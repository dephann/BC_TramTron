using System;
using System.Data;
using System.Data.SqlClient;
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
	}
}
