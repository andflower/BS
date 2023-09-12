using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BS
{
    public partial class frmLogin : Sample
    {
        public string copyRight;
        public string version;

        public frmLogin()
        {
            InitializeComponent();
            GetAssemblyInfo();
        }

        private void GetAssemblyInfo()
        {
            // version info
            AssemblyName assemblyName = Assembly.GetExecutingAssembly().GetName();
            Version assemblyVersion = assemblyName.Version;
            version = assemblyVersion.ToString();

            // Copyright info
            Type attType = typeof(AssemblyCopyrightAttribute);
            object[] attribues = Assembly.GetExecutingAssembly().GetCustomAttributes(attType, false);

            if (attribues.Length != 0)
            {
                AssemblyCopyrightAttribute att = (AssemblyCopyrightAttribute)attribues[0];
                copyRight = att.Copyright;
                lblVersion.Text = copyRight + " v." + version;
            }
            else
            {
                lblVersion.Text = string.Empty;
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            FrmLoad_Initialization();
        }

        private void FrmLoad_Initialization()
        {
            // Active
            ActiveControl = txtUser;
            // guna2 UI TextBox bug
            txtPass.SelectedText = string.Empty;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            frmMain frm = new frmMain();
            frm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            appExit();
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            textBox_keyDown(sender, e);
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            textBox_keyDown(sender, e);
        }

        private void textBox_keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnLogin_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                appExit();
            }
        }

        private void appExit()
        {
            Application.Exit();
        }
    }
}
