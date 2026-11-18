namespace ELearningAcademy.Models
{
    public class Lesson
    {
        public int Id { get; set; }

        public int ModuleId { get; set; }
        public CourseModule Module { get; set; }

        public string Title { get; set; } = string.Empty;
        public string ContentRtf { get; set; } = string.Empty;
        public int OrderIndex { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
