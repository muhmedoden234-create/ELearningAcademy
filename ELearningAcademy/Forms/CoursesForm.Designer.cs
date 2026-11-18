namespace ELearningAcademy.Forms
{
    partial class CoursesForm
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnModules = new System.Windows.Forms.Button();
            this.btnEnroll = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            this.pnlTop.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();

            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblHint);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1000, 80);
            this.pnlTop.TabIndex = 0;

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "Курси";

            this.lblHint.AutoSize = true;
            this.lblHint.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblHint.Location = new System.Drawing.Point(22, 48);
            this.lblHint.Name = "lblHint";
            this.lblHint.Text = "Підказка";

            this.pnlButtons.Controls.Add(this.btnClose);
            this.pnlButtons.Controls.Add(this.btnOpen);
            this.pnlButtons.Controls.Add(this.btnEnroll);
            this.pnlButtons.Controls.Add(this.btnModules);
            this.pnlButtons.Controls.Add(this.btnDelete);
            this.pnlButtons.Controls.Add(this.btnEdit);
            this.pnlButtons.Controls.Add(this.btnAdd);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 536);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(1000, 64);
            this.pnlButtons.TabIndex = 2;

            this.btnAdd.Location = new System.Drawing.Point(20, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 40);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Додати";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnEdit.Location = new System.Drawing.Point(150, 12);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(140, 40);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Tag = "secondary";
            this.btnEdit.Text = "Редагувати";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            this.btnDelete.Location = new System.Drawing.Point(300, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 40);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Tag = "danger";
            this.btnDelete.Text = "Видалити";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.btnModules.Location = new System.Drawing.Point(430, 12);
            this.btnModules.Name = "btnModules";
            this.btnModules.Size = new System.Drawing.Size(220, 40);
            this.btnModules.TabIndex = 3;
            this.btnModules.Tag = "success";
            this.btnModules.Text = "Модулі, уроки та тести";
            this.btnModules.Click += new System.EventHandler(this.btnModules_Click);

            this.btnEnroll.Location = new System.Drawing.Point(20, 12);
            this.btnEnroll.Name = "btnEnroll";
            this.btnEnroll.Size = new System.Drawing.Size(170, 40);
            this.btnEnroll.TabIndex = 4;
            this.btnEnroll.Tag = "success";
            this.btnEnroll.Text = "Записатися";
            this.btnEnroll.Click += new System.EventHandler(this.btnEnroll_Click);

            this.btnOpen.Location = new System.Drawing.Point(200, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(200, 40);
            this.btnOpen.TabIndex = 5;
            this.btnOpen.Text = "Перейти до навчання";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);

            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(860, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 40);
            this.btnClose.TabIndex = 6;
            this.btnClose.Tag = "secondary";
            this.btnClose.Text = "Закрити";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 80);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.Size = new System.Drawing.Size(1000, 456);
            this.grid.TabIndex = 1;
            this.grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellDoubleClick);

            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "CoursesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Курси";
            this.Load += new System.EventHandler(this.CoursesForm_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnModules;
        private System.Windows.Forms.Button btnEnroll;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView grid;
    }
}
