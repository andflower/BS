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

        public override void BSdgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
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
