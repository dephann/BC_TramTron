
namespace NDPSo.Administration
{
    partial class ChangePasswordView
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
            this.txtConfirmPass = new System.Windows.Forms.GroupBox();
            this.txtConfirmPass1 = new System.Windows.Forms.TextBox();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.txtOldPass = new System.Windows.Forms.TextBox();
            this.lblConfirmNewPass = new DevExpress.XtraEditors.LabelControl();
            this.lblNewPass = new DevExpress.XtraEditors.LabelControl();
            this.lblOldPass = new DevExpress.XtraEditors.LabelControl();
            this.grbCommand = new System.Windows.Forms.GroupBox();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.txtConfirmPass.SuspendLayout();
            this.grbCommand.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtConfirmPass
            // 
            this.txtConfirmPass.Controls.Add(this.txtConfirmPass1);
            this.txtConfirmPass.Controls.Add(this.txtNewPass);
            this.txtConfirmPass.Controls.Add(this.txtOldPass);
            this.txtConfirmPass.Controls.Add(this.lblConfirmNewPass);
            this.txtConfirmPass.Controls.Add(this.lblNewPass);
            this.txtConfirmPass.Controls.Add(this.lblOldPass);
            this.txtConfirmPass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConfirmPass.Location = new System.Drawing.Point(0, 0);
            this.txtConfirmPass.Name = "txtConfirmPass";
            this.txtConfirmPass.Size = new System.Drawing.Size(477, 221);
            this.txtConfirmPass.TabIndex = 0;
            this.txtConfirmPass.TabStop = false;
            // 
            // txtConfirmPass1
            // 
            this.txtConfirmPass1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPass1.Location = new System.Drawing.Point(188, 112);
            this.txtConfirmPass1.Name = "txtConfirmPass1";
            this.txtConfirmPass1.PasswordChar = '*';
            this.txtConfirmPass1.Size = new System.Drawing.Size(200, 23);
            this.txtConfirmPass1.TabIndex = 5;
            // 
            // txtNewPass
            // 
            this.txtNewPass.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPass.Location = new System.Drawing.Point(188, 77);
            this.txtNewPass.MaxLength = 30;
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.PasswordChar = '*';
            this.txtNewPass.Size = new System.Drawing.Size(200, 23);
            this.txtNewPass.TabIndex = 4;
            // 
            // txtOldPass
            // 
            this.txtOldPass.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldPass.Location = new System.Drawing.Point(188, 48);
            this.txtOldPass.Name = "txtOldPass";
            this.txtOldPass.Size = new System.Drawing.Size(200, 23);
            this.txtOldPass.TabIndex = 3;
            // 
            // lblConfirmNewPass
            // 
            this.lblConfirmNewPass.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmNewPass.Appearance.Options.UseFont = true;
            this.lblConfirmNewPass.Location = new System.Drawing.Point(49, 115);
            this.lblConfirmNewPass.Name = "lblConfirmNewPass";
            this.lblConfirmNewPass.Size = new System.Drawing.Size(128, 16);
            this.lblConfirmNewPass.TabIndex = 2;
            this.lblConfirmNewPass.Text = "Nhập lại mật khẩu mới";
            // 
            // lblNewPass
            // 
            this.lblNewPass.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewPass.Appearance.Options.UseFont = true;
            this.lblNewPass.Location = new System.Drawing.Point(49, 80);
            this.lblNewPass.Name = "lblNewPass";
            this.lblNewPass.Size = new System.Drawing.Size(111, 16);
            this.lblNewPass.TabIndex = 1;
            this.lblNewPass.Text = "Nhập mật khẩu mới";
            // 
            // lblOldPass
            // 
            this.lblOldPass.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldPass.Appearance.Options.UseFont = true;
            this.lblOldPass.Location = new System.Drawing.Point(49, 51);
            this.lblOldPass.Name = "lblOldPass";
            this.lblOldPass.Size = new System.Drawing.Size(103, 16);
            this.lblOldPass.TabIndex = 0;
            this.lblOldPass.Text = "Nhập mật khẩu cũ";
            // 
            // grbCommand
            // 
            this.grbCommand.Controls.Add(this.btnCancel);
            this.grbCommand.Controls.Add(this.btnOk);
            this.grbCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grbCommand.Location = new System.Drawing.Point(0, 171);
            this.grbCommand.Name = "grbCommand";
            this.grbCommand.Size = new System.Drawing.Size(477, 50);
            this.grbCommand.TabIndex = 1;
            this.grbCommand.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(263, 14);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 30);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Huỷ Bỏ";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Appearance.Options.UseFont = true;
            this.btnOk.Location = new System.Drawing.Point(141, 14);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(98, 30);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Đồng Ý";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // ChangePasswordView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 221);
            this.Controls.Add(this.grbCommand);
            this.Controls.Add(this.txtConfirmPass);
            this.IconOptions.Image = global::NDPSo.ResourceNDP.IcologoPM1;
            this.Name = "ChangePasswordView";
            this.Text = "ChangePasswordView";
            this.txtConfirmPass.ResumeLayout(false);
            this.txtConfirmPass.PerformLayout();
            this.grbCommand.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox txtConfirmPass;
        private DevExpress.XtraEditors.LabelControl lblConfirmNewPass;
        private DevExpress.XtraEditors.LabelControl lblNewPass;
        private DevExpress.XtraEditors.LabelControl lblOldPass;
        private System.Windows.Forms.GroupBox grbCommand;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.TextBox txtOldPass;
        private System.Windows.Forms.TextBox txtConfirmPass1;
    }
}