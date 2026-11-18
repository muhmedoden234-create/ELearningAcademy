namespace ELearningAcademy.Forms
{
    partial class StudentProgressForm
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCourse = new System.Windows.Forms.Label();
            this.cmbCourse = new System.Windows.Forms.ComboBox();
            this.lblCourseProgress = new System.Windows.Forms.Label();
            this.progressCourse = new System.Windows.Forms.ProgressBar();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnOpenLesson = new System.Windows.Forms.Button();
            this.btnTakeTest = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlModules = new System.Windows.Forms.Panel();
            this.gridModules = new System.Windows.Forms.DataGridView();
            this.lblModules = new System.Windows.Forms.Label();
            this.pnlLessons = new System.Windows.Forms.Panel();
            this.gridLessons = new System.Windows.Forms.DataGridView();
            this.lblLessons = new System.Windows.Forms.Label();
            this.lblModuleStatus = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlModules.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridModules)).BeginInit();
            this.pnlLessons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLessons)).BeginInit();
            this.SuspendLayout();

            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.progressCourse);
            this.pnlTop.Controls.Add(this.lblCourseProgress);
            this.pnlTop.Controls.Add(this.cmbCourse);
            this.pnlTop.Controls.Add(this.lblCourse);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1200, 110);
            this.pnlTop.TabIndex = 0;

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "Мій прогрес навчання";

            this.lblCourse.AutoSize = true;
            this.lblCourse.Location = new System.Drawing.Point(20, 64);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Text = "Курс:";

            this.cmbCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCourse.Location = new System.Drawing.Point(75, 60);
            this.cmbCourse.Name = "cmbCourse";
            this.cmbCourse.Size = new System.Drawing.Size(420, 31);
            this.cmbCourse.TabIndex = 0;
            this.cmbCourse.SelectedIndexChanged += new System.EventHandler(this.cmbCourse_SelectedIndexChanged);

            this.lblCourseProgress.AutoSize = true;
            this.lblCourseProgress.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCourseProgress.Location = new System.Drawing.Point(530, 40);
            this.lblCourseProgress.Name = "lblCourseProgress";
            this.lblCourseProgress.Text = "Прогрес курсу: 0%";

            this.progressCourse.Location = new System.Drawing.Point(530, 66);
            this.progressCourse.Name = "progressCourse";
            this.progressCourse.Size = new System.Drawing.Size(420, 24);
            this.progressCourse.TabIndex = 1;

            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Controls.Add(this.btnTakeTest);
            this.pnlBottom.Controls.Add(this.btnOpenLesson);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 656);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1200, 64);
            this.pnlBottom.TabIndex = 3;

            this.btnOpenLesson.Location = new System.Drawing.Point(20, 12);
            this.btnOpenLesson.Name = "btnOpenLesson";
            this.btnOpenLesson.Size = new System.Drawing.Size(200, 40);
            this.btnOpenLesson.TabIndex = 0;
            this.btnOpenLesson.Text = "Відкрити урок";
            this.btnOpenLesson.Click += new System.EventHandler(this.btnOpenLesson_Click);

            this.btnTakeTest.Location = new System.Drawing.Point(230, 12);
            this.btnTakeTest.Name = "btnTakeTest";
            this.btnTakeTest.Size = new System.Drawing.Size(230, 40);
            this.btnTakeTest.TabIndex = 1;
            this.btnTakeTest.Tag = "success";
            this.btnTakeTest.Text = "Пройти тест";
            this.btnTakeTest.Click += new System.EventHandler(this.btnTakeTest_Click);

            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(1060, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 40);
            this.btnClose.TabIndex = 2;
            this.btnClose.Tag = "secondary";
            this.btnClose.Text = "Закрити";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            this.pnlModules.Controls.Add(this.gridModules);
            this.pnlModules.Controls.Add(this.lblModules);
            this.pnlModules.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlModules.Location = new System.Drawing.Point(0, 110);
            this.pnlModules.Name = "pnlModules";
            this.pnlModules.Size = new System.Drawing.Size(660, 546);
            this.pnlModules.TabIndex = 1;

            this.lblModules.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblModules.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblModules.Location = new System.Drawing.Point(0, 0);
            this.lblModules.Name = "lblModules";
            this.lblModules.Padding = new System.Windows.Forms.Padding(10, 8, 0, 0);
            this.lblModules.Size = new System.Drawing.Size(660, 36);
            this.lblModules.Text = "Модулі курсу";

            this.gridModules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridModules.Location = new System.Drawing.Point(0, 36);
            this.gridModules.Name = "gridModules";
            this.gridModules.ReadOnly = true;
            this.gridModules.Size = new System.Drawing.Size(660, 510);
            this.gridModules.TabIndex = 0;
            this.gridModules.SelectionChanged += new System.EventHandler(this.gridModules_SelectionChanged);

            this.pnlLessons.Controls.Add(this.gridLessons);
            this.pnlLessons.Controls.Add(this.lblLessons);
            this.pnlLessons.Controls.Add(this.lblModuleStatus);
            this.pnlLessons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLessons.Location = new System.Drawing.Point(660, 110);
            this.pnlLessons.Name = "pnlLessons";
            this.pnlLessons.Size = new System.Drawing.Size(540, 546);
            this.pnlLessons.TabIndex = 2;

            this.lblModuleStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblModuleStatus.Location = new System.Drawing.Point(0, 0);
            this.lblModuleStatus.Name = "lblModuleStatus";
            this.lblModuleStatus.Padding = new System.Windows.Forms.Padding(12, 10, 12, 0);
            this.lblModuleStatus.Size = new System.Drawing.Size(540, 72);
            this.lblModuleStatus.Text = "Оберіть модуль ліворуч.";

            this.lblLessons.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLessons.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblLessons.Location = new System.Drawing.Point(0, 72);
            this.lblLessons.Name = "lblLessons";
            this.lblLessons.Padding = new System.Windows.Forms.Padding(10, 4, 0, 0);
            this.lblLessons.Size = new System.Drawing.Size(540, 32);
            this.lblLessons.Text = "Уроки модуля";

            this.gridLessons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridLessons.Location = new System.Drawing.Point(0, 104);
            this.gridLessons.Name = "gridLessons";
            this.gridLessons.ReadOnly = true;
            this.gridLessons.Size = new System.Drawing.Size(540, 442);
            this.gridLessons.TabIndex = 0;
            this.gridLessons.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridLessons_CellDoubleClick);

            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.Controls.Add(this.pnlLessons);
            this.Controls.Add(this.pnlModules);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(1100, 600);
            this.Name = "StudentProgressForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Мій прогрес";
            this.Load += new System.EventHandler(this.StudentProgressForm_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlModules.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridModules)).EndInit();
            this.pnlLessons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridLessons)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.ComboBox cmbCourse;
        private System.Windows.Forms.Label lblCourseProgress;
        private System.Windows.Forms.ProgressBar progressCourse;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnOpenLesson;
        private System.Windows.Forms.Button btnTakeTest;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlModules;
        private System.Windows.Forms.Label lblModules;
        private System.Windows.Forms.DataGridView gridModules;
        private System.Windows.Forms.Panel pnlLessons;
        private System.Windows.Forms.Label lblModuleStatus;
        private System.Windows.Forms.Label lblLessons;
        private System.Windows.Forms.DataGridView gridLessons;
    }
}
