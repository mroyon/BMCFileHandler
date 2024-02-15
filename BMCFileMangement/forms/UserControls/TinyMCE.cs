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
            
        }

        public bool checkif()
        {
            if (webBrowserControl.ReadyState == WebBrowserReadyState.Complete)
                return true;
            else
               return  false;
        }

        public void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.AbsolutePath == webBrowserControl.Url.AbsolutePath)
            {
                //webBrowserControl.Document.InvokeScript("SetContent", new object[] { "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html>\r\n<head>\r\n<title>Untitled document</title>\r\n</head>\r\n<body>\r\n<p><span>\r\n<p dir=\"ltr\" align=\"left\">(Name of Company/Person)<br />(Address)<br /><br />(Today&rsquo;s date)<br /><br /><br /><strong>Re: Request that<span style=\"font-family: MS Mincho,&sbquo;l&sbquo;r &ndash;&frac34;&rsquo;&copy;;\">　</span> my record be updated to reflect my changed name</strong><br /><br /><br /><span style=\"color: #ff0000;\">Dear XXXXX,</span><br /><br />Please change my record to reflect my new name. <br /><br />My account number is ____________________. <br />My Social Security number is _____________________.<em>(Include this only if necessary to identify you)</em><br /><br />My former name is <em>(former name)</em>. However, as of (<em>date of court order or date you decided to assume your new name)</em>, my new name is (<em>New Name). </em><br /><br /><span style=\"color: #0000ff;\">Please make modify my records with you as soon as possible. I am enclosing copy of the court order. (<em>Delete this sentence if not appropriate.) </em><br /></span><br />If there are any questions regarding the change of my name, please contact me immediately. During the day I can best be reached by <em>(fill in how you want to be reached and the hours if appropriate) <br /></em><br />Thank you for your assistance. I would appreciate written confirmation that you have acted upon my request.<br /><br /><br />Sincerely,<br /><br /><br /><br /><em>(New Name &ndash; written and typed)</em> formerly known as <em>(Former Name &ndash; written and typed)</em><br /><em>(Address)</em><br />(<em>Email)</em><br /><em>(Phone) </em><span style=\"font-size: small; font-family: Aptos;\"><span style=\"font-size: small; font-family: Aptos;\">\r\n<p dir=\"ltr\" align=\"left\">&nbsp;</p>\r\n</span></span></p>\r\n</span></p>\r\n</body>\r\n</html>" });
            }
        }

        
        private string _html;
        public string html
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
                    //webBrowserControl.Document.InvokeScript("initTinyMCE");
                    webBrowserControl.Document.InvokeScript("SetContent", new object[] { _html = value });
                }
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
            //if (webBrowserControl.Document == null)
            //{
            //    this.webBrowserControl.DocumentCompleted += WebBrowser_DocumentCompleted;
            //}
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
