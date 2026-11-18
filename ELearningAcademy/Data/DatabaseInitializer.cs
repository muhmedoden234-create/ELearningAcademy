using ELearningAcademy.Helpers;

namespace ELearningAcademy.Data
{
    public static class DatabaseInitializer
    {
        public static bool Initialize()
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    db.Database.EnsureCreated();
                    DbSeeder.Seed(db);
                }
                return true;
            }
            catch (Exception ex)
            {
                string details = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                UiHelper.ShowError(
                    "Не вдалося підключитися до бази даних або створити її.\n\n" +
                    "Перевірте, що в XAMPP Control Panel запущено модуль MySQL (кнопка «Start», " +
                    "напис MySQL підсвічений зеленим), а порт — 3306.\n" +
                    "Якщо для користувача root встановлено пароль — вкажіть його в appsettings.json (Password=...).\n\n" +
                    "Поточний рядок підключення:\n" + AppConfig.ConnectionString + "\n\n" +
                    "Технічні деталі: " + details);
                return false;
            }
        }
    }
}
