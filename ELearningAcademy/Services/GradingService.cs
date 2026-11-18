using ELearningAcademy.Helpers;
using ELearningAcademy.Models;
using ELearningAcademy.Models.Dto;

namespace ELearningAcademy.Services
{
    public class QuestionGradeResult
    {
        public bool IsCorrect { get; set; }
        public int PointsAwarded { get; set; }
    }

    public static class GradingService
    {
        public const decimal PassingPercent = 70m;

        public static QuestionGradeResult GradeQuestion(Question question, StudentAnswerInput answer)
        {
            if (question == null) throw new ArgumentNullException(nameof(question));

            bool isCorrect;
            switch (question.Type)
            {
                case QuestionType.SingleChoice:
                case QuestionType.MultipleChoice:
                    isCorrect = CheckChoice(question, answer);
                    break;
                case QuestionType.TextInput:
                    isCorrect = CheckText(question, answer);
                    break;
                default:
                    isCorrect = false;
                    break;
            }

            return new QuestionGradeResult
            {
                IsCorrect = isCorrect,
                PointsAwarded = isCorrect ? question.Points : 0
            };
        }

        private static bool CheckChoice(Question question, StudentAnswerInput answer)
        {
            var correctIds = question.Options.Where(o => o.IsCorrect).Select(o => o.Id).ToHashSet();
            if (correctIds.Count == 0)
                return false;

            var selectedIds = (answer?.SelectedOptionIds ?? new List<int>()).ToHashSet();

            if (question.Type == QuestionType.SingleChoice && selectedIds.Count != 1)
                return false;

            return selectedIds.SetEquals(correctIds);
        }

        private static bool CheckText(Question question, StudentAnswerInput answer)
        {
            string studentText = NormalizeText(answer?.TextAnswer);
            if (studentText.Length == 0)
                return false;

            return question.Options.Any(o => NormalizeText(o.Text) == studentText);
        }

        public static string NormalizeText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            string[] words = text.Trim().Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
            return string.Join(" ", words).ToLowerInvariant();
        }

        public static decimal CalculatePercent(int obtained, int max)
        {
            if (max <= 0) return 0m;
            return Math.Round(obtained * 100m / max, 2, MidpointRounding.AwayFromZero);
        }

        public static bool IsPassed(int obtained, int max)
        {
            if (max <= 0) return false;
            return obtained * 100m >= PassingPercent * max;
        }
    }
}
