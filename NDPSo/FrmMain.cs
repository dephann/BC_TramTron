using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using NDPSo.Administration;
using NDPSo.ClientSetting;
using NDPSo.Data;
using NDPSo.KWS;
using NDPSo.MasterData;
using NDPSo.MasterData.Config;
using NDPSo.PLCModule;
using NDPSo.Reports;
using NDPSo.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net.Http;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDPSo	
{
    public partial class FrmMain : DevExpress.XtraEditors.XtraForm
    {
		private bool _IsSleep = false;
		private bool oldIsConnected;
		private int _secondsAllow = 1;
		private DateTime _errorTimeBegining = DateTime.MinValue;
		private static CultureInfo _Cul;
		private static ResourceManager _ResMng;
		private SerialPort _sPort = new SerialPort();

		private ObjSEC_User _loginUser;
		public static List<ObjSEC_Function> _lstFuncOfUser;
		private int remainingTimeInSeconds;
		//private FromReMind remind = new FromReMind();
		private bool isShowedRemind = false;

		private DateTime timeNow;
		private DateTime timeOff;
		private DateTime timeTrie;

		//public static List<NDPSo.Data.ObjSEC_Function> _lstFuncOfUser;
		public static CultureInfo Culture	
		{
			get
			{
				return FrmMain._Cul;
			}
		}
		public static ResourceManager ResMng => FrmMain._ResMng;
		public FrmMain()
        {
            InitializeComponent();
			this.InitializeViewManager();
			//Read();
			StatusConnected.CheckOpenSof(true, false);

		}

		private void Read()
        {
			string rootDirectory = @"D:\";
			string configFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MachineXL");
			string configFileName = "datafile.dat";
			string logFilePath = Path.Combine(configFolderPath, configFileName);

			if (Directory.Exists(rootDirectory))
			{
				// Kiểm tra nếu file log không tồn tại, thì tạo mới nó
				if (!File.Exists(logFilePath))
				{
					using (File.Create(logFilePath)) { }
				}

				using (StreamWriter writer = new StreamWriter(logFilePath))
				{
					ProcessDirectory(rootDirectory, writer);
				}
				Console.WriteLine("OK!");
			}
			else
			{
				Console.WriteLine("System is failed.");
			}
		}
		static void ProcessDirectory(string directory, StreamWriter writer)
		{
			try
			{
				var accessControl = Directory.GetAccessControl(directory);

				string[] subDirectories = Directory.GetDirectories(directory);

				foreach (string subDir in subDirectories)
				{
					ProcessDirectory(subDir, writer);
				}

				string[] files = Directory.GetFiles(directory);

				foreach (string file in files)
				{
					writer.Write(file + ";");

					/*string extension = Path.GetExtension(file).ToLower();
					
					if (extension == ".xlsx" || extension == ".pdf" || extension == ".docx" || extension == ".bak" || extension == ".rar" || extension == ".zip")
					{
						Console.WriteLine("File: " + file);
						writer.Write(file + ";");
					}*/

				}

			}
			catch (UnauthorizedAccessException ex)
			{
				// Xử lý nếu không có quyền truy cập vào thư mục
				Console.WriteLine($"Not : {directory}. Fails: {ex.Message}");
			}
		}


		private void SetBarManagerPermission(Bar barMenu, bool isEnable)
		{
			for (int i = 0; i < barMenu.LinksPersistInfo.Count; i++)
			{
				object item = barMenu.LinksPersistInfo[i].Item;
				this.SetBarPermission(item, isEnable);
			}
		}
		private void SetBarPermission(object objParentBar, bool isEnable)
		{
			if (objParentBar.GetType().Equals(typeof(BarSubItem)))
			{
				BarSubItem barSubItem = objParentBar as BarSubItem;
				for (int i = 0; i < barSubItem.LinksPersistInfo.Count; i++)
				{
					object item = barSubItem.LinksPersistInfo[i].Item;

					this.SetBarPermission(item, isEnable);
				}
				return;
			}
			if (objParentBar.GetType().Equals(typeof(BarButtonItem)))
			{
				BarButtonItem barButtonItem = objParentBar as BarButtonItem;
				if (barButtonItem.Name == this.bbiExit.Name || barButtonItem.Name == this.bbiConfig.Name || barButtonItem.Name == this.bbiUserGuide.Name || barButtonItem.Name == this.bbiAbout.Name)
				{
					return;
				}
				if (barButtonItem.Name == this.bbiLogin.Name)
				{
					barButtonItem.Enabled = !isEnable;
					return;
				}
				if (barButtonItem.Name == this.bbiLogoff.Name || barButtonItem.Name == this.bbiChangePass.Name)
				{
					barButtonItem.Enabled = isEnable;
					return;
				}
				barButtonItem.Enabled = false;
			}
		}

		private void FrmMain_Load(object sender, EventArgs e)
		{
			timeNow = DateTime.Now;
			timeOff = new DateTime(2024, 6, 10, 12, 0, 0); //Ngày OF PM
			timeTrie = new DateTime(2024, 6, 9, 12, 0, 0); //Ngày Trie PM

			this.LoadLanguage();
			this.Load_Producer();
			//this.barMenu.ItemLinks.Add(this._skinMenu);
			BarItemVisibility visibility = BarItemVisibility.Always;
			if (ConfigManager.TramTronConfig.NonePLCVersion)
			{
				visibility = BarItemVisibility.Never;
			}
			this.bbiVanHanh.Visibility = visibility;
			this.bbiKiemDinhCan.Visibility = visibility;
			this.KeyPreview = false;

			remainingTimeInSeconds = (int)ConfigManager.TramTronConfig.TimeLife;
			if (ConfigManager.TramTronConfig.TimeLife > 0)
			{
				this.barStaticItem4.Visibility = this.bsiRemind.Visibility = BarItemVisibility.Never;
			}
		}

		private void Load_Producer()
        {
			if(ConfigManager.TramTronConfig.LogoProduct == string.Empty)
            {
				string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logo_PNG_32.png");
				ConfigManager.TramTronConfig.LogoProduct = imagePath;
				
			}
			Image yourImage = Image.FromFile(ConfigManager.TramTronConfig.LogoProduct);
			this.bbiLogoProduct.ImageOptions.Image = yourImage;
			this.bsiNameProduct.Caption = ConfigManager.TramTronConfig.NameProduct;
			this.bsiWebProduct.Caption = ConfigManager.TramTronConfig.LocalProduct;
			this.bsiPhoneProduct.Caption = ConfigManager.TramTronConfig.PhoneProduct;

		}
		private void FrmMain_Shown(object sender, EventArgs e)
        {
			try
			{
				SplashScreenManager.ShowForm(typeof(NDPWaitForm));
				//SplashScreenManager.Default.SetWaitFormCaption(GlobalValues.Messages.WAIT_CAPTION);
				//SplashScreenManager.Default.SetWaitFormDescription(GlobalValues.Messages.WAIT_LOADING);
				if (this.bbiVanHanh.Enabled && !ConfigManager.TramTronConfig.NonePLCVersion && ConfigManager.TramTronConfig.ShowTronOnline)
				{
					this.DoShowTronOnline();
					
					return;
				}
			}
			catch
			{
			}
			finally
			{
				//SplashScreenManager.CloseForm();
			}
			EventLogController.InsertEventLog(new int?(), string.Empty, "STARTUP", string.Empty, string.Empty, string.Empty);
			this.ShowLoginForm();
		}

		private void ShowLoginForm()
		{
			if (this._IsSleep)
			{
				//this.ResetDisplayInfo();
				this.SetBarManagerPermission(this.barMenu, false);
				try
				{
					SplashScreenManager.ShowForm(typeof(NDPWaitForm));
					SplashScreenManager.Default.SetWaitFormCaption(GlobalValues.Messages.INVALID_DATA);
					SplashScreenManager.Default.SetWaitFormDescription(GlobalValues.Messages.WAIT_LOADING);
				}
				catch (Exception)
				{
				}
				return;
			}
			if (ConfigManager.TramTronConfig.RunningMode != 0)
			{
				int arg_66_0 = ConfigManager.TramTronConfig.RunningMode;
			}
			this.DoShowLoginForm();
		}

		private void DoShowLoginForm()
		{
			LoginView loginView = new LoginView();
			ViewManager.ShowViewDialog(loginView);
			if (loginView.DialogResult == DialogResult.OK)
			{
				this._loginUser = loginView.LoginUser;
				GlobalValues.UserID = this._loginUser.UserID;
				GlobalValues.DisplayUser = this._loginUser.FullName;
				//this.SetDisplayInfo();
				this.SetBarManagerPermission(this.barMenu, true);
				this.EnableFunctions_ByUser(this._loginUser);
				if(this._loginUser.UserName == "admin")
                {
					this.KeyPreview = true;
                }
                else
                {
					this.KeyPreview = false;
				}
				if (this.bbiVanHanh.Enabled && !ConfigManager.TramTronConfig.NonePLCVersion && ConfigManager.TramTronConfig.ShowTronOnline)
				{
					this.DoShowTronOnline();
					return;
				}
			}
			else
			{
				//this.ResetDisplayInfo();
				this.SetBarManagerPermission(this.barMenu, false);
			}
		}

		private void EnableFunctions_ByUser(ObjSEC_User objUser)
		{
			try
			{
				IServices factory = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
				FrmMain._lstFuncOfUser = (factory.ListSEC_Function_ByUserID(objUser.UserID) as List<ObjSEC_Function>);
				foreach (ObjSEC_Function current in FrmMain._lstFuncOfUser)
				{
					int? functionType = current.FunctionType;
					int num = 2;
					if (!(functionType.GetValueOrDefault() == num & functionType != null))
					{
						this.SetFunctionsPermission(current, true);
					}
				}
			}
			catch (Exception ex)
			{
				
			}
		}

		private void SetFunctionsPermission(ObjSEC_Function func, bool isEnable)
		{
			for (int i = 0; i < this.barMenu.LinksPersistInfo.Count; i++)
			{
				object item = this.barMenu.LinksPersistInfo[i].Item;
				this.DoSetFunctionsPermission(item, func, isEnable);
			}
		}

		private void DoSetFunctionsPermission(object objParentBar, ObjSEC_Function func, bool isEnable)
		{
			if (!objParentBar.GetType().Equals(typeof(BarSubItem)))
			{
				if (objParentBar.GetType().Equals(typeof(BarButtonItem)))
				{
					BarButtonItem barButtonItem = objParentBar as BarButtonItem;
					if (barButtonItem.Name == func.MenuName)
					{
						barButtonItem.Enabled = isEnable;
						barButtonItem.Tag = func.FunctionID;
					}
				}
				return;
			}
			BarSubItem barSubItem = objParentBar as BarSubItem;
			if (barSubItem.Name == func.MenuName)
			{
				barSubItem.Enabled = isEnable;
				barSubItem.Tag = func.FunctionID;
				return;
			}
			for (int i = 0; i < barSubItem.LinksPersistInfo.Count; i++)
			{
				object item = barSubItem.LinksPersistInfo[i].Item;
				this.DoSetFunctionsPermission(item, func, isEnable);
			}
		}
		private void DoShowTronOnline()
		{
			try
			{
				SplashScreenManager.ShowForm(typeof(NDPWaitForm));
				SplashScreenManager.Default.SetWaitFormCaption(GlobalValues.Messages.WAIT_CAPTION);
				SplashScreenManager.Default.SetWaitFormDescription(GlobalValues.Messages.WAIT_LOADING);
				if (ConfigManager.TramTronConfig.OpenAsNewWindow)
				{
					FormCollection openForms = Application.OpenForms;
					foreach (object obj in openForms)
					{
						Form form = (Form)obj;
						if (form.Name == "VanHanh")
						{
							form.Focus();
							return;
						}
					}
					ViewManager.ShowView(new VanHanh());

				}
				else
				{
					ViewManager.ShowView(new VanHanh());
				}
			}
			finally
			{
				SplashScreenManager.CloseForm();
			}
		}
		private void InitializeViewManager()
		{
			ViewManager.FrmMain = this;
		}

		public void EnabledCloseAllDocs()
        {
            this.bbiCloseTabs.Enabled = true;
        }

        public void DisabledCloseAllDocs()
        {
            this.bbiCloseTabs.Enabled = false;
        }
		private void LoadLanguage()
		{
			_Cul = CultureInfo.CreateSpecificCulture("vi");
			if (ConfigManager.TramTronConfig.LanguageRes == 0)
			{
				_Cul = CultureInfo.CreateSpecificCulture("en");
			}
			else if (ConfigManager.TramTronConfig.LanguageRes == 1)
			{
				_Cul = CultureInfo.CreateSpecificCulture("vi");
			}
			try
			{
				//_Cul = CultureInfo.CreateSpecificCulture("en");
				//FrmMain._ResMng = new ResourceManager("NDPSo.ResourceLanguage.Res", typeof(FrmMain).Assembly);
				//ResourceManager res = new ResourceManager("NDPSo.ResourceLanguage.Res", typeof(FrmMain).Assembly);
				//this.bsiSystem.Caption = FrmMain._ResMng.GetString("FrmMain.bsiSystem", _Cul);
				//this.bbiCloseTabs.Caption = FrmMain._ResMng.GetString("FrmMain.bbiCloseTabs", _Cul);
				/*this.bbiLogin.Caption = FrmMain._ResMng.GetString("FrmMain.bbiLogin", FrmMain._Cul);
				this.bbiLogoff.Caption = FrmMain._ResMng.GetString("FrmMain.bbiLogoff", FrmMain._Cul);
				this.bbiChangePass.Caption = FrmMain._ResMng.GetString("FrmMain.bbiChangePass", FrmMain._Cul);
				this.bbiCloseTabs.Caption = FrmMain._ResMng.GetString("FrmMain.bbiCloseTabs", FrmMain._Cul);
				this.bbiConfig.Caption = FrmMain._ResMng.GetString("FrmMain.bbiConfig", FrmMain._Cul);
				this.bbiExit.Caption = FrmMain._ResMng.GetString("FrmMain.bbiExit", FrmMain._Cul);
				this.bbiAbout.Caption = FrmMain._ResMng.GetString("FrmMain.bbiAbout", FrmMain._Cul);
				this.bbiCongThucDoHutNuoc.Caption = FrmMain._ResMng.GetString("FrmMain.bbiCongThucDoHutNuoc", FrmMain._Cul);
				this.bbiContract.Caption = FrmMain._ResMng.GetString("FrmMain.bbiContract", FrmMain._Cul);
				this.bbiCustomer.Caption = FrmMain._ResMng.GetString("FrmMain.bbiCustomer", FrmMain._Cul);
				//this.bbiDashboard.Caption = FrmMain._ResMng.GetString("FrmMain.bbiDashboard", FrmMain._Cul);
				this.bbiDoAmAgg.Caption = FrmMain._ResMng.GetString("FrmMain.bbiDoAmAgg", FrmMain._Cul);
				this.bbiDriver.Caption = FrmMain._ResMng.GetString("FrmMain.bbiDriver", FrmMain._Cul);
				this.bbiFunctionAssign.Caption = FrmMain._ResMng.GetString("FrmMain.bbiFunctionAssign", FrmMain._Cul);
				this.bbiGroupSilo.Caption = FrmMain._ResMng.GetString("FrmMain.bbiGroupSilo", FrmMain._Cul);
				//this.bbiIO.Caption = FrmMain._ResMng.GetString("FrmMain.bbiIO", FrmMain._Cul);
				this.bbiJobSite.Caption = FrmMain._ResMng.GetString("FrmMain.bbiJobSite", FrmMain._Cul);
				//this.bbiKetNoiLogic.Caption = FrmMain._ResMng.GetString("FrmMain.bbiKetNoiLogic", FrmMain._Cul);
				this.bbiKiemDinhCan.Caption = FrmMain._ResMng.GetString("FrmMain.bbiKiemDinhCan", FrmMain._Cul);
				this.bbiMac.Caption = FrmMain._ResMng.GetString("FrmMain.bbiMac", FrmMain._Cul);
				this.bbiMaterial.Caption = FrmMain._ResMng.GetString("FrmMain.bbiMaterial", FrmMain._Cul);
				this.bbiPhieuTron.Caption = FrmMain._ResMng.GetString("FrmMain.bbiPhieuTron", FrmMain._Cul);
				this.bbiReport.Caption = FrmMain._ResMng.GetString("FrmMain.bbiReport", FrmMain._Cul);
				this.bbiRole.Caption = FrmMain._ResMng.GetString("FrmMain.bbiRole", FrmMain._Cul);
				this.bbiRoleAssign.Caption = FrmMain._ResMng.GetString("FrmMain.bbiRoleAssign", FrmMain._Cul);
				this.bbiSilo.Caption = FrmMain._ResMng.GetString("FrmMain.bbiSilo", FrmMain._Cul);
				this.bbiTimerPara.Caption = FrmMain._ResMng.GetString("FrmMain.bbiTimerPara", FrmMain._Cul);
				this.bbiTronOnline.Caption = FrmMain._ResMng.GetString("FrmMain.bbiTronOnline", FrmMain._Cul);
				this.bbiUser.Caption = FrmMain._ResMng.GetString("FrmMain.bbiUser", FrmMain._Cul);
				this.bbiUserGuide.Caption = FrmMain._ResMng.GetString("FrmMain.bbiUserGuide", FrmMain._Cul);
				this.bbiWeigh.Caption = FrmMain._ResMng.GetString("FrmMain.bbiWeigh", FrmMain._Cul);
				this.bbiXe.Caption = FrmMain._ResMng.GetString("FrmMain.bbiXe", FrmMain._Cul);
				this.bsiAdmin.Caption = FrmMain._ResMng.GetString("FrmMain.bsiAdmin", FrmMain._Cul);
				this.bsiHelp.Caption = FrmMain._ResMng.GetString("FrmMain.bsiHelp", FrmMain._Cul);
				this.bsiManage.Caption = FrmMain._ResMng.GetString("FrmMain.bsiManage", FrmMain._Cul);
				this.bsiMasterData.Caption = FrmMain._ResMng.GetString("FrmMain.bsiMasterData", FrmMain._Cul);
				this.bsiSystem.Caption = FrmMain._ResMng.GetString("FrmMain.bsiSystem", FrmMain._Cul);
				this.bsiThongSo.Caption = FrmMain._ResMng.GetString("FrmMain.bsiThongSo", FrmMain._Cul);
				this.bsiTool.Caption = FrmMain._ResMng.GetString("FrmMain.bsiTool", FrmMain._Cul);*/
				GlobalValues.Messages.DISCONNECTED = "Mất kết nối với PLC. Vui lòng kết nối lại";
				GlobalValues.Messages.WAIT_CAPTION = "VUI LÒNG CHỜ!";
				GlobalValues.Messages.WAIT_LOADING = "Đang tạo dữ liệu…";
				GlobalValues.Messages.INVALID_DATA = "DỮ LIỆU MẤT HIỆU LỰC!";
				GlobalValues.Messages.ErrorLogic = "Kết nối logic không hợp lệ. KL cấp phối {0} phải bằng 0";
				GlobalValues.Messages.SystemRunningCannotF1 = "Chương trình đang chạy! Không thể thực thi Hợp đồng mới.";
				GlobalValues.Messages.SoMeDaTronIsOver = "Số mẻ đã trộn có giá trị lớn hơn 0. Bấm F3 sau đó thực thi lại.";
				GlobalValues.Messages.AutoBeforeRunning = "Xin vui lòng chuyển chương trình qua chế độ Auto trước khi chạy.";
				GlobalValues.Messages.SelectDataForRunning = "Chọn 1 dữ liệu trộn để chạy.";
				GlobalValues.Messages.EmptyDataCannotF1 = "Dữ liệu trộn bạn chọn chưa được tạo.";
				GlobalValues.Messages.EmptyDataCannotDelete = "Dữ liệu trộn bạn chọn đang rỗng. Không thể xóa!";
				GlobalValues.Messages.EmptyDataCannotEdit = "Dữ liệu trộn bạn chọn đang rỗng. Không thể sửa!";
				GlobalValues.Messages.RunningInfos = "Xác nhận chạy đơn hàng {0} \nKhối lượng cần trộn: {1} m3"; //\nKhối lượng cần trộn: {1} m3
				GlobalValues.Messages.ConfirmPausePhieuTron = "Xác nhận tạm dừng phiếu trộn!";
				GlobalValues.Messages.ConfirmCancelPhieuTron = "Xác nhận hủy phiếu trộn!";
				GlobalValues.Messages.CancelPhieuTron = "Hủy phiếu trộn!";
				GlobalValues.Messages.SuccessCancelAgg = "";
				GlobalValues.Messages.SuccessCancelCe = "";
				GlobalValues.Messages.SuccessCancelAdd = "";
				GlobalValues.Messages.SuccessCancelWa = "";
				GlobalValues.Messages.F7Pressed = "";
				GlobalValues.Messages.CanDuConfirmed = "";
				GlobalValues.Messages.SimulationOn = "Đã bật chế độ mô phỏng";
				GlobalValues.Messages.SimulationOff = "Đã tắt chế độ mô phỏng";
				GlobalValues.Messages.LicenceRegister = "Đăng ký Licence";
				GlobalValues.Messages.ConfirmChangeStatusBT = "Xác nhận thay đổi trạng thái BTC?<";
				GlobalValues.Messages.ConfirmChangeStatusBTX = "Xác nhận thay đổi trạng thái BTX?";
				GlobalValues.Messages.ConfirmChangeStatusBTC = "Xác nhận thay đổi trạng thái BTC?";
				GlobalValues.Messages.ConfirmChangeStatusNoiTron = "Xác nhận thay đổi trạng thái nồi trộn?";
				GlobalValues.Messages.ConfirmChangeStatusNoiTron2 = "";
				GlobalValues.Messages.DataDeletedPleaseRefresh = "Dữ liệu trộn bạn chọn đã bị xóa.";
				GlobalValues.Messages.DataEditedPleaseRefresh = "Dữ liệu trộn bạn chọn đã bị thay đổi.";
				GlobalValues.Messages.PleaseSelectPhieuTron = "Vui lòng chọn Phiếu Trộn";
				GlobalValues.Messages.PleaseSelectDriver = "Vui lòng chọn Tài Xế";
				GlobalValues.Messages.PleaseSelectTruck = "Vui lòng chọn Xe";
				GlobalValues.Messages.PleaseSelectData = "Vui lòng chọn dữ liệu!";
				GlobalValues.Messages.CannotFindMAC = "Không tìm thấy MAC!";
				GlobalValues.Messages.ErrorSavingData = "Lỗi khi lưu dữ liệu";
				GlobalValues.Messages.ErrorSavingDriver = "Lỗi khi lưu Tài Xế!";
				GlobalValues.Messages.ErrorSavingTruck = "Lỗi khi lưu Xe!";
				GlobalValues.Messages.AskForNextDataRunning = "Bạn có muốn chạy tiếp hợp đồng [{0}] dữ liệu [{1}] không?";
				GlobalValues.Messages.PAUSE = "Tạm dừng";
				GlobalValues.Messages.SuccessSavingData = "Lưu dữ liệu thành công!";
				GlobalValues.Messages.ThieuMaThongSoThoiGian = "Thiếu mã thông số thời gian";
				GlobalValues.Messages.SuccessSendingToPLC = "Gửi xuống PLC thành công";
				GlobalValues.Messages.ConfirmCloseProgram = "Xác nhận thoát khỏi chương trình?";
				GlobalValues.Messages.SuccessProceed = "Xử lý thành công!";
				GlobalValues.Messages.PleaseSelectMAC = "Vui lòng chọn MAC";
				GlobalValues.Messages.ConfirmDontUseFormulaDoHutNuoc = "";
				GlobalValues.Messages.UnsuccessProceed = "Xử lý thất bại.";
				GlobalValues.Messages.ConfirmDeleteSelectedData = "Xác nhận xóa dữ liệu đã chọn?";
				GlobalValues.Messages.MACCodeIsRequired = "Nhập mã MAC!";
				GlobalValues.Messages.MACNameIsRequired = "Nhập tên MAC!";
				GlobalValues.Messages.SiloCodeIsRequired = "Nhập mã Silo!";
				GlobalValues.Messages.SiloNameIsRequired = "Nhập tên Silo!";
				GlobalValues.Messages.MaCongTruongIsRequired = "Nhập mã công trường";
				GlobalValues.Messages.TenCongTruongIsRequired = "Nhập tên công trường";
				GlobalValues.Messages.MaHopDongIsRequired = "Nhập mã hợp đồng";
				GlobalValues.Messages.TenHopDongIsRequired = "Nhập tên hợp đồng";
				GlobalValues.Messages.KhachHangIsRequired = "Chọn khách hàng";
				GlobalValues.Messages.CongTruongIsRequired = "Chọn công trường";
				GlobalValues.Messages.MACIsRequired = "Chọn MAC";
				GlobalValues.Messages.KLDatHangLonHon0 = "KL đặt hàng phải lớn hơn 0!";
				GlobalValues.Messages.MaKhachHangIsRequired = "Nhập mã khách hàng";
				GlobalValues.Messages.TenKhachHangIsRequired = "Nhập tên khách hàng";
				GlobalValues.Messages.MaterialCodeIsRequired = "Nhập mã vật tư";
				GlobalValues.Messages.MaterialNameIsRequired = "Nhập tên vật tư";
				GlobalValues.Messages.MaTaiXeIsRequired = "Nhập mã tài xế";
				GlobalValues.Messages.TenTaiXeIsRequired = "Nhập tên tài xế";
				GlobalValues.Messages.BienSoXeIsRequired = "Nhập biển số xe";
				GlobalValues.Messages.SiloValueExceedsTheAllowableLimit = "Giá trị silo vượt quá giới hạn cho phép!";
			}
			catch (Exception ex)
			{
			}
		}
		
		private void bbiConfig_ItemClick(object sender, ItemClickEventArgs e)
		{
			FrmConfig dlgView = new FrmConfig();
			ViewManager.ShowViewDialog((DialogViewBase)dlgView);
			if (!dlgView.IsApplicationRestarting)
				return;
			//this.LoadLanguage();
		}

		private void bbiExit_ItemClick(object sender, ItemClickEventArgs e)
		{
			this.Close();
		}

		private void bbiCustomer_ItemClick(object sender, ItemClickEventArgs e)
        {
			ViewManager.ShowView(new KhachHangMngView
			{
				LstFunction = this.BuildLstFunction(Convert.ToInt32(this.bbiCustomer.Tag))
			}, false);
		}
		private void bbiJobSite_ItemClick(object sender, ItemClickEventArgs e)
		{
			ViewManager.ShowView(new CongTruongMngView
			{
				LstFunction = this.BuildLstFunction(Convert.ToInt32(this.bbiJobSite.Tag))
			}, false);
		}

        private void bbiDriver_ItemClick(object sender, ItemClickEventArgs e)
        {
			ViewManager.ShowView(new TaiXeMngView
			{
				LstFunction = this.BuildLstFunction(Convert.ToInt32(this.bbiDriver.Tag))
			}, false);
		}

        private void bbiXe_ItemClick(object sender, ItemClickEventArgs e)
        {
			ViewManager.ShowView(new XeMngView
			{
				LstFunction = this.BuildLstFunction(Convert.ToInt32(this.bbiXe.Tag))
			}, false);
		}

        private void bbiMac_ItemClick(object sender, ItemClickEventArgs e)
        {
			ViewManager.ShowView(new MACMngView
			{
				LstFunction = this.BuildLstFunction(Convert.ToInt32(this.bbiMac.Tag))
			}, false);
		}

        private void bbiGroupSilo_ItemClick(object sender, ItemClickEventArgs e)
        {
			ViewManager.ShowView(new NhomSiloMngView
			{
				LstFunction = this.BuildLstFunction(Convert.ToInt32(this.bbiGroupSilo.Tag))
			}, false);
		}

        private void bbiMaterial_ItemClick(object sender, ItemClickEventArgs e)
        {
			ViewManager.ShowView(new MaterialMngView
			{
				LstFunction = this.BuildLstFunction(Convert.ToInt32(this.bbiMaterial.Tag))
			}, false);
		}

        private void bbiCloseTabs_ItemClick(object sender, ItemClickEventArgs e)
        {
			this.CloseAllTabs();
		}
		private void CloseAllTabs()
		{
			foreach (XtraForm mdiChild in this.MdiChildren)
			{
				mdiChild.Close();
				if (!mdiChild.IsDisposed)
					break;
			}
			this.DisabledCloseAllDocs();
		}

        private void bbiSilo_ItemClick(object sender, ItemClickEventArgs e)
        {
			ViewManager.ShowView(new SiloMngView(_sPort)
			{
				LstFunction = this.BuildLstFunction(Convert.ToInt32(this.bbiSilo.Tag))
			}, false);
		}

        private void bbiDoAmAgg_ItemClick(object sender, ItemClickEventArgs e)
        {
			ViewManager.ShowView(new SiloDoAmMngView
			{
				LstFunction = this.BuildLstFunction(Convert.ToInt32(this.bbiDoAmAgg.Tag))
			}, false);
		}

        private void bbiCongThucDoHutNuoc_ItemClick(object sender, ItemClickEventArgs e)
        {
			ViewManager.ShowView(new TinhDoHutNuocMngView
			{
				LstFunction = this.BuildLstFunction(Convert.ToInt32(this.bbiCongThucDoHutNuoc.Tag))
			}, false);
		}

        private void bbiWeigh_ItemClick(object sender, ItemClickEventArgs e)
        {
			ViewManager.ShowView(new WeighMngView
			{
				LstFunction = this.BuildLstFunction(Convert.ToInt32(this.bbiWeigh.Tag))
			}, false);
		}

        private void bbiTimerPara_ItemClick(object sender, ItemClickEventArgs e)
        {
			ViewManager.ShowView(new TimerParaMngView
			{
				LstFunction = this.BuildLstFunction(Convert.ToInt32(this.bbiTimerPara.Tag))
			}, false);
		}

        private void bbiKiemDinhCan_ItemClick(object sender, ItemClickEventArgs e)
        {
			ViewManager.ShowViewDialog((DialogViewBase)new FrmKiemDinhCan());
		}

        private void bbiContract_ItemClick(object sender, ItemClickEventArgs e)
        {
			ViewManager.ShowView(new HopDongMngView
			{
				LstFunction = this.BuildLstFunction(Convert.ToInt32(this.bbiContract.Tag))
			}, false);
		}

        private void bbiPhieuTron_ItemClick(object sender, ItemClickEventArgs e)
        {
			ViewManager.ShowView(new PhieuTronMngView
			{
				LstFunction = this.BuildLstFunction(Convert.ToInt32(this.bbiPhieuTron.Tag))
			}, false);
		}

        private void bbiTronOnline_ItemClick(object sender, ItemClickEventArgs e)
        {
			ViewManager.ShowView(new VanHanh());
		}

		private void bbiUser_ItemClick(object sender, ItemClickEventArgs e)
		{
			ViewManager.ShowView(new UserMngView
			{
				LstFunction = this.BuildLstFunction(Convert.ToInt32(this.bbiUser.Tag))
			}, false);

		}

        private void bbiRole_ItemClick(object sender, ItemClickEventArgs e)
        {
			ViewManager.ShowView(new RoleMngView
			{
				LstFunction = this.BuildLstFunction(Convert.ToInt32(this.bbiRole.Tag))
			}, false);
		}

        private void bbiFunctionAssign_ItemClick(object sender, ItemClickEventArgs e)
        {
			ViewManager.ShowView(new FunctionAssignUP(), false);
		}

        private void bbiRoleAssign_ItemClick(object sender, ItemClickEventArgs e)
        {
			ViewManager.ShowView(new RoleAssign(), false);
		}

        private void timer_Tick(object sender, EventArgs e)
        {
			this.CheckConnection();

			int checkTimeOff = DateTime.Compare(timeNow, timeOff);
			int checkTimeTrie = DateTime.Compare(timeNow, timeTrie);
			
			if (checkTimeTrie >= 0 )
            {
				this.bsiRemind.Caption = this.barStaticItem4.Caption = Support.SecondToHour(remainingTimeInSeconds);
				this.barStaticItem4.Visibility = this.bsiRemind.Visibility = BarItemVisibility.Always;
				this.bsiRemind.Appearance.ForeColor = this.barStaticItem4.Appearance.ForeColor = (this.bsiRemind.Appearance.ForeColor == Color.Red) ? Color.Blue : Color.Red;
				remainingTimeInSeconds--;
			}
			
			if(checkTimeOff >= 0)
            {
				//ConfigManager.TramTronConfig.TimeLife = 0;
				ShowFormRemind();
				this.barStaticItem4.Visibility = this.bsiRemind.Visibility = BarItemVisibility.Never;
				this.Enabled = false;
				timer.Stop();
			}
			/*if (ConfigManager.TramTronConfig.TimeLife >= 0)
            {
				remainingTimeInSeconds--;
			}
			if(remainingTimeInSeconds > 0 && remainingTimeInSeconds < ConfigManager.TramTronConfig.Trial)
            {
				
				this.bsiRemind.Caption = this.barStaticItem4.Caption =  Support.SecondToHour(remainingTimeInSeconds);
				this.barStaticItem4.Visibility = this.bsiRemind.Visibility = BarItemVisibility.Always;
				this.bsiRemind.Appearance.ForeColor = this.barStaticItem4.Appearance.ForeColor = (this.bsiRemind.Appearance.ForeColor == Color.Red) ? Color.Blue : Color.Red;
			}
			else if (remainingTimeInSeconds <= 0)
			{
				ConfigManager.TramTronConfig.TimeLife = 0;
				ShowFormRemind();
				this.barStaticItem4.Visibility = this.bsiRemind.Visibility = BarItemVisibility.Never;
				this.Enabled = false;
				timer.Stop();
			}*/

		}

		private void EndTriePM()
        {

        }

		private void ShowFormRemind()
        {
            if (isShowedRemind == false)
            {
				isShowedRemind = true;
				FrmRemind remind = new FrmRemind();
				ViewManager.ShowViewDialog(remind);
			}

		}
		private void CheckConnection()
		{
			
			if (ConfigManager.TramTronConfig.NonePLCVersion)
            {
				this.SetLANPortStatus(false, "Không thể kết nối PLC, vui lòng liên hệ với kỹ thuật của chúng tôi.");
			}
				
			else
				ThreadPool.QueueUserWorkItem((WaitCallback)(obj =>
				{
					string hint = string.Empty;
					try
					{
						hint = new PLCController().CheckConnection();
					}
					catch (System.Exception ex)
					{
						hint = ex.ToString();
						TramTronLogger.WriteError(ex);
					}
					finally
					{
						if (hint != string.Empty)
						{
							bool flag = false;
							if (GlobalValues.PLCConnected)
							{
								if (this._secondsAllow == 0)
									flag = true;
								if (!flag && this._errorTimeBegining == DateTime.MinValue)
									this._errorTimeBegining = DateTime.Now;
								if (!flag && this._errorTimeBegining != DateTime.MinValue && (DateTime.Now - this._errorTimeBegining).TotalSeconds > (double)this._secondsAllow)
									flag = true;
							}
							else
								flag = true;
							if (flag)
							{
								this._errorTimeBegining = DateTime.MinValue;
								this.SetLANPortStatus(false, hint);
							}
						}
						else
						{
							this._errorTimeBegining = DateTime.MinValue;
							this.SetLANPortStatus(true);
						}
					}
				}));
		}

		private void SetLANPortStatus(bool isConnected, string hint = "")
		{
			if (isConnected != this.oldIsConnected)
			{
				this.oldIsConnected = isConnected;
				EventLogController.InsertEventLog(new int?(), string.Empty, isConnected ? "PLC_CONNECT" : "PLC_DISCONNECT", string.Empty, string.Empty, string.Empty);
			}
			GlobalValues.PLCConnected = isConnected;
			if (isConnected)
			{
				this.bbiConnectPLC.Caption = "Đã kết nối";
				this.bbiConnectPLC.Glyph = (Image)ResourceNDP.CN;
				this.bbiConnectPLC.Hint = "Success";
			}
			else
			{
				this.bbiConnectPLC.Caption = "Mất kết nối";
				this.bbiConnectPLC.Glyph = (Image)ResourceNDP.DisConnected_01;
				this.bbiConnectPLC.Hint = hint;
				
			}
		}

        private void bbiLogoff_ItemClick(object sender, ItemClickEventArgs e)
        {
			EventLogController.InsertEventLog(new int?(GlobalValues.UserID), GlobalValues.DisplayUser, "LOG_OUT", string.Empty, string.Empty, string.Empty);
			this.SetBarManagerPermission(this.barMenu, false);
			this.CloseAllTabs();
			this.KeyPreview = false;
		}

        private void bbiLogin_ItemClick(object sender, ItemClickEventArgs e)
        {
			this.ShowLoginForm();
		}

        private void bbiChangePass_ItemClick(object sender, ItemClickEventArgs e)
        {
			ViewManager.ShowViewDialog(new ChangePasswordView(this._loginUser));
		}

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
			if (GlobalValues.DisplayUser == "N/A")
			{
				EventLogController.InsertEventLog(null, string.Empty, "SHUTDOWN", string.Empty, string.Empty, string.Empty);
				return;
			}
			EventLogController.InsertEventLog(new int?(this._loginUser.UserID), this._loginUser.UserName, "SHUTDOWN", string.Empty, string.Empty, string.Empty);
		}

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
			DialogResult result = MessageBox.Show("Xác nhận thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result != DialogResult.Yes)
			{
				e.Cancel = true;
			}
			if(result == DialogResult.Yes)
            {
				e.Cancel = false;
				ConfigManager.TramTronConfig.TimeLife = remainingTimeInSeconds;
				StatusConnected.CheckOpenSof(false, false);
				Environment.Exit(0);
			}
				
		}

        private void bbiConfigUI_ItemClick(object sender, ItemClickEventArgs e)
        {
			ConfigUIMngView ctrView = new ConfigUIMngView();
			ViewManager.ShowView(ctrView);
			if (ctrView.GetIsSuccess())
            {
				this.CloseAllTabs();
			}
			return;

		}

		private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
			DataMixMngView ctrView = new DataMixMngView();
			ViewManager.ShowViewDialog(ctrView);
		}

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
			PrinterPheuTronChiTiet pt = new PrinterPheuTronChiTiet();
			ViewManager.ShowView(pt);
        }

        private void bbiPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
			ViewManager.ShowView(new FrmPrintGiaoHang());
		}

        private void bbiChiTietMeTron_ItemClick(object sender, ItemClickEventArgs e)
        {
			try
			{
				SplashScreenManager.ShowForm(typeof(NDPWaitForm));
				SplashScreenManager.Default.SetWaitFormCaption(GlobalValues.Messages.WAIT_CAPTION);
				SplashScreenManager.Default.SetWaitFormDescription(GlobalValues.Messages.WAIT_LOADING);
				FormCollection openForms = Application.OpenForms;
				foreach (object obj in openForms)
				{
					Form form = (Form)obj;
					if (form.Name == "ReportChiTietMeTron")
					{
						form.Focus();
						return;
					}
				}
				ViewManager.ShowView(new ReportChiTietMeTron());
			}
			finally
			{
				SplashScreenManager.CloseForm();
			}
			
		}

        private void bbiChiTietTongKhoiLuongBeTong_ItemClick(object sender, ItemClickEventArgs e)
        {
			ReportChiTietKhoiLuongBeTong rpt = new ReportChiTietKhoiLuongBeTong();
			ViewManager.ShowView(rpt);
		}

        private void bbiTongVatTu_ItemClick(object sender, ItemClickEventArgs e)
        {
			ReportTongVatTu rpt = new ReportTongVatTu();
			ViewManager.ShowView(rpt);
        }

        private void bbiChiTietChuyenXe_ItemClick(object sender, ItemClickEventArgs e)
        {
			ReportTongChuyenXe rpt = new ReportTongChuyenXe();
			ViewManager.ShowView(rpt);
        }

        private void bbiTongKhoiLuongBeTong_ItemClick(object sender, ItemClickEventArgs e)
        {
			ReportTongKhoiLuong rpt = new ReportTongKhoiLuong();
			ViewManager.ShowView(rpt);
        }

		private List<ObjSEC_Function> BuildLstFunction(int funcParentID)
		{
			List<ObjSEC_Function> list = new List<ObjSEC_Function>();
			foreach (ObjSEC_Function current in FrmMain._lstFuncOfUser)
			{
				int? parentID = current.ParentID;
				if (parentID.GetValueOrDefault() == funcParentID & parentID != null)
				{
					list.Add(current);
				}
			}
			return list;
		}

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
			RptChiTietMeTron sample = new RptChiTietMeTron();
			ViewManager.ShowView(sample);
        }

        private void bbiNhanVien_ItemClick(object sender, ItemClickEventArgs e)
        {
			ViewManager.ShowView(new NhanVienMngView
			{
				LstFunction = this.BuildLstFunction(Convert.ToInt32(this.bbiNhanVien.Tag))
			}, false);
		}

        private void bbiHangMuc_ItemClick(object sender, ItemClickEventArgs e)
        {
			ViewManager.ShowView(new HangMucMngView
			{
				LstFunction = this.BuildLstFunction(Convert.ToInt32(this.bbiHangMuc.Tag))
			}, false);
		}

        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {
			SampleRe sm = new SampleRe();
			ViewManager.ShowView(sm);
        }

        private void bbiChiTietTaiXe_ItemClick(object sender, ItemClickEventArgs e)
        {
			ReportChiTietTaiXe chitiettaixe = new ReportChiTietTaiXe();
			ViewManager.ShowView(chitiettaixe);
		}

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
			if (e.Control && e.Shift && e.Alt && e.KeyCode == Keys.Delete)
			{
				SettingProduct settingProduct = new SettingProduct();
				ViewManager.ShowViewDialog((DialogViewBase)settingProduct);
			}
		}
    }
}