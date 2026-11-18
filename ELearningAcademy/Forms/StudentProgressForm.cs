using ELearningAcademy.Helpers;
using ELearningAcademy.Models.Dto;
using ELearningAcademy.Services;

namespace ELearningAcademy.Forms
{
    public partial class StudentProgressForm : Form
    {
        private readonly int? _initialCourseId;
        private readonly ModuleAccessService _accessService = new ModuleAccessService();
        private readonly ProgressService _progressService = new ProgressService();
        private readonly LessonService _lessonService = new LessonService();
        private bool _loading;

        public StudentProgressForm(int? courseId)
        {
            InitializeComponent();
            UiTheme.Apply(this);
            _initialCourseId = courseId;

            gridModules.DataBindingComplete += (s, e) =>
                UiTheme.ColorRows<ModuleProgressInfo>(gridModules, GetModuleBackColor, GetModuleForeColor);
        }

        private static Color? GetModuleBackColor(ModuleProgressInfo m)
        {
            if (!m.IsUnlocked) return UiTheme.LockedRow;
            if (m.HasTest && m.IsPassed) return UiTheme.PassedRow;
            if (m.AttemptsCount > 0) return UiTheme.FailedRow;
            return Color.White;
        }

        private static Color? GetModuleForeColor(ModuleProgressInfo m)
        {
            return m.IsUnlocked ? (Color?)null : UiTheme.Muted;
        }

        private void StudentProgressForm_Load(object sender, EventArgs e)
        {
            List<ComboItem> courses = null;
            if (!UiHelper.Run(() => courses = new CourseService().GetEnrolledCourses(Session.UserId)))
            {
                BeginInvoke(new Action(Close));
                return;
            }

            if (courses.Count == 0)
            {
                UiHelper.ShowInfo("Ви ще не записані на жоден курс.\nВідкрийте «Каталог курсів» і запишіться на курс.");
                BeginInvoke(new Action(Close));
                return;
            }

            _loading = true;
            foreach (ComboItem item in courses)
                cmbCourse.Items.Add(item);

            ComboItem initial = courses.FirstOrDefault(c => c.Id == _initialCourseId) ?? courses[0];
            cmbCourse.SelectedItem = initial;
            _loading = false;

            LoadModules(null);
        }

        private int SelectedCourseId => cmbCourse.SelectedItem is ComboItem item ? item.Id : 0;

        private void cmbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_loading)
                LoadModules(null);
        }

        private void LoadModules(int? selectModuleId)
        {
            int courseId = SelectedCourseId;
            if (courseId == 0) return;

            _loading = true;
            UiHelper.Run(() =>
            {
                List<ModuleProgressInfo> statuses = _accessService.GetModuleStatuses(Session.UserId, courseId);
                gridModules.DataSource = statuses;

                int percent = _progressService.GetCourseProgressPercent(Session.UserId, courseId, out int passed, out int total);
                progressCourse.Value = Math.Max(0, Math.Min(100, percent));
                lblCourseProgress.Text = $"Прогрес курсу: {percent}%  (складено тестів: {passed} з {total})";

                if (selectModuleId.HasValue)
                    UiHelper.SelectRow<ModuleProgressInfo>(gridModules, m => m.ModuleId == selectModuleId.Value);
            });
            _loading = false;
            ShowModuleDetails();
        }

        private void gridModules_SelectionChanged(object sender, EventArgs e)
        {
            if (!_loading)
                ShowModuleDetails();
        }

        private void ShowModuleDetails()
        {
            var module = UiHelper.GetSelected<ModuleProgressInfo>(gridModules);
            if (module == null)
            {
                lblModuleStatus.Text = "Оберіть модуль ліворуч.";
                gridLessons.DataSource = null;
                btnOpenLesson.Enabled = false;
                btnTakeTest.Enabled = false;
                return;
            }

            if (!module.IsUnlocked)
            {
                lblModuleStatus.Text = $"🔒 Модуль «{module.Title}» заблоковано.\n" +
                                       "Щоб відкрити його, складіть тест попереднього модуля щонайменше на 70%.";
                lblModuleStatus.ForeColor = UiTheme.Muted;
            }
            else if (!module.HasTest)
            {
                lblModuleStatus.Text = $"Модуль «{module.Title}» відкрито. Тест у цьому модулі відсутній.";
                lblModuleStatus.ForeColor = UiTheme.Dark;
            }
            else if (module.IsPassed)
            {
                lblModuleStatus.Text = $"✔ Модуль «{module.Title}» завершено. Найкращий результат: {module.BestResultText}.";
                lblModuleStatus.ForeColor = UiTheme.Success;
            }
            else if (module.AttemptsCount > 0)
            {
                lblModuleStatus.Text = $"Тест модуля «{module.Title}» ще не складено (найкращий результат: {module.BestResultText}).\n" +
                                       "Повторіть уроки та пройдіть тест ще раз — потрібно щонайменше 70%.";
                lblModuleStatus.ForeColor = UiTheme.Danger;
            }
            else
            {
                lblModuleStatus.Text = $"Модуль «{module.Title}» відкрито. Вивчіть уроки й пройдіть тест (потрібно щонайменше 70%).";
                lblModuleStatus.ForeColor = UiTheme.Primary;
            }

            UiHelper.Run(() => gridLessons.DataSource = _lessonService.GetLessons(module.ModuleId));

            btnOpenLesson.Enabled = module.IsUnlocked;
            btnTakeTest.Enabled = module.IsUnlocked && module.HasTest;
            btnTakeTest.Text = !module.HasTest ? "Тест відсутній"
                : module.AttemptsCount == 0 ? "Пройти тест"
                : module.IsPassed ? "Пройти тест ще раз"
                : "Повторити тест";
        }

        private void btnOpenLesson_Click(object sender, EventArgs e)
        {
            var module = UiHelper.GetSelected<ModuleProgressInfo>(gridModules);
            var lesson = UiHelper.GetSelected<LessonRow>(gridLessons);
            if (module == null || lesson == null)
            {
                UiHelper.ShowWarning("Оберіть модуль і урок.");
                return;
            }

            using (var form = new LessonViewForm(lesson.Id))
                form.ShowDialog(this);
        }

        private void gridLessons_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && btnOpenLesson.Enabled)
                btnOpenLesson_Click(sender, EventArgs.Empty);
        }

        private void btnTakeTest_Click(object sender, EventArgs e)
        {
            var module = UiHelper.GetSelected<ModuleProgressInfo>(gridModules);
            if (module == null) return;

            using (var form = new TestPassingForm(module.ModuleId))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    LoadModules(module.ModuleId);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
