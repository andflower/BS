using DevExpress.Utils.Helpers;
using Guna.UI2.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
        private void frmUserAdd_Load(object sender, EventArgs e)
        {
            if (editID > 0)
            {
                MainClass.AutoLoadForEdit(this, "TABLE_USER", editID);
            }
            GetInterNumber();
            gHtmlToolTip.SetToolTip(this.qAccount, "영문자로 시작하는 영문자 또는 숫자 6~20자");
            gHtmlToolTip.SetToolTip(this.qPass, "8 ~ 16자 영문, 숫자, 특수문자를 최소 한가지씩 조합");
            gHtmlToolTip.SetToolTip(this.qName, "영문 대문자, 소문자, 문자사이 공백");
            gHtmlToolTip.SetToolTip(this.qEmail, "xx@xx.xx.xx 또는 xx@xx.xx");
            gHtmlToolTip.SetToolTip(this.qCountury, "국가 선택 필수(기본값 : 대한민국)");
            gHtmlToolTip.SetToolTip(this.qPhone, "예시) +82 10 1234 1234");

            // bug
            this.btnDel.Location = new System.Drawing.Point(500, 20);
            ActiveControl = txtAccount;
        }

        /*[System.Runtime.InteropServices.DllImport("User32.dll")]
        static extern bool MoveWindow(IntPtr h, int x, int y, int width, int height, bool redraw);
        private void toolTip1_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
            var t = (ToolTip)sender;
            var h = t.GetType().GetProperty("Handle",
              System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var handle = (IntPtr)h.GetValue(t);
            var location = new Point(1000, 1000);
            MoveWindow(handle, location.X, location.Y, e.Bounds.Width, e.Bounds.Height, false);
        }*/

        public override void btnSave_Click(object sender, EventArgs e)
        {
            var t1 = new System.Windows.Forms.TextBox();
            int toolTipPositionX = 10;
            int toolTipPositionY = 5;
            Color v_color = Color.FromArgb(245, 29, 70);
            Font v_font = new Font("나눔고딕", 8F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(129)));


            // 입력값 형식 확인
            if (MainClass.Validate(this, v_color, v_font, toolTipPositionX, toolTipPositionY, alpha2_Code, numeric_Code) == false)
            {
                return;
            }

            // Save
            if (editID == 0)
            {
                ArrayList al = new ArrayList();
                al.Add(cbCountury.Name);
                MainClass.AutoSQL(this, "TABLE_USER", MainClass.eumType.Insert, editID, al);
            }

            else
            {

            }
        }
        

        private void GetInterNumber()
        {
            string qry =
                @"SELECT Contury_KOR, Numeric_Code, Numeric_Code, Alpha2_Code, Alpha3_Code,
	                + Contury_KOR + '(' + Alpha3_Code + ')' AS CombinedText
                    FROM TABLE_COUNTURY_CODE";
            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.Text;
            da.Fill(dt);

            cbCountury.DisplayMember = "CombinedText"; // 표시할 열을 설정합니다.
            cbCountury.DataSource = dt; // DataTable 자체를 DataSource로 설정합니다.
            cbCountury.SelectedIndex = 25;
            // 초기 선택 항목에 대한 Numeric_Code를 txtInum.Text에 설정합니다.
            txtPhone.Text = "";
            txtPhone.Text = numeric_Code = "+" + dt.Rows[cbCountury.SelectedIndex]["Numeric_Code"].ToString();

            // ComboBox의 SelectedIndexChanged 이벤트를 핸들링합니다.
            cbCountury.SelectedIndexChanged += cbCountury_SelectedIndexChanged;

        }

        private void cbCountury_SelectedIndexChanged(object sender, EventArgs e)
        {
            Getalpha2_Code();
        }

        private void Getalpha2_Code()
        {
            // ComboBox의 선택 항목이 변경될 때 Numeric_Code를 txtInum.Text에 설정합니다.
            if (cbCountury.SelectedIndex >= 0)
            {
                DataTable dt = (DataTable)cbCountury.DataSource;
                txtPhone.Text = "";
                txtPhone.Text = numeric_Code = "+" + dt.Rows[cbCountury.SelectedIndex]["Numeric_Code"].ToString() + txtPhone.Text;
                alpha2_Code = dt.Rows[cbCountury.SelectedIndex]["Alpha2_Code"].ToString();
            }
            else
            {
                // 선택된 항목이 없는 경우에 대한 처리를 추가할 수 있습니다.
                cbCountury.Text = "";
            }
        }


        private void toolTipEnter(object sender)
        {
            var t = sender as Guna2PictureBox;
            t.Image = BS.Properties.Resources.question_b;
                
        }

        private void toolTipLeave(object sender)
        {
            var t = sender as Guna2PictureBox;
            t.Image = BS.Properties.Resources.question;
        }

        private void qAccount_MouseEnter(object sender, EventArgs e)
        {
            toolTipEnter(sender);
        }

        private void qName_MouseEnter(object sender, EventArgs e)
        {
            toolTipEnter(sender);
        }

        private void qCountury_MouseEnter(object sender, EventArgs e)
        {
            toolTipEnter(sender);
        }

        private void qPass_MouseEnter(object sender, EventArgs e)
        {
            toolTipEnter(sender);
        }

        private void qEmail_MouseEnter(object sender, EventArgs e)
        {
            toolTipEnter(sender);
        }

        private void qPhone_MouseEnter(object sender, EventArgs e)
        {
            toolTipEnter(sender);
        }

        private void qAccount_MouseLeave(object sender, EventArgs e)
        {
            toolTipLeave(sender);
        }

        private void qName_MouseLeave(object sender, EventArgs e)
        {
            toolTipLeave(sender);
        }

        private void qCountury_MouseLeave(object sender, EventArgs e)
        {
            toolTipLeave(sender);
        }

        private void qPass_MouseLeave(object sender, EventArgs e)
        {
            toolTipLeave(sender);
        }

        private void qEmail_MouseLeave(object sender, EventArgs e)
        {
            toolTipLeave(sender);
        }

        private void qPhone_MouseLeave(object sender, EventArgs e)
        {
            toolTipLeave(sender);
        }

        private void txtPhone_MouseClick(object sender, MouseEventArgs e)
        {
            var t = sender as Guna2TextBox;
            t.SelectionStart = t.Text.Length;
        }
    }
}
