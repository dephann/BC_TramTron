using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NDPSo.Properties;
using System.Diagnostics;

namespace NDPSo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool isAlreadyRunning = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1;

            if (isAlreadyRunning)
            {
                MessageBox.Show("CMix đã được Khởi động.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new FrmMain().Show();
            Application.Run();
            
        }
    }
}
