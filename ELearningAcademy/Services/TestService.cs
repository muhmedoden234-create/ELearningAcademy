using ELearningAcademy.Data;
using ELearningAcademy.Helpers;
using ELearningAcademy.Models;
using ELearningAcademy.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace ELearningAcademy.Services
{
    public class TestService
    {
        public Test GetTestForEditing(int moduleId)
        {
            using (var db = new AppDbContext())
            {
                var test = db.Tests.AsNoTracking()
                    .Include(t => t.Questions).ThenInclude(q => q.Options)
                    .AsSplitQuery()
                    .FirstOrDefault(t => t.ModuleId == moduleId);

                if (test != null)
                {
                    test.Questions = test.Questions.OrderBy(q => q.OrderIndex).ThenBy(q => q.Id).ToList();
                    foreach (var q in test.Questions)
                        q.Options = q.Options.OrderBy(o => o.OrderIndex).ThenBy(o => o.Id).ToList();
                }
                return test;
            }
        }

        public int SaveTest(int moduleId, string title, string description)
        {
            title = title?.Trim() ?? string.Empty;
            description = description?.Trim() ?? string.Empty;

            if (title.Length == 0)
                throw new BusinessException("Введіть назву тесту.");
            if (title.Length > 200)
                throw new BusinessException("Назва тесту не може бути довшою за 200 символів.");
            if (description.Length > 1000)
                throw new BusinessException("Опис тесту не може бути довшим за 1000 символів.");

            using (var db = new AppDbContext())
            {
                if (!db.Modules.Any(m => m.Id == moduleId))
                    throw new BusinessException("Модуль не знайдено.");

                var test = db.Tests.FirstOrDefault(t => t.ModuleId == moduleId);
                if (test == null)
                {
                    test = new Test { ModuleId = moduleId };
                    db.Tests.Add(test);
                }
                test.Title = title;
                test.Description = description;
                db.SaveChanges();
                return test.Id;
            }
        }

        internal static void DeleteAttemptsForTests(AppDbContext db, List<int> testIds)
        {
            if (testIds.Count > 0)
                db.TestAttempts.Where(a => testIds.Contains(a.TestId)).ExecuteDelete();
        }

        public void DeleteTest(int testId)
        {
            using (var db = new AppDbContext())
            using (var transaction = db.Database.BeginTransaction())
            {
                var test = db.Tests.FirstOrDefault(t => t.Id == testId)
                    ?? throw new BusinessException("Тест не знайдено.");

                DeleteAttemptsForTests(db, new List<int> { testId });
                db.Tests.Remove(test);
                db.SaveChanges();
                transaction.Commit();
            }
        }

        public static void ValidateQuestion(QuestionEditModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            string text = model.Text?.Trim() ?? string.Empty;
            if (text.Length == 0)
                throw new BusinessException("Введіть текст питання.");
            if (text.Length > 2000)
                throw new BusinessException("Текст питання не може бути довшим за 2000 символів.");
            if (model.Points < 1 || model.Points > 100)
                throw new BusinessException("Вага питання повинна бути від 1 до 100 балів.");
            if (model.ImageData != null && model.ImageData.Length > ImageHelper.MaxImageBytes)
                throw new BusinessException("Зображення завелике (максимум 900 КБ).");

            var options = model.Options.Where(o => !string.IsNullOrWhiteSpace(o.Text)).ToList();

            if (options.Any(o => o.Text.Trim().Length > 500))
                throw new BusinessException("Текст варіанта відповіді не може бути довшим за 500 символів.");

            bool hasDuplicates = options
                .GroupBy(o => GradingService.NormalizeText(o.Text))
                .Any(g => g.Count() > 1);
            if (hasDuplicates)
                throw new BusinessException("Варіанти відповідей не повинні повторюватися.");

            int correctCount = options.Count(o => o.IsCorrect);

            switch (model.Type)
            {
                case QuestionType.SingleChoice:
                    if (options.Count < 2)
                        throw new BusinessException("Для питання з однією відповіддю потрібно щонайменше 2 варіанти.");
                    if (correctCount != 1)
                        throw new BusinessException("Для питання з однією відповіддю позначте рівно ОДИН правильний варіант.");
                    break;

                case QuestionType.MultipleChoice:
                    if (options.Count < 2)
                        throw new BusinessException("Для питання з кількома відповідями потрібно щонайменше 2 варіанти.");
                    if (correctCount < 1)
                        throw new BusinessException("Позначте хоча б один правильний варіант.");
                    break;

                case QuestionType.TextInput:
                    if (options.Count < 1)
                        throw new BusinessException("Введіть хоча б одну допустиму правильну відповідь.");
                    break;

                default:
                    throw new BusinessException("Оберіть тип питання.");
            }
        }

        public int SaveQuestion(QuestionEditModel model)
        {
            ValidateQuestion(model);

            using (var db = new AppDbContext())
            using (var transaction = db.Database.BeginTransaction())
            {
                if (!db.Tests.Any(t => t.Id == model.TestId))
                    throw new BusinessException("Спочатку збережіть тест.");

                Question question;
                if (model.Id == 0)
                {
                    int nextOrder = (db.Questions.Where(q => q.TestId == model.TestId)
                        .Max(q => (int?)q.OrderIndex) ?? 0) + 1;
                    question = new Question { TestId = model.TestId, OrderIndex = nextOrder };
                    db.Questions.Add(question);
                }
                else
                {
                    question = db.Questions.Include(q => q.Options)
                        .FirstOrDefault(q => q.Id == model.Id && q.TestId == model.TestId)
                        ?? throw new BusinessException("Питання не знайдено.");
                }

                question.Text = model.Text.Trim();
                question.Type = model.Type;
                question.Points = model.Points;
                question.ImageData = model.ImageData;

                bool isText = model.Type == QuestionType.TextInput;
                var newOptions = model.Options.Where(o => !string.IsNullOrWhiteSpace(o.Text)).ToList();
                var keepIds = newOptions.Where(o => o.Id > 0).Select(o => o.Id).ToHashSet();

                var toRemove = question.Options.Where(o => !keepIds.Contains(o.Id)).ToList();
                if (toRemove.Count > 0)
                {
                    var removeIds = toRemove.Select(o => o.Id).ToList();
                    db.StudentAnswerOptions.Where(x => removeIds.Contains(x.AnswerOptionId)).ExecuteDelete();
                    foreach (var option in toRemove)
                    {
                        question.Options.Remove(option);
                        db.AnswerOptions.Remove(option);
                    }
                }

                int order = 1;
                foreach (var optionModel in newOptions)
                {
                    AnswerOption option = optionModel.Id > 0
                        ? question.Options.FirstOrDefault(o => o.Id == optionModel.Id)
                        : null;

                    if (option == null)
                    {
                        option = new AnswerOption();
                        question.Options.Add(option);
                    }

                    option.Text = optionModel.Text.Trim();
                    option.IsCorrect = isText || optionModel.IsCorrect;
                    option.OrderIndex = order++;
                }

                db.SaveChanges();
                transaction.Commit();
                return question.Id;
            }
        }

        public void DeleteQuestion(int questionId)
        {
            using (var db = new AppDbContext())
            using (var transaction = db.Database.BeginTransaction())
            {
                var question = db.Questions.FirstOrDefault(q => q.Id == questionId)
                    ?? throw new BusinessException("Питання не знайдено.");
                int testId = question.TestId;

                db.StudentAnswers.Where(a => a.QuestionId == questionId).ExecuteDelete();

                db.Questions.Remove(question);
                db.SaveChanges();

                var rest = db.Questions.Where(q => q.TestId == testId)
                    .OrderBy(q => q.OrderIndex).ThenBy(q => q.Id).ToList();
                for (int i = 0; i < rest.Count; i++)
                    rest[i].OrderIndex = i + 1;
                db.SaveChanges();

                transaction.Commit();
            }
        }

        public StudentTestView GetTestForStudent(int studentId, int moduleId)
        {
            using (var db = new AppDbContext())
            {
                new ModuleAccessService().EnsureModuleUnlocked(db, studentId, moduleId);

                var test = db.Tests.AsNoTracking()
                    .Include(t => t.Module)
                    .Include(t => t.Questions).ThenInclude(q => q.Options)
                    .AsSplitQuery()
                    .FirstOrDefault(t => t.ModuleId == moduleId)
                    ?? throw new BusinessException("Для цього модуля ще не створено тест.");

                if (test.Questions.Count == 0)
                    throw new BusinessException("Тест поки що не містить жодного питання.");

                var view = new StudentTestView
                {
                    TestId = test.Id,
                    Title = test.Title,
                    Description = test.Description,
                    ModuleTitle = test.Module.Title
                };

                int number = 1;
                foreach (var q in test.Questions.OrderBy(q => q.OrderIndex).ThenBy(q => q.Id))
                {
                    view.Questions.Add(new StudentQuestionView
                    {
                        Id = q.Id,
                        Number = number++,
                        Text = q.Text,
                        Type = q.Type,
                        Points = q.Points,
                        ImageData = q.ImageData,

                        Options = q.Type == QuestionType.TextInput
                            ? new List<StudentOptionView>()
                            : q.Options.OrderBy(o => o.OrderIndex).ThenBy(o => o.Id)
                                .Select(o => new StudentOptionView { Id = o.Id, Text = o.Text })
                                .ToList()
                    });
                }
                return view;
            }
        }

        public AttemptResult SubmitAttempt(int studentId, int testId, IList<StudentAnswerInput> answers, DateTime startedAt)
        {
            answers = answers ?? new List<StudentAnswerInput>();

            using (var db = new AppDbContext())
            {
                var test = db.Tests.AsNoTracking()
                    .Include(t => t.Module)
                    .Include(t => t.Questions).ThenInclude(q => q.Options)
                    .AsSplitQuery()
                    .FirstOrDefault(t => t.Id == testId)
                    ?? throw new BusinessException("Тест не знайдено.");

                new ModuleAccessService().EnsureModuleUnlocked(db, studentId, test.ModuleId);

                if (test.Questions.Count == 0)
                    throw new BusinessException("Тест не містить питань.");

                var attempt = new TestAttempt
                {
                    TestId = testId,
                    StudentId = studentId,
                    StartedAt = startedAt,
                    FinishedAt = DateTime.Now
                };

                int obtained = 0;
                int max = 0;

                foreach (var question in test.Questions.OrderBy(q => q.OrderIndex).ThenBy(q => q.Id))
                {
                    var input = answers.FirstOrDefault(a => a.QuestionId == question.Id)
                                ?? new StudentAnswerInput { QuestionId = question.Id };

                    QuestionGradeResult grade = GradingService.GradeQuestion(question, input);

                    var studentAnswer = new StudentAnswer
                    {
                        QuestionId = question.Id,
                        IsCorrect = grade.IsCorrect,
                        PointsAwarded = grade.PointsAwarded,
                        TextAnswer = question.Type == QuestionType.TextInput
                            ? Truncate(input.TextAnswer?.Trim(), 1000)
                            : null
                    };

                    if (question.Type != QuestionType.TextInput)
                    {
                        var validIds = question.Options.Select(o => o.Id).ToHashSet();
                        foreach (int optionId in input.SelectedOptionIds.Distinct().Where(validIds.Contains))
                            studentAnswer.SelectedOptions.Add(new StudentAnswerOption { AnswerOptionId = optionId });
                    }

                    attempt.Answers.Add(studentAnswer);
                    obtained += grade.PointsAwarded;
                    max += question.Points;
                }

                attempt.ScoreObtained = obtained;
                attempt.MaxScore = max;
                attempt.Percent = GradingService.CalculatePercent(obtained, max);
                attempt.IsPassed = GradingService.IsPassed(obtained, max);

                using (var transaction = db.Database.BeginTransaction())
                {
                    db.TestAttempts.Add(attempt);
                    db.SaveChanges();
                    transaction.Commit();
                }

                var statuses = new ModuleAccessService().GetModuleStatuses(db, studentId, test.Module.CourseId);
                int index = statuses.FindIndex(s => s.ModuleId == test.ModuleId);
                ModuleProgressInfo next = index >= 0 && index + 1 < statuses.Count ? statuses[index + 1] : null;

                return new AttemptResult
                {
                    AttemptId = attempt.Id,
                    ScoreObtained = obtained,
                    MaxScore = max,
                    Percent = attempt.Percent,
                    IsPassed = attempt.IsPassed,
                    NextModuleTitle = next?.Title,
                    NextModuleUnlocked = next != null && next.IsUnlocked
                };
            }
        }

        private static string Truncate(string value, int maxLength)
        {
            if (value == null) return null;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
    }
}
