namespace ELearningAcademy.Forms
{
    partial class CourseEditForm
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.chkPublished = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblHeader.Location = new System.Drawing.Point(25, 18);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Text = "Новий курс";

            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(25, 65);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "Назва курсу *";

            this.txtTitle.Location = new System.Drawing.Point(25, 88);
            this.txtTitle.MaxLength = 200;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(490, 30);
            this.txtTitle.TabIndex = 0;

            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(25, 130);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Text = "Опис курсу";

            this.txtDescription.Location = new System.Drawing.Point(25, 153);
            this.txtDescription.MaxLength = 2000;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(490, 150);
            this.txtDescription.TabIndex = 1;

            this.chkPublished.AutoSize = true;
            this.chkPublished.Location = new System.Drawing.Point(25, 315);
            this.chkPublished.Name = "chkPublished";
            this.chkPublished.TabIndex = 2;
            this.chkPublished.Text = "Опублікувати (курс буде видно студентам у каталозі)";

            this.btnSave.Location = new System.Drawing.Point(25, 360);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(240, 44);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Зберегти";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(275, 360);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(240, 44);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Tag = "secondary";
            this.btnCancel.Text = "Скасувати";

            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(540, 425);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkPublished);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CourseEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Курс";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.CheckBox chkPublished;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
