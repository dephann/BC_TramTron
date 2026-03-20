using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;

namespace NDPSo.Utils
{
	public class Validation
	{
		public static int ValidateDatabase(string server, string database, string username, string password)
		{
			string arg_05_0 = string.Empty;
			int result;
			try
			{
				SqlConnection conn = new SqlConnection(string.Format("server={0};database={1};user id={2};pwd={3}", new object[]
				{
					server,
					"master",
					username,
					password
				}));
				SqlDataAdapter adap = new SqlDataAdapter("select name from sysDataBases", conn);
				DataSet ds = new DataSet();
				adap.Fill(ds, "TableNames");
				foreach (object obj in ds.Tables["TableNames"].Rows)
				{
					DataRow row = (DataRow)obj;
					if (database == row[0].ToString())
					{
						result = 1;
						return result;
					}
				}
				result = 0;
			}
			catch (Exception ex)
			{
				TramTronLogger.WriteError(ex);
				result = -1;
			}
			return result;
		}

		public static bool ValidateDBConnection(string server, string database, string username, string password)
		{
			SqlConnection conn = new SqlConnection(string.Format("server={0};database={1};user id={2};pwd={3}", new object[]
			{
				server,
				database,
				username,
				password
			}));
			bool result;
			try
			{
				conn.Open();
				result = true;
			}
			catch (Exception ex)
			{
				TramTronLogger.WriteError(ex);
				result = false;
			}
			finally
			{
				if (conn.State != ConnectionState.Closed)
				{
					conn.Close();
				}
			}
			return result;
		}

		public static bool ValidateServerIPConnection(string serverIP)
		{
			bool result;
			try
			{
				PingReply pingReply;
				using (Ping ping3 = new Ping())
				{
					pingReply = ping3.Send(serverIP);
				}
				result = (pingReply.Status == IPStatus.Success);
			}
			catch (PingException ex)
			{
				TramTronLogger.WriteError(ex);
				result = false;
			}
			return result;
		}

		private const string CONNECTION_STRING = "server={0};database={1};user id={2};pwd={3}";

        public static string GetPhysicalMacsConcatenated()
        {
            try
            {
                var macList = NetworkInterface.GetAllNetworkInterfaces()
                    .Where(ni =>
                        ni.OperationalStatus == OperationalStatus.Up &&
                        ni.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                        ni.GetPhysicalAddress() != null &&
                        ni.GetPhysicalAddress().GetAddressBytes().Length == 6 &&
                        !IsVirtualAdapter(ni) // lọc adapter ảo
                    )
                    .Select(ni => ni.GetPhysicalAddress().ToString())
                    .Where(s => !string.IsNullOrWhiteSpace(s))
                    .Distinct()
                    .OrderBy(s => s)
                    .ToArray();

                if (macList.Length == 0)
                {
                    // Nếu không tìm thấy MAC hợp lệ, fallback: trả chuỗi rỗng hoặc "nomac"
                    return "nomac";
                }

                // Nối các MAC bằng dấu phẩy (hoặc gì đó) để đảm bảo ổn định
                return string.Join(",", macList);
            }
            catch
            {
                return "nomac";
            }

        }
        private static bool IsVirtualAdapter(NetworkInterface ni)
        {
            string desc = ni.Description?.ToLowerInvariant() ?? "";
            string name = ni.Name?.ToLowerInvariant() ?? "";

            string[] virtualSigns = new[] {
            "virtual", "vmware", "vbox", "hyper-v", "hyperv", "loopback",
            "docker", "tunnel", "vpn", "hamachi", "virtualbox", "wireshark", "npcap"
        };

            foreach (var s in virtualSigns)
            {
                if (desc.Contains(s) || name.Contains(s)) return true;
            }

            return false;
        }
    }

}
