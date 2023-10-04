using CefSharp;

namespace BS.Model
{
    partial class WebBrowserForm
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
            this.txtAddress = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtPostNumber = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblPostNumber = new System.Windows.Forms.Label();
            this.lblDetailAddress = new System.Windows.Forms.Label();
            this.txtDetailAddress = new Guna.UI2.WinForms.Guna2TextBox();
            this.paAddressSearch = new Guna.UI2.WinForms.Guna2Panel();
            this.paTop.SuspendLayout();
            this.paBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // paTop
            // 
            this.paTop.Size = new System.Drawing.Size(850, 100);
            // 
            // paBottom
            // 
            this.paBottom.Location = new System.Drawing.Point(0, 910);
            this.paBottom.Size = new System.Drawing.Size(850, 90);
            // 
            // label1
            // 
            this.label1.Text = "주소 조회";
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
            this.btnDel.Location = new System.Drawing.Point(781, 20);
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
            this.txtAddress.Margin = new System.Windows.Forms.Padding(5, 4, 5, 0);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.txtAddress.PasswordChar = '\0';
            this.txtAddress.PlaceholderText = "";
            this.txtAddress.SelectedText = "";
            this.txtAddress.Size = new System.Drawing.Size(380, 45);
            this.txtAddress.TabIndex = 35;
            this.txtAddress.Tag = "address";
            this.txtAddress.TextOffset = new System.Drawing.Point(15, 0);
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
            this.lblAddress.TabIndex = 36;
            this.lblAddress.Text = "주소";
            // 
            // txtPostNumber
            // 
            this.txtPostNumber.BorderRadius = 20;
            this.txtPostNumber.BorderThickness = 2;
            this.txtPostNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPostNumber.DefaultText = "";
            this.txtPostNumber.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.txtPostNumber.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(72)))));
            this.txtPostNumber.DisabledState.ForeColor = System.Drawing.Color.White;
            this.txtPostNumber.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.txtPostNumber.Enabled = false;
            this.txtPostNumber.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.txtPostNumber.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPostNumber.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPostNumber.ForeColor = System.Drawing.Color.White;
            this.txtPostNumber.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPostNumber.Location = new System.Drawing.Point(30, 153);
            this.txtPostNumber.Margin = new System.Windows.Forms.Padding(30, 4, 5, 0);
            this.txtPostNumber.Name = "txtPostNumber";
            this.txtPostNumber.Padding = new System.Windows.Forms.Padding(0, 0, 0, 60);
            this.txtPostNumber.PasswordChar = '\0';
            this.txtPostNumber.PlaceholderText = "";
            this.txtPostNumber.SelectedText = "";
            this.txtPostNumber.Size = new System.Drawing.Size(250, 45);
            this.txtPostNumber.TabIndex = 32;
            this.txtPostNumber.Tag = "s";
            this.txtPostNumber.TextOffset = new System.Drawing.Point(15, 0);
            // 
            // lblPostNumber
            // 
            this.lblPostNumber.AutoSize = true;
            this.lblPostNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblPostNumber.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPostNumber.Location = new System.Drawing.Point(49, 130);
            this.lblPostNumber.Margin = new System.Windows.Forms.Padding(40, 30, 3, 0);
            this.lblPostNumber.Name = "lblPostNumber";
            this.lblPostNumber.Size = new System.Drawing.Size(69, 19);
            this.lblPostNumber.TabIndex = 33;
            this.lblPostNumber.Text = "우편번호";
            // 
            // lblDetailAddress
            // 
            this.lblDetailAddress.AutoSize = true;
            this.lblDetailAddress.BackColor = System.Drawing.Color.Transparent;
            this.lblDetailAddress.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDetailAddress.Location = new System.Drawing.Point(464, 240);
            this.lblDetailAddress.Margin = new System.Windows.Forms.Padding(40, 30, 3, 0);
            this.lblDetailAddress.Name = "lblDetailAddress";
            this.lblDetailAddress.Size = new System.Drawing.Size(69, 19);
            this.lblDetailAddress.TabIndex = 33;
            this.lblDetailAddress.Text = "상세주소";
            // 
            // txtDetailAddress
            // 
            this.txtDetailAddress.BorderRadius = 20;
            this.txtDetailAddress.BorderThickness = 2;
            this.txtDetailAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDetailAddress.DefaultText = "";
            this.txtDetailAddress.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDetailAddress.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDetailAddress.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDetailAddress.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDetailAddress.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.txtDetailAddress.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDetailAddress.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetailAddress.ForeColor = System.Drawing.Color.White;
            this.txtDetailAddress.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDetailAddress.Location = new System.Drawing.Point(445, 263);
            this.txtDetailAddress.Margin = new System.Windows.Forms.Padding(30, 4, 5, 0);
            this.txtDetailAddress.Name = "txtDetailAddress";
            this.txtDetailAddress.Padding = new System.Windows.Forms.Padding(0, 0, 0, 60);
            this.txtDetailAddress.PasswordChar = '\0';
            this.txtDetailAddress.PlaceholderText = "";
            this.txtDetailAddress.SelectedText = "";
            this.txtDetailAddress.Size = new System.Drawing.Size(366, 45);
            this.txtDetailAddress.TabIndex = 32;
            this.txtDetailAddress.Tag = "s";
            this.txtDetailAddress.TextOffset = new System.Drawing.Point(15, 0);
            this.txtDetailAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.object_KeyDown);
            // 
            // paAddressSearch
            // 
            this.paAddressSearch.Location = new System.Drawing.Point(30, 356);
            this.paAddressSearch.Margin = new System.Windows.Forms.Padding(30, 0, 30, 0);
            this.paAddressSearch.Name = "paAddressSearch";
            this.paAddressSearch.Size = new System.Drawing.Size(781, 500);
            this.paAddressSearch.TabIndex = 37;
            // 
            // WebBrowserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 1000);
            this.Controls.Add(this.paAddressSearch);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtDetailAddress);
            this.Controls.Add(this.lblDetailAddress);
            this.Controls.Add(this.txtPostNumber);
            this.Controls.Add(this.lblPostNumber);
            this.Name = "WebBrowserForm";
            this.Text = "WebBrowserForm";
            this.Controls.SetChildIndex(this.paTop, 0);
            this.Controls.SetChildIndex(this.paBottom, 0);
            this.Controls.SetChildIndex(this.lblPostNumber, 0);
            this.Controls.SetChildIndex(this.txtPostNumber, 0);
            this.Controls.SetChildIndex(this.lblDetailAddress, 0);
            this.Controls.SetChildIndex(this.txtDetailAddress, 0);
            this.Controls.SetChildIndex(this.lblAddress, 0);
            this.Controls.SetChildIndex(this.txtAddress, 0);
            this.Controls.SetChildIndex(this.paAddressSearch, 0);
            this.paTop.ResumeLayout(false);
            this.paBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private Guna.UI2.WinForms.Guna2TextBox txtPostNumber;
        private System.Windows.Forms.Label lblPostNumber;
        private System.Windows.Forms.Label lblDetailAddress;
        private Guna.UI2.WinForms.Guna2TextBox txtDetailAddress;
        private Guna.UI2.WinForms.Guna2Panel paAddressSearch;
    }
}