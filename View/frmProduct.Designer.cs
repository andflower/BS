namespace BS.View
{
    partial class frmProduct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GunaDGVuser = new BS.AnimatedDataGridView();
            this.dgvID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.paTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnViewAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GunaDGVuser)).BeginInit();
            this.SuspendLayout();
            // 
            // lblContext
            // 
            this.lblContext.Text = "상품 목록";
            // 
            // txtSearch
            // 
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.txtSearch.ShadowDecoration.BorderRadius = 26;
            this.txtSearch.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.txtSearch.ShadowDecoration.Depth = 15;
            this.txtSearch.ShadowDecoration.Enabled = true;
            this.txtSearch.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(8);
            // 
            // btnViewAdd
            // 
            this.btnViewAdd.ImageFlip = Guna.UI2.WinForms.Enums.FlipOrientation.Normal;
            // 
            // GunaDGVuser
            // 
            this.GunaDGVuser.AllowUserToAddRows = false;
            this.GunaDGVuser.AllowUserToDeleteRows = false;
            this.GunaDGVuser.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(38)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.GunaDGVuser.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.GunaDGVuser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GunaDGVuser.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
            this.GunaDGVuser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GunaDGVuser.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.GunaDGVuser.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.GunaDGVuser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GunaDGVuser.ColumnHeadersHeight = 25;
            this.GunaDGVuser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.GunaDGVuser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvID,
            this.dgvProductID,
            this.dgvName,
            this.dgvPrice,
            this.dgvCost,
            this.dgvImage});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GunaDGVuser.DefaultCellStyle = dataGridViewCellStyle6;
            this.GunaDGVuser.EnableHeadersVisualStyles = false;
            this.GunaDGVuser.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.GunaDGVuser.Location = new System.Drawing.Point(39, 250);
            this.GunaDGVuser.Margin = new System.Windows.Forms.Padding(30, 30, 30, 0);
            this.GunaDGVuser.Name = "GunaDGVuser";
            this.GunaDGVuser.ReadOnly = true;
            this.GunaDGVuser.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GunaDGVuser.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.GunaDGVuser.RowHeadersVisible = false;
            this.GunaDGVuser.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.GunaDGVuser.RowTemplate.Height = 60;
            this.GunaDGVuser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GunaDGVuser.Size = new System.Drawing.Size(1100, 500);
            this.GunaDGVuser.TabIndex = 3;
            this.GunaDGVuser.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.GunaDGVuser.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.GunaDGVuser.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.White;
            this.GunaDGVuser.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.GunaDGVuser.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.White;
            this.GunaDGVuser.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
            this.GunaDGVuser.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.GunaDGVuser.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.GunaDGVuser.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.GunaDGVuser.ThemeStyle.HeaderStyle.Font = null;
            this.GunaDGVuser.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.GunaDGVuser.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.GunaDGVuser.ThemeStyle.HeaderStyle.Height = 25;
            this.GunaDGVuser.ThemeStyle.ReadOnly = true;
            this.GunaDGVuser.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
            this.GunaDGVuser.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.GunaDGVuser.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.GunaDGVuser.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.White;
            this.GunaDGVuser.ThemeStyle.RowsStyle.Height = 60;
            this.GunaDGVuser.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.GunaDGVuser.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            this.GunaDGVuser.DoubleClick += new System.EventHandler(this.GunaDGVuser_DoubleClick);
            // 
            // dgvID
            // 
            this.dgvID.HeaderText = "구 분";
            this.dgvID.Name = "dgvID";
            this.dgvID.ReadOnly = true;
            // 
            // dgvProductID
            // 
            this.dgvProductID.HeaderText = "상품ID";
            this.dgvProductID.Name = "dgvProductID";
            this.dgvProductID.ReadOnly = true;
            this.dgvProductID.Visible = false;
            // 
            // dgvName
            // 
            this.dgvName.HeaderText = "상품명";
            this.dgvName.Name = "dgvName";
            this.dgvName.ReadOnly = true;
            // 
            // dgvPrice
            // 
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.dgvPrice.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPrice.HeaderText = "가격(원)";
            this.dgvPrice.Name = "dgvPrice";
            this.dgvPrice.ReadOnly = true;
            // 
            // dgvCost
            // 
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.dgvCost.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCost.HeaderText = "비용(원)";
            this.dgvCost.Name = "dgvCost";
            this.dgvCost.ReadOnly = true;
            // 
            // dgvImage
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.NullValue = "System.Drawing.Image";
            this.dgvImage.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvImage.HeaderText = "이미지";
            this.dgvImage.Image = global::BS.Properties.Resources.nyancat;
            this.dgvImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dgvImage.Name = "dgvImage";
            this.dgvImage.ReadOnly = true;
            this.dgvImage.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvImage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // frmProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1720, 1020);
            this.Controls.Add(this.GunaDGVuser);
            this.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold);
            this.Name = "frmProduct";
            this.Text = "frmProduct";
            this.Load += new System.EventHandler(this.frmProduct_Load);
            this.Controls.SetChildIndex(this.GunaDGVuser, 0);
            this.Controls.SetChildIndex(this.paTop, 0);
            this.paTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnViewAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GunaDGVuser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private AnimatedDataGridView GunaDGVuser;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCost;
        private System.Windows.Forms.DataGridViewImageColumn dgvImage;
    }
}