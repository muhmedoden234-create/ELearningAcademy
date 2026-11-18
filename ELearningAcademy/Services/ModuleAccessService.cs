using ELearningAcademy.Data;
using ELearningAcademy.Helpers;
using ELearningAcademy.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace ELearningAcademy.Services
{
    public class ModuleAccessService
    {
        public List<ModuleProgressInfo> GetModuleStatuses(int studentId, int courseId)
        {
            using (var db = new AppDbContext())
            {
                return GetModuleStatuses(db, studentId, courseId);
            }
        }

        internal List<ModuleProgressInfo> GetModuleStatuses(AppDbContext db, int studentId, int courseId)
        {
            var modules = db.Modules.AsNoTracking()
                .Where(m => m.CourseId == courseId)
                .OrderBy(m => m.OrderIndex).ThenBy(m => m.Id)
                .Select(m => new
                {
                    m.Id,
                    m.Title,
                    LessonsCount = m.Lessons.Count,
                    TestId = m.Test != null ? (int?)m.Test.Id : null
                })
                .ToList();

            var testIds = modules.Where(m => m.TestId.HasValue).Select(m => m.TestId.Value).ToList();

            var attempts = db.TestAttempts.AsNoTracking()
                .Where(a => a.StudentId == studentId && testIds.Contains(a.TestId))
                .Select(a => new { a.TestId, a.Percent, a.IsPassed })
                .ToList();

            var result = new List<ModuleProgressInfo>();
            bool previousCompleted = true;
            int position = 1;

            foreach (var m in modules)
            {
                var info = new ModuleProgressInfo
                {
                    ModuleId = m.Id,
                    Position = position++,
                    Title = m.Title,
                    LessonsCount = m.LessonsCount,
                    TestId = m.TestId,
                    HasTest = m.TestId.HasValue,
                    IsUnlocked = previousCompleted
                };

                if (info.HasTest)
                {
                    var myAttempts = attempts.Where(a => a.TestId == m.TestId.Value).ToList();
                    info.AttemptsCount = myAttempts.Count;
                    info.BestPercent = myAttempts.Count > 0 ? myAttempts.Max(a => a.Percent) : (decimal?)null;
                    info.IsPassed = myAttempts.Any(a => a.IsPassed);
                }
                else
                {
                    info.IsPassed = true;
                }

                info.StatusText = !info.IsUnlocked ? "Заблоковано"
                    : !info.HasTest ? "Відкрито (без тесту)"
                    : info.IsPassed ? "Складено"
                    : info.AttemptsCount > 0 ? "Не складено — повторіть тест"
                    : "Відкрито";

                info.BestResultText = info.BestPercent.HasValue ? info.BestPercent.Value.ToString("0.##") + " %" : "—";

                result.Add(info);
                previousCompleted = info.IsUnlocked && info.IsPassed;
            }

            return result;
        }

        internal void EnsureModuleUnlocked(AppDbContext db, int studentId, int moduleId)
        {
            var module = db.Modules.AsNoTracking().FirstOrDefault(m => m.Id == moduleId)
                ?? throw new BusinessException("Модуль не знайдено.");

            bool enrolled = db.CourseEnrollments.Any(e => e.CourseId == module.CourseId && e.StudentId == studentId);
            if (!enrolled)
                throw new BusinessException("Ви не записані на курс, до якого належить цей модуль.");

            var statuses = GetModuleStatuses(db, studentId, module.CourseId);
            var status = statuses.FirstOrDefault(s => s.ModuleId == moduleId);

            if (status == null || !status.IsUnlocked)
            {
                throw new BusinessException(
                    $"Модуль «{module.Title}» заблоковано.\n" +
                    $"Щоб відкрити його, складіть тест попереднього модуля щонайменше на {GradingService.PassingPercent:0}%.");
            }
        }
    }
}
