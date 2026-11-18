namespace ELearningAcademy.Models
{
    public class CourseModule
    {
        public int Id { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int OrderIndex { get; set; }

        public List<Lesson> Lessons { get; set; } = new List<Lesson>();
        public Test Test { get; set; }
    }
}
