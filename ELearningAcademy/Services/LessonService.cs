using ELearningAcademy.Data;
using ELearningAcademy.Helpers;
using ELearningAcademy.Models;
using ELearningAcademy.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace ELearningAcademy.Services
{
    public class LessonService
    {
        public List<LessonRow> GetLessons(int moduleId)
        {
            using (var db = new AppDbContext())
            {
                var data = db.Lessons.AsNoTracking()
                    .Where(l => l.ModuleId == moduleId)
                    .OrderBy(l => l.OrderIndex).ThenBy(l => l.Id)
                    .Select(l => new { l.Id, l.Title })
                    .ToList();

                return data.Select((l, i) => new LessonRow { Id = l.Id, Position = i + 1, Title = l.Title }).ToList();
            }
        }

        public List<int> GetLessonIds(int moduleId)
        {
            using (var db = new AppDbContext())
            {
                return db.Lessons.AsNoTracking()
                    .Where(l => l.ModuleId == moduleId)
                    .OrderBy(l => l.OrderIndex).ThenBy(l => l.Id)
                    .Select(l => l.Id)
                    .ToList();
            }
        }

        public Lesson GetLesson(int lessonId)
        {
            using (var db = new AppDbContext())
            {
                return db.Lessons.AsNoTracking()
                    .Include(l => l.Module)
                    .FirstOrDefault(l => l.Id == lessonId)
                    ?? throw new BusinessException("Урок не знайдено.");
            }
        }

        public Lesson GetLessonForStudent(int studentId, int lessonId)
        {
            using (var db = new AppDbContext())
            {
                var lesson = db.Lessons.AsNoTracking()
                    .Include(l => l.Module)
                    .FirstOrDefault(l => l.Id == lessonId)
                    ?? throw new BusinessException("Урок не знайдено.");

                new ModuleAccessService().EnsureModuleUnlocked(db, studentId, lesson.ModuleId);
                return lesson;
            }
        }

        public int SaveLesson(Lesson input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            string title = input.Title?.Trim() ?? string.Empty;
            if (title.Length == 0)
                throw new BusinessException("Введіть назву уроку.");
            if (title.Length > 200)
                throw new BusinessException("Назва уроку не може бути довшою за 200 символів.");

            using (var db = new AppDbContext())
            {
                if (!db.Modules.Any(m => m.Id == input.ModuleId))
                    throw new BusinessException("Модуль не знайдено.");

                Lesson entity;
                if (input.Id == 0)
                {
                    int nextOrder = (db.Lessons.Where(l => l.ModuleId == input.ModuleId)
                        .Max(l => (int?)l.OrderIndex) ?? 0) + 1;
                    entity = new Lesson { ModuleId = input.ModuleId, OrderIndex = nextOrder, CreatedAt = DateTime.Now };
                    db.Lessons.Add(entity);
                }
                else
                {
                    entity = db.Lessons.FirstOrDefault(l => l.Id == input.Id && l.ModuleId == input.ModuleId)
                        ?? throw new BusinessException("Урок не знайдено.");
                }

                entity.Title = title;
                entity.ContentRtf = input.ContentRtf ?? string.Empty;
                db.SaveChanges();
                return entity.Id;
            }
        }

        public void DeleteLesson(int lessonId)
        {
            using (var db = new AppDbContext())
            using (var transaction = db.Database.BeginTransaction())
            {
                var lesson = db.Lessons.FirstOrDefault(l => l.Id == lessonId)
                    ?? throw new BusinessException("Урок не знайдено.");
                int moduleId = lesson.ModuleId;

                db.Lessons.Remove(lesson);
                db.SaveChanges();

                var rest = db.Lessons.Where(l => l.ModuleId == moduleId)
                    .OrderBy(l => l.OrderIndex).ThenBy(l => l.Id).ToList();
                for (int i = 0; i < rest.Count; i++)
                    rest[i].OrderIndex = i + 1;
                db.SaveChanges();

                transaction.Commit();
            }
        }

        public void MoveLesson(int lessonId, int direction)
        {
            using (var db = new AppDbContext())
            {
                var lesson = db.Lessons.FirstOrDefault(l => l.Id == lessonId)
                    ?? throw new BusinessException("Урок не знайдено.");

                var siblings = db.Lessons.Where(l => l.ModuleId == lesson.ModuleId)
                    .OrderBy(l => l.OrderIndex).ThenBy(l => l.Id).ToList();

                int index = siblings.FindIndex(l => l.Id == lessonId);
                int target = index + direction;
                if (target < 0 || target >= siblings.Count)
                    return;

                Lesson temp = siblings[index];
                siblings[index] = siblings[target];
                siblings[target] = temp;

                for (int i = 0; i < siblings.Count; i++)
                    siblings[i].OrderIndex = i + 1;

                db.SaveChanges();
            }
        }
    }
}
