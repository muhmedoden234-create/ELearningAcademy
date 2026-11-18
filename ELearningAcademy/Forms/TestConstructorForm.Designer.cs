namespace ELearningAcademy.Forms
{
    partial class TestConstructorForm
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblTestTitle = new System.Windows.Forms.Label();
            this.txtTestTitle = new System.Windows.Forms.TextBox();
            this.lblTestDesc = new System.Windows.Forms.Label();
            this.txtTestDesc = new System.Windows.Forms.TextBox();
            this.btnSaveTest = new System.Windows.Forms.Button();
            this.btnDeleteTest = new System.Windows.Forms.Button();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.gridQuestions = new System.Windows.Forms.DataGridView();
            this.pnlLeftButtons = new System.Windows.Forms.Panel();
            this.btnNewQuestion = new System.Windows.Forms.Button();
            this.btnDeleteQuestion = new System.Windows.Forms.Button();
            this.lblSummary = new System.Windows.Forms.Label();
            this.lblQuestions = new System.Windows.Forms.Label();
            this.pnlQuestion = new System.Windows.Forms.Panel();
            this.lblEditorMode = new System.Windows.Forms.Label();
            this.lblQText = new System.Windows.Forms.Label();
            this.txtQText = new System.Windows.Forms.TextBox();
            this.lblQType = new System.Windows.Forms.Label();
            this.cmbQType = new System.Windows.Forms.ComboBox();
            this.lblPoints = new System.Windows.Forms.Label();
            this.numPoints = new System.Windows.Forms.NumericUpDown();
            this.lblOptions = new System.Windows.Forms.Label();
            this.gridOptions = new System.Windows.Forms.DataGridView();
            this.colOptionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOptionText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsCorrect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnRemoveOption = new System.Windows.Forms.Button();
            this.lblTextHint = new System.Windows.Forms.Label();
            this.lblImage = new System.Windows.Forms.Label();
            this.picQuestion = new System.Windows.Forms.PictureBox();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.btnRemoveImage = new System.Windows.Forms.Button();
            this.lblImageHint = new System.Windows.Forms.Label();
            this.btnSaveQuestion = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridQuestions)).BeginInit();
            this.pnlLeftButtons.SuspendLayout();
            this.pnlQuestion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picQuestion)).BeginInit();
            this.SuspendLayout();

            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.btnDeleteTest);
            this.pnlTop.Controls.Add(this.btnSaveTest);
            this.pnlTop.Controls.Add(this.txtTestDesc);
            this.pnlTop.Controls.Add(this.lblTestDesc);
            this.pnlTop.Controls.Add(this.txtTestTitle);
            this.pnlTop.Controls.Add(this.lblTestTitle);
            this.pnlTop.Controls.Add(this.lblHeader);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1280, 120);
            this.pnlTop.TabIndex = 0;

            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblHeader.Location = new System.Drawing.Point(20, 8);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Text = "Конструктор тесту";

            this.lblTestTitle.AutoSize = true;
            this.lblTestTitle.Location = new System.Drawing.Point(20, 50);
            this.lblTestTitle.Name = "lblTestTitle";
            this.lblTestTitle.Text = "Назва тесту *";

            this.txtTestTitle.Location = new System.Drawing.Point(20, 75);
            this.txtTestTitle.MaxLength = 200;
            this.txtTestTitle.Name = "txtTestTitle";
            this.txtTestTitle.Size = new System.Drawing.Size(380, 30);
            this.txtTestTitle.TabIndex = 0;

            this.lblTestDesc.AutoSize = true;
            this.lblTestDesc.Location = new System.Drawing.Point(420, 50);
            this.lblTestDesc.Name = "lblTestDesc";
            this.lblTestDesc.Text = "Опис / інструкція для студента";

            this.txtTestDesc.Location = new System.Drawing.Point(420, 75);
            this.txtTestDesc.MaxLength = 1000;
            this.txtTestDesc.Name = "txtTestDesc";
            this.txtTestDesc.Size = new System.Drawing.Size(430, 30);
            this.txtTestDesc.TabIndex = 1;

            this.btnSaveTest.Location = new System.Drawing.Point(870, 70);
            this.btnSaveTest.Name = "btnSaveTest";
            this.btnSaveTest.Size = new System.Drawing.Size(180, 40);
            this.btnSaveTest.TabIndex = 2;
            this.btnSaveTest.Text = "Зберегти тест";
            this.btnSaveTest.Click += new System.EventHandler(this.btnSaveTest_Click);

            this.btnDeleteTest.Location = new System.Drawing.Point(1060, 70);
            this.btnDeleteTest.Name = "btnDeleteTest";
            this.btnDeleteTest.Size = new System.Drawing.Size(180, 40);
            this.btnDeleteTest.TabIndex = 3;
            this.btnDeleteTest.Tag = "danger";
            this.btnDeleteTest.Text = "Видалити тест";
            this.btnDeleteTest.Click += new System.EventHandler(this.btnDeleteTest_Click);

            this.pnlLeft.Controls.Add(this.gridQuestions);
            this.pnlLeft.Controls.Add(this.pnlLeftButtons);
            this.pnlLeft.Controls.Add(this.lblSummary);
            this.pnlLeft.Controls.Add(this.lblQuestions);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 120);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(400, 680);
            this.pnlLeft.TabIndex = 1;

            this.lblQuestions.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblQuestions.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblQuestions.Location = new System.Drawing.Point(0, 0);
            this.lblQuestions.Name = "lblQuestions";
            this.lblQuestions.Padding = new System.Windows.Forms.Padding(10, 8, 0, 0);
            this.lblQuestions.Size = new System.Drawing.Size(400, 34);
            this.lblQuestions.Text = "Питання тесту";

            this.lblSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSummary.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblSummary.Location = new System.Drawing.Point(0, 34);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.lblSummary.Size = new System.Drawing.Size(400, 46);
            this.lblSummary.Text = "";

            this.gridQuestions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridQuestions.Location = new System.Drawing.Point(0, 80);
            this.gridQuestions.Name = "gridQuestions";
            this.gridQuestions.ReadOnly = true;
            this.gridQuestions.Size = new System.Drawing.Size(400, 538);
            this.gridQuestions.TabIndex = 0;
            this.gridQuestions.SelectionChanged += new System.EventHandler(this.gridQuestions_SelectionChanged);

            this.pnlLeftButtons.Controls.Add(this.btnDeleteQuestion);
            this.pnlLeftButtons.Controls.Add(this.btnNewQuestion);
            this.pnlLeftButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLeftButtons.Location = new System.Drawing.Point(0, 618);
            this.pnlLeftButtons.Name = "pnlLeftButtons";
            this.pnlLeftButtons.Size = new System.Drawing.Size(400, 62);
            this.pnlLeftButtons.TabIndex = 1;

            this.btnNewQuestion.Location = new System.Drawing.Point(10, 10);
            this.btnNewQuestion.Name = "btnNewQuestion";
            this.btnNewQuestion.Size = new System.Drawing.Size(185, 42);
            this.btnNewQuestion.TabIndex = 0;
            this.btnNewQuestion.Text = "+ Нове питання";
            this.btnNewQuestion.Click += new System.EventHandler(this.btnNewQuestion_Click);

            this.btnDeleteQuestion.Location = new System.Drawing.Point(205, 10);
            this.btnDeleteQuestion.Name = "btnDeleteQuestion";
            this.btnDeleteQuestion.Size = new System.Drawing.Size(185, 42);
            this.btnDeleteQuestion.TabIndex = 1;
            this.btnDeleteQuestion.Tag = "danger";
            this.btnDeleteQuestion.Text = "Видалити питання";
            this.btnDeleteQuestion.Click += new System.EventHandler(this.btnDeleteQuestion_Click);

            this.pnlQuestion.AutoScroll = true;
            this.pnlQuestion.BackColor = System.Drawing.Color.White;
            this.pnlQuestion.Controls.Add(this.lblStatus);
            this.pnlQuestion.Controls.Add(this.btnSaveQuestion);
            this.pnlQuestion.Controls.Add(this.lblImageHint);
            this.pnlQuestion.Controls.Add(this.btnRemoveImage);
            this.pnlQuestion.Controls.Add(this.btnLoadImage);
            this.pnlQuestion.Controls.Add(this.picQuestion);
            this.pnlQuestion.Controls.Add(this.lblImage);
            this.pnlQuestion.Controls.Add(this.lblTextHint);
            this.pnlQuestion.Controls.Add(this.btnRemoveOption);
            this.pnlQuestion.Controls.Add(this.gridOptions);
            this.pnlQuestion.Controls.Add(this.lblOptions);
            this.pnlQuestion.Controls.Add(this.numPoints);
            this.pnlQuestion.Controls.Add(this.lblPoints);
            this.pnlQuestion.Controls.Add(this.cmbQType);
            this.pnlQuestion.Controls.Add(this.lblQType);
            this.pnlQuestion.Controls.Add(this.txtQText);
            this.pnlQuestion.Controls.Add(this.lblQText);
            this.pnlQuestion.Controls.Add(this.lblEditorMode);
            this.pnlQuestion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlQuestion.Location = new System.Drawing.Point(400, 120);
            this.pnlQuestion.Name = "pnlQuestion";
            this.pnlQuestion.Size = new System.Drawing.Size(880, 680);
            this.pnlQuestion.TabIndex = 2;

            this.lblEditorMode.AutoSize = true;
            this.lblEditorMode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEditorMode.Location = new System.Drawing.Point(20, 12);
            this.lblEditorMode.Name = "lblEditorMode";
            this.lblEditorMode.Text = "Нове питання";

            this.lblQText.AutoSize = true;
            this.lblQText.Location = new System.Drawing.Point(20, 48);
            this.lblQText.Name = "lblQText";
            this.lblQText.Text = "Текст питання *";

            this.txtQText.Location = new System.Drawing.Point(20, 72);
            this.txtQText.MaxLength = 2000;
            this.txtQText.Multiline = true;
            this.txtQText.Name = "txtQText";
            this.txtQText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtQText.Size = new System.Drawing.Size(500, 80);
            this.txtQText.TabIndex = 0;

            this.lblQType.AutoSize = true;
            this.lblQType.Location = new System.Drawing.Point(20, 165);
            this.lblQType.Name = "lblQType";
            this.lblQType.Text = "Тип питання";

            this.cmbQType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQType.Location = new System.Drawing.Point(20, 189);
            this.cmbQType.Name = "cmbQType";
            this.cmbQType.Size = new System.Drawing.Size(300, 31);
            this.cmbQType.TabIndex = 1;
            this.cmbQType.SelectedIndexChanged += new System.EventHandler(this.cmbQType_SelectedIndexChanged);

            this.lblPoints.AutoSize = true;
            this.lblPoints.Location = new System.Drawing.Point(340, 165);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Text = "Вага (бали)";

            this.numPoints.Location = new System.Drawing.Point(340, 189);
            this.numPoints.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.numPoints.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numPoints.Name = "numPoints";
            this.numPoints.Size = new System.Drawing.Size(100, 30);
            this.numPoints.TabIndex = 2;
            this.numPoints.Value = new decimal(new int[] { 1, 0, 0, 0 });

            this.lblOptions.AutoSize = true;
            this.lblOptions.Location = new System.Drawing.Point(20, 232);
            this.lblOptions.Name = "lblOptions";
            this.lblOptions.Text = "Варіанти відповідей:";

            this.gridOptions.AllowUserToAddRows = true;
            this.gridOptions.AllowUserToDeleteRows = true;
            this.gridOptions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOptionId,
            this.colOptionText,
            this.colIsCorrect});
            this.gridOptions.Location = new System.Drawing.Point(20, 256);
            this.gridOptions.Name = "gridOptions";
            this.gridOptions.RowHeadersWidth = 30;
            this.gridOptions.Size = new System.Drawing.Size(500, 220);
            this.gridOptions.TabIndex = 3;
            this.gridOptions.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridOptions_CellValueChanged);
            this.gridOptions.CurrentCellDirtyStateChanged += new System.EventHandler(this.gridOptions_CurrentCellDirtyStateChanged);

            this.colOptionId.HeaderText = "Id";
            this.colOptionId.Name = "colOptionId";
            this.colOptionId.Visible = false;

            this.colOptionText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colOptionText.HeaderText = "Текст варіанта";
            this.colOptionText.MaxInputLength = 500;
            this.colOptionText.Name = "colOptionText";

            this.colIsCorrect.HeaderText = "Правильна";
            this.colIsCorrect.Name = "colIsCorrect";
            this.colIsCorrect.Width = 100;

            this.btnRemoveOption.Location = new System.Drawing.Point(20, 484);
            this.btnRemoveOption.Name = "btnRemoveOption";
            this.btnRemoveOption.Size = new System.Drawing.Size(200, 34);
            this.btnRemoveOption.TabIndex = 4;
            this.btnRemoveOption.Tag = "secondary";
            this.btnRemoveOption.Text = "Видалити рядок варіанта";
            this.btnRemoveOption.Click += new System.EventHandler(this.btnRemoveOption_Click);

            this.lblTextHint.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblTextHint.Location = new System.Drawing.Point(230, 480);
            this.lblTextHint.Name = "lblTextHint";
            this.lblTextHint.Size = new System.Drawing.Size(290, 44);
            this.lblTextHint.Text = "Регістр літер і зайві пробіли під час перевірки не враховуються.";
            this.lblTextHint.Visible = false;

            this.lblImage.AutoSize = true;
            this.lblImage.Location = new System.Drawing.Point(545, 48);
            this.lblImage.Name = "lblImage";
            this.lblImage.Text = "Зображення / схема / графік";

            this.picQuestion.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.picQuestion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picQuestion.Location = new System.Drawing.Point(545, 72);
            this.picQuestion.Name = "picQuestion";
            this.picQuestion.Size = new System.Drawing.Size(320, 220);
            this.picQuestion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picQuestion.TabIndex = 5;
            this.picQuestion.TabStop = false;

            this.btnLoadImage.Location = new System.Drawing.Point(545, 300);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(155, 36);
            this.btnLoadImage.TabIndex = 6;
            this.btnLoadImage.Text = "Завантажити...";
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);

            this.btnRemoveImage.Location = new System.Drawing.Point(710, 300);
            this.btnRemoveImage.Name = "btnRemoveImage";
            this.btnRemoveImage.Size = new System.Drawing.Size(155, 36);
            this.btnRemoveImage.TabIndex = 7;
            this.btnRemoveImage.Tag = "secondary";
            this.btnRemoveImage.Text = "Прибрати";
            this.btnRemoveImage.Click += new System.EventHandler(this.btnRemoveImage_Click);

            this.lblImageHint.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblImageHint.Location = new System.Drawing.Point(545, 344);
            this.lblImageHint.Name = "lblImageHint";
            this.lblImageHint.Size = new System.Drawing.Size(320, 66);
            this.lblImageHint.Text = "PNG, JPG, BMP або GIF (до 900 КБ). Зображення зберігається в БД як масив байтів byte[] після натискання «Зберегти питання».";

            this.btnSaveQuestion.Location = new System.Drawing.Point(20, 540);
            this.btnSaveQuestion.Name = "btnSaveQuestion";
            this.btnSaveQuestion.Size = new System.Drawing.Size(240, 44);
            this.btnSaveQuestion.TabIndex = 8;
            this.btnSaveQuestion.Tag = "success";
            this.btnSaveQuestion.Text = "Зберегти питання";
            this.btnSaveQuestion.Click += new System.EventHandler(this.btnSaveQuestion_Click);

            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblStatus.Location = new System.Drawing.Point(275, 552);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Text = "";

            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.pnlQuestion);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(1200, 760);
            this.Name = "TestConstructorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Конструктор тесту";
            this.Load += new System.EventHandler(this.TestConstructorForm_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridQuestions)).EndInit();
            this.pnlLeftButtons.ResumeLayout(false);
            this.pnlQuestion.ResumeLayout(false);
            this.pnlQuestion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picQuestion)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblTestTitle;
        private System.Windows.Forms.TextBox txtTestTitle;
        private System.Windows.Forms.Label lblTestDesc;
        private System.Windows.Forms.TextBox txtTestDesc;
        private System.Windows.Forms.Button btnSaveTest;
        private System.Windows.Forms.Button btnDeleteTest;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label lblQuestions;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.DataGridView gridQuestions;
        private System.Windows.Forms.Panel pnlLeftButtons;
        private System.Windows.Forms.Button btnNewQuestion;
        private System.Windows.Forms.Button btnDeleteQuestion;
        private System.Windows.Forms.Panel pnlQuestion;
        private System.Windows.Forms.Label lblEditorMode;
        private System.Windows.Forms.Label lblQText;
        private System.Windows.Forms.TextBox txtQText;
        private System.Windows.Forms.Label lblQType;
        private System.Windows.Forms.ComboBox cmbQType;
        private System.Windows.Forms.Label lblPoints;
        private System.Windows.Forms.NumericUpDown numPoints;
        private System.Windows.Forms.Label lblOptions;
        private System.Windows.Forms.DataGridView gridOptions;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOptionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOptionText;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsCorrect;
        private System.Windows.Forms.Button btnRemoveOption;
        private System.Windows.Forms.Label lblTextHint;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.PictureBox picQuestion;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.Button btnRemoveImage;
        private System.Windows.Forms.Label lblImageHint;
        private System.Windows.Forms.Button btnSaveQuestion;
        private System.Windows.Forms.Label lblStatus;
    }
}
