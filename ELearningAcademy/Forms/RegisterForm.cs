using ELearningAcademy.Helpers;
using ELearningAcademy.Services;

namespace ELearningAcademy.Forms
{
    public partial class RegisterForm : Form
    {
        public string RegisteredLogin { get; private set; }

        public RegisterForm()
        {
            InitializeComponent();
            UiTheme.Apply(this);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            bool ok = UiHelper.Run(() =>
            {
                var user = new AuthService().RegisterStudent(
                    txtFullName.Text, txtLogin.Text, txtPassword.Text, txtConfirm.Text);
                RegisteredLogin = user.Login;
            });

            if (ok)
            {
                UiHelper.ShowInfo("Реєстрацію завершено. Тепер увійдіть зі своїм логіном і паролем.");
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
