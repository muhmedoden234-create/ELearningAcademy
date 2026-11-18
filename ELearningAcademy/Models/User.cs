namespace ELearningAcademy.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public UserRole Role { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public List<CourseEnrollment> Enrollments { get; set; } = new List<CourseEnrollment>();
        public List<TestAttempt> TestAttempts { get; set; } = new List<TestAttempt>();
        public List<Course> CreatedCourses { get; set; } = new List<Course>();
    }
}
