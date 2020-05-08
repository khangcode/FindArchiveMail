using System;
using System.Windows.Forms;

namespace FindArchiveMail
{
    public partial class TabMailView : TabPage
    {
        public TabMailView()
        {
            InitializeComponent();
        }
        public TabMailView(MailData mail)
        {
            InitializeComponent();
            webBrowser1.DocumentText = mail.ToHtml(MyConfig.GetMailFolder());
        }

        private bool bCancel = false;
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            int i;
            for (i = 0; i < webBrowser1.Document.Links.Count; i++)
            {
                webBrowser1.Document.Links[i].Click += new HtmlElementEventHandler(LinkClick);
            }
        }
        private void LinkClick(object sender, System.EventArgs e)
        {
            bCancel = true;
            HtmlElement element = (HtmlElement)sender;
            string href = element.GetAttribute("href");
            GoNavigating(href);
        }

        public void GoNavigating(string href)
        {
            if (string.IsNullOrEmpty(href)) return;

            try
            {
                System.Diagnostics.Process.Start(href);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thong bao loi", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (bCancel)
            {
                e.Cancel = true;
                bCancel = false;
            }
        }
    }
}
