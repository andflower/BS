using BS.Model;
using System;
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
            string qry =
            @"SELECT 0 '구분', USER_ID, USER_ACCOUNT, USER_PASSWORD, 
              USER_NAME, USER_PHONE, USER_EMAIL FROM TABLE_USER
              WHERE USER_ACCOUNT LIKE '%" + txtSearch.Text + "%'" +
            @"OR USER_NAME LIKE '%" + txtSearch.Text + "%'" +
            @"OR USER_PHONE LIKE '%" + txtSearch.Text + "%'" +
            @"OR USER_EMAIL LIKE '%" + txtSearch.Text + "%'";

            /*@"SELECT * FROM TABLE_USER
                  WHERE USER_NAME LIKE '%" + txtSearch.Text + "%'";*/
            ListBox lb = new ListBox();

            lb.Items.Add(dgvID);
            lb.Items.Add(dgvUserID);
            lb.Items.Add(dgvAccount);
            lb.Items.Add(dgvPass);
            lb.Items.Add(dgvName);
            lb.Items.Add(dgvPhone);
            lb.Items.Add(dgvEmail);

            MainClass.LoadData(qry, GunaDGVuser, lb);
        }

        public async override void btnViewAdd_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                frmUserAdd UserAdd = new frmUserAdd();
                MainClass.BlurBackground(UserAdd);
            });
            LoadData();
        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            txtSearchFunc();
        }

        public override void txtSearch_IconRightClick(object sender, EventArgs e)
        {
            txtSearchFunc();
        }

        private void txtSearchFunc()
        {
            LoadData();
        }

        private async void GunaDGVuser_DoubleClick(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(GunaDGVuser.CurrentRow.Cells[1].Value);
            await Task.Run(() =>
            {
                frmUserAdd UserAdd = new frmUserAdd()
                {
                    editID = id
                };
                MainClass.BlurBackground(UserAdd);
            });

            LoadData();
        }
    }
}
