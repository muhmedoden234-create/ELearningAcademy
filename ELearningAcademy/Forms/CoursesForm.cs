using ELearningAcademy.Helpers;
using ELearningAcademy.Models;
using ELearningAcademy.Models.Dto;
using ELearningAcademy.Services;

namespace ELearningAcademy.Forms
{
    public partial class CoursesForm : Form
    {
        private readonly CourseService _courseService = new CourseService();

        public CoursesForm()
        {
            InitializeComponent();
            UiTheme.Apply(this);
        }

        private void CoursesForm_Load(object sender, EventArgs e)
        {
            bool isTeacher = Session.IsTeacher;

            Text = isTeacher ? "Керування курсами" : "Каталог курсів";
            lblTitle.Text = Text;
            lblHint.Text = isTeacher
                ? "Створюйте курси, а потім додавайте до них модулі, уроки та тести (кнопка «Модулі, уроки та тести»)."
                : "Оберіть курс і натисніть «Записатися». Подвійний клік — перейти до навчання.";

            btnAdd.Visible = isTeacher;
            btnEdit.Visible = isTeacher;
            btnDelete.Visible = isTeacher;
            btnModules.Visible = isTeacher;
            btnEnroll.Visible = !isTeacher;
            btnOpen.Visible = !isTeacher;

            LoadCourses(null);
        }

        private void LoadCourses(int? selectId)
        {
            UiHelper.Run(() =>
            {
                if (Session.IsTeacher)
                {
                    grid.DataSource = _courseService.GetCoursesForTeacher();
                    if (selectId.HasValue)
                        UiHelper.SelectRow<CourseRow>(grid, r => r.Id == selectId.Value);
                }
                else
                {
                    grid.DataSource = _courseService.GetCatalogForStudent(Session.UserId);
                    if (selectId.HasValue)
                        UiHelper.SelectRow<CatalogCourseRow>(grid, r => r.Id == selectId.Value);
                }
            });
        }

        private int? SelectedCourseId()
        {
            if (Session.IsTeacher)
                return UiHelper.GetSelected<CourseRow>(grid)?.Id;
            return UiHelper.GetSelected<CatalogCourseRow>(grid)?.Id;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new CourseEditForm(null))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    LoadCourses(form.SavedCourseId);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int? id = SelectedCourseId();
            if (id == null)
            {
                UiHelper.ShowWarning("Оберіть курс у списку.");
                return;
            }

            Course course = null;
            if (!UiHelper.Run(() => course = _courseService.GetCourse(id.Value)))
                return;

            using (var form = new CourseEditForm(course))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    LoadCourses(id);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var row = UiHelper.GetSelected<CourseRow>(grid);
            if (row == null)
            {
                UiHelper.ShowWarning("Оберіть курс у списку.");
                return;
            }

            if (!UiHelper.Confirm($"Видалити курс «{row.Title}»?\n\n" +
                                  "Разом з ним будуть видалені всі модулі, уроки, тести, " +
                                  "записи студентів та результати тестування. Дію неможливо скасувати."))
                return;

            if (UiHelper.Run(() => _courseService.DeleteCourse(row.Id)))
                LoadCourses(null);
        }

        private void btnModules_Click(object sender, EventArgs e)
        {
            int? id = SelectedCourseId();
            if (id == null)
            {
                UiHelper.ShowWarning("Оберіть курс у списку.");
                return;
            }

            using (var form = new ModulesForm(id.Value))
                form.ShowDialog(this);
            LoadCourses(id);
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            var row = UiHelper.GetSelected<CatalogCourseRow>(grid);
            if (row == null)
            {
                UiHelper.ShowWarning("Оберіть курс у списку.");
                return;
            }
            if (row.IsEnrolled)
            {
                UiHelper.ShowInfo("Ви вже записані на цей курс. Натисніть «Перейти до навчання».");
                return;
            }

            if (UiHelper.Run(() => _courseService.Enroll(Session.UserId, row.Id)))
            {
                UiHelper.ShowInfo($"Ви успішно записалися на курс «{row.Title}».\nПерший модуль уже доступний для навчання.");
                LoadCourses(row.Id);
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            var row = UiHelper.GetSelected<CatalogCourseRow>(grid);
            if (row == null)
            {
                UiHelper.ShowWarning("Оберіть курс у списку.");
                return;
            }
            if (!row.IsEnrolled)
            {
                UiHelper.ShowWarning("Спочатку запишіться на курс (кнопка «Записатися»).");
                return;
            }

            using (var form = new StudentProgressForm(row.Id))
                form.ShowDialog(this);
        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (Session.IsTeacher)
                btnEdit_Click(sender, EventArgs.Empty);
            else
                btnOpen_Click(sender, EventArgs.Empty);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
