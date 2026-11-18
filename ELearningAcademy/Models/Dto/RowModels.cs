using System.ComponentModel;

namespace ELearningAcademy.Models.Dto
{
    public class CourseRow
    {
        [Browsable(false)] public int Id { get; set; }
        [DisplayName("Назва курсу")] public string Title { get; set; }
        [DisplayName("Опис")] public string Description { get; set; }
        [DisplayName("Модулів")] public int ModulesCount { get; set; }
        [DisplayName("Студентів")] public int StudentsCount { get; set; }
        [DisplayName("Опубліковано")] public string PublishedText { get; set; }
        [DisplayName("Створено")] public string CreatedAtText { get; set; }
    }

    public class CatalogCourseRow
    {
        [Browsable(false)] public int Id { get; set; }
        [Browsable(false)] public bool IsEnrolled { get; set; }
        [DisplayName("Назва курсу")] public string Title { get; set; }
        [DisplayName("Опис")] public string Description { get; set; }
        [DisplayName("Модулів")] public int ModulesCount { get; set; }
        [DisplayName("Викладач")] public string TeacherName { get; set; }
        [DisplayName("Ви записані")] public string EnrolledText { get; set; }
    }

    public class ModuleRow
    {
        [Browsable(false)] public int Id { get; set; }
        [DisplayName("№")] public int Position { get; set; }
        [DisplayName("Назва модуля")] public string Title { get; set; }
        [DisplayName("Опис")] public string Description { get; set; }
        [DisplayName("Уроків")] public int LessonsCount { get; set; }
        [DisplayName("Тест")] public string TestInfo { get; set; }
    }

    public class LessonRow
    {
        [Browsable(false)] public int Id { get; set; }
        [DisplayName("№")] public int Position { get; set; }
        [DisplayName("Назва уроку")] public string Title { get; set; }
    }

    public class QuestionRow
    {
        [Browsable(false)] public int Id { get; set; }
        [DisplayName("№")] public int Number { get; set; }
        [DisplayName("Питання")] public string Text { get; set; }
        [DisplayName("Тип")] public string TypeName { get; set; }
        [DisplayName("Бали")] public int Points { get; set; }
        [DisplayName("Зображення")] public string ImageText { get; set; }
    }
}
