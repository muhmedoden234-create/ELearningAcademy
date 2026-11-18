using ELearningAcademy.Helpers;
using ELearningAcademy.Models;
using ELearningAcademy.Services;

namespace ELearningAcademy.Forms
{
    public partial class LessonViewForm : Form
    {
        private readonly LessonService _lessonService = new LessonService();
        private readonly int _startLessonId;
        private List<int> _lessonIds = new List<int>();
        private int _currentIndex;

        public LessonViewForm(int lessonId)
        {
            InitializeComponent();
            UiTheme.Apply(this);
            _startLessonId = lessonId;
        }

        private void LessonViewForm_Load(object sender, EventArgs e)
        {
            if (!ShowLesson(_startLessonId))
                BeginInvoke(new Action(Close));
        }

        private bool ShowLesson(int lessonId)
        {
            return UiHelper.Run(() =>
            {
                Lesson lesson = Session.IsStudent
                    ? _lessonService.GetLessonForStudent(Session.UserId, lessonId)
                    : _lessonService.GetLesson(lessonId);

                Text = "Урок — " + lesson.Title;
                lblModule.Text = "Модуль: " + lesson.Module.Title;
                lblTitle.Text = lesson.Title;
                rtbContent.Font = new Font("Segoe UI", 11F);
                UiHelper.LoadRichText(rtbContent, lesson.ContentRtf);
                rtbContent.SelectionStart = 0;
                rtbContent.ScrollToCaret();

                _lessonIds = _lessonService.GetLessonIds(lesson.ModuleId);
                _currentIndex = _lessonIds.IndexOf(lesson.Id);

                lblPosition.Text = $"Урок {_currentIndex + 1} з {_lessonIds.Count}";
                btnPrev.Enabled = _currentIndex > 0;
                btnNext.Enabled = _currentIndex >= 0 && _currentIndex < _lessonIds.Count - 1;
            });
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (_currentIndex > 0)
                ShowLesson(_lessonIds[_currentIndex - 1]);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_currentIndex < _lessonIds.Count - 1)
                ShowLesson(_lessonIds[_currentIndex + 1]);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
