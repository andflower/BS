using System;
using System.Reflection;
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

        private string mode = "Exit";

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
            string userName = txtUser.Text;
            string userPass = txtPass.Text;

            if (MainClass.IsValidUser(userName, userPass) == false)
            {
                guna2MessageDialog1.Show("알수 없는 아이디, 패스워드입니다.");
                MainClass.isLogined = false;
            }
            else
            {
                MainClass.isLogined = true;
                guna2MessageDialog1.Show("로그인 하였습니다.");
                this.Close();
            }

            if (ActiveControl == txtUser)
            {
                txtUser.Focus();
                txtUser.SelectionStart = txtUser.Text.Length;
                //txtPass.Select(txtPass.Text.Length, 0);
            }
            else if (ActiveControl == txtPass)
            {
                txtPass.Focus();
                txtPass.SelectionStart = txtPass.Text.Length;
                //txtPass.Select(txtPass.Text.Length, 0);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox_keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnLogin_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (mode.Equals("Exit"))
                {
                    Application.Exit();
                }
                else if (this.mode.Equals("Close"))
                {
                    this.Close();
                }
            }
        }
    }
}
