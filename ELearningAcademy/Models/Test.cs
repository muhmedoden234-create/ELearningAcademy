namespace ELearningAcademy.Models
{
    public class Test
    {
        public int Id { get; set; }

        public int ModuleId { get; set; }
        public CourseModule Module { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public List<Question> Questions { get; set; } = new List<Question>();
        public List<TestAttempt> Attempts { get; set; } = new List<TestAttempt>();
    }
}
