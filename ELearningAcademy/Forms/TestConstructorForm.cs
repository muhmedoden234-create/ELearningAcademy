using ELearningAcademy.Helpers;
using ELearningAcademy.Models;
using ELearningAcademy.Models.Dto;
using ELearningAcademy.Services;

namespace ELearningAcademy.Forms
{
    public partial class TestConstructorForm : Form
    {
        private readonly int _moduleId;
        private readonly TestService _testService = new TestService();

        private Test _test;
        private int _currentQuestionId;
        private byte[] _currentImage;
        private string _moduleTitle = string.Empty;
        private bool _loading;

        public TestConstructorForm(int moduleId)
        {
            InitializeComponent();
            UiTheme.Apply(this);
            _moduleId = moduleId;
        }

        private QuestionType SelectedType =>
            cmbQType.SelectedItem is ComboItem item ? (QuestionType)item.Id : QuestionType.SingleChoice;

        private void TestConstructorForm_Load(object sender, EventArgs e)
        {
            cmbQType.Items.Add(new ComboItem((int)QuestionType.SingleChoice, QuestionTypeNames.GetName(QuestionType.SingleChoice)));
            cmbQType.Items.Add(new ComboItem((int)QuestionType.MultipleChoice, QuestionTypeNames.GetName(QuestionType.MultipleChoice)));
            cmbQType.Items.Add(new ComboItem((int)QuestionType.TextInput, QuestionTypeNames.GetName(QuestionType.TextInput)));

            bool ok = UiHelper.Run(() =>
            {
                CourseModule module = new ModuleService().GetModule(_moduleId);
                _moduleTitle = module.Title;
                lblHeader.Text = $"Конструктор тесту — модуль «{module.Title}»";
                Text = "Конструктор тесту — " + module.Title;
            });
            if (!ok)
            {
                BeginInvoke(new Action(Close));
                return;
            }

            LoadTest(null);
        }

        private void LoadTest(int? selectQuestionId)
        {
            Test test = null;
            if (!UiHelper.Run(() => test = _testService.GetTestForEditing(_moduleId)))
                return;

            _test = test;
            _loading = true;

            if (test == null)
            {
                txtTestTitle.Text = $"Тест до модуля «{_moduleTitle}»";
                txtTestDesc.Text = "Для переходу до наступного модуля потрібно набрати щонайменше 70%.";
                btnDeleteTest.Enabled = false;
                gridQuestions.DataSource = null;
                lblSummary.Text = "Тест ще не створено. Перевірте назву і натисніть «Зберегти тест», щоб додавати питання.";
                SetQuestionAreaEnabled(false);
                _loading = false;
                StartNewQuestion();
                return;
            }

            txtTestTitle.Text = test.Title;
            txtTestDesc.Text = test.Description;
            btnDeleteTest.Enabled = true;
            SetQuestionAreaEnabled(true);

            int number = 1;
            var rows = test.Questions.Select(q => new QuestionRow
            {
                Id = q.Id,
                Number = number++,
                Text = q.Text.Length > 70 ? q.Text.Substring(0, 70) + "…" : q.Text,
                TypeName = QuestionTypeNames.GetName(q.Type),
                Points = q.Points,
                ImageText = q.ImageData != null ? "Так" : "—"
            }).ToList();

            gridQuestions.DataSource = rows;
            lblSummary.Text = $"Питань: {rows.Count}.  Максимальний бал: {test.Questions.Sum(q => q.Points)}.  Прохідний поріг: 70%.";

            if (selectQuestionId.HasValue)
                UiHelper.SelectRow<QuestionRow>(gridQuestions, r => r.Id == selectQuestionId.Value);

            _loading = false;

            var selected = UiHelper.GetSelected<QuestionRow>(gridQuestions);
            if (selected != null)
                ShowQuestion(selected.Id);
            else
                StartNewQuestion();
        }

        private void SetQuestionAreaEnabled(bool enabled)
        {
            pnlQuestion.Enabled = enabled;
            pnlLeftButtons.Enabled = enabled;
        }

        private void btnSaveTest_Click(object sender, EventArgs e)
        {
            bool isNew = _test == null;
            if (UiHelper.Run(() => _testService.SaveTest(_moduleId, txtTestTitle.Text, txtTestDesc.Text)))
            {
                LoadTest(_currentQuestionId > 0 ? _currentQuestionId : (int?)null);
                UiHelper.ShowInfo(isNew
                    ? "Тест створено. Тепер додайте питання (праворуч)."
                    : "Назву та опис тесту збережено.");
            }
        }

        private void btnDeleteTest_Click(object sender, EventArgs e)
        {
            if (_test == null) return;
            if (!UiHelper.Confirm("Видалити тест разом з усіма питаннями та результатами студентів?\nДію неможливо скасувати."))
                return;

            if (UiHelper.Run(() => _testService.DeleteTest(_test.Id)))
                LoadTest(null);
        }

        private void gridQuestions_SelectionChanged(object sender, EventArgs e)
        {
            if (_loading) return;
            var row = UiHelper.GetSelected<QuestionRow>(gridQuestions);
            if (row != null && row.Id != _currentQuestionId)
                ShowQuestion(row.Id);
        }

        private void ShowQuestion(int questionId)
        {
            Question q = _test?.Questions.FirstOrDefault(x => x.Id == questionId);
            if (q == null) return;

            _loading = true;
            _currentQuestionId = q.Id;
            txtQText.Text = q.Text;
            SelectType(q.Type);
            numPoints.Value = Math.Max(numPoints.Minimum, Math.Min(numPoints.Maximum, q.Points));

            gridOptions.Rows.Clear();
            foreach (AnswerOption option in q.Options)
                gridOptions.Rows.Add(option.Id, option.Text, option.IsCorrect);

            _currentImage = q.ImageData;
            ImageHelper.ShowInPictureBox(picQuestion, _currentImage);

            int number = _test.Questions.IndexOf(q) + 1;
            lblEditorMode.Text = $"Редагування питання №{number}";
            lblStatus.Text = string.Empty;
            _loading = false;
            UpdateTypeUi();
        }

        private void StartNewQuestion()
        {
            _loading = true;
            gridQuestions.ClearSelection();
            gridQuestions.CurrentCell = null;
            _currentQuestionId = 0;
            txtQText.Clear();
            SelectType(QuestionType.SingleChoice);
            numPoints.Value = 1;
            gridOptions.Rows.Clear();
            for (int i = 0; i < 4; i++)
                gridOptions.Rows.Add(0, string.Empty, false);
            _currentImage = null;
            ImageHelper.ShowInPictureBox(picQuestion, null);
            lblEditorMode.Text = "Нове питання";
            lblStatus.Text = string.Empty;
            _loading = false;
            UpdateTypeUi();
        }

        private void SelectType(QuestionType type)
        {
            foreach (object item in cmbQType.Items)
            {
                if (item is ComboItem ci && ci.Id == (int)type)
                {
                    cmbQType.SelectedItem = ci;
                    return;
                }
            }
        }

        private void btnNewQuestion_Click(object sender, EventArgs e)
        {
            StartNewQuestion();
            txtQText.Focus();
        }

        private void btnDeleteQuestion_Click(object sender, EventArgs e)
        {
            if (_currentQuestionId == 0)
            {
                UiHelper.ShowWarning("Оберіть збережене питання у списку.");
                return;
            }
            if (!UiHelper.Confirm("Видалити це питання?\nВідповіді студентів на нього також будуть видалені."))
                return;

            int id = _currentQuestionId;
            if (UiHelper.Run(() => _testService.DeleteQuestion(id)))
            {
                _currentQuestionId = 0;
                LoadTest(null);
            }
        }

        private void btnSaveQuestion_Click(object sender, EventArgs e)
        {
            if (_test == null)
            {
                UiHelper.ShowWarning("Спочатку збережіть тест.");
                return;
            }

            gridOptions.EndEdit();

            var model = new QuestionEditModel
            {
                Id = _currentQuestionId,
                TestId = _test.Id,
                Text = txtQText.Text,
                Type = SelectedType,
                Points = (int)numPoints.Value,
                ImageData = _currentImage,
                Options = ReadOptions()
            };

            int savedId = 0;
            if (UiHelper.Run(() => savedId = _testService.SaveQuestion(model)))
            {
                LoadTest(savedId);
                lblStatus.Text = "Питання збережено ✓  " + DateTime.Now.ToString("HH:mm:ss");
            }
        }

        private List<OptionEditModel> ReadOptions()
        {
            var list = new List<OptionEditModel>();
            foreach (DataGridViewRow row in gridOptions.Rows)
            {
                if (row.IsNewRow) continue;

                object idValue = row.Cells[colOptionId.Index].Value;
                int id = 0;
                if (idValue is int intId)
                    id = intId;
                else if (idValue != null)
                    int.TryParse(idValue.ToString(), out id);

                list.Add(new OptionEditModel
                {
                    Id = id,
                    Text = Convert.ToString(row.Cells[colOptionText.Index].Value) ?? string.Empty,
                    IsCorrect = row.Cells[colIsCorrect.Index].Value is bool b && b
                });
            }
            return list;
        }

        private void cmbQType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_loading) return;
            UpdateTypeUi();

            if (SelectedType == QuestionType.SingleChoice)
            {
                bool found = false;
                foreach (DataGridViewRow row in gridOptions.Rows)
                {
                    if (row.IsNewRow) continue;
                    if (row.Cells[colIsCorrect.Index].Value is bool b && b)
                    {
                        if (found) row.Cells[colIsCorrect.Index].Value = false;
                        found = true;
                    }
                }
            }
        }

        private void UpdateTypeUi()
        {
            QuestionType type = SelectedType;
            colIsCorrect.Visible = type != QuestionType.TextInput;
            lblTextHint.Visible = type == QuestionType.TextInput;
            colOptionText.HeaderText = type == QuestionType.TextInput ? "Допустима правильна відповідь" : "Текст варіанта";

            switch (type)
            {
                case QuestionType.SingleChoice:
                    lblOptions.Text = "Варіанти відповідей (позначте ОДНУ правильну):";
                    break;
                case QuestionType.MultipleChoice:
                    lblOptions.Text = "Варіанти відповідей (позначте ВСІ правильні):";
                    break;
                default:
                    lblOptions.Text = "Правильні відповіді (кожен допустимий варіант — окремим рядком):";
                    break;
            }
        }

        private void gridOptions_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (gridOptions.IsCurrentCellDirty && gridOptions.CurrentCell is DataGridViewCheckBoxCell)
                gridOptions.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void gridOptions_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_loading || e.RowIndex < 0 || e.ColumnIndex != colIsCorrect.Index) return;
            if (SelectedType != QuestionType.SingleChoice) return;

            bool isChecked = gridOptions.Rows[e.RowIndex].Cells[colIsCorrect.Index].Value is bool b && b;
            if (!isChecked) return;

            foreach (DataGridViewRow row in gridOptions.Rows)
            {
                if (row.Index != e.RowIndex && !row.IsNewRow &&
                    row.Cells[colIsCorrect.Index].Value is bool other && other)
                {
                    row.Cells[colIsCorrect.Index].Value = false;
                }
            }
        }

        private void btnRemoveOption_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = gridOptions.CurrentRow;
            if (row == null || row.IsNewRow)
            {
                UiHelper.ShowWarning("Клацніть на рядок варіанта, який потрібно видалити.");
                return;
            }
            gridOptions.Rows.Remove(row);
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Title = "Оберіть зображення до питання";
                dialog.Filter = "Зображення (*.png;*.jpg;*.jpeg;*.bmp;*.gif)|*.png;*.jpg;*.jpeg;*.bmp;*.gif";
                if (dialog.ShowDialog(this) != DialogResult.OK)
                    return;

                UiHelper.Run(() =>
                {
                    byte[] bytes = ImageHelper.LoadImageFile(dialog.FileName);
                    _currentImage = bytes;
                    ImageHelper.ShowInPictureBox(picQuestion, bytes);
                    lblStatus.Text = "Зображення додано. Натисніть «Зберегти питання».";
                });
            }
        }

        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            _currentImage = null;
            ImageHelper.ShowInPictureBox(picQuestion, null);
            lblStatus.Text = "Зображення прибрано. Натисніть «Зберегти питання».";
        }
    }
}
