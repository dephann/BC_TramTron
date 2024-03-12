
namespace NDPSo.MasterData.TronOnlineView.UserControls
{
    partial class UcNhomChinhCanAdd
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ip_NhapTai = new NDPSo.MasterData.TronOnlineView.UserControls.UcInputChinhCan();
            this.ip_Xung = new NDPSo.MasterData.TronOnlineView.UserControls.UcInputChinhCan();
            this.btnChinhTai = new NDPSo.MasterData.TronOnlineView.UserControls.UcBtnChinhCan();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lblXung = new DevExpress.XtraEditors.LabelControl();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ip_NhapTai);
            this.groupBox1.Controls.Add(this.ip_Xung);
            this.groupBox1.Controls.Add(this.btnChinhTai);
            this.groupBox1.Controls.Add(this.labelControl2);
            this.groupBox1.Controls.Add(this.lblXung);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(142, 114);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ADD 1";
            // 
            // ip_NhapTai
            // 
            this.ip_NhapTai.CheDo = NDPSo.MasterData.TronOnlineView.UserControls.UcInputChinhCan.CheDoNhap.Input;
            this.ip_NhapTai.GiaTri = "";
            this.ip_NhapTai.Location = new System.Drawing.Point(65, 42);
            this.ip_NhapTai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ip_NhapTai.Name = "ip_NhapTai";
            this.ip_NhapTai.Size = new System.Drawing.Size(71, 20);
            this.ip_NhapTai.TabIndex = 12;
            this.ip_NhapTai.ValueEditChanged += new NDPSo.MasterData.TronOnlineView.UserControls.UcInputChinhCan.ValueEditChangedEventHandler(this.ip_NhapTai_ValueEditChanged);
            this.ip_NhapTai.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ip_NhapTai_KeyPress);
            // 
            // ip_Xung
            // 
            this.ip_Xung.CheDo = NDPSo.MasterData.TronOnlineView.UserControls.UcInputChinhCan.CheDoNhap.Output;
            this.ip_Xung.GiaTri = "";
            this.ip_Xung.Location = new System.Drawing.Point(65, 15);
            this.ip_Xung.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ip_Xung.Name = "ip_Xung";
            this.ip_Xung.Size = new System.Drawing.Size(71, 20);
            this.ip_Xung.TabIndex = 10;
            this.ip_Xung.ValueEditChanged += new NDPSo.MasterData.TronOnlineView.UserControls.UcInputChinhCan.ValueEditChangedEventHandler(this.ip_Xung_ValueEditChanged);
            this.ip_Xung.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ip_Xung_KeyPress);
            // 
            // btnChinhTai
            // 
            this.btnChinhTai.Appearance.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnChinhTai.Appearance.Options.UseBackColor = true;
            this.btnChinhTai.BGColor = NDPSo.MasterData.TronOnlineView.UserControls.UcBtnChinhCan.BGColorEnum.Orange;
            this.btnChinhTai.Caption = "Chỉnh tải";
            this.btnChinhTai.ColorBG = System.Drawing.Color.DodgerBlue;
            this.btnChinhTai.ColorMouseDown = System.Drawing.Color.SteelBlue;
            this.btnChinhTai.IsOn = false;
            this.btnChinhTai.Location = new System.Drawing.Point(24, 73);
            this.btnChinhTai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnChinhTai.Name = "btnChinhTai";
            this.btnChinhTai.Size = new System.Drawing.Size(96, 30);
            this.btnChinhTai.TabIndex = 9;
            this.btnChinhTai.ButtonMoveDown_Click += new NDPSo.MasterData.TronOnlineView.UserControls.UcBtnChinhCan.DelButtonEventHandler(this.btnChinhTai_ButtonMoveDown_Click);
            this.btnChinhTai.ButtonMoveUp_Click += new NDPSo.MasterData.TronOnlineView.UserControls.UcBtnChinhCan.DelButtonEventHandler(this.btnChinhTai_ButtonMoveUp_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(7, 44);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(50, 17);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Nhập tải";
            // 
            // lblXung
            // 
            this.lblXung.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXung.Appearance.Options.UseFont = true;
            this.lblXung.Location = new System.Drawing.Point(29, 17);
            this.lblXung.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblXung.Name = "lblXung";
            this.lblXung.Size = new System.Drawing.Size(32, 17);
            this.lblXung.TabIndex = 0;
            this.lblXung.Text = "Xung";
            // 
            // UcNhomChinhCanAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UcNhomChinhCanAdd";
            this.Size = new System.Drawing.Size(142, 114);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.LabelControl lblXung;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private UcBtnChinhCan btnChinhTai;
        private UcInputChinhCan ip_Xung;
        private UcInputChinhCan ip_NhapTai;
    }
}
