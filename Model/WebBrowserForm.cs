using CefSharp.WinForms;
using CefSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using static BS.Model.frmCustomerAdd;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Threading;
using Guna.UI2.WinForms;
using CefSharp.DevTools.DOM;

namespace BS.Model
{
    public partial class WebBrowserForm : SampleAdd
    {
        ChromiumWebBrowser webBrowser;
        public WebBrowserForm()
        {
            InitializeComponent();

            // bug
            this.btnDel.Location = new System.Drawing.Point(761, 20);

            foreach (ChromiumWebBrowser item in this.Controls.OfType<ChromiumWebBrowser>())
            {
                this.Controls.Remove(item);
                item.Dispose();
            }

            webBrowser = new ChromiumWebBrowser("http://localhost:61000/index.html");
            webBrowser.Dock = DockStyle.Fill;
            webBrowser.JavascriptObjectRepository.Settings.LegacyBindingEnabled = true;
            webBrowser.JavascriptObjectRepository.Register("cAPI", new ChromeAPI(this), false, BindingOptions.DefaultBinder);
            paAddressSearch.Controls.Add(webBrowser);

            this.FormClosing += WebBrowserForm_FormClosing;
        }

        class ChromeAPI
        {
            WebBrowserForm frm;
            public ChromeAPI(WebBrowserForm frm)
            {
                this.frm = frm;
            }
            public void getAddress(object obj)
            {
                Dictionary<string, object> dict = obj as Dictionary<string, object>;
                Array array = dict.Values.ToArray();

                frm.txtPostNumber.Text = ((object[])array)[5].ToString();

                frm.txtAddress.Text = ((object[])array)[3].ToString();
            }
        }

        public override void btnSave_Click(object sender, EventArgs e)
        {
            #region MessageBox setting
            Guna2MessageDialog dialog = new Guna2MessageDialog()
            {
                //Parent = ,
                Style = MessageDialogStyle.Dark,
                Caption = "결제 시스템",
                Icon = MessageDialogIcon.None,
            };
            #endregion

            if (txtPostNumber.Text != "" && txtAddress.Text != "" && txtDetailAddress.Text != "")
            {
                MainClass.jusoString = $"({txtPostNumber.Text}) {txtAddress.Text} {txtDetailAddress.Text}";
                this.Close();
            }
            else
            {
                dialog.Show("주소를 조회하여 주세요.\n상세주소 입력 필수");
            }
        }

        private void WebBrowserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MainClass.jusoString == "")
            {
                MainClass.jusoString = MainClass.oldjusoString;
            }
        }

        private readonly string mode = "Close";

        private void object_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnSave_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (mode.Equals("Exit"))
                {
                    Application.Exit();
                }
                else if (mode.Equals("Close"))
                {
                    this.Close();
                }
            }
        }
    }
}
