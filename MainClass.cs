using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using System.Runtime.CompilerServices;
using System.Drawing;

namespace BS
{
    public class MainClass
    {
        public static readonly string SERVER_INIT =
            @"Server=GOMDDANJI\\SQLEXPRESS01;
              Database=BS;
              Trusted_Connection=True;";
        public static SqlConnection con = new SqlConnection(SERVER_INIT);

        /// <summary>
        /// DataTable 가져오기
        /// </summary>
        /// <param name="qry"></param>
        /// <returns></returns>
        public static DataTable GetData(string qry)
        {
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        /// <summary>
        /// 사용자 데이터베이스 확인
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public static bool IsValidUser(string user, string pass)
        {
            bool isValid = false;
            string qry =
                @"SELECT * FROM USERS
                  WHERE USER_NAME = '"+ user + "' AND '" + pass + "';";
            DataTable dt = GetData(qry);

            if (dt.Rows.Count > 0)
            {
                isValid = true;
            }

            return isValid;
        }

        /// <summary>
        /// INSERT, UPDATE, DELETE 쿼리문 실행
        /// </summary>
        /// <param name="qry"></param>
        /// <param name="ht"></param>
        /// <returns></returns>
        public static int SQL(string qry, Hashtable ht)
        {
            int res = 0;

            try
            {
                SqlCommand cmd = new SqlCommand(qry, con);

                //
                // 요약:
                //     System.Data.SqlClient.SqlParameterCollection 끝에 값을 추가합니다.
                //
                // 매개 변수:
                //   parameterName:
                //     매개 변수의 이름입니다.
                //
                //   value:
                //     추가할 값입니다. null 값을 나타내기 위해 null 대신 System.DBNull.Value를 사용합니다.
                //
                // 반환 값:
                //     System.Data.SqlClient.SqlParameter 개체입니다.
                foreach (DictionaryEntry deItem in ht)
                {
                    cmd.Parameters.AddWithValue(deItem.Key.ToString(), deItem.Value);
                }


                // connection 상태에 따른 데이터베이스 접속
                // 데이터베이스 진입(open)시 res(result) 값으로 cmd의 쿼리 실행
                if (con.State == ConnectionState.Closed)
                    con.Open();

                res = cmd.ExecuteNonQuery();

                if (con.State == ConnectionState.Open)
                    con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
            }
            return res;
        }

        /// <summary>
        /// DataGridView 에서 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int count = 0;
            Guna.UI2.WinForms.Guna2DataGridView dgv = (Guna.UI2.WinForms.Guna2DataGridView)sender;

            // dgvRow는 첫번째 열이 무조건 인덱스라 가정시에 적용 가능함
            foreach (DataGridViewRow dgvRow in dgv.Rows)
            {
                count++;
                dgvRow.Cells[0].Value = count;
            }
        }

        /// <summary>
        /// Form에 대한 Guna.UI2.WinForms.Control 초기화
        /// </summary>
        /// <param name="F"></param>
        public static void ClearAll(Form F)
        {
            foreach (Control control in F.Controls)
            {
                Type type = control.GetType();

                if (type == typeof(Guna2TextBox))
                {
                    Guna2TextBox textBox = (Guna2TextBox)control;
                    textBox.Text = "";
                }
                else if (type == typeof(Guna2ComboBox))
                {
                    Guna2ComboBox comboBox = (Guna2ComboBox)control;
                    comboBox.SelectedIndex = 0;
                    comboBox.SelectedIndex = -1;
                }
                else if (type == typeof(CheckBox))
                {
                    ((CheckBox)control).Checked = false;
                }
            }
        }


        /// <summary>
        /// FrmMain 폼 기준 다른 폼 로드시 반투명 배경화면 설정
        /// FrmMain.cs Example
        /// static FrmMain _obj;
        ///
        ///public static FrmMain Instance
        ///{
        ///    get
        ///    {
        ///        if (_obj == null)
        ///        {
        ///            _obj = new FrmMain();
        ///        }
        ///        return _obj;
        ///    }
        ///}
        ///
        ///private void FrmMain_Load(object sender, EventArgs e)
        ///{
        ///    _obj = this;
        ///}
        ///
        /// </summary>
        /// <param name="Model"></param>
        public static void BlurBackground(Form Model)
        {
            Form Background = new Form();
            using (Model)
            {
                Background.StartPosition = FormStartPosition.Manual;
                Background.FormBorderStyle = FormBorderStyle.None;
                Background.Opacity = 0.5d;
                Background.BackColor = Color.Black;
                Background.Size = frmMain.Instance.Size;
                Background.Location = frmMain.Instance.Location;
                Background.ShowInTaskbar = false;
                Background.Show();
                Model.Owner = Background;
                Model.ShowDialog(Background);
                Background.Dispose();
            }
        }
    }
}
