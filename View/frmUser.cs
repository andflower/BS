using BS.Model;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BS.View
{
    public partial class frmUser : SampleView
    {
        public frmUser()
        {
            InitializeComponent();
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            // SELECT 순서는 DataGridView의 순서대로 받아야함
            string qry =
            @"SELECT 0 '구분', USER_ID, USER_NAME, USER_ACCOUNT, USER_PASSWORD, 
              USER_PHONE, USER_EMAIL FROM TABLE_USER
              WHERE USER_ACCOUNT LIKE '%" + txtSearch.Text + "%'" +
            @"OR USER_NAME LIKE '%" + txtSearch.Text + "%'" +
            @"OR USER_PHONE LIKE '%" + txtSearch.Text + "%'" +
            @"OR USER_EMAIL LIKE '%" + txtSearch.Text + "%' ORDER BY USER_ID";

            /*@"SELECT * FROM TABLE_USER
                  WHERE USER_NAME LIKE '%" + txtSearch.Text + "%'";*/

            MainClass.LoadData(qry, GunaDGVuser);
        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        public override void txtSearch_IconRightClick(object sender, EventArgs e)
        {
            LoadData();
        }

        private BackgroundWorker worker;
        private bool isNeededID = false;
        int id;

        public override void btnViewAdd_Click(object sender, EventArgs e)
        {
            isNeededID = false;
            AsyncForm();
            //AsyncFormAdd();
        }

        private void GunaDGVuser_DoubleClick(object sender, EventArgs e)
        {
            isNeededID = true;
            id = Convert.ToInt32(GunaDGVuser.CurrentRow.Cells[1].Value);
            AsyncForm();
            //AsyncFormAdd();
        }

        #region BackgroundWorker 기반 비동기_AsyncForm
        private void AsyncForm()
        {
            worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerAsync();
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            frmUserAdd UserAdd = null;
            
            if (isNeededID)
            {
                UserAdd = new frmUserAdd()
                {
                    editID = id
                };
                UserAdd.label1.Text += " 수정";
            }
            else
            {
                UserAdd = new frmUserAdd();
                UserAdd.label1.Text += " 추가";
            }
            MainClass.BlurBackground(UserAdd);
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LoadData();
        }
        #endregion

        #region async/await 기반 비동기_AsyncFormAdd
        private async void AsyncFormAdd()
        {
            Task task = Task.Factory.StartNew(() =>
            {
                frmUserAdd UserAdd = null;

                if (isNeededID)
                {
                    UserAdd = new frmUserAdd()
                    {
                        editID = id
                    };
                }
                else
                {
                    UserAdd = new frmUserAdd();
                }
                MainClass.BlurBackground(UserAdd);
            });

            await task;
            LoadData();
        }
        #endregion
    }
}
