namespace ELearningAcademy.Models
{
    public class StudentAnswer
    {
        public int Id { get; set; }

        public int TestAttemptId { get; set; }
        public TestAttempt TestAttempt { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public string TextAnswer { get; set; }
        public bool IsCorrect { get; set; }
        public int PointsAwarded { get; set; }

        public List<StudentAnswerOption> SelectedOptions { get; set; } = new List<StudentAnswerOption>();
    }
}
