using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Xml;

namespace NDPSo.Utils
{
	public class TramTronLogger
	{
		public static bool WriteInfo(string msg)
		{
			bool result;
			try
			{
				if (TramTronLogger._logPath == string.Empty)
				{
					//TramTronLogger.LogPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FolderLogs");
					TramTronLogger.LogPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "OperXL");
				}
				if (!Directory.Exists(TramTronLogger._logPath))
				{
					Directory.CreateDirectory(TramTronLogger._logPath);
				}
				string logfilename = "_inf_" + DateTime.Now.Date.ToString("yyyy-MM-dd") + ".txt";
				string logFilePath = Path.Combine(TramTronLogger._logPath, logfilename);
				if (!File.Exists(logFilePath))
				{
					FileStream fs = File.Create(logFilePath);
					fs.Close();
				}
				/*TramTronLogger.WriteString(logFilePath, new List<string>
				{
					msg
				});*/
				TramTronLogger.WriteOperationLog(logFilePath, msg);
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		public static bool WriteError(Exception ex)
		{
			bool result;
			try
			{
				if (TramTronLogger._logPath == string.Empty)
				{
					//TramTronLogger.LogPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FolderLogs");
					TramTronLogger.LogPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "OperXL");

					if (!Directory.Exists(TramTronLogger._logPath))
					{
						Directory.CreateDirectory(TramTronLogger._logPath);
					}
				}
				
				if (TramTronLogger._logFile == string.Empty)
				{
					TramTronLogger.LogFile = TramTronLogger.AutoGenerateLogFile();
				}
				if (!Directory.Exists(TramTronLogger._logPath))
				{
					Directory.CreateDirectory(TramTronLogger._logPath);
				}
				if (!File.Exists(TramTronLogger._logFilePath))
				{
					FileStream fs = File.Create(TramTronLogger._logFilePath);
					fs.Close();
				}
				TramTronLogger.WriteErrorLog(TramTronLogger._logFilePath, ex);
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		private static string AutoGenerateLogFile()
		{
			return DateTime.Now.Date.ToString("yyyy-MM-dd") + ".txt";
		}

		public static bool ErrorRoutine(bool bLogType, Exception objException)
		{
			bool result;
			try
			{
				if (!TramTronLogger.CheckLoggingEnabled())
				{
					result = true;
				}
				else
				{
					if (bLogType)

					{
						string EventLogName = "ErrorSample";
						if (!EventLog.SourceExists(EventLogName))
						{
							EventLog.CreateEventSource(objException.Message, EventLogName);
						}
						new EventLog
						{
							Source = EventLogName
						}.WriteEntry(objException.Message, EventLogEntryType.Error);
					}
					else if (!TramTronLogger.CustomErrorRoutine(objException))
					{
						result = false;
						return result;
					}
					result = true;
				}
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		private static bool CheckLoggingEnabled()
		{
			string strLoggingStatusConfig = string.Empty;
			strLoggingStatusConfig = TramTronLogger.GetLoggingStatusConfigFileName();
			return strLoggingStatusConfig.Equals(string.Empty) || TramTronLogger.GetValueFromXml(strLoggingStatusConfig);
		}

		private static string GetLoggingStatusConfigFileName()
		{
			string strCheckinBaseDirecotry = AppDomain.CurrentDomain.BaseDirectory + "LoggingStatus.Config";
			if (File.Exists(strCheckinBaseDirecotry))
			{
				return strCheckinBaseDirecotry;
			}
			string strCheckinApplicationDirecotry = TramTronLogger.GetApplicationPath() + "LoggingStatus.Config";
			if (File.Exists(strCheckinApplicationDirecotry))
			{
				return strCheckinApplicationDirecotry;
			}
			return string.Empty;
		}

		private static bool GetValueFromXml(string strXmlPath)
		{
			bool result;
			try
			{
				FileStream docIn = new FileStream(strXmlPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
				XmlDocument contactDoc = new XmlDocument();
				contactDoc.Load(docIn);
				XmlNodeList UserList = contactDoc.GetElementsByTagName("LoggingEnabled");
				string strGetValue = UserList.Item(0).InnerText.ToString();
				result = (!strGetValue.Equals("0") && strGetValue.Equals("1"));
			}
			catch (Exception ex)
			{
				TramTronLogger.WriteError(ex);
				result = false;
			}
			return result;
		}

		private static bool CustomErrorRoutine(Exception objException)
		{
			string strPathName = string.Empty;
			if (TramTronLogger._logFilePath.Equals(string.Empty))
			{
				strPathName = TramTronLogger.GetLogFilePath();
			}
			else
			{
				if (!File.Exists(TramTronLogger._logFilePath))
				{
					if (!TramTronLogger.CheckDirectory(TramTronLogger._logFilePath))
					{
						return false;
					}
					FileStream fs = new FileStream(TramTronLogger._logFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
					fs.Close();
				}
				strPathName = TramTronLogger._logFilePath;
			}
			bool bReturn = true;
			if (!TramTronLogger.WriteErrorLog(strPathName, objException))
			{
				bReturn = false;
			}
			return bReturn;
		}

		public static string GetHDDSerial()
		{
			ArrayList hdCollection = new ArrayList();
			ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
			foreach (ManagementBaseObject managementBaseObject in searcher.Get())
			{
				ManagementObject wmi_HD = (ManagementObject)managementBaseObject;
				hdCollection.Add(new HardDrive
				{
					Model = wmi_HD["Model"].ToString(),
					Type = wmi_HD["InterfaceType"].ToString()
				});
			}
			searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
			int i = 0;
			foreach (ManagementBaseObject managementBaseObject2 in searcher.Get())
			{
				ManagementObject wmi_HD2 = (ManagementObject)managementBaseObject2;
				HardDrive hd = (HardDrive)hdCollection[i];
				if (wmi_HD2["SerialNumber"] == null)
				{
					hd.SerialNo = "None";
				}
				else
				{
					hd.SerialNo = wmi_HD2["SerialNumber"].ToString();
				}
				i++;
				if (hdCollection.Count == i)
				{
					break;
				}
			}
			string hddSerial = string.Empty;
			foreach (object obj in hdCollection)
			{
				HardDrive hd2 = (HardDrive)obj;
				hddSerial = hd2.SerialNo;
			}
			return hddSerial;
		}

		public static string GetComputer_LanIP()
		{
			string result;
			try
			{
				string strHostName = Dns.GetHostName();
				IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
				foreach (IPAddress ipAddress in ipEntry.AddressList)
				{
					if (ipAddress.AddressFamily.ToString() == "InterNetwork")
					{
						result = ipAddress.ToString();
						return result;
					}
				}
				result = "-";
			}
			catch (Exception)
			{
				result = "Local IP Address Not Found!";
			}
			return result;
		}

		public static string GetComputer_InternetIP()
		{
			string result;
			try
			{
				string url = "http://checkip.dyndns.org";
				WebRequest req = WebRequest.Create(url);
				WebResponse resp = req.GetResponse();
				StreamReader sr = new StreamReader(resp.GetResponseStream());
				string response = sr.ReadToEnd().Trim();
				result = response.Replace("<html><head><title>Current IP Check</title></head><body>Current IP Address: ", string.Empty).Replace("</body></html>", string.Empty);
			}
			catch (Exception)
			{
				result = "Internet IP Not Found!";
			}
			return result;
		}

		public static string GetLocalIPAddress()
		{
			string result;
			try
			{
				IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
				foreach (IPAddress ip in host.AddressList)
				{
					if (ip.AddressFamily == AddressFamily.InterNetwork)
					{
						result = ip.ToString();
						return result;
					}
				}
				result = "-";
			}
			catch (Exception)
			{
				result = "Local IP Address Not Found!";
			}
			return result;
		}

		private static bool WriteErrorLog(string strPathName, Exception objException)
		{
			bool bReturn = false;
			string arg_07_0 = string.Empty;
			try
			{
				TramTronLogger._sw = new StreamWriter(strPathName, true);
				TramTronLogger._sw.WriteLine("Source\t\t: " + objException.Source.ToString().Trim());
				TramTronLogger._sw.WriteLine("Method\t\t: " + objException.TargetSite.Name.ToString());
				TramTronLogger._sw.WriteLine("Date\t\t: " + DateTime.Now.ToShortDateString());
				TramTronLogger._sw.WriteLine("Time\t\t: " + DateTime.Now.ToLongTimeString());
				TramTronLogger._sw.WriteLine("Computer\t: " + Dns.GetHostName().ToString());
				TramTronLogger._sw.WriteLine("Error\t\t: " + objException.Message.ToString().Trim());
				TramTronLogger._sw.WriteLine("Inner\t\t: " + ((objException.InnerException != null) ? objException.InnerException.Message : string.Empty));
				TramTronLogger._sw.WriteLine("Stack Trace\t: " + objException.StackTrace.ToString().Trim());
				TramTronLogger._sw.WriteLine("==================================================================");
				TramTronLogger._sw.Flush();
				TramTronLogger._sw.Close();
				bReturn = true;
			}
			catch (Exception)
			{
				bReturn = false;
			}
			return bReturn;
		}
		private static bool WriteOperationLog(string strPathName, string actionOper)
		{
			bool bReturn = false;
			string arg_07_0 = string.Empty;
			try
			{
				TramTronLogger._sw = new StreamWriter(strPathName, true);
				TramTronLogger._sw.WriteLine("User\t\t: " + GlobalValues.DisplayUser);
				TramTronLogger._sw.WriteLine("Date\t\t: " + DateTime.Now.ToShortDateString());
				TramTronLogger._sw.WriteLine("Time\t\t: " + DateTime.Now.ToLongTimeString());
				TramTronLogger._sw.WriteLine("Computer\t: " + Dns.GetHostName().ToString());
				TramTronLogger._sw.WriteLine("Description\t: " + actionOper);
				TramTronLogger._sw.WriteLine("==================================================================");
				TramTronLogger._sw.Flush();
				TramTronLogger._sw.Close();
				bReturn = true;
			}
			catch (Exception)
			{
				bReturn = false;
			}
			return bReturn;
		}

		private static bool WriteString(string strPathName, List<string> list)
		{
			bool bReturn = false;
			string arg_07_0 = string.Empty;
			try
			{
				if (list != null)
				{
					TramTronLogger._sw = new StreamWriter(strPathName, true);
					TramTronLogger._sw.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
					TramTronLogger._sw.WriteLine("Date\t\t: " + DateTime.Now.ToShortDateString());
					TramTronLogger._sw.WriteLine("Time\t\t: " + DateTime.Now.ToLongTimeString());
					foreach (string str in list)
					{
						TramTronLogger._sw.WriteLine(str);
					}
					TramTronLogger._sw.WriteLine("==================================================================");
					TramTronLogger._sw.Flush();
					TramTronLogger._sw.Close();
				}
				bReturn = true;
			}
			catch (Exception)
			{
				bReturn = false;
			}
			return bReturn;
		}

		private static string GetLogFilePath()
		{
			string result;
			try
			{
				string baseDir = AppDomain.CurrentDomain.BaseDirectory + AppDomain.CurrentDomain.RelativeSearchPath;
				string retFilePath = baseDir + "//LogFile.txt";
				if (File.Exists(retFilePath))
				{
					result = retFilePath;
				}
				else if (!TramTronLogger.CheckDirectory(retFilePath))
				{
					result = string.Empty;
				}
				else
				{
					FileStream fs = new FileStream(retFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
					fs.Close();
					result = retFilePath;
				}
			}
			catch (Exception)
			{
				result = string.Empty;
			}
			return result;
		}
		
		private static bool CheckDirectory(string strLogPath)
		{
			bool result;
			try
			{
				int nFindSlashPos = strLogPath.Trim().LastIndexOf("\\");
				string strDirectoryname = strLogPath.Trim().Substring(0, nFindSlashPos);
				if (!Directory.Exists(strDirectoryname))
				{
					Directory.CreateDirectory(strDirectoryname);
				}
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		private static string GetApplicationPath()
		{
			string result;
			try
			{
				string strBaseDirectory = AppDomain.CurrentDomain.BaseDirectory.ToString();
				int nFirstSlashPos = strBaseDirectory.LastIndexOf("\\");
				string strTemp = string.Empty;
				if (0 < nFirstSlashPos)
				{
					strTemp = strBaseDirectory.Substring(0, nFirstSlashPos);
				}
				int nSecondSlashPos = strTemp.LastIndexOf("\\");
				string strTempAppPath = string.Empty;
				if (0 < nSecondSlashPos)
				{
					strTempAppPath = strTemp.Substring(0, nSecondSlashPos);
				}
				string strAppPath = strTempAppPath.Replace("bin", "");
				result = strAppPath;
			}
			catch (Exception)
			{
				result = string.Empty;
			}
			return result;
		}

		public static string LogFile
		{
			set
			{
				TramTronLogger._logFile = value;
				TramTronLogger._logFilePath = Path.Combine(TramTronLogger._logPath, TramTronLogger._logFile);
			}
		}

		public static string LogPath
		{
			set
			{
				TramTronLogger._logPath = value;
				TramTronLogger._logFilePath = Path.Combine(TramTronLogger._logPath, TramTronLogger._logFile);
			}
		}

		public static string LogFilePath
		{
			get
			{
				return TramTronLogger._logFilePath;
			}
			set
			{
				TramTronLogger._logFilePath = value;
			}
		}

		protected static string _logFilePath = string.Empty;

		private static StreamWriter _sw = null;

		private static string _logFile = string.Empty;

		private static string _logPath = string.Empty;
	}
}
