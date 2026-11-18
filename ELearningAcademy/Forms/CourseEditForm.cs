using ELearningAcademy.Helpers;
using ELearningAcademy.Models;
using ELearningAcademy.Services;

namespace ELearningAcademy.Forms
{
    public partial class CourseEditForm : Form
    {
        private readonly Course _course;

        public int SavedCourseId { get; private set; }

        public CourseEditForm(Course course)
        {
            InitializeComponent();
            UiTheme.Apply(this);

            _course = course;
            if (course != null)
            {
                Text = "Редагування курсу";
                lblHeader.Text = "Редагування курсу";
                txtTitle.Text = course.Title;
                txtDescription.Text = course.Description;
                chkPublished.Checked = course.IsPublished;
            }
            else
            {
                Text = "Новий курс";
                chkPublished.Checked = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var data = new Course
            {
                Id = _course?.Id ?? 0,
                Title = txtTitle.Text,
                Description = txtDescription.Text,
                IsPublished = chkPublished.Checked
            };

            bool ok = UiHelper.Run(() => SavedCourseId = new CourseService().SaveCourse(data, Session.UserId));
            if (ok)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
