namespace ELearningAcademy.Forms
{
    partial class MainForm
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
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.lblAppName = new System.Windows.Forms.Label();
            this.btnCourses = new System.Windows.Forms.Button();
            this.btnResults = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnCatalog = new System.Windows.Forms.Button();
            this.btnProgress = new System.Windows.Forms.Button();
            this.btnMyResults = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.lblDashTitle = new System.Windows.Forms.Label();
            this.pnlCard1 = new System.Windows.Forms.Panel();
            this.lblCard1Value = new System.Windows.Forms.Label();
            this.lblCard1Caption = new System.Windows.Forms.Label();
            this.pnlCard2 = new System.Windows.Forms.Panel();
            this.lblCard2Value = new System.Windows.Forms.Label();
            this.lblCard2Caption = new System.Windows.Forms.Label();
            this.pnlCard3 = new System.Windows.Forms.Panel();
            this.lblCard3Value = new System.Windows.Forms.Label();
            this.lblCard3Caption = new System.Windows.Forms.Label();
            this.lblHelp = new System.Windows.Forms.Label();
            this.pnlSidebar.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlCard1.SuspendLayout();
            this.pnlCard2.SuspendLayout();
            this.pnlCard3.SuspendLayout();
            this.SuspendLayout();

            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.pnlSidebar.Controls.Add(this.btnLogout);
            this.pnlSidebar.Controls.Add(this.btnMyResults);
            this.pnlSidebar.Controls.Add(this.btnProgress);
            this.pnlSidebar.Controls.Add(this.btnCatalog);
            this.pnlSidebar.Controls.Add(this.btnReports);
            this.pnlSidebar.Controls.Add(this.btnResults);
            this.pnlSidebar.Controls.Add(this.btnCourses);
            this.pnlSidebar.Controls.Add(this.lblAppName);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(240, 680);
            this.pnlSidebar.TabIndex = 0;

            this.lblAppName.AutoSize = true;
            this.lblAppName.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblAppName.ForeColor = System.Drawing.Color.White;
            this.lblAppName.Location = new System.Drawing.Point(18, 22);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Text = "E-Learning\r\nAcademy";

            this.btnCourses.Location = new System.Drawing.Point(10, 110);
            this.btnCourses.Name = "btnCourses";
            this.btnCourses.Size = new System.Drawing.Size(220, 44);
            this.btnCourses.TabIndex = 1;
            this.btnCourses.Tag = "sidebar";
            this.btnCourses.Text = "Курси, модулі, тести";
            this.btnCourses.Click += new System.EventHandler(this.btnCourses_Click);

            this.btnResults.Location = new System.Drawing.Point(10, 162);
            this.btnResults.Name = "btnResults";
            this.btnResults.Size = new System.Drawing.Size(220, 44);
            this.btnResults.TabIndex = 2;
            this.btnResults.Tag = "sidebar";
            this.btnResults.Text = "Результати студентів";
            this.btnResults.Click += new System.EventHandler(this.btnResults_Click);

            this.btnReports.Location = new System.Drawing.Point(10, 214);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(220, 44);
            this.btnReports.TabIndex = 3;
            this.btnReports.Tag = "sidebar";
            this.btnReports.Text = "Звіти в Excel";
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);

            this.btnCatalog.Location = new System.Drawing.Point(10, 110);
            this.btnCatalog.Name = "btnCatalog";
            this.btnCatalog.Size = new System.Drawing.Size(220, 44);
            this.btnCatalog.TabIndex = 4;
            this.btnCatalog.Tag = "sidebar";
            this.btnCatalog.Text = "Каталог курсів";
            this.btnCatalog.Click += new System.EventHandler(this.btnCatalog_Click);

            this.btnProgress.Location = new System.Drawing.Point(10, 162);
            this.btnProgress.Name = "btnProgress";
            this.btnProgress.Size = new System.Drawing.Size(220, 44);
            this.btnProgress.TabIndex = 5;
            this.btnProgress.Tag = "sidebar";
            this.btnProgress.Text = "Мій прогрес і навчання";
            this.btnProgress.Click += new System.EventHandler(this.btnProgress_Click);

            this.btnMyResults.Location = new System.Drawing.Point(10, 214);
            this.btnMyResults.Name = "btnMyResults";
            this.btnMyResults.Size = new System.Drawing.Size(220, 44);
            this.btnMyResults.TabIndex = 6;
            this.btnMyResults.Tag = "sidebar";
            this.btnMyResults.Text = "Мої результати";
            this.btnMyResults.Click += new System.EventHandler(this.btnMyResults_Click);

            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLogout.Location = new System.Drawing.Point(10, 620);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(220, 44);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Tag = "sidebar";
            this.btnLogout.Text = "Вийти з облікового запису";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblRole);
            this.pnlHeader.Controls.Add(this.lblWelcome);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(240, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(860, 80);
            this.pnlHeader.TabIndex = 1;

            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.Location = new System.Drawing.Point(25, 12);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Text = "Вітаємо!";

            this.lblRole.AutoSize = true;
            this.lblRole.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblRole.Location = new System.Drawing.Point(27, 48);
            this.lblRole.Name = "lblRole";
            this.lblRole.Text = "Роль";

            this.pnlContent.Controls.Add(this.lblHelp);
            this.pnlContent.Controls.Add(this.pnlCard3);
            this.pnlContent.Controls.Add(this.pnlCard2);
            this.pnlContent.Controls.Add(this.pnlCard1);
            this.pnlContent.Controls.Add(this.lblDashTitle);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(240, 80);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(860, 600);
            this.pnlContent.TabIndex = 2;

            this.lblDashTitle.AutoSize = true;
            this.lblDashTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblDashTitle.Location = new System.Drawing.Point(30, 22);
            this.lblDashTitle.Name = "lblDashTitle";
            this.lblDashTitle.Text = "Огляд";

            this.pnlCard1.BackColor = System.Drawing.Color.White;
            this.pnlCard1.Controls.Add(this.lblCard1Caption);
            this.pnlCard1.Controls.Add(this.lblCard1Value);
            this.pnlCard1.Location = new System.Drawing.Point(30, 65);
            this.pnlCard1.Name = "pnlCard1";
            this.pnlCard1.Size = new System.Drawing.Size(250, 110);
            this.pnlCard1.TabIndex = 0;

            this.lblCard1Value.AutoSize = true;
            this.lblCard1Value.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblCard1Value.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblCard1Value.Location = new System.Drawing.Point(16, 10);
            this.lblCard1Value.Name = "lblCard1Value";
            this.lblCard1Value.Text = "0";

            this.lblCard1Caption.AutoSize = true;
            this.lblCard1Caption.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblCard1Caption.Location = new System.Drawing.Point(19, 74);
            this.lblCard1Caption.Name = "lblCard1Caption";
            this.lblCard1Caption.Text = "Показник 1";

            this.pnlCard2.BackColor = System.Drawing.Color.White;
            this.pnlCard2.Controls.Add(this.lblCard2Caption);
            this.pnlCard2.Controls.Add(this.lblCard2Value);
            this.pnlCard2.Location = new System.Drawing.Point(300, 65);
            this.pnlCard2.Name = "pnlCard2";
            this.pnlCard2.Size = new System.Drawing.Size(250, 110);
            this.pnlCard2.TabIndex = 1;

            this.lblCard2Value.AutoSize = true;
            this.lblCard2Value.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblCard2Value.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblCard2Value.Location = new System.Drawing.Point(16, 10);
            this.lblCard2Value.Name = "lblCard2Value";
            this.lblCard2Value.Text = "0";

            this.lblCard2Caption.AutoSize = true;
            this.lblCard2Caption.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblCard2Caption.Location = new System.Drawing.Point(19, 74);
            this.lblCard2Caption.Name = "lblCard2Caption";
            this.lblCard2Caption.Text = "Показник 2";

            this.pnlCard3.BackColor = System.Drawing.Color.White;
            this.pnlCard3.Controls.Add(this.lblCard3Caption);
            this.pnlCard3.Controls.Add(this.lblCard3Value);
            this.pnlCard3.Location = new System.Drawing.Point(570, 65);
            this.pnlCard3.Name = "pnlCard3";
            this.pnlCard3.Size = new System.Drawing.Size(250, 110);
            this.pnlCard3.TabIndex = 2;

            this.lblCard3Value.AutoSize = true;
            this.lblCard3Value.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblCard3Value.ForeColor = System.Drawing.Color.FromArgb(180, 83, 9);
            this.lblCard3Value.Location = new System.Drawing.Point(16, 10);
            this.lblCard3Value.Name = "lblCard3Value";
            this.lblCard3Value.Text = "0";

            this.lblCard3Caption.AutoSize = true;
            this.lblCard3Caption.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblCard3Caption.Location = new System.Drawing.Point(19, 74);
            this.lblCard3Caption.Name = "lblCard3Caption";
            this.lblCard3Caption.Text = "Показник 3";

            this.lblHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHelp.Location = new System.Drawing.Point(30, 200);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(790, 370);
            this.lblHelp.Text = "Підказка";

            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1100, 680);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSidebar);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "E-Learning Academy — Головне меню";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.pnlCard1.ResumeLayout(false);
            this.pnlCard1.PerformLayout();
            this.pnlCard2.ResumeLayout(false);
            this.pnlCard2.PerformLayout();
            this.pnlCard3.ResumeLayout(false);
            this.pnlCard3.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Button btnCourses;
        private System.Windows.Forms.Button btnResults;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnCatalog;
        private System.Windows.Forms.Button btnProgress;
        private System.Windows.Forms.Button btnMyResults;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblDashTitle;
        private System.Windows.Forms.Panel pnlCard1;
        private System.Windows.Forms.Label lblCard1Value;
        private System.Windows.Forms.Label lblCard1Caption;
        private System.Windows.Forms.Panel pnlCard2;
        private System.Windows.Forms.Label lblCard2Value;
        private System.Windows.Forms.Label lblCard2Caption;
        private System.Windows.Forms.Panel pnlCard3;
        private System.Windows.Forms.Label lblCard3Value;
        private System.Windows.Forms.Label lblCard3Caption;
        private System.Windows.Forms.Label lblHelp;
    }
}
