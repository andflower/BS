namespace BS
{
    partial class SampleView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SampleView));
            this.paTop = new Guna.UI2.WinForms.Guna2Panel();
            this.btnViewAdd = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblContext = new System.Windows.Forms.Label();
            this.paTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnViewAdd)).BeginInit();
            this.SuspendLayout();
            // 
            // paTop
            // 
            this.paTop.Controls.Add(this.btnViewAdd);
            this.paTop.Controls.Add(this.lblSearch);
            this.paTop.Controls.Add(this.txtSearch);
            this.paTop.Controls.Add(this.lblContext);
            this.paTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.paTop.Location = new System.Drawing.Point(0, 0);
            this.paTop.Name = "paTop";
            this.paTop.Size = new System.Drawing.Size(1720, 220);
            this.paTop.TabIndex = 0;
            // 
            // btnViewAdd
            // 
            this.btnViewAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnViewAdd.FillColor = System.Drawing.Color.Transparent;
            this.btnViewAdd.Image = global::BS.Properties.Resources.plus;
            this.btnViewAdd.ImageRotate = 0F;
            this.btnViewAdd.Location = new System.Drawing.Point(1620, 140);
            this.btnViewAdd.Margin = new System.Windows.Forms.Padding(0, 0, 50, 30);
            this.btnViewAdd.Name = "btnViewAdd";
            this.btnViewAdd.Size = new System.Drawing.Size(50, 50);
            this.btnViewAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnViewAdd.TabIndex = 4;
            this.btnViewAdd.TabStop = false;
            this.btnViewAdd.UseTransparentBackground = true;
            this.btnViewAdd.Click += new System.EventHandler(this.btnViewAdd_Click);
            // 
            // lblSearch
            // 
            this.lblSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSearch.BackColor = System.Drawing.Color.Transparent;
            this.lblSearch.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSearch.Location = new System.Drawing.Point(50, 95);
            this.lblSearch.Margin = new System.Windows.Forms.Padding(50, 0, 0, 5);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(55, 40);
            this.lblSearch.TabIndex = 3;
            this.lblSearch.Text = "검색";
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSearch.Animated = true;
            this.txtSearch.BackColor = System.Drawing.Color.Transparent;
            this.txtSearch.BorderColor = System.Drawing.Color.Silver;
            this.txtSearch.BorderRadius = 21;
            this.txtSearch.BorderThickness = 3;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.txtSearch.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.txtSearch.ForeColor = System.Drawing.Color.White;
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.txtSearch.IconLeftOffset = new System.Drawing.Point(10, 0);
            this.txtSearch.IconLeftSize = new System.Drawing.Size(25, 25);
            this.txtSearch.IconRight = ((System.Drawing.Image)(resources.GetObject("txtSearch.IconRight")));
            this.txtSearch.IconRightOffset = new System.Drawing.Point(10, 0);
            this.txtSearch.Location = new System.Drawing.Point(36, 140);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(27, 0, 0, 30);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.txtSearch.PlaceholderText = "여기에 검색";
            this.txtSearch.SelectedText = "";
            this.txtSearch.ShadowDecoration.BorderRadius = 26;
            this.txtSearch.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.txtSearch.ShadowDecoration.Depth = 15;
            this.txtSearch.ShadowDecoration.Enabled = true;
            this.txtSearch.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(8);
            this.txtSearch.Size = new System.Drawing.Size(330, 50);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextOffset = new System.Drawing.Point(10, 0);
            this.txtSearch.IconRightClick += new System.EventHandler(this.txtSearch_IconRightClick);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSearch_MouseClick);
            // 
            // lblContext
            // 
            this.lblContext.BackColor = System.Drawing.Color.Transparent;
            this.lblContext.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblContext.Location = new System.Drawing.Point(50, 30);
            this.lblContext.Margin = new System.Windows.Forms.Padding(30, 30, 0, 30);
            this.lblContext.Name = "lblContext";
            this.lblContext.Size = new System.Drawing.Size(250, 40);
            this.lblContext.TabIndex = 1;
            this.lblContext.Text = "Sample View 머리말";
            this.lblContext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SampleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1720, 1020);
            this.Controls.Add(this.paTop);
            this.Name = "SampleView";
            this.Text = "SampleView";
            this.paTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnViewAdd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Guna.UI2.WinForms.Guna2Panel paTop;
        public System.Windows.Forms.Label lblContext;
        public Guna.UI2.WinForms.Guna2TextBox txtSearch;
        public System.Windows.Forms.Label lblSearch;
        public Guna.UI2.WinForms.Guna2PictureBox btnViewAdd;
    }
}