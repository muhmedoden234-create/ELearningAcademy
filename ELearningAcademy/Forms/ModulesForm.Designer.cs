namespace ELearningAcademy.Forms
{
    partial class ModulesForm
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
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnLessons = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlEditor = new System.Windows.Forms.Panel();
            this.lblEditorTitle = new System.Windows.Forms.Label();
            this.lblModTitle = new System.Windows.Forms.Label();
            this.txtModTitle = new System.Windows.Forms.TextBox();
            this.lblModDesc = new System.Windows.Forms.Label();
            this.txtModDesc = new System.Windows.Forms.TextBox();
            this.btnSaveModule = new System.Windows.Forms.Button();
            this.btnNewModule = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            this.pnlTop.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.pnlEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();

            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblHint);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1100, 80);
            this.pnlTop.TabIndex = 0;

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "Модулі курсу";

            this.lblHint.AutoSize = true;
            this.lblHint.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblHint.Location = new System.Drawing.Point(22, 48);
            this.lblHint.Name = "lblHint";
            this.lblHint.Text = "Модулі відкриваються студентам по черзі: наступний — після складання тесту попереднього щонайменше на 70%.";

            this.pnlButtons.Controls.Add(this.btnClose);
            this.pnlButtons.Controls.Add(this.btnTest);
            this.pnlButtons.Controls.Add(this.btnLessons);
            this.pnlButtons.Controls.Add(this.btnDown);
            this.pnlButtons.Controls.Add(this.btnUp);
            this.pnlButtons.Controls.Add(this.btnDelete);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 576);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(1100, 64);
            this.pnlButtons.TabIndex = 3;

            this.btnDelete.Location = new System.Drawing.Point(20, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 40);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Tag = "danger";
            this.btnDelete.Text = "Видалити";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.btnUp.Location = new System.Drawing.Point(150, 12);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(110, 40);
            this.btnUp.TabIndex = 1;
            this.btnUp.Tag = "secondary";
            this.btnUp.Text = "▲ Вгору";
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);

            this.btnDown.Location = new System.Drawing.Point(270, 12);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(110, 40);
            this.btnDown.TabIndex = 2;
            this.btnDown.Tag = "secondary";
            this.btnDown.Text = "▼ Вниз";
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);

            this.btnLessons.Location = new System.Drawing.Point(390, 12);
            this.btnLessons.Name = "btnLessons";
            this.btnLessons.Size = new System.Drawing.Size(170, 40);
            this.btnLessons.TabIndex = 3;
            this.btnLessons.Text = "Уроки модуля";
            this.btnLessons.Click += new System.EventHandler(this.btnLessons_Click);

            this.btnTest.Location = new System.Drawing.Point(570, 12);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(190, 40);
            this.btnTest.TabIndex = 4;
            this.btnTest.Tag = "success";
            this.btnTest.Text = "Конструктор тесту";
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);

            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(960, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 40);
            this.btnClose.TabIndex = 5;
            this.btnClose.Tag = "secondary";
            this.btnClose.Text = "Закрити";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            this.pnlEditor.BackColor = System.Drawing.Color.White;
            this.pnlEditor.Controls.Add(this.btnNewModule);
            this.pnlEditor.Controls.Add(this.btnSaveModule);
            this.pnlEditor.Controls.Add(this.txtModDesc);
            this.pnlEditor.Controls.Add(this.lblModDesc);
            this.pnlEditor.Controls.Add(this.txtModTitle);
            this.pnlEditor.Controls.Add(this.lblModTitle);
            this.pnlEditor.Controls.Add(this.lblEditorTitle);
            this.pnlEditor.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlEditor.Location = new System.Drawing.Point(760, 80);
            this.pnlEditor.Name = "pnlEditor";
            this.pnlEditor.Size = new System.Drawing.Size(340, 496);
            this.pnlEditor.TabIndex = 2;

            this.lblEditorTitle.AutoSize = true;
            this.lblEditorTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEditorTitle.Location = new System.Drawing.Point(20, 15);
            this.lblEditorTitle.Name = "lblEditorTitle";
            this.lblEditorTitle.Text = "Новий модуль";

            this.lblModTitle.AutoSize = true;
            this.lblModTitle.Location = new System.Drawing.Point(20, 55);
            this.lblModTitle.Name = "lblModTitle";
            this.lblModTitle.Text = "Назва модуля *";

            this.txtModTitle.Location = new System.Drawing.Point(20, 78);
            this.txtModTitle.MaxLength = 200;
            this.txtModTitle.Name = "txtModTitle";
            this.txtModTitle.Size = new System.Drawing.Size(300, 30);
            this.txtModTitle.TabIndex = 0;

            this.lblModDesc.AutoSize = true;
            this.lblModDesc.Location = new System.Drawing.Point(20, 120);
            this.lblModDesc.Name = "lblModDesc";
            this.lblModDesc.Text = "Опис модуля";

            this.txtModDesc.Location = new System.Drawing.Point(20, 143);
            this.txtModDesc.MaxLength = 2000;
            this.txtModDesc.Multiline = true;
            this.txtModDesc.Name = "txtModDesc";
            this.txtModDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtModDesc.Size = new System.Drawing.Size(300, 150);
            this.txtModDesc.TabIndex = 1;

            this.btnSaveModule.Location = new System.Drawing.Point(20, 310);
            this.btnSaveModule.Name = "btnSaveModule";
            this.btnSaveModule.Size = new System.Drawing.Size(300, 42);
            this.btnSaveModule.TabIndex = 2;
            this.btnSaveModule.Text = "Зберегти модуль";
            this.btnSaveModule.Click += new System.EventHandler(this.btnSaveModule_Click);

            this.btnNewModule.Location = new System.Drawing.Point(20, 362);
            this.btnNewModule.Name = "btnNewModule";
            this.btnNewModule.Size = new System.Drawing.Size(300, 38);
            this.btnNewModule.TabIndex = 3;
            this.btnNewModule.Tag = "secondary";
            this.btnNewModule.Text = "+ Створити новий модуль";
            this.btnNewModule.Click += new System.EventHandler(this.btnNewModule_Click);

            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 80);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.Size = new System.Drawing.Size(760, 496);
            this.grid.TabIndex = 1;
            this.grid.SelectionChanged += new System.EventHandler(this.grid_SelectionChanged);

            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1100, 640);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.pnlEditor);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(1000, 560);
            this.Name = "ModulesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Модулі курсу";
            this.Load += new System.EventHandler(this.ModulesForm_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.pnlEditor.ResumeLayout(false);
            this.pnlEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnLessons;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlEditor;
        private System.Windows.Forms.Label lblEditorTitle;
        private System.Windows.Forms.Label lblModTitle;
        private System.Windows.Forms.TextBox txtModTitle;
        private System.Windows.Forms.Label lblModDesc;
        private System.Windows.Forms.TextBox txtModDesc;
        private System.Windows.Forms.Button btnSaveModule;
        private System.Windows.Forms.Button btnNewModule;
        private System.Windows.Forms.DataGridView grid;
    }
}
