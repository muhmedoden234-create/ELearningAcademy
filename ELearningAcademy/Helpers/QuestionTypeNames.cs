using ELearningAcademy.Models;

namespace ELearningAcademy.Helpers
{
    public static class QuestionTypeNames
    {
        public static string GetName(QuestionType type)
        {
            switch (type)
            {
                case QuestionType.SingleChoice: return "Одна правильна відповідь";
                case QuestionType.MultipleChoice: return "Кілька правильних відповідей";
                case QuestionType.TextInput: return "Текстова відповідь";
                default: return type.ToString();
            }
        }

        public static string GetHint(QuestionType type)
        {
            switch (type)
            {
                case QuestionType.SingleChoice: return "Оберіть одну відповідь";
                case QuestionType.MultipleChoice: return "Оберіть усі правильні відповіді";
                case QuestionType.TextInput: return "Введіть відповідь з клавіатури";
                default: return string.Empty;
            }
        }
    }
}
