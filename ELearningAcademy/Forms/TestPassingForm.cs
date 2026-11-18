using ELearningAcademy.Helpers;
using ELearningAcademy.Models;
using ELearningAcademy.Models.Dto;
using ELearningAcademy.Services;

namespace ELearningAcademy.Forms
{
    public partial class TestPassingForm : Form
    {
        private readonly int _moduleId;
        private StudentTestView _test;
        private int _index;
        private DateTime _startedAt;
        private bool _submitted;

        private readonly Dictionary<int, StudentAnswerInput> _answers = new Dictionary<int, StudentAnswerInput>();

        public AttemptResult Result { get; private set; }

        public TestPassingForm(int moduleId)
        {
            InitializeComponent();
            UiTheme.Apply(this);
            _moduleId = moduleId;
        }

        private void TestPassingForm_Load(object sender, EventArgs e)
        {
            bool ok = UiHelper.Run(() => _test = new TestService().GetTestForStudent(Session.UserId, _moduleId));
            if (!ok)
            {
                BeginInvoke(new Action(Close));
                return;
            }

            Text = "Тест — " + _test.Title;
            lblTestTitle.Text = _test.Title;
            int maxScore = _test.Questions.Sum(q => q.Points);
            lblModule.Text = $"Модуль: {_test.ModuleTitle}   ·   Питань: {_test.Questions.Count}   ·   " +
                             $"Максимум: {maxScore} б.   ·   Прохідний бал: 70%";
            progressBar.Minimum = 0;
            progressBar.Maximum = _test.Questions.Count;
            _startedAt = DateTime.Now;

            if (!string.IsNullOrWhiteSpace(_test.Description))
                UiHelper.ShowInfo(_test.Description);

            ShowQuestion(0);
        }

        private void ShowQuestion(int index)
        {
            _index = index;
            StudentQuestionView q = _test.Questions[index];
            int width = Math.Max(300, pnlQuestion.ClientSize.Width - 60);

            lblQuestionText.MaximumSize = new Size(width, 0);
            lblQuestionText.Text = $"{q.Number}. {q.Text}";
            lblPointsInfo.Top = lblQuestionText.Bottom + 8;
            lblPointsInfo.Text = $"{QuestionTypeNames.GetHint(q.Type)}   ·   Бали: {q.Points}";

            int nextTop = lblPointsInfo.Bottom + 12;
            if (q.ImageData != null && q.ImageData.Length > 0)
            {
                ImageHelper.ShowInPictureBox(picQuestion, q.ImageData);
                picQuestion.Top = nextTop;
                picQuestion.Visible = true;
                nextTop = picQuestion.Bottom + 12;
            }
            else
            {
                picQuestion.Visible = false;
                ImageHelper.ShowInPictureBox(picQuestion, null);
            }

            pnlAnswers.Top = nextTop;
            pnlAnswers.Width = width;
            pnlAnswers.Height = Math.Max(150, pnlQuestion.ClientSize.Height - nextTop - 15);

            BuildAnswerControls(q, width);

            lblProgress.Text = $"Питання {index + 1} з {_test.Questions.Count}";
            progressBar.Value = index + 1;
            btnPrev.Enabled = index > 0;
            btnNext.Enabled = index < _test.Questions.Count - 1;
        }

        private void BuildAnswerControls(StudentQuestionView q, int width)
        {
            var oldControls = pnlAnswers.Controls.Cast<Control>().ToList();
            pnlAnswers.Controls.Clear();
            foreach (Control c in oldControls)
                c.Dispose();

            _answers.TryGetValue(q.Id, out StudentAnswerInput saved);
            var maxSize = new Size(width - 40, 0);
            var margin = new Padding(4, 6, 4, 6);

            switch (q.Type)
            {
                case QuestionType.SingleChoice:
                    foreach (StudentOptionView option in q.Options)
                    {
                        pnlAnswers.Controls.Add(new RadioButton
                        {
                            Text = option.Text,
                            Tag = option.Id,
                            AutoSize = true,
                            MaximumSize = maxSize,
                            Margin = margin,
                            Checked = saved != null && saved.SelectedOptionIds.Contains(option.Id)
                        });
                    }
                    break;

                case QuestionType.MultipleChoice:
                    foreach (StudentOptionView option in q.Options)
                    {
                        pnlAnswers.Controls.Add(new CheckBox
                        {
                            Text = option.Text,
                            Tag = option.Id,
                            AutoSize = true,
                            MaximumSize = maxSize,
                            Margin = margin,
                            Checked = saved != null && saved.SelectedOptionIds.Contains(option.Id)
                        });
                    }
                    break;

                case QuestionType.TextInput:
                    pnlAnswers.Controls.Add(new Label
                    {
                        Text = "Ваша відповідь:",
                        AutoSize = true,
                        Margin = margin
                    });
                    var textBox = new TextBox
                    {
                        Width = Math.Min(500, width - 40),
                        MaxLength = 1000,
                        Margin = margin,
                        Text = saved?.TextAnswer ?? string.Empty
                    };
                    pnlAnswers.Controls.Add(textBox);
                    textBox.Focus();
                    break;
            }
        }

        private void SaveCurrentAnswer()
        {
            if (_test == null) return;
            StudentQuestionView q = _test.Questions[_index];
            var input = new StudentAnswerInput { QuestionId = q.Id };

            foreach (Control control in pnlAnswers.Controls)
            {
                if (control is RadioButton rb && rb.Checked)
                    input.SelectedOptionIds.Add((int)rb.Tag);
                else if (control is CheckBox cb && cb.Checked)
                    input.SelectedOptionIds.Add((int)cb.Tag);
                else if (control is TextBox tb)
                    input.TextAnswer = tb.Text;
            }

            if (input.IsAnswered)
                _answers[q.Id] = input;
            else
                _answers.Remove(q.Id);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            SaveCurrentAnswer();
            if (_index > 0)
                ShowQuestion(_index - 1);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            SaveCurrentAnswer();
            if (_index < _test.Questions.Count - 1)
                ShowQuestion(_index + 1);
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            SaveCurrentAnswer();

            int unanswered = _test.Questions.Count - _answers.Count;
            string question = unanswered > 0
                ? $"Ви не відповіли на питань: {unanswered}. Вони будуть зараховані як неправильні.\n\nЗавершити тест?"
                : "Завершити тест і надіслати відповіді на перевірку?";
            if (!UiHelper.Confirm(question))
                return;

            bool ok = UiHelper.Run(() =>
            {
                Result = new TestService().SubmitAttempt(
                    Session.UserId, _test.TestId, _answers.Values.ToList(), _startedAt);
            });
            if (!ok) return;

            _submitted = true;
            ShowResultMessage(Result);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ShowResultMessage(AttemptResult r)
        {
            string text =
                $"Результат тесту «{_test.Title}»\n\n" +
                $"Набрано балів: {r.ScoreObtained} з {r.MaxScore}\n" +
                $"Відсоток: {r.Percent:0.##}%\n" +
                $"Статус: {(r.IsPassed ? "СКЛАДЕНО" : "НЕ СКЛАДЕНО")}\n\n";

            if (r.IsPassed)
            {
                text += r.NextModuleTitle != null
                    ? $"Вітаємо! Наступний модуль «{r.NextModuleTitle}» розблоковано."
                    : "Вітаємо! Це був останній модуль курсу.";
            }
            else
            {
                text += "Для розблокування наступного модуля потрібно набрати щонайменше 70%.\n" +
                        "Повторіть матеріал уроків і пройдіть тест ще раз.";
            }

            MessageBox.Show(text, "Результат тестування", MessageBoxButtons.OK,
                r.IsPassed ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }

        private void TestPassingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_submitted || _test == null) return;

            SaveCurrentAnswer();
            if (_answers.Count > 0 &&
                !UiHelper.Confirm("Вийти з тесту? Відповіді не будуть збережені, спроба не зарахується."))
            {
                e.Cancel = true;
            }
        }
    }
}
