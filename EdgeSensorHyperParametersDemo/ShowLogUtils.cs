using System.Drawing;
using CCWin.SkinControl;

namespace EdgeSensorHyperParametersDemo
{
    public static class ShowLogUtils
    {
        public static void ShowLog(this SkinChatRichTextBox skrtb, string log, Color color)
        {
            skrtb.Focus();
            int textlen = skrtb.TextLength;
            skrtb.AppendText(">>> " + log + "\r\n");
            skrtb.Select(textlen, skrtb.TextLength);
            skrtb.SelectionColor = color;
            skrtb.Select(skrtb.TextLength, skrtb.TextLength);
            skrtb.ScrollToCaret();
        }
        public static void ShowLog(this SkinChatRichTextBox skrtb, string log)
        {
            skrtb.Focus();
            skrtb.AppendText(">>> " + log + "\r\n");
            skrtb.Select(skrtb.TextLength, skrtb.TextLength);
            skrtb.ScrollToCaret();
        }
    }
}