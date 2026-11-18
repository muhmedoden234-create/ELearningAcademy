namespace ELearningAcademy.Forms
{
    partial class LessonViewForm
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
            this.lblModule = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblPosition = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.rtbContent = new System.Windows.Forms.RichTextBox();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();

            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.lblModule);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(900, 85);
            this.pnlTop.TabIndex = 0;

            this.lblModule.AutoSize = true;
            this.lblModule.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblModule.Location = new System.Drawing.Point(25, 10);
            this.lblModule.Name = "lblModule";
            this.lblModule.Text = "Модуль";

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(22, 34);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "Урок";

            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Controls.Add(this.lblPosition);
            this.pnlBottom.Controls.Add(this.btnNext);
            this.pnlBottom.Controls.Add(this.btnPrev);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 616);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(900, 64);
            this.pnlBottom.TabIndex = 2;

            this.btnPrev.Location = new System.Drawing.Point(20, 12);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(170, 40);
            this.btnPrev.TabIndex = 0;
            this.btnPrev.Tag = "secondary";
            this.btnPrev.Text = "◀ Попередній урок";
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);

            this.btnNext.Location = new System.Drawing.Point(200, 12);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(170, 40);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Наступний урок ▶";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);

            this.lblPosition.AutoSize = true;
            this.lblPosition.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblPosition.Location = new System.Drawing.Point(390, 22);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Text = "Урок 1 з 1";

            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(760, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 40);
            this.btnClose.TabIndex = 2;
            this.btnClose.Tag = "secondary";
            this.btnClose.Text = "Закрити";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            this.pnlBody.Controls.Add(this.rtbContent);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 85);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(20);
            this.pnlBody.Size = new System.Drawing.Size(900, 531);
            this.pnlBody.TabIndex = 1;

            this.rtbContent.BackColor = System.Drawing.Color.White;
            this.rtbContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbContent.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.rtbContent.Location = new System.Drawing.Point(20, 20);
            this.rtbContent.Name = "rtbContent";
            this.rtbContent.ReadOnly = true;
            this.rtbContent.Size = new System.Drawing.Size(860, 491);
            this.rtbContent.TabIndex = 0;
            this.rtbContent.Text = "";

            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(900, 680);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "LessonViewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Перегляд уроку";
            this.Load += new System.EventHandler(this.LessonViewForm_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblModule;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.RichTextBox rtbContent;
    }
}
