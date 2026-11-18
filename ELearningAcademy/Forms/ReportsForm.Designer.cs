namespace ELearningAcademy.Forms
{
    partial class ReportsForm
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
            this.lblHint = new System.Windows.Forms.Label();
            this.pnlAttemptCard = new System.Windows.Forms.Panel();
            this.lblCard1Title = new System.Windows.Forms.Label();
            this.lblCourse = new System.Windows.Forms.Label();
            this.cmbCourse = new System.Windows.Forms.ComboBox();
            this.lblStudent = new System.Windows.Forms.Label();
            this.cmbStudent = new System.Windows.Forms.ComboBox();
            this.lblAttempt = new System.Windows.Forms.Label();
            this.cmbAttempt = new System.Windows.Forms.ComboBox();
            this.btnExportAttempt = new System.Windows.Forms.Button();
            this.pnlSummaryCard = new System.Windows.Forms.Panel();
            this.lblCard2Title = new System.Windows.Forms.Label();
            this.lblCard2Hint = new System.Windows.Forms.Label();
            this.btnExportSummary = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.pnlAttemptCard.SuspendLayout();
            this.pnlSummaryCard.SuspendLayout();
            this.SuspendLayout();

            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblHint);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(760, 80);
            this.pnlTop.TabIndex = 0;

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "Експорт звітів в Excel";

            this.lblHint.AutoSize = true;
            this.lblHint.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblHint.Location = new System.Drawing.Point(22, 48);
            this.lblHint.Name = "lblHint";
            this.lblHint.Text = "Звіти формуються бібліотекою ClosedXML у форматі .xlsx (Microsoft Excel не потрібен).";

            this.pnlAttemptCard.BackColor = System.Drawing.Color.White;
            this.pnlAttemptCard.Controls.Add(this.btnExportAttempt);
            this.pnlAttemptCard.Controls.Add(this.cmbAttempt);
            this.pnlAttemptCard.Controls.Add(this.lblAttempt);
            this.pnlAttemptCard.Controls.Add(this.cmbStudent);
            this.pnlAttemptCard.Controls.Add(this.lblStudent);
            this.pnlAttemptCard.Controls.Add(this.cmbCourse);
            this.pnlAttemptCard.Controls.Add(this.lblCourse);
            this.pnlAttemptCard.Controls.Add(this.lblCard1Title);
            this.pnlAttemptCard.Location = new System.Drawing.Point(20, 100);
            this.pnlAttemptCard.Name = "pnlAttemptCard";
            this.pnlAttemptCard.Size = new System.Drawing.Size(720, 280);
            this.pnlAttemptCard.TabIndex = 1;

            this.lblCard1Title.AutoSize = true;
            this.lblCard1Title.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCard1Title.Location = new System.Drawing.Point(20, 15);
            this.lblCard1Title.Name = "lblCard1Title";
            this.lblCard1Title.Text = "Детальний звіт про проходження тесту";

            this.lblCourse.AutoSize = true;
            this.lblCourse.Location = new System.Drawing.Point(20, 64);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Text = "Курс";

            this.cmbCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCourse.Location = new System.Drawing.Point(150, 60);
            this.cmbCourse.Name = "cmbCourse";
            this.cmbCourse.Size = new System.Drawing.Size(540, 31);
            this.cmbCourse.TabIndex = 0;
            this.cmbCourse.SelectedIndexChanged += new System.EventHandler(this.cmbCourse_SelectedIndexChanged);

            this.lblStudent.AutoSize = true;
            this.lblStudent.Location = new System.Drawing.Point(20, 109);
            this.lblStudent.Name = "lblStudent";
            this.lblStudent.Text = "Студент";

            this.cmbStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStudent.Location = new System.Drawing.Point(150, 105);
            this.cmbStudent.Name = "cmbStudent";
            this.cmbStudent.Size = new System.Drawing.Size(540, 31);
            this.cmbStudent.TabIndex = 1;
            this.cmbStudent.SelectedIndexChanged += new System.EventHandler(this.cmbStudent_SelectedIndexChanged);

            this.lblAttempt.AutoSize = true;
            this.lblAttempt.Location = new System.Drawing.Point(20, 154);
            this.lblAttempt.Name = "lblAttempt";
            this.lblAttempt.Text = "Спроба";

            this.cmbAttempt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAttempt.Location = new System.Drawing.Point(150, 150);
            this.cmbAttempt.Name = "cmbAttempt";
            this.cmbAttempt.Size = new System.Drawing.Size(540, 31);
            this.cmbAttempt.TabIndex = 2;

            this.btnExportAttempt.Location = new System.Drawing.Point(20, 205);
            this.btnExportAttempt.Name = "btnExportAttempt";
            this.btnExportAttempt.Size = new System.Drawing.Size(670, 46);
            this.btnExportAttempt.TabIndex = 3;
            this.btnExportAttempt.Tag = "success";
            this.btnExportAttempt.Text = "Експортувати звіт в Excel";
            this.btnExportAttempt.Click += new System.EventHandler(this.btnExportAttempt_Click);

            this.pnlSummaryCard.BackColor = System.Drawing.Color.White;
            this.pnlSummaryCard.Controls.Add(this.btnExportSummary);
            this.pnlSummaryCard.Controls.Add(this.lblCard2Hint);
            this.pnlSummaryCard.Controls.Add(this.lblCard2Title);
            this.pnlSummaryCard.Location = new System.Drawing.Point(20, 395);
            this.pnlSummaryCard.Name = "pnlSummaryCard";
            this.pnlSummaryCard.Size = new System.Drawing.Size(720, 160);
            this.pnlSummaryCard.TabIndex = 2;

            this.lblCard2Title.AutoSize = true;
            this.lblCard2Title.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCard2Title.Location = new System.Drawing.Point(20, 15);
            this.lblCard2Title.Name = "lblCard2Title";
            this.lblCard2Title.Text = "Зведена відомість курсу";

            this.lblCard2Hint.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblCard2Hint.Location = new System.Drawing.Point(20, 46);
            this.lblCard2Hint.Name = "lblCard2Hint";
            this.lblCard2Hint.Size = new System.Drawing.Size(670, 44);
            this.lblCard2Hint.Text = "Усі спроби всіх студентів курсу, обраного вище: дата, бали, відсоток і статус, а також підсумки.";

            this.btnExportSummary.Location = new System.Drawing.Point(20, 95);
            this.btnExportSummary.Name = "btnExportSummary";
            this.btnExportSummary.Size = new System.Drawing.Size(670, 44);
            this.btnExportSummary.TabIndex = 0;
            this.btnExportSummary.Text = "Експортувати зведену відомість";
            this.btnExportSummary.Click += new System.EventHandler(this.btnExportSummary_Click);

            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblStatus.Location = new System.Drawing.Point(20, 572);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Text = "";

            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(760, 610);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.pnlSummaryCard);
            this.Controls.Add(this.pnlAttemptCard);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ReportsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Звіти";
            this.Load += new System.EventHandler(this.ReportsForm_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlAttemptCard.ResumeLayout(false);
            this.pnlAttemptCard.PerformLayout();
            this.pnlSummaryCard.ResumeLayout(false);
            this.pnlSummaryCard.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.Panel pnlAttemptCard;
        private System.Windows.Forms.Label lblCard1Title;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.ComboBox cmbCourse;
        private System.Windows.Forms.Label lblStudent;
        private System.Windows.Forms.ComboBox cmbStudent;
        private System.Windows.Forms.Label lblAttempt;
        private System.Windows.Forms.ComboBox cmbAttempt;
        private System.Windows.Forms.Button btnExportAttempt;
        private System.Windows.Forms.Panel pnlSummaryCard;
        private System.Windows.Forms.Label lblCard2Title;
        private System.Windows.Forms.Label lblCard2Hint;
        private System.Windows.Forms.Button btnExportSummary;
        private System.Windows.Forms.Label lblStatus;
    }
}
