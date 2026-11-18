using ELearningAcademy.Helpers;
using ELearningAcademy.Models.Dto;
using ELearningAcademy.Reports;
using ELearningAcademy.Services;

namespace ELearningAcademy.Forms
{
    public partial class ReportsForm : Form
    {
        private readonly ProgressService _progressService = new ProgressService();
        private readonly ExcelReportGenerator _generator = new ExcelReportGenerator();
        private bool _loading;

        public ReportsForm()
        {
            InitializeComponent();
            UiTheme.Apply(this);
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            _loading = true;
            UiHelper.Run(() =>
            {
                foreach (ComboItem item in new CourseService().GetCourseItems())
                    cmbCourse.Items.Add(item);
            });
            _loading = false;

            if (cmbCourse.Items.Count > 0)
                cmbCourse.SelectedIndex = 0;
            else
                lblStatus.Text = "Курсів ще немає.";
        }

        private ComboItem SelectedCourse => cmbCourse.SelectedItem as ComboItem;
        private ComboItem SelectedStudent => cmbStudent.SelectedItem as ComboItem;
        private ComboItem SelectedAttempt => cmbAttempt.SelectedItem as ComboItem;

        private void cmbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_loading || SelectedCourse == null) return;

            cmbStudent.Items.Clear();
            cmbAttempt.Items.Clear();

            UiHelper.Run(() =>
            {
                foreach (ComboItem item in _progressService.GetStudentsWithAttempts(SelectedCourse.Id))
                    cmbStudent.Items.Add(item);
            });

            if (cmbStudent.Items.Count > 0)
            {
                cmbStudent.SelectedIndex = 0;
                lblStatus.Text = string.Empty;
            }
            else
            {
                lblStatus.Text = "За цим курсом ще немає жодної спроби проходження тесту.";
            }
        }

        private void cmbStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_loading || SelectedCourse == null || SelectedStudent == null) return;

            cmbAttempt.Items.Clear();
            UiHelper.Run(() =>
            {
                foreach (AttemptRow a in _progressService.GetAttempts(SelectedCourse.Id, SelectedStudent.Id))
                {
                    cmbAttempt.Items.Add(new ComboItem(a.Id,
                        $"{a.ModuleTitle}  —  {a.FinishedAtText}  —  {a.PercentText} ({a.StatusText})"));
                }
            });
            if (cmbAttempt.Items.Count > 0)
                cmbAttempt.SelectedIndex = 0;
        }

        private void btnExportAttempt_Click(object sender, EventArgs e)
        {
            if (SelectedAttempt == null)
            {
                UiHelper.ShowWarning("Оберіть курс, студента та спробу.");
                return;
            }

            AttemptDetails details = null;
            if (!UiHelper.Run(() => details = _progressService.GetAttemptDetails(SelectedAttempt.Id, null)))
                return;

            string fileName = $"Звіт_{details.StudentName}_{details.ModuleTitle}_{details.FinishedAt:yyyy-MM-dd_HH-mm}.xlsx";
            UiHelper.SaveExcel(this, fileName, path =>
            {
                _generator.ExportAttemptReport(details, path);
                lblStatus.Text = "Збережено: " + path;
            });
        }

        private void btnExportSummary_Click(object sender, EventArgs e)
        {
            if (SelectedCourse == null)
            {
                UiHelper.ShowWarning("Оберіть курс.");
                return;
            }

            List<AttemptRow> rows = null;
            if (!UiHelper.Run(() => rows = _progressService.GetAttempts(SelectedCourse.Id, null)))
                return;

            if (rows.Count == 0)
            {
                UiHelper.ShowWarning("За обраним курсом ще немає жодної спроби.");
                return;
            }

            string courseTitle = SelectedCourse.Text;
            string fileName = $"Відомість_{courseTitle}_{DateTime.Now:yyyy-MM-dd}.xlsx";
            UiHelper.SaveExcel(this, fileName, path =>
            {
                _generator.ExportCourseSummary(courseTitle, rows, path);
                lblStatus.Text = "Збережено: " + path;
            });
        }
    }
}
