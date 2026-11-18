using ELearningAcademy.Helpers;
using ELearningAcademy.Services;

namespace ELearningAcademy.Forms
{
    public partial class MainForm : Form
    {
        private readonly ProgressService _progressService = new ProgressService();

        public bool LogoutRequested { get; private set; }

        public MainForm()
        {
            InitializeComponent();
            UiTheme.Apply(this);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var user = Session.CurrentUser;
            lblWelcome.Text = $"Вітаємо, {user.FullName}!";
            lblRole.Text = Session.IsTeacher ? "Роль: викладач (адміністратор)" : "Роль: студент";

            bool isTeacher = Session.IsTeacher;
            btnCourses.Visible = isTeacher;
            btnResults.Visible = isTeacher;
            btnReports.Visible = isTeacher;
            btnCatalog.Visible = !isTeacher;
            btnProgress.Visible = !isTeacher;
            btnMyResults.Visible = !isTeacher;

            RefreshDashboard();
        }

        private void RefreshDashboard()
        {
            UiHelper.Run(() =>
            {
                if (Session.IsTeacher)
                {
                    var stats = _progressService.GetTeacherStats();
                    lblCard1Value.Text = stats.CoursesCount.ToString();
                    lblCard1Caption.Text = "Курсів у системі";
                    lblCard2Value.Text = stats.StudentsCount.ToString();
                    lblCard2Caption.Text = "Зареєстрованих студентів";
                    lblCard3Value.Text = stats.AttemptsCount.ToString();
                    lblCard3Caption.Text = "Спроб проходження тестів";
                    lblHelp.Text =
                        "Що можна зробити:\r\n\r\n" +
                        "•  «Курси, модулі, тести» — створення та редагування курсів, модулів, уроків " +
                        "(з форматуванням тексту) і тестів трьох типів.\r\n\r\n" +
                        "•  «Результати студентів» — перегляд усіх спроб: бали, відсоток, статус " +
                        "і відповідь на кожне питання.\r\n\r\n" +
                        "•  «Звіти в Excel» — детальний звіт про спробу або зведена відомість курсу.\r\n\r\n" +
                        "Правило доступу: модулі відкриваються студентам по черзі. Наступний модуль " +
                        "стає доступним, коли тест попереднього складено щонайменше на 70%.";
                }
                else
                {
                    var stats = _progressService.GetStudentStats(Session.UserId);
                    lblCard1Value.Text = stats.EnrolledCoursesCount.ToString();
                    lblCard1Caption.Text = "Моїх курсів";
                    lblCard2Value.Text = stats.PassedTestsCount.ToString();
                    lblCard2Caption.Text = "Складених тестів";
                    lblCard3Value.Text = stats.AveragePercent.ToString("0.#") + "%";
                    lblCard3Caption.Text = "Середній результат спроб";
                    lblHelp.Text =
                        "Як навчатися:\r\n\r\n" +
                        "1.  Відкрийте «Каталог курсів» і запишіться на курс.\r\n\r\n" +
                        "2.  У розділі «Мій прогрес і навчання» оберіть модуль, вивчіть його уроки " +
                        "і пройдіть тест.\r\n\r\n" +
                        "3.  Якщо ви набрали 70% або більше — відкриється наступний модуль. " +
                        "Якщо менше — повторіть матеріал і пройдіть тест ще раз.\r\n\r\n" +
                        "4.  Усі ваші спроби та відповіді доступні в розділі «Мої результати».";
                }
            });
        }

        private void btnCourses_Click(object sender, EventArgs e)
        {
            using (var form = new CoursesForm())
                form.ShowDialog(this);
            RefreshDashboard();
        }

        private void btnCatalog_Click(object sender, EventArgs e)
        {
            using (var form = new CoursesForm())
                form.ShowDialog(this);
            RefreshDashboard();
        }

        private void btnProgress_Click(object sender, EventArgs e)
        {
            using (var form = new StudentProgressForm(null))
                form.ShowDialog(this);
            RefreshDashboard();
        }

        private void btnResults_Click(object sender, EventArgs e)
        {
            using (var form = new ResultsForm())
                form.ShowDialog(this);
            RefreshDashboard();
        }

        private void btnMyResults_Click(object sender, EventArgs e)
        {
            using (var form = new ResultsForm())
                form.ShowDialog(this);
            RefreshDashboard();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            using (var form = new ReportsForm())
                form.ShowDialog(this);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (UiHelper.Confirm("Вийти з облікового запису?"))
            {
                LogoutRequested = true;
                Close();
            }
        }
    }
}
