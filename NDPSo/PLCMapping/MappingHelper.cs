using System;
using System.Collections.Generic;
using System.Text;

namespace NDPSo.PLCMapping
{
	public class MappingHelper
	{
		public static string GetString_PLCDataType_Silo(int i)
		{
			string strOutput = string.Empty;
			switch (i)
			{
				case 0:
					strOutput = ">AG1";
					break;
				case 1:
					strOutput = ">AG2";
					break;
				case 2:
					strOutput = ">AG3";
					break;
				case 3:
					strOutput = ">AG4";
					break;
				default:
					throw new Exception("[NamDaiPhatTramTron] - Out of range [PLC DataType Silo]");
			}
			return strOutput;
		}

		public static List<byte> SeparateIntTo2Bytes(int intOrigin)
		{
			return new List<byte>
			{
				(byte)(intOrigin >> 8 & 255),
				(byte)(intOrigin & 255)
			};
		}

		//New Convert Float To 4 Byte
		public static List<byte> SeparateFloatTo4Bytes(double floatOrigin)
		{
			byte[] byteArray = S7.Net.Types.Double.ToByteArray(floatOrigin);
			return new List<byte>
			{
				byteArray[0],
				byteArray[1],
				byteArray[2],
				byteArray[3]
			};
		}
		public static int Merge2BytesIntoInt(byte byte1, byte byte2)
		{
			return (int)byte1 << 8 ^ (int)byte2;
		}
		//New Convert 4 Bytes To Int
		public static uint Merge4BytesIntoInt(byte byte1, byte byte2, byte byte3, byte byte4)
		{
			byte[] bytes = { byte1, byte2, byte3, byte4 };
			if (BitConverter.IsLittleEndian)
				Array.Reverse(bytes);

			return BitConverter.ToUInt32(bytes, 0);
		}
		public static byte[] MapToSendingData_WithPLCDatatype(List<byte> lstByte, string strInputType)
		{
			byte[] myBuff = new byte[strInputType.Length + lstByte.Count + 3];
			myBuff[0] = 3;
			myBuff[1] = (byte)(lstByte.Count + strInputType.Length + 1);
			ASCIIEncoding encoding = new ASCIIEncoding();
			byte[] inputTypeBuff = encoding.GetBytes(strInputType);
			int count = 2;
			int distance = count;
			foreach (byte arg_4C_0 in inputTypeBuff)
			{
				myBuff[count] = inputTypeBuff[count - distance];
				count++;
			}
			distance = count;
			foreach (byte arg_7C_0 in lstByte)
			{
				myBuff[count] = lstByte[count - distance];
				count++;
			}
			myBuff[myBuff.Length - 1] = 13;
			return myBuff;
		}

		public static byte[] MapToSendingData_WithPLCDatatype(List<int> lstIntOriginValue, string strInputType)
		{
			List<byte> lstByte = new List<byte>();
			foreach (int originValue in lstIntOriginValue)
			{
				lstByte.AddRange(MappingHelper.SeparateIntTo2Bytes(originValue));
			}
			return MappingHelper.MapToSendingData_WithPLCDatatype(lstByte, strInputType);
		}

		public static int ValidateDataInput(byte[] plcBuff, string strInputTypeOK)
		{
			if (plcBuff.Length < 3)
			{
				return -1;
			}
			if (plcBuff[0] != 3)
			{
				return -2;
			}
			int length = (int)(plcBuff[1] + 2);
			if (length != plcBuff.Length)
			{
				return -3;
			}
			if (plcBuff[length - 1] != 13)
			{
				return -4;
			}
			byte[] inputTypeBuff = new byte[strInputTypeOK.Length];
			for (int i = 0; i < strInputTypeOK.Length; i++)
			{
				inputTypeBuff[i] = plcBuff[i + 2];
			}
			string strInputType = Encoding.ASCII.GetString(inputTypeBuff);
			if (strInputType != strInputTypeOK)
			{
				return -5;
			}
			return strInputTypeOK.Length + 2;
		}

		public static byte[] MapToReceivingData_WithoutPLCDatatype(byte[] plcBuff, int startIndex)
		{
			byte[] myBuff = new byte[plcBuff.Length - startIndex - 1];
			for (int i = 0; i < myBuff.Length; i++)
			{
				myBuff[i] = plcBuff[i + startIndex];
			}
			return myBuff;
		}

		public static byte[] MapToReceivingData_WithoutPLCDatatype1(byte[] plcBuff, string strInputTypeOK)
		{
			if (plcBuff.Length < 3)
			{
				throw new Exception("[NamDaiPhat] - Invalid data format.");
			}
			if (plcBuff[0] != 3)
			{
				throw new Exception("[NamDaiPhat] - Invalid begining charater.");
			}
			int length = (int)(plcBuff[1] + 2);
			if (length != plcBuff.Length)
			{
				throw new Exception("[NamDaiPhat] - Invalid length of data.");
			}
			if (plcBuff[length - 1] != 13)
			{
				throw new Exception("[NamDaiPhat] - Invalid ending charater.");
			}
			byte[] myBuff = new byte[plcBuff.Length - strInputTypeOK.Length - 3];
			int count = 2;
			int distance = count;
			byte[] inputTypeBuff = new byte[strInputTypeOK.Length];
			for (int i = 0; i < strInputTypeOK.Length; i++)
			{
				inputTypeBuff[i] = plcBuff[i + distance];
				count++;
			}
			string strInputType = Encoding.ASCII.GetString(inputTypeBuff);
			if (strInputType != strInputTypeOK)
			{
				throw new Exception("[NamDaiPhat] - MapToReceivingData_WithoutPLCDatatype - PLCInputType does not match");
			}
			distance = count;
			for (int j = 0; j < myBuff.Length; j++)
			{
				myBuff[j] = plcBuff[j + distance];
			}
			return myBuff;
		}

		public static bool ByteArraysEqual(byte[] a1, byte[] a2)
		{
			if (a1.Length != a2.Length)
				return false;

			for (int i = 0; i < a1.Length; i++)
			{
				if (a1[i] != a2[i])
					return false;
			}
			return true;
		}
	}
}
