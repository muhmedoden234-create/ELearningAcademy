using ELearningAcademy.Helpers;
using ELearningAcademy.Models;
using ELearningAcademy.Services;

namespace ELearningAcademy.Forms
{
    public partial class LoginForm : Form
    {
        private readonly AuthService _authService = new AuthService();

        public LoginForm()
        {
            InitializeComponent();
            UiTheme.Apply(this);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            User user = null;
            bool ok = UiHelper.Run(() => user = _authService.Login(txtLogin.Text, txtPassword.Text));
            if (!ok)
                return;

            if (user == null)
            {
                UiHelper.ShowWarning("Невірний логін або пароль.");
                txtPassword.Clear();
                txtPassword.Focus();
                return;
            }

            Session.Start(user);
            OpenMainForm();
        }

        private void OpenMainForm()
        {
            Hide();
            bool logoutRequested;
            using (var mainForm = new MainForm())
            {
                mainForm.ShowDialog();
                logoutRequested = mainForm.LogoutRequested;
            }
            Session.End();

            if (logoutRequested)
            {
                txtPassword.Clear();
                Show();
                txtLogin.Focus();
            }
            else
            {
                Close();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            using (var form = new RegisterForm())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    txtLogin.Text = form.RegisteredLogin;
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }
    }
}
