namespace BS.Model
{
    partial class frmCustomerAdd
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
            this.qName = new Guna.UI2.WinForms.Guna2PictureBox();
            this.txtName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.qPhone = new Guna.UI2.WinForms.Guna2PictureBox();
            this.txtPhone = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.qCountury = new Guna.UI2.WinForms.Guna2PictureBox();
            this.cbCountury = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblCountury = new System.Windows.Forms.Label();
            this.qEmail = new Guna.UI2.WinForms.Guna2PictureBox();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new Guna.UI2.WinForms.Guna2TextBox();
            this.qAddress = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnAddressSearch = new Guna.UI2.WinForms.Guna2Button();
            this.paTop.SuspendLayout();
            this.paBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qCountury)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qAddress)).BeginInit();
            this.SuspendLayout();
            // 
            // paTop
            // 
            this.paTop.Size = new System.Drawing.Size(850, 100);
            // 
            // paBottom
            // 
            this.paBottom.Location = new System.Drawing.Point(0, 360);
            this.paBottom.Size = new System.Drawing.Size(850, 90);
            // 
            // label1
            // 
            this.label1.Text = "고객 정보";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            // 
            // btnDel
            // 
            this.btnDel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDel.Location = new System.Drawing.Point(770, 20);
            // 
            // qName
            // 
            this.qName.BackColor = System.Drawing.Color.Transparent;
            this.qName.Image = global::BS.Properties.Resources.question;
            this.qName.ImageRotate = 0F;
            this.qName.Location = new System.Drawing.Point(117, 130);
            this.qName.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.qName.Name = "qName";
            this.qName.Size = new System.Drawing.Size(18, 18);
            this.qName.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.qName.TabIndex = 28;
            this.qName.TabStop = false;
            this.qName.UseTransparentBackground = true;
            this.qName.MouseEnter += new System.EventHandler(this.q_MouseEnter);
            this.qName.MouseLeave += new System.EventHandler(this.q_MouseLeave);
            // 
            // txtName
            // 
            this.txtName.BorderRadius = 20;
            this.txtName.BorderThickness = 2;
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.DefaultText = "";
            this.txtName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtName.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.txtName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtName.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.Color.White;
            this.txtName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtName.Location = new System.Drawing.Point(30, 153);
            this.txtName.Margin = new System.Windows.Forms.Padding(30, 4, 5, 0);
            this.txtName.Name = "txtName";
            this.txtName.Padding = new System.Windows.Forms.Padding(0, 0, 0, 60);
            this.txtName.PasswordChar = '\0';
            this.txtName.PlaceholderText = "";
            this.txtName.SelectedText = "";
            this.txtName.Size = new System.Drawing.Size(250, 45);
            this.txtName.TabIndex = 26;
            this.txtName.Tag = "s";
            this.txtName.TextOffset = new System.Drawing.Point(15, 0);
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.object_KeyDown);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblName.Location = new System.Drawing.Point(49, 130);
            this.lblName.Margin = new System.Windows.Forms.Padding(40, 30, 3, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(54, 19);
            this.lblName.TabIndex = 27;
            this.lblName.Text = "고객명";
            // 
            // qPhone
            // 
            this.qPhone.BackColor = System.Drawing.Color.Transparent;
            this.qPhone.Image = global::BS.Properties.Resources.question;
            this.qPhone.ImageRotate = 0F;
            this.qPhone.Location = new System.Drawing.Point(657, 240);
            this.qPhone.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.qPhone.Name = "qPhone";
            this.qPhone.Size = new System.Drawing.Size(18, 18);
            this.qPhone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.qPhone.TabIndex = 31;
            this.qPhone.TabStop = false;
            this.qPhone.UseTransparentBackground = true;
            this.qPhone.MouseEnter += new System.EventHandler(this.q_MouseEnter);
            this.qPhone.MouseLeave += new System.EventHandler(this.q_MouseLeave);
            // 
            // txtPhone
            // 
            this.txtPhone.BorderRadius = 20;
            this.txtPhone.BorderThickness = 2;
            this.txtPhone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPhone.DefaultText = "";
            this.txtPhone.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPhone.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPhone.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPhone.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPhone.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.txtPhone.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPhone.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.ForeColor = System.Drawing.Color.White;
            this.txtPhone.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPhone.Location = new System.Drawing.Point(570, 263);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(10, 4, 0, 0);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.txtPhone.PasswordChar = '\0';
            this.txtPhone.PlaceholderText = "";
            this.txtPhone.SelectedText = "";
            this.txtPhone.Size = new System.Drawing.Size(250, 45);
            this.txtPhone.TabIndex = 29;
            this.txtPhone.Tag = "p";
            this.txtPhone.TextOffset = new System.Drawing.Point(15, 0);
            this.txtPhone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.object_KeyDown);
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.BackColor = System.Drawing.Color.Transparent;
            this.lblPhone.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPhone.Location = new System.Drawing.Point(589, 238);
            this.lblPhone.Margin = new System.Windows.Forms.Padding(40, 40, 3, 0);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(54, 19);
            this.lblPhone.TabIndex = 30;
            this.lblPhone.Text = "연락처";
            // 
            // qCountury
            // 
            this.qCountury.BackColor = System.Drawing.Color.Transparent;
            this.qCountury.Image = global::BS.Properties.Resources.question;
            this.qCountury.ImageRotate = 0F;
            this.qCountury.Location = new System.Drawing.Point(657, 130);
            this.qCountury.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.qCountury.Name = "qCountury";
            this.qCountury.Size = new System.Drawing.Size(18, 18);
            this.qCountury.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.qCountury.TabIndex = 34;
            this.qCountury.TabStop = false;
            this.qCountury.UseTransparentBackground = true;
            this.qCountury.MouseEnter += new System.EventHandler(this.q_MouseEnter);
            this.qCountury.MouseLeave += new System.EventHandler(this.q_MouseLeave);
            // 
            // cbCountury
            // 
            this.cbCountury.BackColor = System.Drawing.Color.Transparent;
            this.cbCountury.BorderRadius = 20;
            this.cbCountury.BorderThickness = 2;
            this.cbCountury.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbCountury.DropDownHeight = 390;
            this.cbCountury.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCountury.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.cbCountury.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbCountury.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbCountury.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.cbCountury.ForeColor = System.Drawing.Color.White;
            this.cbCountury.IntegralHeight = false;
            this.cbCountury.ItemHeight = 39;
            this.cbCountury.ItemsAppearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.cbCountury.ItemsAppearance.ForeColor = System.Drawing.Color.White;
            this.cbCountury.ItemsAppearance.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
            this.cbCountury.Location = new System.Drawing.Point(570, 153);
            this.cbCountury.Margin = new System.Windows.Forms.Padding(10, 4, 10, 0);
            this.cbCountury.Name = "cbCountury";
            this.cbCountury.Size = new System.Drawing.Size(250, 45);
            this.cbCountury.TabIndex = 32;
            this.cbCountury.Tag = "cb";
            this.cbCountury.TextOffset = new System.Drawing.Point(15, 0);
            this.cbCountury.KeyDown += new System.Windows.Forms.KeyEventHandler(this.object_KeyDown);
            // 
            // lblCountury
            // 
            this.lblCountury.AutoSize = true;
            this.lblCountury.BackColor = System.Drawing.Color.Transparent;
            this.lblCountury.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCountury.Location = new System.Drawing.Point(589, 128);
            this.lblCountury.Margin = new System.Windows.Forms.Padding(40, 30, 3, 0);
            this.lblCountury.Name = "lblCountury";
            this.lblCountury.Size = new System.Drawing.Size(54, 19);
            this.lblCountury.TabIndex = 33;
            this.lblCountury.Text = "국가명";
            // 
            // qEmail
            // 
            this.qEmail.BackColor = System.Drawing.Color.Transparent;
            this.qEmail.Image = global::BS.Properties.Resources.question;
            this.qEmail.ImageRotate = 0F;
            this.qEmail.Location = new System.Drawing.Point(387, 131);
            this.qEmail.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.qEmail.Name = "qEmail";
            this.qEmail.Size = new System.Drawing.Size(18, 18);
            this.qEmail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.qEmail.TabIndex = 37;
            this.qEmail.TabStop = false;
            this.qEmail.UseTransparentBackground = true;
            this.qEmail.MouseEnter += new System.EventHandler(this.q_MouseEnter);
            this.qEmail.MouseLeave += new System.EventHandler(this.q_MouseLeave);
            // 
            // txtEmail
            // 
            this.txtEmail.BorderRadius = 20;
            this.txtEmail.BorderThickness = 2;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.DefaultText = "";
            this.txtEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.txtEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.Color.White;
            this.txtEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Location = new System.Drawing.Point(300, 153);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(0, 4, 10, 0);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.PlaceholderText = "";
            this.txtEmail.SelectedText = "";
            this.txtEmail.Size = new System.Drawing.Size(250, 45);
            this.txtEmail.TabIndex = 35;
            this.txtEmail.Tag = "e";
            this.txtEmail.TextOffset = new System.Drawing.Point(15, 0);
            this.txtEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.object_KeyDown);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.BackColor = System.Drawing.Color.Transparent;
            this.lblEmail.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblEmail.Location = new System.Drawing.Point(319, 130);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(40, 40, 3, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(54, 19);
            this.lblEmail.TabIndex = 36;
            this.lblEmail.Text = "이메일";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.BackColor = System.Drawing.Color.Transparent;
            this.lblAddress.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAddress.Location = new System.Drawing.Point(49, 238);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(40, 40, 3, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(39, 19);
            this.lblAddress.TabIndex = 30;
            this.lblAddress.Text = "주소";
            // 
            // txtAddress
            // 
            this.txtAddress.BorderRadius = 20;
            this.txtAddress.BorderThickness = 2;
            this.txtAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAddress.DefaultText = "";
            this.txtAddress.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.txtAddress.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(72)))));
            this.txtAddress.DisabledState.ForeColor = System.Drawing.Color.White;
            this.txtAddress.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.txtAddress.Enabled = false;
            this.txtAddress.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.txtAddress.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAddress.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.ForeColor = System.Drawing.Color.White;
            this.txtAddress.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAddress.Location = new System.Drawing.Point(30, 263);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(10, 4, 0, 0);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.txtAddress.PasswordChar = '\0';
            this.txtAddress.PlaceholderText = "";
            this.txtAddress.SelectedText = "";
            this.txtAddress.Size = new System.Drawing.Size(380, 45);
            this.txtAddress.TabIndex = 29;
            this.txtAddress.Tag = "address";
            this.txtAddress.TextOffset = new System.Drawing.Point(15, 0);
            // 
            // qAddress
            // 
            this.qAddress.BackColor = System.Drawing.Color.Transparent;
            this.qAddress.Image = global::BS.Properties.Resources.question;
            this.qAddress.ImageRotate = 0F;
            this.qAddress.Location = new System.Drawing.Point(117, 240);
            this.qAddress.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.qAddress.Name = "qAddress";
            this.qAddress.Size = new System.Drawing.Size(18, 18);
            this.qAddress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.qAddress.TabIndex = 31;
            this.qAddress.TabStop = false;
            this.qAddress.UseTransparentBackground = true;
            this.qAddress.MouseEnter += new System.EventHandler(this.q_MouseEnter);
            this.qAddress.MouseLeave += new System.EventHandler(this.q_MouseLeave);
            // 
            // btnAddressSearch
            // 
            this.btnAddressSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddressSearch.Animated = true;
            this.btnAddressSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnAddressSearch.BorderColor = System.Drawing.Color.White;
            this.btnAddressSearch.BorderRadius = 5;
            this.btnAddressSearch.BorderThickness = 2;
            this.btnAddressSearch.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddressSearch.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddressSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddressSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddressSearch.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(92)))));
            this.btnAddressSearch.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAddressSearch.ForeColor = System.Drawing.Color.White;
            this.btnAddressSearch.Location = new System.Drawing.Point(440, 263);
            this.btnAddressSearch.Margin = new System.Windows.Forms.Padding(30, 20, 10, 20);
            this.btnAddressSearch.Name = "btnAddressSearch";
            this.btnAddressSearch.Size = new System.Drawing.Size(110, 45);
            this.btnAddressSearch.TabIndex = 38;
            this.btnAddressSearch.Text = "주소조회";
            this.btnAddressSearch.Click += new System.EventHandler(this.btnAddressSearch_Click);
            // 
            // frmCustomerAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 450);
            this.Controls.Add(this.btnAddressSearch);
            this.Controls.Add(this.qEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.qCountury);
            this.Controls.Add(this.cbCountury);
            this.Controls.Add(this.lblCountury);
            this.Controls.Add(this.qAddress);
            this.Controls.Add(this.qPhone);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.qName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Name = "frmCustomerAdd";
            this.Text = "frmCustomerAdd";
            this.Load += new System.EventHandler(this.frmCustomerAdd_Load);
            this.Controls.SetChildIndex(this.lblName, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.qName, 0);
            this.Controls.SetChildIndex(this.lblPhone, 0);
            this.Controls.SetChildIndex(this.txtPhone, 0);
            this.Controls.SetChildIndex(this.lblAddress, 0);
            this.Controls.SetChildIndex(this.txtAddress, 0);
            this.Controls.SetChildIndex(this.qPhone, 0);
            this.Controls.SetChildIndex(this.qAddress, 0);
            this.Controls.SetChildIndex(this.lblCountury, 0);
            this.Controls.SetChildIndex(this.cbCountury, 0);
            this.Controls.SetChildIndex(this.qCountury, 0);
            this.Controls.SetChildIndex(this.lblEmail, 0);
            this.Controls.SetChildIndex(this.txtEmail, 0);
            this.Controls.SetChildIndex(this.qEmail, 0);
            this.Controls.SetChildIndex(this.btnAddressSearch, 0);
            this.Controls.SetChildIndex(this.paTop, 0);
            this.Controls.SetChildIndex(this.paBottom, 0);
            this.paTop.ResumeLayout(false);
            this.paBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qCountury)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qAddress)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox qName;
        private Guna.UI2.WinForms.Guna2TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private Guna.UI2.WinForms.Guna2PictureBox qPhone;
        private Guna.UI2.WinForms.Guna2TextBox txtPhone;
        private System.Windows.Forms.Label lblPhone;
        private Guna.UI2.WinForms.Guna2PictureBox qCountury;
        public Guna.UI2.WinForms.Guna2ComboBox cbCountury;
        private System.Windows.Forms.Label lblCountury;
        private Guna.UI2.WinForms.Guna2PictureBox qEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblAddress;
        private Guna.UI2.WinForms.Guna2TextBox txtAddress;
        private Guna.UI2.WinForms.Guna2PictureBox qAddress;
        public Guna.UI2.WinForms.Guna2Button btnAddressSearch;
    }
}