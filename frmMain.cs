using BS.Model;
using BS.View;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void btnUser_Click(object sender, EventArgs e)
        {
            var View_FrmUser = new frmUser();
            AddControls(View_FrmUser);
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            var View_FrmProduct = new frmProduct();
            AddControls(View_FrmProduct);
            
        }
    }
}
