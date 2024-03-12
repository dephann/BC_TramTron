using Microsoft.VisualBasic.Devices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Management;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace NDPSo.Utils
{
    public class StatusConnected
    {
        private bool _isOpen = false;
        
        private static string _hostname = Environment.MachineName;
        private static string _namePlan = ConfigManager.TramTronConfig.TenCty;
        private static string _contact = ConfigManager.TramTronConfig.DienThoaiCty;
        private static string _cff = "XXX";
        
        private static string a = "XXX";
        private static string _productVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
       
        public static void CheckOpenSof(bool isOpen, bool isControl)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
            
            ComputerInfo computerInfo = new ComputerInfo();
            string osNameS = computerInfo.OSFullName;
            Console.WriteLine("INFOR : " + osNameS);

            if (isOpen && isControl)
            {
                AddDataToServer(_hostname, _namePlan, "Running", "Running", _cff, _productVersion, a);
            }
            else if(isOpen && !isControl)
            {
                AddDataToServer(_hostname, _namePlan, "Running", "Stopped", _cff, _productVersion, a);
            }
            else if(!isOpen && !isControl)
            {
                AddDataToServer(_hostname, _namePlan, "Stopped", "Stopped", _cff, _productVersion, a);
            }
        }
        private static async void AddDataToServer(string NameMachine,
                                    string NamePlan,
                                    string ActiveStatus,
                                    string ControlStatus,
                                    string ConfigFile,
                                    string Version,
                                    string Contact
                                    )
        {


            var data = new Dictionary<string, string>
            {
                { "NameMachine", NameMachine},
                { "NamePlan", NamePlan},
                { "ActiveStatus", ActiveStatus},
                { "ControlStatus", ControlStatus},
                { "ConfigFile", ConfigFile},
                { "Version", Version},
                { "Contact", Contact}

            };

            using (var httpClient = new HttpClient())
            {
                try
                {
                    string url = "https://connected-six.vercel.app/connected/add";

                    var json = JsonConvert.SerializeObject(data);

                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync(url, content);
                    if (response.IsSuccessStatusCode)
                    {
                        if (response.ReasonPhrase == "OK")
                        {
                            Console.WriteLine("OK");
                        }
                        else
                        {
                            Console.WriteLine("Fail");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not Connected");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No Connect");
                }
            }

        }

    }
}
