using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BS.Model;

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
            //MainClass.BlurBackground(new frmUserAdd());
            
            await Task.Run(() =>
            {
                MainClass.BlurBackground(new frmUserAdd());
                LoadData();
            });
        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            txtSearchFunc();
        }


        /*public override void BSdgv_DoubleClick(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(BSdgv.CurrentRow.Cells[1].Value);
            new frmUserAdd() { editID = id }.Show();
            LoadData();
        }*/

        public override void txtSearch_IconRightClick(object sender, EventArgs e)
        {
            txtSearchFunc();
        }

        private void txtSearchFunc()
        {
            LoadData();
        }

        private void GunaDGVuser_DoubleClick(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(GunaDGVuser.CurrentRow.Cells[1].Value);
            new frmUserAdd() { editID = id }.Show();
            LoadData();
        }
    }
}
