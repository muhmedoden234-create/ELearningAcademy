using System.ComponentModel;

namespace ELearningAcademy.Models.Dto
{
    public class ModuleProgressInfo
    {
        [Browsable(false)] public int ModuleId { get; set; }
        [Browsable(false)] public int? TestId { get; set; }
        [Browsable(false)] public bool HasTest { get; set; }
        [Browsable(false)] public bool IsUnlocked { get; set; }
        [Browsable(false)] public bool IsPassed { get; set; }
        [Browsable(false)] public decimal? BestPercent { get; set; }

        [DisplayName("№")] public int Position { get; set; }
        [DisplayName("Модуль")] public string Title { get; set; }
        [DisplayName("Уроків")] public int LessonsCount { get; set; }
        [DisplayName("Статус")] public string StatusText { get; set; }
        [DisplayName("Найкращий результат")] public string BestResultText { get; set; }
        [DisplayName("Спроб")] public int AttemptsCount { get; set; }
    }

    public class AttemptRow
    {
        [Browsable(false)] public int Id { get; set; }
        [Browsable(false)] public int StudentId { get; set; }
        [Browsable(false)] public int ScoreObtained { get; set; }
        [Browsable(false)] public int MaxScore { get; set; }
        [Browsable(false)] public decimal Percent { get; set; }
        [Browsable(false)] public bool IsPassed { get; set; }
        [Browsable(false)] public DateTime FinishedAt { get; set; }

        [DisplayName("Студент")] public string StudentName { get; set; }
        [DisplayName("Курс")] public string CourseTitle { get; set; }
        [DisplayName("Модуль")] public string ModuleTitle { get; set; }
        [DisplayName("Тест")] public string TestTitle { get; set; }
        [DisplayName("Дата")] public string FinishedAtText { get; set; }
        [DisplayName("Бали")] public string ScoreText { get; set; }
        [DisplayName("Відсоток")] public string PercentText { get; set; }
        [DisplayName("Статус")] public string StatusText { get; set; }
    }

    public class AttemptDetails
    {
        public int AttemptId { get; set; }
        public string StudentName { get; set; }
        public string CourseTitle { get; set; }
        public string ModuleTitle { get; set; }
        public string TestTitle { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime FinishedAt { get; set; }
        public int ScoreObtained { get; set; }
        public int MaxScore { get; set; }
        public decimal Percent { get; set; }
        public bool IsPassed { get; set; }
        public List<AnswerDetail> Answers { get; set; } = new List<AnswerDetail>();
    }

    public class AnswerDetail
    {
        [Browsable(false)] public bool IsCorrect { get; set; }
        [Browsable(false)] public string QuestionTypeName { get; set; }

        [DisplayName("№")] public int Number { get; set; }
        [DisplayName("Питання")] public string QuestionText { get; set; }
        [DisplayName("Відповідь студента")] public string StudentAnswerText { get; set; }
        [DisplayName("Правильна відповідь")] public string CorrectAnswerText { get; set; }
        [DisplayName("Бали")] public int PointsAwarded { get; set; }
        [DisplayName("Макс.")] public int MaxPoints { get; set; }
        [DisplayName("Результат")] public string ResultText { get; set; }
    }

    public class TeacherStats
    {
        public int CoursesCount { get; set; }
        public int StudentsCount { get; set; }
        public int AttemptsCount { get; set; }
    }

    public class StudentStats
    {
        public int EnrolledCoursesCount { get; set; }
        public int PassedTestsCount { get; set; }
        public decimal AveragePercent { get; set; }
    }
}
