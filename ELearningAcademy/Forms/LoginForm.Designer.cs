namespace ELearningAcademy.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.chkShowPassword = new System.Windows.Forms.CheckBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lblHint = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();

            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(460, 120);
            this.pnlHeader.TabIndex = 0;

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(30, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "E-Learning Academy";

            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(219, 234, 254);
            this.lblSubtitle.Location = new System.Drawing.Point(33, 75);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Text = "Інтерактивна платформа дистанційного навчання";

            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(40, 145);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Text = "Логін";

            this.txtLogin.Location = new System.Drawing.Point(40, 170);
            this.txtLogin.MaxLength = 50;
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(380, 30);
            this.txtLogin.TabIndex = 1;

            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(40, 215);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Text = "Пароль";

            this.txtPassword.Location = new System.Drawing.Point(40, 240);
            this.txtPassword.MaxLength = 100;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(380, 30);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.UseSystemPasswordChar = true;

            this.chkShowPassword.AutoSize = true;
            this.chkShowPassword.Location = new System.Drawing.Point(40, 280);
            this.chkShowPassword.Name = "chkShowPassword";
            this.chkShowPassword.TabIndex = 3;
            this.chkShowPassword.Text = "Показати пароль";
            this.chkShowPassword.CheckedChanged += new System.EventHandler(this.chkShowPassword_CheckedChanged);

            this.btnLogin.Location = new System.Drawing.Point(40, 318);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(380, 44);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Увійти";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            this.btnRegister.Location = new System.Drawing.Point(40, 372);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(380, 38);
            this.btnRegister.TabIndex = 5;
            this.btnRegister.Tag = "secondary";
            this.btnRegister.Text = "Реєстрація нового студента";
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);

            this.lblHint.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblHint.Location = new System.Drawing.Point(40, 425);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(380, 55);
            this.lblHint.Text = "Демо-акаунти:\r\nвикладач — teacher / teacher123\r\nстудент — student / student123";

            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(460, 500);
            this.Controls.Add(this.lblHint);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.chkShowPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "E-Learning Academy — Вхід у систему";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox chkShowPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label lblHint;
    }
}
