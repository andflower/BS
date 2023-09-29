using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BS.Model
{
    public partial class frmProductAdd : SampleAdd
    {
        public frmProductAdd()
        {
            InitializeComponent();
        }

        ArrayList al = new ArrayList();
        string tableName = "";
        private MainClass.eumType enumtype;

        private void frmProductAdd_Load(object sender, EventArgs e)
        {
            tableName = "TABLE_" + this.Name.Replace("frm", "").Replace("Add", "").ToUpper();

            // bug
            this.btnDel.Location = new System.Drawing.Point(720, 20);

            if (editID > 0)
            {
                MainClass.AutoLoadForEdit(this, "TABLE_PRODUCT", editID);
                enumtype = MainClass.eumType.Update;
            }
            else if (editID == 0)
            {
                enumtype = MainClass.eumType.Insert;
            }
        }
        
        public override void btnSave_Click(object sender, EventArgs e)
        {
            int toolTipPositionX = 10;
            int toolTipPositionY = 5;
            Color v_color = Color.FromArgb(245, 29, 70);
            Font v_font = new Font("나눔고딕", 8F, FontStyle.Bold, GraphicsUnit.Point, 129);
            bool isAvailableAccount = false;
            
            string qry =
                @"SELECT PRODUCT_ID, PRODUCT_NAME, PRODUCT_PRICE, PRODUCT_COST, PRODUCT_IMAGE FROM TABLE_PRODUCT";
            DataTable dt = MainClass.GetData(qry, CommandType.Text);

            // 입력값 형식 확인
            if (editID == 0)
            {
                if (MainClass.Validate(this, MainClass.eumType.Insert, v_color, v_font, toolTipPositionX, toolTipPositionY, "", "", isAvailableAccount) == false)
                {
                    return;
                }
            }
            else
            {
                if (MainClass.Validate(this, MainClass.eumType.Update, v_color, v_font, toolTipPositionX, toolTipPositionY, "", "", isAvailableAccount) == false)
                {
                    return;
                }
            }

            // Save
            if (editID == 0)
            {
                MainClass.AutoSQL(this, tableName, MainClass.eumType.Insert, editID, al);
            }

            else
            {
                MainClass.AutoSQL(this, tableName, MainClass.eumType.Update, editID, al);
            }

            this.Close();
        }

        public override void btnDel_Click(object sender, EventArgs e)
        {
            MainClass.AutoSQL(this, tableName, MainClass.eumType.Delete, editID, al);
            editID = 0;
            MainClass.Reset_All(this);
        }

        [STAThread]
        private async void btnBrowse_Click(object sender, EventArgs e)
        {
            await MainClass.BrowsePicture(pbImage);
        }
    }
}
