namespace ELearningAcademy.Forms
{
    partial class ResultsForm
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
            this.lblStudent = new System.Windows.Forms.Label();
            this.cmbStudent = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.split = new System.Windows.Forms.SplitContainer();
            this.gridAttempts = new System.Windows.Forms.DataGridView();
            this.gridAnswers = new System.Windows.Forms.DataGridView();
            this.lblDetails = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblSummary = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split)).BeginInit();
            this.split.Panel1.SuspendLayout();
            this.split.Panel2.SuspendLayout();
            this.split.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAttempts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAnswers)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();

            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.btnRefresh);
            this.pnlTop.Controls.Add(this.cmbStudent);
            this.pnlTop.Controls.Add(this.lblStudent);
            this.pnlTop.Controls.Add(this.cmbCourse);
            this.pnlTop.Controls.Add(this.lblCourse);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1200, 95);
            this.pnlTop.TabIndex = 0;

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "Результати тестування";

            this.lblCourse.AutoSize = true;
            this.lblCourse.Location = new System.Drawing.Point(20, 56);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Text = "Курс:";

            this.cmbCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCourse.Location = new System.Drawing.Point(75, 52);
            this.cmbCourse.Name = "cmbCourse";
            this.cmbCourse.Size = new System.Drawing.Size(330, 31);
            this.cmbCourse.TabIndex = 0;
            this.cmbCourse.SelectedIndexChanged += new System.EventHandler(this.Filter_Changed);

            this.lblStudent.AutoSize = true;
            this.lblStudent.Location = new System.Drawing.Point(425, 56);
            this.lblStudent.Name = "lblStudent";
            this.lblStudent.Text = "Студент:";

            this.cmbStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStudent.Location = new System.Drawing.Point(500, 52);
            this.cmbStudent.Name = "cmbStudent";
            this.cmbStudent.Size = new System.Drawing.Size(300, 31);
            this.cmbStudent.TabIndex = 1;
            this.cmbStudent.SelectedIndexChanged += new System.EventHandler(this.Filter_Changed);

            this.btnRefresh.Location = new System.Drawing.Point(820, 49);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(140, 36);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Tag = "secondary";
            this.btnRefresh.Text = "Оновити";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            this.split.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split.Location = new System.Drawing.Point(0, 95);
            this.split.Name = "split";
            this.split.Orientation = System.Windows.Forms.Orientation.Horizontal;

            this.split.Panel1.Controls.Add(this.gridAttempts);

            this.split.Panel2.Controls.Add(this.gridAnswers);
            this.split.Panel2.Controls.Add(this.lblDetails);
            this.split.Size = new System.Drawing.Size(1200, 561);
            this.split.SplitterDistance = 260;
            this.split.SplitterWidth = 6;
            this.split.TabIndex = 1;

            this.gridAttempts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAttempts.Location = new System.Drawing.Point(0, 0);
            this.gridAttempts.Name = "gridAttempts";
            this.gridAttempts.ReadOnly = true;
            this.gridAttempts.Size = new System.Drawing.Size(1200, 260);
            this.gridAttempts.TabIndex = 0;
            this.gridAttempts.SelectionChanged += new System.EventHandler(this.gridAttempts_SelectionChanged);

            this.lblDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDetails.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDetails.Location = new System.Drawing.Point(0, 0);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Padding = new System.Windows.Forms.Padding(10, 8, 0, 0);
            this.lblDetails.Size = new System.Drawing.Size(1200, 34);
            this.lblDetails.Text = "Відповіді на питання";

            this.gridAnswers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAnswers.Location = new System.Drawing.Point(0, 34);
            this.gridAnswers.Name = "gridAnswers";
            this.gridAnswers.ReadOnly = true;
            this.gridAnswers.Size = new System.Drawing.Size(1200, 261);
            this.gridAnswers.TabIndex = 0;

            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Controls.Add(this.btnExport);
            this.pnlBottom.Controls.Add(this.lblSummary);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 656);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1200, 64);
            this.pnlBottom.TabIndex = 2;

            this.lblSummary.AutoSize = true;
            this.lblSummary.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSummary.Location = new System.Drawing.Point(20, 20);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Text = "";

            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(790, 12);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(260, 40);
            this.btnExport.TabIndex = 0;
            this.btnExport.Tag = "success";
            this.btnExport.Text = "Експортувати звіт в Excel";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);

            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(1060, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 40);
            this.btnClose.TabIndex = 1;
            this.btnClose.Tag = "secondary";
            this.btnClose.Text = "Закрити";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.Controls.Add(this.split);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "ResultsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Результати тестування";
            this.Load += new System.EventHandler(this.ResultsForm_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.split.Panel1.ResumeLayout(false);
            this.split.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split)).EndInit();
            this.split.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAttempts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAnswers)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.ComboBox cmbCourse;
        private System.Windows.Forms.Label lblStudent;
        private System.Windows.Forms.ComboBox cmbStudent;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.SplitContainer split;
        private System.Windows.Forms.DataGridView gridAttempts;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.DataGridView gridAnswers;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnClose;
    }
}
