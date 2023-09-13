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
                @"SELECT 0 '구분', USER_ID, USER_ACCOUNT, USER_NAME,
                  USER_PHONE, USER_EMAIL FROM TABLE_USER
                  WHERE USER_NAME LIKE '%" + txtSearch.Text + "%'";
            //MainClass.
        }

        public override void btnViewAdd_Click(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new frmUserAdd());
            LoadData();
        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            txtSearchFunc();
        }


        public override void BSdgv_DoubleClick(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(BSdgv.CurrentRow.Cells[1].Value);
            new frmUserAdd() { editID = id }.Show();
            LoadData();
        }

        public override void txtSearch_IconRightClick(object sender, EventArgs e)
        {
            txtSearchFunc();
        }

        private void txtSearchFunc()
        {
            LoadData();
        }
    }
}
