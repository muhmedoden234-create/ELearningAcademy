using ELearningAcademy.Data;
using ELearningAcademy.Forms;
using ELearningAcademy.Helpers;

namespace ELearningAcademy
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            ApplicationConfiguration.Initialize();

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (sender, e) =>
                UiHelper.ShowError("Непередбачена помилка:\n" + e.Exception.Message);
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
                UiHelper.ShowError("Критична помилка:\n" + (e.ExceptionObject as Exception)?.Message);

            if (!DatabaseInitializer.Initialize())
                return;

            Application.Run(new LoginForm());
        }
    }
}
