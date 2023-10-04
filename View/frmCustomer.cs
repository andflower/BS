using BS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BS.View
{
    public partial class frmCustomer : SampleView
    {
        public frmCustomer()
        {
            InitializeComponent();
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string qry =
            @"SELECT 0 '구분', CUSTOMER_ID, CUSTOMER_NAME, CUSTOMER_PHONE, 
              CUSTOMER_EMAIL, CUSTOMER_ADDRESS FROM TABLE_CUSTOMER
              WHERE CUSTOMER_NAME LIKE '%" + txtSearch.Text + "%'" +
            @"OR CUSTOMER_PHONE LIKE '%" + txtSearch.Text + "%'" +
            @"OR CUSTOMER_EMAIL LIKE '%" + txtSearch.Text + "%'" +
            @"OR CUSTOMER_ADDRESS LIKE '%" + txtSearch.Text + "%' ORDER BY CUSTOMER_ID";

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
        }

        private void GunaDGVuser_DoubleClick(object sender, EventArgs e)
        {
            isNeededID = true;
            id = Convert.ToInt32(GunaDGVuser.CurrentRow.Cells[1].Value);
            AsyncForm();
        }

        private void AsyncForm()
        {
            worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerAsync();
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            frmCustomerAdd CustomerAdd = null;

            if (isNeededID)
            {
                CustomerAdd = new frmCustomerAdd()
                {
                    editID = id
                };
                CustomerAdd.label1.Text += " 수정";
            }
            else
            {
                CustomerAdd = new frmCustomerAdd();
                CustomerAdd.label1.Text += " 추가";
            }
            MainClass.BlurBackground(CustomerAdd);
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LoadData();
        }
    }
}
