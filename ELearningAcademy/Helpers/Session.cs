using ELearningAcademy.Models;

namespace ELearningAcademy.Helpers
{
    public static class Session
    {
        public static User CurrentUser { get; private set; }

        public static bool IsTeacher => CurrentUser != null && CurrentUser.Role == UserRole.Teacher;
        public static bool IsStudent => CurrentUser != null && CurrentUser.Role == UserRole.Student;
        public static int UserId => CurrentUser?.Id ?? 0;

        public static void Start(User user)
        {
            CurrentUser = user ?? throw new ArgumentNullException(nameof(user));
        }

        public static void End()
        {
            CurrentUser = null;
        }
    }
}
