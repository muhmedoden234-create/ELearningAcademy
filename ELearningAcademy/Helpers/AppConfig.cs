using System.Text.Json;

namespace ELearningAcademy.Helpers
{
    public static class AppConfig
    {
        public static string ConnectionString { get; private set; } =
            "Server=localhost;Port=3306;Database=elearning_academy;User=root;Password=;CharSet=utf8mb4;";

        public static string MySqlServerVersion { get; private set; } = "10.4.32-mariadb";

        static AppConfig()
        {
            string path = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
            if (!File.Exists(path))
                return;

            try
            {
                using JsonDocument doc = JsonDocument.Parse(File.ReadAllText(path));
                JsonElement root = doc.RootElement;

                if (root.TryGetProperty("ConnectionString", out JsonElement connection) &&
                    !string.IsNullOrWhiteSpace(connection.GetString()))
                {
                    ConnectionString = connection.GetString();
                }

                if (root.TryGetProperty("MySqlServerVersion", out JsonElement version) &&
                    !string.IsNullOrWhiteSpace(version.GetString()))
                {
                    MySqlServerVersion = version.GetString();
                }
            }
            catch (JsonException)
            {
            }
        }
    }
}
