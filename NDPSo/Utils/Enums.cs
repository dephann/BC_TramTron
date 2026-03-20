
using System;
using System.ComponentModel.DataAnnotations;

namespace NDPSo.Utils
{
	public class Enums
	{
		public class VanHanh
		{
			public enum WeiSiloType
			{
				Silo = 1,
				Wei = 11
			}
		}

		public enum FormAction
		{
			New,
			Edit,
			View
		}
		public enum MsgType
		{
			Error,
			Info,
			Warning,
		}

		public enum RunningMode
		{
			[Display(Name = "Stand Alone")]
			StandAlone,
			[Display(Name = "Service")]
			Service
		}

		public enum LanguageRes
		{
			[Display(Name = "English")]
			English = 0,
			[Display(Name = "Vietnamese")]
			Vietnamese = 1,
			/*[Display(Name = "Laos")]
			Laos = 2,
			[Display(Name = "Cambodia")]
			Cambodia = 3,
			[Display(Name = "Thailand")]
			Thailand = 4*/
		}

		public enum ActiveEnum
		{
			[Display(Name = "Đang hoạt động")]
			Active = 1,
			[Display(Name = "Tạm ngưng")]
			Deactive
		}
		public enum SimMode
		{
			[Display(Name = "Mô phỏng")]
			Sim = 1,
			[Display(Name = "Bình thường")]
			Normal
		}

		public enum HopDongStatus
		{
			[Display(Name = "Mới")] //0
			New,
			[Display(Name = "Đang xử lý")] //1
			InProcess,
			[Display(Name = "Hủy")] //2
			Cancel,
			[Display(Name = "Đợi")] //3
			Close,
			[Display(Name = "Hoàn tất")] //4
			Completed
		}

		public enum PhieuTronStatus
		{
			[Display(Name = "Mới")] //0
			New,
			[Display(Name = "Hủy")] //1
			Cancel,
			[Display(Name = "Đợi")] //2
			Waiting,
			[Display(Name = "Đang trộn")] //3
			InProcess,
 			[Display(Name = "Trộn thất Bại")] //4
			Failed,
			[Display(Name = "Đã trộn")] //5
			Finished
			/*[Display(Name = "Vượt KL")]
			Over*/
		}

		public enum DuLieuTronStatus
		{
			[Display(Name = "Mới")] //0
			New = 0,
			[Display(Name = "Đang trộn")] //1
			Running = 1,
			[Display(Name = "Tạm dừng")] //2
			Pause = 2,
			[Display(Name = "Hủy")] //3
			Abort = 3,
			[Display(Name = "Hoàn tất")] //4
			Finished = 4
		}

		public enum Unit
        {
			Kg,
			ml,
			m3
		}

		public enum MeTronStatus
		{
			Mixing,
			Failed,
			Finished
		}

		public enum SiloType
		{
			Agg,
			Ce,
			Wa,
			Add
		}

		public enum TronOnlineCommand
		{
			Run,
			Pause,
			Stop,
			CancelAgg,
			CancelCe,
			CancelWa,
			StopCe,
			StopWa,
			StopAdd,
			RunMoPhong
		}

		public enum TronOnlineState
		{
			Step0,
			Step1,
			Step2,
			Step3,
			Step4,
			Step5,
			Step6
		}

		public enum TronProcess
		{
			S00_None,
			S01_Init,
			S02_NapCan,
			S03_NapNoiTron,
			S04_NoiTronFull = 5,
			S05_XaNoiTron
		}

		public enum FunctionType
		{
			Module,
			Menu,
			Function
		}

		public class Exception
		{
			public enum MappingEx
			{
				[Display(Name =  "Invalid data input.")]
				DataInput = -1,
				[Display(Name = "Invalid begining charater.")]
				BeginningCharacter = -2,
				[Display(Name = "Invalid length of data.")]
				Length = -3,
				[Display(Name = "Invalid ending charater.")]
				EndingCharacter = -4,
				[Display(Name = "PLCInputType does not match")]
				InputTypeNotMatch = -5
			}
		}

		public class S7Connector
		{
			public enum CPUType
			{
				S7200,
				S7300 = 10,
				S7400 = 20,
				S71200 = 30
			}

			public enum ExceptionCode
			{
				ExceptionNo,
				WrongCPU_Type,
				ConnectionError,
				IPAdressNotAvailable,
				WrongVariableFormat = 10,
				WrongNumberReceivedBytes,
				SendData = 20,
				ReadData = 30,
				WriteData = 50
			}

			public enum DataType
			{
				Input = 129,
				Output,
				Marker,
				DataBlock,
				Timer = 29,
				Counter = 28
			}

			public enum VarType
			{
				Bit,
				Byte,
				Word,
				DWord,
				Int,
				DInt,
				Real,
				String,
				Timer,
				Counter
			}
		}
	}
}
