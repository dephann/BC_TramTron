using DevExpress.XtraEditors;
using NDPSo.Data;
using NDPSo.MasterData.TronOnlineView.UserControls;
using NDPSo.PLCMapping;
using NDPSo.PLCModule;
using NDPSo.Utils;
using S7.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDPSo.MasterData
{
    public partial class FrmKiemDinhCan : DialogViewBase, IFrmKiemDinhCan, IBase
    {

        private SendingToPLC _so = new SendingToPLC();
        private ReceivingFromPLC _ro = new ReceivingFromPLC();
        private PLCController _plcController = new PLCController();
        private SetPoint _sp = new SetPoint();
        public FrmKiemDinhCan()
        {
            InitializeComponent();
        }

        protected override void PopulateStaticData()
        {
            LoadingView();
            //LoadDataConfig();
        }

        private void LoadDataConfig()
        {
            this.uc_ChinhCan_AGG1.GiaTri_Nhap0 = ConfigManager.TramTronConfig.KL_ZERO_AGG1;
            this.uc_ChinhCan_AGG1.GiaTri_NhapTai = ConfigManager.TramTronConfig.KL_SPAN_AGG1;
            this.uc_ChinhCan_AGG2.GiaTri_Nhap0 = ConfigManager.TramTronConfig.KL_ZERO_AGG2;
            this.uc_ChinhCan_AGG2.GiaTri_NhapTai = ConfigManager.TramTronConfig.KL_SPAN_AGG2;
            this.uc_ChinhCan_AGG3.GiaTri_Nhap0 = ConfigManager.TramTronConfig.KL_ZERO_AGG3;
            this.uc_ChinhCan_AGG3.GiaTri_NhapTai = ConfigManager.TramTronConfig.KL_SPAN_AGG3;
            this.uc_ChinhCan_AGG4.GiaTri_Nhap0 = ConfigManager.TramTronConfig.KL_ZERO_AGG4;
            this.uc_ChinhCan_AGG4.GiaTri_NhapTai = ConfigManager.TramTronConfig.KL_SPAN_AGG4;
            this.uc_ChinhCan_AGG5.GiaTri_Nhap0 = ConfigManager.TramTronConfig.KL_ZERO_AGG5;
            this.uc_ChinhCan_AGG5.GiaTri_NhapTai = ConfigManager.TramTronConfig.KL_SPAN_AGG5;
            this.uc_ChinhCan_AGG6.GiaTri_Nhap0 = ConfigManager.TramTronConfig.KL_ZERO_AGG6;
            this.uc_ChinhCan_AGG6.GiaTri_NhapTai = ConfigManager.TramTronConfig.KL_SPAN_AGG6;
            this.uc_ChinhCan_CE1.GiaTri_Nhap0 = ConfigManager.TramTronConfig.KL_ZERO_CEM1;
            this.uc_ChinhCan_CE1.GiaTri_NhapTai = ConfigManager.TramTronConfig.KL_SPAN_CEM1;
            this.uc_ChinhCan_CE2.GiaTri_Nhap0 = ConfigManager.TramTronConfig.KL_ZERO_CEM2;
            this.uc_ChinhCan_CE2.GiaTri_NhapTai = ConfigManager.TramTronConfig.KL_SPAN_CEM2;
            this.uc_ChinhCan_WA1.GiaTri_Nhap0 = ConfigManager.TramTronConfig.KL_ZERO_WA1;
            this.uc_ChinhCan_WA1.GiaTri_NhapTai = ConfigManager.TramTronConfig.KL_SPAN_WA1;
            this.uc_ChinhCan_WA2.GiaTri_Nhap0 = ConfigManager.TramTronConfig.KL_ZERO_WA2;
            this.uc_ChinhCan_WA2.GiaTri_NhapTai = ConfigManager.TramTronConfig.KL_SPAN_WA2;
            this.uc_ChinhCan_ADD1.GiaTri_Nhap0 = ConfigManager.TramTronConfig.KL_ZERO_ADD1;
            this.uc_ChinhCan_ADD1.GiaTri_NhapTai = ConfigManager.TramTronConfig.KL_SPAN_ADD1;
            this.uc_ChinhCan_ADD2.GiaTri_Nhap0 = ConfigManager.TramTronConfig.KL_ZERO_ADD2;
            this.uc_ChinhCan_ADD2.GiaTri_NhapTai = ConfigManager.TramTronConfig.KL_SPAN_ADD2;

        }
        private void LoadingView()
        {
            CreateWei_AGG(ConfigManager.TramTronConfig.SL_Wei_AGG);
            CreateWei_CE(ConfigManager.TramTronConfig.SL_Wei_CE);
            CreateWei_WA(ConfigManager.TramTronConfig.SL_Wei_WA);
            CreateWei_ADD(ConfigManager.TramTronConfig.SL_Wei_ADD);
        }
        private void ActiveWei(List<UcNhomChinhCan> lst_Silo, int sl)
        {
            LimitedList<UcNhomChinhCan> limitedList = new LimitedList<UcNhomChinhCan>(sl);
            for (int i = 0; i < sl; i++)
            {
                limitedList.Add(lst_Silo[i]);
            }
            foreach (UcNhomChinhCan sl_Silo in limitedList)
            {
                sl_Silo.Visible = true;
            }
        }
        private void CreateWei_AGG(int sl)
        {
            List<UcNhomChinhCan> lst_Agg = new List<UcNhomChinhCan>();
            lst_Agg.Add(uc_ChinhCan_AGG1);
            lst_Agg.Add(uc_ChinhCan_AGG2);
            lst_Agg.Add(uc_ChinhCan_AGG3);
            lst_Agg.Add(uc_ChinhCan_AGG4);
            lst_Agg.Add(uc_ChinhCan_AGG5);
            lst_Agg.Add(uc_ChinhCan_AGG6);
            foreach (UcNhomChinhCan silo_Agg in lst_Agg)
            {
                silo_Agg.Visible = false;
            }
            ActiveWei(lst_Agg, sl);
        }
        private void CreateWei_CE(int sl)
        {
            List<UcNhomChinhCan> lst_Agg = new List<UcNhomChinhCan>();
            lst_Agg.Add(uc_ChinhCan_CE1);
            lst_Agg.Add(uc_ChinhCan_CE2);
            
            foreach (UcNhomChinhCan silo_Agg in lst_Agg)
            {
                silo_Agg.Visible = false;
            }
            ActiveWei(lst_Agg, sl);
        }
        private void CreateWei_WA(int sl)
        {
            List<UcNhomChinhCan> lst_Agg = new List<UcNhomChinhCan>();
            lst_Agg.Add(uc_ChinhCan_WA1);
            lst_Agg.Add(uc_ChinhCan_WA2);

            foreach (UcNhomChinhCan silo_Agg in lst_Agg)
            {
                silo_Agg.Visible = false;
            }
            ActiveWei(lst_Agg, sl);
        }
        private void CreateWei_ADD(int sl)
        {
            List<UcNhomChinhCan> lst_Agg = new List<UcNhomChinhCan>();
            lst_Agg.Add(uc_ChinhCan_ADD1);
            lst_Agg.Add(uc_ChinhCan_ADD2);

            foreach (UcNhomChinhCan silo_Agg in lst_Agg)
            {
                silo_Agg.Visible = false;
            }
            ActiveWei(lst_Agg, sl);
        }

        public BindingList<ObjWeigh> BLstWeigh { set => throw new NotImplementedException(); }

        private void Send_Data_DB_2_To_PLC()
        {
            List<byte> list_00 = new List<byte>();
            //list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreCan_Agg));// 0
            //list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreXa_Agg));// 4
            //list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreDongCan_Agg));// 8
            //list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KhoiLuongBaoRong_Agg));// 12
            //list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KhoiLuongRungCan_Agg));// 16
            //list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianBatRung_Agg));// 20
            //list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTatRung_Agg));// 24
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreCan_Ce));// 28
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreXa_Ce));// 32
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreDongCan_Ce));// 36
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KhoiLuongBaoRong_Ce));// 40
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KhoiLuongRungCan_Ce));// 44
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianBatRung_Ce));// 48
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTatRung_Ce));// 52
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreCan_Wa));// 56
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreXa_Wa));// 60
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreDongCan_Wa));// 64
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KhoiLuongBaoRong_Wa));// 68
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.XungCan_Agg));// 72
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_Chinh_0_Agg));// 76
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_ChinhTai_Agg));// 80
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_Thuc_Agg));// 84
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.XungCan_Ce));// 88
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_Chinh_0_Ce));// 92
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_ChinhTai_Ce));// 96
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_Thuc_Ce));// 100
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.XungCan_Wa));// 104
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_Chinh_0_Wa));// 108
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_ChinhTai_Wa));// 112
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_Thuc_Wa));// 116

            byte[] value = list_00.ToArray();
            this._plcController.WriteBytes(DataType.DataBlock, 2, 0, value);
        }
        private void Send_Data_DB_6_To_PLC()
        {
            List<byte> list_00 = new List<byte>();
           
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_ZERO_AGG1));// 48
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_SPAN_AGG1));// 52
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_ZERO_AGG2));// 56
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_SPAN_AGG2));// 60
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_ZERO_AGG3));// 64
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_SPAN_AGG3));// 68
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_ZERO_AGG4));// 72
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_SPAN_AGG4));// 76
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_ZERO_AGG5));// 80
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_SPAN_AGG5));// 84
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_ZERO_AGG6));// 88
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_SPAN_AGG6));// 92
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_ZERO_CEM1));// 96
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_SPAN_CEM1));// 100
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_ZERO_CEM2));// 104
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_SPAN_CEM2));// 108
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_ZERO_WAT1));// 112
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_SPAN_WAT1));// 116
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_ZERO_WAT2));// 120
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_SPAN_WAT2));// 124
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_ZERO_ADD1));// 128
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_SPAN_ADD1));// 132
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_ZERO_ADD2));// 136
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_SPAN_ADD2));// 140
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.HS_XUNG_PG1));// 144
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.HS_XUNG_PG2));// 148
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.HS_XUNG_PG3));// 152
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.HS_XUNG_PG4));// 156
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.HS_XUNG_PG5));// 160
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.HS_XUNG_PG6));// 164
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_XUNG_PG1));// 168
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_XUNG_PG2));// 172
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_XUNG_PG3));// 176
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_XUNG_PG4));// 180
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_XUNG_PG5));// 184
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_XUNG_PG6));// 188

            byte[] value = list_00.ToArray();
            this._plcController.WriteBytes(DataType.DataBlock, 6, 48, value);
        }
        private void Send_Data_DB_5_To_PLC()
        {
            if (this._plcController == null)
            {
                MessageBox.Show("PLC MẤT KẾT NỐI");
                return;
            }
            List<byte> list = new List<byte>();
            
            list.Add(this._so.Byte_12);
            list.Add(this._so.Byte_13);
            list.Add(this._so.Byte_14);
            list.Add(this._so.Byte_15);
            list.Add(this._so.Byte_16);
            
            byte[] value = list.ToArray();
            this._plcController.WriteBytes(DataType.DataBlock, 2, 12, value);
        }

        private void SendData_DB_5_NewTread()
        {
            Thread thread = new Thread(new ThreadStart(this.Send_Data_DB_5_To_PLC));
            thread.Start();
        }
        private void SendData_DB_2_NewTread()
        {
            Thread thread = new Thread(new ThreadStart(this.Send_Data_DB_2_To_PLC));
            thread.Start();
        }
        private void SendData_DB_6_NewTread()
        {
            Thread thread = new Thread(new ThreadStart(this.Send_Data_DB_6_To_PLC));
            thread.Start();
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_plcController.IsConnected)
            {
                
                byte[] c = this._plcController.ReadBytes(DataType.DataBlock, 6, 0, 292);
                ReceiveData_DB6(c);
                BindReceivingOnline(_ro);
            }
            
        }

        private void BindReceivingOnline(ReceivingFromPLC ro)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => this.BindReceivingOnline(ro)));
                }
                else
                {
                    uc_ChinhCan_AGG1.GiaTri_Xung = _ro.Xung_Agg_1.ToString();
                    uc_ChinhCan_AGG2.GiaTri_Xung = _ro.Xung_Agg_2.ToString();
                    uc_ChinhCan_AGG3.GiaTri_Xung = _ro.Xung_Agg_3.ToString();
                    uc_ChinhCan_AGG4.GiaTri_Xung = _ro.Xung_Agg_4.ToString();
                    uc_ChinhCan_AGG5.GiaTri_Xung = _ro.Xung_Agg_5.ToString();
                    uc_ChinhCan_AGG6.GiaTri_Xung = _ro.Xung_Agg_6.ToString();
                    uc_ChinhCan_CE1.GiaTri_Xung = _ro.Xung_Cem_1.ToString();
                    uc_ChinhCan_CE2.GiaTri_Xung = _ro.Xung_Cem_2.ToString();
                    uc_ChinhCan_WA1.GiaTri_Xung = _ro.Xung_Wa_1.ToString();
                    uc_ChinhCan_WA2.GiaTri_Xung = _ro.Xung_Wa_2.ToString();
                    uc_ChinhCan_ADD1.GiaTri_Xung = _ro.Xung_Add_1.ToString();
                    uc_ChinhCan_ADD2.GiaTri_Xung = _ro.Xung_Add_2.ToString();
                    //KL Thuc Te

                    uc_ChinhCan_AGG1.GiaTri_KLThucTe = _ro.KLT_AGG1.ToString();
                    uc_ChinhCan_AGG2.GiaTri_KLThucTe = _ro.KLT_AGG2.ToString();
                    uc_ChinhCan_AGG3.GiaTri_KLThucTe = _ro.KLT_AGG3.ToString();
                    uc_ChinhCan_AGG4.GiaTri_KLThucTe = _ro.KLT_AGG4.ToString();
                    uc_ChinhCan_AGG5.GiaTri_KLThucTe = _ro.KLT_AGG5.ToString();
                    uc_ChinhCan_AGG6.GiaTri_KLThucTe = _ro.KLT_AGG6.ToString();
                    uc_ChinhCan_CE1.GiaTri_KLThucTe = _ro.KLT_WCE1.ToString();
                    uc_ChinhCan_CE2.GiaTri_KLThucTe = _ro.KLT_WCE2.ToString();
                    uc_ChinhCan_WA1.GiaTri_KLThucTe = _ro.KLT_WA1.ToString();
                    uc_ChinhCan_WA2.GiaTri_KLThucTe = _ro.KLT_WA2.ToString();
                    uc_ChinhCan_ADD1.GiaTri_KLThucTe = _ro.KLT_ADD1.ToString();
                    uc_ChinhCan_ADD2.GiaTri_KLThucTe = _ro.KLT_ADD2.ToString();
                    //

                    ucNhomChinhCanAdd1.GiaTri_Xung = _ro.KLX_ADD1.ToString();
                    ucNhomChinhCanAdd2.GiaTri_Xung = _ro.KLX_ADD2.ToString();
                    ucNhomChinhCanAdd3.GiaTri_Xung = _ro.KLX_ADD3.ToString();
                    ucNhomChinhCanAdd4.GiaTri_Xung = _ro.KLX_ADD4.ToString();
                    ucNhomChinhCanAdd5.GiaTri_Xung = _ro.KLX_ADD5.ToString();
                    ucNhomChinhCanAdd6.GiaTri_Xung = _ro.KLX_ADD6.ToString();

                }
            }
            catch (ThreadAbortException ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private double ConvertData(uint data)
        {
            double a = data.ConvertToFloat();
            if (a > 32000 || a < -32000)
            {
                return a = 0;
            }
            else
                return a;
        }
       
        private void ReceiveData_DB6(byte[] a) //READ DATA FROM PLC
        {
            this._ro.Xung_Agg_1 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[0], a[1], a[2], a[3])); // 0
            this._ro.Xung_Agg_2 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[4], a[5], a[6], a[7])); // 4
            this._ro.Xung_Agg_3 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[8], a[9], a[10], a[11])); // 8
            this._ro.Xung_Agg_4 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[12], a[13], a[14], a[15])); // 12
            this._ro.Xung_Agg_5 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[16], a[17], a[18], a[19])); // 16
            this._ro.Xung_Agg_6 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[20], a[21], a[22], a[23])); // 20
            this._ro.Xung_Cem_1 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[24], a[25], a[26], a[27])); // 24
            this._ro.Xung_Cem_2 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[28], a[29], a[30], a[31])); // 28
            this._ro.Xung_Wa_1 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[32], a[33], a[34], a[35])); // 32
            this._ro.Xung_Wa_2 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[36], a[37], a[38], a[39])); // 36
            this._ro.Xung_Add_1 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[40], a[41], a[42], a[43])); // 40
            this._ro.Xung_Add_2 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[44], a[45], a[46], a[47])); // 44
            this._ro.Zero_Agg1 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[48], a[49], a[50], a[51])); // 48
            this._ro.Span_Agg1 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[52], a[53], a[54], a[55])); // 52
            this._ro.Zero_Agg2 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[56], a[57], a[58], a[59])); // 56
            this._ro.Span_Agg2 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[60], a[61], a[62], a[63])); // 60
            this._ro.Zero_Agg3 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[64], a[65], a[66], a[67])); // 64
            this._ro.Span_Agg3 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[68], a[69], a[70], a[71])); // 68
            this._ro.Zero_Agg4 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[72], a[73], a[74], a[75])); // 72
            this._ro.Span_Agg4 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[76], a[77], a[78], a[79])); // 76
            this._ro.Zero_Agg5 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[80], a[81], a[82], a[83])); // 80
            this._ro.Span_Agg5 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[84], a[85], a[86], a[87])); // 84
            this._ro.Zero_Agg6 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[88], a[89], a[90], a[91])); // 88
            this._ro.Span_Agg6 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[92], a[93], a[94], a[95])); // 92
            this._ro.Zero_Ce1 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[96], a[97], a[98], a[99])); // 96
            this._ro.Span_Ce1 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[100], a[101], a[102], a[103])); // 100
            this._ro.Zero_Ce2 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[104], a[105], a[106], a[107])); // 104
            this._ro.Span_Ce2 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[108], a[109], a[110], a[111])); // 108
            this._ro.Zero_Wa1 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[112], a[113], a[114], a[115])); // 112
            this._ro.Span_Wa1 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[116], a[117], a[118], a[119])); // 116
            this._ro.Zero_Wa2 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[120], a[121], a[122], a[123])); // 120
            this._ro.Span_Wa2 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[124], a[125], a[126], a[127])); // 124
            this._ro.Zero_Add1 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[128], a[129], a[130], a[131])); // 128
            this._ro.Span_Add1 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[132], a[133], a[134], a[135])); // 132
            this._ro.Zero_Add2 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[136], a[137], a[138], a[139])); // 136
            this._ro.Span_Add2 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[140], a[141], a[142], a[143])); // 140
            this._ro.HS_Xung_PG1 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[144], a[145], a[146], a[147])); // 144
            this._ro.HS_Xung_PG2 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[148], a[149], a[150], a[151])); // 148
            this._ro.HS_Xung_PG3 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[152], a[153], a[154], a[155])); // 152
            this._ro.HS_Xung_PG4 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[156], a[157], a[158], a[159])); // 156
            this._ro.HS_Xung_PG5 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[160], a[161], a[162], a[163])); // 160
            this._ro.HS_Xung_PG6 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[164], a[165], a[166], a[167])); // 164
            this._ro.KL_Xung_PG1 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[168], a[169], a[170], a[171])); // 168
            this._ro.KL_Xung_PG2 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[172], a[173], a[174], a[175])); // 172
            this._ro.KL_Xung_PG3 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[176], a[177], a[178], a[179])); // 176
            this._ro.KL_Xung_PG4 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[180], a[181], a[182], a[183])); // 180
            this._ro.KL_Xung_PG5 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[184], a[185], a[186], a[187])); // 184
            this._ro.KL_Xung_PG6 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[188], a[189], a[190], a[191])); // 188

            this._ro.KLT_AGG1= this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[220], a[221], a[222], a[223])); // 220
            this._ro.KLT_AGG2= this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[224], a[225], a[226], a[227])); // 224
            this._ro.KLT_AGG3= this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[228], a[229], a[230], a[231])); // 228
            this._ro.KLT_AGG4= this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[232], a[233], a[234], a[235])); // 232
            this._ro.KLT_AGG5= this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[236], a[237], a[238], a[239])); // 236
            this._ro.KLT_AGG6= this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[240], a[241], a[242], a[243])); // 240
            this._ro.KLT_WCE1= this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[244], a[245], a[246], a[247])); // 244
            this._ro.KLT_WCE2= this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[248], a[249], a[250], a[251])); // 248
            this._ro.KLT_WA1= this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[252], a[253], a[254], a[255])); // 252
            this._ro.KLT_WA2= this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[256], a[257], a[258], a[259])); // 256
            this._ro.KLT_ADD1= this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[260], a[261], a[262], a[263])); // 260
            this._ro.KLT_ADD2= this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[264], a[265], a[266], a[267])); // 264

            this._ro.KLX_ADD1= this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[268], a[269], a[270], a[271])); // 268
            this._ro.KLX_ADD2= this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[272], a[273], a[274], a[275])); // 272
            this._ro.KLX_ADD3= this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[276], a[277], a[278], a[279])); // 276
            this._ro.KLX_ADD4= this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[280], a[281], a[282], a[283])); // 280
            this._ro.KLX_ADD5= this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[284], a[285], a[286], a[287])); // 284
            this._ro.KLX_ADD6= this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[288], a[289], a[290], a[291])); // 288


        }
        
        private void FrmKiemDinhCan_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start();
        }


        // CHINH CAN AGG 1

        private void uc_ChinhCan_AGG1_Enter_Down_Nhap0(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    this._sp.KL_ZERO_AGG1 = Double.Parse(this.uc_ChinhCan_AGG1.GiaTri_Nhap0);
                    this.SendData_DB_6_NewTread();
                    ConfigManager.TramTronConfig.KL_ZERO_AGG1 = this.uc_ChinhCan_AGG1.GiaTri_Nhap0;
                    break;

            }
        }
        private void uc_ChinhCan_AGG1_Enter_Down_NhapTai(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    this._sp.KL_SPAN_AGG1 = Double.Parse(this.uc_ChinhCan_AGG1.GiaTri_NhapTai);
                    this.SendData_DB_6_NewTread();
                    ConfigManager.TramTronConfig.KL_SPAN_AGG1 = this.uc_ChinhCan_AGG1.GiaTri_NhapTai;
                    break;

            }
        }
        
        private void uc_ChinhCan_AGG1_ButtonChinh0_Down(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_ZERO_AGG1 = true;
            this.SendData_DB_5_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void uc_ChinhCan_AGG1_ButtonChinh0_Up(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_ZERO_AGG1 = false;
            this.SendData_DB_5_NewTread();
        }

        private void uc_ChinhCan_AGG1_ButtonChinhTai_Down(object sender, EventArgs e)
        {
           
            this._so.SendingCommand.NN_SPAN_AGG1 = true;
            this.SendData_DB_5_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void uc_ChinhCan_AGG1_ButtonChinhTai_Up(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_SPAN_AGG1 = false;
            this.SendData_DB_5_NewTread();
        }
        // CHINH CAN AGG 2
        private void uc_ChinhCan_AGG2_Enter_Down_Nhap0(object sender, KeyEventArgs e)
        {
            this._sp.KL_ZERO_AGG2 = Double.Parse(this.uc_ChinhCan_AGG2.GiaTri_Nhap0);
            this.SendData_DB_6_NewTread();
            ConfigManager.TramTronConfig.KL_ZERO_AGG2 = this.uc_ChinhCan_AGG2.GiaTri_Nhap0;
        }

        private void uc_ChinhCan_AGG2_Enter_Down_NhapTai(object sender, KeyEventArgs e)
        {
            this._sp.KL_SPAN_AGG2 = Double.Parse(this.uc_ChinhCan_AGG2.GiaTri_NhapTai);
            this.SendData_DB_6_NewTread();
            ConfigManager.TramTronConfig.KL_SPAN_AGG2 = this.uc_ChinhCan_AGG2.GiaTri_NhapTai;
        }
        
        private void uc_ChinhCan_AGG2_ButtonChinh0_Down(object sender, EventArgs e)
        {
            
            this._so.SendingCommand.NN_ZERO_AGG2 = true;
            this.SendData_DB_5_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void uc_ChinhCan_AGG2_ButtonChinh0_Up(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_ZERO_AGG2 = false;
            this.SendData_DB_5_NewTread();
        }

        private void uc_ChinhCan_AGG2_ButtonChinhTai_Down(object sender, EventArgs e)
        {
           
            this._so.SendingCommand.NN_SPAN_AGG2 = true;
            this.SendData_DB_5_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void uc_ChinhCan_AGG2_ButtonChinhTai_Up(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_SPAN_AGG2 = false;
            this.SendData_DB_5_NewTread();
        }
        // CHINH CAN AGG 3
        private void uc_ChinhCan_AGG3_ButtonChinh0_Down(object sender, EventArgs e)
        {
            this._sp.KL_ZERO_AGG3 = Double.Parse(this.uc_ChinhCan_AGG3.GiaTri_Nhap0);
            this.SendData_DB_6_NewTread();
            this._so.SendingCommand.NN_ZERO_AGG3 = true;
            this.SendData_DB_5_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void uc_ChinhCan_AGG3_ButtonChinh0_Up(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_ZERO_AGG3 = false;
            this.SendData_DB_5_NewTread();
        }

        private void uc_ChinhCan_AGG3_ButtonChinhTai_Down(object sender, EventArgs e)
        {
            this._sp.KL_SPAN_AGG3 = Double.Parse(this.uc_ChinhCan_AGG3.GiaTri_NhapTai);
            this.SendData_DB_6_NewTread();
            this._so.SendingCommand.NN_SPAN_AGG3 = true;
            this.SendData_DB_5_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void uc_ChinhCan_AGG3_ButtonChinhTai_Up(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_SPAN_AGG3 = false;
            this.SendData_DB_5_NewTread();
        }
        // CHINH CAN AGG 4
        private void uc_ChinhCan_AGG4_ButtonChinh0_Down(object sender, EventArgs e)
        {
            this._sp.KL_ZERO_AGG4 = Double.Parse(this.uc_ChinhCan_AGG4.GiaTri_Nhap0);
            this.SendData_DB_6_NewTread();
            this._so.SendingCommand.NN_ZERO_AGG4 = true;
            this.SendData_DB_5_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void uc_ChinhCan_AGG4_ButtonChinh0_Up(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_ZERO_AGG4 = false;
            this.SendData_DB_5_NewTread();
        }

        private void uc_ChinhCan_AGG4_ButtonChinhTai_Down(object sender, EventArgs e)
        {
            this._sp.KL_SPAN_AGG4 = Double.Parse(this.uc_ChinhCan_AGG4.GiaTri_NhapTai);
            this.SendData_DB_6_NewTread();
            this._so.SendingCommand.NN_SPAN_AGG4 = true;
            this.SendData_DB_5_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void uc_ChinhCan_AGG4_ButtonChinhTai_Up(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_SPAN_AGG4 = false;
            this.SendData_DB_5_NewTread();
        }
        // CHINH CAN AGG 5
        private void uc_ChinhCan_AGG5_ButtonChinh0_Down(object sender, EventArgs e)
        {
            this._sp.KL_ZERO_AGG5 = Double.Parse(this.uc_ChinhCan_AGG5.GiaTri_Nhap0);
            this.SendData_DB_6_NewTread();
            this._so.SendingCommand.NN_ZERO_AGG5 = true;
            this.SendData_DB_5_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void uc_ChinhCan_AGG5_ButtonChinh0_Up(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_ZERO_AGG5 = false;
            this.SendData_DB_5_NewTread();
        }

        private void uc_ChinhCan_AGG5_ButtonChinhTai_Down(object sender, EventArgs e)
        {
            this._sp.KL_SPAN_AGG5 = Double.Parse(this.uc_ChinhCan_AGG5.GiaTri_NhapTai);
            this.SendData_DB_6_NewTread();
            this._so.SendingCommand.NN_SPAN_AGG5 = true;
            this.SendData_DB_5_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void uc_ChinhCan_AGG5_ButtonChinhTai_Up(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_SPAN_AGG5 = false;
            this.SendData_DB_5_NewTread();
        }
        // CHINH CAN AGG 6
        private void uc_ChinhCan_AGG6_ButtonChinh0_Down(object sender, EventArgs e)
        {
            this._sp.KL_ZERO_AGG6 = Double.Parse(this.uc_ChinhCan_AGG6.GiaTri_Nhap0);
            this.SendData_DB_6_NewTread();
            this._so.SendingCommand.NN_ZERO_AGG6 = true;
            this.SendData_DB_5_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void uc_ChinhCan_AGG6_ButtonChinh0_Up(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_ZERO_AGG6 = false;
            this.SendData_DB_5_NewTread();
        }

        private void uc_ChinhCan_AGG6_ButtonChinhTai_Down(object sender, EventArgs e)
        {
            this._sp.KL_SPAN_AGG6 = Double.Parse(this.uc_ChinhCan_AGG6.GiaTri_NhapTai);
            this.SendData_DB_6_NewTread();
            this._so.SendingCommand.NN_SPAN_AGG6 = true;
            this.SendData_DB_5_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void uc_ChinhCan_AGG6_ButtonChinhTai_Up(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_SPAN_AGG6 = false;
            this.SendData_DB_5_NewTread();
        }
        // CHINH CAN CE 1
        private void uc_ChinhCan_CE1_Enter_Down_Nhap0(object sender, KeyEventArgs e)
        {
            this._sp.KL_ZERO_CEM1 = Double.Parse(this.uc_ChinhCan_CE1.GiaTri_Nhap0);
            this.SendData_DB_6_NewTread();
            ConfigManager.TramTronConfig.KL_ZERO_CEM1 = this.uc_ChinhCan_CE1.GiaTri_Nhap0;
        }

        private void uc_ChinhCan_CE1_Enter_Down_NhapTai(object sender, KeyEventArgs e)
        {
            this._sp.KL_SPAN_CEM1 = Double.Parse(this.uc_ChinhCan_CE1.GiaTri_NhapTai);
            this.SendData_DB_6_NewTread();
            ConfigManager.TramTronConfig.KL_SPAN_CEM1 = this.uc_ChinhCan_CE1.GiaTri_NhapTai;
        }
        
        private void uc_ChinhCan_CE1_ButtonChinh0_Down(object sender, EventArgs e)
        {
            
            this._so.SendingCommand.NN_ZERO_CEM1 = true;
            this.SendData_DB_5_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void uc_ChinhCan_CE1_ButtonChinh0_Up(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_ZERO_CEM1 = false;
            this.SendData_DB_5_NewTread();
        }

        private void uc_ChinhCan_CE1_ButtonChinhTai_Down(object sender, EventArgs e)
        {
            
            this._so.SendingCommand.NN_SPAN_CEM1 = true;
            this.SendData_DB_5_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void uc_ChinhCan_CE1_ButtonChinhTai_Up(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_SPAN_CEM1 = false;
            this.SendData_DB_5_NewTread();
        }
        // CHINH CAN CE 2
        private void uc_ChinhCan_CE2_ButtonChinh0_Down(object sender, EventArgs e)
        {
            this._sp.KL_ZERO_CEM2 = Double.Parse(this.uc_ChinhCan_CE2.GiaTri_Nhap0);
            this.SendData_DB_6_NewTread();
            this._so.SendingCommand.NN_ZERO_CEM2 = true;
            this.SendData_DB_5_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void uc_ChinhCan_CE2_ButtonChinh0_Up(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_ZERO_CEM2 = false;
            this.SendData_DB_5_NewTread();
        }

        private void uc_ChinhCan_CE2_ButtonChinhTai_Down(object sender, EventArgs e)
        {
            this._sp.KL_SPAN_CEM2 = Double.Parse(this.uc_ChinhCan_CE2.GiaTri_NhapTai);
            this.SendData_DB_6_NewTread();
            this._so.SendingCommand.NN_SPAN_CEM2 = true;
            this.SendData_DB_5_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void uc_ChinhCan_CE2_ButtonChinhTai_Up(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_SPAN_CEM2 = false;
            this.SendData_DB_5_NewTread();
        }
        // CHINH CAN WA 1
        private void uc_ChinhCan_WA1_Enter_Down_Nhap0(object sender, KeyEventArgs e)
        {
            this._sp.KL_ZERO_WAT1 = Double.Parse(this.uc_ChinhCan_WA1.GiaTri_Nhap0);
            this.SendData_DB_6_NewTread();
            ConfigManager.TramTronConfig.KL_ZERO_WA1 = this.uc_ChinhCan_WA1.GiaTri_Nhap0;
        }

        private void uc_ChinhCan_WA1_Enter_Down_NhapTai(object sender, KeyEventArgs e)
        {
            this._sp.KL_SPAN_WAT1 = Double.Parse(this.uc_ChinhCan_WA1.GiaTri_NhapTai);
            this.SendData_DB_6_NewTread();
            ConfigManager.TramTronConfig.KL_SPAN_WA1 = this.uc_ChinhCan_WA1.GiaTri_NhapTai;
        }
        
        private void uc_ChinhCan_WA1_ButtonChinh0_Down(object sender, EventArgs e)
        {
            
            this._so.SendingCommand.NN_ZERO_WAT1 = true;
            this.SendData_DB_5_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void uc_ChinhCan_WA1_ButtonChinh0_Up(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_ZERO_WAT1 = false;
            this.SendData_DB_5_NewTread();
        }

        private void uc_ChinhCan_WA1_ButtonChinhTai_Down(object sender, EventArgs e)
        {
            
            this._so.SendingCommand.NN_SPAN_WAT1 = true;
            this.SendData_DB_5_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void uc_ChinhCan_WA1_ButtonChinhTai_Up(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_SPAN_WAT1 = false;
            this.SendData_DB_5_NewTread();
        }
        // CHINH CAN WA 2
        private void uc_ChinhCan_WA2_ButtonChinh0_Down(object sender, EventArgs e)
        {
            this._sp.KL_ZERO_WAT2 = Double.Parse(this.uc_ChinhCan_WA2.GiaTri_Nhap0);
            this.SendData_DB_6_NewTread();
            this._so.SendingCommand.NN_ZERO_WAT2 = true;
            this.SendData_DB_5_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void uc_ChinhCan_WA2_ButtonChinh0_Up(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_ZERO_WAT2 = false;
            this.SendData_DB_5_NewTread();
        }

        private void uc_ChinhCan_WA2_ButtonChinhTai_Down(object sender, EventArgs e)
        {
            this._sp.KL_SPAN_WAT2 = Double.Parse(this.uc_ChinhCan_WA2.GiaTri_NhapTai);
            this.SendData_DB_6_NewTread();
            this._so.SendingCommand.NN_SPAN_WAT2 = true;
            this.SendData_DB_5_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void uc_ChinhCan_WA2_ButtonChinhTai_Up(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_SPAN_WAT2 = false;
            this.SendData_DB_5_NewTread();
        }
        // CHINH CAN ADD 1
        private void uc_ChinhCan_ADD1_Enter_Down_Nhap0(object sender, KeyEventArgs e)
        {
            this._sp.KL_ZERO_ADD1 = Double.Parse(this.uc_ChinhCan_ADD1.GiaTri_Nhap0);
            this.SendData_DB_6_NewTread();
            ConfigManager.TramTronConfig.KL_ZERO_ADD1 = this.uc_ChinhCan_ADD1.GiaTri_Nhap0;
        }

        private void uc_ChinhCan_ADD1_Enter_Down_NhapTai(object sender, KeyEventArgs e)
        {
            this._sp.KL_SPAN_ADD1 = Double.Parse(this.uc_ChinhCan_ADD1.GiaTri_NhapTai);
            this.SendData_DB_6_NewTread();
            ConfigManager.TramTronConfig.KL_SPAN_ADD1 = this.uc_ChinhCan_ADD1.GiaTri_NhapTai;
        }
        
        private void uc_ChinhCan_ADD1_ButtonChinh0_Down(object sender, EventArgs e)
        {
            
            this._so.SendingCommand.NN_ZERO_ADD1 = true;
            this.SendData_DB_5_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void uc_ChinhCan_ADD1_ButtonChinh0_Up(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_ZERO_ADD1 = false;
            this.SendData_DB_5_NewTread();
        }

        private void uc_ChinhCan_ADD1_ButtonChinhTai_Down(object sender, EventArgs e)
        {
           
            this._so.SendingCommand.NN_SPAN_ADD1 = true;
            this.SendData_DB_5_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void uc_ChinhCan_ADD1_ButtonChinhTai_Up(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_SPAN_ADD1 = false;
            this.SendData_DB_5_NewTread();
        }
        // CHINH CAN ADD 2
        private void uc_ChinhCan_ADD2_ButtonChinh0_Down(object sender, EventArgs e)
        {
            this._sp.KL_ZERO_ADD2 = Double.Parse(this.uc_ChinhCan_ADD2.GiaTri_Nhap0);
            this.SendData_DB_6_NewTread();
            this._so.SendingCommand.NN_ZERO_ADD2 = true;
            this.SendData_DB_5_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void uc_ChinhCan_ADD2_ButtonChinh0_Up(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_ZERO_ADD2 = false;
            this.SendData_DB_5_NewTread();
        }

        private void uc_ChinhCan_ADD2_ButtonChinhTai_Down(object sender, EventArgs e)
        {
            this._sp.KL_SPAN_ADD2 = Double.Parse(this.uc_ChinhCan_ADD2.GiaTri_NhapTai);
            this.SendData_DB_6_NewTread();
            this._so.SendingCommand.NN_SPAN_ADD2 = true;
            this.SendData_DB_5_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void uc_ChinhCan_ADD2_ButtonChinhTai_Up(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_SPAN_ADD2 = false;
            this.SendData_DB_5_NewTread();
        }

        private void ucNhomChinhCanAdd1_ButtonChinhTai_Down(object sender, EventArgs e)
        {
            this._sp.KL_XUNG_PG1= Double.Parse(this.ucNhomChinhCanAdd1.GiaTri_NhapTai);
            this.SendData_DB_6_NewTread();
            this._so.SendingCommand.SPAN_ADD1 = true;
            this.SendData_DB_5_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void ucNhomChinhCanAdd1_ButtonChinhTai_Up(object sender, EventArgs e)
        {
            this._so.SendingCommand.SPAN_ADD1 = false;
            this.SendData_DB_5_NewTread();
        }

        private void ucNhomChinhCanAdd2_ButtonChinhTai_Down(object sender, EventArgs e)
        {
            this._sp.KL_XUNG_PG2 = Double.Parse(this.ucNhomChinhCanAdd2.GiaTri_NhapTai);
            this.SendData_DB_6_NewTread();
            this._so.SendingCommand.SPAN_ADD2 = true;
            this.SendData_DB_5_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void ucNhomChinhCanAdd2_ButtonChinhTai_Up(object sender, EventArgs e)
        {
            this._so.SendingCommand.SPAN_ADD2 = false;
            this.SendData_DB_5_NewTread();
        }

        private void ucNhomChinhCanAdd3_ButtonChinhTai_Down(object sender, EventArgs e)
        {
            this._sp.KL_XUNG_PG3 = Double.Parse(this.ucNhomChinhCanAdd3.GiaTri_NhapTai);
            this.SendData_DB_6_NewTread();
            this._so.SendingCommand.SPAN_ADD3 = true;
            this.SendData_DB_5_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void ucNhomChinhCanAdd3_ButtonChinhTai_Up(object sender, EventArgs e)
        {
            this._so.SendingCommand.SPAN_ADD3 = false;
            this.SendData_DB_5_NewTread();
        }

        private void ucNhomChinhCanAdd4_ButtonChinhTai_Down(object sender, EventArgs e)
        {
            this._sp.KL_XUNG_PG4 = Double.Parse(this.ucNhomChinhCanAdd4.GiaTri_NhapTai);
            this.SendData_DB_6_NewTread();
            this._so.SendingCommand.SPAN_ADD4 = true;
            this.SendData_DB_5_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void ucNhomChinhCanAdd4_ButtonChinhTai_Up(object sender, EventArgs e)
        {
            this._so.SendingCommand.SPAN_ADD4 = false;
            this.SendData_DB_5_NewTread();
        }

        private void ucNhomChinhCanAdd5_ButtonChinhTai_Down(object sender, EventArgs e)
        {
            this._sp.KL_XUNG_PG5 = Double.Parse(this.ucNhomChinhCanAdd5.GiaTri_NhapTai);
            this.SendData_DB_6_NewTread();
            this._so.SendingCommand.SPAN_ADD5 = true;
            this.SendData_DB_5_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void ucNhomChinhCanAdd5_ButtonChinhTai_Up(object sender, EventArgs e)
        {
            this._so.SendingCommand.SPAN_ADD5 = false;
            this.SendData_DB_5_NewTread();
        }

        private void ucNhomChinhCanAdd6_ButtonChinhTai_Down(object sender, EventArgs e)
        {
            this._sp.KL_XUNG_PG6 = Double.Parse(this.ucNhomChinhCanAdd6.GiaTri_NhapTai);
            this.SendData_DB_6_NewTread();
            this._so.SendingCommand.SPAN_ADD6 = true;
            this.SendData_DB_5_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void ucNhomChinhCanAdd6_ButtonChinhTai_Up(object sender, EventArgs e)
        {
            this._so.SendingCommand.SPAN_ADD6 = false;
            this.SendData_DB_5_NewTread();
        }
    }
}