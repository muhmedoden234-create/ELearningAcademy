namespace ELearningAcademy.Helpers
{
    public static class UiTheme
    {
        public static readonly Color Primary = Color.FromArgb(37, 99, 235);
        public static readonly Color PrimaryHover = Color.FromArgb(29, 78, 216);
        public static readonly Color Danger = Color.FromArgb(220, 38, 38);
        public static readonly Color DangerHover = Color.FromArgb(185, 28, 28);
        public static readonly Color Success = Color.FromArgb(22, 163, 74);
        public static readonly Color SuccessHover = Color.FromArgb(21, 128, 61);
        public static readonly Color Secondary = Color.FromArgb(226, 232, 240);
        public static readonly Color SecondaryHover = Color.FromArgb(203, 213, 225);
        public static readonly Color Dark = Color.FromArgb(30, 41, 59);
        public static readonly Color SidebarHover = Color.FromArgb(51, 65, 85);
        public static readonly Color Background = Color.FromArgb(241, 245, 249);
        public static readonly Color Muted = Color.FromArgb(100, 116, 139);
        public static readonly Color Warning = Color.FromArgb(180, 83, 9);

        public static readonly Color LockedRow = Color.FromArgb(226, 232, 240);
        public static readonly Color PassedRow = Color.FromArgb(220, 252, 231);
        public static readonly Color FailedRow = Color.FromArgb(254, 226, 226);
        public static readonly Color InProgressRow = Color.FromArgb(254, 249, 195);

        public static void Apply(Form form)
        {
            form.BackColor = Background;
            ApplyToControls(form.Controls);
        }

        private static void ApplyToControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is Button button)
                    StyleButton(button);
                else if (control is DataGridView grid)
                    StyleGrid(grid);

                if (control.HasChildren && !(control is DataGridView))
                    ApplyToControls(control.Controls);
            }
        }

        public static void StyleButton(Button button)
        {
            string kind = button.Tag as string ?? "primary";
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Cursor = Cursors.Hand;
            button.UseVisualStyleBackColor = false;

            switch (kind)
            {
                case "danger":
                    SetColors(button, Danger, DangerHover, Color.White);
                    break;
                case "success":
                    SetColors(button, Success, SuccessHover, Color.White);
                    break;
                case "secondary":
                    SetColors(button, Secondary, SecondaryHover, Dark);
                    break;
                case "sidebar":
                    SetColors(button, Dark, SidebarHover, Color.White);
                    button.TextAlign = ContentAlignment.MiddleLeft;
                    button.Padding = new Padding(14, 0, 0, 0);
                    break;
                case "tool":
                    SetColors(button, Color.White, Secondary, Dark);
                    button.FlatAppearance.BorderSize = 1;
                    button.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
                    break;
                default:
                    SetColors(button, Primary, PrimaryHover, Color.White);
                    break;
            }
        }

        private static void SetColors(Button button, Color back, Color hover, Color fore)
        {
            button.BackColor = back;
            button.ForeColor = fore;
            button.FlatAppearance.MouseOverBackColor = hover;
            button.FlatAppearance.MouseDownBackColor = hover;
        }

        public static void StyleGrid(DataGridView grid)
        {
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Dark;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Dark;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.ColumnHeadersHeight = 36;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(191, 219, 254);
            grid.DefaultCellStyle.SelectionForeColor = Color.Black;
            grid.DefaultCellStyle.Padding = new Padding(4, 0, 4, 0);
            grid.RowTemplate.Height = 32;
            grid.GridColor = Color.FromArgb(226, 232, 240);
            grid.AllowUserToResizeRows = false;

            if (grid.ReadOnly)
            {
                grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                grid.MultiSelect = false;
                grid.AllowUserToAddRows = false;
                grid.AllowUserToDeleteRows = false;
                grid.RowHeadersVisible = false;
                grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            }
        }

        public static void ColorRows<T>(DataGridView grid, Func<T, Color?> getBackColor, Func<T, Color?> getForeColor = null)
            where T : class
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.DataBoundItem is T item)
                {
                    Color? back = getBackColor(item);
                    if (back.HasValue)
                        row.DefaultCellStyle.BackColor = back.Value;

                    Color? fore = getForeColor?.Invoke(item);
                    if (fore.HasValue)
                        row.DefaultCellStyle.ForeColor = fore.Value;
                }
            }
        }
    }
}
