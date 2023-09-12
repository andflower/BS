using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BS.View;
using BS.Model;

namespace BS
{
    public partial class frmMain : Sample
    {
        public frmMain()
        {
            InitializeComponent();
        }

        // BlurBackground 적용 1) 멤버 변수
        static frmMain _obj;

        // BlurBackground 적용 2) 프로퍼티
        public static frmMain Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new frmMain();
                }
                return _obj;
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // BlurBackground 적용 3) 멤버 변수에 현재 form할당
            _obj = this;
            btnMax.PerformClick();
            //paAdd.BringToFront();
            paAdd.Visible = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            paAdd.Visible = true;
        }

        private void paLeft_MouseEnter(object sender, EventArgs e)
        {
            paAdd.Visible = false;
        }

        private void AddControls(Form F)
        {
            paMain.Controls.Clear();
            F.TopLevel = false;
            F.Dock = DockStyle.Fill;
            paMain.Controls.Add(F);
            F.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            AddControls(new frmUser());
        }
    }
}
