using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDPSo.MasterData
{
    public partial class UcSiloAgg : UcBaseSilo2
    {
        private Point mouseDownLocation;

        public UcSiloAgg()
        {
            InitializeComponent();
            
        }

        private void UcSiloAgg_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownLocation = e.Location;
        }

        private void UcSiloAgg_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int dx = e.Location.X - mouseDownLocation.X;
                int dy = e.Location.Y - mouseDownLocation.Y;

                // Di chuyển UserControl bằng cách thay đổi vị trí Top và Left
                this.Top += dy;
                this.Left += dx;
            }
        }
    }
}
