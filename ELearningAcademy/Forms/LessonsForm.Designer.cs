namespace ELearningAcademy.Forms
{
    partial class LessonsForm
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
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.gridLessons = new System.Windows.Forms.DataGridView();
            this.pnlLeftButtons = new System.Windows.Forms.Panel();
            this.btnNewLesson = new System.Windows.Forms.Button();
            this.btnDeleteLesson = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.pnlEditor = new System.Windows.Forms.Panel();
            this.rtbContent = new System.Windows.Forms.RichTextBox();
            this.pnlEditorButtons = new System.Windows.Forms.Panel();
            this.btnSaveLesson = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.lblEditorMode = new System.Windows.Forms.Label();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.btnBold = new System.Windows.Forms.Button();
            this.btnItalic = new System.Windows.Forms.Button();
            this.btnUnderline = new System.Windows.Forms.Button();
            this.btnHeading = new System.Windows.Forms.Button();
            this.btnNormal = new System.Windows.Forms.Button();
            this.btnBullet = new System.Windows.Forms.Button();
            this.lblFontSize = new System.Windows.Forms.Label();
            this.cmbFontSize = new System.Windows.Forms.ComboBox();
            this.pnlTitleBar = new System.Windows.Forms.Panel();
            this.lblLessonTitle = new System.Windows.Forms.Label();
            this.txtLessonTitle = new System.Windows.Forms.TextBox();
            this.pnlTop.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLessons)).BeginInit();
            this.pnlLeftButtons.SuspendLayout();
            this.pnlEditor.SuspendLayout();
            this.pnlEditorButtons.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.pnlTitleBar.SuspendLayout();
            this.SuspendLayout();

            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblHint);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1200, 72);
            this.pnlTop.TabIndex = 0;

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "Уроки модуля";

            this.lblHint.AutoSize = true;
            this.lblHint.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblHint.Location = new System.Drawing.Point(22, 44);
            this.lblHint.Name = "lblHint";
            this.lblHint.Text = "Оберіть урок зліва або створіть новий. Виділіть текст і застосуйте форматування. Вміст зберігається у форматі RTF.";

            this.pnlLeft.Controls.Add(this.gridLessons);
            this.pnlLeft.Controls.Add(this.pnlLeftButtons);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 72);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(320, 648);
            this.pnlLeft.TabIndex = 1;

            this.gridLessons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridLessons.Location = new System.Drawing.Point(0, 0);
            this.gridLessons.Name = "gridLessons";
            this.gridLessons.ReadOnly = true;
            this.gridLessons.Size = new System.Drawing.Size(320, 538);
            this.gridLessons.TabIndex = 0;
            this.gridLessons.SelectionChanged += new System.EventHandler(this.gridLessons_SelectionChanged);

            this.pnlLeftButtons.Controls.Add(this.btnDown);
            this.pnlLeftButtons.Controls.Add(this.btnUp);
            this.pnlLeftButtons.Controls.Add(this.btnDeleteLesson);
            this.pnlLeftButtons.Controls.Add(this.btnNewLesson);
            this.pnlLeftButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLeftButtons.Location = new System.Drawing.Point(0, 538);
            this.pnlLeftButtons.Name = "pnlLeftButtons";
            this.pnlLeftButtons.Size = new System.Drawing.Size(320, 110);
            this.pnlLeftButtons.TabIndex = 1;

            this.btnNewLesson.Location = new System.Drawing.Point(10, 10);
            this.btnNewLesson.Name = "btnNewLesson";
            this.btnNewLesson.Size = new System.Drawing.Size(145, 40);
            this.btnNewLesson.TabIndex = 0;
            this.btnNewLesson.Text = "+ Новий урок";
            this.btnNewLesson.Click += new System.EventHandler(this.btnNewLesson_Click);

            this.btnDeleteLesson.Location = new System.Drawing.Point(165, 10);
            this.btnDeleteLesson.Name = "btnDeleteLesson";
            this.btnDeleteLesson.Size = new System.Drawing.Size(145, 40);
            this.btnDeleteLesson.TabIndex = 1;
            this.btnDeleteLesson.Tag = "danger";
            this.btnDeleteLesson.Text = "Видалити";
            this.btnDeleteLesson.Click += new System.EventHandler(this.btnDeleteLesson_Click);

            this.btnUp.Location = new System.Drawing.Point(10, 58);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(145, 40);
            this.btnUp.TabIndex = 2;
            this.btnUp.Tag = "secondary";
            this.btnUp.Text = "▲ Вгору";
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);

            this.btnDown.Location = new System.Drawing.Point(165, 58);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(145, 40);
            this.btnDown.TabIndex = 3;
            this.btnDown.Tag = "secondary";
            this.btnDown.Text = "▼ Вниз";
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);

            this.pnlEditor.Controls.Add(this.rtbContent);
            this.pnlEditor.Controls.Add(this.pnlEditorButtons);
            this.pnlEditor.Controls.Add(this.pnlToolbar);
            this.pnlEditor.Controls.Add(this.pnlTitleBar);
            this.pnlEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEditor.Location = new System.Drawing.Point(320, 72);
            this.pnlEditor.Name = "pnlEditor";
            this.pnlEditor.Padding = new System.Windows.Forms.Padding(15, 8, 15, 0);
            this.pnlEditor.Size = new System.Drawing.Size(880, 648);
            this.pnlEditor.TabIndex = 2;

            this.pnlTitleBar.Controls.Add(this.txtLessonTitle);
            this.pnlTitleBar.Controls.Add(this.lblLessonTitle);
            this.pnlTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitleBar.Location = new System.Drawing.Point(15, 8);
            this.pnlTitleBar.Name = "pnlTitleBar";
            this.pnlTitleBar.Size = new System.Drawing.Size(850, 66);
            this.pnlTitleBar.TabIndex = 0;

            this.lblLessonTitle.AutoSize = true;
            this.lblLessonTitle.Location = new System.Drawing.Point(0, 4);
            this.lblLessonTitle.Name = "lblLessonTitle";
            this.lblLessonTitle.Text = "Назва уроку *";

            this.txtLessonTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLessonTitle.Location = new System.Drawing.Point(0, 28);
            this.txtLessonTitle.MaxLength = 200;
            this.txtLessonTitle.Name = "txtLessonTitle";
            this.txtLessonTitle.Size = new System.Drawing.Size(850, 30);
            this.txtLessonTitle.TabIndex = 0;
            this.txtLessonTitle.TextChanged += new System.EventHandler(this.Content_Changed);

            this.pnlToolbar.Controls.Add(this.cmbFontSize);
            this.pnlToolbar.Controls.Add(this.lblFontSize);
            this.pnlToolbar.Controls.Add(this.btnBullet);
            this.pnlToolbar.Controls.Add(this.btnNormal);
            this.pnlToolbar.Controls.Add(this.btnHeading);
            this.pnlToolbar.Controls.Add(this.btnUnderline);
            this.pnlToolbar.Controls.Add(this.btnItalic);
            this.pnlToolbar.Controls.Add(this.btnBold);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(15, 74);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(850, 48);
            this.pnlToolbar.TabIndex = 1;

            this.btnBold.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBold.Location = new System.Drawing.Point(0, 6);
            this.btnBold.Name = "btnBold";
            this.btnBold.Size = new System.Drawing.Size(40, 34);
            this.btnBold.TabIndex = 0;
            this.btnBold.Tag = "tool";
            this.btnBold.Text = "Ж";
            this.btnBold.Click += new System.EventHandler(this.btnBold_Click);

            this.btnItalic.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.btnItalic.Location = new System.Drawing.Point(45, 6);
            this.btnItalic.Name = "btnItalic";
            this.btnItalic.Size = new System.Drawing.Size(40, 34);
            this.btnItalic.TabIndex = 1;
            this.btnItalic.Tag = "tool";
            this.btnItalic.Text = "К";
            this.btnItalic.Click += new System.EventHandler(this.btnItalic_Click);

            this.btnUnderline.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Underline);
            this.btnUnderline.Location = new System.Drawing.Point(90, 6);
            this.btnUnderline.Name = "btnUnderline";
            this.btnUnderline.Size = new System.Drawing.Size(40, 34);
            this.btnUnderline.TabIndex = 2;
            this.btnUnderline.Tag = "tool";
            this.btnUnderline.Text = "П";
            this.btnUnderline.Click += new System.EventHandler(this.btnUnderline_Click);

            this.btnHeading.Location = new System.Drawing.Point(140, 6);
            this.btnHeading.Name = "btnHeading";
            this.btnHeading.Size = new System.Drawing.Size(110, 34);
            this.btnHeading.TabIndex = 3;
            this.btnHeading.Tag = "tool";
            this.btnHeading.Text = "Заголовок";
            this.btnHeading.Click += new System.EventHandler(this.btnHeading_Click);

            this.btnNormal.Location = new System.Drawing.Point(255, 6);
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.Size = new System.Drawing.Size(110, 34);
            this.btnNormal.TabIndex = 4;
            this.btnNormal.Tag = "tool";
            this.btnNormal.Text = "Звичайний";
            this.btnNormal.Click += new System.EventHandler(this.btnNormal_Click);

            this.btnBullet.Location = new System.Drawing.Point(370, 6);
            this.btnBullet.Name = "btnBullet";
            this.btnBullet.Size = new System.Drawing.Size(100, 34);
            this.btnBullet.TabIndex = 5;
            this.btnBullet.Tag = "tool";
            this.btnBullet.Text = "• Список";
            this.btnBullet.Click += new System.EventHandler(this.btnBullet_Click);

            this.lblFontSize.AutoSize = true;
            this.lblFontSize.Location = new System.Drawing.Point(485, 13);
            this.lblFontSize.Name = "lblFontSize";
            this.lblFontSize.Text = "Розмір:";

            this.cmbFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFontSize.Location = new System.Drawing.Point(550, 9);
            this.cmbFontSize.Name = "cmbFontSize";
            this.cmbFontSize.Size = new System.Drawing.Size(80, 31);
            this.cmbFontSize.TabIndex = 6;
            this.cmbFontSize.SelectedIndexChanged += new System.EventHandler(this.cmbFontSize_SelectedIndexChanged);

            this.rtbContent.AcceptsTab = true;
            this.rtbContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbContent.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.rtbContent.Location = new System.Drawing.Point(15, 122);
            this.rtbContent.Name = "rtbContent";
            this.rtbContent.Size = new System.Drawing.Size(850, 466);
            this.rtbContent.TabIndex = 2;
            this.rtbContent.Text = "";
            this.rtbContent.TextChanged += new System.EventHandler(this.Content_Changed);

            this.pnlEditorButtons.Controls.Add(this.lblEditorMode);
            this.pnlEditorButtons.Controls.Add(this.btnPreview);
            this.pnlEditorButtons.Controls.Add(this.btnSaveLesson);
            this.pnlEditorButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlEditorButtons.Location = new System.Drawing.Point(15, 588);
            this.pnlEditorButtons.Name = "pnlEditorButtons";
            this.pnlEditorButtons.Size = new System.Drawing.Size(850, 60);
            this.pnlEditorButtons.TabIndex = 3;

            this.btnSaveLesson.Location = new System.Drawing.Point(0, 10);
            this.btnSaveLesson.Name = "btnSaveLesson";
            this.btnSaveLesson.Size = new System.Drawing.Size(200, 42);
            this.btnSaveLesson.TabIndex = 0;
            this.btnSaveLesson.Text = "Зберегти урок";
            this.btnSaveLesson.Click += new System.EventHandler(this.btnSaveLesson_Click);

            this.btnPreview.Location = new System.Drawing.Point(210, 10);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(200, 42);
            this.btnPreview.TabIndex = 1;
            this.btnPreview.Tag = "secondary";
            this.btnPreview.Text = "Переглянути урок";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);

            this.lblEditorMode.AutoSize = true;
            this.lblEditorMode.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblEditorMode.Location = new System.Drawing.Point(425, 21);
            this.lblEditorMode.Name = "lblEditorMode";
            this.lblEditorMode.Text = "Новий урок";

            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.Controls.Add(this.pnlEditor);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(1100, 650);
            this.Name = "LessonsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Уроки модуля";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LessonsForm_FormClosing);
            this.Load += new System.EventHandler(this.LessonsForm_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridLessons)).EndInit();
            this.pnlLeftButtons.ResumeLayout(false);
            this.pnlEditor.ResumeLayout(false);
            this.pnlEditorButtons.ResumeLayout(false);
            this.pnlEditorButtons.PerformLayout();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.pnlTitleBar.ResumeLayout(false);
            this.pnlTitleBar.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.DataGridView gridLessons;
        private System.Windows.Forms.Panel pnlLeftButtons;
        private System.Windows.Forms.Button btnNewLesson;
        private System.Windows.Forms.Button btnDeleteLesson;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Panel pnlEditor;
        private System.Windows.Forms.Panel pnlTitleBar;
        private System.Windows.Forms.Label lblLessonTitle;
        private System.Windows.Forms.TextBox txtLessonTitle;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Button btnBold;
        private System.Windows.Forms.Button btnItalic;
        private System.Windows.Forms.Button btnUnderline;
        private System.Windows.Forms.Button btnHeading;
        private System.Windows.Forms.Button btnNormal;
        private System.Windows.Forms.Button btnBullet;
        private System.Windows.Forms.Label lblFontSize;
        private System.Windows.Forms.ComboBox cmbFontSize;
        private System.Windows.Forms.RichTextBox rtbContent;
        private System.Windows.Forms.Panel pnlEditorButtons;
        private System.Windows.Forms.Button btnSaveLesson;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Label lblEditorMode;
    }
}
