using ELearningAcademy.Data;
using ELearningAcademy.Helpers;
using ELearningAcademy.Models;
using ELearningAcademy.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace ELearningAcademy.Services
{
    public class CourseService
    {
        public List<CourseRow> GetCoursesForTeacher()
        {
            using (var db = new AppDbContext())
            {
                var data = db.Courses.AsNoTracking()
                    .OrderBy(c => c.Title)
                    .Select(c => new
                    {
                        c.Id,
                        c.Title,
                        c.Description,
                        c.IsPublished,
                        c.CreatedAt,
                        Modules = c.Modules.Count,
                        Students = c.Enrollments.Count
                    })
                    .ToList();

                return data.Select(c => new CourseRow
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                    ModulesCount = c.Modules,
                    StudentsCount = c.Students,
                    PublishedText = c.IsPublished ? "Так" : "Ні",
                    CreatedAtText = c.CreatedAt.ToString("dd.MM.yyyy")
                }).ToList();
            }
        }

        public List<CatalogCourseRow> GetCatalogForStudent(int studentId)
        {
            using (var db = new AppDbContext())
            {
                var data = db.Courses.AsNoTracking()
                    .Where(c => c.IsPublished || c.Enrollments.Any(e => e.StudentId == studentId))
                    .OrderBy(c => c.Title)
                    .Select(c => new
                    {
                        c.Id,
                        c.Title,
                        c.Description,
                        Modules = c.Modules.Count,
                        Teacher = c.CreatedBy.FullName,
                        Enrolled = c.Enrollments.Any(e => e.StudentId == studentId)
                    })
                    .ToList();

                return data.Select(c => new CatalogCourseRow
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                    ModulesCount = c.Modules,
                    TeacherName = c.Teacher,
                    IsEnrolled = c.Enrolled,
                    EnrolledText = c.Enrolled ? "Так" : "Ні"
                }).ToList();
            }
        }

        public Course GetCourse(int courseId)
        {
            using (var db = new AppDbContext())
            {
                return db.Courses.AsNoTracking().FirstOrDefault(c => c.Id == courseId)
                    ?? throw new BusinessException("Курс не знайдено. Можливо, його вже видалено.");
            }
        }

        public List<ComboItem> GetCourseItems()
        {
            using (var db = new AppDbContext())
            {
                return db.Courses.AsNoTracking()
                    .OrderBy(c => c.Title)
                    .Select(c => new { c.Id, c.Title })
                    .ToList()
                    .Select(c => new ComboItem(c.Id, c.Title))
                    .ToList();
            }
        }

        public List<ComboItem> GetEnrolledCourses(int studentId)
        {
            using (var db = new AppDbContext())
            {
                return db.CourseEnrollments.AsNoTracking()
                    .Where(e => e.StudentId == studentId)
                    .OrderBy(e => e.Course.Title)
                    .Select(e => new { e.CourseId, e.Course.Title })
                    .ToList()
                    .Select(c => new ComboItem(c.CourseId, c.Title))
                    .ToList();
            }
        }

        public int SaveCourse(Course input, int teacherId)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            string title = input.Title?.Trim() ?? string.Empty;
            string description = input.Description?.Trim() ?? string.Empty;

            if (title.Length == 0)
                throw new BusinessException("Введіть назву курсу.");
            if (title.Length > 200)
                throw new BusinessException("Назва курсу не може бути довшою за 200 символів.");
            if (description.Length > 2000)
                throw new BusinessException("Опис курсу не може бути довшим за 2000 символів.");

            using (var db = new AppDbContext())
            {
                if (db.Courses.Any(c => c.Title == title && c.Id != input.Id))
                    throw new BusinessException("Курс з такою назвою вже існує.");

                Course entity;
                if (input.Id == 0)
                {
                    entity = new Course { CreatedByUserId = teacherId, CreatedAt = DateTime.Now };
                    db.Courses.Add(entity);
                }
                else
                {
                    entity = db.Courses.FirstOrDefault(c => c.Id == input.Id)
                        ?? throw new BusinessException("Курс не знайдено.");
                }

                entity.Title = title;
                entity.Description = description;
                entity.IsPublished = input.IsPublished;
                db.SaveChanges();
                return entity.Id;
            }
        }

        public void DeleteCourse(int courseId)
        {
            using (var db = new AppDbContext())
            using (var transaction = db.Database.BeginTransaction())
            {
                var course = db.Courses.FirstOrDefault(c => c.Id == courseId)
                    ?? throw new BusinessException("Курс не знайдено.");

                var testIds = db.Tests.Where(t => t.Module.CourseId == courseId).Select(t => t.Id).ToList();
                TestService.DeleteAttemptsForTests(db, testIds);

                db.Courses.Remove(course);
                db.SaveChanges();
                transaction.Commit();
            }
        }

        public void Enroll(int studentId, int courseId)
        {
            using (var db = new AppDbContext())
            {
                var course = db.Courses.FirstOrDefault(c => c.Id == courseId)
                    ?? throw new BusinessException("Курс не знайдено.");
                if (!course.IsPublished)
                    throw new BusinessException("Цей курс ще не опублікований викладачем.");
                if (db.CourseEnrollments.Any(e => e.CourseId == courseId && e.StudentId == studentId))
                    throw new BusinessException("Ви вже записані на цей курс.");

                db.CourseEnrollments.Add(new CourseEnrollment
                {
                    CourseId = courseId,
                    StudentId = studentId,
                    EnrolledAt = DateTime.Now
                });
                db.SaveChanges();
            }
        }
    }
}
