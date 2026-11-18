using System.Text.RegularExpressions;
using ELearningAcademy.Data;
using ELearningAcademy.Helpers;
using ELearningAcademy.Models;

namespace ELearningAcademy.Services
{
    public class AuthService
    {
        private static readonly Regex LoginPattern = new Regex(@"^[A-Za-z0-9._-]{3,50}$");

        public User Login(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrEmpty(password))
                throw new BusinessException("Введіть логін і пароль.");

            string normalizedLogin = login.Trim();

            using (var db = new AppDbContext())
            {
                User user = db.Users.FirstOrDefault(u => u.Login == normalizedLogin);
                if (user == null)
                    return null;

                return PasswordHasher.Verify(password, user.PasswordHash) ? user : null;
            }
        }

        public User RegisterStudent(string fullName, string login, string password, string confirmPassword)
        {
            fullName = fullName?.Trim() ?? string.Empty;
            login = login?.Trim() ?? string.Empty;

            if (fullName.Length < 5)
                throw new BusinessException("Введіть повне ПІБ (щонайменше 5 символів).");
            if (fullName.Length > 150)
                throw new BusinessException("ПІБ занадто довге (максимум 150 символів).");
            if (!LoginPattern.IsMatch(login))
                throw new BusinessException("Логін: 3–50 символів, лише латинські літери, цифри, крапка, дефіс або підкреслення.");
            if (string.IsNullOrEmpty(password) || password.Length < 6)
                throw new BusinessException("Пароль повинен містити щонайменше 6 символів.");
            if (password != confirmPassword)
                throw new BusinessException("Паролі не збігаються.");

            using (var db = new AppDbContext())
            {
                if (db.Users.Any(u => u.Login == login))
                    throw new BusinessException("Користувач з таким логіном уже існує.");

                var user = new User
                {
                    FullName = fullName,
                    Login = login,
                    PasswordHash = PasswordHasher.Hash(password),
                    Role = UserRole.Student,
                    CreatedAt = DateTime.Now
                };
                db.Users.Add(user);
                db.SaveChanges();
                return user;
            }
        }
    }
}
