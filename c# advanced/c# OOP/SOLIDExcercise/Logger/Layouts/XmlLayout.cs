using System;
using System.Text;

namespace Logger
{
    class XmlLayout : ILayout
    {
        private string Layout()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<log>");
            sb.AppendLine("    <date>{0}</date>");
            sb.AppendLine("    <level>{1}</level>");
            sb.AppendLine("    <message>{2}</message>");
            sb.AppendLine("</log>");
            return sb.ToString().Trim();
        }
        public string LayoutFormat => Layout();
    }
}
