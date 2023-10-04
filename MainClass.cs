using Guna.UI2.WinForms;
using PhoneNumbers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Control = System.Windows.Forms.Control;

namespace BS
{
    public class MainClass
    {
        public static string MsgCaption;
        public static string conString;
        public static SqlConnection con = new SqlConnection(conString);
        public static bool isLogined = false;
        public static string filePath;
        public static string jusoString;
        public static string oldjusoString;

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
        /// 
        /// </summary>
        /// <param name="qry"></param>
        /// <param name="type">ex) CommandType.Text</param>
        /// <returns></returns>
        public static DataTable GetData(string qry, CommandType type)
        {
            SqlCommand cmd = new SqlCommand(qry, con)
            {
                CommandType = type
            };
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
                @"SELECT * FROM TABLE_USER
                  WHERE USER_ACCOUNT = '" + user + "' " +
                  "AND USER_PASSWORD = '" + pass + "';";
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

                foreach (DictionaryEntry deItem in ht)
                {
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
                    // public SqlParameter AddWithValue(string parameterName, object value)
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
        /// ListBox를 정해야 되는 경우 ListBox 포함
        /// ListBox를 정하지 않는 경우 ListBox 미포함
        /// </summary>
        /// <param name="qry"></param>
        /// <param name="gv"></param>
        /// <param name="lb"></param>
        public static void LoadData(string qry, DataGridView gv)
        {
            #region MessageBox setting
            Guna2MessageDialog dialog = new Guna2MessageDialog()
            {
                //Parent = ,
                Style = MessageDialogStyle.Dark,
                Caption = "결제 시스템",
                Icon = MessageDialogIcon.None,
            };
            #endregion

            ListBox lb = new ListBox();
            bool isImgContained = false;

            foreach (DataGridViewColumn col in gv.Columns)
            {
                lb.Items.Add(gv.Columns[col.Name]);
            }

            gv.CellFormatting += new DataGridViewCellFormattingEventHandler(dgv_CellFormatting);
            try
            {
                DataTable dt = GetData(qry, CommandType.Text);
                DataTable dtCloned = dt.Clone();

                // GIF 동적 이미지
                for (int i = 0; i < lb.Items.Count; ++i)
                {
                    string colName = ((DataGridViewColumn)lb.Items[i]).Name;

                    if (colName.Equals("dgvImage"))
                    {
                        // 원하는 Type으로 변경한다.
                        dtCloned.Columns[i].DataType = typeof(Image);

                        foreach (DataRow row in dt.Rows)
                        {
                            // 임시 Table의 원본 DataRow내용을 가져온다.
                            DataRow newRow = dtCloned.NewRow();
                            for (int j = 0; j < dt.Columns.Count; j++)
                            {
                                if (j == i) // 이미지 열의 경우
                                {
                                    byte[] imageBytes = (byte[])row[i];
                                    using (MemoryStream ms = new MemoryStream(imageBytes))
                                    {
                                        Image image = Image.FromStream(ms);
                                        newRow[i] = image;
                                    }
                                }
                                else
                                {
                                    newRow[j] = row[j];
                                }
                            }
                            dtCloned.Rows.Add(newRow);
                        }

                        isImgContained = true;
                    }
                }

                for (int i = 0; i < lb.Items.Count; ++i)
                {
                    string colName = ((DataGridViewColumn)lb.Items[i]).Name;
                    
                    gv.Columns[colName].DataPropertyName = dt.Columns[i].ToString();
                }

                // TODO : 현재 동적 IMG는 가능하나 코드가 이중으로 IMAGE를 넣는 것으로 최적화 필요함
                if (isImgContained)
                {
                    gv.DataSource = dtCloned;
                    for (int i = 0; i < dt.Rows.Count; ++i)
                    {
                        byte[] imageByteArray = (byte[])(dt.Rows[i]["PRODUCT_IMAGE"]);
                        gv.Rows[i].Cells["dgvImage"].ValueType = typeof(Image);
                        gv.Rows[i].Cells["dgvImage"].Value = (Image.FromStream(new MemoryStream(imageByteArray)));
                    }
                }
                else
                {
                    gv.DataSource = dt;
                }
            }
            catch (Exception e)
            {
                dialog.Show(e.ToString());
                con.Close();
            }
        }

        /// <summary>
        /// DataGridView 에서 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int count = 0;
            Guna.UI2.WinForms.Guna2DataGridView dgv = sender as Guna.UI2.WinForms.Guna2DataGridView;

            
            // dgvRow는 첫번째 열이 무조건 인덱스로 가정시에 적용 가능함
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
            foreach (System.Windows.Forms.Control control in F.Controls)
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

        public static void BlurBackground(Form Model, Form ownerForm)
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
                Background.Show(ownerForm);
                Model.Owner = Background;
                Model.ShowDialog(Background);
                Background.Dispose();
            }
        }

        public static void TransparentBackground(Form Model, Form ownerForm)
        {
            Form Background = new Form();
            using (Model)
            {
                Background.StartPosition = FormStartPosition.Manual;
                Background.FormBorderStyle = FormBorderStyle.None;
                Background.Opacity = 0.0d;
                Background.BackColor = Color.Black;
                Background.Size = ownerForm.Size;
                Background.Location = ownerForm.Location;
                Background.ShowInTaskbar = false;
                Background.Show(ownerForm);
                Model.Owner = Background;
                Model.ShowDialog(Background);
                Background.Dispose();
            }
        }

        /// <summary>
        /// ComboBox의 값을 데이터베이스에서 가져와 목록을 만들어줌
        /// </summary>
        /// <param name="qry"></param>
        /// <param name="cb"></param>
        /// <param name="index">default값 -1</param>
        public static void CBFill(string qry, ComboBox cb, string member, int index = -1)
        {
            DataTable dt = GetData(qry, CommandType.Text);

            cb.DisplayMember = member;
            cb.ValueMember = "id";
            cb.DataSource = dt;
            cb.SelectedIndex = index;
        }

        /// <summary>
        /// 해당 Form의 TextBox, ComboBox의 Name 속성과 DB의 Column 이름이 일치할 경우
        /// TextBox, ComboBox의 값을 INSERT문으로 자동적으로 INSERT함
        /// </summary>
        /// <param name="frm"></param>
        /// <param name="tableName"></param>
        /// <param name="ordinalPosition"></param>
        public static void AutoInsert(Form frm, string tableName, int ordinalPosition = 0)
        {
            string qry =
                $"SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS " +
                $"WHERE TABLE_NAME LIKE '{tableName}' " +
                $"AND ORDINAL_POSITION > {ordinalPosition};";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = GetData(qry);
            da.Fill(dt);

            List<string> columnNames = new List<string>();

            foreach (DataRow item in dt.Rows)
            {
                columnNames.Add("@" + item["COLUMN_NAME"].ToString());
            }

            string insertStatment = $"INSERT INTO {tableName} VALUES ({string.Join(", ", columnNames)});";

            SqlCommand instertCommand = new SqlCommand(insertStatment, con);

            // debugging
            //MessageBox.Show(InsertStatment);

            foreach (DataRow item in dt.Rows)
            {
                string colName = item["COLUMN_NAME"].ToString();
                string dataType = item["DATA_TYPE"].ToString();

                foreach (System.Windows.Forms.Control c in frm.Controls)
                {
                    if (c.Name == colName)
                    {
                        if (c is Guna2TextBox)
                        {

                            Guna2TextBox t = c as Guna2TextBox;

                            if (dataType.ToLower() == "varchar")
                            {
                                instertCommand.Parameters.AddWithValue("@" + colName, t.Text);
                            }
                            else if (dataType.ToLower() == "int")
                            {
                                instertCommand.Parameters.AddWithValue("@" + colName, Convert.ToInt32(t.Text));
                            }
                        }

                        else if (c is Guna2ComboBox)
                        {
                            Guna2ComboBox cb = c as Guna2ComboBox;
                            if (dataType.ToLower() == "varchar")
                            {
                                instertCommand.Parameters.AddWithValue("@" + colName, cb.Text);
                            }
                            else if (dataType.ToLower() == "int")
                            {
                                instertCommand.Parameters.AddWithValue("@" + colName, Convert.ToInt32(cb.SelectedValue));
                            }
                        }
                    }
                }

                con.Open();
                int sqlResult = cmd.ExecuteNonQuery();
                con.Close();

                // debugging
                if (sqlResult > 0)
                {
                    //msgDialog.Show("INSERT문이 성공하였습니다.");
                }
            }
        }

        public enum eumType
        {
            Insert,
            Update,
            Delete
        }

        public eumType action;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frm">작업할 Form</param>
        /// <param name="tableName">Add 되는 테이블 이름</param>
        /// <param name="type">enumType : Insert, Update, Delete</param>
        /// <param name="id">Add 되는 id</param>
        /// <param name="ignoredColumns">제외되는 열이름(type: ArrayList)</param>
        /// <returns></returns>
        public static int AutoSQL(Form frm, string tableName, eumType type, int id, ArrayList ignoredColumns)
        {
            string query = "";
            SqlCommand cmd = new SqlCommand();
            int sqlResult = 0;
            string prefixColumnName = tableName.Replace("TABLE_", "") + "_";

            #region MessageBox setting
            Guna2MessageDialog dialog = new Guna2MessageDialog()
            {
                Parent = frm,
                Style = MessageDialogStyle.Dark,
                Caption = "결제 시스템",
                Icon = MessageDialogIcon.None
            };
            #endregion


            switch (type)
            {
                case eumType.Insert:
                    query = $"INSERT INTO {tableName} (";
                    break;
                case eumType.Update:
                    query = $"UPDATE {tableName} SET ";
                    break;
                case eumType.Delete:
                    query = $"DELETE FROM {tableName} WHERE {prefixColumnName}ID = @ID"; // 예시로 ID 기반 삭제
                    cmd.Parameters.AddWithValue("@ID", id);
                    break;
                default:
                    return sqlResult;
            }

            List<string> columnNames = new List<string>();

            foreach (Control c in frm.Controls)
            {
                if (!ignoredColumns.Contains(c.Name))
                {
                    string colName = "";
                    object colValue = "";

                    if (c is Guna2TextBox)
                    {
                        Guna2TextBox t = c as Guna2TextBox;
                        colName = prefixColumnName + t.Name.Replace("txt", "").ToUpper();
                        colValue = t.Text.Replace(",", "");
                    }
                    else if (c is Guna2ComboBox)
                    {
                        Guna2ComboBox cb = c as Guna2ComboBox;
                        colName = prefixColumnName + cb.Name.Replace("cb", "").ToUpper();
                        colValue = cb.Text.Replace(",", "");
                    }
                    else if (c is Guna2PictureBox && c.Tag != null)
                    {
                        Guna2PictureBox pb = c as Guna2PictureBox;
                        colName = prefixColumnName + pb.Name.Replace("pb", "").ToUpper();
                        byte[] imageByteArray = File.ReadAllBytes(filePath);
                        colValue = imageByteArray;
                    }
                    if (c.Tag != null)
                    {
                        columnNames.Add($"{colName}");
                        cmd.Parameters.AddWithValue("@" + colName, colValue);
                    }
                }
            }

            if (type == eumType.Insert)
            {
                query += string.Join(", ", columnNames) + ") VALUES (";
                query += "@" + string.Join(", @", columnNames) + ");";
            }
            else if (type == eumType.Update)
            {
                List<string> updateStatements = new List<string>();
                foreach (string colName in columnNames)
                {
                    updateStatements.Add($"{colName} = @{colName}");
                }
                query += string.Join(", ", updateStatements) + $" WHERE {prefixColumnName}ID = @{prefixColumnName}ID"; // 예시로 ID 기반 업데이트
                cmd.Parameters.AddWithValue($"@{prefixColumnName}ID", id);
            }

            cmd.CommandText = query;
            cmd.Connection = con;

            try
            {
                con.Open();
                sqlResult = cmd.ExecuteNonQuery();
                con.Close();

                if (type == eumType.Insert)
                {
                    dialog.Show("저장하였습니다");
                }
                else if (type == eumType.Delete)
                {
                    dialog.Show("삭제하였습니다.");
                }
                else if (type == eumType.Update)
                {
                    dialog.Show("수정하였습니다.");
                }
            }
            catch (Exception ex)
            {
                dialog.Show($"오류 발생: {ex.Message}");
            }

            return sqlResult;
        }

        public static void AutoLoadForEdit(Form frm, string tableName, int id)
        {
            string query =
                $"SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS " +
                $"WHERE TABLE_NAME LIKE '{tableName}';";

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtSchema = new DataTable();
            da.Fill(dtSchema);

            // Build the SELECT query with the WHERE clause to fetch data by ID
            string selectQuery = $"SELECT * FROM {tableName} WHERE {tableName.Replace("TABLE_", "")}_ID = @ID";
            SqlCommand selectCmd = new SqlCommand(selectQuery, con);
            selectCmd.Parameters.AddWithValue("@ID", id);
            SqlDataAdapter selectDa = new SqlDataAdapter(selectCmd);
            DataTable dtData = new DataTable();
            selectDa.Fill(dtData);

            //msgDialog.Parent = frm;

            // Check if data was found for the given ID
            if (dtData.Rows.Count > 0)
            {
                DataRow dataRow = dtData.Rows[0];

                // Loop through the form controls and set values based on column names
                foreach (Control control in frm.Controls)
                {
                    if (control is Guna2TextBox || control is Guna2ComboBox || control is Guna2PictureBox)
                    {
                        string columnName = "";
                        if (control is Guna2TextBox)
                            columnName = tableName.Replace("TABLE_", "") + "_" + control.Name.Trim().Replace("txt", "").ToUpper();
                        else if (control is Guna2ComboBox)
                            columnName = tableName + "_" + control.Name.Trim().Replace("cb", "").ToUpper();
                        else if (control is Guna2PictureBox && control.Tag != null)
                            columnName = tableName.Replace("TABLE_", "") + "_" + control.Name.Trim().Replace("pb", "").ToUpper();
                            
                        if (dtData.Columns.Contains(columnName))
                        {
                            // Set the value based on the data type
                            if (control is Guna2TextBox)
                            {
                                Guna2TextBox textBox = control as Guna2TextBox;
                                if (control.Tag.ToString() == "n")
                                    textBox.Text = Convert.ToInt64(dataRow[columnName].ToString()).ToString("N0");
                                else
                                    textBox.Text = dataRow[columnName].ToString();
                            }
                            else if (control is Guna2ComboBox)
                            {
                                Guna2ComboBox comboBox = control as Guna2ComboBox;
                                if (control.Tag.ToString() == "n")
                                    comboBox.Text = Convert.ToInt64(dataRow[columnName].ToString()).ToString("N0");
                                else
                                    comboBox.Text = dataRow[columnName].ToString();
                            }
                            else if (control is Guna2PictureBox && control.Tag != null)
                            {
                                Guna2PictureBox pb = control as Guna2PictureBox;
                                byte[] imageByteArray = (byte[])(dataRow[columnName]);

                                pb.Image = Image.FromStream(new MemoryStream(imageByteArray));
                            }
                        }
                    }
                }
                //msgDialog.Show("저장하였습니다.");
            }
            else
            {
                //msgDialog.Show("해당 ID에 대한 데이터를 찾을 수 없습니다.");
            }
        }

        public static int AutoSQL2(Form frm, string mainTable, string detailTable, DataGridView gv, int id, eumType type)
        {
            #region MessageBox setting
            Guna2MessageDialog dialog = new Guna2MessageDialog()
            {
                Parent = frm,
                Style = MessageDialogStyle.Dark,
                Caption = "결제 시스템",
                Icon = MessageDialogIcon.None
            };
            #endregion

            SqlCommand cmd = new SqlCommand();
            int sqlResult = 0;

            // Build the SELECT query to retrieve column names and data types
            string columnQuery = $"SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @TableName";
            SqlCommand columnCmd = new SqlCommand(columnQuery, con);
            columnCmd.Parameters.AddWithValue("@TableName", mainTable);
            SqlDataAdapter columnDa = new SqlDataAdapter(columnCmd);
            DataTable dtColumns = new DataTable();
            columnDa.Fill(dtColumns);

            if (dtColumns.Rows.Count == 0)
            {
                dialog.Show($"테이블 '{mainTable}'의 열을 찾을 수 없습니다.");
                return sqlResult;
            }

            string query = "";

            switch (type)
            {
                case eumType.Insert:
                    // Build the INSERT query dynamically
                    query = $"INSERT INTO {mainTable} (";
                    foreach (DataRow row in dtColumns.Rows)
                    {
                        string columnName = row["COLUMN_NAME"].ToString();
                        if (columnName != $"{mainTable}_ID") // Exclude primary key column
                        {
                            query += $"{columnName}, ";
                        }
                    }
                    query = query.TrimEnd(',', ' ') + ") VALUES (";
                    foreach (DataRow row in dtColumns.Rows)
                    {
                        string columnName = row["COLUMN_NAME"].ToString();
                        if (columnName != $"{mainTable}_ID") // Exclude primary key column
                        {
                            query += $"@{columnName}, ";
                        }
                    }
                    query = query.TrimEnd(',', ' ') + ");";
                    break;
                case eumType.Update:
                    // Build the UPDATE query dynamically
                    query = $"UPDATE {mainTable} SET ";
                    foreach (DataRow row in dtColumns.Rows)
                    {
                        string columnName = row["COLUMN_NAME"].ToString();
                        if (columnName != $"{mainTable}_ID") // Exclude primary key column
                        {
                            query += $"{columnName} = @{columnName}, ";
                        }
                    }
                    query = query.TrimEnd(',', ' ') + $" WHERE {mainTable}_ID = @ID;";
                    break;
                case eumType.Delete:
                    query = $"DELETE FROM {mainTable} WHERE {mainTable}_ID = @ID;";
                    break;
                default:
                    return sqlResult;
            }

            cmd.CommandText = query;
            cmd.Connection = con;

            // Add parameters for the main table
            cmd.Parameters.AddWithValue("@ID", id);

            foreach (DataRow row in dtColumns.Rows)
            {
                string columnName = row["COLUMN_NAME"].ToString();
                string dataType = row["DATA_TYPE"].ToString();

                // Exclude primary key column for INSERT and UPDATE operations
                if (columnName != $"{mainTable}_ID")
                {
                    if (frm.Controls.Find(columnName, true).Length > 0)
                    {
                        Control control = frm.Controls.Find(columnName, true)[0];

                        if (control is Guna2TextBox)
                        {
                            Guna2TextBox textBox = control as Guna2TextBox;
                            cmd.Parameters.AddWithValue($"@{columnName}", textBox.Text);
                        }
                        else if (control is Guna2ComboBox)
                        {
                            Guna2ComboBox comboBox = control as Guna2ComboBox;
                            cmd.Parameters.AddWithValue($"@{columnName}", comboBox.Text);
                        }
                        // Add more cases for other control types if needed
                    }
                }
            }

            try
            {
                con.Open();
                sqlResult = cmd.ExecuteNonQuery();
                con.Close();

                if (sqlResult > 0)
                {
                    //msgDialog.Show($"{type} 작업이 성공하였습니다.");
                }
            }
            catch (Exception ex)
            {
                dialog.Show($" Exception : {ex.Message}");
            }

            return sqlResult;
        }

        public static void AutoLoadForEdit2(Form frm, string mainTable, string detailQuery, DataGridView gv, int id)
        {
            #region MessageBox setting
            Guna2MessageDialog dialog = new Guna2MessageDialog()
            {
                Parent = frm,
                Style = MessageDialogStyle.Dark,
                Caption = "결제 시스템",
                Icon = MessageDialogIcon.None
            };
            #endregion

            string mainSelectQuery =
                $"SELECT {mainTable}.*, {detailQuery} " +
                $"FROM {mainTable} " +
                $"INNER JOIN {mainTable}_DETAIL ON {mainTable}.MAIN_ID = {mainTable}_DETAIL.MAIN_ID " +
                $"WHERE {mainTable}.MAIN_ID = @ID";

            SqlCommand mainCmd = new SqlCommand(mainSelectQuery, con);
            mainCmd.Parameters.AddWithValue("@ID", id);

            SqlDataAdapter mainDa = new SqlDataAdapter(mainCmd);
            DataTable dtData = new DataTable();
            mainDa.Fill(dtData);
            //msgDialog.Parent = frm;

            if (dtData.Rows.Count > 0)
            {
                DataRow dataRow = dtData.Rows[0];

                // Loop through the form controls and set values based on column names
                foreach (Control control in frm.Controls)
                {
                    if (control is Guna2TextBox || control is Guna2ComboBox)
                    {
                        string columnName = control.Name;

                        // Set the value based on the data type
                        if (dtData.Columns.Contains(columnName))
                        {
                            if (control is Guna2TextBox)
                            {
                                Guna2TextBox textBox = control as Guna2TextBox;
                                textBox.Text = dataRow[columnName].ToString();
                            }
                            else if (control is Guna2ComboBox)
                            {
                                Guna2ComboBox comboBox = control as Guna2ComboBox;
                                comboBox.Text = dataRow[columnName].ToString();
                            }
                        }
                    }
                }
                //msgDialog.Show("수정하였습니다.");
            }
            else
            {
                dialog.Show("해당 ID에 대한 데이터를 찾을 수 없습니다.");
            }
        }

        /// <summary>
        /// 테이블에 같은 값이 존재하는가를 체크
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="columnName"></param>
        /// <param name="columnValue"></param>
        /// <param name="dgv"></param>
        /// <returns>Type: int, 0이면 중복X, 1이면 중복O</returns>
        public static int GetDuplicate(string tableName, string columnName, string columnValue, Guna2DataGridView dgv)
        {
            string qry =
                $"SELECT * FROM {tableName} " +
                $"WHERE {columnName} = '{columnValue}';";
            DataTable dt = GetData(qry);
            dgv.DataSource = dt;

            return dt.Rows.Count;
        }

        public static void SrNo(Guna2DataGridView gv)
        {
            Guna2MessageDialog dialog = new Guna2MessageDialog()
            {
                //Parent = ,
                Style = MessageDialogStyle.Dark,
                Caption = "결제 시스템",
                Icon = MessageDialogIcon.None,
            };

            try
            {
                int count = 0;
                foreach (DataGridViewRow row in gv.Rows)
                {
                    count++;
                    row.Cells[0].Value = count;
                }
            }
            catch (Exception ex)
            {
                dialog.Show(ex.ToString());
                con.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="F"></param>
        /// <param name="col"></param>
        /// <param name="font"></param>
        /// <param name="px"></param>
        /// <param name="py"></param>
        /// <returns></returns>
        public static bool Validate(Form F, eumType type, Color col, Font font, int px, int py, string alpha2_Code, string numeric_Code, bool isAvailableID)
        {
            bool isValid = true;
            int count = 0;
            int x;
            int y;
            int rad;
            Font lblFont = font;
            Color vColor = col;

            var dynamicLabels = F.Controls.OfType<Label>().Where(c => c.Tag != null && c.Tag.ToString() == "remove").ToList();
            foreach (var lbl in dynamicLabels)
            {
                F.Controls.Remove(lbl);
            }

            foreach (Control c in F.Controls)
            {
                if (c is Guna2Button)
                {

                }
                else
                {
                    if (c.Tag == null || c.Tag.ToString() == string.Empty)
                    {
                        if (c is Guna2TextBox)
                        {
                            Guna2TextBox t = c as Guna2TextBox;
                            t.BorderColor = Color.Red;
                            t.FocusedState.BorderColor = Color.Red;
                            t.HoverState.BorderColor = Color.Red;
                        }
                        else if (c is Guna2ComboBox)
                        {
                            Guna2ComboBox t = c as Guna2ComboBox;
                            t.BorderColor = Color.Red;
                            t.FocusedState.BorderColor = Color.Red;
                            t.HoverState.BorderColor = Color.Red;
                        }
                    }
                    else
                    {
                        if (c is Guna2TextBox)
                        {
                            Guna2TextBox t = c as Guna2TextBox;
                            t.BorderColor = Color.FromArgb(213, 218, 223);
                            t.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
                            t.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
                        }
                        else if (c is Guna2ComboBox)
                        {
                            Guna2ComboBox t = c as Guna2ComboBox;
                            t.BorderColor = Color.FromArgb(213, 218, 223);
                            t.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
                            t.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
                        }
                        Label lbl = new Label
                        {
                            Font = lblFont,
                            AutoSize = true
                        };

                        // TextBox
                        if (c is Guna2TextBox)
                        {
                            Guna2TextBox t = c as Guna2TextBox;
                            if (t.AutoRoundedCorners == true || t.BorderRadius > 0)
                            {
                                rad = (int)((t.BorderRadius / 2) + 0.5);
                                x = int.Parse(c.Location.X.ToString()) + px + int.Parse(rad.ToString());
                                y = int.Parse(c.Location.Y.ToString()) + int.Parse(c.Height.ToString()) + py;
                            }
                            else
                            {
                                x = int.Parse(c.Location.X.ToString()) + px;
                                y = int.Parse(c.Location.Y.ToString()) + int.Parse(c.Height.ToString()) + py;
                            }
                            if (t.Tag.ToString() == "s" && t.Text.Trim() == "")
                            {
                                Regex regex = new Regex(@"^[a-zA-Z][a-zA-Z ]*$");
                                Match match = regex.Match(t.Text);
                                if (match.Success) { }
                                else
                                {
                                    // validate label
                                    string cname = "vlbl" + c.Name;
                                    lbl.Name = cname;
                                    lbl.Tag = "remove";
                                    lbl.Text = "알 수 없는 문자열 형식";
                                    lbl.ForeColor = vColor;
                                    lbl.Font = lblFont;
                                    F.Controls.Add(lbl);

                                    lbl.Location = new Point(x, y);

                                    t.BorderColor = Color.Red;
                                    t.FocusedState.BorderColor = Color.Red;
                                    t.HoverState.BorderColor = Color.Red;

                                    count++;
                                }
                            }
                        }

                        // id
                        if (c is Guna2TextBox)
                        {
                            Guna2TextBox t = c as Guna2TextBox;
                            if (t.AutoRoundedCorners == true || t.BorderRadius > 0)
                            {
                                rad = (int)((t.BorderRadius / 2) + 0.5);
                                x = int.Parse(c.Location.X.ToString()) + px + int.Parse(rad.ToString());
                                y = int.Parse(c.Location.Y.ToString()) + int.Parse(c.Height.ToString()) + py;
                            }
                            else
                            {
                                x = int.Parse(c.Location.X.ToString()) + px;
                                y = int.Parse(c.Location.Y.ToString()) + int.Parse(c.Height.ToString()) + py;
                            }
                            if (t.Tag.ToString() == "id")
                            {
                                Regex regex = new Regex(@"^([a-zA-Z]+)(([a-zA-Z0-9]{5,19})+)$");
                                Match match = regex.Match(t.Text);
                                if (match.Success && isAvailableID) { }
                                else
                                {
                                    lbl.Name = t.Tag.ToString() + "lbl" + c.Name;
                                    lbl.Tag = "remove";
                                    if (!isAvailableID)
                                        lbl.Text = "사용하고 있는 아이디입니다.";
                                    else
                                        lbl.Text = "알 수 없는 아이디 형식";
                                    lbl.ForeColor = vColor;
                                    lbl.Font = lblFont;
                                    F.Controls.Add(lbl);

                                    lbl.Location = new Point(x, y);

                                    t.BorderColor = Color.Red;
                                    t.FocusedState.BorderColor = Color.Red;
                                    t.HoverState.BorderColor = Color.Red;

                                    count++;
                                }
                            }
                        }

                        // Password
                        if (c is Guna2TextBox)
                        {
                            Guna2TextBox t = c as Guna2TextBox;
                            if (t.AutoRoundedCorners == true || t.BorderRadius > 0)
                            {
                                rad = (int)((t.BorderRadius / 2) + 0.5);
                                x = int.Parse(c.Location.X.ToString()) + px + int.Parse(rad.ToString());
                                y = int.Parse(c.Location.Y.ToString()) + int.Parse(c.Height.ToString()) + py;
                            }
                            else
                            {
                                x = int.Parse(c.Location.X.ToString()) + px;
                                y = int.Parse(c.Location.Y.ToString()) + int.Parse(c.Height.ToString()) + py;
                            }
                            // 8 ~ 16자 영문, 숫자, 특수문자를 최소 한가지씩 조합
                            if (t.Tag.ToString() == "pass")
                            {
                                Regex regex = new Regex(@"^(?=.*[a-zA-z])(?=.*[0-9])(?=.*[$`~!@$!%*#^?&\\(\\)\-_=+]).{8,16}$");
                                Match match = regex.Match(t.Text);
                                if (match.Success) { }
                                else
                                {
                                    lbl.Name = t.Tag.ToString() + "lbl" + c.Name;
                                    lbl.Tag = "remove";
                                    lbl.Text = "알 수 없는 비밀번호 형식";
                                    lbl.ForeColor = vColor;
                                    lbl.Font = lblFont;
                                    F.Controls.Add(lbl);

                                    lbl.Location = new Point(x, y);

                                    t.BorderColor = Color.Red;
                                    t.FocusedState.BorderColor = Color.Red;
                                    t.HoverState.BorderColor = Color.Red;

                                    count++;
                                }
                            }
                        }

                        // Email
                        if (c is Guna2TextBox)
                        {
                            Guna2TextBox t = c as Guna2TextBox;
                            if (t.AutoRoundedCorners == true || t.BorderRadius > 0)
                            {
                                rad = (int)((t.BorderRadius / 2) + 0.5);
                                x = int.Parse(c.Location.X.ToString()) + px + int.Parse(rad.ToString());
                                y = int.Parse(c.Location.Y.ToString()) + int.Parse(c.Height.ToString()) + py;
                            }
                            else
                            {
                                x = int.Parse(c.Location.X.ToString()) + px;
                                y = int.Parse(c.Location.Y.ToString()) + int.Parse(c.Height.ToString()) + py;
                            }
                            if (t.Tag.ToString() == "e")
                            {
                                Regex regex = new Regex(@"^[0-9a-zA-Z]([-_\.]?[0-9a-zA-Z])*@[0-9a-zA-Z]([-_\.]?[0-9a-zA-Z])*\.[a-zA-Z]{2,3}$");
                                Match match = regex.Match(t.Text);
                                if (match.Success) { }
                                else
                                {
                                    string cname = t.Tag.ToString() + "lbl" + c.Name;
                                    lbl.Name = cname;
                                    lbl.Tag = "remove";
                                    lbl.Text = "알 수 없는 이메일 형식";
                                    lbl.ForeColor = vColor;
                                    lbl.Font = lblFont;
                                    F.Controls.Add(lbl);

                                    lbl.Location = new Point(x, y);

                                    t.BorderColor = Color.Red;
                                    t.FocusedState.BorderColor = Color.Red;
                                    t.HoverState.BorderColor = Color.Red;

                                    count++;
                                }
                            }
                        }

                        // Number
                        if (c is Guna2TextBox)
                        {
                            Guna2TextBox t = c as Guna2TextBox;
                            if (t.AutoRoundedCorners == true || t.BorderRadius > 0)
                            {
                                rad = (int)((t.BorderRadius / 2) + 0.5);
                                x = int.Parse(c.Location.X.ToString()) + px + int.Parse(rad.ToString());
                                y = int.Parse(c.Location.Y.ToString()) + int.Parse(c.Height.ToString()) + py;
                            }
                            else
                            {
                                x = int.Parse(c.Location.X.ToString()) + px;
                                y = int.Parse(c.Location.Y.ToString()) + int.Parse(c.Height.ToString()) + py;
                            }
                            if (t.Tag.ToString() == "n")
                            {
                                Regex regex = new Regex(@"^-?[0-9][0-9,\.]+$");
                                Match match = regex.Match(t.Text.Replace(",", ""));
                                if (match.Success) { }
                                else
                                {
                                    string cname = t.Tag.ToString() + "nlbl" + c.Name;
                                    lbl.Name = cname;
                                    lbl.Tag = "remove";
                                    lbl.Text = "알 수 없는 숫자 형식";
                                    lbl.ForeColor = vColor;
                                    lbl.Font = lblFont;
                                    F.Controls.Add(lbl);

                                    lbl.Location = new Point(x, y);

                                    t.BorderColor = Color.Red;
                                    t.FocusedState.BorderColor = Color.Red;
                                    t.HoverState.BorderColor = Color.Red;

                                    count++;
                                }
                            }
                        }

                        // Phone Number
                        if (c is Guna2TextBox)
                        {
                            Guna2TextBox t = c as Guna2TextBox;
                            if (t.AutoRoundedCorners == true || t.BorderRadius > 0)
                            {
                                rad = (int)((t.BorderRadius / 2) + 0.5);
                                x = int.Parse(c.Location.X.ToString()) + px + int.Parse(rad.ToString());
                                y = int.Parse(c.Location.Y.ToString()) + int.Parse(c.Height.ToString()) + py;
                            }
                            else
                            {
                                x = int.Parse(c.Location.X.ToString()) + px;
                                y = int.Parse(c.Location.Y.ToString()) + int.Parse(c.Height.ToString()) + py;
                            }
                            if (t.Tag.ToString() == "p")
                            {
                                // 미국식 전화번호
                                //Regex regex = new Regex(@"^([+]?1[\s]?)?((?:[(](?:[2-9]1[02-9]|[2-9][02-8][0-9])[)][\s]?)|(?:(?:[2-9]1[02-9]|[2-9][02-8][0-9])[\s.-]?)){1}([2-9]1[02-9]|[2-9][02-9]1|[2-9][02-9]{2}[\s.-]?){1}([0-9]{4}){1}$");
                                //Regex regex = new Regex(@"^([2-6]\d{3}-\d{4})|(0[1-5]\d-\d{4}-\d{4})|(0\d{2}-\d{3}-\d{7})|(00\d{1,3}-\d{3}-\d{7})|\((0\d{2})-1\d{3}\)$");
                                //Match match = regex.Match(t.Text);
                                //if (match.Success) { }

                                if (IsValPhoneNumber(t, type, alpha2_Code, numeric_Code)) { }
                                else
                                {
                                    string cname = t.Tag.ToString() + "nlbl" + c.Name;
                                    lbl.Name = cname;
                                    lbl.Tag = "remove";
                                    lbl.Text = "알 수 없는 전화번호 형식";
                                    lbl.ForeColor = vColor;
                                    lbl.Font = lblFont;
                                    F.Controls.Add(lbl);

                                    lbl.Location = new Point(x, y);

                                    t.BorderColor = Color.Red;
                                    t.FocusedState.BorderColor = Color.Red;
                                    t.HoverState.BorderColor = Color.Red;

                                    count++;
                                }
                            }
                        }

                        // Image
                        if (c is Guna2PictureBox)
                        {
                            Guna2PictureBox t = c as Guna2PictureBox;
                            if (t.AutoRoundedCorners == true || t.BorderRadius > 0)
                            {
                                rad = (int)((t.BorderRadius / 2) + 0.5);
                                x = int.Parse(c.Location.X.ToString()) + int.Parse(rad.ToString());
                                y = int.Parse(c.Location.Y.ToString()) + int.Parse(c.Height.ToString()) + py + 60;
                            }
                            else
                            {
                                // TOTO : 11 상수 dynamic 처리 필요
                                x = int.Parse(c.Location.X.ToString()) - 11;
                                y = int.Parse(c.Location.Y.ToString()) + int.Parse(c.Height.ToString()) + py + 60;
                            }
                            if (t.Tag.ToString() == "Image")
                            {
                                if (t.Image != img) { }
                                else
                                {
                                    string cname = t.Tag.ToString() + "nlbl" + c.Name;
                                    lbl.Name = cname;
                                    lbl.Tag = "remove";
                                    lbl.Text = "알 수 없는 이미지 형식";
                                    lbl.ForeColor = vColor;
                                    lbl.Font = lblFont;
                                    lbl.AutoSize = false;
                                    lbl.TextAlign = ContentAlignment.TopCenter;
                                    lbl.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                                    F.Controls.Add(lbl);

                                    lbl.Location = new Point(x, y);
                                    lbl.Size = new Size(130, 20);
                                    count++;
                                }
                            }
                        }

                        // Address
                        if (c is Guna2TextBox)
                        {
                            Guna2TextBox t = c as Guna2TextBox;
                            if (t.AutoRoundedCorners == true || t.BorderRadius > 0)
                            {
                                rad = (int)((t.BorderRadius / 2) + 0.5);
                                x = int.Parse(c.Location.X.ToString()) + px + int.Parse(rad.ToString());
                                y = int.Parse(c.Location.Y.ToString()) + int.Parse(c.Height.ToString()) + py;
                            }
                            else
                            {
                                x = int.Parse(c.Location.X.ToString()) + px;
                                y = int.Parse(c.Location.Y.ToString()) + int.Parse(c.Height.ToString()) + py;
                            }
                            if (t.Tag.ToString() == "address")
                            {
                                if (t.Text != null || t.Text != "") { }
                                else
                                {
                                    string cname = t.Tag.ToString() + "nlbl" + c.Name;
                                    lbl.Name = cname;
                                    lbl.Tag = "remove";
                                    lbl.Text = "알 수 없는 주소 형식";
                                    lbl.ForeColor = vColor;
                                    lbl.Font = lblFont;
                                    F.Controls.Add(lbl);

                                    lbl.Location = new Point(x, y);

                                    t.BorderColor = Color.Red;
                                    t.FocusedState.BorderColor = Color.Red;
                                    t.HoverState.BorderColor = Color.Red;

                                    count++;
                                }
                            }
                        }

                        // Date
                        if (c is Guna2TextBox)
                        {
                            Guna2TextBox t = c as Guna2TextBox;
                            if (t.AutoRoundedCorners == true || t.BorderRadius > 0)
                            {
                                rad = (int)((t.BorderRadius / 2) + 0.5);
                                x = int.Parse(c.Location.X.ToString()) + px + int.Parse(rad.ToString());
                                y = int.Parse(c.Location.Y.ToString()) + int.Parse(c.Height.ToString()) + py;
                            }
                            else
                            {
                                x = int.Parse(c.Location.X.ToString()) + px;
                                y = int.Parse(c.Location.Y.ToString()) + int.Parse(c.Height.ToString()) + py;
                            }
                            if (t.Tag.ToString() == "d")
                            {
                                DateTime dt = new DateTime(1990, 1, 1).Date;
                                Regex regex = new Regex("([0]?[0-9]|[12][0-9]|[3][01])[./-]([0]?[1-9]|[1][0-2])[./-]([0-9]{4}|[0-9]{2})$");
                                Match match = regex.Match(t.Text);
                                DateTime.TryParse(t.Text, out dt);
                                if (match.Success && dt != new DateTime(0001, 1, 1).Date)
                                {
                                    int len = t.Text.Length;
                                    if (len != 10)
                                    {
                                        string cname = t.Tag.ToString() + "lbl" + c.Name;
                                        lbl.Name = cname;
                                        lbl.Tag = "remove";
                                        lbl.ForeColor = vColor;
                                        lbl.Font = lblFont;
                                        F.Controls.Add(lbl);
                                        lbl.Location = new Point(x, y);
                                        count++;
                                    }
                                }
                                else
                                {
                                    string cname = t.Tag.ToString() + "lbl" + c.Name;
                                    lbl.Name = cname;
                                    lbl.Tag = "remove";
                                    lbl.Text = "알 수 없는 Date형식";
                                    lbl.ForeColor = vColor;
                                    lbl.Font = lblFont;
                                    F.Controls.Add(lbl);

                                    lbl.Location = new Point(x, y);

                                    t.BorderColor = Color.Red;
                                    t.FocusedState.BorderColor = Color.Red;
                                    t.HoverState.BorderColor = Color.Red;

                                    count++;
                                }
                            }
                        }

                        // ComboBox
                        if (c is Guna2ComboBox)
                        {
                            Guna2ComboBox t = c as Guna2ComboBox;
                            if (t.AutoRoundedCorners == true || t.BorderRadius > 0)
                            {
                                rad = (int)((t.BorderRadius / 2) + 0.5);
                                x = int.Parse(c.Location.X.ToString()) + px + int.Parse(rad.ToString());
                                y = int.Parse(c.Location.Y.ToString()) + int.Parse(c.Height.ToString()) + py;
                            }
                            else
                            {
                                x = int.Parse(c.Location.X.ToString()) + px;
                                y = int.Parse(c.Location.Y.ToString()) + int.Parse(c.Height.ToString()) + py;
                            }
                            if (t.Tag.ToString() == "cb" && t.Text == "")
                            {
                                string cname = t.Tag.ToString() + "cb" + c.Name;
                                lbl.Name = cname;
                                lbl.Tag = "remove";
                                lbl.Text = "데이터를 선택하여 주세요.";
                                lbl.ForeColor = vColor;
                                lbl.Font = lblFont;
                                F.Controls.Add(lbl);

                                lbl.Location = new Point(x, y);

                                t.BorderColor = Color.Red;
                                t.FocusedState.BorderColor = Color.Red;
                                t.HoverState.BorderColor = Color.Red;

                                count++;
                            }
                        }
                    }
                }
            }

            if (count == 0)
            {
                isValid = true;
            }
            else
            {
                isValid = false;
            }
            return isValid;
        }

        private static bool IsValPhoneNumber(Guna2TextBox t, eumType type, string alpha2_Code, string numeric_Code)
        {
            bool isValPhoneNumber = false;
            PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();

            try
            {
                PhoneNumber number = phoneUtil.Parse(t.Text, alpha2_Code);
                if (type == eumType.Insert || type == eumType.Update)
                {
                    t.Text = phoneUtil.Format(number, PhoneNumberFormat.INTERNATIONAL);
                }

                isValPhoneNumber = true;
            }
            catch (NumberParseException)
            {
                t.Text = numeric_Code;
            }

            return isValPhoneNumber;
        }

        public static void Reset_All(Form p)
        {
            foreach (Control c in p.Controls)
            {
                if (c is Guna2TextBox)
                {
                    Guna2TextBox t = c as Guna2TextBox;

                    t.Text = "";
                }

                if (c is Guna2ComboBox)
                {
                    Guna2ComboBox cb = c as Guna2ComboBox;

                    cb.SelectedIndex = 0;
                    cb.SelectedIndex = -1;
                }

                if (c is Guna2RadioButton)
                {
                    Guna2RadioButton rb = c as Guna2RadioButton;

                    rb.Checked = false;
                }

                if (c is Guna2CheckBox)
                {
                    Guna2CheckBox rb = c as Guna2CheckBox;

                    rb.Checked = false;
                }

                if (c is Guna2DateTimePicker)
                {
                    Guna2DateTimePicker dp = c as Guna2DateTimePicker;

                    dp.Value = DateTime.Today;
                }

                if (c is ListBox)
                {
                    ListBox list = c as ListBox;
                }

                if (c is NumericUpDown)
                {
                    NumericUpDown nud = c as NumericUpDown;
                    nud.Value = 0;
                }

                if (c is MaskedTextBox)
                {
                    MaskedTextBox mt = c as MaskedTextBox;
                    mt.Text = "";
                }

                if (c is PictureBox)
                {
                    PictureBox pb = c as PictureBox;
                    pb.Image = null;
                }
            }
        }

        public static async Task BrowsePicture(Guna2PictureBox pbImage)
        {
            await Task.Run(() =>
            {
                OpenFileDialog ofd = new OpenFileDialog()
                {
                    Filter = "Images(*.BMP; *.JPG; *.PNG; *.GIF) | *.BMP; *.JPG; *.PNG; *.GIF"
                };
                DialogResult dr = ofd.ShowDialog(pbImage.Parent);
                if (dr == DialogResult.OK)
                {
                    filePath = ofd.FileName;
                    pbImage.Image = new Bitmap(filePath);
                    
                }
                else
                {
                    return;
                }
            });
        }

        public static string user;

        public static string USER
        {
            get { return user; }
            private set { user = value; }
        }

        public static Image img;

        public static Image IMG
        {
            get { return img; }
            private set { img = value; }
        }
    }
}
