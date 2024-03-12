using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDPSo.MasterData.TronOnlineView.UserControls
{
    public partial class UcGauTai : DevExpress.XtraEditors.XtraUserControl
    {
        private TrangThai _trangThai;
        private GauTaiStatus _trangThaiGT;
        private decimal _tongSoMe;
        private decimal _soMeDaTron;
        public event DelButtonEventHandler ButtonClick;
        public delegate void DelButtonEventHandler(object sender, EventArgs e);

        public enum TrangThai
        {
            GauDuoi,
            GauGiuaDuoi,
            GauCho,
            GauGiuaTren,
            GauTren,
            GauAnToan
        }
        public TrangThai IsTrangThai
        {
            get => this._trangThai;
            set
            {
                _trangThai = value;
                switch (this._trangThai)
                {
                    case TrangThai.GauDuoi:
                        {
                            this.picThanhTruoc.EditValue = ResourceNDP.ThanhTruoc_GauTai;
                            this.picPheu.Location = new Point(-3, 148);
                            this.lblStatusGAU.Location = new Point(16, 166);
                            this.ucSoMeDaCan1.Location = new Point(13, 149);
                            break;
                        }
                    case TrangThai.GauGiuaDuoi:
                        {
                            this.picThanhTruoc.EditValue = ResourceNDP.ThanhTruoc_GauTai;
                            this.picPheu.Location = new Point(25, 126);
                            this.lblStatusGAU.Location = new Point(44, 144);
                            this.ucSoMeDaCan1.Location = new Point(41, 127);
                            break;
                        }
                    case TrangThai.GauCho:
                        {
                            this.picThanhTruoc.EditValue = ResourceNDP.ThanhTruoc_GauTai;
                            this.picPheu.Location = new Point(57, 101);
                            this.lblStatusGAU.Location = new Point(76, 119);
                            this.ucSoMeDaCan1.Location = new Point(73, 102);
                            break;
                        }
                    case TrangThai.GauGiuaTren:
                        {
                            this.picThanhTruoc.EditValue = ResourceNDP.ThanhTruoc_GauTai;
                            this.picPheu.Location = new Point(96, 70);
                            this.lblStatusGAU.Location = new Point(115, 88);
                            this.ucSoMeDaCan1.Location = new Point(112, 71);
                            break;
                        }
                    case TrangThai.GauTren:
                        {
                            this.picThanhTruoc.EditValue = ResourceNDP.ThanhTruoc_GauTai;
                            this.picPheu.Location = new Point(145, 32);
                            this.lblStatusGAU.Location = new Point(164, 50);
                            this.ucSoMeDaCan1.Location = new Point(161, 33);
                            break;
                        }
                    case TrangThai.GauAnToan:
                        {
                            this.picThanhTruoc.EditValue = ResourceNDP.ThanhTruoc_GauTai;
                            this.picPheu.Location = new Point(145, 32);
                            this.lblStatusGAU.Location = new Point(164, 50);
                            this.ucSoMeDaCan1.Location = new Point(161, 33);
                            break;
                        }
                }
            }
        }

        public enum GauTaiStatus
        {
            Empty,
            Full,
            In,
            Out
        }
        public GauTaiStatus IsGauTaiStatus
        {
            get => this._trangThaiGT;
            set
            {
                _trangThaiGT = value;
                switch (this._trangThaiGT)
                {
                    case GauTaiStatus.Empty:
                        {
                            this.lblStatusGAU.Text = "EM";
                            break;
                        }
                    case GauTaiStatus.Full:
                        {
                            this.lblStatusGAU.Text = "FU";
                            break;
                        }
                    case GauTaiStatus.In:
                        {
                            this.lblStatusGAU.Text = "IN";
                            break;
                        }
                    case GauTaiStatus.Out:
                        {
                            this.lblStatusGAU.Text = "OU";
                            break;
                        }
                }
            }
        }

        public Decimal SoLuongMeCanTron
        {
            get => this._tongSoMe;
            set
            {
                this._tongSoMe = value;
                this.ucSoMeDaCan1.SoLuongMeCanTron = _tongSoMe;
            }
        }
        public Decimal SoMeDaTron
        {
            get => this._soMeDaTron;
            set
            {
                this._soMeDaTron = value;
                this.ucSoMeDaCan1.SoLuongMeDaTron = _soMeDaTron;
            }
        }
        public UcGauTai()
        {
            InitializeComponent();
        }

        private void pictureEdit3_Click(object sender, EventArgs e)
        {
            if (this.ButtonClick == null)
                return;
            this.ButtonClick((object)this, new EventArgs());
        }

        private void pictureEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void lblStatusGAU_Click(object sender, EventArgs e)
        {
            if (this.ButtonClick == null)
                return;
            this.ButtonClick((object)this, new EventArgs());
        }

        private void ucSoMeDaCan1_Click(object sender, EventArgs e)
        {
            if (this.ButtonClick == null)
                return;
            this.ButtonClick((object)this, new EventArgs());
        }
    }
}
