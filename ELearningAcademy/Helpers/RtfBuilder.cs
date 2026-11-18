using System.Text;

namespace ELearningAcademy.Helpers
{
    public class RtfBuilder
    {
        private readonly StringBuilder _sb = new StringBuilder();
        private bool _paragraphOpen;

        public RtfBuilder()
        {
            _sb.Append(@"{\rtf1\ansi\deff0{\fonttbl{\f0\fswiss Segoe UI;}{\f1\fmodern Consolas;}}");
            _sb.Append(@"\viewkind4\uc1\pard\f0\fs22 ");
        }

        public RtfBuilder Heading(string text)
        {
            CloseParagraph();
            _sb.Append(@"\pard\sb120\sa120\b\fs32 ").Append(Escape(text)).Append(@"\b0\fs22\par").AppendLine();
            return this;
        }

        public RtfBuilder SubHeading(string text)
        {
            CloseParagraph();
            _sb.Append(@"\pard\sb100\sa80\b\fs26 ").Append(Escape(text)).Append(@"\b0\fs22\par").AppendLine();
            return this;
        }

        public RtfBuilder Paragraph(string text)
        {
            return Text(text).EndParagraph();
        }

        public RtfBuilder Bullet(string text)
        {
            CloseParagraph();
            _sb.Append(@"\pard\fi-240\li480\sa60 ").Append(Escape("• " + text)).Append(@"\par").AppendLine();
            return this;
        }

        public RtfBuilder Code(string code)
        {
            CloseParagraph();
            _sb.Append(@"\pard\li480\sa40\f1\fs20 ").Append(Escape(code)).Append(@"\f0\fs22\par").AppendLine();
            return this;
        }

        public RtfBuilder Text(string text) { Open(); _sb.Append(Escape(text)); return this; }
        public RtfBuilder Bold(string text) { Open(); _sb.Append(@"{\b ").Append(Escape(text)).Append('}'); return this; }
        public RtfBuilder Italic(string text) { Open(); _sb.Append(@"{\i ").Append(Escape(text)).Append('}'); return this; }
        public RtfBuilder Underline(string text) { Open(); _sb.Append(@"{\ul ").Append(Escape(text)).Append('}'); return this; }

        public RtfBuilder EndParagraph()
        {
            if (_paragraphOpen)
            {
                _sb.Append(@"\par").AppendLine();
                _paragraphOpen = false;
            }
            return this;
        }

        public string Build()
        {
            CloseParagraph();
            return _sb.ToString() + "}";
        }

        private void Open()
        {
            if (!_paragraphOpen)
            {
                _sb.Append(@"\pard\sa100\fs22 ");
                _paragraphOpen = true;
            }
        }

        private void CloseParagraph() => EndParagraph();

        public static string Escape(string text)
        {
            if (string.IsNullOrEmpty(text)) return string.Empty;

            var sb = new StringBuilder(text.Length * 2);
            foreach (char c in text)
            {
                switch (c)
                {
                    case '\\': sb.Append(@"\\"); break;
                    case '{': sb.Append(@"\{"); break;
                    case '}': sb.Append(@"\}"); break;
                    case '\n': sb.Append(@"\line "); break;
                    case '\r': break;
                    case '\t': sb.Append(@"\tab "); break;
                    default:
                        if (c > 127)
                            sb.Append(@"\u").Append(((short)c).ToString()).Append('?');
                        else
                            sb.Append(c);
                        break;
                }
            }
            return sb.ToString();
        }
    }
}
