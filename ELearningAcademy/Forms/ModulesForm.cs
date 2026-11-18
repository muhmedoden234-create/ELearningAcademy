using ELearningAcademy.Helpers;
using ELearningAcademy.Models;
using ELearningAcademy.Models.Dto;
using ELearningAcademy.Services;

namespace ELearningAcademy.Forms
{
    public partial class ModulesForm : Form
    {
        private readonly int _courseId;
        private readonly ModuleService _moduleService = new ModuleService();
        private int _editingModuleId;
        private bool _loading;

        public ModulesForm(int courseId)
        {
            InitializeComponent();
            UiTheme.Apply(this);
            _courseId = courseId;
        }

        private void ModulesForm_Load(object sender, EventArgs e)
        {
            bool ok = UiHelper.Run(() =>
            {
                Course course = new CourseService().GetCourse(_courseId);
                lblTitle.Text = $"Модулі курсу «{course.Title}»";
                Text = "Модулі курсу — " + course.Title;
            });
            if (!ok)
            {
                BeginInvoke(new Action(Close));
                return;
            }
            LoadModules(null);
        }

        private void LoadModules(int? selectId)
        {
            _loading = true;
            UiHelper.Run(() =>
            {
                grid.DataSource = _moduleService.GetModules(_courseId);
                if (selectId.HasValue)
                    UiHelper.SelectRow<ModuleRow>(grid, m => m.Id == selectId.Value);
            });
            _loading = false;
            FillEditorFromSelection();
        }

        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            if (_loading) return;
            FillEditorFromSelection();
        }

        private void FillEditorFromSelection()
        {
            var row = UiHelper.GetSelected<ModuleRow>(grid);
            if (row == null)
            {
                ClearEditor();
                return;
            }
            _editingModuleId = row.Id;
            lblEditorTitle.Text = $"Редагування модуля №{row.Position}";
            txtModTitle.Text = row.Title;
            txtModDesc.Text = row.Description;
        }

        private void ClearEditor()
        {
            _editingModuleId = 0;
            lblEditorTitle.Text = "Новий модуль";
            txtModTitle.Clear();
            txtModDesc.Clear();
        }

        private void btnNewModule_Click(object sender, EventArgs e)
        {
            _loading = true;
            grid.ClearSelection();
            grid.CurrentCell = null;
            _loading = false;
            ClearEditor();
            txtModTitle.Focus();
        }

        private void btnSaveModule_Click(object sender, EventArgs e)
        {
            int savedId = 0;
            var data = new CourseModule
            {
                Id = _editingModuleId,
                CourseId = _courseId,
                Title = txtModTitle.Text,
                Description = txtModDesc.Text
            };

            if (UiHelper.Run(() => savedId = _moduleService.SaveModule(data)))
                LoadModules(savedId);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var row = RequireSelected();
            if (row == null) return;

            if (!UiHelper.Confirm($"Видалити модуль «{row.Title}»?\n\nБудуть видалені всі його уроки, тест і результати студентів."))
                return;

            if (UiHelper.Run(() => _moduleService.DeleteModule(row.Id)))
                LoadModules(null);
        }

        private void btnUp_Click(object sender, EventArgs e) => MoveSelected(-1);

        private void btnDown_Click(object sender, EventArgs e) => MoveSelected(+1);

        private void MoveSelected(int direction)
        {
            var row = RequireSelected();
            if (row == null) return;

            if (UiHelper.Run(() => _moduleService.MoveModule(row.Id, direction)))
                LoadModules(row.Id);
        }

        private void btnLessons_Click(object sender, EventArgs e)
        {
            var row = RequireSelected();
            if (row == null) return;

            using (var form = new LessonsForm(row.Id))
                form.ShowDialog(this);
            LoadModules(row.Id);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            var row = RequireSelected();
            if (row == null) return;

            using (var form = new TestConstructorForm(row.Id))
                form.ShowDialog(this);
            LoadModules(row.Id);
        }

        private ModuleRow RequireSelected()
        {
            var row = UiHelper.GetSelected<ModuleRow>(grid);
            if (row == null)
                UiHelper.ShowWarning("Оберіть модуль у списку.");
            return row;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
