using ClosedXML.Excel;
using ELearningAcademy.Models.Dto;

namespace ELearningAcademy.Reports
{
    public class ExcelReportGenerator
    {
        private static readonly XLColor HeaderColor = XLColor.FromArgb(30, 41, 59);
        private static readonly XLColor TitleColor = XLColor.FromArgb(37, 99, 235);
        private static readonly XLColor CorrectColor = XLColor.FromArgb(220, 252, 231);
        private static readonly XLColor WrongColor = XLColor.FromArgb(254, 226, 226);
        private static readonly XLColor LabelColor = XLColor.FromArgb(241, 245, 249);
        private static readonly XLColor PassedText = XLColor.FromArgb(21, 128, 61);
        private static readonly XLColor FailedText = XLColor.FromArgb(185, 28, 28);

        public void ExportAttemptReport(AttemptDetails details, string filePath)
        {
            if (details == null) throw new ArgumentNullException(nameof(details));

            using (var workbook = new XLWorkbook())
            {
                IXLWorksheet ws = workbook.Worksheets.Add("Звіт");
                const int lastColumn = 8;

                ws.Cell(1, 1).Value = "Звіт про проходження тесту — E-Learning Academy";
                IXLRange title = ws.Range(1, 1, 1, lastColumn);
                title.Merge();
                title.Style.Font.Bold = true;
                title.Style.Font.FontSize = 16;
                title.Style.Font.FontColor = XLColor.White;
                title.Style.Fill.BackgroundColor = TitleColor;
                title.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                title.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Row(1).Height = 30;

                int row = 3;
                WriteInfoRow(ws, row++, "ПІБ студента", details.StudentName, lastColumn);
                WriteInfoRow(ws, row++, "Курс", details.CourseTitle, lastColumn);
                WriteInfoRow(ws, row++, "Модуль", details.ModuleTitle, lastColumn);
                WriteInfoRow(ws, row++, "Тест", details.TestTitle, lastColumn);
                WriteInfoRow(ws, row++, "Дата проходження", details.FinishedAt.ToString("dd.MM.yyyy HH:mm"), lastColumn);
                TimeSpan duration = details.FinishedAt - details.StartedAt;
                if (duration < TimeSpan.Zero) duration = TimeSpan.Zero;
                WriteInfoRow(ws, row++, "Тривалість", $"{(int)duration.TotalMinutes} хв {duration.Seconds} с", lastColumn);

                row++;
                int headerRow = row;
                string[] headers =
                {
                    "№", "Питання", "Тип питання", "Відповідь студента",
                    "Правильна відповідь", "Отримано балів", "Макс. балів", "Результат"
                };
                for (int c = 0; c < headers.Length; c++)
                    ws.Cell(headerRow, c + 1).Value = headers[c];

                IXLRange headerRange = ws.Range(headerRow, 1, headerRow, lastColumn);
                headerRange.Style.Font.Bold = true;
                headerRange.Style.Font.FontColor = XLColor.White;
                headerRange.Style.Fill.BackgroundColor = HeaderColor;
                headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                headerRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                headerRange.Style.Alignment.WrapText = true;
                ws.Row(headerRow).Height = 32;

                row = headerRow + 1;
                foreach (AnswerDetail answer in details.Answers)
                {
                    ws.Cell(row, 1).Value = answer.Number;
                    ws.Cell(row, 2).Value = answer.QuestionText;
                    ws.Cell(row, 3).Value = answer.QuestionTypeName;
                    ws.Cell(row, 4).Value = answer.StudentAnswerText;
                    ws.Cell(row, 5).Value = answer.CorrectAnswerText;
                    ws.Cell(row, 6).Value = answer.PointsAwarded;
                    ws.Cell(row, 7).Value = answer.MaxPoints;
                    ws.Cell(row, 8).Value = answer.IsCorrect ? "✔ Правильно" : "✘ Неправильно";

                    IXLRange dataRange = ws.Range(row, 1, row, lastColumn);
                    dataRange.Style.Fill.BackgroundColor = answer.IsCorrect ? CorrectColor : WrongColor;
                    dataRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Top;
                    dataRange.Style.Alignment.WrapText = true;
                    ws.Cell(row, 8).Style.Font.Bold = true;
                    ws.Cell(row, 8).Style.Font.FontColor = answer.IsCorrect ? PassedText : FailedText;
                    row++;
                }

                int lastDataRow = row - 1;
                IXLRange table = ws.Range(headerRow, 1, Math.Max(headerRow, lastDataRow), lastColumn);
                table.Style.Border.OutsideBorder = XLBorderStyleValues.Medium;
                table.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                ws.Range(headerRow + 1, 1, Math.Max(headerRow + 1, lastDataRow), 1)
                    .Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Range(headerRow + 1, 6, Math.Max(headerRow + 1, lastDataRow), 7)
                    .Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                row++;
                WriteSummaryRow(ws, row++, "Загальна кількість балів", $"{details.ScoreObtained} з {details.MaxScore}");

                ws.Cell(row, 1).Value = "Підсумковий відсоток";
                ws.Range(row, 1, row, 3).Merge();
                ws.Cell(row, 4).Value = (double)details.Percent / 100.0;
                ws.Cell(row, 4).Style.NumberFormat.Format = "0.00%";
                StyleSummary(ws, row);
                row++;

                WriteSummaryRow(ws, row, "Статус складання тесту", details.IsPassed ? "СКЛАДЕНО" : "НЕ СКЛАДЕНО");
                ws.Cell(row, 4).Style.Font.FontColor = details.IsPassed ? PassedText : FailedText;
                ws.Cell(row, 4).Style.Fill.BackgroundColor = details.IsPassed ? CorrectColor : WrongColor;
                row++;

                ws.Cell(row, 1).Value = "Прохідний бал: 70%. Відсоток = (отримані бали / максимальні бали) × 100%.";
                ws.Range(row, 1, row, lastColumn).Merge();
                ws.Cell(row, 1).Style.Font.Italic = true;
                ws.Cell(row, 1).Style.Font.FontColor = XLColor.Gray;

                ws.Column(1).Width = 6;
                ws.Column(2).Width = 45;
                ws.Column(3).Width = 22;
                ws.Column(4).Width = 30;
                ws.Column(5).Width = 30;
                ws.Column(6).Width = 12;
                ws.Column(7).Width = 11;
                ws.Column(8).Width = 16;

                ws.SheetView.FreezeRows(headerRow);
                ws.PageSetup.PageOrientation = XLPageOrientation.Landscape;
                ws.PageSetup.FitToPages(1, 0);

                workbook.SaveAs(filePath);
            }
        }

        public void ExportCourseSummary(string courseTitle, List<AttemptRow> attempts, string filePath)
        {
            using (var workbook = new XLWorkbook())
            {
                IXLWorksheet ws = workbook.Worksheets.Add("Зведена відомість");
                const int lastColumn = 8;

                ws.Cell(1, 1).Value = "Зведена відомість курсу «" + courseTitle + "»";
                IXLRange title = ws.Range(1, 1, 1, lastColumn);
                title.Merge();
                title.Style.Font.Bold = true;
                title.Style.Font.FontSize = 16;
                title.Style.Font.FontColor = XLColor.White;
                title.Style.Fill.BackgroundColor = TitleColor;
                title.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Row(1).Height = 30;

                ws.Cell(2, 1).Value = "Сформовано: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm");
                ws.Range(2, 1, 2, lastColumn).Merge();
                ws.Cell(2, 1).Style.Font.Italic = true;

                int headerRow = 4;
                string[] headers = { "ПІБ студента", "Модуль", "Тест", "Дата", "Бали", "Макс. балів", "Відсоток", "Статус" };
                for (int c = 0; c < headers.Length; c++)
                    ws.Cell(headerRow, c + 1).Value = headers[c];

                IXLRange header = ws.Range(headerRow, 1, headerRow, lastColumn);
                header.Style.Font.Bold = true;
                header.Style.Font.FontColor = XLColor.White;
                header.Style.Fill.BackgroundColor = HeaderColor;
                header.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                int row = headerRow + 1;
                foreach (AttemptRow a in attempts.OrderBy(x => x.StudentName).ThenBy(x => x.FinishedAt))
                {
                    ws.Cell(row, 1).Value = a.StudentName;
                    ws.Cell(row, 2).Value = a.ModuleTitle;
                    ws.Cell(row, 3).Value = a.TestTitle;
                    ws.Cell(row, 4).Value = a.FinishedAt;
                    ws.Cell(row, 4).Style.NumberFormat.Format = "dd.MM.yyyy HH:mm";
                    ws.Cell(row, 5).Value = a.ScoreObtained;
                    ws.Cell(row, 6).Value = a.MaxScore;
                    ws.Cell(row, 7).Value = (double)a.Percent / 100.0;
                    ws.Cell(row, 7).Style.NumberFormat.Format = "0.00%";
                    ws.Cell(row, 8).Value = a.IsPassed ? "Складено" : "Не складено";
                    ws.Cell(row, 8).Style.Font.Bold = true;
                    ws.Cell(row, 8).Style.Font.FontColor = a.IsPassed ? PassedText : FailedText;
                    ws.Range(row, 1, row, lastColumn).Style.Fill.BackgroundColor = a.IsPassed ? CorrectColor : WrongColor;
                    row++;
                }

                int lastRow = Math.Max(headerRow, row - 1);
                IXLRange table = ws.Range(headerRow, 1, lastRow, lastColumn);
                table.Style.Border.OutsideBorder = XLBorderStyleValues.Medium;
                table.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                row++;
                int total = attempts.Count;
                int passed = attempts.Count(a => a.IsPassed);
                WriteSummaryRow(ws, row++, "Усього спроб", total.ToString());
                WriteSummaryRow(ws, row++, "З них складено", passed.ToString());
                ws.Cell(row, 1).Value = "Середній відсоток";
                ws.Range(row, 1, row, 3).Merge();
                ws.Cell(row, 4).Value = total > 0 ? (double)attempts.Average(a => a.Percent) / 100.0 : 0.0;
                ws.Cell(row, 4).Style.NumberFormat.Format = "0.00%";
                StyleSummary(ws, row);

                ws.Column(1).Width = 32;
                ws.Column(2).Width = 32;
                ws.Column(3).Width = 30;
                ws.Column(4).Width = 18;
                ws.Column(5).Width = 9;
                ws.Column(6).Width = 12;
                ws.Column(7).Width = 11;
                ws.Column(8).Width = 14;
                ws.SheetView.FreezeRows(headerRow);

                workbook.SaveAs(filePath);
            }
        }

        private static void WriteInfoRow(IXLWorksheet ws, int row, string label, string value, int lastColumn)
        {
            ws.Cell(row, 1).Value = label;
            ws.Range(row, 1, row, 2).Merge();
            ws.Range(row, 1, row, 2).Style.Font.Bold = true;
            ws.Range(row, 1, row, 2).Style.Fill.BackgroundColor = LabelColor;

            ws.Cell(row, 3).Value = value;
            ws.Range(row, 3, row, lastColumn).Merge();
            ws.Range(row, 1, row, lastColumn).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        }

        private static void WriteSummaryRow(IXLWorksheet ws, int row, string label, string value)
        {
            ws.Cell(row, 1).Value = label;
            ws.Range(row, 1, row, 3).Merge();
            ws.Cell(row, 4).Value = value;
            StyleSummary(ws, row);
        }

        private static void StyleSummary(IXLWorksheet ws, int row)
        {
            IXLRange range = ws.Range(row, 1, row, 4);
            range.Style.Font.Bold = true;
            range.Style.Font.FontSize = 12;
            range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            range.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
            ws.Range(row, 1, row, 3).Style.Fill.BackgroundColor = LabelColor;
            ws.Cell(row, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        }
    }
}
