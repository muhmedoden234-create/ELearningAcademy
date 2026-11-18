namespace ELearningAcademy.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsPublished { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int CreatedByUserId { get; set; }
        public User CreatedBy { get; set; }

        public List<CourseModule> Modules { get; set; } = new List<CourseModule>();
        public List<CourseEnrollment> Enrollments { get; set; } = new List<CourseEnrollment>();
    }
}
