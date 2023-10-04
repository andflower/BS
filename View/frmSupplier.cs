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
    public partial class frmSupplier : SampleView
    {
        public frmSupplier()
        {
            InitializeComponent();
        }

        private void frmSupplier_Load(object sender, EventArgs e)
        {

        }

        private void LoadData()
        {
            string qry =
            @"SELECT 0 '구분', SUPPLIER_ID, SUPPLIER_NAME, SUPPLIER_PHONE, 
              SUPPLIER_EMAIL, SUPPLIER_ADDRESS FROM TABLE_SUPPLIER
              WHERE SUPPLIER_NAME LIKE '%" + txtSearch.Text + "%'" +
            @"OR SUPPLIER_PHONE LIKE '%" + txtSearch.Text + "%'" +
            @"OR SUPPLIER_EMAIL LIKE '%" + txtSearch.Text + "%'" +
            @"OR SUPPLIER_ADDRESS LIKE '%" + txtSearch.Text + "%' ORDER BY SUPPLIER_ID";

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
            frmSupplierAdd SupplierAdd = null;

            if (isNeededID)
            {
                SupplierAdd = new frmSupplierAdd()
                {
                    editID = id
                };
                SupplierAdd.label1.Text += " 수정";
            }
            else
            {
                SupplierAdd = new frmSupplierAdd();
                SupplierAdd.label1.Text += " 추가";
            }
            MainClass.BlurBackground(SupplierAdd);
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LoadData();
        }
    }
}
