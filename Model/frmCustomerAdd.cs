using CefSharp;
using CefSharp.WinForms;
using Guna.UI2.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BS.Model
{
    public partial class frmCustomerAdd : SampleAdd
    {
        public frmCustomerAdd()
        {
            InitializeComponent();
        }

        public string alpha2_Code = "KO";
        public string numeric_Code = "+82";
        ArrayList al = new ArrayList();
        private readonly string mode = "Close";
        private MainClass.eumType enumtype;
        string tableName;

        private void frmCustomerAdd_Load(object sender, EventArgs e)
        {
            if (editID > 0)
            {
                MainClass.AutoLoadForEdit(this, "TABLE_CUSTOMER", editID);
                enumtype = MainClass.eumType.Update;
                GetInterNumber();
            }
            else if (editID == 0)
            {
                enumtype = MainClass.eumType.Insert;
                GetInterNumber();
            }

            gHtmlToolTip.SetToolTip(this.qName, "영문 대문자, 소문자, 문자사이 공백");
            gHtmlToolTip.SetToolTip(this.qEmail, "xx@xx.xx.xx 또는 xx@xx.xx");
            gHtmlToolTip.SetToolTip(this.qCountury, "국가 선택 필수(기본값 : 대한민국)");
            gHtmlToolTip.SetToolTip(this.qAddress, "주소조회 버튼을 클릭");
            gHtmlToolTip.SetToolTip(this.qPhone, "예시) +82 10 1234 1234");

            al.Add(cbCountury.Name);

            tableName = "TABLE_" + this.Name.Replace("frm", "").Replace("Add", "").ToUpper();
            // bug
            this.btnDel.Location = new System.Drawing.Point(770, 20);

            ActiveControl = txtName;

            // ComboBox의 SelectedIndexChanged 이벤트를 핸들링합니다.
            cbCountury.SelectedIndexChanged += cbCountury_SelectedIndexChanged;
        }

        private void btnAddressSearch_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() =>
            {
                MainClass.jusoString = "";
                MainClass.oldjusoString = this.txtAddress.Text;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new WebBrowserForm());

                // 폼이 닫힌 후 추가 작업 수행 가능
                txtAddress.Text = MainClass.jusoString;
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        public override void btnSave_Click(object sender, EventArgs e)
        {
            int toolTipPositionX = 10;
            int toolTipPositionY = 5;
            Color v_color = Color.FromArgb(245, 29, 70);
            Font v_font = new Font("나눔고딕", 8F, FontStyle.Bold, GraphicsUnit.Point, 129);
            string tableName = "TABLE_" + this.Name.Replace("frm", "").Replace("Add", "").ToUpper();

            // 입력값 형식 확인
            if (editID == 0)
            {
                if (MainClass.Validate(this, MainClass.eumType.Insert, v_color, v_font, toolTipPositionX, toolTipPositionY, alpha2_Code, numeric_Code, false) == false)
                {
                    return;
                }
            }
            else
            {
                if (MainClass.Validate(this, MainClass.eumType.Update, v_color, v_font, toolTipPositionX, toolTipPositionY, alpha2_Code, numeric_Code, false) == false)
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

        private void GetInterNumber()
        {
            string qry =
                @"SELECT CONTURY_KOR, NUMERIC_CODE, ALPHA2_CODE, ALPHA3_CODE,
	                + CONTURY_KOR + '(' + ALPHA3_CODE + ')' AS COMBINED_TEXT
                    FROM TABLE_CONTURY_CODE";
            DataTable dt = MainClass.GetData(qry, CommandType.Text);
            MainClass.CBFill(qry, cbCountury, "COMBINED_TEXT", 25);

            // 초기 선택 항목에 대한 Numeric_Code를 txtInum.Text에 설정합니다.
            if (enumtype != MainClass.eumType.Update)
            {
                txtPhone.Text = "";
                txtPhone.Text = numeric_Code = "+" + dt.Rows[cbCountury.SelectedIndex]["NUMERIC_CODE"].ToString();
            }
        }

        private void Getalpha2_Code()
        {
            // ComboBox의 선택 항목이 변경될 때 Numeric_Code를 txtInum.Text에 설정합니다.
            if (cbCountury.SelectedIndex >= 0)
            {
                DataTable dt = (DataTable)cbCountury.DataSource;
                txtPhone.Text = "";
                txtPhone.Text = numeric_Code = "+" + dt.Rows[cbCountury.SelectedIndex]["NUMERIC_CODE"].ToString() + txtPhone.Text;
                alpha2_Code = dt.Rows[cbCountury.SelectedIndex]["ALPHA2_CODE"].ToString();
            }
            else
            {
                // 선택된 항목이 없는 경우에 대한 처리를 추가할 수 있습니다.
                cbCountury.Text = "";
            }
        }

        private void q_MouseEnter(object sender, EventArgs e)
        {
            var t = sender as Guna2PictureBox;
            t.Image = BS.Properties.Resources.question_b;
        }

        private void q_MouseLeave(object sender, EventArgs e)
        {
            var t = sender as Guna2PictureBox;
            t.Image = BS.Properties.Resources.question;
        }

        private void txtPhone_MouseClick(object sender, MouseEventArgs e)
        {
            var t = sender as Guna2TextBox;
            t.SelectionStart = t.Text.Length;
        }

        public override void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void object_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnSave_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (mode.Equals("Exit"))
                {
                    Application.Exit();
                }
                else if (mode.Equals("Close"))
                {
                    this.Close();
                }
            }
        }

        private void cbCountury_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (editID >= 0)
            {
                Getalpha2_Code();
            }
        }
    }
}