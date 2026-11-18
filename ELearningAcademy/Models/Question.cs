namespace ELearningAcademy.Models
{
    public class Question
    {
        public int Id { get; set; }

        public int TestId { get; set; }
        public Test Test { get; set; }

        public string Text { get; set; } = string.Empty;
        public QuestionType Type { get; set; }
        public int Points { get; set; } = 1;
        public int OrderIndex { get; set; }

        public byte[] ImageData { get; set; }

        public List<AnswerOption> Options { get; set; } = new List<AnswerOption>();
    }
}
