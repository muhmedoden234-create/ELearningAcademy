namespace ELearningAcademy.Models
{
    public class TestAttempt
    {
        public int Id { get; set; }

        public int TestId { get; set; }
        public Test Test { get; set; }

        public int StudentId { get; set; }
        public User Student { get; set; }

        public DateTime StartedAt { get; set; }
        public DateTime FinishedAt { get; set; }

        public int ScoreObtained { get; set; }
        public int MaxScore { get; set; }
        public decimal Percent { get; set; }
        public bool IsPassed { get; set; }

        public List<StudentAnswer> Answers { get; set; } = new List<StudentAnswer>();
    }
}
