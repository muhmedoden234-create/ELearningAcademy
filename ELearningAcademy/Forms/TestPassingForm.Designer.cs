namespace ELearningAcademy.Forms
{
    partial class TestPassingForm
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
            this.lblTestTitle = new System.Windows.Forms.Label();
            this.lblModule = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.pnlQuestion = new System.Windows.Forms.Panel();
            this.lblQuestionText = new System.Windows.Forms.Label();
            this.lblPointsInfo = new System.Windows.Forms.Label();
            this.picQuestion = new System.Windows.Forms.PictureBox();
            this.pnlAnswers = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlQuestion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQuestion)).BeginInit();
            this.SuspendLayout();

            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblProgress);
            this.pnlTop.Controls.Add(this.lblModule);
            this.pnlTop.Controls.Add(this.lblTestTitle);
            this.pnlTop.Controls.Add(this.progressBar);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(960, 95);
            this.pnlTop.TabIndex = 0;

            this.lblTestTitle.AutoSize = true;
            this.lblTestTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTestTitle.Location = new System.Drawing.Point(20, 8);
            this.lblTestTitle.Name = "lblTestTitle";
            this.lblTestTitle.Text = "Тест";

            this.lblModule.AutoSize = true;
            this.lblModule.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblModule.Location = new System.Drawing.Point(22, 46);
            this.lblModule.Name = "lblModule";
            this.lblModule.Text = "Модуль";

            this.lblProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProgress.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblProgress.Location = new System.Drawing.Point(740, 44);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(200, 26);
            this.lblProgress.Text = "Питання 1 з 1";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(0, 85);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(960, 10);
            this.progressBar.TabIndex = 0;

            this.pnlBottom.Controls.Add(this.btnFinish);
            this.pnlBottom.Controls.Add(this.btnNext);
            this.pnlBottom.Controls.Add(this.btnPrev);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 634);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(960, 66);
            this.pnlBottom.TabIndex = 2;

            this.btnPrev.Location = new System.Drawing.Point(20, 12);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(170, 42);
            this.btnPrev.TabIndex = 0;
            this.btnPrev.Tag = "secondary";
            this.btnPrev.Text = "◀ Назад";
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);

            this.btnNext.Location = new System.Drawing.Point(200, 12);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(170, 42);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Далі ▶";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);

            this.btnFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinish.Location = new System.Drawing.Point(750, 12);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(190, 42);
            this.btnFinish.TabIndex = 2;
            this.btnFinish.Tag = "success";
            this.btnFinish.Text = "Завершити тест";
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);

            this.pnlQuestion.AutoScroll = true;
            this.pnlQuestion.BackColor = System.Drawing.Color.White;
            this.pnlQuestion.Controls.Add(this.pnlAnswers);
            this.pnlQuestion.Controls.Add(this.picQuestion);
            this.pnlQuestion.Controls.Add(this.lblPointsInfo);
            this.pnlQuestion.Controls.Add(this.lblQuestionText);
            this.pnlQuestion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlQuestion.Location = new System.Drawing.Point(0, 95);
            this.pnlQuestion.Name = "pnlQuestion";
            this.pnlQuestion.Size = new System.Drawing.Size(960, 539);
            this.pnlQuestion.TabIndex = 1;

            this.lblQuestionText.AutoSize = true;
            this.lblQuestionText.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblQuestionText.Location = new System.Drawing.Point(25, 20);
            this.lblQuestionText.MaximumSize = new System.Drawing.Size(900, 0);
            this.lblQuestionText.Name = "lblQuestionText";
            this.lblQuestionText.Text = "Текст питання";

            this.lblPointsInfo.AutoSize = true;
            this.lblPointsInfo.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblPointsInfo.Location = new System.Drawing.Point(27, 62);
            this.lblPointsInfo.Name = "lblPointsInfo";
            this.lblPointsInfo.Text = "Бали";

            this.picQuestion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picQuestion.Location = new System.Drawing.Point(25, 95);
            this.picQuestion.Name = "picQuestion";
            this.picQuestion.Size = new System.Drawing.Size(440, 250);
            this.picQuestion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picQuestion.TabIndex = 0;
            this.picQuestion.TabStop = false;
            this.picQuestion.Visible = false;

            this.pnlAnswers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAnswers.AutoScroll = true;
            this.pnlAnswers.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlAnswers.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.pnlAnswers.Location = new System.Drawing.Point(25, 100);
            this.pnlAnswers.Name = "pnlAnswers";
            this.pnlAnswers.Size = new System.Drawing.Size(900, 300);
            this.pnlAnswers.TabIndex = 1;
            this.pnlAnswers.WrapContents = false;

            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(960, 700);
            this.Controls.Add(this.pnlQuestion);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "TestPassingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Проходження тесту";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TestPassingForm_FormClosing);
            this.Load += new System.EventHandler(this.TestPassingForm_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlQuestion.ResumeLayout(false);
            this.pnlQuestion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQuestion)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTestTitle;
        private System.Windows.Forms.Label lblModule;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Panel pnlQuestion;
        private System.Windows.Forms.Label lblQuestionText;
        private System.Windows.Forms.Label lblPointsInfo;
        private System.Windows.Forms.PictureBox picQuestion;
        private System.Windows.Forms.FlowLayoutPanel pnlAnswers;
    }
}
