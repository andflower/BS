using Guna.UI2.WinForms;
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BS.Model
{
    public partial class frmUserAdd : SampleAdd
    {
        public frmUserAdd()
        {
            InitializeComponent();
        }

        public string alpha2_Code = "KO";
        public string numeric_Code = "+82";
        ArrayList al = new ArrayList();
        private readonly string mode = "Close";
        private MainClass.eumType enumtype;
        string updateName;

        private void frmUserAdd_Load(object sender, EventArgs e)
        {
            if (editID > 0)
            {
                
                MainClass.AutoLoadForEdit(this, "TABLE_USER", editID);
                enumtype = MainClass.eumType.Update;
                updateName = txtAccount.Text;
                GetInterNumber();
            }
            else if (editID == 0)
            {
                enumtype = MainClass.eumType.Insert;
                GetInterNumber();
            }

            gHtmlToolTip.SetToolTip(this.qAccount, "영문자로 시작하는 영문자 또는 숫자 6~20자");
            gHtmlToolTip.SetToolTip(this.qPass, "8 ~ 16자 영문, 숫자, 특수문자를 최소 한가지씩 조합");
            gHtmlToolTip.SetToolTip(this.qName, "영문 대문자, 소문자, 문자사이 공백");
            gHtmlToolTip.SetToolTip(this.qEmail, "xx@xx.xx.xx 또는 xx@xx.xx");
            gHtmlToolTip.SetToolTip(this.qCountury, "국가 선택 필수(기본값 : 대한민국)");
            gHtmlToolTip.SetToolTip(this.qPhone, "예시) +82 10 1234 1234");

            al.Add(cbCountury.Name);

            // bug
            this.btnDel.Location = new System.Drawing.Point(500, 20);
            ActiveControl = txtAccount;

            // ComboBox의 SelectedIndexChanged 이벤트를 핸들링합니다.
            cbCountury.SelectedIndexChanged += cbCountury_SelectedIndexChanged;
        }

        public override void btnSave_Click(object sender, EventArgs e)
        {
            int toolTipPositionX = 10;
            int toolTipPositionY = 5;
            Color v_color = Color.FromArgb(245, 29, 70);
            Font v_font = new Font("나눔고딕", 8F, FontStyle.Bold, GraphicsUnit.Point, 129);
            bool isAvailableAccount = false;

            string qry =
                @"SELECT USER_ID, USER_ACCOUNT FROM TABLE_USER";
            DataTable dt = MainClass.GetData(qry, CommandType.Text);
            
            try
            {
                if ((dt.Select("[" + "USER_ACCOUNT" + "] LIKE '" + txtAccount.Text + "'"))[0][1].ToString() == updateName)
                {
                    isAvailableAccount = true;
                }
                else if ((dt.Select("[" + "USER_ACCOUNT" + "] LIKE '" + txtAccount.Text + "'"))[0][1].ToString().Length > 1)
                {
                    isAvailableAccount = false;
                }
            }

            catch (IndexOutOfRangeException)
            {
                isAvailableAccount = true;
            }

            // 입력값 형식 확인
            if (editID == 0)
            {
                if (MainClass.Validate(this, MainClass.eumType.Insert, v_color, v_font, toolTipPositionX, toolTipPositionY, alpha2_Code, numeric_Code, isAvailableAccount) == false)
                {
                    return;
                }
            }
            else
            {
                if (MainClass.Validate(this, MainClass.eumType.Update, v_color, v_font, toolTipPositionX, toolTipPositionY, alpha2_Code, numeric_Code, isAvailableAccount) == false)
                {
                    return;
                }
            }

            // Save
            if (editID == 0)
            {
                MainClass.AutoSQL(this, "TABLE_USER", MainClass.eumType.Insert, editID, al);
            }

            else
            {
                MainClass.AutoSQL(this, "TABLE_USER", MainClass.eumType.Update, editID, al);
            }


            this.Close();
        }

        public override void btnDel_Click(object sender, EventArgs e)
        {
            MainClass.AutoSQL(this, "TABLE_USER", MainClass.eumType.Delete, editID, al);
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
