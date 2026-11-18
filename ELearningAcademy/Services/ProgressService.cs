using ELearningAcademy.Data;
using ELearningAcademy.Helpers;
using ELearningAcademy.Models;
using ELearningAcademy.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace ELearningAcademy.Services
{
    public class ProgressService
    {
        public int GetCourseProgressPercent(int studentId, int courseId, out int passedTests, out int totalTests)
        {
            var statuses = new ModuleAccessService().GetModuleStatuses(studentId, courseId);
            var withTests = statuses.Where(s => s.HasTest).ToList();

            totalTests = withTests.Count;
            passedTests = withTests.Count(s => s.IsPassed);

            if (totalTests == 0) return 0;
            return (int)Math.Round(passedTests * 100.0 / totalTests, MidpointRounding.AwayFromZero);
        }

        public TeacherStats GetTeacherStats()
        {
            using (var db = new AppDbContext())
            {
                return new TeacherStats
                {
                    CoursesCount = db.Courses.Count(),
                    StudentsCount = db.Users.Count(u => u.Role == UserRole.Student),
                    AttemptsCount = db.TestAttempts.Count()
                };
            }
        }

        public StudentStats GetStudentStats(int studentId)
        {
            using (var db = new AppDbContext())
            {
                var percents = db.TestAttempts.Where(a => a.StudentId == studentId)
                    .Select(a => a.Percent).ToList();

                return new StudentStats
                {
                    EnrolledCoursesCount = db.CourseEnrollments.Count(e => e.StudentId == studentId),
                    PassedTestsCount = db.TestAttempts
                        .Where(a => a.StudentId == studentId && a.IsPassed)
                        .Select(a => a.TestId).Distinct().Count(),
                    AveragePercent = percents.Count > 0 ? Math.Round(percents.Average(), 1) : 0m
                };
            }
        }

        public List<ComboItem> GetStudentItems()
        {
            using (var db = new AppDbContext())
            {
                return db.Users.AsNoTracking()
                    .Where(u => u.Role == UserRole.Student)
                    .OrderBy(u => u.FullName)
                    .Select(u => new { u.Id, u.FullName })
                    .ToList()
                    .Select(u => new ComboItem(u.Id, u.FullName))
                    .ToList();
            }
        }

        public List<ComboItem> GetStudentsWithAttempts(int courseId)
        {
            using (var db = new AppDbContext())
            {
                return db.TestAttempts.AsNoTracking()
                    .Where(a => a.Test.Module.CourseId == courseId)
                    .Select(a => new { a.StudentId, a.Student.FullName })
                    .Distinct()
                    .OrderBy(x => x.FullName)
                    .ToList()
                    .Select(x => new ComboItem(x.StudentId, x.FullName))
                    .ToList();
            }
        }

        public List<AttemptRow> GetAttempts(int? courseId, int? studentId)
        {
            using (var db = new AppDbContext())
            {
                IQueryable<TestAttempt> query = db.TestAttempts.AsNoTracking()
                    .Include(a => a.Student)
                    .Include(a => a.Test).ThenInclude(t => t.Module).ThenInclude(m => m.Course);

                if (courseId.HasValue)
                    query = query.Where(a => a.Test.Module.CourseId == courseId.Value);
                if (studentId.HasValue)
                    query = query.Where(a => a.StudentId == studentId.Value);

                return query.OrderByDescending(a => a.FinishedAt)
                    .ToList()
                    .Select(a => new AttemptRow
                    {
                        Id = a.Id,
                        StudentId = a.StudentId,
                        StudentName = a.Student.FullName,
                        CourseTitle = a.Test.Module.Course.Title,
                        ModuleTitle = a.Test.Module.Title,
                        TestTitle = a.Test.Title,
                        FinishedAt = a.FinishedAt,
                        FinishedAtText = a.FinishedAt.ToString("dd.MM.yyyy HH:mm"),
                        ScoreObtained = a.ScoreObtained,
                        MaxScore = a.MaxScore,
                        ScoreText = $"{a.ScoreObtained} з {a.MaxScore}",
                        Percent = a.Percent,
                        PercentText = a.Percent.ToString("0.##") + " %",
                        IsPassed = a.IsPassed,
                        StatusText = a.IsPassed ? "Складено" : "Не складено"
                    })
                    .ToList();
            }
        }

        public AttemptDetails GetAttemptDetails(int attemptId, int? restrictToStudentId)
        {
            using (var db = new AppDbContext())
            {
                var attempt = db.TestAttempts.AsNoTracking()
                    .Include(a => a.Student)
                    .Include(a => a.Test).ThenInclude(t => t.Module).ThenInclude(m => m.Course)
                    .Include(a => a.Answers).ThenInclude(sa => sa.Question).ThenInclude(q => q.Options)
                    .Include(a => a.Answers).ThenInclude(sa => sa.SelectedOptions).ThenInclude(so => so.AnswerOption)
                    .AsSplitQuery()
                    .FirstOrDefault(a => a.Id == attemptId)
                    ?? throw new BusinessException("Спробу не знайдено.");

                if (restrictToStudentId.HasValue && attempt.StudentId != restrictToStudentId.Value)
                    throw new BusinessException("Ви можете переглядати лише власні результати.");

                var details = new AttemptDetails
                {
                    AttemptId = attempt.Id,
                    StudentName = attempt.Student.FullName,
                    CourseTitle = attempt.Test.Module.Course.Title,
                    ModuleTitle = attempt.Test.Module.Title,
                    TestTitle = attempt.Test.Title,
                    StartedAt = attempt.StartedAt,
                    FinishedAt = attempt.FinishedAt,
                    ScoreObtained = attempt.ScoreObtained,
                    MaxScore = attempt.MaxScore,
                    Percent = attempt.Percent,
                    IsPassed = attempt.IsPassed
                };

                int number = 1;
                foreach (var answer in attempt.Answers
                             .OrderBy(a => a.Question.OrderIndex).ThenBy(a => a.QuestionId))
                {
                    Question question = answer.Question;
                    var correctOptions = question.Options
                        .Where(o => o.IsCorrect)
                        .OrderBy(o => o.OrderIndex)
                        .Select(o => o.Text)
                        .ToList();

                    string studentText;
                    string correctText;

                    if (question.Type == QuestionType.TextInput)
                    {
                        studentText = string.IsNullOrWhiteSpace(answer.TextAnswer) ? "(немає відповіді)" : answer.TextAnswer;
                        correctText = string.Join(" або ", correctOptions);
                    }
                    else
                    {
                        var selected = answer.SelectedOptions
                            .Where(so => so.AnswerOption != null)
                            .OrderBy(so => so.AnswerOption.OrderIndex)
                            .Select(so => so.AnswerOption.Text)
                            .ToList();
                        studentText = selected.Count > 0 ? string.Join("; ", selected) : "(немає відповіді)";
                        correctText = string.Join("; ", correctOptions);
                    }

                    details.Answers.Add(new AnswerDetail
                    {
                        Number = number++,
                        QuestionText = question.Text,
                        QuestionTypeName = QuestionTypeNames.GetName(question.Type),
                        StudentAnswerText = studentText,
                        CorrectAnswerText = correctText,
                        PointsAwarded = answer.PointsAwarded,
                        MaxPoints = question.Points,
                        IsCorrect = answer.IsCorrect,
                        ResultText = answer.IsCorrect ? "✔ Правильно" : "✘ Неправильно"
                    });
                }

                return details;
            }
        }
    }
}
