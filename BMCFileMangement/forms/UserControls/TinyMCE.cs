using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Windows.Controls;

namespace WinFormTinyMCE
{
  public partial class TinyMCE : System.Windows.Forms.UserControl
    {
        public TinyMCE()
        {
            InitializeComponent();
            webBrowserControl.DocumentCompleted += WebBrowser_DocumentCompleted;
        }
        private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.AbsolutePath == webBrowserControl.Url.AbsolutePath)
            {
                //webBrowserControl.Document.InvokeScript("SetContent", new object[] {  });
            }
        }
        public string HtmlContent
        {
            get
            {
                string content = string.Empty;
                if (webBrowserControl != null && webBrowserControl.Document != null)
                {
                    object html = webBrowserControl.Document.InvokeScript("GetContent");
                    content = html as string;
                }
                return content;
            }
            set
            {
                if (webBrowserControl.Document != null)
                {
                    webBrowserControl.Document.InvokeScript("SetContent", new object[] { value });
                }
            }
        }

        public void CreateEditor()
        {
            // Check if the main script file exist being used by the HTML page
            if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"tinymce\jscripts\tiny_mce\tiny_mce.js")))
            {
                webBrowserControl.Url = new Uri(@"file:///" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tinymce.htm").Replace('\\', '/'));
            }
            else
            {
                MessageBox.Show("Could not find the tinyMCE script directory. Please ensure the directory is in the same location as tinymce.htm", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
  }
}
