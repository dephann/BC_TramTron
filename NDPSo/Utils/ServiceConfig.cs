using System;
using System.Data.EntityClient;
using System.Data.SqlClient;

namespace NDPSo.Utils
{
	public class ServiceConfig : ConfigBase
	{
		public ServiceConfig() : base("ServiceConfig.xml", "/configuration/Service")
		{
		}

		public string DataProvider
		{
			get
			{
				return base["DataProvider"];
			}
			set
			{
				base["DataProvider"] = value;
			}
		}

		public string ServerName
		{
			get
			{
				return base["ServerName"];
			}
			set
			{
				base["ServerName"] = value;
			}
		}

		public string DatabaseName
		{
			get
			{
				return base["DatabaseName"];
			}
			set
			{
				base["DatabaseName"] = value;
			}
		}

		public string UserID
		{
			get
			{
				return base["UserID"];
			}
			set
			{
				base["UserID"] = value;
			}
		}

		public string Password
		{
			get
			{
				return base["Password"];
			}
			set
			{
				base["Password"] = value;
			}
		}

		public string ConnectionString
		{
			get

			{
				string connectionString = string.Empty;
				string dataProvider;
				if ((dataProvider = this.DataProvider) != null)
				{
					if (!(dataProvider == "System.Data.SqlClient"))
					{
						if (!(dataProvider == "System.Data.OleDb") && !(dataProvider == "System.Data.OracleClient"))
						{
						}
					}
					else
					{
						connectionString = new EntityConnectionStringBuilder
						{
							Metadata = "res://*",
							Provider = "System.Data.SqlClient",
							ProviderConnectionString = new SqlConnectionStringBuilder
							{
								InitialCatalog = this.DatabaseName,
								DataSource = this.ServerName,
								IntegratedSecurity = false,
								UserID = this.UserID,
								Password = this.Password
							}.ConnectionString
						}.ConnectionString;
					}
				}
				return connectionString;    
			}
		}

		private const string FILENAME = "ServiceConfig.xml";

		private const string CONFIG_PATH = "/configuration/Service";
	}
}
//DataSource = "LAPTOP-BDV7JS0S\\PHAM",
//DataSource = "VIRAS_TTA_DESKT\\VIRAS",
//DataSource = "DESKTOP-SRUH8A8\\SQLPHAM",
//DataSource = "DESKTOP-LP03ONR",
//DataSource = "DESKTOP-QOP03D",
//DataSource = "DESKTOP-658KU1P\\SQLEXPRESS",