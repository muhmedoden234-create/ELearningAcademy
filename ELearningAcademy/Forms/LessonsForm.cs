using ELearningAcademy.Helpers;
using ELearningAcademy.Models;
using ELearningAcademy.Models.Dto;
using ELearningAcademy.Services;

namespace ELearningAcademy.Forms
{
    public partial class LessonsForm : Form
    {
        private static readonly float[] FontSizes = { 9, 10, 11, 12, 14, 16, 18, 20, 24, 28 };
        private const string BaseFontName = "Segoe UI";

        private readonly int _moduleId;
        private readonly LessonService _lessonService = new LessonService();
        private int _editingLessonId;
        private bool _loading;
        private bool _dirty;

        public LessonsForm(int moduleId)
        {
            InitializeComponent();
            UiTheme.Apply(this);
            _moduleId = moduleId;
        }

        private void LessonsForm_Load(object sender, EventArgs e)
        {
            _loading = true;
            foreach (float size in FontSizes)
                cmbFontSize.Items.Add(size.ToString());
            cmbFontSize.SelectedItem = "11";
            _loading = false;

            bool ok = UiHelper.Run(() =>
            {
                CourseModule module = new ModuleService().GetModule(_moduleId);
                lblTitle.Text = $"Уроки модуля «{module.Title}»";
                Text = "Уроки — " + module.Title;
            });
            if (!ok)
            {
                BeginInvoke(new Action(Close));
                return;
            }

            LoadLessons(null);
            if (UiHelper.GetSelected<LessonRow>(gridLessons) == null)
                StartNewLesson();
        }

        private void LoadLessons(int? selectId)
        {
            _loading = true;
            UiHelper.Run(() =>
            {
                gridLessons.DataSource = _lessonService.GetLessons(_moduleId);
                if (selectId.HasValue)
                    UiHelper.SelectRow<LessonRow>(gridLessons, l => l.Id == selectId.Value);
            });
            _loading = false;

            var row = UiHelper.GetSelected<LessonRow>(gridLessons);
            if (row != null)
                ShowLesson(row.Id);
        }

        private void gridLessons_SelectionChanged(object sender, EventArgs e)
        {
            if (_loading) return;

            var row = UiHelper.GetSelected<LessonRow>(gridLessons);
            if (row == null || row.Id == _editingLessonId) return;

            if (_dirty && UiHelper.Confirm("У поточному уроці є незбережені зміни. Зберегти їх?"))
                SaveCurrentLesson(false);

            ShowLesson(row.Id);
        }

        private void ShowLesson(int lessonId)
        {
            Lesson lesson = null;
            if (!UiHelper.Run(() => lesson = _lessonService.GetLesson(lessonId)))
                return;

            _loading = true;
            _editingLessonId = lesson.Id;
            txtLessonTitle.Text = lesson.Title;
            rtbContent.Font = new Font(BaseFontName, 11F);
            UiHelper.LoadRichText(rtbContent, lesson.ContentRtf);
            lblEditorMode.Text = "Редагування уроку «" + lesson.Title + "»";
            _dirty = false;
            _loading = false;
        }

        private void StartNewLesson()
        {
            _loading = true;
            gridLessons.ClearSelection();
            gridLessons.CurrentCell = null;
            _editingLessonId = 0;
            txtLessonTitle.Clear();
            rtbContent.Clear();
            rtbContent.Font = new Font(BaseFontName, 11F);
            lblEditorMode.Text = "Новий урок (ще не збережено)";
            _dirty = false;
            _loading = false;
            txtLessonTitle.Focus();
        }

        private void btnNewLesson_Click(object sender, EventArgs e)
        {
            if (_dirty && UiHelper.Confirm("Є незбережені зміни. Зберегти поточний урок перед створенням нового?"))
            {
                if (!SaveCurrentLesson(true))
                    return;
            }
            StartNewLesson();
        }

        private void btnDeleteLesson_Click(object sender, EventArgs e)
        {
            var row = UiHelper.GetSelected<LessonRow>(gridLessons);
            if (row == null || _editingLessonId == 0)
            {
                UiHelper.ShowWarning("Оберіть збережений урок у списку.");
                return;
            }
            if (!UiHelper.Confirm($"Видалити урок «{row.Title}»?"))
                return;

            if (UiHelper.Run(() => _lessonService.DeleteLesson(row.Id)))
            {
                _dirty = false;
                _editingLessonId = 0;
                LoadLessons(null);
                if (UiHelper.GetSelected<LessonRow>(gridLessons) == null)
                    StartNewLesson();
            }
        }

        private void btnUp_Click(object sender, EventArgs e) => MoveSelected(-1);

        private void btnDown_Click(object sender, EventArgs e) => MoveSelected(+1);

        private void MoveSelected(int direction)
        {
            if (_editingLessonId == 0) return;
            int id = _editingLessonId;
            if (_dirty && !SaveCurrentLesson(false)) return;

            if (UiHelper.Run(() => _lessonService.MoveLesson(id, direction)))
                LoadLessons(id);
        }

        private void btnSaveLesson_Click(object sender, EventArgs e)
        {
            if (SaveCurrentLesson(true))
                lblEditorMode.Text = "Урок збережено ✓  " + DateTime.Now.ToString("HH:mm:ss");
        }

        private bool SaveCurrentLesson(bool reloadList)
        {
            int savedId = 0;
            var data = new Lesson
            {
                Id = _editingLessonId,
                ModuleId = _moduleId,
                Title = txtLessonTitle.Text,
                ContentRtf = rtbContent.Rtf
            };

            bool ok = UiHelper.Run(() => savedId = _lessonService.SaveLesson(data));
            if (!ok) return false;

            _editingLessonId = savedId;
            _dirty = false;
            if (reloadList)
                LoadLessons(savedId);
            return true;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (_dirty || _editingLessonId == 0)
            {
                if (!UiHelper.Confirm("Щоб переглянути урок, його потрібно зберегти. Зберегти зараз?"))
                    return;
                if (!SaveCurrentLesson(true))
                    return;
            }

            using (var form = new LessonViewForm(_editingLessonId))
                form.ShowDialog(this);
        }

        private void Content_Changed(object sender, EventArgs e)
        {
            if (!_loading)
                _dirty = true;
        }

        private void LessonsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_dirty) return;

            DialogResult answer = UiHelper.AskYesNoCancel("Є незбережені зміни в уроці. Зберегти перед закриттям?");
            if (answer == DialogResult.Cancel)
                e.Cancel = true;
            else if (answer == DialogResult.Yes && !SaveCurrentLesson(false))
                e.Cancel = true;
        }

        private void ToggleStyle(FontStyle style)
        {
            Font current = rtbContent.SelectionFont ?? rtbContent.Font;
            rtbContent.SelectionFont = new Font(current, current.Style ^ style);
            _dirty = true;
            rtbContent.Focus();
        }

        private void btnBold_Click(object sender, EventArgs e) => ToggleStyle(FontStyle.Bold);

        private void btnItalic_Click(object sender, EventArgs e) => ToggleStyle(FontStyle.Italic);

        private void btnUnderline_Click(object sender, EventArgs e) => ToggleStyle(FontStyle.Underline);

        private void btnHeading_Click(object sender, EventArgs e)
        {
            rtbContent.SelectionFont = new Font(BaseFontName, 16F, FontStyle.Bold);
            _dirty = true;
            rtbContent.Focus();
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            rtbContent.SelectionFont = new Font(BaseFontName, 11F, FontStyle.Regular);
            rtbContent.SelectionBullet = false;
            _dirty = true;
            rtbContent.Focus();
        }

        private void btnBullet_Click(object sender, EventArgs e)
        {
            rtbContent.SelectionBullet = !rtbContent.SelectionBullet;
            _dirty = true;
            rtbContent.Focus();
        }

        private void cmbFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_loading || cmbFontSize.SelectedItem == null) return;
            if (!float.TryParse(cmbFontSize.SelectedItem.ToString(), out float size)) return;

            Font current = rtbContent.SelectionFont ?? rtbContent.Font;
            rtbContent.SelectionFont = new Font(current.FontFamily, size, current.Style);
            _dirty = true;
            rtbContent.Focus();
        }
    }
}
