namespace ELearningAcademy.Models.Dto
{
    public class StudentTestView
    {
        public int TestId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ModuleTitle { get; set; }
        public List<StudentQuestionView> Questions { get; set; } = new List<StudentQuestionView>();
    }

    public class StudentQuestionView
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Text { get; set; }
        public QuestionType Type { get; set; }
        public int Points { get; set; }
        public byte[] ImageData { get; set; }
        public List<StudentOptionView> Options { get; set; } = new List<StudentOptionView>();
    }

    public class StudentOptionView
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }

    public class StudentAnswerInput
    {
        public int QuestionId { get; set; }
        public List<int> SelectedOptionIds { get; set; } = new List<int>();
        public string TextAnswer { get; set; }

        public bool IsAnswered =>
            SelectedOptionIds.Count > 0 || !string.IsNullOrWhiteSpace(TextAnswer);
    }

    public class QuestionEditModel
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public string Text { get; set; }
        public QuestionType Type { get; set; }
        public int Points { get; set; }
        public byte[] ImageData { get; set; }
        public List<OptionEditModel> Options { get; set; } = new List<OptionEditModel>();
    }

    public class OptionEditModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }

    public class AttemptResult
    {
        public int AttemptId { get; set; }
        public int ScoreObtained { get; set; }
        public int MaxScore { get; set; }
        public decimal Percent { get; set; }
        public bool IsPassed { get; set; }
        public string NextModuleTitle { get; set; }
        public bool NextModuleUnlocked { get; set; }
    }
}
