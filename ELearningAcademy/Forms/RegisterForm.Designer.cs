namespace ELearningAcademy.Forms
{
    partial class RegisterForm
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblConfirm = new System.Windows.Forms.Label();
            this.txtConfirm = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblHeader.Location = new System.Drawing.Point(30, 20);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Text = "Реєстрація студента";

            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(30, 70);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Text = "ПІБ (прізвище, ім'я, по батькові)";

            this.txtFullName.Location = new System.Drawing.Point(30, 93);
            this.txtFullName.MaxLength = 150;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(380, 30);
            this.txtFullName.TabIndex = 0;

            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(30, 135);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Text = "Логін (латиницею)";

            this.txtLogin.Location = new System.Drawing.Point(30, 158);
            this.txtLogin.MaxLength = 50;
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(380, 30);
            this.txtLogin.TabIndex = 1;

            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(30, 200);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Text = "Пароль (мінімум 6 символів)";

            this.txtPassword.Location = new System.Drawing.Point(30, 223);
            this.txtPassword.MaxLength = 100;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(380, 30);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.UseSystemPasswordChar = true;

            this.lblConfirm.AutoSize = true;
            this.lblConfirm.Location = new System.Drawing.Point(30, 265);
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.Text = "Повторіть пароль";

            this.txtConfirm.Location = new System.Drawing.Point(30, 288);
            this.txtConfirm.MaxLength = 100;
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.Size = new System.Drawing.Size(380, 30);
            this.txtConfirm.TabIndex = 3;
            this.txtConfirm.UseSystemPasswordChar = true;

            this.btnRegister.Location = new System.Drawing.Point(30, 345);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(185, 42);
            this.btnRegister.TabIndex = 4;
            this.btnRegister.Text = "Зареєструватися";
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);

            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(225, 345);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(185, 42);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Tag = "secondary";
            this.btnCancel.Text = "Скасувати";

            this.AcceptButton = this.btnRegister;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(440, 410);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.txtConfirm);
            this.Controls.Add(this.lblConfirm);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Реєстрація";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblConfirm;
        private System.Windows.Forms.TextBox txtConfirm;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnCancel;
    }
}
