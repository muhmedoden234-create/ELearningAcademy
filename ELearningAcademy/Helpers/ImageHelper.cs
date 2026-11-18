using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace ELearningAcademy.Helpers
{
    public static class ImageHelper
    {
        public const int MaxImageBytes = 900 * 1024;

        public static byte[] LoadImageFile(string path)
        {
            var info = new FileInfo(path);
            if (!info.Exists)
                throw new BusinessException("Файл не знайдено.");
            if (info.Length > MaxImageBytes)
                throw new BusinessException("Розмір зображення перевищує 900 КБ. Оберіть менший файл.");

            byte[] bytes = File.ReadAllBytes(path);

            try
            {
                using (Image test = BytesToImage(bytes))
                {
                    if (test == null)
                        throw new BusinessException("Файл порожній.");
                }
            }
            catch (ArgumentException)
            {
                throw new BusinessException("Обраний файл не є підтримуваним зображенням.");
            }

            return bytes;
        }

        public static Image BytesToImage(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0)
                return null;

            using (var stream = new MemoryStream(bytes))
            using (Image image = Image.FromStream(stream))
            {
                return new Bitmap(image);
            }
        }

        public static byte[] ImageToPngBytes(Image image)
        {
            using (var stream = new MemoryStream())
            {
                image.Save(stream, ImageFormat.Png);
                return stream.ToArray();
            }
        }

        public static void ShowInPictureBox(PictureBox pictureBox, byte[] bytes)
        {
            Image old = pictureBox.Image;
            pictureBox.Image = BytesToImage(bytes);
            old?.Dispose();
        }

        public static byte[] CreateIfStatementDiagram()
        {
            using (var bmp = new Bitmap(480, 290))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                using (var font = new Font("Segoe UI", 10F))
                using (var bold = new Font("Segoe UI", 11F, FontStyle.Bold))
                using (var pen = new Pen(Color.FromArgb(30, 41, 59), 2F))
                using (var boxBrush = new SolidBrush(Color.FromArgb(219, 234, 254)))
                using (var condBrush = new SolidBrush(Color.FromArgb(254, 243, 199)))
                using (var textBrush = new SolidBrush(Color.FromArgb(30, 41, 59)))
                using (var center = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                    g.Clear(Color.White);

                    var start = new Rectangle(170, 15, 140, 40);
                    g.FillRectangle(boxBrush, start);
                    g.DrawRectangle(pen, start);
                    g.DrawString("int x = 5;", bold, textBrush, start, center);

                    DrawArrow(g, pen, 240, 55, 240, 85);

                    Point[] diamond =
                    {
                        new Point(240, 85), new Point(320, 130), new Point(240, 175), new Point(160, 130)
                    };
                    g.FillPolygon(condBrush, diamond);
                    g.DrawPolygon(pen, diamond);
                    g.DrawString("x > 3 ?", bold, textBrush, new Rectangle(160, 85, 160, 90), center);

                    g.DrawLine(pen, 160, 130, 90, 130);
                    DrawArrow(g, pen, 90, 130, 90, 205);
                    g.DrawString("Так", font, textBrush, 105, 106);
                    var yesBox = new Rectangle(15, 205, 150, 55);
                    g.FillRectangle(boxBrush, yesBox);
                    g.DrawRectangle(pen, yesBox);
                    g.DrawString("Вивести\n\"Більше\"", font, textBrush, yesBox, center);

                    g.DrawLine(pen, 320, 130, 390, 130);
                    DrawArrow(g, pen, 390, 130, 390, 205);
                    g.DrawString("Ні", font, textBrush, 345, 106);
                    var noBox = new Rectangle(300, 205, 170, 55);
                    g.FillRectangle(boxBrush, noBox);
                    g.DrawRectangle(pen, noBox);
                    g.DrawString("Вивести \"Менше\nабо дорівнює\"", font, textBrush, noBox, center);
                }
                return ImageToPngBytes(bmp);
            }
        }

        private static void DrawArrow(Graphics g, Pen pen, int x1, int y1, int x2, int y2)
        {
            using (var arrowPen = (Pen)pen.Clone())
            {
                arrowPen.CustomEndCap = new AdjustableArrowCap(5, 5);
                g.DrawLine(arrowPen, x1, y1, x2, y2);
            }
        }
    }
}
