using BS.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheArtOfDevHtmlRenderer.Adapters.Entities;

namespace BS.View
{
    public partial class frmProduct : SampleView
    {
        public frmProduct()
        {
            InitializeComponent();
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        int IMAGE_COL_INDEX = 0;
        bool currentlyAnimating = false;

        private void LoadData()
        {
            string qry =
            @"SELECT 0 '구분', PRODUCT_ID, PRODUCT_NAME, PRODUCT_PRICE, 
              PRODUCT_COST, PRODUCT_IMAGE FROM TABLE_PRODUCT
              WHERE PRODUCT_NAME LIKE '%" + txtSearch.Text + "%' ORDER BY PRODUCT_ID";
            
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
            //AsyncFormAdd();
            AsyncForm();
        }

        private void GunaDGVuser_DoubleClick(object sender, EventArgs e)
        {
            isNeededID = true;
            id = Convert.ToInt32(GunaDGVuser.CurrentRow.Cells[1].Value);
            //AsyncFormAdd();
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
            frmProductAdd ProductAdd = null;

            if (isNeededID)
            {
                ProductAdd = new frmProductAdd()
                {
                    editID = id
                };
                ProductAdd.label1.Text += " 수정";
            }
            else
            {
                ProductAdd = new frmProductAdd();
                ProductAdd.label1.Text += " 추가";
            }
            MainClass.BlurBackground(ProductAdd);
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LoadData();
        }

        private async void AsyncFormAdd()
        {
            Task task = Task.Factory.StartNew(() =>
            {
                frmProductAdd ProductAdd = null;

                if (isNeededID)
                {
                    ProductAdd = new frmProductAdd()
                    {
                        editID = id
                    };
                }
                else
                {
                    ProductAdd = new frmProductAdd();
                }
                MainClass.BlurBackground(ProductAdd);
            });

            await task;
            LoadData();
        }
    }
}
