using ELearningAcademy.Data;
using ELearningAcademy.Helpers;
using ELearningAcademy.Models;
using ELearningAcademy.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace ELearningAcademy.Services
{
    public class ModuleService
    {
        public List<ModuleRow> GetModules(int courseId)
        {
            using (var db = new AppDbContext())
            {
                var data = db.Modules.AsNoTracking()
                    .Where(m => m.CourseId == courseId)
                    .OrderBy(m => m.OrderIndex).ThenBy(m => m.Id)
                    .Select(m => new
                    {
                        m.Id,
                        m.Title,
                        m.Description,
                        Lessons = m.Lessons.Count,
                        HasTest = m.Test != null,
                        QuestionsCount = m.Test != null ? m.Test.Questions.Count : 0
                    })
                    .ToList();

                return data.Select((m, index) => new ModuleRow
                {
                    Id = m.Id,
                    Position = index + 1,
                    Title = m.Title,
                    Description = m.Description,
                    LessonsCount = m.Lessons,
                    TestInfo = m.HasTest ? $"Є ({m.QuestionsCount} пит.)" : "Немає"
                }).ToList();
            }
        }

        public CourseModule GetModule(int moduleId)
        {
            using (var db = new AppDbContext())
            {
                return db.Modules.AsNoTracking()
                    .Include(m => m.Course)
                    .FirstOrDefault(m => m.Id == moduleId)
                    ?? throw new BusinessException("Модуль не знайдено.");
            }
        }

        public int SaveModule(CourseModule input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            string title = input.Title?.Trim() ?? string.Empty;
            string description = input.Description?.Trim() ?? string.Empty;

            if (title.Length == 0)
                throw new BusinessException("Введіть назву модуля.");
            if (title.Length > 200)
                throw new BusinessException("Назва модуля не може бути довшою за 200 символів.");
            if (description.Length > 2000)
                throw new BusinessException("Опис модуля не може бути довшим за 2000 символів.");

            using (var db = new AppDbContext())
            {
                if (!db.Courses.Any(c => c.Id == input.CourseId))
                    throw new BusinessException("Курс не знайдено.");

                CourseModule entity;
                if (input.Id == 0)
                {
                    int nextOrder = (db.Modules.Where(m => m.CourseId == input.CourseId)
                        .Max(m => (int?)m.OrderIndex) ?? 0) + 1;
                    entity = new CourseModule { CourseId = input.CourseId, OrderIndex = nextOrder };
                    db.Modules.Add(entity);
                }
                else
                {
                    entity = db.Modules.FirstOrDefault(m => m.Id == input.Id && m.CourseId == input.CourseId)
                        ?? throw new BusinessException("Модуль не знайдено.");
                }

                entity.Title = title;
                entity.Description = description;
                db.SaveChanges();
                return entity.Id;
            }
        }

        public void DeleteModule(int moduleId)
        {
            using (var db = new AppDbContext())
            using (var transaction = db.Database.BeginTransaction())
            {
                var module = db.Modules.FirstOrDefault(m => m.Id == moduleId)
                    ?? throw new BusinessException("Модуль не знайдено.");
                int courseId = module.CourseId;

                var testIds = db.Tests.Where(t => t.ModuleId == moduleId).Select(t => t.Id).ToList();
                TestService.DeleteAttemptsForTests(db, testIds);

                db.Modules.Remove(module);
                db.SaveChanges();

                var rest = db.Modules.Where(m => m.CourseId == courseId)
                    .OrderBy(m => m.OrderIndex).ThenBy(m => m.Id).ToList();
                for (int i = 0; i < rest.Count; i++)
                    rest[i].OrderIndex = i + 1;
                db.SaveChanges();

                transaction.Commit();
            }
        }

        public void MoveModule(int moduleId, int direction)
        {
            using (var db = new AppDbContext())
            {
                var module = db.Modules.FirstOrDefault(m => m.Id == moduleId)
                    ?? throw new BusinessException("Модуль не знайдено.");

                var siblings = db.Modules.Where(m => m.CourseId == module.CourseId)
                    .OrderBy(m => m.OrderIndex).ThenBy(m => m.Id).ToList();

                int index = siblings.FindIndex(m => m.Id == moduleId);
                int target = index + direction;
                if (target < 0 || target >= siblings.Count)
                    return;

                CourseModule temp = siblings[index];
                siblings[index] = siblings[target];
                siblings[target] = temp;

                for (int i = 0; i < siblings.Count; i++)
                    siblings[i].OrderIndex = i + 1;

                db.SaveChanges();
            }
        }
    }
}
