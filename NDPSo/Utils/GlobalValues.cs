using System;
using System.ComponentModel;


namespace NDPSo.Utils
{
	public class GlobalValues
	{
		public static void ResetDisplay()
		{
			GlobalValues._displayUser = "N/A";
			GlobalValues._displayRole = "N/A";
		}

		public static int UserID
		{
			get
			{
				return GlobalValues._userID;
			}
			set
			{
				GlobalValues._userID = value;
			}
		}

		public static string DisplayUser
		{
			get
			{
				return GlobalValues._displayUser;
			}
			set
			{
				GlobalValues._displayUser = value;
			}
		}

		public static string DisplayRole
		{
			get
			{
				return GlobalValues._displayRole;
			}
			set
			{
				GlobalValues._displayRole = value;
			}
		}

		public static string IP { get; set; }

		public static int Port { get; set; }

		public static ushort Rack { get; set; }

		public static ushort Slot { get; set; }

		

		public static bool PLCConnected
		{
			get
			{
				return GlobalValues._PLCConnected;
			}
			set
			{
				GlobalValues._PLCConnected = value;
				if (!value)
				{
					GlobalValues.ReconnectedPLCData = false;
				}
			}
		}

		[DefaultValue(false)]
		public static bool ReconnectedPLCData { get; set; }

		private const string NON_AVAIL = "N/A";

		private static int _userID = 0;

		private static string _displayUser = "N/A";

		private static string _displayRole = "N/A";

		private static bool _PLCConnected = false;

		public static class Messages
		{
			public static string DISCONNECTED { get; set; }

			public static string WAIT_CAPTION { get; set; }

			public static string WAIT_LOADING { get; set; }

			public static string INVALID_DATA { get; set; }

			public static string ErrorLogic { get; set; }

			public static string SystemRunningCannotF1 { get; set; }

			public static string SoMeDaTronIsOver { get; set; }

			public static string AutoBeforeRunning { get; set; }

			public static string SelectDataForRunning { get; set; }

			public static string EmptyDataCannotF1 { get; set; }

			public static string EmptyDataCannotDelete { get; set; }

			public static string EmptyDataCannotEdit { get; set; }

			public static string RunningInfos { get; set; }

			public static string ConfirmPausePhieuTron { get; set; }
			public static string ConfirmCancelPhieuTron { get; set; }

			public static string CancelPhieuTron { get; set; }

			public static string SuccessCancelAgg { get; set; }

			public static string SuccessCancelCe { get; set; }

			public static string SuccessCancelAdd { get; set; }

			public static string SuccessCancelWa { get; set; }

			public static string F7Pressed { get; set; }

			public static string CanDuConfirmed { get; set; }

			public static string SimulationOn { get; set; }

			public static string SimulationOff { get; set; }

			public static string LicenceRegister { get; set; }

			public static string ConfirmChangeStatusBT { get; set; }

			public static string ConfirmChangeStatusBTX { get; set; }

			public static string ConfirmChangeStatusBTC { get; set; }

			public static string ConfirmChangeStatusNoiTron { get; set; }

			public static string ConfirmChangeStatusNoiTron2 { get; set; }

			public static string DataDeletedPleaseRefresh { get; set; }

			public static string DataEditedPleaseRefresh { get; set; }

			public static string PleaseSelectPhieuTron { get; set; }

			public static string PleaseSelectDriver { get; set; }

			public static string PleaseSelectTruck { get; set; }

			public static string PleaseSelectData { get; set; }

			public static string CannotFindMAC { get; set; }

			public static string ErrorSavingData { get; set; }

			public static string ErrorSavingDriver { get; set; }

			public static string ErrorSavingTruck { get; set; }

			public static string AskForNextDataRunning { get; set; }

			public static string PAUSE { get; set; }

			public static string SuccessSavingData { get; set; }

			public static string ThieuMaThongSoThoiGian { get; set; }

			public static string SuccessSendingToPLC { get; set; }

			public static string ConfirmCloseProgram { get; set; }

			public static string PleaseSelectMAC { get; set; }

			public static string SuccessProceed { get; set; }

			public static string ConfirmDontUseFormulaDoHutNuoc { get; set; }

			public static string UnsuccessProceed { get; set; }

			public static string ConfirmDeleteSelectedData { get; set; }

			public static string MACCodeIsRequired { get; set; }

			public static string MACNameIsRequired { get; set; }

			public static string SiloCodeIsRequired { get; set; }

			public static string SiloNameIsRequired { get; set; }

			public static string MaCongTruongIsRequired { get; set; }

			public static string TenCongTruongIsRequired { get; set; }

			public static string MaHopDongIsRequired { get; set; }

			public static string TenHopDongIsRequired { get; set; }

			public static string KhachHangIsRequired { get; set; }

			public static string CongTruongIsRequired { get; set; }

			public static string MACIsRequired { get; set; }

			public static string HangMucIsRequired { get; set; }

			public static string KLDatHangLonHon0 { get; set; }

			public static string MaKhachHangIsRequired { get; set; }

			public static string TenKhachHangIsRequired { get; set; }

			public static string MaterialCodeIsRequired { get; set; }

			public static string MaterialNameIsRequired { get; set; }

			public static string MaTaiXeIsRequired { get; set; }

			public static string TenTaiXeIsRequired { get; set; }

			public static string MaNhanVienIsRequired { get; set; }

			public static string TenNhanVienIsRequired { get; set; }

			public static string MaHangMucIsRequired { get; set; }

			public static string TenHangMucIsRequired { get; set; }

			public static string BienSoXeIsRequired { get; set; }
			public static string SiloValueExceedsTheAllowableLimit { get; set; }
		}
	}
}
