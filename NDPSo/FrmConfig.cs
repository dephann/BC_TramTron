using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using NDPSo.PLCMapping;
using NDPSo.PLCModule;
using NDPSo.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataType = S7.Net.DataType;

namespace NDPSo
{
    public partial class FrmConfig : DialogViewBase
    {
        private const string LANG_EN = "English";
        private const string LANG_VI = "Việt Nam";
        private bool _isRestarting;
        private bool _configError;

        public bool IsApplicationRestarting => this._isRestarting;

        public bool ConfigError => this._configError;

        protected override void PopulateData()
        {
            try
            {
                /*this.rdgLanguageRes.Properties.Items.AddRange(new RadioGroupItem[2]
                {
                     new RadioGroupItem((object) Enums.LanguageRes.English, "English"),
                     new RadioGroupItem((object) Enums.LanguageRes.Vietnamese, "Việt Nam")
                });*/
                this.lueRunningMode.Properties.DataSource = (object)Converter.EnumToListFieldCode<Enums.RunningMode>(false);
                this.lueRunningMode.EditValue = (object)ConfigManager.TramTronConfig.RunningMode;
                this.txtServerIP.Text = ConfigManager.TramTronConfig.ServerIP;
                //this.txtServer.Text = ConfigManager.ServiceConfig.ServerName;
                this.txtServer.Text = ".";
                this.txtDatabase.Text = ConfigManager.ServiceConfig.DatabaseName;
                this.txtUsername.Text = ConfigManager.ServiceConfig.UserID;
                this.txtPassword.Text = ConfigManager.ServiceConfig.Password;
                this.txtTenCty.Text = ConfigManager.TramTronConfig.TenCty;
                this.txtDiaChiCty.Text = ConfigManager.TramTronConfig.DiaChiCty;
                this.txtDienThoaiCty.Text = ConfigManager.TramTronConfig.DienThoaiCty;
                this.spnKLChoLonNhat.Value = ConfigManager.TramTronConfig.KLChoLonNhat;
                this.spnKLTronNhoNhat.Value = ConfigManager.TramTronConfig.KLTronNhoNhat;
                this.spnKLTronLonNhat.Value = ConfigManager.TramTronConfig.KLTronLonNhat;
                this.chkTronOnline.Checked = ConfigManager.TramTronConfig.ShowTronOnline;
                this.chkTinhBuTru.Checked = ConfigManager.TramTronConfig.TinhBuTru;
                this.spnLatestHopDongDays.EditValue = (object)ConfigManager.TramTronConfig.LatestHopDongDays;
                this.spnLatestPhieuTronDays.EditValue = (object)ConfigManager.TramTronConfig.LatestPhieuTronDays;
                this.spnLatestBaoCaoDays.EditValue = (object)ConfigManager.TramTronConfig.LatestBaoCaoDays;
                this.bteExportPath.Text = ConfigManager.TramTronConfig.ReportPath;
                this.bteImportPath_GH.Text = ConfigManager.TramTronConfig.PIPath;
                this.bteImportPath_CT.Text = ConfigManager.TramTronConfig.PICTPath;
                this.rdgLanguageRes.SelectedIndex = ConfigManager.TramTronConfig.LanguageRes;
                this.lueLanguages.EditValue = (object)ConfigManager.TramTronConfig.LanguageRes;
                this.lueLanguages.Properties.DataSource = (object)Converter.EnumToListFieldCode<Enums.LanguageRes>(false);
                this.txtPLCPort.Text = ConfigManager.TramTronConfig.SerialPort;
                this.txtLANIP.Text = ConfigManager.TramTronConfig.LANIP;
                this.txtLANPort.Text = ConfigManager.TramTronConfig.LANPort.ToString();
                this.bteLogoPath.Text = ConfigManager.TramTronConfig.LogoCty.ToString();
                this.chkDev.Checked = ConfigManager.TramTronConfig.DevEnv;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
                TramTronLogger.WriteError(ex);
                //DNMessageBox.ShowDNErrorDialog(ex);
            }
        }
        protected override void AdjustCulture()
        {
            try
            {
                this.Text = "Cấu hình";
                /*this.Text = FrmMain.ResMng.GetString("FrmConfig.Text", FrmMain.Culture);
                this.tpgCompanyInfo.Text = FrmMain.ResMng.GetString("FrmConfig.tpgCompanyInfo", FrmMain.Culture);
                this.tpgRunningMode.Text = FrmMain.ResMng.GetString("FrmConfig.tpgRunningMode", FrmMain.Culture);
                this.tpgOptions.Text = FrmMain.ResMng.GetString("FrmConfig.tpgOptions", FrmMain.Culture);
                this.lblRunningMode.Text = FrmMain.ResMng.GetString("FrmConfig.lblRunningMode", FrmMain.Culture);
                this.grpStandAlone.Text = FrmMain.ResMng.GetString("FrmConfig.grpStandAlone", FrmMain.Culture);
                this.grpService.Text = FrmMain.ResMng.GetString("FrmConfig.grpService", FrmMain.Culture);
                this.lblServerName.Text = FrmMain.ResMng.GetString("FrmConfig.lblServerName", FrmMain.Culture);
                this.lblDatabase.Text = FrmMain.ResMng.GetString("FrmConfig.lblDatabase", FrmMain.Culture);
                this.lblUsername.Text = FrmMain.ResMng.GetString("FrmConfig.lblUsername", FrmMain.Culture);
                this.lblPassword.Text = FrmMain.ResMng.GetString("FrmConfig.lblPassword", FrmMain.Culture);
                this.lblCompanyName.Text = FrmMain.ResMng.GetString("FrmConfig.lblCompanyName", FrmMain.Culture);
                this.lblAddress.Text = FrmMain.ResMng.GetString("FrmConfig.lblAddress", FrmMain.Culture);
                this.lblPhone.Text = FrmMain.ResMng.GetString("FrmConfig.lblPhone", FrmMain.Culture);
                this.tpgRange.Text = FrmMain.ResMng.GetString("FrmConfig.tpgRange", FrmMain.Culture);
                this.tpgFilter.Text = FrmMain.ResMng.GetString("FrmConfig.tpgFilter", FrmMain.Culture);
                this.tpgOthers.Text = FrmMain.ResMng.GetString("FrmConfig.tpgOthers", FrmMain.Culture);
                this.tpgGeneral.Text = FrmMain.ResMng.GetString("FrmConfig.tpgGeneral", FrmMain.Culture);
                this.lblKLChoLonNhat.Text = FrmMain.ResMng.GetString("FrmConfig.lblKLChoLonNhat", FrmMain.Culture);
                this.lblKLTronNhoNhat.Text = FrmMain.ResMng.GetString("FrmConfig.lblKLTronNhoNhat", FrmMain.Culture);
                this.lblKLTronLonNhat.Text = FrmMain.ResMng.GetString("FrmConfig.lblKLTronLonNhat", FrmMain.Culture);
                this.lblContract.Text = FrmMain.ResMng.GetString("FrmConfig.lblContract", FrmMain.Culture);
                this.lblPhieuTron.Text = FrmMain.ResMng.GetString("FrmConfig.lblPhieuTron", FrmMain.Culture);
                this.lblLatestDay.Text = FrmMain.ResMng.GetString("Text.LastestDates", FrmMain.Culture);
                this.lblLatestDay2.Text = FrmMain.ResMng.GetString("Text.LastestDates", FrmMain.Culture);
                this.lblReportPath.Text = FrmMain.ResMng.GetString("FrmConfig.lblReportPath", FrmMain.Culture);
                this.btnReportPathBrowse.Text = FrmMain.ResMng.GetString("FrmConfig.btnReportPathBrowse", FrmMain.Culture);
                this.btnTestReportPath.Text = FrmMain.ResMng.GetString("FrmConfig.btnTestReportPath", FrmMain.Culture);
                this.chkTronOnline.Text = FrmMain.ResMng.GetString("FrmConfig.chkTronOnline", FrmMain.Culture);
                this.chkTinhBuTru.Text = FrmMain.ResMng.GetString("FrmConfig.chkTinhBuTru", FrmMain.Culture);
                this.lblLanguage.Text = FrmMain.ResMng.GetString("FrmConfig.lblLanguage", FrmMain.Culture);*/
            }
            catch (System.Exception ex)
            {
            }
        }
        public bool ValidateConnection(bool showMessage)
        {
            if ((int)this.lueRunningMode.EditValue == 0)
            {
                if (!this.ValidateDBConnection(showMessage))
                    return false;
            }
            else if ((int)this.lueRunningMode.EditValue == 1 && !this.ValidateRemotingServerConnection(showMessage))
                return false;
            return true;
        }
        public bool ValidateDBConnection(bool showMessage) => true;
        public bool ValidateRemotingServerConnection(bool showMessage)
        {
            try
            {
                return true;
            }
            catch (WebException ex)
            {
                if (showMessage)
                    TramTromMessageBox.ShowErrorDialog(string.Format("Không thể kết nối đến Server IP:{0}", (object)this.txtServerIP.Text));
                    TramTronLogger.WriteError((System.Exception)ex);
                return false;
            }
            catch (System.Exception ex)
            {
                if (showMessage)
                    TramTromMessageBox.ShowDEPErrorDialog(ex);
                TramTronLogger.WriteError(ex);
                return false;
            }
        }
        public FrmConfig()
        {
            InitializeComponent();
            
        }

        private void FrmConfig_Load(object sender, EventArgs e)
        {
            //this.rdgLanguageRes.BorderStyle = BorderStyles.NoBorder;
            this.EndPreventEvent();
        }

        static string GetMACAddress() //Lấy địa chỉ MAC
        {
            string macAddress = "";
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Loopback || !nic.GetIPProperties().GetIPv4Properties().IsDhcpEnabled)
                    continue;

                macAddress = nic.GetPhysicalAddress().ToString();
                break; 
            }
            return macAddress;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.ValidateConnection(true))
                {
                    this.tabConfig.SelectedTabPage = this.tpgRunningMode;
                }
                else
                {
                    ConfigManager.TramTronConfig.RunningMode = 0;
                    string macAddress = Environment.MachineName;


                    ConfigManager.ServiceConfig.ServerName = "ndp-server";

                    switch (macAddress)
                    {
                        case "LAPTOP-BDV7JS0S": //me
                            ConfigManager.ServiceConfig.ServerName = "LAPTOP-BDV7JS0S\\PHAM";
                            break;
                        case "DESKTOP-SRUH8A8": //vp test
                            ConfigManager.ServiceConfig.ServerName = "DESKTOP-SRUH8A8\\SQLPHAM";
                            break;
                        case "DESKTOP-E4UEIUC": //thanhtuan-longan
                            ConfigManager.ServiceConfig.ServerName = "DESKTOP-E4UEIUC";
                            break;
                        case "B2A7B96A2868": //binh dinh
                            ConfigManager.ServiceConfig.ServerName = "DESKTOP-R4OQ2QU";
                            break;
                        case "DESKTOP-9S8AT23": //MQ
                            ConfigManager.ServiceConfig.ServerName = "DESKTOP-9S8AT23";
                            break;
                    }

                    ConfigManager.ServiceConfig.DatabaseName = this.txtDatabase.Text;
                    ConfigManager.ServiceConfig.UserID = this.txtUsername.Text;
                    ConfigManager.ServiceConfig.Password = this.txtPassword.Text;
                    ConfigManager.TramTronConfig.ServerIP = this.txtServerIP.Text;
                    ConfigManager.TramTronConfig.TenCty = this.txtTenCty.Text;
                    ConfigManager.TramTronConfig.DiaChiCty = this.txtDiaChiCty.Text;
                    ConfigManager.TramTronConfig.DienThoaiCty = this.txtDienThoaiCty.Text;
                    ConfigManager.TramTronConfig.KLChoLonNhat = this.spnKLChoLonNhat.Value;
                    ConfigManager.TramTronConfig.KLTronNhoNhat = this.spnKLTronNhoNhat.Value;
                    ConfigManager.TramTronConfig.KLTronLonNhat = this.spnKLTronLonNhat.Value;
                    ConfigManager.TramTronConfig.TinhBuTru = this.chkTinhBuTru.Checked;
                    ConfigManager.TramTronConfig.ShowTronOnline = this.chkTronOnline.Checked;
                    ConfigManager.TramTronConfig.LatestHopDongDays = Convert.ToInt32(this.spnLatestHopDongDays.Value);
                    ConfigManager.TramTronConfig.LatestPhieuTronDays = Convert.ToInt32(this.spnLatestPhieuTronDays.Value);
                    ConfigManager.TramTronConfig.LatestBaoCaoDays = Convert.ToInt32(this.spnLatestBaoCaoDays.Value);
                    ConfigManager.TramTronConfig.LANIP = this.txtLANIP.Text;
                    ConfigManager.TramTronConfig.LANPort = Convert.ToInt32(this.txtLANPort.Text);
                    ConfigManager.TramTronConfig.LogoCty = this.bteLogoPath.Text;
                    ConfigManager.TramTronConfig.DevEnv = this.chkDev.Checked;
                    ConfigManager.TramTronConfig.ReportPath = this.bteExportPath.Text;
                    ConfigManager.TramTronConfig.PIPath = this.bteImportPath_GH.Text;
                    ConfigManager.TramTronConfig.PICTPath = this.bteImportPath_CT.Text;

                    this.Close();
                }
            }
            catch (System.Exception ex)
            {
                TramTronLogger.WriteError(ex);
                TramTromMessageBox.ShowErrorDialog(ex.Message);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this._isRestarting)
                return;
            this._configError = this.ValidateConnection(false);
        }
        private void rdgLanguageRes_EditValueChanging(object sender, ChangingEventArgs e)
        {
            /*if (this.EventIsPrevented)
            {
                return;
            }
                
            if (MessageBox.Show("Application Language has been changed. You must restart application to get effect.", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                MessageBox.Show(e.NewValue.ToString());
                ConfigManager.TramTronConfig.LanguageRes = Convert.ToInt32(e.NewValue);
                this._isRestarting = true;
                this.Close();
            }*/
        }

        private void btnReportPathBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            int num = (int)folderBrowserDialog.ShowDialog();
            this.bteExportPath.Text = folderBrowserDialog.SelectedPath;
        }

        private void btnTestReportPath_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryMng.CreateDirectoryWithCheckExist(this.bteExportPath.Text);
                ConfigManager.TramTronConfig.ReportPath = this.bteExportPath.Text;
            }
            catch (System.Exception ex)
            {
                TramTronLogger.WriteError(ex);
                TramTromMessageBox.ShowDEPErrorDialog(ex);
            }
        }

        private void btnChangePLCPort_Click(object sender, EventArgs e)
        {
            FrmPLCPort dlgView = new FrmPLCPort();
            ViewManager.ShowViewDialog((DialogViewBase)dlgView);
            if (dlgView.DialogResult != DialogResult.OK)
                return;
            this.txtPLCPort.Text = dlgView.PLCPortName;
            ConfigManager.TramTronConfig.SerialPort = this.txtPLCPort.Text;
        }

        private void btnTestPort_Click(object sender, EventArgs e)
        {
            (sender as SerialPort).ReadExisting();
            TramTromMessageBox.ShowMessageDialog("Test Success");
        }

        private void lueLanguages_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (this.EventIsPrevented)
            {
                return;
            }

            if (TramTromMessageBox.ShowYesNoDialog("Application Language has been changed. You must restart application to get effect.") == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                MessageBox.Show(e.NewValue.ToString());
                ConfigManager.TramTronConfig.LanguageRes = Convert.ToInt32(e.NewValue);
                this._isRestarting = true;
                this.Close();
            }
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureEdit1_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void pictureEdit1_LoadCompleted(object sender, EventArgs e)
        {
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
        }

        

        private void buttonEdit1_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Thiết lập các thuộc tính của hộp thoại mở tệp
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp"; // Chỉ cho phép các loại file hình ảnh
            openFileDialog1.Title = "Chọn hình ảnh";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Lấy đường dẫn đến tệp hình ảnh được chọn
                    string imagePath = openFileDialog1.FileName;
                    bteLogoPath.Text = imagePath;
                    // Hiển thị hình ảnh trong PictureBox
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void bteLogoPath_EditValueChanged(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(bteLogoPath.Text))
            {
                pictureEdit1.Image = Image.FromFile(bteLogoPath.Text);
                pictureEdit1.Properties.SizeMode = PictureSizeMode.Zoom; // Chọn loại thay đổi kích thước tùy chỉnh
                pictureEdit1.Properties.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.True; // Cho phép hiển thị menu Zoom

                // Đảm bảo rằng hình ảnh vừa với kích thước của PictureEdit
                pictureEdit1.Properties.SizeMode = PictureSizeMode.Squeeze;

            }
            else
            {
                MessageBox.Show("Đường dẫn không phù hợp, vui lòng chọn lại đường dẫn!");
            }
        }

        private void beFilePath_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Step Files|*.s7p";
            openFileDialog1.Title = "Chọn File";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = openFileDialog1.FileName;
                    beFilePathPLC.Text = filePath;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void btnUploadToPLC_Click(object sender, EventArgs e)
        {

            PLCController _plc = new PLCController();

            if (_plc.IsConnected)
            {
                byte[] currentProgram = _plc.ReadBytes(DataType.DataBlock, 1, 0, 1000);
                byte[] newProgram = System.IO.File.ReadAllBytes(this.beFilePathPLC.Text);

                if(!MappingHelper.ByteArraysEqual(currentProgram, newProgram))
                {
                    _plc.WriteBytes(DataType.DataBlock, 1, 0, newProgram);
                    TramTromMessageBox.ShowMessageDialog("PLC Upload thành công");
                }
                else
                {
                    TramTromMessageBox.ShowMessageDialog("PLC Upload thành công");
                }
            }
            else
            {
                TramTromMessageBox.ShowMessageDialog("PLC MẤT KẾT NỐI, VUI LÒNG KIỂM TRA LẠI KẾT NỐI");
            }
        }

        private void bteExportPath_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();

            folderBrowserDialog1.Description = "Chọn Thư Mục";

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string folderPath = folderBrowserDialog1.SelectedPath;
                    bteExportPath.Text = folderPath;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void bteImportPath_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Document File|*.docx";
            openFileDialog1.Title = "Chọn File";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = openFileDialog1.FileName;
                    bteImportPath_GH.Text = filePath;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void bteImportPath_CT_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Document File|*.docx";
            openFileDialog1.Title = "Chọn File";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = openFileDialog1.FileName;
                    bteImportPath_CT.Text = filePath;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
    }
}