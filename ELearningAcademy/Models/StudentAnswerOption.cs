namespace ELearningAcademy.Models
{
    public class StudentAnswerOption
    {
        public int StudentAnswerId { get; set; }
        public StudentAnswer StudentAnswer { get; set; }

        public int AnswerOptionId { get; set; }
        public AnswerOption AnswerOption { get; set; }
    }
}
