using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace ELearningAcademy.Helpers
{
    public static class UiHelper
    {
        private const string AppTitle = "E-Learning Academy";

        public static void ShowInfo(string message) =>
            MessageBox.Show(message, AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

        public static void ShowWarning(string message) =>
            MessageBox.Show(message, AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);

        public static void ShowError(string message) =>
            MessageBox.Show(message, AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);

        public static bool Confirm(string message) =>
            MessageBox.Show(message, AppTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

        public static DialogResult AskYesNoCancel(string message) =>
            MessageBox.Show(message, AppTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

        public static bool Run(Action action)
        {
            Cursor previous = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                action();
                return true;
            }
            catch (BusinessException ex)
            {
                Cursor.Current = previous;
                ShowWarning(ex.Message);
            }
            catch (DbUpdateException ex)
            {
                Cursor.Current = previous;
                ShowError("Помилка збереження даних у базі:\n" + (ex.InnerException?.Message ?? ex.Message));
            }
            catch (Exception ex)
            {
                Cursor.Current = previous;
                ShowError("Сталася помилка:\n" + ex.Message);
            }
            finally
            {
                Cursor.Current = previous;
            }
            return false;
        }

        public static T GetSelected<T>(DataGridView grid) where T : class
        {
            if (grid.SelectedRows.Count > 0)
                return grid.SelectedRows[0].DataBoundItem as T;
            return grid.CurrentRow?.DataBoundItem as T;
        }

        public static void SelectRow<T>(DataGridView grid, Func<T, bool> predicate) where T : class
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.DataBoundItem is T item && predicate(item))
                {
                    DataGridViewCell firstVisible = row.Cells.Cast<DataGridViewCell>().FirstOrDefault(c => c.Visible);
                    if (firstVisible != null)
                        grid.CurrentCell = firstVisible;
                    row.Selected = true;
                    return;
                }
            }
        }

        public static void LoadRichText(RichTextBox box, string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                box.Clear();
                return;
            }

            if (content.TrimStart().StartsWith(@"{\rtf", StringComparison.Ordinal))
            {
                try
                {
                    box.Rtf = content;
                    return;
                }
                catch (ArgumentException)
                {
                }
            }
            box.Text = content;
        }

        public static string SafeFileName(string name)
        {
            foreach (char c in Path.GetInvalidFileNameChars())
                name = name.Replace(c, '_');
            return name.Replace(' ', '_');
        }

        public static void SaveExcel(IWin32Window owner, string defaultFileName, Action<string> export)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Title = "Зберегти звіт Excel";
                dialog.Filter = "Книга Excel (*.xlsx)|*.xlsx";
                dialog.FileName = SafeFileName(defaultFileName);
                dialog.DefaultExt = "xlsx";
                dialog.AddExtension = true;

                if (dialog.ShowDialog(owner) != DialogResult.OK)
                    return;

                string path = dialog.FileName;
                bool ok = Run(() => export(path));
                if (ok && Confirm("Звіт успішно збережено:\n" + path + "\n\nВідкрити файл зараз?"))
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        ShowWarning("Не вдалося відкрити файл автоматично: " + ex.Message);
                    }
                }
            }
        }
    }
}
