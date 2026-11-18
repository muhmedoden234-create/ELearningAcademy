using ELearningAcademy.Helpers;
using ELearningAcademy.Models.Dto;
using ELearningAcademy.Reports;
using ELearningAcademy.Services;

namespace ELearningAcademy.Forms
{
    public partial class ResultsForm : Form
    {
        private readonly ProgressService _progressService = new ProgressService();
        private AttemptDetails _currentDetails;
        private bool _loading;

        public ResultsForm()
        {
            InitializeComponent();
            UiTheme.Apply(this);

            gridAttempts.DataBindingComplete += (s, e) =>
                UiTheme.ColorRows<AttemptRow>(gridAttempts, r => r.IsPassed ? UiTheme.PassedRow : UiTheme.FailedRow);
            gridAnswers.DataBindingComplete += (s, e) =>
            {
                UiTheme.ColorRows<AnswerDetail>(gridAnswers, a => a.IsCorrect ? UiTheme.PassedRow : UiTheme.FailedRow);
                if (Session.IsStudent && gridAnswers.Columns.Contains(nameof(AnswerDetail.CorrectAnswerText)))
                    gridAnswers.Columns[nameof(AnswerDetail.CorrectAnswerText)].Visible = false;
            };
        }

        private void ResultsForm_Load(object sender, EventArgs e)
        {
            bool isTeacher = Session.IsTeacher;
            lblTitle.Text = isTeacher ? "Результати студентів" : "Мої результати";
            Text = lblTitle.Text;
            lblCourse.Visible = isTeacher;
            cmbCourse.Visible = isTeacher;
            lblStudent.Visible = isTeacher;
            cmbStudent.Visible = isTeacher;
            btnExport.Visible = isTeacher;

            if (isTeacher)
            {
                _loading = true;
                UiHelper.Run(() =>
                {
                    cmbCourse.Items.Add(new ComboItem(0, "Усі курси"));
                    foreach (ComboItem item in new CourseService().GetCourseItems())
                        cmbCourse.Items.Add(item);
                    cmbCourse.SelectedIndex = 0;

                    cmbStudent.Items.Add(new ComboItem(0, "Усі студенти"));
                    foreach (ComboItem item in _progressService.GetStudentItems())
                        cmbStudent.Items.Add(item);
                    cmbStudent.SelectedIndex = 0;
                });
                _loading = false;
            }

            LoadAttempts();
        }

        private void LoadAttempts()
        {
            int? courseId = null;
            int? studentId;

            if (Session.IsTeacher)
            {
                if (cmbCourse.SelectedItem is ComboItem c && c.Id > 0) courseId = c.Id;
                studentId = cmbStudent.SelectedItem is ComboItem s && s.Id > 0 ? s.Id : (int?)null;
            }
            else
            {
                studentId = Session.UserId;
            }

            _loading = true;
            UiHelper.Run(() => gridAttempts.DataSource = _progressService.GetAttempts(courseId, studentId));
            _loading = false;
            ShowDetails();
        }

        private void Filter_Changed(object sender, EventArgs e)
        {
            if (!_loading)
                LoadAttempts();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAttempts();
        }

        private void gridAttempts_SelectionChanged(object sender, EventArgs e)
        {
            if (!_loading)
                ShowDetails();
        }

        private void ShowDetails()
        {
            var row = UiHelper.GetSelected<AttemptRow>(gridAttempts);
            if (row == null)
            {
                _currentDetails = null;
                gridAnswers.DataSource = null;
                lblDetails.Text = "Відповіді на питання";
                lblSummary.Text = gridAttempts.Rows.Count == 0 ? "Спроб ще немає." : "Оберіть спробу у верхній таблиці.";
                lblSummary.ForeColor = UiTheme.Muted;
                return;
            }

            AttemptDetails details = null;
            int? restrict = Session.IsStudent ? Session.UserId : (int?)null;
            if (!UiHelper.Run(() => details = _progressService.GetAttemptDetails(row.Id, restrict)))
                return;

            _currentDetails = details;
            gridAnswers.DataSource = details.Answers;
            lblDetails.Text = $"Відповіді: {details.StudentName} — {details.TestTitle} ({details.FinishedAt:dd.MM.yyyy HH:mm})";
            lblSummary.Text = $"Набрано {details.ScoreObtained} з {details.MaxScore} балів  ·  " +
                              $"{details.Percent:0.##}%  ·  {(details.IsPassed ? "СКЛАДЕНО" : "НЕ СКЛАДЕНО")}";
            lblSummary.ForeColor = details.IsPassed ? UiTheme.Success : UiTheme.Danger;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (_currentDetails == null)
            {
                UiHelper.ShowWarning("Оберіть спробу, для якої потрібно сформувати звіт.");
                return;
            }

            AttemptDetails details = _currentDetails;
            string fileName = $"Звіт_{details.StudentName}_{details.ModuleTitle}_{details.FinishedAt:yyyy-MM-dd_HH-mm}.xlsx";
            UiHelper.SaveExcel(this, fileName,
                path => new ExcelReportGenerator().ExportAttemptReport(details, path));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
