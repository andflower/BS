using BS.Model;
using BS.View;
using BS.webServer;
using System;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BS
{
    public partial class frmMain : Sample
    {
        public frmMain()
        {
            InitializeComponent();
            initializeWebServer();
        }

        private WebServer server = null;

        private void initializeWebServer()
        {
            // ref : https://icodebroker.tistory.com/entry/CCOMMON-HttpListener-%ED%81%B4%EB%9E%98%EC%8A%A4-%EC%9B%B9-%EC%84%9C%EB%B2%84-%EB%A7%8C%EB%93%A4%EA%B8%B0
            this.server = new WebServer();
            this.server.AddBindingAddress("http://localhost:61000/"); // 포트 번호까지 반드시 설정합니다.

            var localDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            var htmlPath = Path.Combine(localDirectory, "html");
            this.server.RootPath = htmlPath;
            this.server.ActionRequested += server_ActionRequested;
            this.FormClosing += FrmMain_FormClosing;
            this.server.Start();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.server.IsRunning)
            {
                this.server.Stop();
                this.server = null;
            }
        }

        private void server_ActionRequested(object sender, ActionRequestedEventArgs e)
        {
            e.Server.WriteDefaultAction(e.Context);
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

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            var View_FrmCustomer = new frmCustomer();
            AddControls(View_FrmCustomer);
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            var View_FrmSupplier = new frmSupplier();
            AddControls(View_FrmSupplier);
        }
    }
}
