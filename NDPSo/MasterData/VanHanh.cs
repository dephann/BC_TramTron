using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Microsoft.Office.Interop.Word;
using NDPSo.ClientSetting;
using NDPSo.Data;
using NDPSo.KWS;
using NDPSo.MasterData.Config;
using NDPSo.MasterData.TronOnlineView.UserControls;
using NDPSo.PLCMapping;
using NDPSo.PLCModule;
using NDPSo.Utils;
using Newtonsoft.Json;
using S7.Net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataType = S7.Net.DataType;
using Task = System.Threading.Tasks.Task;

namespace NDPSo.MasterData
{
    public partial class VanHanh : ControlViewBase, IBase, IPermission, ITronOnlineView
    {
        private TronOnlineDataPresenter _presenter;
        private IServices _ser = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
        private PLCController _plcController = new PLCController();

        private List<ObjSEC_Function> _lstFunction = new List<ObjSEC_Function>();

        private SetPoint _sp = new SetPoint();
        private ReceivingFromPLC _ro = new ReceivingFromPLC();
        private SendingToPLC _so = new SendingToPLC();
        private TronOnlineAttributes _TronOnlineAttributes = new TronOnlineAttributes();
        private Thread _thread;
        private bool _Ready;
        private bool _isRunNoiTron;
        private bool _isRunBTX;
        private bool _isRunBTC;
        private bool _error;
        private Cursor customCursor;

        private bool _running;

        private bool _isSimulation;

        private bool _seletedLogic;

        private ObjPhieuTron _savingPT;

        private ObjHopDong _selectedHD_Run;

        private ObjPhieuTron _selectedPT_NextRun;

        private ObjPhieuTron _selectedPT_Run;
        private Decimal _themBotNuoc;
        private Decimal _giuNuocTenCan;

        private bool _CanNewDuLieuTron;
        private bool _CanAddMAC;
        private bool _CanEditMAC;
        private bool _CanViewMAC;
        private bool _CanEditDuLieuTron;
        private bool _CanEditDuLieuTron_KLOnly;
        private bool _CanDeleteDuLieuTron;

        private bool _flagSaveMAC;

        private int _idSavePLC = -1;
        private int _idSave = -1;
        
        private int soMeCanTronTest = -1;
        private int randomNumberTest = 1;
        private bool isTesst = false;

        private int some = 0;

        private bool IsRunningNoiTron = false;

        private decimal _LuyKe_InNhanh;
        List<string> paras = new List<string>();
        //PlayOff
        private DateTime timeNow;
        private DateTime timeTrie;

        public bool IsRunNoiTron
        {
            get => _isRunNoiTron;
            set
            {
                _isRunNoiTron = value;
                if (_isRunNoiTron)
                {
                    this.ucPrpel1.CheDo = UcPrpel.Action.Start;
                    this.ucPrpelSe1.CheDo = UcPrpelSe.Action.Start;
                }
                else
                {
                    this.ucPrpel1.CheDo = UcPrpel.Action.Pause;
                    this.ucPrpelSe1.CheDo = UcPrpelSe.Action.Pause;
                }
            }
        }
        public bool IsRunBTX
        {
            get => _isRunBTX;
            set
            {
                _isRunBTX = value;

                if (_isRunBTX)
                {
                    this.ucBTXien1.CheDo = UcBTXien.Action.Start;
                }
                else
                {
                    this.ucBTXien1.CheDo = UcBTXien.Action.Pause;
                }
            }
        }
        public bool IsRunBTC
        {
            get => _isRunBTC;
            set
            {
                _isRunBTC = value;

                if (_isRunBTC)
                {
                    this.ucBTCan1.CheDo = UcBTCan.Action.Start;
                }
                else
                {
                    this.ucBTCan1.CheDo = UcBTCan.Action.Pause;
                }
            }
        }
        
        public SetPoint SP
        {
            set
            {
                this._sp = value;
                this.BindSetPoint(this._sp);
            }
        }

        public BindingList<ObjDuLieuTron> BLstDuLieuTron
        {
            set
            {
                this._blstDuLieuTron = value;
                //LoadDuLieuTron();
                this.grcHopDong.DataSource = this._blstDuLieuTron;
            }
        }
        public BindingList<ObjMAC> BLstMAC { 
            set
            {
                this._blstMAC = value;
            }
        }

        public BindingList<ObjMACSilo> BLstMACSilo
        {
            set
            {
                this._blstMACSilo = value;
                this._blstMACSilo_Run = this._blstMACSilo;
            }
        }

        public BindingList<ObjPhieuTron> BLstPhieuTron
        {
            set
            {

            }
        }

        public BindingList<ObjSilo> BLstSilo
        {
            set
            {
                this._blstSilo = value;
                foreach (ObjSilo current in this._blstSilo)
                {
                    if (current.MaSilo == "Agg1")
                    {
                        this.siloAgg1.SiloCaption = current.MaSilo;
                        this.siloAgg1.SiloDesc = current.MaterialName;
                    }
                    else if (current.MaSilo == "Agg2")
                    {
                        this.siloAgg2.SiloCaption = current.MaSilo;
                        this.siloAgg2.SiloDesc = current.MaterialName;
                    }
                    else if (current.MaSilo == "Agg3")
                    {
                        this.siloAgg3.SiloCaption = current.MaSilo;
                        this.siloAgg3.SiloDesc = current.MaterialName;
                    }
                    else if (current.MaSilo == "Agg4")
                    {
                        this.siloAgg4.SiloCaption = current.MaSilo;
                        this.siloAgg4.SiloDesc = current.MaterialName;
                    }
                    else if (current.MaSilo == "Agg5")
                    {
                        this.siloAgg5.SiloCaption = current.MaSilo;
                        this.siloAgg5.SiloDesc = current.MaterialName;
                    }
                    else if (current.MaSilo == "Agg6")
                    {
                        this.siloAgg6.SiloCaption = current.MaSilo;
                        this.siloAgg6.SiloDesc = current.MaterialName;
                    }
                    else if (current.MaSilo == "Wa1")
                    {
                        this.siloWa1.SiloCaption = current.MaSilo;
                        this.siloWa1.SiloDesc = current.MaterialName;
                    }
                    else if (current.MaSilo == "Wa2")
                    {
                        this.siloWa2.SiloCaption = current.MaSilo;
                        this.siloWa2.SiloDesc = current.MaterialName;
                    }
                    else if (current.MaSilo == "Ce1")
                    {
                        this.siloCe1.SiloCaption = current.MaSilo;
                        this.siloCe1.SiloDesc = current.MaterialName;

                    }
                    else if (current.MaSilo == "Ce2")
                    {
                        this.siloCe2.SiloCaption = current.MaSilo;
                        this.siloCe2.SiloDesc = current.MaterialName;

                    }
                    else if (current.MaSilo == "Ce3")
                    {
                        this.siloCe3.SiloCaption = current.MaSilo;
                        this.siloCe3.SiloDesc = current.MaterialName;

                    }
                    else if (current.MaSilo == "Ce4")
                    {
                        this.siloCe4.SiloCaption = current.MaSilo;
                        this.siloCe4.SiloDesc = current.MaterialName;

                    }
                    else if (current.MaSilo == "Ce5")
                    {
                        this.siloCe5.SiloCaption = current.MaSilo;
                        this.siloCe5.SiloDesc = current.MaterialName;

                    }
                    else if (current.MaSilo == "Add1")
                    {
                        this.siloAdd1.SiloCaption = current.MaSilo;
                        this.siloAdd1.SiloDesc = current.MaterialName;
                    }
                    else if (current.MaSilo == "Add2")
                    {
                        this.siloAdd2.SiloCaption = current.MaSilo;
                        this.siloAdd2.SiloDesc = current.MaterialName;
                    }
                    else if (current.MaSilo == "Add3")
                    {
                        this.siloAdd3.SiloCaption = current.MaSilo;
                        this.siloAdd3.SiloDesc = current.MaterialName;
                    }
                    else if (current.MaSilo == "Add4")
                    {
                        this.siloAdd4.SiloCaption = current.MaSilo;
                        this.siloAdd4.SiloDesc = current.MaterialName;
                    }
                    else if (current.MaSilo == "Add5")
                    {
                        this.siloAdd5.SiloCaption = current.MaSilo;
                        this.siloAdd5.SiloDesc = current.MaterialName;
                    }
                    else if (current.MaSilo == "Add6")
                    {
                        this.siloAdd6.SiloCaption = current.MaSilo;
                        this.siloAdd6.SiloDesc = current.MaterialName;
                    }
                }
            }
        }

        public BindingList<ObjSilo> BLstSiloLogicAG
        {
            set
            {
                this._blstSiloLogicAG = value;
                _seletedLogic = false;
            }
        }
        public BindingList<ObjSilo> BLstSiloLogicAD
        {
            set
            {
                this._blstSiloLogicAD = value;
            }
        }

        public BindingList<ObjSilo> BLstSiloLogicCE
        {
            set
            {
                this._blstSiloLogicCE = value;
            }
        }

        public BindingList<ObjSilo> BLstSilo_DoAmHutAgg
        {
            set
            {
                this._blstSilo_DoAmHutAgg = value;
            }
        }
        public BindingList<ObjNhanVien> BLstNhanVien
        {
            set
            {
                this._blstNhanVien = value;
            }
        }
        public BindingList<ObjTaiXe> BLstTaiXe
        {
            set
            {
                this._blstTaiXe = value;
                this.lueDriver.Properties.DataSource = this._blstTaiXe;
            }
        }

        public BindingList<ObjTimerPara> BLstTimerPara
        {
            set
            {
                this._blstTimerPara = value;
                
                foreach (ObjTimerPara current in this._blstTimerPara)
                {
                    string timerParaCode;
                    timerParaCode = current.TimerParaCode;
                    switch (timerParaCode)
                    {
                        case "TG_Tron":
                            this._sp.ThoiGian_Tron = (double)current.TimerParaValue.Value;
                            break;
                        case "TG_Xa50":
                            this._sp.ThoiGian_Xa50 = (double)current.TimerParaValue.Value;
                            break;
                        case "TG_Xa100":
                            this._sp.ThoiGian_Xa100 = (double)current.TimerParaValue.Value;
                            break;
                        case "TG_XaCe_1SauPC":
                            this._sp.ThoiGian_XaCe1SauPC = (double)current.TimerParaValue.Value;
                            break;
                        case "TG_XaCe_2SauPC":
                            this._sp.ThoiGian_XaCe2SauPC = (double)current.TimerParaValue.Value;
                            break;
                        case "TG_XaNuocSauPC":
                            this._sp.ThoiGian_XaNuocSauPC = (double)current.TimerParaValue.Value;
                            break;
                        case "TG_XaCan_Agg1":
                            this._sp.ThoiGian_XaCan_Agg1 = (double)current.TimerParaValue.Value;
                            break;
                        case "TG_XaCan_Agg2":
                            this._sp.ThoiGian_XaCan_Agg2 = (double)current.TimerParaValue.Value;
                            break;
                        case "TG_XaCan_Agg3":
                            this._sp.ThoiGian_XaCan_Agg3 = (double)current.TimerParaValue.Value;
                            break;
                        case "TG_XaCan_Agg4":
                            this._sp.ThoiGian_XaCan_Agg4 = (double)current.TimerParaValue.Value;
                            break;
                        case "TG_XaCan_Agg5":
                            this._sp.ThoiGian_XaCan_Agg5 = (double)current.TimerParaValue.Value;
                            break;
                        case "TG_XaCan_Agg6":
                            this._sp.ThoiGian_XaCan_Agg6 = (double)current.TimerParaValue.Value;
                            break;
                        case "TG_XaWa2_PC":
                            this._sp.ThoiGian_XaWa2_PC = (double)current.TimerParaValue.Value;
                            break;
                        case "TG_XaAdd1_PC":
                            this._sp.ThoiGian_XaAdd1_PC = (double)current.TimerParaValue.Value;
                            break;
                        case "TG_XaAdd2_PC":
                            this._sp.ThoiGian_XaAdd2_PC = (double)current.TimerParaValue.Value;
                            break;
                        case "TG_AN_TOAN_GAU":
                            this._sp.ThoiGian_AnToanGau = (double)current.TimerParaValue.Value;
                            break;
                        case "TG_DL_GAU_LEN":
                            this._sp.ThoiGian_DL_GauLen = (double)current.TimerParaValue.Value;
                            break;
                        case "TG_DL_GAU_DUOI":
                            this._sp.ThoiGian_DL_GauDuoi = (double)current.TimerParaValue.Value;
                            break;
                        case "TG_DL_XA_GAU":
                            this._sp.ThoiGian_DL_XaGau = (double)current.TimerParaValue.Value;
                            break;
                        case "KL_XA_TRUOC_AGG1":
                            this._sp.KL_XaTruoc_Agg1 = (double)current.TimerParaValue.Value;
                            break;
                        case "KL_XA_TRUOC_AGG2":
                            this._sp.KL_XaTruoc_Agg2 = (double)current.TimerParaValue.Value;
                            break;
                        case "KL_XA_TRUOC_AGG3":
                            this._sp.KL_XaTruoc_Agg3 = (double)current.TimerParaValue.Value;
                            break;
                        case "KL_XA_TRUOC_AGG4":
                            this._sp.KL_XaTruoc_Agg4 = (double)current.TimerParaValue.Value;
                            break;
                        case "KL_XA_TRUOC_AGG5":
                            this._sp.KL_XaTruoc_Agg5 = (double)current.TimerParaValue.Value;
                            break;
                        case "KL_XA_TRUOC_AGG6":
                            this._sp.KL_XaTruoc_Agg6 = (double)current.TimerParaValue.Value;
                            break;
                        case "TG_TRE_TAT_VTX":
                            this._sp.TG_TRE_TAT_VTX = (double)current.TimerParaValue.Value;
                            break;
                        case "TG_BAT_RUNG_WAGG":
                            this._sp.TG_BAT_RUNG_WAGG = (double)current.TimerParaValue.Value;
                            break;
                        case "TG_TAT_RUNG_WAGG":
                            this._sp.TG_TAT_RUNG_WAGG = (double)current.TimerParaValue.Value;
                            break;
                        case "TG_BAT_RUNG_WCE":
                            this._sp.TG_BAT_RUNG_WCE = (double)current.TimerParaValue.Value;
                            break;
                        case "TG_TAT_RUNG_WCE":
                            this._sp.TG_TAT_RUNG_WCE = (double)current.TimerParaValue.Value;
                            break;
                        case "TG_BAT_SKSL":
                            this._sp.TG_BAT_SKSL = (double)current.TimerParaValue.Value;
                            break;
                        case "TG_TAT_SKSL":
                            this._sp.TG_TAT_SKSL = (double)current.TimerParaValue.Value;
                            break;
                        case "TG_TRE_MO_VAN_CE":
                            this._sp.TG_TRE_MO_VAN_CE = (double)current.TimerParaValue.Value;
                            break;
                        
                        case "TG_PheuChoDay":
                            this._sp.ThoiGian_PheuChoDay = (double)current.TimerParaValue.Value;
                            break;
                        case "TG_XaPC":
                            this._sp.ThoiGian_XaPC = (double)current.TimerParaValue.Value;
                            break;
                        case "TG_PC_ChoPhepRung":
                            this._sp.ThoiGian_PC_ChoPhepRung = (double)current.TimerParaValue.Value;
                            break;
                        case "TG_Rung_PC_ON":
                            this._sp.ThoiGian_Rung_PC_ON = (double)current.TimerParaValue.Value;
                            break;
                        case "TG_Rung_PC_OFF":
                            this._sp.ThoiGian_Rung_PC_OFF = (double)current.TimerParaValue.Value;
                            break;
                        case "HSN_AGG1":
                            this._sp.HSN_AGG1 = (double)current.TimerParaValue.Value;
                            break;
                        case "HSX_AGG1":
                            this._sp.HSX_AGG1 = (double)current.TimerParaValue.Value;
                            break;
                        case "HSN_AGG2":
                            this._sp.HSN_AGG2 = (double)current.TimerParaValue.Value;
                            break;
                        case "HSX_AGG2":
                            this._sp.HSX_AGG2 = (double)current.TimerParaValue.Value;
                            break;
                        case "HSN_AGG3":
                            this._sp.HSN_AGG3 = (double)current.TimerParaValue.Value;
                            break;
                        case "HSX_AGG3":
                            this._sp.HSX_AGG3 = (double)current.TimerParaValue.Value;
                            break;
                        case "HSN_AGG4":
                            this._sp.HSN_AGG4 = (double)current.TimerParaValue.Value;
                            break;
                        case "HSX_AGG4":
                            this._sp.HSX_AGG4 = (double)current.TimerParaValue.Value;
                            break;
                        case "HSN_AGG5":
                            this._sp.HSN_AGG5 = (double)current.TimerParaValue.Value;
                            break;
                        case "HSX_AGG5":
                            this._sp.HSX_AGG5 = (double)current.TimerParaValue.Value;
                            break;
                        case "HSN_AGG6":
                            this._sp.HSN_AGG6 = (double)current.TimerParaValue.Value;
                            break;
                        case "HSX_AGG6":
                            this._sp.HSX_AGG6 = (double)current.TimerParaValue.Value;
                            break;
                       
                        case "HSN_CE1":
                            this._sp.HSN_CE1 = (double)current.TimerParaValue.Value;
                            break;
                        case "HSX_CE1":
                            this._sp.HSX_CE1 = (double)current.TimerParaValue.Value;
                            break;
                        case "HSN_CE2":
                            this._sp.HSN_CE2 = (double)current.TimerParaValue.Value;
                            break;
                        case "HSX_CE2":
                            this._sp.HSX_CE2 = (double)current.TimerParaValue.Value;
                            break;
                        case "HSN_CE3":
                            this._sp.HSN_CE3 = (double)current.TimerParaValue.Value;
                            break;
                        case "HSN_CE4":
                            this._sp.HSN_CE4 = (double)current.TimerParaValue.Value;
                            break;
                        case "HSN_CE5":
                            this._sp.HSN_CE5 = (double)current.TimerParaValue.Value;
                            break;

                        case "HSN_WA1":
                            this._sp.HSN_WA1 = (double)current.TimerParaValue.Value;
                            break;
                        case "HSX_WA1":
                            this._sp.HSX_WA1 = (double)current.TimerParaValue.Value;
                            break;
                        case "HSN_WA2":
                            this._sp.HSN_WA2 = (double)current.TimerParaValue.Value;
                            break;
                        case "HSX_WA2":
                            this._sp.HSX_WA2 = (double)current.TimerParaValue.Value;
                            break;
                        case "HSN_ADD1":
                            this._sp.HSN_ADD1 = (double)current.TimerParaValue.Value;
                            break;
                        case "HSX_ADD1":
                            this._sp.HSX_ADD1 = (double)current.TimerParaValue.Value;
                            break;
                        case "HSN_ADD2":
                            this._sp.HSN_ADD2 = (double)current.TimerParaValue.Value;
                            break;
                        case "HSX_ADD2":
                            this._sp.HSX_ADD2 = (double)current.TimerParaValue.Value;
                            break;
                        case "HSN_ADD3":
                            this._sp.HSN_ADD3 = (double)current.TimerParaValue.Value;
                            break;
                        case "HSN_ADD4":
                            this._sp.HSN_ADD4 = (double)current.TimerParaValue.Value;
                            break;
                        case "HSN_ADD5":
                            this._sp.HSN_ADD5 = (double)current.TimerParaValue.Value;
                            break;
                        case "HSN_ADD6":
                            this._sp.HSN_ADD6 = (double)current.TimerParaValue.Value;
                            break;
                        default:
                            // Không có xử lý đặc biệt cho các giá trị timerParaCode khác
                            break;
                    }

                }
                //this.SetupIntervals();
            }
        }

        public BindingList<ObjWeigh> BLstWeigh
        {
            set
            {
                this._blstWeigh = value;

            }
        }

        public BindingList<ObjWeiSiloSaving> BLstWeiSiloSaving
        {
            set
            {
                this._blstWeiSiloSaving = value;
            }
        }

        public BindingList<ObjWeiSiloVisible> BLstWeiSiloVisible
        {
            set
            {
                this._blstWeiSiloVisible = value;
            }
        }

        public BindingList<ObjXe> BLstXe
        {
            set
            {
                this._blstXe = value;
                this.lueXe.Properties.DataSource = this._blstXe;
            }
        }

        public ObjMeTron CurMeTron
        {
            set
            {
                //this._curMT = value;
            }
        }

        public ObjMeTronChiTiet CurMeTronChiTiet
        {
            set
            {
                //this._curMTCT = value;
            }
        }

        private void BindSetPoint(SetPoint sp) //function
        {
            if (base.InvokeRequired)
            {
                base.Invoke(new MethodInvoker(delegate ()
                {
                    this.BindSetPoint(sp);
                }));
                return;
            }
            else
            {
                this.siloAgg6.DoAm = sp.DoAm_Agg6;
                this.siloAgg5.DoAm = sp.DoAm_Agg5;
                this.siloAgg4.DoAm = sp.DoAm_Agg4;
                this.siloAgg3.DoAm = sp.DoAm_Agg3;
                this.siloAgg2.DoAm = sp.DoAm_Agg2;
                this.siloAgg1.DoAm = sp.DoAm_Agg1;

                //if (this._ro.WeiRuning_F1_FromPLC && !this._flagSaveMAC && !sp.CanUpdateWhenRunning)
                //   return;
                //this._flagSaveMAC = false;
                this.siloAdd1.KLCaiDat = (decimal)sp.KL_CaiDat_Add1;
                this.siloAdd1.KLCanCan = (decimal)sp.KL_CanCan_Add1;
                this.siloAdd2.KLCaiDat = (decimal)sp.KL_CaiDat_Add2;
                this.siloAdd2.KLCanCan = (decimal)sp.KL_CanCan_Add2;
                this.siloAdd3.KLCaiDat = (decimal)sp.KL_CaiDat_Add3;
                this.siloAdd3.KLCanCan = (decimal)sp.KL_CanCan_Add3;
                this.siloAdd4.KLCaiDat = (decimal)sp.KL_CaiDat_Add4;
                this.siloAdd4.KLCanCan = (decimal)sp.KL_CanCan_Add4;
                this.siloAdd5.KLCaiDat = (decimal)sp.KL_CaiDat_Add5;
                this.siloAdd5.KLCanCan = (decimal)sp.KL_CanCan_Add5;
                this.siloAdd6.KLCaiDat = (decimal)sp.KL_CaiDat_Add6;
                this.siloAdd6.KLCanCan = (decimal)sp.KL_CanCan_Add6;

                this.siloCe1.KLCaiDat = (decimal)sp.KL_CaiDat_Ce1;
                this.siloCe1.KLCanCan = (decimal)sp.KL_CanCan_Ce1;
                this.siloCe2.KLCaiDat = (decimal)sp.KL_CaiDat_Ce2;
                this.siloCe2.KLCanCan = (decimal)sp.KL_CanCan_Ce2;
                this.siloCe3.KLCaiDat = (decimal)sp.KL_CaiDat_Ce3;
                this.siloCe3.KLCanCan = (decimal)sp.KL_CanCan_Ce3;
                this.siloCe4.KLCaiDat = (decimal)sp.KL_CaiDat_Ce4;
                this.siloCe4.KLCanCan = (decimal)sp.KL_CanCan_Ce4;
                this.siloCe5.KLCaiDat = (decimal)sp.KL_CaiDat_Ce5;
                this.siloCe5.KLCanCan = (decimal)sp.KL_CanCan_Ce5;

                if (sp.KL_CaiDat_Wa1 < 0)
                    sp.KL_CaiDat_Wa1 = 0;

                this.siloWa1.KLCaiDat = (decimal)sp.KL_CaiDat_Wa1;
                this.siloWa1.KLCanCan = (decimal)sp.KL_CanCan_Wa1;
                this.siloWa2.KLCaiDat = (decimal)sp.KL_CaiDat_Wa2;
                this.siloWa2.KLCanCan = (decimal)sp.KL_CanCan_Wa2;

                this.siloAgg6.KLCaiDat = (decimal)sp.KL_CaiDat_Agg6;
                this.siloAgg6.KLCanCan = (decimal)sp.KL_CanCan_Agg6;
                this.siloAgg5.KLCaiDat = (decimal)sp.KL_CaiDat_Agg5;
                this.siloAgg5.KLCanCan = (decimal)sp.KL_CanCan_Agg5;
                this.siloAgg4.KLCaiDat = (decimal)sp.KL_CaiDat_Agg4;
                this.siloAgg4.KLCanCan = (decimal)sp.KL_CanCan_Agg4;
                this.siloAgg3.KLCaiDat = (decimal)sp.KL_CaiDat_Agg3;
                this.siloAgg3.KLCanCan = (decimal)sp.KL_CanCan_Agg3;
                this.siloAgg2.KLCaiDat = (decimal)sp.KL_CaiDat_Agg2;
                this.siloAgg2.KLCanCan = (decimal)sp.KL_CanCan_Agg2;
                this.siloAgg1.KLCaiDat = (decimal)sp.KL_CaiDat_Agg1;
                this.siloAgg1.KLCanCan = (decimal)sp.KL_CanCan_Agg1;
                this.SetSLMe((int)sp.SoMeTron);

                this.lblSoMeCheck.Text = sp.SoMeTron.ToString();

                this.ucSoKhoiTrenMe.GiaTri = (decimal)sp.KLTrenTungMe;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        private BindingList<ObjDuLieuTron> _blstDuLieuTron = new BindingList<ObjDuLieuTron>();

        private BindingList<ObjMAC> _blstMAC = new BindingList<ObjMAC>();

        private BindingList<ObjMACSilo> _blstMACSilo = new BindingList<ObjMACSilo>();

        private BindingList<ObjMACSilo> _blstMACSilo_Run = new BindingList<ObjMACSilo>();

        private BindingList<ObjPhieuTron> _blstPhieuTron = new BindingList<ObjPhieuTron>();

        private BindingList<ObjSilo> _blstSilo = new BindingList<ObjSilo>();

        private BindingList<ObjSilo> _blstSiloLogicAG = new BindingList<ObjSilo>();

        private BindingList<ObjSilo> _blstSiloLogicAD = new BindingList<ObjSilo>();
        
        private BindingList<ObjSilo> _blstSiloLogicCE = new BindingList<ObjSilo>();

        private BindingList<ObjSilo> _blstSilo_DoAmHutAgg = new BindingList<ObjSilo>();

        private BindingList<ObjNhanVien> _blstNhanVien = new BindingList<ObjNhanVien>();

        private BindingList<ObjTaiXe> _blstTaiXe = new BindingList<ObjTaiXe>();

        private BindingList<ObjTimerPara> _blstTimerPara = new BindingList<ObjTimerPara>();

        private List<ObjTimerPara> _listTimer = new List<ObjTimerPara>();

        private BindingList<ObjWeigh> _blstWeigh = new BindingList<ObjWeigh>();

        private BindingList<ObjWeiSiloSaving> _blstWeiSiloSaving = new BindingList<ObjWeiSiloSaving>();

        private BindingList<ObjWeiSiloVisible> _blstWeiSiloVisible = new BindingList<ObjWeiSiloVisible>();

        private BindingList<ObjXe> _blstXe = new BindingList<ObjXe>();

        private List<FieldCode> _lstPhieuTronStatus = new List<FieldCode>();

        private List<FieldCode> _lstDuLieuTronStatus = new List<FieldCode>();
        public List<FieldCode> LstPhieuTronStatus { set => throw new NotImplementedException(); }
        public List<FieldCode> LstDuLieuTronStatus 
        {
            set
            {
                this._lstDuLieuTronStatus = value;
                this.ilueHDStatus.DataSource = (object)this._lstDuLieuTronStatus;
                this.iicbStatus.Items.Clear();
                this.iicbStatus.Items.Add(new ImageComboBoxItem(((DisplayAttribute)Attribute.GetCustomAttribute(typeof(Enums.DuLieuTronStatus).GetField(Enums.DuLieuTronStatus.New.ToString()), typeof(DisplayAttribute)))?.Name, (object)0.ToString(), 0));
                this.iicbStatus.Items.Add(new ImageComboBoxItem(((DisplayAttribute)Attribute.GetCustomAttribute(typeof(Enums.DuLieuTronStatus).GetField(Enums.DuLieuTronStatus.Running.ToString()), typeof(DisplayAttribute)))?.Name, (object)1.ToString(), 1));
                this.iicbStatus.Items.Add(new ImageComboBoxItem(((DisplayAttribute)Attribute.GetCustomAttribute(typeof(Enums.DuLieuTronStatus).GetField(Enums.DuLieuTronStatus.Pause.ToString()), typeof(DisplayAttribute)))?.Name, (object)2.ToString(), 2));
                this.iicbStatus.Items.Add(new ImageComboBoxItem(((DisplayAttribute)Attribute.GetCustomAttribute(typeof(Enums.DuLieuTronStatus).GetField(Enums.DuLieuTronStatus.Abort.ToString()), typeof(DisplayAttribute)))?.Name, (object)3.ToString(), 3));
                this.iicbStatus.Items.Add(new ImageComboBoxItem(((DisplayAttribute)Attribute.GetCustomAttribute(typeof(Enums.DuLieuTronStatus).GetField(Enums.DuLieuTronStatus.Finished.ToString()), typeof(DisplayAttribute)))?.Name, (object)4.ToString(), 4));
            }
        }

        public InitOnline IO { set => throw new NotImplementedException(); }
        public SendingToPLC SO { set => throw new NotImplementedException(); }
        public bool IsSuccessfulUpdatePT { set => throw new NotImplementedException(); }
        public bool IsSuccessfulSaveTronOnline { set => throw new NotImplementedException(); }
        public ObjPhieuTron SavingPhieuTron { set => throw new NotImplementedException(); }

        private bool _htAuto = false;

        private bool HeThongAuto
        {
            get
            {
                return this._htAuto;
            }
            set
            {
                this._htAuto = value;
                //this.ucHeThongAuto1.IsAuto = value;
            }
        }


        public VanHanh()
        {
            InitializeComponent();
            this._presenter = new TronOnlineDataPresenter((ITronOnlineView)this);
            //this._TronOnlineAttributes.WeiRunningStatusChanged += new TronOnlineAttributes.WeiEventHandler(this._TronOnlineAttributes_WeiRunningStatusChanged);
            this.Caption = "Vận hành";
        }
        public VanHanh(int a) : this()
        {

        }
        public void CloseForm()
        {
            this.Close();
        }

        //private void _TronOnlineAttributes_WeiRunningStatusChanged(bool isRunning) => this.ShowRunningStatus(isRunning);
        /*private void ShowRunningStatus(bool isRunning)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((Delegate)(() => this.ShowRunningStatus(isRunning)));
            }
            else
            {
                this.marqueeProgressBarControl1.Properties.Stopped = !isRunning;
                if (isRunning)
                    return;
                bool flag = true;
                foreach (ObjDuLieuTron objDuLieuTron in (Collection<ObjDuLieuTron>)this._blstDuLieuTron)
                {
                    int? status = objDuLieuTron.Status;
                    int num = 1;
                    if (status.GetValueOrDefault() == num & status.HasValue)
                    {
                        flag = false;
                        objDuLieuTron.Status = new int?(0);
                        if (!this._ShowFinishedDLT)
                            objDuLieuTron.Activated = false;
                    }
                }
                int focusedRowHandle = this.grvHopDong.FocusedRowHandle;
                this._presenter.SaveDuLieuTron(this._blstDuLieuTron);
                this._presenter.ListDuLieuTron();
                this.grvHopDong.FocusedRowHandle = focusedRowHandle;
                if (flag)
                    return;
                this.GetNextDLT_Run();
            }
        }*/

        private void BuildSetPoint(ObjHopDong selectedHD, bool canUpdateWhenRunning)
        {
            if (selectedHD != null)
            {
                this.labelControl6.Text = selectedHD.DLT_KLDuTinhCuaTungMe.ToString();
                this._presenter.ListMACSilo_ByHopDongID(selectedHD.HopDongID);
                this._presenter.ListSilo();
                this._presenter.ListSilo_DoAmHutAgg();
                this._presenter.ListWei();
                this._presenter.BuildSetPoint(selectedHD, this._blstMACSilo, this._blstWeigh, this._blstSilo, this.siloAgg1.DoAm, this.siloAgg2.DoAm, this.siloAgg3.DoAm, _themBotNuoc, _giuNuocTenCan, canUpdateWhenRunning);
                return;
            }
            else
            {
                TramTromMessageBox.ShowErrorDialog("Bạn chưa chọn Dữ liệu trộn");
                //this._presenter.BuildNullSetPoint();

            }
        }

        protected override void PopulateData()
        {
            timeNow = DateTime.Now;
            timeTrie = new DateTime(2024, 6, 9, 12, 0, 0); //Ngày Trie PM
            int checkTimeTrie = DateTime.Compare(timeNow, timeTrie);
            if (checkTimeTrie >= 0)
            {
                PlayOffPL(false);
            }

            //this._presenter.ListPhieuTron_ForTronOnline();

            this._presenter.ListTimerPara();
            this._presenter.ListDuLieuTron();
            this._presenter.ListMAC();
            this._presenter.ListSilo();

            // Load SILO
            CreateSilo_AGG(ConfigManager.TramTronConfig.SL_Silo_AGG);
            this.pnl_Silo_Agg1.Location = new System.Drawing.Point(ConfigManager.TramTronConfig.Silo_AGG_1_X, this.pnl_Silo_Agg1.Location.Y);
            this.pnl_Silo_Agg2.Location = new System.Drawing.Point(ConfigManager.TramTronConfig.Silo_AGG_2_X, this.pnl_Silo_Agg2.Location.Y);
            this.pnl_Silo_Agg3.Location = new System.Drawing.Point(ConfigManager.TramTronConfig.Silo_AGG_3_X, this.pnl_Silo_Agg3.Location.Y);
            this.pnl_Silo_Agg4.Location = new System.Drawing.Point(ConfigManager.TramTronConfig.Silo_AGG_4_X, this.pnl_Silo_Agg4.Location.Y);
            this.pnl_Silo_Agg5.Location = new System.Drawing.Point(ConfigManager.TramTronConfig.Silo_AGG_5_X, this.pnl_Silo_Agg5.Location.Y);
            this.pnl_Silo_Agg6.Location = new System.Drawing.Point(ConfigManager.TramTronConfig.Silo_AGG_6_X, this.pnl_Silo_Agg6.Location.Y);

            CreateSilo_CE(ConfigManager.TramTronConfig.SL_Silo_CE);
            this.pnl_Silo_Ce1.Location = new System.Drawing.Point(ConfigManager.TramTronConfig.Silo_CE_1_X, this.pnl_Silo_Ce1.Location.Y);
            this.pnl_Silo_Ce2.Location = new System.Drawing.Point(ConfigManager.TramTronConfig.Silo_CE_2_X, this.pnl_Silo_Ce2.Location.Y);
            this.pnl_Silo_Ce3.Location = new System.Drawing.Point(ConfigManager.TramTronConfig.Silo_CE_3_X, this.pnl_Silo_Ce3.Location.Y);
            this.pnl_Silo_Ce4.Location = new System.Drawing.Point(ConfigManager.TramTronConfig.Silo_CE_4_X, this.pnl_Silo_Ce4.Location.Y);
            this.pnl_Silo_Ce5.Location = new System.Drawing.Point(ConfigManager.TramTronConfig.Silo_CE_5_X, this.pnl_Silo_Ce5.Location.Y);

            CreateSilo_WA(ConfigManager.TramTronConfig.SL_Silo_WA);
            this.pnl_Silo_Wa1.Location = new System.Drawing.Point(ConfigManager.TramTronConfig.Silo_WA_1_X, this.pnl_Silo_Wa1.Location.Y);
            this.pnl_Silo_Wa2.Location = new System.Drawing.Point(ConfigManager.TramTronConfig.Silo_WA_2_X, this.pnl_Silo_Wa2.Location.Y);

            CreateSilo_ADD(ConfigManager.TramTronConfig.SL_Silo_ADD);
            this.pnl_Silo_Add1.Location = new System.Drawing.Point(ConfigManager.TramTronConfig.Silo_ADD_1_X, this.pnl_Silo_Add1.Location.Y);
            this.pnl_Silo_Add2.Location = new System.Drawing.Point(ConfigManager.TramTronConfig.Silo_ADD_2_X, this.pnl_Silo_Add2.Location.Y);
            this.pnl_Silo_Add3.Location = new System.Drawing.Point(ConfigManager.TramTronConfig.Silo_ADD_3_X, this.pnl_Silo_Add3.Location.Y);
            this.pnl_Silo_Add4.Location = new System.Drawing.Point(ConfigManager.TramTronConfig.Silo_ADD_4_X, this.pnl_Silo_Add4.Location.Y);
            this.pnl_Silo_Add5.Location = new System.Drawing.Point(ConfigManager.TramTronConfig.Silo_ADD_5_X, this.pnl_Silo_Add5.Location.Y);
            this.pnl_Silo_Add6.Location = new System.Drawing.Point(ConfigManager.TramTronConfig.Silo_ADD_6_X, this.pnl_Silo_Add6.Location.Y);

            CreateWei_AGG(ConfigManager.TramTronConfig.SL_Wei_AGG);
            this.pnl_Wei_Agg1.Location = new System.Drawing.Point(ConfigManager.TramTronConfig.Wei_AGG_1_X, this.pnl_Wei_Agg1.Location.Y);
            this.pnl_Wei_Agg2.Location = new System.Drawing.Point(ConfigManager.TramTronConfig.Wei_AGG_2_X, this.pnl_Wei_Agg2.Location.Y);
            this.pnl_Wei_Agg3.Location = new System.Drawing.Point(ConfigManager.TramTronConfig.Wei_AGG_3_X, this.pnl_Wei_Agg3.Location.Y);
            this.pnl_Wei_Agg4.Location = new System.Drawing.Point(ConfigManager.TramTronConfig.Wei_AGG_4_X, this.pnl_Wei_Agg4.Location.Y);
            this.pnl_Wei_Agg5.Location = new System.Drawing.Point(ConfigManager.TramTronConfig.Wei_AGG_5_X, this.pnl_Wei_Agg5.Location.Y);
            this.pnl_Wei_Agg6.Location = new System.Drawing.Point(ConfigManager.TramTronConfig.Wei_AGG_6_X, this.pnl_Wei_Agg6.Location.Y);

            CreateWei_CE(ConfigManager.TramTronConfig.SL_Wei_CE);
            this.pnl_Wei_Ce1.Location = new System.Drawing.Point(ConfigManager.TramTronConfig.Wei_CE_1_X, this.pnl_Wei_Ce1.Location.Y);
            this.pnl_Wei_Ce2.Location = new System.Drawing.Point(ConfigManager.TramTronConfig.Wei_CE_2_X, this.pnl_Wei_Ce2.Location.Y);

            CreateWei_WA(ConfigManager.TramTronConfig.SL_Wei_WA);
            this.pnl_Wei_Wa1.Location = new System.Drawing.Point(ConfigManager.TramTronConfig.Wei_WA_1_X, this.pnl_Wei_Wa1.Location.Y);
            this.pnl_Wei_Wa2.Location = new System.Drawing.Point(ConfigManager.TramTronConfig.Wei_WA_2_X, this.pnl_Wei_Wa2.Location.Y);

            CreateWei_ADD(ConfigManager.TramTronConfig.SL_Wei_ADD);
            this.pnl_Wei_Add1.Location = new System.Drawing.Point(ConfigManager.TramTronConfig.Wei_ADD_1_X, this.pnl_Wei_Add1.Location.Y);
            this.pnl_Wei_Add2.Location = new System.Drawing.Point(ConfigManager.TramTronConfig.Wei_ADD_2_X, this.pnl_Wei_Add2.Location.Y);

            this.ucBTCan1.Visible = ConfigManager.TramTronConfig.Show_BTC;
            this.ucBTCan1.Location = new System.Drawing.Point(ConfigManager.TramTronConfig.BTC_X, this.ucBTCan1.Location.Y);
            this.ucBTCan1.Size = new Size(ConfigManager.TramTronConfig.Width_BTC, this.ucBTCan1.Size.Height);

            this.pnl_Funnel.Visible = ConfigManager.TramTronConfig.Show_Funnel;

            if (ConfigManager.TramTronConfig.CapPhoiRes == 0)
            {
                this.ucBTXien1.Visible = true;
                this.pnlGauTai.Visible = false;
                btnXaCanCotLieu.Caption = "XẢ CÂN CỐT LIỆU";
            }
            else if (ConfigManager.TramTronConfig.CapPhoiRes == 1)
            {
                this.ucBTXien1.Visible = false;
                this.pnlGauTai.Visible = true;
                btnXaCanCotLieu.Caption = "GÀU TẢI TAY";
            }
            CreateGroupLogicAG(ConfigManager.TramTronConfig.SL_Silo_AGG);
            CreateGroupLogicCE(ConfigManager.TramTronConfig.SL_Silo_CE);
            CreateGroupLogicAD(ConfigManager.TramTronConfig.SL_Silo_ADD);

            this.checkAutoPrint.Checked = ConfigManager.TramTronConfig.AutoPrint;
        }

        private void PlayOffPL(bool isOff)
        {
            this.btnVanXa_Agg1_1.Enabled //Silo
                = this.btnVanXa_Agg1_2.Enabled
                = this.btnVanXa_Agg2_1.Enabled
                = this.btnVanXa_Agg2_2.Enabled
                = this.btnVanXa_Agg3_1.Enabled
                = this.btnVanXa_Agg3_2.Enabled
                = this.btnVanXa_Agg4_1.Enabled
                = this.btnVanXa_Agg4_2.Enabled
                = this.btnVanXa_Agg5_1.Enabled
                = this.btnVanXa_Agg5_2.Enabled
                = this.btnVanXa_Agg6_1.Enabled
                = this.btnVanXa_Agg6_2.Enabled
                = this.btnVanXa_Ce1.Enabled
                = this.btnVanXa_Ce2.Enabled
                = this.btnVanXa_Ce3.Enabled
                = this.btnVanXa_Ce4.Enabled
                = this.btnVanXa_Ce5.Enabled
                //= this.btnVanXa_Wa1.Enabled
                //= this.btnVanXa_Wa2.Enabled
                = this.btnVanXa_Add1.Enabled
                = this.btnVanXa_Add2.Enabled
                = this.btnVanXa_Add3.Enabled
                = this.btnVanXa_Add4.Enabled
                = this.btnVanXa_Add5.Enabled
                = this.btnVanXa_Add6.Enabled
                = this.btnXaCan_Agg1.Enabled // Can
                = this.btnXaCan_Agg2.Enabled
                = this.btnXaCan_Agg3.Enabled
                = this.btnXaCan_Agg4.Enabled
                = this.btnXaCan_Agg5.Enabled
                = this.btnXaCan_Agg6.Enabled
                = this.btnXaCan_Ce1.Enabled
                = this.btnXaCan_Ce2.Enabled
                //= this.btnXaCan_Wa1.Enabled
                //= this.btnXaCan_Wa2.Enabled
                = this.btnXaCan_Add1.Enabled
                = this.btnXaCan_Add2.Enabled
                = this.ucHeThongAuto1.Enabled // HeThong
                = isOff;
        }
        protected override void PopulateStaticData()
        {
            this._presenter.ListNhanVien();
            this._presenter.ListTaiXe();
            this._presenter.ListXe();
            this._presenter.ListDuLieuTronStatus();
            this._presenter.ListWei();
            this._presenter.ListWeiSiloSaving();
            this._presenter.ListWeiSiloVisible();
            this._presenter.ListSiloLogicAgg();
            this._presenter.ListSiloLogicAdd();
            this._presenter.ListSiloLogicCE();

            GetNiemChi();
            
        }

        protected override void Loaded()
        {
            this.DoFocusHopDong();
            this._presenter.ListTimerPara();
            SendData_DB5_NewTread();
            //this.SendData_NewTread();
           

        }


        private void GetBlstSiloLogicAgg(UcLogicSiloAgg logicSilo, BindingList<ObjSilo> blstSilo)
        {
            //logicSilo.GetBlstSiloLogic(blstSilo);
        }
        
        private void VanHanh_Load(object sender, EventArgs e)
        {
            this._Ready = true;
            timer1.Interval = 100;
            this._thread = new Thread(new ThreadStart(this.Running));
            this._thread.Name = "Running";
            _thread.Start();

            ChangeStusLight(false);
            

           // this.ucLogicSiloAgg1._blstSiloLogicAggSelected1 = this._blstSiloLogicAG;
        }
        
         private void ChangeStusLight(bool isOn) //funcction
        {
            this.ucBaoRung_Agg1.Visible 
                = this.ucBaoRung_Agg2.Visible
                = this.ucBaoRung_Agg3.Visible
                = this.ucBaoRung_Agg4.Visible
                = this.ucBaoRung_Agg5.Visible
                = this.ucBaoRung_Agg6.Visible
                = this.ucBaoRung_Ce1.Visible
                = this.ucBaoRung_Ce2.Visible
                = this.ucTinHieu_PCD.Visible
                = this.ucTinHieu_PCM.Visible
                = this.ucBaoRung_Funnel.Visible
                = this.uc_TinHieu_CuaNoiDong.Visible
                = this.uc_TinHieu_CuaNoiMo.Visible
                = this.uc_TinHieu_CuaNoi1per2.Visible

                = this.btnF_Agg1.Visible
                = this.btnF_Agg2.Visible
                = this.btnF_Agg3.Visible
                = this.btnF_Agg4.Visible
                = this.btnF_Agg5.Visible
                = this.btnF_Agg6.Visible
                = this.btnF_Ce1.Visible
                = this.btnF_Ce2.Visible
                = this.btnF_Ce3.Visible
                = this.btnF_Ce4.Visible
                = this.btnF_Ce5.Visible
                = this.btnF_Wa1.Visible
                = this.btnF_Wa2.Visible
                = this.btnF_Add1.Visible
                = this.btnF_Add1.Visible
                = this.btnF_Add2.Visible
                = this.btnF_Add3.Visible
                = this.btnF_Add4.Visible
                = this.btnF_Add5.Visible
                = this.btnF_Add6.Visible

                = this.lblSim.Visible

                = isOn;
        }
        private void RunningBTX()
        {
            if (base.InvokeRequired)
            {
                base.Invoke(new MethodInvoker(delegate ()
                {
                    if (_isRunBTX)
                    {
                        this.ucBTXien1.CheDo = UcBTXien.Action.Start;
                    }
                    else
                    {
                        this.ucBTXien1.CheDo = UcBTXien.Action.Pause;
                    }
                    
                }));
            }
        }
        private void Running()
        {
            while (this._Ready)
            {
                Thread.Sleep(500);
                try
                {
                    if (this._plcController != null && !this._plcController.IsConnected)
                    {
                        _plcController = new PLCController();
                        ShowMessage(GlobalValues.Messages.DISCONNECTED, Enums.MsgType.Warning);

                    }
                    
                    if (this._plcController.IsConnected)
                    {

                        if (base.InvokeRequired)
                        {
                            base.Invoke(new MethodInvoker(delegate ()
                            {
                                this.labelControl1.Text = "CONNECT";
                                ShowMessage("PLC ĐÃ KẾT NỐI", Enums.MsgType.Info);
                                timer1.Start();
                            }));
                            return;

                        }
                    }
                    else
                    {
                        if (base.InvokeRequired)
                        {
                            base.Invoke(new MethodInvoker(delegate ()
                            {
                                ShowMessage(GlobalValues.Messages.DISCONNECTED, Enums.MsgType.Warning);
                                //_plcController.AttemptReconnect();
                            }));
                            return;
                        }
                    }
                }
                catch (Exception e)
                {
                }
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

        private void ReceiveData_DB1(byte[] a) //READ DATA FROM PLC
        {
            this._ro.StatusIO_00 = a[0];
            this._ro.StatusIO_01 = a[1];
            this._ro.StatusIO_02 = a[2];
            this._ro.StatusIO_03 = a[3];
            this._ro.StatusIO_04 = a[4];
            this._ro.StatusIO_05 = a[5];
            this._ro.StatusIO_06 = a[6];
            this._ro.StatusIO_07 = a[7];
            this._ro.StatusIO_08 = a[8];
            this._ro.StatusIO_09 = a[9];
            this._ro.StatusIO_10 = a[10];
            this._ro.StatusIO_11 = a[11];
            this._ro.StatusIO_12 = a[12];
            this._ro.StatusIO_13 = a[13];
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
        }
        private void ReceiveData_DB7(byte[] a) //READ DATA FROM PLC
        {
            this._ro.PV_AGG_1 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[0], a[1], a[2], a[3])); // 0.0
            this._ro.Per_WAGG_1 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[4], a[5], a[6], a[7])); // 4.0
            this._ro.WE_AGG_1 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[8], a[9], a[10], a[11])); // 8.0
            this._ro.SMC_AGG_1 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[12], a[13], a[14], a[15])); // 12.0
            this._ro.SMX_AGG_1 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[16], a[17], a[18], a[19])); // 16.0
            this._ro.PV_AGG_2 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[20], a[21], a[22], a[23])); // 20.0
            this._ro.Per_WAGG_2 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[24], a[25], a[26], a[27])); // 24.0
            this._ro.WE_AGG_2 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[28], a[29], a[30], a[31])); // 28.0
            this._ro.SMC_AGG_2 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[32], a[33], a[34], a[35])); // 32.0
            this._ro.SMX_AGG_2 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[36], a[37], a[38], a[39])); // 36.0
            this._ro.PV_AGG_3 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[40], a[41], a[42], a[43])); // 40.0
            this._ro.Per_WAGG_3 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[44], a[45], a[46], a[47])); // 44.0
            this._ro.WE_AGG_3 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[48], a[49], a[50], a[51])); // 48.0
            this._ro.SMC_AGG_3 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[52], a[53], a[54], a[55])); // 52.0
            this._ro.SMX_AGG_3 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[56], a[57], a[58], a[59])); // 56.0
            this._ro.PV_AGG_4 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[60], a[61], a[62], a[63])); // 60.0
            this._ro.Per_WAGG_4 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[64], a[65], a[66], a[67])); // 64.0
            this._ro.WE_AGG_4 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[68], a[69], a[70], a[71])); // 68.0
            this._ro.SMC_AGG_4 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[72], a[73], a[74], a[75])); // 72.0
            this._ro.SMX_AGG_4 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[76], a[77], a[78], a[79])); // 76.0
            this._ro.PV_AGG_5 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[80], a[81], a[82], a[83])); // 80.0
            this._ro.Per_WAGG_5 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[84], a[85], a[86], a[87])); // 84.0
            this._ro.WE_AGG_5 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[88], a[89], a[90], a[91])); // 88.0
            this._ro.SMC_AGG_5 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[92], a[93], a[94], a[95])); // 92.0
            this._ro.SMX_AGG_5 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[96], a[97], a[98], a[99])); // 96.0
            this._ro.PV_AGG_6 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[100], a[101], a[102], a[103])); // 100.0
            this._ro.Per_WAGG_6 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[104], a[105], a[106], a[107])); // 104.0
            this._ro.WE_AGG_6 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[108], a[109], a[110], a[111])); // 108.0
            this._ro.SMC_AGG_6 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[112], a[113], a[114], a[115])); // 112
            this._ro.SMX_AGG_6 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[116], a[117], a[118], a[119])); // 116
            this._ro.PV_SILO_1 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[120], a[121], a[122], a[123])); // 120
            this._ro.PV_SILO_2 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[124], a[125], a[126], a[127])); // 124
            this._ro.PV_SILO_3 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[128], a[129], a[130], a[131])); // 128
            this._ro.Per_WCEM_1 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[132], a[133], a[134], a[135])); // 132
            this._ro.WE_CEM_1 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[136], a[137], a[138], a[139])); // 136
            this._ro.SMC_CEM_1 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[140], a[141], a[142], a[143])); // 140
            this._ro.SMX_CEM_1 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[144], a[145], a[146], a[147])); // 144
            this._ro.PV_SILO_4 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[148], a[149], a[150], a[151])); // 148
            this._ro.PV_SILO_5 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[152], a[153], a[154], a[155])); // 152
            this._ro.Per_WCEM_2 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[156], a[157], a[158], a[159])); // 156
            this._ro.WE_CEM_2 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[160], a[161], a[162], a[163])); // 160
            this._ro.SMC_CEM_2 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[164], a[165], a[166], a[167])); // 164
            this._ro.SMX_CEM_2 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[168], a[169], a[170], a[171])); // 168
            this._ro.PV_WA_1 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[172], a[173], a[174], a[175])); // 172
            this._ro.Per_WWA_1 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[176], a[177], a[178], a[179])); // 176
            this._ro.WE_WA_1 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[180], a[181], a[182], a[183])); // 180
            this._ro.SMC_WA_1 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[184], a[185], a[186], a[187])); // 184
            this._ro.SMX_WA_1 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[188], a[189], a[190], a[191])); // 188
            this._ro.PV_WA_2 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[192], a[193], a[194], a[195])); // 192
            this._ro.Per_WWA_2 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[196], a[197], a[198], a[199])); // 196
            this._ro.WE_WA_2 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[200], a[201], a[202], a[203])); // 200
            this._ro.SMC_WA_2 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[204], a[205], a[206], a[207])); // 204
            this._ro.SMX_WA_2 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[208], a[209], a[210], a[211])); // 208
            this._ro.PV_ADD_1 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[212], a[213], a[214], a[215])); // 212
            this._ro.PV_ADD_2 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[216], a[217], a[218], a[219])); // 216
            this._ro.PV_ADD_3 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[220], a[221], a[222], a[223])); // 220
            this._ro.Per_WADD_1 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[224], a[225], a[226], a[227])); // 224
            this._ro.WE_ADD_1 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[228], a[229], a[230], a[231])); // 228
            this._ro.SMC_ADD_1 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[232], a[233], a[234], a[235])); // 232
            this._ro.SMX_ADD_1 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[236], a[237], a[238], a[239])); // 236
            this._ro.PV_ADD_4 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[240], a[241], a[242], a[243])); // 240
            this._ro.PV_ADD_5 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[244], a[245], a[246], a[247])); // 244
            this._ro.PV_ADD_6 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[248], a[249], a[250], a[251])); // 248
            this._ro.Per_WADD_2 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[252], a[253], a[254], a[255])); // 252
            this._ro.WE_ADD_2 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[256], a[257], a[258], a[259])); // 256
            this._ro.SMC_ADD_2 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[260], a[261], a[262], a[263])); // 260
            this._ro.SMX_ADD_2 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[264], a[265], a[266], a[267])); // 264
            this._ro.SMC_SKIP = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[268], a[269], a[270], a[271])); // 268
            this._ro.SMX_SKIP = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[272], a[273], a[274], a[275])); // 272
            this._ro.SMC_PTG = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[276], a[277], a[278], a[279])); // 276
            this._ro.SMX_PTG = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[280], a[281], a[282], a[283])); // 280
            this._ro.SMC_MIXER = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[284], a[285], a[286], a[287])); // 284
            this._ro.SMX_MIXER = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[288], a[289], a[290], a[291])); // 288
            this._ro.ThoiGianThucTron = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[292], a[293], a[294], a[295])); // 292
            this._ro.ThoiGianThucXa = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[296], a[297], a[298], a[299])); // 296
            this._ro.PheuChoStatus = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[300], a[301], a[302], a[303])); // 300
        }

        private void ReceiveData_DB8(byte[] a) //READ DATA FROM PLC
        {
            this._ro.StatusIO_SAVE = a[0];
            this._ro.RE_PV_AGG1 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[4], a[5], a[6], a[7])); // 4
            this._ro.RE_PVM_AGG1 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[8], a[9], a[10], a[11])); // 8
            this._ro.RE_PV_AGG2 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[12], a[13], a[14], a[15])); // 12
            this._ro.RE_PVM_AGG2 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[16], a[17], a[18], a[19])); // 16
            this._ro.RE_PV_AGG3 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[20], a[21], a[22], a[23])); // 20
            this._ro.RE_PVM_AGG3 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[24], a[25], a[26], a[27])); // 24
            this._ro.RE_PV_AGG4 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[28], a[29], a[30], a[31])); // 28
            this._ro.RE_PVM_AGG4 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[32], a[33], a[34], a[35])); // 32
            this._ro.RE_PV_AGG5 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[36], a[37], a[38], a[39])); // 36
            this._ro.RE_PVM_AGG5 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[40], a[41], a[42], a[43])); // 40
            this._ro.RE_PV_AGG6 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[44], a[45], a[46], a[47])); // 44
            this._ro.RE_PVM_AGG6 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[48], a[49], a[50], a[51])); // 48.0
            this._ro.RE_PV_CE1 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[52], a[53], a[54], a[55])); // 52.0
            this._ro.RE_PVM_CE1 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[56], a[57], a[58], a[59])); // 56.0
            this._ro.RE_PV_CE2 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[60], a[61], a[62], a[63])); // 60.0
            this._ro.RE_PVM_CE2 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[64], a[65], a[66], a[67])); // 64.0
            this._ro.RE_PV_CE3 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[68], a[69], a[70], a[71])); // 68.0
            this._ro.RE_PVM_CE3 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[72], a[73], a[74], a[75])); // 72.0
            this._ro.RE_PV_CE4 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[76], a[77], a[78], a[79])); // 76.0
            this._ro.RE_PVM_CE4 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[80], a[81], a[82], a[83])); // 80.0
            this._ro.RE_PV_CE5 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[84], a[85], a[86], a[87])); // 84.0
            this._ro.RE_PVM_CE5 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[88], a[89], a[90], a[91])); // 88.0
            this._ro.RE_PV_WA1 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[92], a[93], a[94], a[95])); // 92.0
            this._ro.RE_PVM_WA1 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[96], a[97], a[98], a[99])); // 96.0
            this._ro.RE_PV_WA2 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[100], a[101], a[102], a[103])); // 100.0
            this._ro.RE_PVM_WA2 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[104], a[105], a[106], a[107])); // 104.0
            this._ro.RE_PV_PG1 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[108], a[109], a[110], a[111])); // 108.0
            this._ro.RE_PVM_PG1 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[112], a[113], a[114], a[115])); // 112
            this._ro.RE_PV_PG2 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[116], a[117], a[118], a[119])); // 116
            this._ro.RE_PVM_PG2 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[120], a[121], a[122], a[123])); // 120
            this._ro.RE_PV_PG3 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[124], a[125], a[126], a[127])); // 124
            this._ro.RE_PVM_PG3 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[128], a[129], a[130], a[131])); // 128
            this._ro.RE_PV_PG4 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[132], a[133], a[134], a[135])); // 132
            this._ro.RE_PVM_PG4 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[136], a[137], a[138], a[139])); // 136
            this._ro.RE_PV_PG5 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[140], a[141], a[142], a[143])); // 140
            this._ro.RE_PVM_PG5 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[144], a[145], a[146], a[147])); // 144
            this._ro.RE_PV_PG6 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[148], a[149], a[150], a[151])); // 148
            this._ro.RE_PVM_PG6 = this.ConvertData(MappingHelper.Merge4BytesIntoInt(a[152], a[153], a[154], a[155])); // 152
        }
        private decimal CorectData(double data)
        {
            decimal a;
            if (data > 32000 || data < -32000)
            {
                a = 0;
            }
            else
            {
                a = (decimal)data;

                if (data > Double.MaxValue)
                {
                    return 0;
                }
                else if (data < -Double.MaxValue)
                {
                    return 0;
                }
                return a;
            }
            return a;
        }

        private bool isGiuaDuoi = false;
        private bool isGiuaTren = false;
        private int tempGau = 0;
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
                    IsRunNoiTron = _ro.Op_TinHieu_NoiTron;
                    IsRunBTX = _ro.Op_TinHieu_BangTaiXien;
                    IsRunBTC = _ro.Op_TinHieu_BangTaiCan;
                    /*siloAgg1.KLThucTe = this.CorectData(_ro.PV_AGG_1);
                    barProcess_Weight_Agg1.Percent = _ro.Per_WAGG_1;
                    weightAgg1.GiaTriWeight = this.CorectData(_ro.WE_AGG_1);

                    */
                    //=========================================================TIN HIEU

                    _running = _ro.Op_RUNNING;
                    this.labelControl6.Visible = _ro.Op_RUNNING;
                    this._TronOnlineAttributes.IsRunning = _ro.Op_RUNNING;
                    if (_running)
                    {
                        btnRun.Visible = false;
                    }
                    else
                    {
                        btnRun.Visible = true;
                    }
                    _isSimulation = _ro.Op_SIMULATION;
                    labelControl6.Enabled = _ro.Op_SIMULATION;
                    lblSim.Visible = _ro.Op_SIMULATION;
                    
                    if (_isSimulation)
                    {
                        this.ucBtnMoPhong1.IsTrangThai = UcBtnMoPhong.TrangThai.Run;
                        this._so.SendingCommand.F4_MoPhong = true;
                    }
                    else
                    {
                        this.ucBtnMoPhong1.IsTrangThai = UcBtnMoPhong.TrangThai.Stop;
                        this._so.SendingCommand.F4_MoPhong = false;
                    }
                    
                    if (_ro.STT_MAN_AUT)
                    {
                        ucHeThongAuto1.CheDoChay = UcHeThongAuto.CheDo.Auto;
                        this._so.SendingCommand.SW_MAN_AUTO = true;
                        this.lblCheDoHeThongAut.ForeColor = Color.Blue;
                        this.lblCheDoHeThongMan.ForeColor = Color.DarkGray;
                    }
                    else
                    {
                        ucHeThongAuto1.CheDoChay = UcHeThongAuto.CheDo.Manual;
                        this._so.SendingCommand.SW_MAN_AUTO = false;
                        this.lblCheDoHeThongAut.ForeColor = Color.DarkGray;
                        this.lblCheDoHeThongMan.ForeColor = Color.Red;
                    }
                    if (_ro.STT_PAUSE)
                    {
                        btnPause.IsTrangThai = UcBtnPause.TrangThai.Run;
                        this._so.SendingCommand.F2_Pause = true;
                    }
                    else
                    {
                        btnPause.IsTrangThai = UcBtnPause.TrangThai.Stop;
                        this._so.SendingCommand.F2_Pause = false;
                    }
                    if (_ro.STT_CANCEL)
                    {
                        btnHuy.IsTrangThai = UcBtnHuyMe.TrangThai.Run;
                        this._so.SendingCommand.F3_Cancel = true;
                    }
                    else
                    {
                        btnHuy.IsTrangThai = UcBtnHuyMe.TrangThai.Stop;
                        this._so.SendingCommand.F3_Cancel = false;
                    }
                    ucTinHieu_Can_Agg1_1.Visible = _ro.Op_VanCan_Agg_1_1;
                    ucTinHieu_Can_Agg1_2.Visible = _ro.Op_VanCan_Agg_1_2;

                    ucTinHieu_Can_Agg2_1.Visible = _ro.Op_VanCan_Agg_2_1;
                    ucTinHieu_Can_Agg2_2.Visible = _ro.Op_VanCan_Agg_2_2;

                    ucTinHieu_Can_Agg3_1.Visible = _ro.Op_VanCan_Agg_3_1;
                    ucTinHieu_Can_Agg3_2.Visible = _ro.Op_VanCan_Agg_3_2;

                    ucTinHieu_Can_Agg4_1.Visible = _ro.Op_VanCan_Agg_4_1;
                    ucTinHieu_Can_Agg4_2.Visible = _ro.Op_VanCan_Agg_4_2;

                    ucTinHieu_Can_Agg5_1.Visible = _ro.Op_VanCan_Agg_5_1;
                    ucTinHieu_Can_Agg5_2.Visible = _ro.Op_VanCan_Agg_5_2;

                    ucTinHieu_Can_Agg6_1.Visible = _ro.Op_VanCan_Agg_6_1;
                    ucTinHieu_Can_Agg6_2.Visible = _ro.Op_VanCan_Agg_6_2;

                    ucTinHieu_Can_Ce_1.Visible = _ro.Op_VanCan_XiMang_1;
                    ucTinHieu_Can_Ce_2.Visible = _ro.Op_VanCan_XiMang_2;
                    ucTinHieu_Can_Ce_3.Visible = _ro.Op_VanCan_XiMang_3;
                    ucTinHieu_Can_Ce_4.Visible = _ro.Op_VanCan_XiMang_4;
                    ucTinHieu_Can_Ce_5.Visible = _ro.Op_VanCan_XiMang_5;

                    ucTinHieu_Can_Wa1.Visible = _ro.Op_VanCan_Nuoc_1;
                    ucTinHieu_Can_Wa2.Visible = _ro.Op_VanCan_Nuoc_2;

                    ucTinHieu_Can_Add1.Visible = _ro.Op_VanCan_PhuGia_1;
                    ucTinHieu_Can_Add2.Visible = _ro.Op_VanCan_PhuGia_2;
                    ucTinHieu_Can_Add3.Visible = _ro.Op_VanCan_PhuGia_3;
                    ucTinHieu_Can_Add4.Visible = _ro.Op_VanCan_PhuGia_4;
                    ucTinHieu_Can_Add5.Visible = _ro.Op_VanCan_PhuGia_5;
                    ucTinHieu_Can_Add6.Visible = _ro.Op_VanCan_PhuGia_6;

                    
                    ucButtonRungCanAgg2.IsOn = _ro.Op_RungPheuCan_CotLieu_2;
                    ucButtonRungCanAgg3.IsOn = _ro.Op_RungPheuCan_CotLieu_3;
                    ucButtonRungCanAgg4.IsOn = _ro.Op_RungPheuCan_CotLieu_4;
                    ucButtonRungCanAgg5.IsOn = _ro.Op_RungPheuCan_CotLieu_5;
                    ucButtonRungCanAgg6.IsOn = _ro.Op_RungPheuCan_CotLieu_6;

                    ucButtonSKCe1.IsOn = _ro.Op_VanSutKhi_Silo_1;
                    ucButtonSKCe2.IsOn = _ro.Op_VanSutKhi_Silo_2;
                    ucButtonSKCe3.IsOn = _ro.Op_VanSutKhi_Silo_3;
                    ucButtonSKCe4.IsOn = _ro.Op_VanSutKhi_Silo_4;
                    ucButtonSKCe5.IsOn = _ro.Op_VanSutKhi_Silo_5;

                    ucBaoRung_Ce1.Visible = _ro.Op_RungPheuCan_XiMang_1;
                    ucButtonRungCanCe1.IsOn = _ro.Op_RungPheuCan_XiMang_1;

                    ucBaoRung_Ce2.Visible = _ro.Op_RungPheuCan_XiMang_2;
                    ucButtonRungCanCe2.IsOn = _ro.Op_RungPheuCan_XiMang_2;

                    ucTinHieu_XaCan_Agg1.Visible = _ro.Op_VanXa_PheuCan_Agg_1;
                    ucTinHieu_XaCan_Agg2.Visible = _ro.Op_VanXa_PheuCan_Agg_2;
                    ucTinHieu_XaCan_Agg3.Visible = _ro.Op_VanXa_PheuCan_Agg_3;
                    ucTinHieu_XaCan_Agg4.Visible = _ro.Op_VanXa_PheuCan_Agg_4;
                    ucTinHieu_XaCan_Agg5.Visible = _ro.Op_VanXa_PheuCan_Agg_5;
                    ucTinHieu_XaCan_Agg6.Visible = _ro.Op_VanXa_PheuCan_Agg_6;

                    ucTinHieu_XaCan_Ce1.Visible = _ro.Op_VanXa_PheuCan_XiMang_1;
                    ucTinHieu_XaCan_Ce2.Visible = _ro.Op_VanXa_PheuCan_XiMang_2;

                    ucTinHieu_XaCan_Wa1.Visible = _ro.Op_VanXa_PheuCan_Nuoc_1;
                    ucTinHieu_XaCan_Wa2.Visible = _ro.Op_VanXa_PheuCan_Nuoc_2;

                    ucTinHieu_XaCan_Add1.Visible = _ro.Op_VanXa_PheuCan_PhuGia_1;
                    ucTinHieu_XaCan_Add2.Visible = _ro.Op_VanXa_PheuCan_PhuGia_2;

                    barProcess_Weight_Agg1.Percent = _ro.Per_WAGG_1;
                    barProcess_Weight_Agg2.Percent = _ro.Per_WAGG_2;
                    barProcess_Weight_Agg3.Percent = _ro.Per_WAGG_3;
                    barProcess_Weight_Agg4.Percent = _ro.Per_WAGG_4;
                    barProcess_Weight_Agg5.Percent = _ro.Per_WAGG_5;
                    barProcess_Weight_Agg6.Percent = _ro.Per_WAGG_6;

                    barProcess_Weight_Ce1.Percent = _ro.Per_WCEM_1;
                    barProcess_Weight_Ce2.Percent = _ro.Per_WCEM_2;

                    barProcess_Weight_Wa1.Percent = _ro.Per_WWA_1;
                    barProcess_Weight_Wa2.Percent = _ro.Per_WWA_2;

                    barProcess_Weight_Add1.Percent = _ro.Per_WADD_1;
                    barProcess_Weight_Add2.Percent = _ro.Per_WADD_2;

                    ucBaoRung_Funnel.Visible = _ro.Op_RungPheuCho;
                    ucBaoRung_Funnel.IsOn = _ro.Op_RungPheuCho;
                    if (!ConfigManager.TramTronConfig.Show_Funnel)
                    {
                        ucButtonRungCanAgg1.IsOn = _ro.Op_RungPheuCho;
                    }
                    else
                    {
                        ucButtonRungCanAgg1.IsOn = _ro.Op_RungPheuCan_CotLieu_1;
                        ucButtonRungCanPC.IsOn = _ro.Op_RungPheuCho;
                    }
                    

                    ucTinHieu_PCD.Visible = _ro.Op_TinHieu_PheuChoDong;
                    ucTinHieu_PCD.IsOn = _ro.Op_TinHieu_PheuChoDong;

                    ucTinHieu_PCM.Visible = _ro.Op_TinHieu_PheuChoMo;
                    ucTinHieu_PCM.IsOn = _ro.Op_TinHieu_PheuChoMo;

                    ucTinHieu_Xa_Funnel.Visible = _ro.Op_Van_XaPheuCho;

                    uc_TinHieu_CuaNoiMo.Visible = _ro.Op_TinHieu_CuaNoiMo;
                    uc_TinHieu_CuaNoiMo.IsOn = _ro.Op_TinHieu_CuaNoiMo;

                    uc_TinHieu_CuaNoi1per2.Visible = _ro.Op_TinHieu_CuaNoi_1p2;
                    uc_TinHieu_CuaNoi1per2.IsOn = _ro.Op_TinHieu_CuaNoi_1p2;

                    uc_TinHieu_CuaNoiDong.Visible = _ro.Op_TinHieu_CuaNoiDong;
                    uc_TinHieu_CuaNoiDong.IsOn = _ro.Op_TinHieu_CuaNoiDong;

                    uc_TinHIeu_VanMoCuaNoi.Visible = _ro.Op_Van_MoCuaNoi;
                    uc_TinHIeu_VanDongCuaNoi.Visible = _ro.Op_Van_DongCuaNoi;

                    ucThoiGianThucTron.Visible = _ro.Op_MIXER_FULL;
                    
                    ucThoiGianThucXa.Visible = _ro.Op_TinHieu_CuaNoiMo;
                    if(_ro.PheuChoStatus != double.NaN)
                    {
                        switch (_ro.PheuChoStatus)
                        {
                            case 0:
                                this.lblStatusPC.Text = "EM";
                                this.ucGauTai1.IsGauTaiStatus = UcGauTai.GauTaiStatus.Empty;
                                break;
                            case 1:
                                this.lblStatusPC.Text = "FU";
                                this.ucGauTai1.IsGauTaiStatus = UcGauTai.GauTaiStatus.Full;
                                break;
                            case 2:
                                this.lblStatusPC.Text = "IN";
                                this.ucGauTai1.IsGauTaiStatus = UcGauTai.GauTaiStatus.In;
                                break;
                            case 3:
                                this.lblStatusPC.Text = "OU";
                                this.ucGauTai1.IsGauTaiStatus = UcGauTai.GauTaiStatus.Out;
                                break;
                        }
                    }

                    checkEdit2.Checked = _ro.Op_TinHieu_NoiTron;
                    
                    btnF_Agg1.Visible = _ro.Op_TTC_AGG1;
                    btnF_Agg2.Visible = _ro.Op_TTC_AGG2;
                    btnF_Agg3.Visible = _ro.Op_TTC_AGG3;
                    btnF_Agg4.Visible = _ro.Op_TTC_AGG4;
                    btnF_Agg5.Visible = _ro.Op_TTC_AGG5;
                    btnF_Agg6.Visible = _ro.Op_TTC_AGG6;

                    btnF_Ce1.Visible = _ro.Op_TTC_SILO1;
                    btnF_Ce2.Visible = _ro.Op_TTC_SILO2;
                    btnF_Ce3.Visible = _ro.Op_TTC_SILO3;
                    btnF_Ce4.Visible = _ro.Op_TTC_SILO4;
                    btnF_Ce5.Visible = _ro.Op_TTC_SILO5;

                    btnF_Wa1.Visible = _ro.Op_TTC_WA1;
                    btnF_Wa2.Visible = _ro.Op_TTC_WA2;

                    btnF_Add1.Visible = _ro.Op_TTC_ADD1;
                    btnF_Add2.Visible = _ro.Op_TTC_ADD2;
                    btnF_Add3.Visible = _ro.Op_TTC_ADD3;
                    btnF_Add4.Visible = _ro.Op_TTC_ADD4;
                    btnF_Add5.Visible = _ro.Op_TTC_ADD5;
                    btnF_Add6.Visible = _ro.Op_TTC_ADD6;


                    //=========================================GAU TAI


                    ucTinHieu_GT_Duoi.IsOn = _ro.Op_TinHieu_GauDuoi;
                    ucTinHieu_GT_Cho.IsOn = _ro.Op_TinHieu_GauCho;
                    ucTinHieu_GT_Tren.IsOn = _ro.Op_TinHieu_GauTren;
                    ucTinHieu_GT_AnToan.IsOn = _ro.Op_TinHieu_GauAnToan;
                    if (_ro.Op_TinHieu_GauDuoi)
                    {
                        ucGauTai1.IsTrangThai = UcGauTai.TrangThai.GauDuoi;
                        
                        tempGau = 1;
                    }
                    else if(tempGau == 1 && _ro.Op_TinHieu_GauLen)
                    {
                        ucGauTai1.IsTrangThai = UcGauTai.TrangThai.GauGiuaDuoi;
                        tempGau = 2;
                    }
                    else if(_ro.Op_TinHieu_GauCho)
                    {
                        ucGauTai1.IsTrangThai = UcGauTai.TrangThai.GauCho;
                        tempGau = 3;
                    }
                    else if(tempGau == 3 && _ro.Op_TinHieu_GauLen)
                    {
                        ucGauTai1.IsTrangThai = UcGauTai.TrangThai.GauGiuaTren;
                        tempGau = 4;
                    }
                    else if(_ro.Op_TinHieu_GauTren)
                    {
                        ucGauTai1.IsTrangThai = UcGauTai.TrangThai.GauTren;
                        tempGau = 5;
                    }
                    else if(_ro.Op_TinHieu_GauAnToan)
                    {
                        ucGauTai1.IsTrangThai = UcGauTai.TrangThai.GauAnToan;
                    }

                    else if(tempGau == 5 && _ro.Op_TinHieu_GauXuong)
                    {
                        ucGauTai1.IsTrangThai = UcGauTai.TrangThai.GauGiuaTren;
                        tempGau = 4;
                    }
                    else if(_ro.Op_TinHieu_GauDuoi)
                    {
                        ucGauTai1.IsTrangThai = UcGauTai.TrangThai.GauCho;
                        tempGau = 3;
                    }
                    else if(tempGau == 3 && _ro.Op_TinHieu_GauXuong)
                    {
                        ucGauTai1.IsTrangThai = UcGauTai.TrangThai.GauGiuaDuoi;
                        tempGau = 2;
                    }

                    ucTinHieuGauLen.Visible = _ro.Op_TinHieu_GauLen;
                    ucTinHieuGauLen1.Visible = _ro.Op_TinHieu_GauLen;
                    ucTinHieuGauXuong.Visible = _ro.Op_TinHieu_GauXuong;
                    ucTinHieuGauXuong1.Visible = _ro.Op_TinHieu_GauXuong;

                    //=========================================THDC

                    ucBaoDongThungCanAgg1.IsOn = _ro.Op_THDC_WAGG1;
                    ucBaoDongThungCanAgg2.IsOn = _ro.Op_THDC_WAGG2;
                    ucBaoDongThungCanAgg3.IsOn = _ro.Op_THDC_WAGG3;
                    ucBaoDongThungCanAgg4.IsOn = _ro.Op_THDC_WAGG4;
                    ucBaoDongThungCanAgg5.IsOn = _ro.Op_THDC_WAGG5;
                    ucBaoDongThungCanAgg6.IsOn = _ro.Op_THDC_WAGG6;
                    ucBaoDongThungCanCe1.IsOn = _ro.Op_THDC_WCE1;
                    ucBaoDongThungCanCe2.IsOn = _ro.Op_THDC_WCE2;
                    ucBaoDongThungCanWa1.IsOn = _ro.Op_THDC_WWA1;
                    ucBaoDongThungCanWa2.IsOn = _ro.Op_THDC_WWA2;
                    ucBaoDongThungCanAdd1.IsOn = _ro.Op_THDC_WADD1;
                    ucBaoDongThungCanAdd2.IsOn = _ro.Op_THDC_WADD2;

                    //============================================================= DU LIEU

                    siloAgg1.KLThucTe = this.CorectData(_ro.PV_AGG_1);
                    weightAgg1.Weight = this.CorectData(_ro.WE_AGG_1);
                    slMeDaCanAgg1.SoLuongMeDaTron = this.CorectData(_ro.SMC_AGG_1);
                    this.lblPV1.Text = "PV1: " + this.CorectData(_ro.PV_AGG_1);
                    this.lblSoMe.Text = "Số mẻ: " + this.CorectData(_ro.SMC_AGG_1);

                    siloAgg2.KLThucTe = this.CorectData(_ro.PV_AGG_2);
                    weightAgg2.Weight = this.CorectData(_ro.WE_AGG_2);
                    slMeDaCanAgg2.SoLuongMeDaTron = this.CorectData(_ro.SMC_AGG_2);
                    this.lblPV2.Text = "PV2: " + this.CorectData(_ro.PV_AGG_2);

                    siloAgg3.KLThucTe = this.CorectData(_ro.PV_AGG_3);
                    weightAgg3.Weight = this.CorectData(_ro.WE_AGG_3);
                    slMeDaCanAgg3.SoLuongMeDaTron = this.CorectData(_ro.SMC_AGG_3);
                    this.lblPV3.Text = "PV3: " + this.CorectData(_ro.PV_AGG_3);

                    siloAgg4.KLThucTe = this.CorectData(_ro.PV_AGG_4);
                    weightAgg4.Weight = this.CorectData(_ro.WE_AGG_4);
                    slMeDaCanAgg4.SoLuongMeDaTron = this.CorectData(_ro.SMC_AGG_4);
                    this.lblPV4.Text = "PV4: " + this.CorectData(_ro.PV_AGG_4);

                    siloAgg5.KLThucTe = this.CorectData(_ro.PV_AGG_5);
                    weightAgg5.Weight = this.CorectData(_ro.WE_AGG_5);
                    slMeDaCanAgg5.SoLuongMeDaTron = this.CorectData(_ro.SMC_AGG_5);
                    this.lblPV5.Text = "PV5: " + this.CorectData(_ro.PV_AGG_5);

                    siloAgg6.KLThucTe = this.CorectData(_ro.PV_AGG_6);
                    weightAgg6.Weight = this.CorectData(_ro.WE_AGG_6);
                    slMeDaCanAgg6.SoLuongMeDaTron = this.CorectData(_ro.SMC_AGG_6);
                    this.lblPV6.Text = "PV6: " + this.CorectData(_ro.PV_AGG_6);

                    siloCe1.KLThucTe = this.CorectData(_ro.PV_SILO_1);
                    siloCe2.KLThucTe = this.CorectData(_ro.PV_SILO_2);
                    siloCe3.KLThucTe = this.CorectData(_ro.PV_SILO_3);
                    weightCe1.Weight = this.CorectData(_ro.WE_CEM_1);
                    slMeDaCanCe1.SoLuongMeDaTron = this.CorectData(_ro.SMC_CEM_1);

                    siloCe4.KLThucTe = this.CorectData(_ro.PV_SILO_4);
                    siloCe5.KLThucTe = this.CorectData(_ro.PV_SILO_5);
                    weightCe2.Weight = this.CorectData(_ro.WE_CEM_2);
                    slMeDaCanCe2.SoLuongMeDaTron = this.CorectData(_ro.SMC_CEM_2);

                    siloWa1.KLThucTe = this.CorectData(_ro.PV_WA_1);
                    siloWa2.KLThucTe = this.CorectData(_ro.PV_WA_2);
                    weightWa1.Weight = this.CorectData(_ro.WE_WA_1);
                    weightWa2.Weight = this.CorectData(_ro.WE_WA_2);
                    slMeDaCanWa1.SoLuongMeDaTron = this.CorectData(_ro.SMC_WA_1);
                    slMeDaCanWa2.SoLuongMeDaTron = this.CorectData(_ro.SMC_WA_2);

                    siloAdd1.KLThucTe = this.CorectData(_ro.PV_ADD_1);
                    siloAdd2.KLThucTe = this.CorectData(_ro.PV_ADD_2);
                    siloAdd3.KLThucTe = this.CorectData(_ro.PV_ADD_3);
                    weightAdd1.Weight = this.CorectData(_ro.WE_ADD_1);
                    slMeDaCanAdd1.SoLuongMeDaTron = this.CorectData(_ro.SMC_ADD_1);

                    siloAdd4.KLThucTe = this.CorectData(_ro.PV_ADD_4);
                    siloAdd5.KLThucTe = this.CorectData(_ro.PV_ADD_5);
                    siloAdd6.KLThucTe = this.CorectData(_ro.PV_ADD_6);
                    weightAdd2.Weight = this.CorectData(_ro.WE_ADD_2);
                    slMeDaCanAdd2.SoLuongMeDaTron = this.CorectData(_ro.SMC_ADD_2);

                    slMeDaCanPC.SoLuongMeDaTron = this.CorectData(_ro.SMC_PTG);

                    ucGauTai1.SoMeDaTron = this.CorectData(_ro.SMC_SKIP);

                    this.ucThoiGianThucTron.GiaTri = this.CorectData(_ro.ThoiGianThucTron);
                    this.ucThoiGianThucXa.GiaTri = this.CorectData(_ro.ThoiGianThucXa);
                    this.slMeDaCanNoiTron.SoLuongMeDaTron = this.CorectData(_ro.SMC_MIXER);
                    //RunFan_NewThread(true);
                }
            }
            catch (ThreadAbortException ex)
            {
                TramTromMessageBox.ShowMessageDialog(ex.ToString());
            }
        }
        
        private void DoCreateNewDuLieuTron(object sender, EventArgs e)
        {
            this.CreateNewDuLieuTron(((sender as DXMenuItem).Tag as VanHanh.RowInfo).RowHandle);

        }
        private void DoViewDuLieuTron()
        {

        }
        private void DoEditDuLieuTron(object sender, EventArgs e)
        {
            this.EditHopDong(((sender as DXMenuItem).Tag as VanHanh.RowInfo).RowHandle);
        }
        private void DoChangeDuLieuTron(object sender, EventArgs e)
        {
            this.ChangeHopDong(((sender as DXMenuItem).Tag as VanHanh.RowInfo).RowHandle);
        }
        private void DoRemoveDuLieuTron(object sender, EventArgs e)
        {
            this.RemoveHopDong(((sender as DXMenuItem).Tag as VanHanh.RowInfo).RowHandle);
        }
        private void grvHopDong_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView gridView = sender as GridView;
            if (e.RowHandle >= 0 && e.RowHandle < this._blstDuLieuTron.Count)
            {
                string a = gridView.GetRowCellValue(e.RowHandle, gridView.Columns["NPStatus"]).ToString();
                if (a == 1.ToString())
                {
                    e.Appearance.BackColor = Color.Green;
                    e.Appearance.BackColor2 = Color.MintCream;
                    return;
                }
              
            }
        }
        private void grvHopDong_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.MenuType == GridMenuType.Row)
            {
                int rowHandle = e.HitInfo.RowHandle;
                e.Menu.Items.Clear();
                if (rowHandle < 0)
                {
                    this._CanEditDuLieuTron = false;
                    this._CanDeleteDuLieuTron = false;
                }
                else
                {
                    this._CanEditDuLieuTron = true;
                    this._CanDeleteDuLieuTron = true;
                }
                DXMenuItem dXMenuItem = new DXMenuItem("&Tạo mới Hợp đồng", new EventHandler(this.DoCreateNewDuLieuTron), ResourceNDP.plus_dlt);
                dXMenuItem.Tag = new VanHanh.RowInfo(view, rowHandle);
                //dXMenuItem.Enabled = this._CanNewDuLieuTron;
                dXMenuItem.Enabled = true;
                e.Menu.Items.Add(dXMenuItem);
                DXMenuItem dXMenuItem2 = new DXMenuItem("&Chỉnh sửa Hợp đồng", new EventHandler(this.DoEditDuLieuTron), ResourceNDP.edit_dlt);
                dXMenuItem2.Tag = new VanHanh.RowInfo(view, rowHandle);
                // dXMenuItem2.Enabled = (this._CanEditDuLieuTron || this._CanEditDuLieuTron_KLOnly);
                dXMenuItem2.Enabled = _CanEditDuLieuTron;
                e.Menu.Items.Add(dXMenuItem2);
                DXMenuItem dXMenuItem3 = new DXMenuItem("&Tìm Hợp đồng đã tạo", new EventHandler(this.DoChangeDuLieuTron), ResourceNDP.search_dll);
                dXMenuItem3.Tag = new VanHanh.RowInfo(view, rowHandle);
                dXMenuItem3.Enabled = true;
                 e.Menu.Items.Add(dXMenuItem3);
                DXMenuItem dXMenuItem4 = new DXMenuItem("&Xóa dữ liệu trộn", new EventHandler(this.DoRemoveDuLieuTron), ResourceNDP.delete_dlt);
                dXMenuItem4.Tag = new VanHanh.RowInfo(view, rowHandle);
                 dXMenuItem4.Enabled = this._CanDeleteDuLieuTron;
                 //dXMenuItem4.Enabled = true;
                e.Menu.Items.Add(dXMenuItem4);
            }
        }
        private void ResetValueInfoTable()
        {
            this.lblMaPhieuTron.Text
            = this.lblTenKhachHang.Text
            = this.lblTenCongTruong.Text
            = this.lblMAC.Text
            = this.lblTenHangMuc.Text
            = this.lblLuyKe.Text = "----------";
        }
        private void DoFocusHopDong()
        {
            ObjDuLieuTron objDuLieuTron = this.grvHopDong.GetRow(this.grvHopDong.FocusedRowHandle) as ObjDuLieuTron;
            if (objDuLieuTron != null && objDuLieuTron.HopDongID != null)
            {
                int? hopDongID = objDuLieuTron.HopDongID;
                int num = 0;
                if (!(hopDongID.GetValueOrDefault() == num & hopDongID != null))
                {

                    ObjHopDong hopDongByKey = this._presenter.GetHopDongByKey(objDuLieuTron.HopDongID.Value);
                    if (hopDongByKey == null)
                    {
                        return;
                    }
                    
                    if (!this._TronOnlineAttributes.IsRunning)
                    {
                        ResetValueInfoTable();
                        int _idMAC = (int)hopDongByKey.MACID;
                        int _idKhachHang = (int)hopDongByKey.KhachHangID;
                        int _idCongTruong = (int)hopDongByKey.CongTruongID;
                        if (hopDongByKey.HangMucID.HasValue)
                        {
                            int _idHangMuc = (int)hopDongByKey.HangMucID;
                            this.lblTenHangMuc.Text = this._presenter.GetHangMucByKey(_idHangMuc).TenHangMuc;
                        }
                        //this.lblMaPhieuTron.Text = hopDongByKey.MaHopDong;
                        this.lblTenKhachHang.Text = this._presenter.GetKhachHangByKey(_idKhachHang).TenKhachHang;
                        this.lblTenCongTruong.Text = this._presenter.GetCongTruongByKey(_idCongTruong).TenCongTruong;
                        this.lblMAC.Text = hopDongByKey.NPMACTenMAC;
                        this.lblMAC.Tag = hopDongByKey;
                        this.lblKhoiLuong.Text = hopDongByKey.DLT_KLDuTinh.ToString();
                        this.lblLuyKe.Text = hopDongByKey.KLDaGiao.ToString();
                        this.spnThemBotNc.Tag = hopDongByKey.MACID;
                        this.spnThemBotNc.EditValue = hopDongByKey.NPMACThemBotNuoc1;
                        this.ucSoKhoiTrenMe.GiaTri = (decimal)hopDongByKey.DLT_KLDuTinhCuaTungMe;
                        this.lblNguoiTron.Text = GlobalValues.DisplayUser;
                        
                        this.BuildSetPoint(hopDongByKey, false);

                    }
                    return;
                }
            }
        }
        private void Test_DoFocusHopDong(int row)
        {

            ObjDuLieuTron objDuLieuTron = this.grvHopDong.GetRow(row) as ObjDuLieuTron;
            if (objDuLieuTron != null && objDuLieuTron.HopDongID != null)
            {
                int? hopDongID = objDuLieuTron.HopDongID;
                int num = 0;
                if (!(hopDongID.GetValueOrDefault() == num & hopDongID != null))
                {
                    ObjHopDong hopDongByKey = this._presenter.GetHopDongByKey(objDuLieuTron.HopDongID.Value);
                    if (hopDongByKey == null)
                    {
                        return;
                    }
                    this.BuildSetPoint(hopDongByKey, false);
                    if (!this._TronOnlineAttributes.IsRunning)
                    {
                        int _idMAC = (int)hopDongByKey.MACID;
                        int _idKhachHang = (int)hopDongByKey.KhachHangID;
                        int _idCongTruong = (int)hopDongByKey.CongTruongID;
                        int _idHangMuc = (int)hopDongByKey.HangMucID;
                        this.lblMaPhieuTron.Text = hopDongByKey.MaHopDong;
                        this.lblTenKhachHang.Text = this._presenter.GetKhachHangByKey(_idKhachHang).TenKhachHang;
                        this.lblTenCongTruong.Text = this._presenter.GetCongTruongByKey(_idCongTruong).TenCongTruong;
                        this.lblTenHangMuc.Text = this._presenter.GetHangMucByKey(_idHangMuc).TenHangMuc;
                        this.lblMAC.Text = hopDongByKey.NPMACTenMAC;
                        this.lblKhoiLuong.Text = hopDongByKey.DLT_KLDuTinh.ToString();
                        this.spnThemBotNc.Tag = hopDongByKey.MACID;
                        this.spnThemBotNc.EditValue = hopDongByKey.NPMACThemBotNuoc1;
                        this.ucSoKhoiTrenMe.GiaTri = (decimal)hopDongByKey.DLT_KLDuTinhCuaTungMe;

                        /*Send_Data_DB_2_To_PLC();
                        Send_Data_DB_3_To_PLC();
                        Send_Data_DB_4_To_PLC();
                        Send_Data_DB_5_To_PLC();*/

                    }
                    return;
                }
            }
        }

        private void Test_InitRunning(int row)
        {
            
            ObjDuLieuTron objDuLieuTron = this.grvHopDong.GetRow(row) as ObjDuLieuTron;
            int hopDongID = objDuLieuTron.HopDongID.Value;
            
            if (objDuLieuTron == null || objDuLieuTron.HopDongID == null)
            {
                return;
            }

            this._selectedHD_Run = this._presenter.GetHopDongByKey(hopDongID);

            this._selectedPT_Run = this._presenter.CreateAndSaveNewPhieuTron(this._selectedHD_Run, false);
            this.some = 1;
            this.lblMaPhieuTron.Text = this._selectedPT_Run.MaPhieuTron;
            this.lblDriver.Text = string.Empty;
            this.lblXe.Text = string.Empty;
            this.ChangeStatusSelectedDuLieuTron(1, null);
            //this.BuildSetPoint(this._selectedHD_Run, true);

            Random ramNV = new Random();
            int intNV = ramNV.Next(1, this._blstNhanVien.Count);
            Random ramXe = new Random();
            int intXe = ramXe.Next(1, this._blstXe.Count);
            Random ramTãie = new Random();
            int intTaiXe = ramTãie.Next(1, this._blstTaiXe.Count);

            this.lueDriver.EditValue = intTaiXe;
            this.lueXe.EditValue = intXe;
            
            SaveTaiXe();
            SaveXe();
            
        }
        private void AutoTest(int randomNumber)
        {

            this._so.SendingCommand.NN_MCN = true;
            labelControl1.Visible = true;
            this.SendData_DB2_NewTread();
            Thread.Sleep(500);
            this._so.SendingCommand.NN_MCN = false;
            labelControl1.Visible = false;
            this.SendData_DB2_NewTread();

            lblTest.Text = "DLT: " + randomNumber.ToString();
            Test_DoFocusHopDong(randomNumber);
            Thread.Sleep(3000);

            this._so.SendingCommand.F1_Run = true;
            this.SendData_DB2_NewTread();
            Thread.Sleep(1000);
            this._so.SendingCommand.F1_Run = false;
            this.SendData_DB2_NewTread();

            Test_InitRunning(randomNumber);
            lblTest.Text = "Bắt đầu trộn";
            Thread.Sleep(2000);
            soMeCanTronTest = (int)this.slMeDaCanNoiTron.SoLuongMeCanTron;
            lblTest.Text = "Tổng số mẻ: " + soMeCanTronTest.ToString();

            
        }
        private void grcHopDong_DoubleClick(object sender, EventArgs e)
        {
            GridHitInfo gridHitInfo = this.grvHopDong.CalcHitInfo((e as MouseEventArgs).Location);
            if (gridHitInfo.InRowCell)
            {
                if (gridHitInfo.RowHandle < 0)
                {
                    this.CreateNewDuLieuTron(gridHitInfo.RowHandle);
                    return;
                }
                else if(gridHitInfo.RowHandle == 0)
                {
                    if (this._TronOnlineAttributes.IsRunning)
                    {
                        this.ViewDuLieuTron(gridHitInfo.RowHandle);
                    }
                    else
                    {
                        this.EditDuLieuTron(gridHitInfo.RowHandle);
                    }
                }
                else
                {
                    this.EditDuLieuTron(gridHitInfo.RowHandle);
                }
            }
        }
        private void RemoveHopDong(int rowHandle)
        {
            /* if (!this._CanDeleteDuLieuTron)
                 return;*/
            if (!(this.grvHopDong.GetRow(rowHandle) is ObjDuLieuTron row) || !row.HopDongID.HasValue)
            {
                 TramTromMessageBox.ShowWarningDialog(GlobalValues.Messages.EmptyDataCannotDelete);
            }
            else
            {
                if (this.CheckDLTChanged(row))
                    return;
                this._presenter.DeleteDulieuTron(row.DuLieuTronID);
                this._blstDuLieuTron.Remove(row);
                this.grvHopDong.RefreshData();
                
                if (!this._TronOnlineAttributes.IsRunning)
                {
                    this.grvHopDong.FocusedRowHandle = 0;
                    ObjDuLieuTron objDuLieuTron1 = this.grvHopDong.GetRow(this.grvHopDong.FocusedRowHandle) as ObjDuLieuTron;
                    UpdateRankingDLT(objDuLieuTron1);
                }
                
            }
        }
        private void CreateNewDuLieuTron(int rowHandle) //TEST AGAIN
        {
            /*if (!this._CanNewDuLieuTron)
            {
                return;
            }*/
            /*NewDuLieuTronView newDuLieuTronView = new NewDuLieuTronView(null, Enums.FormAction.New, false);
            newDuLieuTronView.CanAddMAC = true;
            newDuLieuTronView.CanEditMAC = true;
            newDuLieuTronView.CanViewMAC = true;*/
            NewHopDongView ctrView = new NewHopDongView((ObjHopDong)null, Enums.FormAction.New);
            ViewManager.ShowViewDialog(ctrView);
            if (ctrView.GetDialogResult() == DialogResult.OK)
            {
                ObjHopDong objHopDong = ctrView.GetSavedHopDong();
                objHopDong = this._ser.GetHopDongByMaHD(objHopDong.MaHopDong);
                ObjDuLieuTron objDuLieuTron = new ObjDuLieuTron();
                DuLieuTronHelper.CopyToDuLieuTron_FromHopDong(objHopDong, objDuLieuTron);
                objDuLieuTron.DLT_KLDuTinhCuaTungMe_NoiB = 1; 
                objDuLieuTron.Status = new int?(0);
                objDuLieuTron.Activated = true;
                objDuLieuTron = this._presenter.AddDuLieuTron(objDuLieuTron);
                this._blstDuLieuTron.Add(objDuLieuTron);
                this.grvHopDong.RefreshData();
                this.grvHopDong.FocusedRowHandle = this._blstDuLieuTron.Count - 1;
                if (!this._TronOnlineAttributes.IsRunning)
                {
                    ObjDuLieuTron objDuLieuTron1 = this.grvHopDong.GetRow(this.grvHopDong.FocusedRowHandle) as ObjDuLieuTron;
                    UpdateRankingDLT(objDuLieuTron1);
                }
            }
        }

        private void ViewDuLieuTron(int rowHandle)
        {
            ObjDuLieuTron objDuLieuTron = this.grvHopDong.GetRow(rowHandle) as ObjDuLieuTron;
            if (objDuLieuTron == null || objDuLieuTron.HopDongID == null)
            {
                TramTromMessageBox.ShowWarningDialog(GlobalValues.Messages.EmptyDataCannotEdit);
                return;
            }
            if (this.CheckDLTChanged(objDuLieuTron))
            {
                return;
            }
            ObjHopDong ct = new ObjHopDong
            {
                HopDongID = objDuLieuTron.HopDongID.Value
            };
            NewDuLieuTronView newDuLieuTronView = new NewDuLieuTronView(ct, Enums.FormAction.View, false);
            newDuLieuTronView.CanAddMAC = false;
            newDuLieuTronView.CanViewMAC = false;
            newDuLieuTronView.CanEditMAC = false;
            ViewManager.ShowViewDialog(newDuLieuTronView);

        }
        private void EditDuLieuTron(int rowHandle)
        {
            /*if (!this._CanEditDuLieuTron && !this._CanEditDuLieuTron_KLOnly)
            {
                return;
            }*/
            bool editKLOnly = true;
            if (this._CanEditDuLieuTron)
            {
                editKLOnly = false;
            }
            ObjDuLieuTron objDuLieuTron = this.grvHopDong.GetRow(rowHandle) as ObjDuLieuTron;
            if (objDuLieuTron == null || objDuLieuTron.HopDongID == null)
            {
                TramTromMessageBox.ShowWarningDialog(GlobalValues.Messages.EmptyDataCannotEdit);
                return;
            }
            if (this.CheckDLTChanged(objDuLieuTron))
            {
                return;
            }
            ObjHopDong ct = new ObjHopDong
            {
                HopDongID = objDuLieuTron.HopDongID.Value
            };
            NewDuLieuTronView newDuLieuTronView = new NewDuLieuTronView(ct, Enums.FormAction.Edit, editKLOnly);
            newDuLieuTronView.CanAddMAC = true;
            newDuLieuTronView.CanViewMAC = true;
            newDuLieuTronView.CanEditMAC = true;
            ViewManager.ShowViewDialog(newDuLieuTronView);
            if (newDuLieuTronView.GetDialogResult() == DialogResult.OK)
            {
                int value = objDuLieuTron.Status.Value;
                ObjHopDong objHopDong = newDuLieuTronView.GetSavedHopDong();
                objHopDong = this._ser.GetHopDongByMaHD(objHopDong.MaHopDong);
                DuLieuTronHelper.CopyToDuLieuTron_FromHopDong(objHopDong, objDuLieuTron);
                objDuLieuTron.Status = new int?(value);
                int? status = objDuLieuTron.Status;
                int num = 1;
                if (!(status.GetValueOrDefault() == num & status != null))
                {
                    objDuLieuTron.Status = new int?(0);
                }
                objDuLieuTron = this._presenter.UpdateDuLieuTron(objDuLieuTron);
                this.grvHopDong.RefreshRow(rowHandle);
                if (!this._TronOnlineAttributes.IsRunning)
                {
                    this.BuildSetPoint(objHopDong, false);
                }
                //Update Thong tin PT
                UpdateInfoPT(rowHandle);
                //DoFocusHopDong();
            }
        }

        private void UpdateInfoPT(int rowHandle)
        {
            ObjDuLieuTron objDuLieuTron = this.grvHopDong.GetRow(0) as ObjDuLieuTron;
            if (objDuLieuTron != null && objDuLieuTron.HopDongID != null)
            {
                int? hopDongID = objDuLieuTron.HopDongID;
                int num = 0;
                if (!(hopDongID.GetValueOrDefault() == num & hopDongID != null))
                {
                    ObjHopDong hopDongByKey = this._presenter.GetHopDongByKey(objDuLieuTron.HopDongID.Value);
                    if (hopDongByKey == null)
                    {
                        return;
                    }

                    if (!this._TronOnlineAttributes.IsRunning)
                    {
                       // ResetValueInfoTable();
                        int _idMAC = (int)hopDongByKey.MACID;
                        int _idKhachHang = (int)hopDongByKey.KhachHangID;
                        int _idCongTruong = (int)hopDongByKey.CongTruongID;
                        if (hopDongByKey.HangMucID.HasValue)
                        {
                            int _idHangMuc = (int)hopDongByKey.HangMucID;
                            this.lblTenHangMuc.Text = this._presenter.GetHangMucByKey(_idHangMuc).TenHangMuc;
                        }
                        //this.lblMaPhieuTron.Text = hopDongByKey.MaHopDong;
                        this.lblTenKhachHang.Text = this._presenter.GetKhachHangByKey(_idKhachHang).TenKhachHang;
                        this.lblTenCongTruong.Text = this._presenter.GetCongTruongByKey(_idCongTruong).TenCongTruong;
                        this.lblMAC.Text = hopDongByKey.NPMACTenMAC;
                        this.lblMAC.Tag = hopDongByKey;
                        this.lblKhoiLuong.Text = hopDongByKey.DLT_KLDuTinh.ToString();
                        this.lblLuyKe.Text = hopDongByKey.KLDaGiao.ToString();
                        this.spnThemBotNc.Tag = hopDongByKey.MACID;
                        this.spnThemBotNc.EditValue = hopDongByKey.NPMACThemBotNuoc1;
                        this.ucSoKhoiTrenMe.GiaTri = (decimal)hopDongByKey.DLT_KLDuTinhCuaTungMe;
                        this.lblNguoiTron.Text = GlobalValues.DisplayUser;

                    }
                    return;
                }
            }

        }
        
        private void EditHopDong(int rowHandle)
        {
            /*if (!this._CanEditDuLieuTron && !this._CanEditDuLieuTron_KLOnly)
            {
                return;
            }*/
            bool editKLOnly = true;
            if (this._CanEditDuLieuTron)
            {
                editKLOnly = false;
            }
            ObjDuLieuTron objDuLieuTron = this.grvHopDong.GetRow(rowHandle) as ObjDuLieuTron;
            if (objDuLieuTron == null || objDuLieuTron.HopDongID == null)
            {
                TramTromMessageBox.ShowWarningDialog(GlobalValues.Messages.EmptyDataCannotEdit);
                return;
            }
            if (this.CheckDLTChanged(objDuLieuTron))
            {
                return;
            }
            ObjHopDong ct = new ObjHopDong
            {
                HopDongID = objDuLieuTron.HopDongID.Value
            };
            NewHopDongView ctrlView = new NewHopDongView(ct, Enums.FormAction.Edit);
            ViewManager.ShowViewDialog(ctrlView);
            if (ctrlView.GetDialogResult() == DialogResult.OK)
            {
                int value = objDuLieuTron.Status.Value;
                ObjHopDong objHopDong = ctrlView.GetSavedHopDong();
                objHopDong = this._ser.GetHopDongByMaHD(objHopDong.MaHopDong);
                DuLieuTronHelper.CopyToDuLieuTron_FromHopDong(objHopDong, objDuLieuTron);
                objDuLieuTron.Status = new int?(value);
                int? status = objDuLieuTron.Status;
                int num = 1;
                if (!(status.GetValueOrDefault() == num & status != null))
                {
                    objDuLieuTron.Status = new int?(0);
                }
                objDuLieuTron = this._presenter.UpdateDuLieuTron(objDuLieuTron);
                this.grvHopDong.RefreshRow(rowHandle);
                if (!this._TronOnlineAttributes.IsRunning)
                {
                    this.BuildSetPoint(objHopDong, false);
                }
            }
        }

        private void ChangeHopDong(int rowHandle)
        {
            /*if (!this._CanFindDuLieuTron)
            {
                return;
            }*/

            ObjDuLieuTron objDuLieuTron = this.grvHopDong.GetRow(rowHandle) as ObjDuLieuTron;
            if (objDuLieuTron != null && this.CheckDLTChanged(objDuLieuTron))
            {
                return;
            }
            
            UcSearchHopDong ucSearchHD = new UcSearchHopDong();
            ucSearchHD.SearchStatus = 0;
            ViewManager.ShowViewDialog(ucSearchHD);
            if(ucSearchHD.GetDialogResult() == DialogResult.OK)
            {
                ObjHopDong selectedObjects = ucSearchHD.GetSelectedObjects();
                ObjHopDong fromHopDong = selectedObjects;
                if (objDuLieuTron != null)
                {
                    DuLieuTronHelper.CopyToDuLieuTron_FromHopDong(fromHopDong, objDuLieuTron);
                    objDuLieuTron.DLT_KLDuTinhCuaTungMe_NoiB = 1;
                    objDuLieuTron.Status = new int?(0);
                    objDuLieuTron = this._presenter.UpdateDuLieuTron(objDuLieuTron);
                    this.grvHopDong.RefreshRow(rowHandle);
                    this.grvHopDong.FocusedRowHandle = rowHandle;
                    if (!this._TronOnlineAttributes.IsRunning)
                    {
                        ObjDuLieuTron objDuLieuTron1 = this.grvHopDong.GetRow(this.grvHopDong.FocusedRowHandle) as ObjDuLieuTron;
                        UpdateRankingDLT(objDuLieuTron1);
                    }
                    
                    return;
                }
                objDuLieuTron = new ObjDuLieuTron();
                DuLieuTronHelper.CopyToDuLieuTron_FromHopDong(fromHopDong, objDuLieuTron);
                objDuLieuTron.DLT_KLDuTinhCuaTungMe_NoiB = 1;
                objDuLieuTron.Status = new int?(0);
                objDuLieuTron = this._presenter.AddDuLieuTron(objDuLieuTron);
                this._blstDuLieuTron.Add(objDuLieuTron);
                this.grvHopDong.RefreshData();
                this.grvHopDong.FocusedRowHandle = this._blstDuLieuTron.Count - 1;
                if (!this._TronOnlineAttributes.IsRunning)
                {
                    ObjDuLieuTron objDuLieuTron2 = this.grvHopDong.GetRow(this.grvHopDong.FocusedRowHandle) as ObjDuLieuTron;
                    UpdateRankingDLT(objDuLieuTron2);
                }
            }
        }

        private bool CheckDLTChanged(ObjDuLieuTron objDLT)
        {
            ObjDuLieuTron dLTByKey = this._presenter.GetDLTByKey(objDLT.DuLieuTronID);
            if (dLTByKey == null)
            {
                TramTromMessageBox.ShowWarningDialog(GlobalValues.Messages.DataDeletedPleaseRefresh);
                return true;
            }
            if (!objDLT.VersionNo.SequenceEqual(dLTByKey.VersionNo))
            {
                TramTromMessageBox.ShowWarningDialog(GlobalValues.Messages.DataEditedPleaseRefresh);
                return true;
            }
            return false;
        }
        private class RowInfo
        {
            public RowInfo(GridView view, int rowHandle)
            {
                this.RowHandle = rowHandle;
                this.View = view;
            }

            public int RowHandle;

            public GridView View;
        }

        private void grvHopDong_FocusedRowChanged_1(object sender, FocusedRowChangedEventArgs e)
        {
            this.DoFocusHopDong();
        }

        private void txtNiemChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        #region SetSLMe
        private void SetSLMe(int slMe)
        {

            this.slMeDaCanAgg1.SoLuongMeCanTron
                = (this.slMeDaCanAgg2.SoLuongMeCanTron
                 = (this.slMeDaCanAgg3.SoLuongMeCanTron
                  = (this.slMeDaCanAgg4.SoLuongMeCanTron
                   = (this.slMeDaCanAgg5.SoLuongMeCanTron
                    = (this.slMeDaCanAgg6.SoLuongMeCanTron
                     = (this.slMeDaCanCe1.SoLuongMeCanTron
                      = (this.slMeDaCanCe2.SoLuongMeCanTron
                       = (this.slMeDaCanWa1.SoLuongMeCanTron
                        = (this.slMeDaCanWa2.SoLuongMeCanTron
                         = (this.slMeDaCanAdd1.SoLuongMeCanTron
                          = (this.slMeDaCanAdd2.SoLuongMeCanTron
                           = (this.slMeDaCanPC.SoLuongMeCanTron
                           = (this.ucGauTai1.SoLuongMeCanTron
                            = (this.slMeDaCanNoiTron.SoLuongMeCanTron = slMe))))))))))))));
        }
        #endregion

        //============================================
        // EVENT UI 
        //============================================
        private void btnVanXa_Agg3_1_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_AGG3_1 = true;
            this.SendData_DB2_NewTread();
        }

        private void btnVanXa_Agg3_1_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_AGG3_1 = false;
            this.SendData_DB2_NewTread();
        }

        private void btnVanXa_Agg3_2_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_AGG3_2 = true;
            this.SendData_DB2_NewTread();
        }

        private void btnVanXa_Agg3_2_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_AGG3_2 = false;
            this.SendData_DB2_NewTread();
        }

        private void btnVanXa_Agg2_1_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_AGG2_1 = true;
            this.SendData_DB2_NewTread();
        }
        private void btnVanXa_Agg2_1_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_AGG2_1 = false;
            this.SendData_DB2_NewTread();
        }
        private void btnVanXa_Agg2_2_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_AGG2_2 = true;
            this.SendData_DB2_NewTread();
        }

        private void btnVanXa_Agg2_2_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_AGG2_2 = false;
            this.SendData_DB2_NewTread();
        }

        private void btnVanXa_Agg1_1_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_AGG1_1 = true;
            this.SendData_DB2_NewTread();
        }

        private void btnVanXa_Agg1_1_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_AGG1_1 = false;
            this.SendData_DB2_NewTread();
        }

        private void btnVanXa_Agg1_2_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_AGG1_2 = true;
            this.SendData_DB2_NewTread();
        }

        private void btnVanXa_Agg1_2_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_AGG1_2 = false;
            this.SendData_DB2_NewTread();
        }

        private void btnVanXa_Ce1_1_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_CE1 = true;
            this.SendData_DB2_NewTread();
        }

        private void btnVanXa_Ce1_1_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_CE1 = false;
            this.SendData_DB2_NewTread();
        }

        private void btnVanXa_Wa1_1_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_WA1 = true;
            this.SendData_DB2_NewTread();
        }

        private void btnVanXa_Wa1_1_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_WA1 = false;
            this.SendData_DB2_NewTread();
        }

       

        private void ShowFrmSilo(UcBaseSilo2 slBase, string maSilo)
        {
            Enums.FormAction action;
            //if (this._CanEditSilo)
            if (true)
            {
                action = Enums.FormAction.Edit;
            }
            else
            {
                /*if (!this._CanViewSilo)
                {
                    return;
                }
                action = Enums.FormAction.View;*/
            }
            if (this.lblMAC.Tag == null)
            {
                TramTromMessageBox.ShowWarningDialog(GlobalValues.Messages.PleaseSelectData);
                return;
            }
            ObjHopDong selectedHD = this.lblMAC.Tag as ObjHopDong;
            ObjSilo objSilo = (from o in this._blstSilo
                               where o.MaSilo == maSilo
                               select o).First<ObjSilo>();
            bool showDoAm = false;
            if (maSilo.Contains("Agg"))
            {
                showDoAm = true;
            }
            NewSiloView newSiloView = new NewSiloView(objSilo, action, false, showDoAm, false);
            ViewManager.ShowViewDialog(newSiloView);
            if (newSiloView.GetDialogResult() == DialogResult.OK)
            {
                slBase.SiloDesc = objSilo.MaterialName;
                this._presenter.ListSilo();
                
                if (newSiloView.ShowDoAm)
                {
                    //if (this._TronOnlineAttributes.IsRunning)
                    /*if (true)
                    {
                        this.BuildSetPoint(this._selectedHD_Run, true);
                       *//* Thread thread = new Thread(new ThreadStart(this.SendSetPoint));
                        thread.Start();
                        this._so.SoMeDis = (int)this._sp.SoMe;*//*
                        this.SendData_DB3_NewTread();
                        return;
                    }*/
                    
                }
                BuildSetPoint(selectedHD, true);
                this.SendData_DB3_NewTread();
            }
        }
        //  Caption Click
        private void siloAgg1_CaptionClick(object sender, EventArgs e)
        {
            ShowFrmSilo(sender as UcBaseSilo2, "Agg1");
        }

        private void siloAgg2_CaptionClick(object sender, EventArgs e)
        {
           ShowFrmSilo(sender as UcBaseSilo2, "Agg2");
        }

        private void siloAgg3_CaptionClick(object sender, EventArgs e)
        {
            ShowFrmSilo(sender as UcBaseSilo2, "Agg3");
        }

        private void siloAgg4_CaptionClick(object sender, EventArgs e)
        {
            ShowFrmSilo(sender as UcBaseSilo2, "Agg4");
        }

        private void siloAgg5_CaptionClick(object sender, EventArgs e)
        {
            ShowFrmSilo(sender as UcBaseSilo2, "Agg5");
        }

        private void siloAgg6_CaptionClick(object sender, EventArgs e)
        {
             ShowFrmSilo(sender as UcBaseSilo2, "Agg6");
        }

        private void siloCe1_CaptionClick(object sender, EventArgs e)
        {
            ShowFrmSilo(sender as UcBaseSilo2, "Ce1");
        }
        private void siloCe2_CaptionClick(object sender, EventArgs e)
        {
            ShowFrmSilo(sender as UcBaseSilo2, "Ce2");
        }

        private void siloCe3_CaptionClick(object sender, EventArgs e)
        {
            ShowFrmSilo(sender as UcBaseSilo2, "Ce3");
        }

        private void siloCe4_CaptionClick(object sender, EventArgs e)
        {
            ShowFrmSilo(sender as UcBaseSilo2, "Ce4");
        }

        private void siloCe5_CaptionClick(object sender, EventArgs e)
        {
            ShowFrmSilo(sender as UcBaseSilo2, "Ce5");
        }

        private void siloWa1_CaptionClick(object sender, EventArgs e)
        {
            ShowFrmSilo(sender as UcBaseSilo2, "Wa1");
        }
        private void siloWa2_CaptionClick(object sender, EventArgs e)
        {
            ShowFrmSilo(sender as UcBaseSilo2, "Wa2");
        }
        private void siloAdd1_CaptionClick(object sender, EventArgs e)
        {
            ShowFrmSilo(sender as UcBaseSilo2, "Add1");
        }

        private void siloAdd2_CaptionClick(object sender, EventArgs e)
        {
            ShowFrmSilo(sender as UcBaseSilo2, "Add2");
        }

        private void siloAdd3_CaptionClick(object sender, EventArgs e)
        {
            ShowFrmSilo(sender as UcBaseSilo2, "Add3");
        }

        private void siloAdd4_CaptionClick(object sender, EventArgs e)
        {
            ShowFrmSilo(sender as UcBaseSilo2, "Add4");
        }

        private void siloAdd5_CaptionClick(object sender, EventArgs e)
        {
            ShowFrmSilo(sender as UcBaseSilo2, "Add5");
        }

        private void siloAdd6_CaptionClick(object sender, EventArgs e)
        {
            ShowFrmSilo(sender as UcBaseSilo2, "Add6");
        }

        // Weight Click
        private void weightAgg1_WeightClick(object sender, EventArgs e)
        {
            this.ShowWeighMngView("Agg1");
        }

        private void weightAgg2_WeightClick(object sender, EventArgs e)
        {
            this.ShowWeighMngView("Agg2");
        }

        private void weightAgg3_WeightClick(object sender, EventArgs e)
        {
            this.ShowWeighMngView("Agg3");
        }
        private void weightAgg_WeightClick(object sender, EventArgs e)
        {
            this.ShowWeighMngView("Agg4");
        }
        private void weightAgg5_WeightClick(object sender, EventArgs e)
        {
            this.ShowWeighMngView("Agg5");
        }

        private void weightAgg6_WeightClick(object sender, EventArgs e)
        {
            this.ShowWeighMngView("Agg6");
        }

        private void weightCe1_WeightClick(object sender, EventArgs e)
        {
            this.ShowWeighMngView("Ce1");
        }

        private void weightCe2_WeightClick(object sender, EventArgs e)
        {
            this.ShowWeighMngView("Ce2");
        }
        private void weightWa1_WeightClick(object sender, EventArgs e)
        {
            this.ShowWeighMngView("Wa1");
        }

        private void weightWa2_WeightClick(object sender, EventArgs e)
        {
            this.ShowWeighMngView("Wa2");
        }
        private void weightAdd1_WeightClick(object sender, EventArgs e)
        {
            this.ShowWeighMngView("Add1");
        }

        private void weightAdd2_WeightClick(object sender, EventArgs e)
        {
            this.ShowWeighMngView("Add2");
        }


        private void ShowWeighMngView(string weiCode)
        {
            ObjHopDong selectedHD = this.lblMAC.Tag as ObjHopDong;
            ObjWeigh wei = this._blstWeigh.Where<ObjWeigh>((System.Func<ObjWeigh, bool>)(o => o.WeighCode == weiCode)).First<ObjWeigh>();
            NewWeightView ctrView = new NewWeightView(wei, Enums.FormAction.Edit);
            ViewManager.ShowViewDialog(ctrView);
            if (ctrView.GetDialogResult() != DialogResult.OK)
                return;
            BuildSetPoint(selectedHD, true);
            this.SendData_DB4_NewTread();
        }

        private void btnMoCuaNoi_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_MCN = true;
            labelControl1.Visible = true;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());

        }

        private void btnMoCuaNoi_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_MCN = false;
            labelControl1.Visible = false;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());

        }

        private void btnMoKep_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_MO_KEP = true;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnMoKep_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_MO_KEP = false;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnRungMiengKep_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_RUNG_KEP = true;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnRungMiengKep_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_RUNG_KEP = false;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnDongCuaNoi_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_DCN = true;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnDongCuaNoi_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_DCN = false;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnDongKep_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_DONG_KEP = true;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnDongKep_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_DONG_KEP = false;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }


        private void btnXaCanCotLieu_ButtonClick(object sender, EventArgs e)
        {
            DoXaCanCotLieu();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnNapLieuNoiTron_ButtonClick(object sender, EventArgs e)
        {
            
            if (btnNapLieuNoiTron.IsRun)
            {
                this._so.SendingCommand.SW_NAP_NOI_TRON = true;
                this.SendData_DB2_NewTread();
                btnNapLieuNoiTron.Caption = "NẠP LIỆU TỰ ĐỘNG";
            }
            else
            {
                this._so.SendingCommand.SW_NAP_NOI_TRON = false;
                this.SendData_DB2_NewTread();
                btnNapLieuNoiTron.Caption = "NẠP LIỆU TAY";
            }
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnXaNoiTron_ButtonClick(object sender, EventArgs e)
        {
            if (btnXaNoiTron.IsRun)
            {
                this._so.SendingCommand.SW_XA_NOI_TRON = true;
                this.SendData_DB2_NewTread();
                btnXaNoiTron.Caption = "CỬA NỒI TỰ ĐỘNG";
            }
            else
            {
                this._so.SendingCommand.SW_XA_NOI_TRON = false;
                this.SendData_DB2_NewTread();
                btnXaNoiTron.Caption = "CỬA NỒI TAY";
            }
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnRuaNoiTron_ButtonClick(object sender, EventArgs e)
        {
            if (btnRuaNoiTron.IsRun)
            {
                this._so.SendingCommand.SW_RUA_NOI_TRON = true;
                this.SendData_DB2_NewTread();
            }
            else
            {
                this._so.SendingCommand.SW_RUA_NOI_TRON = false;
                this.SendData_DB2_NewTread();
            }
            TramTronLogger.WriteInfo(sender.ToString());
        }



        private void btnThoiGian_ButtonClick(object sender, EventArgs e)
        {
            DoShowTimerPara();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnRun_ButtonClick(object sender, EventArgs e)
        {
            TramTronLogger.WriteInfo(sender.ToString());
            if (btnRun.IsOn)
            {
                /*DialogResult result = MessageBox.Show("Xác nhận chạy tiến trình trộn?", "Thông báo", MessageBoxButtons.YesNo);
                switch (result)
                {
                    case DialogResult.Yes:
                        *//*this._so.SendingCommand.F1_Run = true;
                        this.SendData_DB2_NewTread();
                        //StatusConnected.CheckOpenSof(true, true);
                        Thread.Sleep(100);
                        this._so.SendingCommand.F1_Run = false;
                        this.SendData_DB2_NewTread();*//*
                        this.InitRunning(true);
                        
                        if (checkEdit3.Checked)
                        {
                            isTesst = true;
                            lblTest.Text = "Đang chạy Auto";
                        }
                       
                        break;
                    case DialogResult.No:
                        break;
                }*/
                this.InitRunning(true);

                if (checkEdit3.Checked)
                {
                    isTesst = true;
                    lblTest.Text = "Đang chạy Auto";
                }
            }
            else
            {
                this._so.SendingCommand.F1_Run = false;
                this.SendData_DB2_NewTread();
            }
            
        }

        private void DoRunning()
        {
            try
            {
                this._so.SendingCommand.F1_Run = true;
                this.SendData_DB2_NewTread();
                Thread.Sleep(100);
                this._so.SendingCommand.F1_Run = false;
                this.SendData_DB2_NewTread();
            }
            catch (System.Exception ex)
            {
                TramTronLogger.WriteError(ex);
                TramTromMessageBox.ShowErrorDialog(ex.ToString());
            }
        }

        private void ucHeThongAuto1_ButtonClick_1(object sender, EventArgs e)
        {
            if (ucHeThongAuto1.IsAuto)
            {
                this._so.SendingCommand.SW_MAN_AUTO = false;
                this.SendData_DB2_NewTread();

            }
            else if (!ucHeThongAuto1.IsAuto)
            {
                this._so.SendingCommand.SW_MAN_AUTO = true;
                this.SendData_DB2_NewTread();
            }
            TramTronLogger.WriteInfo(sender.ToString());
        }
        
        
        

        private void Send_Data_DB_3_To_PLC() //WRITE DATA TO PLC
        {
            List<byte> list_00 = new List<byte>();
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoTren_Agg1));// 0
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoDuoi_Agg1));// 4
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.RoiTuDo_Agg1));// 8
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianMoCan_Agg1));// 12
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianDongCan_Agg1));// 16
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTinhLuongRoiThem_Agg1));// 20
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoTren_Agg2));// 24
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoDuoi_Agg2));// 28
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.RoiTuDo_Agg2));// 32
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianMoCan_Agg2));// 36
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianDongCan_Agg2));// 40
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTinhLuongRoiThem_Agg2));// 44
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoTren_Agg3));// 48
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoDuoi_Agg3));// 52
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.RoiTuDo_Agg3));// 56
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianMoCan_Agg3));// 60
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianDongCan_Agg3));// 64
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTinhLuongRoiThem_Agg3));// 68
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoTren_Agg4));// 72
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoDuoi_Agg4));// 76
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.RoiTuDo_Agg4));// 80
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianMoCan_Agg4));// 84
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianDongCan_Agg4));// 88
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTinhLuongRoiThem_Agg4));// 92
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoTren_Agg5));// 96
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoDuoi_Agg5));// 100
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.RoiTuDo_Agg5));// 104
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianMoCan_Agg5));// 108
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianDongCan_Agg5));// 112
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTinhLuongRoiThem_Agg5));// 116
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoTren_Agg6));// 120
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoDuoi_Agg6));// 124
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.RoiTuDo_Agg6));// 128
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianMoCan_Agg6));// 132
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianDongCan_Agg6));// 136
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTinhLuongRoiThem_Agg6));// 140
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoTren_Ce1));// 144
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoDuoi_Ce1));// 148
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.RoiTuDo_Ce1));// 152
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianMoCan_Ce1));// 156
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianDongCan_Ce1));//160
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTinhLuongRoiThem_Ce1));// 164
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoTren_Ce2));// 168
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoDuoi_Ce2));// 172
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.RoiTuDo_Ce2));// 176
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianMoCan_Ce2));// 180
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianDongCan_Ce2));//184
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTinhLuongRoiThem_Ce2));// 188
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoTren_Ce3));// 192
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoDuoi_Ce3));// 196
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.RoiTuDo_Ce3));// 200
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianMoCan_Ce3));// 204
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianDongCan_Ce3));//208
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTinhLuongRoiThem_Ce3));// 212
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoTren_Ce4));// 216
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoDuoi_Ce4));// 220
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.RoiTuDo_Ce4));// 224
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianMoCan_Ce4));// 228
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianDongCan_Ce4));//232
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTinhLuongRoiThem_Ce4));// 236
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoTren_Ce5));// 240
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoDuoi_Ce5));// 244
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.RoiTuDo_Ce5));// 248
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianMoCan_Ce5));// 252
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianDongCan_Ce5));//256
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTinhLuongRoiThem_Ce5));// 260
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoTren_Wa1));// 264
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoDuoi_Wa1));// 268
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.RoiTuDo_Wa1));// 272
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianMoCan_Wa1));// 276
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianDongCan_Wa1));//280
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTinhLuongRoiThem_Wa1));// 284
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoTren_Wa2));// 288
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoDuoi_Wa2));// 292
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.RoiTuDo_Wa2));// 296
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianMoCan_Wa2));// 300
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianDongCan_Wa2));//304
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTinhLuongRoiThem_Wa2));// 308
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoTren_Add1));// 312
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoDuoi_Add1));// 316
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.RoiTuDo_Add1));// 320
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianMoCan_Add1));// 324
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianDongCan_Add1));//328
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTinhLuongRoiThem_Add1));// 332
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoTren_Add2));// 336
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoDuoi_Add2));// 340
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.RoiTuDo_Add2));// 344
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianMoCan_Add2));// 348
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianDongCan_Add2));//352
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTinhLuongRoiThem_Add2));// 356
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoTren_Add3));// 360
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoDuoi_Add3));// 364
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.RoiTuDo_Add3));// 368
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianMoCan_Add3));// 372
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianDongCan_Add3));//376
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTinhLuongRoiThem_Add3));// 380
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoTren_Add4));// 384
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoDuoi_Add4));// 388
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.RoiTuDo_Add4));// 392
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianMoCan_Add4));// 396
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianDongCan_Add4));//400
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTinhLuongRoiThem_Add4));// 404
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoTren_Add5));// 408
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoDuoi_Add5));// 412
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.RoiTuDo_Add5));// 416
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianMoCan_Add5));// 420
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianDongCan_Add5));//424
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTinhLuongRoiThem_Add5));// 428
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoTren_Add6));// 432
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoDuoi_Add6));// 436
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.RoiTuDo_Add6));// 440
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianMoCan_Add6));// 444
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianDongCan_Add6));//448
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTinhLuongRoiThem_Add6));// 452

            byte[] value = list_00.ToArray();
            this._plcController.WriteBytes(DataType.DataBlock, 3, 0, value);
        }
        private void Send_Data_DB_4_To_PLC() // WRITE DATA TO PLC
        {
            List<byte> list_00 = new List<byte>();
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreCan_Agg1));// 0
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreXa_Agg1));// 4
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreDongCan_Agg1));// 8
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KhoiLuongBaoRong_Agg1));// 12
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KhoiLuongRungCan_Agg1));// 16
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianBatRung_Agg1));// 20
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTatRung_Agg1));// 24
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreCan_Agg2));// 28
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreXa_Agg2));// 32
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreDongCan_Agg2));// 36
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KhoiLuongBaoRong_Agg2));// 40
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KhoiLuongRungCan_Agg2));// 44
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianBatRung_Agg2));// 48
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTatRung_Agg2));// 52
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreCan_Agg3));// 56
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreXa_Agg3));// 60
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreDongCan_Agg3));// 64
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KhoiLuongBaoRong_Agg3));// 68
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KhoiLuongRungCan_Agg3));// 72
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianBatRung_Agg3));// 76
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTatRung_Agg3));// 80
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreCan_Agg4));// 84
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreXa_Agg4));// 88
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreDongCan_Agg4));// 92
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KhoiLuongBaoRong_Agg4));// 96
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KhoiLuongRungCan_Agg4));// 100
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianBatRung_Agg4));// 104
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTatRung_Agg4));// 108
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreCan_Agg5));// 112
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreXa_Agg5));// 116
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreDongCan_Agg5));// 120`
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KhoiLuongBaoRong_Agg5));// 124
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KhoiLuongRungCan_Agg5));// 128
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianBatRung_Agg5));// 132
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTatRung_Agg5));// 136
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreCan_Agg6));// 140
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreXa_Agg6));// 144
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreDongCan_Agg6));// 148
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KhoiLuongBaoRong_Agg6));// 152
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KhoiLuongRungCan_Agg6));// 156
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianBatRung_Agg6));// 160
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTatRung_Agg6));// 164
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreCan_Ce1));// 168
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreXa_Ce1));// 172
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreDongCan_Ce1));// 176
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KhoiLuongBaoRong_Ce1));// 180
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KhoiLuongRungCan_Ce1));// 184
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianBatRung_Ce1));// 188
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTatRung_Ce1));// 192
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreCan_Ce2));// 196
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreXa_Ce2));// 200
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreDongCan_Ce2));// 204
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KhoiLuongBaoRong_Ce2));// 208
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KhoiLuongRungCan_Ce2));// 212
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianBatRung_Ce2));// 216
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTatRung_Ce2));// 220
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreCan_Wa1));// 224
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreXa_Wa1));// 228
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreDongCan_Wa1));// 232
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KhoiLuongBaoRong_Wa1));// 236
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreCan_Wa2));// 240
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreXa_Wa2));// 244
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreDongCan_Wa2));// 248
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KhoiLuongBaoRong_Wa2));// 252
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreCan_Add1));// 256
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreXa_Add1));// 260
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreDongCan_Add1));// 264
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KhoiLuongBaoRong_Add1));// 268
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreCan_Add2));// 272
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreXa_Add2));// 276
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreDongCan_Add2));// 280
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KhoiLuongBaoRong_Add2));// 284
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SoMeTron));// 288
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Agg1));// 292
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Agg2));// 296
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Agg3));// 300
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Agg4));// 304
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Agg5));// 308
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Agg6));// 312
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Ce1));// 316
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Ce2));// 320
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Ce3));// 324
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Ce4));// 328
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Ce5));// 332
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Wa1));// 336
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Wa2));// 340
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Add1));// 344
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Add2));// 348
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Add3));// 352
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Add4));// 356
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Add5));// 360
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Add6));// 364

            byte[] value = list_00.ToArray();
            this._plcController.WriteBytes(DataType.DataBlock, 4, 0, value);
        }
        private void Send_Data_DB_4_To_PLC_Update()
        {
            List<byte> list_00 = new List<byte>();
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Agg1 + 10));// 292
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Agg2 + 10));// 296
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Agg3 + 10));// 300
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Agg4));// 304
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Agg5));// 308
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Agg6));// 312
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Ce1));// 316
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Ce2));// 320
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Ce3));// 324
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Ce4));// 328
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Ce5));// 332
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Wa1));// 336
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Wa2));// 340
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Add1));// 344
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Add2));// 348
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Add3));// 352
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Add4));// 356
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Add5));// 360
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Add6));// 364
            byte[] value = list_00.ToArray();
            this._plcController.WriteBytes(DataType.DataBlock, 4, 292, value);
        }
        private void Send_Data_DB_5_To_PLC() //WRITE DATA TO PLC
        {
            List<byte> list_00 = new List<byte>();
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_Tron));// 0
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_Xa50));// 4
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_Xa100));// 8
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_PheuChoDay));// 12
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_XaCe1SauPC));// 16
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_XaCe2SauPC));// 20
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_XaNuocSauPC));// 24
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_XaPC));// 28
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_PC_ChoPhepRung));// 32
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_Rung_PC_ON));// 36
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_Rung_PC_OFF));// 40
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_XaCan_Agg1));// 44
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_XaCan_Agg2));// 48
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_XaCan_Agg3));// 52
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_XaCan_Agg4));// 56
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_XaCan_Agg5));// 60
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_XaCan_Agg6));// 64
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_XaWa2_PC));// 68
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_XaAdd1_PC));// 72
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_XaAdd2_PC));// 76
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_AnToanGau));// 80
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_DL_GauLen));// 84
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_DL_GauDuoi));// 88
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_DL_XaGau));// 92
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_XaTruoc_Agg1));// 96
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_XaTruoc_Agg2));// 100
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_XaTruoc_Agg3));// 104
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_XaTruoc_Agg4));// 108
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_XaTruoc_Agg5));// 112
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_XaTruoc_Agg6));// 116
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.TG_TRE_TAT_VTX));// 120
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.TG_BAT_RUNG_WAGG));// 124
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.TG_TAT_RUNG_WAGG));// 128
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.TG_BAT_RUNG_WCE));// 132
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.TG_TAT_RUNG_WCE));// 136
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.TG_BAT_SKSL));// 140
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.TG_TAT_SKSL));// 144
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.TG_TRE_MO_VAN_CE));// 148
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.HSN_AGG1));// 152
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.HSX_AGG1));// 156
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.HSN_AGG2));// 160
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.HSX_AGG2));// 164
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.HSN_AGG3));// 168
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.HSX_AGG3));// 172
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.HSN_AGG4));// 176
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.HSX_AGG4));// 180
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.HSN_AGG5));// 184
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.HSX_AGG5));// 188
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.HSN_AGG6));// 192
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.HSX_AGG6));// 196
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.HSN_CE1));// 200
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.HSX_CE1));// 204
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.HSN_CE2));// 208
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.HSX_CE2));// 212
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.HSN_CE3));// 216
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.HSN_CE4));// 220
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.HSN_CE5));// 224
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.HSN_WA1));// 228
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.HSX_WA1));// 232
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.HSN_WA2));// 236
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.HSX_WA2));// 240
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.HSN_ADD1));// 244
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.HSX_ADD1));// 248
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.HSN_ADD2));// 252
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.HSX_ADD2));// 256
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.HSN_ADD3));// 260
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.HSN_ADD4));// 264
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.HSN_ADD5));// 268
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.HSN_ADD6));// 272


            byte[] value = list_00.ToArray();
            this._plcController.WriteBytes(DataType.DataBlock, 5, 0, value);
        }
        private void Send_Data_DB_6_To_PLC()   //WRITE DATA TO PLC
        {
            List<byte> list_00 = new List<byte>();
            /*list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_TEMPLE));// 0
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_TEMPLE));// 4
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_TEMPLE));// 8
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_TEMPLE));// 12
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_TEMPLE));// 16
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_TEMPLE));// 20
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_TEMPLE));// 24
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_TEMPLE));// 28
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_TEMPLE));// 32
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_TEMPLE));// 36
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_TEMPLE));// 40
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_TEMPLE));// 44*/
            /*list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_ZERO_AGG1));// 48
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
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_XUNG_PG6));// 188*/
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.LG1_AGG));// 192
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.LG2_AGG));// 196
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.LG3_AGG));// 200
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.LG4_CE));// 204
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.LG5_CE));// 208
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.LG6_ADD));// 212
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.LG7_ADD));// 216

            byte[] value = list_00.ToArray();
            this._plcController.WriteBytes(DataType.DataBlock, 6, 192, value);
        }

        private void Send_Data_DB_2_To_PLC() // WRITE DATA TO PLC
        {
            List<byte> list = new List<byte>();
            list.Add(this._so.Byte_0);
            list.Add(this._so.Byte_1);
            list.Add(this._so.Byte_2);
            list.Add(this._so.Byte_3);
            list.Add(this._so.Byte_4);
            list.Add(this._so.Byte_5);
            list.Add(this._so.Byte_6);
            list.Add(this._so.Byte_7);
            list.Add(this._so.Byte_8);
            list.Add(this._so.Byte_9);
            list.Add(this._so.Byte_10);
            list.Add(this._so.Byte_11);
            list.Add(this._so.Byte_12);
            list.Add(this._so.Byte_13);
            list.Add(this._so.Byte_14);
            list.Add(this._so.Byte_15);
            list.Add(this._so.Byte_16);
            list.Add(this._so.Byte_17);
            list.Add(this._so.Byte_18);
            byte[] value = list.ToArray();
            this._plcController.WriteBytes(DataType.DataBlock, 2, 0, value);
        }
        private void SendData_DB2_NewTread() //BIT
        {
            Thread thread = new Thread(new ThreadStart(this.Send_Data_DB_2_To_PLC));
            thread.Name = "DB_2";
            thread.Start();
        }
        private void SendData_DB3_NewTread() //SILO
        {
            Thread thread = new Thread(new ThreadStart(this.Send_Data_DB_3_To_PLC));
           // thread.Name = "DB_3";
            thread.Start();
        }
        private void SendData_DB4_NewTread() //WEIGH
        {
            Thread thread = new Thread(new ThreadStart(this.Send_Data_DB_4_To_PLC));
            thread.Name = "DB_4";
            thread.Start();
        }
        private void SendData_DB4_Update_NewTread() //Bu Tru Me Cuoi
        {
            Thread thread = new Thread(new ThreadStart(this.Send_Data_DB_4_To_PLC_Update));
            thread.Name = "DB_4_Update";
            thread.Start();
        }
        private void SendData_DB5_NewTread() //TIMER -SIM -GAUTAI -PC -MIXER
        {
            Thread thread = new Thread(new ThreadStart(this.Send_Data_DB_5_To_PLC));
            thread.Name = "DB_5";
            thread.Start();
        }
        private void SendData_DB6_NewTread() //BIT
        {
            Thread thread = new Thread(new ThreadStart(this.Send_Data_DB_6_To_PLC));
            thread.Start();
        }
        private void ucBtnMoPhong1_ButtonClick(object sender, EventArgs e)
        {
            DoMoPhong();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void DoMoPhong()
        {
            if (!this.CheckConnection())
                return;
            /*try
            {

            }
            catch(Exception ex)
            {
                TramTromMessageBox.ShowErrorDialog(ex.ToString());
            }*/
            if (ucBtnMoPhong1.IsOn)
            {
                DialogResult result = TramTromMessageBox.ShowYesNoDialog("Xác nhận 'BẬT' mô phỏng?");
                switch (result)
                {
                    case DialogResult.Yes:
                        this._so.SendingCommand.F4_MoPhong = true;
                        this.SendData_DB2_NewTread();
                        ShowMessage("MÔ PHỎNG TIẾN TRÌNH CHẠY", Enums.MsgType.Info);
                        //ucBtnMoPhong1.IsTrangThai = UcBtnMoPhong.TrangThai.Run;

                        break;
                    case DialogResult.No:
                        break;
                }
            }
            else
            {
                DialogResult result = TramTromMessageBox.ShowYesNoDialog("Xác nhận 'TẮT' mô phỏng?");
                switch (result)
                {
                    case DialogResult.Yes:
                        this._so.SendingCommand.F4_MoPhong = false;
                        this.SendData_DB2_NewTread();
                        //ShowMessage("MÔ PHỎNG TIẾN TRÌNH CHẠY", Enums.MsgType.Info);
                        //ucBtnMoPhong1.IsTrangThai = UcBtnMoPhong.TrangThai.Stop;

                        break;
                    case DialogResult.No:
                        break;
                }
            }
        }

        private void btnF_Ce1_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.FU_CE1 = true;
            this.SendData_DB2_NewTread();
        }

        private void btnF_Ce1_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.FU_CE1 = false;
            this.SendData_DB2_NewTread();
        }

        private void btnPauseWeight_Ce1_ButtonClick(object sender, EventArgs e)
        {
            if (btnPauseWeight_Ce1.IsOn)
            {
                this._so.SendingCommand.PA_CE1 = true;
                this.SendData_DB2_NewTread();
            }
            else
            {
                this._so.SendingCommand.PA_CE1 = false;
                this.SendData_DB2_NewTread();
            }
        }

        private void btnF_Wa1_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.FU_WA1 = true;
            this.SendData_DB2_NewTread();
        }

        private void btnF_Wa1_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.FU_WA1 = false;
            this.SendData_DB2_NewTread();
        }

        private void btnPauseWeight_Wa1_ButtonClick(object sender, EventArgs e)
        {
            if (btnPauseWeight_Wa1.IsOn)
            {
                this._so.SendingCommand.PA_WA1 = true;
                this.SendData_DB2_NewTread();
            }
            else
            {
                this._so.SendingCommand.PA_WA1 = false;
                this.SendData_DB2_NewTread();
            }
        }

        private void btnPause_ButtonClick(object sender, EventArgs e)
        {
            this.DoPause();
            TramTronLogger.WriteInfo(sender.ToString());
        }
        private void DoPause()
        {
            EventLogController.InsertEventLog(new int?(GlobalValues.UserID), GlobalValues.DisplayUser, "F2", string.Empty, string.Empty, string.Empty);
            if (!this.CheckConnection())
            {
                return;
            }
            
            try
            {
                if (btnPause.IsOn)
                {
                    if (TramTromMessageBox.ShowYesNoDialog(GlobalValues.Messages.ConfirmPausePhieuTron) != DialogResult.Yes)
                    {
                        return;
                    }
                    this._so.SendingCommand.F2_Pause = true;
                    this.SendData_DB2_NewTread();
                    StatusConnected.CheckOpenSof(true, false);
                    this.ShowMessage(GlobalValues.Messages.PAUSE, Enums.MsgType.Info);
                    ChangeStatusSelectedDuLieuTron(2, null);
                }
                else
                {
                    this._so.SendingCommand.F2_Pause = false;
                    this.SendData_DB2_NewTread();
                    this.ShowMessage(string.Empty, Enums.MsgType.Info);
                    ChangeStatusSelectedDuLieuTron(1, null);
                }
            }
            catch (System.Exception ex)
            {
                TramTronLogger.WriteError(ex);
                TramTromMessageBox.ShowErrorDialog(ex.ToString());
            }
        }
        private void btnHuy_ButtonClick(object sender, EventArgs e)
        {
            if (btnHuy.IsOn)
            {
                DoHuy();
            }
            else if (!btnHuy.IsOn)
            {
                this._so.SendingCommand.F3_Cancel = false;
                this.SendData_DB2_NewTread();
            }
            TramTronLogger.WriteInfo(sender.ToString());

        }

        private void DoHuy()
        {
            EventLogController.InsertEventLog(new int?(GlobalValues.UserID), GlobalValues.DisplayUser, "F3", string.Empty, string.Empty, string.Empty);
            if (!this.CheckConnection())
            {
                return;
            }
            if (TramTromMessageBox.ShowYesNoDialog(GlobalValues.Messages.ConfirmCancelPhieuTron) != DialogResult.Yes)
            {
                return;
            }
            try
            {
                this._so.SendingCommand.F3_Cancel = true;
                this.SendData_DB2_NewTread();
                btnHuy.IsTrangThai = UcBtnHuyMe.TrangThai.Run;
                Thread.Sleep(50);
                this._so.SendingCommand.F3_Cancel = false;
                this.SendData_DB2_NewTread();
                this.ChangeStatusSelectedDuLieuTron(3, null);
                btnHuy.IsTrangThai = UcBtnHuyMe.TrangThai.Stop;
                this.ShowMessage(GlobalValues.Messages.CancelPhieuTron, Enums.MsgType.Info);
            }
            catch (Exception ex)
            {
                TramTronLogger.WriteError(ex);
                TramTromMessageBox.ShowErrorDialog(ex.ToString());
            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //this._TronOnlineAttributes.IsRunning = this.checkEdit1.Checked;
            if (this._TronOnlineAttributes.IsRunning)
            {
                this.checkEdit1.Text = "CHẠY";
            }
            else
            {
                this.checkEdit1.Text = "Tạm Dừng";
            }
            if (this._plcController.IsConnected)
            {

                byte[] b = this._plcController.ReadBytes(DataType.DataBlock, 1, 0,14);
                this.ReceiveData_DB1(b);

                byte[] c = this._plcController.ReadBytes(DataType.DataBlock, 6, 0, 50);
                this.ReceiveData_DB6(c);

                byte[] d = this._plcController.ReadBytes(DataType.DataBlock, 7, 0, 304);
                this.ReceiveData_DB7(d);
                this.labelControl14.Text = d.Length.ToString();

                //byte[] d = this._plcController.ReadBytes(DataType.DataBlock, 4, 0, 108);
                //this.ReceiveData_DB4(d);

                //byte[] ee = this._plcController.ReadBytes(DataType.DataBlock, 5, 0, 10);
                //this.ReceiveData_DB5(ee);

                BindReceivingOnline(_ro);

                
            }
            else
            {
                //_plcController.AttemptReconnect();
            }
        }
        

        public override void DoKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    if (this.btnRun.Visible)
                    {
                        TramTronLogger.WriteInfo(sender.ToString());
                        InitRunning();
                        ShowMessage("CHẠY PHIẾU TRỘN", Enums.MsgType.Warning);
                        return;
                    }
                    break;
                case Keys.F2:
                    if (this.btnPause.Visible)
                    {
                        TramTronLogger.WriteInfo(sender.ToString());
                        DoPause();
                        return;
                    }
                    break;
                case Keys.F3:
                    if (this.btnHuy.Visible)
                    {
                        TramTronLogger.WriteInfo(sender.ToString());
                        DoHuy();
                        return;
                    }

                    break;
                case Keys.F4:
                    if (this.ucBtnMoPhong1.Visible)
                    {
                        TramTronLogger.WriteInfo(sender.ToString());
                        DoMoPhong();
                    }
                    break;
                case Keys.F5:
                    if (!this.btnThemMe.Visible)
                        break;
                    TramTronLogger.WriteInfo(sender.ToString());
                    this.DoTangMe(); ;
                    break;
                case Keys.F6:
                    if (!this.btnGiamMe.Visible)
                        break;
                    TramTronLogger.WriteInfo(sender.ToString());
                    this.DoGiamMe(); ;
                    break;
                case Keys.F7:
                    break;
                case Keys.F8:
                    DoShowTimerPara();
                    break;
                case Keys.F9:
                    DoXaCanCotLieu();
                    break;
                case Keys.F10:
                    break;
                case Keys.F11:
                    break;
                
                case Keys.F12:
                    LoadFormInPT();
                    return;
                default:
                    return;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (this._plcController.IsConnected)
            {
                byte[] s = this._plcController.ReadBytes(DataType.DataBlock, 8, 0, 156);
                this.ReceiveData_DB8(s);
                BindReceivingOnline_DB8(_ro);
            }
            else
            {
                //this._plcController.AttemptReconnect();
            }
        }
        private void BindReceivingOnline_DB8(ReceivingFromPLC ro)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => this.BindReceivingOnline_DB8(ro)));
                }
                else
                {
                    if (this._ro.Save_Report)
                    {
                        lblSave.Text = "Saved";
                        _idSavePLC = 1;

                    }
                    else if (!this._ro.Save_Report)
                    {
                        lblSave.Text = "NOT Save";
                        this._idSavePLC = 0;
                        this._idSave = 0;
                        if (isTesst)
                        {
                            lblTest.Text = "Số mê hiệm:" + soMeCanTronTest;
                        }
                    }
                    SaveData();
                }
            }
            catch (ThreadAbortException ex)
            {
                TramTromMessageBox.ShowMessageDialog(ex.ToString());
            }
        }
        
        private void btnHuy_ButtonMoveDown(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Xác nhận huỷ tiến trình trộn?", "Thông báo", MessageBoxButtons.YesNo);
            switch (result)
            {
                case DialogResult.Yes:
                    this._so.SendingCommand.F3_Cancel = true;
                    this.SendData_DB2_NewTread();
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void btnHuy_ButtonMoveUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.F3_Cancel = false;
            this.SendData_DB2_NewTread();
        }



        private bool CheckConnection()
        {
            if (GlobalValues.PLCConnected)
                return true;
            TramTromMessageBox.ShowMessageDialog("PLC MẤT KẾT NỐI, VUI LÒNG KIỂM TRA LẠI KẾT NỐI");
            return false;
        }
        private void btnThemMe_ButtonClick(object sender, EventArgs e)
        {
            this.DoTangMe();
            TramTronLogger.WriteInfo(sender.ToString());
        }


        private void DoTangMe()
        {
            if (!this.CheckConnection())
                return;
            try
            {
                int slMe = (int)this.slMeDaCanNoiTron.SoLuongMeCanTron + 1;
                this.SetSLMe(slMe);
                //this._so.SoMeDis = slMe;
                this._sp.SoMeTron = slMe;
                SendData_DB4_NewTread();
                UpdateDLT_KLDuTinh_TangMe();
            }
            catch (System.Exception ex)
            {
                TramTronLogger.WriteError(ex);
                //TramTromMessageBox.ShowErrorDialog(ex.ToString());
            }
        }

        private void btnGiamMe_ButtonClick(object sender, EventArgs e)
        {
            this.DoGiamMe();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void DoGiamMe()
        {
            if (!this.CheckConnection())
                return;
            try
            {
                if((int)this.slMeDaCanNoiTron.SoLuongMeCanTron <= 1)
                {
                    TramTromMessageBox.ShowWarningDialog("Không thể giảm số lượng mẻ cần trộn xuống!");
                }
                else
                {
                    int slMe = (int)this.slMeDaCanNoiTron.SoLuongMeCanTron - 1;
                    this.SetSLMe(slMe);
                    //this._so.SoMeDis = slMe;
                    this._sp.SoMeTron = slMe;
                    SendData_DB4_NewTread();
                    UpdateDLT_KLDuTinh_GiamMe();
                }
            }
            catch (System.Exception ex)
            {
                TramTronLogger.WriteError(ex);
                TramTromMessageBox.ShowErrorDialog(ex.ToString());
            }
        }
        private void btnXacNhanLoi_ButtonClick(object sender, EventArgs e)
        {
            if (btnXacNhanLoi.IsOn)
            {
                this.btnXacNhanLoi.IsTrangThai = UcBtnReset.TrangThai.Run;
                Thread.Sleep(100);
                this.btnXacNhanLoi.IsTrangThai = UcBtnReset.TrangThai.Stop;
                TramTronLogger.WriteInfo(sender.ToString());
            }
            
        }
        private void DoShowTimerPara()
        {
            TimerParaMngView ctrView = new TimerParaMngView();
            ViewManager.ShowViewDialog(ctrView);
            if (ctrView.GetDialogResult() != DialogResult.OK)
                return;
            this._presenter.ListTimerPara();
            SendData_DB5_NewTread();
        }
        private void DoXaCanCotLieu()
        {
            if (ConfigManager.TramTronConfig.CapPhoiRes == 1)
            {
                if (btnXaCanCotLieu.IsRun)
                {
                    this._so.SendingCommand.SW_XA_COT_LIEU = true;
                    this.SendData_DB2_NewTread();
                    btnXaCanCotLieu.Caption = "GÀU TẢI TỰ ĐỘNG";
                    this.ucButtonGauUp1.Visible = false;
                    this.ucButtonGauStop2.Visible = false;
                    this.ucButtonGauDown1.Visible = false;
                }
                else
                {
                    this._so.SendingCommand.SW_XA_COT_LIEU = false;
                    this.SendData_DB2_NewTread();
                    btnXaCanCotLieu.Caption = "GÀU TẢI TAY";
                    this.ucButtonGauUp1.Visible = true;
                    this.ucButtonGauStop2.Visible = true;
                    this.ucButtonGauDown1.Visible = true;
                }
            }
            else if(ConfigManager.TramTronConfig.CapPhoiRes == 0)
            {
                if (btnXaCanCotLieu.IsRun)
                {
                    this._so.SendingCommand.SW_XA_COT_LIEU = true;
                    this.SendData_DB2_NewTread();
                    btnXaCanCotLieu.Caption = "XẢ CÂN TỰ ĐỘNG";
                }
                else
                {
                    this._so.SendingCommand.SW_XA_COT_LIEU = false;
                    this.SendData_DB2_NewTread();
                    btnXaCanCotLieu.Caption = "XẢ CÂN CỐT LIỆU";
                }
            }
            
        }
        private void DoNapLieuNoiTron()
        {

        }
        private void DoCuaNoiTay()
        {

        }
        private void DoRuaNoiTron()
        {

        }
        private void spnGiuNuocTrenCan_EditValueChanged(object sender, EventArgs e)
        {
            ObjHopDong selectedHD = this.lblMAC.Tag as ObjHopDong;
            SpinEdit spinEdit = sender as SpinEdit;

            if (spinEdit != null && spinEdit.Value < 0)
            {
                spinEdit.Value = 0;
            }
            //this._so.DeNuocTrenCan = Convert.ToInt32(this.spnGiuNuocTrenCan.EditValue);
            _giuNuocTenCan = Convert.ToInt32(this.spnGiuNuocTrenCan.EditValue);
            this.BuildSetPoint(selectedHD, true);
            this.SendData_DB4_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnPauseWeight_Agg1_ButtonClick(object sender, EventArgs e)
        {
            if (btnPauseWeight_Agg1.IsOn)
            {
                this._so.SendingCommand.PA_AGG1 = true;
                this.SendData_DB2_NewTread();
            }
            else
            {
                this._so.SendingCommand.PA_AGG1 = false;
                this.SendData_DB2_NewTread();
            }
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnVanXa_Agg4_2_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_AGG4_2 = true;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnVanXa_Agg4_2_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_AGG4_2 = false;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnVanXa_Agg4_1_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_AGG4_1 = true;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnVanXa_Agg4_1_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_AGG4_1 = false;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnVanXa_Agg5_2_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_AGG5_2 = true;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnVanXa_Agg5_2_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_AGG5_2 = false;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnVanXa_Agg5_1_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_AGG5_1 = true;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnVanXa_Agg5_1_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_AGG5_1 = false;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnVanXa_Agg6_2_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_AGG6_2 = true;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnVanXa_Agg6_2_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_AGG6_2 = false;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnVanXa_Agg6_1_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_AGG6_1 = true;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnVanXa_Agg6_1_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_AGG6_1 = false;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnPauseWeight_Agg2_ButtonClick(object sender, EventArgs e)
        {
            if (btnPauseWeight_Agg2.IsOn)
            {
                this._so.SendingCommand.PA_AGG2 = true;
                this.SendData_DB2_NewTread();
            }
            else
            {
                this._so.SendingCommand.PA_AGG2 = false;
                this.SendData_DB2_NewTread();
            }
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnPauseWeight_Agg3_ButtonClick(object sender, EventArgs e)
        {
            if (btnPauseWeight_Agg3.IsOn)
            {
                this._so.SendingCommand.PA_AGG3 = true;
                this.SendData_DB2_NewTread();
            }
            else
            {
                this._so.SendingCommand.PA_AGG3 = false;
                this.SendData_DB2_NewTread();
            }
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnPauseWeight_Agg4_ButtonClick(object sender, EventArgs e)
        {
            if (btnPauseWeight_Agg4.IsOn)
            {
                this._so.SendingCommand.PA_AGG4 = true;
                this.SendData_DB2_NewTread();
            }
            else
            {
                this._so.SendingCommand.PA_AGG4 = false;
                this.SendData_DB2_NewTread();
            }
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnPauseWeight_Agg5_ButtonClick(object sender, EventArgs e)
        {
            if (btnPauseWeight_Agg5.IsOn)
            {
                this._so.SendingCommand.PA_AGG5 = true;
                this.SendData_DB2_NewTread();
            }
            else
            {
                this._so.SendingCommand.PA_AGG5 = false;
                this.SendData_DB2_NewTread();
            }
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnPauseWeight_Agg6_ButtonClick(object sender, EventArgs e)
        {
            if (btnPauseWeight_Agg6.IsOn)
            {
                this._so.SendingCommand.PA_AGG6 = true;
                this.SendData_DB2_NewTread();
            }
            else
            {
                this._so.SendingCommand.PA_AGG6 = false;
                this.SendData_DB2_NewTread();
            }
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnF_Agg1_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.FU_AGG1 = true;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnF_Agg1_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.FU_AGG1 = false;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnF_Agg2_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.FU_AGG2 = true;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnF_Agg2_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.FU_AGG2 = false;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnF_Agg3_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.FU_AGG3 = true;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnF_Agg3_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.FU_AGG3 = false;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnF_Agg4_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.FU_AGG4 = true;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnF_Agg4_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.FU_AGG4 = false;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnF_Agg5_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.FU_AGG5 = true;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnF_Agg5_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.FU_AGG5 = false;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnF_Agg6_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.FU_AGG6 = true;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnF_Agg6_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.FU_AGG6 = false;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }
        // CE
        private void btnF_Ce2_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.FU_CE2 = true;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnF_Ce2_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.FU_CE2 = false;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnF_Ce3_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.FU_CE3 = true;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnF_Ce3_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.FU_CE3 = false;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnF_Ce4_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.FU_CE4 = true;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnF_Ce4_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.FU_CE4 = false;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnF_Ce5_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.FU_CE5 = true;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnF_Ce5_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.FU_CE5 = false;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnPauseWeight_Ce2_ButtonClick(object sender, EventArgs e)
        {
            if (btnPauseWeight_Ce2.IsOn)
            {
                this._so.SendingCommand.PA_CE2 = true;
                this.SendData_DB2_NewTread();
            }
            else
            {
                this._so.SendingCommand.PA_CE2 = false;
                this.SendData_DB2_NewTread();
            }
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnPauseWeight_Ce3_ButtonClick(object sender, EventArgs e)
        {
            if (btnPauseWeight_Ce3.IsOn)
            {
                this._so.SendingCommand.PA_CE3 = true;
                this.SendData_DB2_NewTread();
            }
            else
            {
                this._so.SendingCommand.PA_CE3 = false;
                this.SendData_DB2_NewTread();
            }
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnPauseWeight_Ce4_ButtonClick(object sender, EventArgs e)
        {
            if (btnPauseWeight_Ce4.IsOn)
            {
                this._so.SendingCommand.PA_CE4 = true;
                this.SendData_DB2_NewTread();
            }
            else
            {
                this._so.SendingCommand.PA_CE4 = false;
                this.SendData_DB2_NewTread();
            }
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnPauseWeight_Ce5_ButtonClick(object sender, EventArgs e)
        {
            if (btnPauseWeight_Ce5.IsOn)
            {
                this._so.SendingCommand.PA_CE5 = true;
                this.SendData_DB2_NewTread();
            }
            else
            {
                this._so.SendingCommand.PA_CE5 = false;
                this.SendData_DB2_NewTread();
            }
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnF_Wa2_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.FU_WA2 = true;
            this.SendData_DB2_NewTread();
        }

        private void btnF_Wa2_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.FU_WA2 = false;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnPauseWeight_Wa2_ButtonClick(object sender, EventArgs e)
        {
            if (btnPauseWeight_Wa2.IsOn)
            {
                this._so.SendingCommand.PA_WA2 = true;
                this.SendData_DB2_NewTread();
            }
            else
            {
                this._so.SendingCommand.PA_WA2 = false;
                this.SendData_DB2_NewTread();
            }
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnVanXa_Wa2_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_WA2 = true;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnVanXa_Wa2_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_WA2 = false;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnF_Add1_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.FU_PG1 = true;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnF_Add1_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.FU_PG1 = false;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnF_Add2_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.FU_PG2 = true;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnF_Add2_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.FU_PG2 = false;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnF_Add3_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.FU_PG3 = true;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnF_Add3_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.FU_PG3 = false;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnF_Add4_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.FU_PG4 = true;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnF_Add4_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.FU_PG4 = false;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnF_Add5_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.FU_PG5 = true;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnF_Add5_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.FU_PG5 = false;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnF_Add6_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.FU_PG6 = true;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnF_Add6_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.FU_PG6 = false;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnPauseWeight_Add1_ButtonClick(object sender, EventArgs e)
        {
            if (btnPauseWeight_Add1.IsOn)
            {
                this._so.SendingCommand.PA_PG1 = true;
                this.SendData_DB2_NewTread();
            }
            else
            {
                this._so.SendingCommand.PA_PG1 = false;
                this.SendData_DB2_NewTread();
            }
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnPauseWeight_Add2_ButtonClick(object sender, EventArgs e)
        {
            if (btnPauseWeight_Add2.IsOn)
            {
                this._so.SendingCommand.PA_PG2 = true;
                this.SendData_DB2_NewTread();
            }
            else
            {
                this._so.SendingCommand.PA_PG2 = false;
                this.SendData_DB2_NewTread();
            }
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnPauseWeight_Add3_ButtonClick(object sender, EventArgs e)
        {
            if (btnPauseWeight_Add3.IsOn)
            {
                this._so.SendingCommand.PA_PG3 = true;
                this.SendData_DB2_NewTread();
            }
            else
            {
                this._so.SendingCommand.PA_PG3 = false;
                this.SendData_DB2_NewTread();
            }
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnPauseWeight_Add4_ButtonClick(object sender, EventArgs e)
        {
            if (btnPauseWeight_Add4.IsOn)
            {
                this._so.SendingCommand.PA_PG4 = true;
                this.SendData_DB2_NewTread();
            }
            else
            {
                this._so.SendingCommand.PA_PG4 = false;
                this.SendData_DB2_NewTread();
            }
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnPauseWeight_Add5_ButtonClick(object sender, EventArgs e)
        {
            if (btnPauseWeight_Add5.IsOn)
            {
                this._so.SendingCommand.PA_PG5 = true;
                this.SendData_DB2_NewTread();
            }
            else
            {
                this._so.SendingCommand.PA_PG5 = false;
                this.SendData_DB2_NewTread();
            }
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnPauseWeight_Add6_ButtonClick(object sender, EventArgs e)
        {
            if (btnPauseWeight_Add6.IsOn)
            {
                this._so.SendingCommand.PA_PG6 = true;
                this.SendData_DB2_NewTread();
            }
            else
            {
                this._so.SendingCommand.PA_PG6 = false;
                this.SendData_DB2_NewTread();
            }
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnVanXa_Add1_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_PG1 = true;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }


        private void btnVanXa_Add1_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_PG1 = false;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnVanXa_Add2_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_PG2 = true;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnVanXa_Add2_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_PG2 = false;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnVanXa_Add3_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_PG3 = true;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnVanXa_Add3_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_PG3 = false;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnVanXa_Add4_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_PG4 = true;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnVanXa_Add4_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_PG4 = false;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnVanXa_Add5_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_PG5 = true;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnVanXa_Add5_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_PG5 = false;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnVanXa_Add6_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_PG6 = true;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnVanXa_Add6_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_PG6 = false;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnVanXa_Ce2_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_CE2 = true;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnVanXa_Ce2_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_CE2 = false;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnVanXa_Ce3_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_CE3 = true;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnVanXa_Ce3_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_CE3 = false;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnVanXa_Ce4_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_CE4 = true;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnVanXa_Ce4_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_CE4 = false;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnVanXa_Ce5_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_CE5 = true;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnVanXa_Ce5_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_CE5 = false;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnXaCan_Agg1_ButtonClick(object sender, EventArgs e)
        {
            if (btnXaCan_Agg1.IsOn)
            {
                this._so.SendingCommand.SW_XA_WAGG1 = true;
                this.SendData_DB2_NewTread();
            }
            else
            {
                this._so.SendingCommand.SW_XA_WAGG1 = false;
                this.SendData_DB2_NewTread();
            }
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnXaCan_Agg2_ButtonClick(object sender, EventArgs e)
        {
            if (btnXaCan_Agg2.IsOn)
            {
                this._so.SendingCommand.SW_XA_WAGG2 = true;
                this.SendData_DB2_NewTread();
            }
            else
            {
                this._so.SendingCommand.SW_XA_WAGG2 = false;
                this.SendData_DB2_NewTread();
            }
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnXaCan_Agg3_ButtonClick(object sender, EventArgs e)
        {
            if (btnXaCan_Agg3.IsOn)
            {
                this._so.SendingCommand.SW_XA_WAGG3 = true;
                this.SendData_DB2_NewTread();
            }
            else
            {
                this._so.SendingCommand.SW_XA_WAGG3 = false;
                this.SendData_DB2_NewTread();
            }
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnXaCan_Agg4_ButtonClick(object sender, EventArgs e)
        {
            if (btnXaCan_Agg4.IsOn)
            {
                this._so.SendingCommand.SW_XA_WAGG4 = true;
                this.SendData_DB2_NewTread();
            }
            else
            {
                this._so.SendingCommand.SW_XA_WAGG4 = false;
                this.SendData_DB2_NewTread();
            }
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnXaCan_Agg5_ButtonClick(object sender, EventArgs e)
        {
            if (btnXaCan_Agg5.IsOn)
            {
                this._so.SendingCommand.SW_XA_WAGG5 = true;
                this.SendData_DB2_NewTread();
            }
            else
            {
                this._so.SendingCommand.SW_XA_WAGG5 = false;
                this.SendData_DB2_NewTread();
            }
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnXaCan_Agg6_ButtonClick(object sender, EventArgs e)
        {
            if (btnXaCan_Agg6.IsOn)
            {
                this._so.SendingCommand.SW_XA_WAGG6 = true;
                this.SendData_DB2_NewTread();
            }
            else
            {
                this._so.SendingCommand.SW_XA_WAGG6 = false;
                this.SendData_DB2_NewTread();
            }
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnXaCan_Ce1_ButtonClick(object sender, EventArgs e)
        {
            if (btnXaCan_Ce1.IsOn)
            {
                this._so.SendingCommand.SW_XA_WCEM1 = true;
                this.SendData_DB2_NewTread();
            }
            else
            {
                this._so.SendingCommand.SW_XA_WCEM1 = false;
                this.SendData_DB2_NewTread();
            }
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnXaCan_Ce2_ButtonClick(object sender, EventArgs e)
        {
            if (btnXaCan_Ce2.IsOn)
            {
                this._so.SendingCommand.SW_XA_WCEM2 = true;
                this.SendData_DB2_NewTread();
            }
            else
            {
                this._so.SendingCommand.SW_XA_WCEM2 = false;
                this.SendData_DB2_NewTread();
            }
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnXaCan_Wa1_ButtonClick(object sender, EventArgs e)
        {
            if (btnXaCan_Wa1.IsOn)
            {
                this._so.SendingCommand.SW_XA_WWA1 = true;
                this.SendData_DB2_NewTread();
            }
            else
            {
                this._so.SendingCommand.SW_XA_WWA1 = false;
                this.SendData_DB2_NewTread();
            }
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnXaCan_Wa2_ButtonClick(object sender, EventArgs e)
        {
            if (btnXaCan_Wa2.IsOn)
            {
                this._so.SendingCommand.SW_XA_WWA2 = true;
                this.SendData_DB2_NewTread();
            }
            else
            {
                this._so.SendingCommand.SW_XA_WWA2 = false;
                this.SendData_DB2_NewTread();
            }
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnXaCan_Add1_ButtonClick(object sender, EventArgs e)
        {
            if (btnXaCan_Add1.IsOn)
            {
                this._so.SendingCommand.SW_XA_WADD1 = true;
                this.SendData_DB2_NewTread();
            }
            else
            {
                this._so.SendingCommand.SW_XA_WADD1 = false;
                this.SendData_DB2_NewTread();
            }
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnXaCan_Add2_ButtonClick(object sender, EventArgs e)
        {
            if (btnXaCan_Add2.IsOn)
            {
                this._so.SendingCommand.SW_XA_WADD2 = true;
                this.SendData_DB2_NewTread();
            }
            else
            {
                this._so.SendingCommand.SW_XA_WADD2 = false;
                this.SendData_DB2_NewTread();
            }
            TramTronLogger.WriteInfo(sender.ToString());
        }
       
        private void btnBangTaiXien_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_BAT_TAT_BTX = true;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnBangTaiXien_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_BAT_TAT_BTX = false;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }


        private void btnBangTaiCan_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_BAT_TAT_BTC = true;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnBangTaiCan_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_BAT_TAT_BTC = false;
            this.SendData_DB2_NewTread();
        }
        private void btnXaCan_Funnel_ButtonClick(object sender, EventArgs e)
        {
            if (btnXaCan_Funnel.IsOn)
            {
                this._so.SendingCommand.SW_XA_PHEU_CHO = true;
                this.SendData_DB2_NewTread();
            }
            else
            {
                this._so.SendingCommand.SW_XA_PHEU_CHO = false;
                this.SendData_DB2_NewTread();
            }
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnCapNhatThongTinPhieuTron_ButtonClick(object sender, EventArgs e)
        {

            this.lblDriver.Text = string.Empty;
            this.lblXe.Text = string.Empty;
            this.lblNiemChi.Text = string.Empty;
            SaveNiemChi();
            SaveTaiXe();
            SaveXe();
            TramTronLogger.WriteInfo(sender.ToString());
        }
        private void SaveTaiXe()
        {
            try
            {
                if (!ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).SaveTaiXeTronOnline((int)this.lueDriver.EditValue))
                {
                    return;

                }
                this.lblDriver.Text = lueDriver.Text;

            }
            catch (System.Exception ex)
            {
                TramTronLogger.WriteError(ex);
                TramTromMessageBox.ShowErrorDialog(ex.ToString());
            }
        }
        private void SaveXe()
        {
            try
            {
                if (!ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).SaveXeTronOnline((int)this.lueXe.EditValue))
                {
                    return;

                }
                this.lblXe.Text = lueXe.Text;

            }
            catch (System.Exception ex)
            {
                TramTronLogger.WriteError(ex);
                TramTromMessageBox.ShowErrorDialog(ex.ToString());
            }
        }
        private void SaveNiemChi()
        {
            try
            {
                if (!ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).SaveNiemChiTronOnline(txtNiemChi.Text))
                {
                    return;
                }
                
                this.lblNiemChi.Text = txtNiemChi.Text;
            }
            catch (System.Exception ex)
            {
                TramTronLogger.WriteError(ex);
                TramTromMessageBox.ShowErrorDialog(ex.ToString());
            }
        }
        private void UpdateDoAm(int siloID, Decimal doAm)
        {
            try
            {
                if (!ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).UpdateDoAmSiloOnlineBySiloID(siloID, doAm))
                {
                    return;
                }
            }
            catch (System.Exception ex)
            {
                TramTronLogger.WriteError(ex);
                TramTromMessageBox.ShowErrorDialog(ex.ToString());
            }
        }
        private void UpdateDoHutNuoc(int siloID, Decimal doHutNuoc)
        {
            try
            {
                if (!ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).UpdateDoAmSiloOnlineBySiloID(siloID, doHutNuoc))
                {
                    return;
                }
            }
            catch (System.Exception ex)
            {
                TramTronLogger.WriteError(ex);
                TramTromMessageBox.ShowErrorDialog(ex.ToString());
            }
        }
        private void btnLamMoiThongTinPhieuTron_ButtonClick(object sender, EventArgs e)
        {
            this.lueDriver.EditValue = (object)-1;
            this.lueXe.EditValue = (object)-1;
            TramTronLogger.WriteInfo(sender.ToString());
            //this.txtNiemChi.Text = "";
        }

        private void ucFunnel1_FunnelClick(object sender, EventArgs e)
        {
            TimerPCMngView ctrView = new TimerPCMngView();
            ViewManager.ShowViewDialog(ctrView);
            if (ctrView.GetDialogResult() != DialogResult.OK)
                return;
            this._presenter.ListTimerPara();
            SendData_DB5_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnInNhanh_ButtonClick(object sender, EventArgs e)
        {
            LoadFormInPT();
            TramTronLogger.WriteInfo(sender.ToString());

        }

        private void LoadFormInPT()
        {
            /*if(checkAutoPrint.Checked == true)
            {
                PrinterPheuTron printerPT = new PrinterPheuTron();
                ViewManager.ShowViewDialog(printerPT);
            }
            else
            {
                FormPhieuIn formPT = new FormPhieuIn();
                ViewManager.ShowViewDialog(formPT);
            }*/
            

            FormPhieuIn formPT = new FormPhieuIn();
            ViewManager.ShowViewDialog(formPT);
        }
        private void CreateGroupLogicAG(int sl)
        {
            HideGroupLogicSiloAGG();
            
        }
        private void CreateGroupLogicCE(int sl)
        {
            HideGroupLogicSiloCE();
            
        }
        private void CreateGroupLogicAD(int sl)
        {
            HideGroupLogicSiloAD();
            
        }
        private void HideGroupLogicSiloAGG()
        {
            
            
        }
        private void HideGroupLogicSiloCE()
        {
           

        }
        private void HideGroupLogicSiloAD()
        {
            

        }
        private void CreateSilo_AGG(int sl)
        {
            List<PanelControl> lst_Agg = new List<PanelControl>();
            lst_Agg.Add(pnl_Silo_Agg1);
            lst_Agg.Add(pnl_Silo_Agg2);
            lst_Agg.Add(pnl_Silo_Agg3);
            lst_Agg.Add(pnl_Silo_Agg4);
            lst_Agg.Add(pnl_Silo_Agg5);
            lst_Agg.Add(pnl_Silo_Agg6);
            foreach (PanelControl silo_Agg in lst_Agg)
            {
                silo_Agg.Visible = false;
            }
            ActiveSilo(lst_Agg, sl);
        }
        private void CreateSilo_CE(int sl)
        {
            List<PanelControl> lst_Ce = new List<PanelControl>();
            lst_Ce.Add(pnl_Silo_Ce1);
            lst_Ce.Add(pnl_Silo_Ce2);
            lst_Ce.Add(pnl_Silo_Ce3);
            lst_Ce.Add(pnl_Silo_Ce4);
            lst_Ce.Add(pnl_Silo_Ce5);
            foreach (PanelControl silo_Ce in lst_Ce)
            {
                silo_Ce.Visible = false;
            }
            ActiveSilo(lst_Ce, sl);
        }
        private void CreateSilo_WA(int sl)
        {
            List<PanelControl> lst_Wa = new List<PanelControl>();
            lst_Wa.Add(pnl_Silo_Wa1);
            lst_Wa.Add(pnl_Silo_Wa2);
            foreach (PanelControl silo_Wa in lst_Wa)
            {
                silo_Wa.Visible = false;
            }
            ActiveSilo(lst_Wa, sl);
        }
        private void CreateSilo_ADD(int sl)
        {
            List<PanelControl> lst_Add = new List<PanelControl>();
            lst_Add.Add(pnl_Silo_Add1);
            lst_Add.Add(pnl_Silo_Add2);
            lst_Add.Add(pnl_Silo_Add3);
            lst_Add.Add(pnl_Silo_Add4);
            lst_Add.Add(pnl_Silo_Add5);
            lst_Add.Add(pnl_Silo_Add6);
            foreach (PanelControl silo_Add in lst_Add)
            {
                silo_Add.Visible = false;
            }
            ActiveSilo(lst_Add, sl);
        }
        private void CreateWei_AGG(int sl)
        {
            List<PanelControl> lst_Agg = new List<PanelControl>();
            lst_Agg.Add(pnl_Wei_Agg1);
            lst_Agg.Add(pnl_Wei_Agg2);
            lst_Agg.Add(pnl_Wei_Agg3);
            lst_Agg.Add(pnl_Wei_Agg4);
            lst_Agg.Add(pnl_Wei_Agg5);
            lst_Agg.Add(pnl_Wei_Agg6);
            foreach (PanelControl silo_Agg in lst_Agg)
            {
                silo_Agg.Visible = false;
            }
            ActiveSilo(lst_Agg, sl);
        }
        private void CreateWei_CE(int sl)
        {
            List<PanelControl> lst_Ce = new List<PanelControl>();
            lst_Ce.Add(pnl_Wei_Ce1);
            lst_Ce.Add(pnl_Wei_Ce2);

            foreach (PanelControl silo_Ce in lst_Ce)
            {
                silo_Ce.Visible = false;
            }
            ActiveSilo(lst_Ce, sl);
        }
        private void CreateWei_WA(int sl)
        {
            List<PanelControl> lst_Wa = new List<PanelControl>();
            lst_Wa.Add(pnl_Wei_Wa1);
            lst_Wa.Add(pnl_Wei_Wa2);

            foreach (PanelControl silo_Wa in lst_Wa)
            {
                silo_Wa.Visible = false;
            }
            ActiveSilo(lst_Wa, sl);
        }
        private void CreateWei_ADD(int sl)
        {
            List<PanelControl> lst_Add = new List<PanelControl>();
            lst_Add.Add(pnl_Wei_Add1);
            lst_Add.Add(pnl_Wei_Add2);

            foreach (PanelControl silo_Add in lst_Add)
            {
                silo_Add.Visible = false;
            }
            ActiveSilo(lst_Add, sl);
        }

        private void ActiveSilo(List<PanelControl> lst_Silo, int sl)
        {
            LimitedList<PanelControl> limitedList = new LimitedList<PanelControl>(sl);
            for (int i = 0; i < sl; i++)
            {
                limitedList.Add(lst_Silo[i]);
            }
            foreach (PanelControl sl_Silo in limitedList)
            {
                sl_Silo.Visible = true;
            }
        }
        private void GetSiloNotActive()
        {
            List<PanelControl> lst_Agg = new List<PanelControl>();
            lst_Agg.Add(pnl_Wei_Agg1);
            lst_Agg.Add(pnl_Wei_Agg2);
            lst_Agg.Add(pnl_Wei_Agg3);
            lst_Agg.Add(pnl_Wei_Agg4);
            lst_Agg.Add(pnl_Wei_Agg5);
            lst_Agg.Add(pnl_Wei_Agg6);
            for(int i = 0;i< lst_Agg.Count; i++)
            {
                if (!lst_Agg[i].Visible)
                {
                    switch (i)
                    {
                        case 0:
                            siloAgg1.SiloOnline.KLCaiDat = 0;
                            siloAgg1.SiloOnline.KLCanCan = 0;
                            break;
                        case 1:
                            siloAgg2.SiloOnline.KLCaiDat = 0;
                            siloAgg2.SiloOnline.KLCanCan = 0;
                            break;
                        case 2:
                            siloAgg3.SiloOnline.KLCaiDat = 0;
                            siloAgg3.SiloOnline.KLCanCan = 0;
                            break;
                        case 3:
                            siloAgg4.SiloOnline.KLCaiDat = 0;
                            siloAgg4.SiloOnline.KLCanCan = 0;
                            break;
                        case 4:
                            siloAgg5.SiloOnline.KLCaiDat = 0;
                            siloAgg5.SiloOnline.KLCanCan = 0;
                            break;
                        case 5:
                            siloAgg6.SiloOnline.KLCaiDat = 0;
                            siloAgg6.SiloOnline.KLCanCan = 0;
                            break;
                    }
                }
            }
            List<PanelControl> lst_Ce = new List<PanelControl>();
            lst_Ce.Add(pnl_Silo_Ce1);
            lst_Ce.Add(pnl_Silo_Ce2);
            lst_Ce.Add(pnl_Silo_Ce3);
            lst_Ce.Add(pnl_Silo_Ce4);
            lst_Ce.Add(pnl_Silo_Ce5);
            for (int i = 0; i < lst_Ce.Count; i++)
            {
                if (!lst_Ce[i].Visible)
                {
                    switch (i)
                    {
                        case 0:
                            siloCe1.SiloOnline.KLCaiDat = 0;
                            siloCe1.SiloOnline.KLCanCan = 0;
                            break;
                        case 1:
                            siloCe2.SiloOnline.KLCaiDat = 0;
                            siloCe2.SiloOnline.KLCanCan = 0;
                            break;
                        case 2:
                            siloCe3.SiloOnline.KLCaiDat = 0;
                            siloCe3.SiloOnline.KLCanCan = 0;
                            break;
                        case 3:
                            siloCe4.SiloOnline.KLCaiDat = 0;
                            siloCe4.SiloOnline.KLCanCan = 0;
                            break;
                        case 4:
                            siloCe5.SiloOnline.KLCaiDat = 0;
                            siloCe5.SiloOnline.KLCanCan = 0;
                            break;
                        
                    }
                }
            }

            List<PanelControl> lst_Wa = new List<PanelControl>();
            lst_Wa.Add(pnl_Silo_Wa1);
            lst_Wa.Add(pnl_Silo_Wa2);
            for (int i = 0; i < lst_Wa.Count; i++)
            {
                if (!lst_Wa[i].Visible)
                {
                    switch (i)
                    {
                        case 0:
                            siloWa1.SiloOnline.KLCaiDat = 0;
                            siloWa1.SiloOnline.KLCanCan = 0;
                            break;
                        case 1:
                            siloWa2.SiloOnline.KLCaiDat = 0;
                            siloWa2.SiloOnline.KLCanCan = 0;
                            break;
                    }
                }
            }
            List<PanelControl> lst_Add = new List<PanelControl>();
            lst_Add.Add(pnl_Silo_Add1);
            lst_Add.Add(pnl_Silo_Add2);
            lst_Add.Add(pnl_Silo_Add3);
            lst_Add.Add(pnl_Silo_Add4);
            lst_Add.Add(pnl_Silo_Add5);
            lst_Add.Add(pnl_Silo_Add6);
            for (int i = 0; i < lst_Add.Count; i++)
            {
                if (!lst_Add[i].Visible)
                {
                    switch (i)
                    {
                        case 0:
                            siloAdd1.SiloOnline.KLCaiDat = 0;
                            siloAdd1.SiloOnline.KLCanCan = 0;
                            break;
                        case 1:
                            siloAdd2.SiloOnline.KLCaiDat = 0;
                            siloAdd2.SiloOnline.KLCanCan = 0;
                            break;
                        case 2:
                            siloAdd3.SiloOnline.KLCaiDat = 0;
                            siloAdd3.SiloOnline.KLCanCan = 0;
                            break;
                        case 3:
                            siloAdd4.SiloOnline.KLCaiDat = 0;
                            siloAdd4.SiloOnline.KLCanCan = 0;
                            break;
                        case 4:
                            siloAdd5.SiloOnline.KLCaiDat = 0;
                            siloAdd5.SiloOnline.KLCanCan = 0;
                            break;
                        case 5:
                            siloAdd6.SiloOnline.KLCaiDat = 0;
                            siloAdd6.SiloOnline.KLCanCan = 0;
                            break;
                    }
                }
            }
        }
        private void SaveData()
        {
            try
            {
                if (this._idSavePLC == 1)
                {
                    if (this._idSave == 0 && this._idSavePLC == 1)
                    {
                        this._idSave = -1;
                        lblAgg1.Text = this._ro.RE_PV_AGG1.ToString();
                        lblAgg2.Text = this._ro.RE_PV_AGG2.ToString();
                        lblAgg3.Text = this._ro.RE_PV_AGG3.ToString();
                        lblCe1.Text = this._ro.RE_PV_CE1.ToString();
                        lblWa1.Text = this._ro.RE_PV_WA1.ToString();
                        int numm0 = 0;
                        if (_isSimulation)  //if (lblSim.Visible)
                            numm0 = 1;
                        this.SaveMTCT("WeiAgg1", some, this.ucHeThongAuto1.IsAuto, numm0, 0);
                        this.SaveMTCT("WeiAgg2", some, this.ucHeThongAuto1.IsAuto, numm0, 0);
                        this.SaveMTCT("WeiAgg3", some, this.ucHeThongAuto1.IsAuto, numm0, 0);
                        this.SaveMTCT("WeiAgg4", some, this.ucHeThongAuto1.IsAuto, numm0, 0);
                        this.SaveMTCT("WeiAgg5", some, this.ucHeThongAuto1.IsAuto, numm0, 0);
                        this.SaveMTCT("WeiAgg6", some, this.ucHeThongAuto1.IsAuto, numm0, 0);
                        this.SaveMTCT("WeiCe1", some, this.ucHeThongAuto1.IsAuto, numm0, 0);
                        this.SaveMTCT("WeiCe2", some, this.ucHeThongAuto1.IsAuto, numm0, 0);
                        this.SaveMTCT("WeiCe3", some, this.ucHeThongAuto1.IsAuto, numm0, 0);
                        this.SaveMTCT("WeiCe4", some, this.ucHeThongAuto1.IsAuto, numm0, 0);
                        this.SaveMTCT("WeiCe5", some, this.ucHeThongAuto1.IsAuto, numm0, 0);
                        this.SaveMTCT("WeiWa1", some, this.ucHeThongAuto1.IsAuto, numm0, 0);
                        this.SaveMTCT("WeiWa2", some, this.ucHeThongAuto1.IsAuto, numm0, 0);
                        this.SaveMTCT("WeiAdd1", some, this.ucHeThongAuto1.IsAuto, numm0, 0);
                        this.SaveMTCT("WeiAdd2", some, this.ucHeThongAuto1.IsAuto, numm0, 0);
                        this.SaveMTCT("WeiAdd3", some, this.ucHeThongAuto1.IsAuto, numm0, 0);
                        this.SaveMTCT("WeiAdd4", some, this.ucHeThongAuto1.IsAuto, numm0, 0);
                        this.SaveMTCT("WeiAdd5", some, this.ucHeThongAuto1.IsAuto, numm0, 0);
                        this.SaveMTCT("WeiAdd6", some, this.ucHeThongAuto1.IsAuto, numm0, 0);
                        if(this._selectedPT_Run != null)
                        {
                            UpdateKLDaGiaoDLT_FocusMeTron();
                        }
                        some++;

                        /*if(((int)_sp.SoMeTron - (int)_ro.SMC_MIXER) == 1) // nếu trong quá trình chạy coá tăng số Mẻ thì sẽ cập nhật lại cho đúng
                        {
                            if (this._selectedHD_Run.DLT_KLBuTruMeCuoi != 0)
                            {
                                //Send_Data_DB_4_To_PLC_Update();
                                //TramTromMessageBox.ShowYesNoDialog("Xác nhận trộn DLT bù mẻ cuối.");
                            }
                        }*/

                        if(some > this._sp.SoMeTron)
                        {
                            DoNextNiemChi();
                            UpdateStateFinishPhieuTron();
                            
                            UpdateTongPhieuHopDong();
                            this.ChangeStatusSelectedDuLieuTron(4, null);
                            
                            if (checkAutoPrint.Checked)
                            {
                                ShowMessage("Đang in phiếu trộn", Enums.MsgType.Info);
                            }
                            if (this._selectedPT_Run != null)
                            {
                                //UpdateKLDaGiaoDLT(); //Cập nhật lại KLĐã giao, KL Cò lại, Tính Luỹ Kế
                            }
                            
                        }

                        if (!checkEdit3.Checked)
                            isTesst = false;
                        if (isTesst)
                        {
                            soMeCanTronTest--;
                            lblTest.Text = "Số mẻ còn: " + soMeCanTronTest; 
                            if(soMeCanTronTest == 0)
                            {
                                randomNumberTest++;
                                lblTest.Text = "DLT: " + randomNumberTest;
                                if(randomNumberTest >= this._blstDuLieuTron.Count)
                                    randomNumberTest = 1;
                                AutoTest(randomNumberTest);
                            }
                            else
                            {
                                Thread.Sleep(2000);
                                this._so.SendingCommand.NN_MCN = true;
                                labelControl1.Visible = true;
                                this.SendData_DB2_NewTread();
                                Thread.Sleep(500);
                                this._so.SendingCommand.NN_MCN = false;
                                labelControl1.Visible = false;
                                this.SendData_DB2_NewTread();
                                lblTest.Text = "Mẻ mới";
                            }
                        }
                        //test Auto
                    }
                }
            }
            catch (System.Exception ex)
            {
                TramTronLogger.WriteError(ex);
                TramTromMessageBox.ShowErrorDialog(ex.ToString());
            }
        }
        private void UpdateStateFinishPhieuTron()
        {
            try
            {
                if (!ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ResolveUnfinishPhieuTron())
                    return;
            }
            catch (System.Exception ex)
            {
                TramTronLogger.WriteError(ex);
                TramTromMessageBox.ShowMessageDialog(ex.ToString());
            }
        }

        private void UpdateInfoDataPhieuTron(ObjPhieuTron objPhieuTron, decimal klThuc)
        {
            try
            {
                if (!ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).UpdatePhieuTron(objPhieuTron, klThuc))
                    return;
            }
            catch (System.Exception ex)
            {
                TramTronLogger.WriteError(ex);
                TramTromMessageBox.ShowMessageDialog(ex.ToString());
            }
        }
        private void UpdateTongPhieuHopDong()
        {
            try
            {
                if (this._selectedHD_Run != null && this._selectedHD_Run.TongPhieu != null)
                {
                    this._selectedHD_Run.TongPhieu = this._selectedHD_Run.TongPhieu + 1;
                    this._selectedHD_Run = this._presenter.SaveHopDong(this._selectedHD_Run);
                }
               
                this.grvHopDong.RefreshData();
            }
            catch (System.Exception ex)
            {
                TramTronLogger.WriteError(ex);
                TramTromMessageBox.ShowMessageDialog(ex.ToString());
            }
        }
        private void UpdateKLConLaiHopDong()
        {
            try
            {
                if (this._selectedHD_Run != null && this._selectedHD_Run.TongPhieu != null)
                {
                    this._selectedHD_Run.TongPhieu = this._selectedHD_Run.TongPhieu + 1;
                }
                this._selectedHD_Run = this._presenter.SaveHopDong(this._selectedHD_Run);

            }
            catch (System.Exception ex)
            {
                TramTronLogger.WriteError(ex);
                TramTromMessageBox.ShowMessageDialog(ex.ToString());
            }
        }
        private void AutoPrint(bool isPrint)
        {

        }

        private void SaveMTCT(
         string maCan,
         int sttMe,
         bool isManual,
         int trangThaiAutoManual,
         int plcSaveId)
        {
            foreach (ObjWeiSiloSaving objWeiSiloSaving in this._blstWeiSiloSaving.Where<ObjWeiSiloSaving>((System.Func<ObjWeiSiloSaving, bool>)(o => o.MaCan == maCan)).ToList<ObjWeiSiloSaving>())
            {
                double valueBat = this.GetValueBat(objWeiSiloSaving.MaSilo);
                double valueBatAuto = this.GetValueBatAuto(objWeiSiloSaving.MaSilo);
                double valueBatMan = this.GetValueBatMan(objWeiSiloSaving.MaSilo);
                this.BuildNewCurMeTronChiTiet(objWeiSiloSaving.MaSilo, sttMe, isManual, trangThaiAutoManual, 0, valueBat, valueBatAuto, valueBatMan, plcSaveId);
            }
        }
        private bool BuildNewCurMeTronChiTiet(
          string strMaSilo,
          int num_bat_can,
          bool isManual,
          int trangThaiAutoMan,
          int phieuTronID,
          double valueBat,
          double valueBatAuto,
          double valueBatMan,
          int plcSaveId)
        {
            try
            {
                ObjMACSilo macSilo = this.GetMacSilo(strMaSilo, this._blstMACSilo_Run);
                ObjSilo silo = this.GetSilo(strMaSilo, this._blstSilo);
                SiloOnline siloOnline = this.GetSiloOnline(strMaSilo);
                this._presenter.BuildNewMeTronChiTiet(strMaSilo, macSilo, silo, siloOnline, num_bat_can, isManual, trangThaiAutoMan, phieuTronID, valueBat, valueBatAuto, valueBatMan, plcSaveId);
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }
        public ObjMACSilo GetMacSilo(string strMaSilo, BindingList<ObjMACSilo> blstMACSilo)
        {
            if (blstMACSilo != null)
            {
                foreach (ObjMACSilo macSilo in (Collection<ObjMACSilo>)blstMACSilo)
                {
                    if (macSilo.NPSiloMaSilo == strMaSilo)
                        return macSilo;
                }
            }
            return (ObjMACSilo)null;
        }

        public ObjSilo GetSilo(int siloID, BindingList<ObjSilo> blstSilo)
        {
            foreach (ObjSilo silo in (Collection<ObjSilo>)blstSilo)
            {
                if (silo.SiloID == siloID)
                    return silo;
            }
            return (ObjSilo)null;
        }
        public ObjSilo GetSilo(string maSilo, BindingList<ObjSilo> blstSilo)
        {
            foreach (ObjSilo silo in (Collection<ObjSilo>)blstSilo)
            {
                if (silo.MaSilo == maSilo)
                    return silo;
            }
            return (ObjSilo)null;
        }
        public SiloOnline GetSiloOnline(string strMaSilo)
        {
            SiloOnline siloOnline = (SiloOnline)null;
            switch (strMaSilo)
            {
                case "Add1":
                    siloOnline = this.siloAdd1.SiloOnline;
                    break;
                case "Add2":
                    siloOnline = this.siloAdd2.SiloOnline;
                    break;
                case "Add3":
                    siloOnline = this.siloAdd3.SiloOnline;
                    break;
                case "Add4":
                    siloOnline = this.siloAdd4.SiloOnline;
                    break;
                case "Add5":
                    siloOnline = this.siloAdd5.SiloOnline;
                    break;
                case "Add6":
                    siloOnline = this.siloAdd6.SiloOnline;
                    break;
                case "Agg1":
                    siloOnline = this.siloAgg1.SiloOnline;
                    break;
                case "Agg2":
                    siloOnline = this.siloAgg2.SiloOnline;
                    break;
                case "Agg3":
                    siloOnline = this.siloAgg3.SiloOnline;
                    break;
                case "Agg4":
                    siloOnline = this.siloAgg4.SiloOnline;
                    break;
                case "Agg5":
                    siloOnline = this.siloAgg5.SiloOnline;
                    break;
                case "Agg6":
                    siloOnline = this.siloAgg6.SiloOnline;
                    break;
                case "Ce1":
                    siloOnline = this.siloCe1.SiloOnline;
                    break;
                case "Ce2":
                    siloOnline = this.siloCe2.SiloOnline;
                    break;
                case "Ce3":
                    siloOnline = this.siloCe3.SiloOnline;
                    break;
                case "Ce4":
                    siloOnline = this.siloCe4.SiloOnline;
                    break;
                case "Ce5":
                    siloOnline = this.siloCe4.SiloOnline;
                    break;
                case "Wa1":
                    siloOnline = this.siloWa1.SiloOnline;
                    break;
                case "Wa2":
                    siloOnline = this.siloWa2.SiloOnline;
                    break;
            }
            return siloOnline;
        }
        private double GetValueBat(string maSilo)
        {
            switch (maSilo)
            {
                case "Add1":
                    return this._ro.RE_PV_PG1;
                case "Add2":
                    return this._ro.RE_PV_PG2;
                case "Add3":
                    return this._ro.RE_PV_PG3;
                case "Add4":
                    return this._ro.RE_PV_PG4;
                case "Add5":
                    return this._ro.RE_PV_PG5;
                case "Add6":
                    return this._ro.RE_PV_PG6;
                case "Agg1":
                    return (int)this._ro.RE_PV_AGG1;
                case "Agg2":
                    return (int)this._ro.RE_PV_AGG2;
                case "Agg3":
                    return (int)this._ro.RE_PV_AGG3;
                case "Agg4":
                    return (int)this._ro.RE_PV_AGG4;
                case "Agg5":
                    return (int)this._ro.RE_PV_AGG5;
                case "Agg6":
                    return (int)this._ro.RE_PV_AGG6;
                case "Ce1":
                    return (int)this._ro.RE_PV_CE1;
                case "Ce2":
                    return (int)this._ro.RE_PV_CE2;
                case "Ce3":
                    return (int)this._ro.RE_PV_CE3;
                case "Ce4":
                    return (int)this._ro.RE_PV_CE4;
                case "Ce5":
                    return (int)this._ro.RE_PV_CE5;
                case "Wa1":
                    return (int)this._ro.RE_PV_WA1;
                case "Wa2":
                    return (int)this._ro.RE_PV_WA2;
                default:
                    return 0;
            }
        }

        private double GetValueBatAuto(string maSilo)
        {
            switch (maSilo)
            {
                case "Add1":
                    return this._ro.RE_PV_PG1;
                case "Add2":
                    return this._ro.RE_PV_PG2;
                case "Add3":
                    return this._ro.RE_PV_PG3;
                case "Add4":
                    return this._ro.RE_PV_PG4;
                case "Add5":
                    return this._ro.RE_PV_PG5;
                case "Add6":
                    return this._ro.RE_PV_PG6;
                case "Agg1":
                    return (int)this._ro.RE_PV_AGG1;
                case "Agg2":
                    return (int)this._ro.RE_PV_AGG2;
                case "Agg3":
                    return (int)this._ro.RE_PV_AGG3;
                case "Agg4":
                    return (int)this._ro.RE_PV_AGG4;
                case "Agg5":
                    return (int)this._ro.RE_PV_AGG5;
                case "Agg6":
                    return (int)this._ro.RE_PV_AGG6;
                case "Ce1":
                    return (int)this._ro.RE_PV_CE1;
                case "Ce2":
                    return (int)this._ro.RE_PV_CE2;
                case "Ce3":
                    return (int)this._ro.RE_PV_CE3;
                case "Ce4":
                    return (int)this._ro.RE_PV_CE4;
                case "Ce5":
                    return (int)this._ro.RE_PV_CE5;
                case "Wa1":
                    return (int)this._ro.RE_PV_WA1;
                case "Wa2":
                    return (int)this._ro.RE_PV_WA2;
                default:
                    return 0;
            }
        }

        private double GetValueBatMan(string maSilo)
        {
            switch (maSilo)
            {
                case "Add1":
                    return this._ro.RE_PVM_PG1;
                case "Add2":
                    return this._ro.RE_PVM_PG2;
                case "Add3":
                    return this._ro.RE_PVM_PG3;
                case "Add4":
                    return this._ro.RE_PVM_PG4;
                case "Add5":
                    return this._ro.RE_PVM_PG5;
                case "Add6":
                    return this._ro.RE_PVM_PG6;
                case "Agg1":
                    return (int)this._ro.RE_PVM_AGG1;
                case "Agg2":
                    return (int)this._ro.RE_PVM_AGG2;
                case "Agg3":
                    return (int)this._ro.RE_PVM_AGG3;
                case "Agg4":
                    return (int)this._ro.RE_PVM_AGG4;
                case "Agg5":
                    return (int)this._ro.RE_PVM_AGG5;
                case "Agg6":
                    return (int)this._ro.RE_PVM_AGG6;
                case "Ce1":
                    return (int)this._ro.RE_PVM_CE1;
                case "Ce2":
                    return (int)this._ro.RE_PVM_CE2;
                case "Ce3":
                    return (int)this._ro.RE_PVM_CE3;
                case "Ce4":
                    return (int)this._ro.RE_PVM_CE4;
                case "Ce5":
                    return (int)this._ro.RE_PVM_CE5;
                case "Wa1":
                    return (int)this._ro.RE_PVM_WA1;
                case "Wa2":
                    return (int)this._ro.RE_PVM_WA2;
                default:
                    return 0;
            }
        }

        public decimal GetDoAmSiloOnline(string strMaSilo)
        {
            decimal siloOnline = 0;
            switch (strMaSilo)
            {
                case "Agg1":
                    siloOnline = this.siloAgg1.SiloOnline.DoAm;
                    break;
                case "Agg2":
                    siloOnline = this.siloAgg2.SiloOnline.DoAm;
                    break;
                case "Agg3":
                    siloOnline = this.siloAgg3.SiloOnline.DoAm;
                    break;
                case "Agg4":
                    siloOnline = this.siloAgg4.SiloOnline.DoAm;
                    break;
                case "Agg5":
                    siloOnline = this.siloAgg5.SiloOnline.DoAm;
                    break;
                case "Agg6":
                    siloOnline = this.siloAgg6.SiloOnline.DoAm;
                    break;
            }
            return siloOnline;
        }

        private void InitRunning(bool checkIsRunning = true)
        {
            if (!this.CheckConnection())
            {
                return;
            }
            if (this._TronOnlineAttributes.IsRunning)
            {
                if (checkIsRunning)
                {
                    string systemRunningCannotF = GlobalValues.Messages.SystemRunningCannotF1;
                    return;
                }
            }
            else if (this.CheckSLMeDaTron_GreaterZero())
            {
                string soMeDaTronIsOver = GlobalValues.Messages.SoMeDaTronIsOver;
                TramTromMessageBox.ShowWarningDialog(soMeDaTronIsOver);
                return;
            }
            /*if (!this.ucHeThongAuto1.IsAuto)
            {
                return;
            }*/
            /*if (!this.CheckKetNoiLogic())
            {
                return;
            }*/
            bool isManual = true;
            if (_isSimulation) //if (lblSim.Visible)
                isManual = false;
            if (this.grvHopDong.RowCount == 0 || this.grvHopDong.FocusedRowHandle < 0)
            {
                return;
            }
            ObjDuLieuTron objDuLieuTron = this.grvHopDong.GetRow(this.grvHopDong.FocusedRowHandle) as ObjDuLieuTron;
            int hopDongID = objDuLieuTron.HopDongID.Value;
            if (objDuLieuTron == null || objDuLieuTron.HopDongID == null)
            {
                TramTromMessageBox.ShowWarningDialog(GlobalValues.Messages.EmptyDataCannotF1);
                return;
            }
            /*if (this.CheckDLTChanged(objDuLieuTron))
            {
                return;
            }*/
            string str = GlobalValues.Messages.RunningInfos;
            if (TramTromMessageBox.ShowYesNoDialog(string.Format(str, objDuLieuTron.TenHopDong, (int)objDuLieuTron.DLT_KLDuTinh)) == DialogResult.No)
            {
                return;
            }
            //UpdateRanking
            UpdateRankingDLT(objDuLieuTron);

            this._selectedHD_Run = this._presenter.GetHopDongByKey(objDuLieuTron.HopDongID.Value);
            if (this._selectedHD_Run == null)
            {
                return;
            }
            this._selectedPT_Run = this._presenter.CreateAndSaveNewPhieuTron(this._selectedHD_Run, isManual);
            this.some = 1;
            this.lblMaPhieuTron.Text = this._selectedPT_Run.MaPhieuTron;
            //this.lblDriver.Text = string.Empty;
            //this.lblXe.Text = string.Empty;
            //this.lblNiemChi.Text = string.Empty;
            this.lblNguoiTron.Text = GlobalValues.DisplayUser;
            this._LuyKe_InNhanh = (decimal)this._selectedHD_Run.KLDaGiao + (decimal)this._selectedPT_Run.KLDuTinh;
            if (_selectedPT_Run == null)
            {
                return;
            }
            this.lblSoPhieuTron.Text = _selectedPT_Run.NoPhieu.ToString();
            GetNiemChi();
            this.ChangeStatusSelectedDuLieuTron(1, null);
            this.GetSiloNotActive();
            this.BuildSetPoint(this._selectedHD_Run, true);

            //Thread thread = new Thread(new ThreadStart(this.SendSetPoint_isF1));
            //thread.Start();
            //this._so.SoMeDis = (int)this._sp.SO_ME_TRON;

            if (isTesst)
            {
                randomNumberTest = this.grvHopDong.FocusedRowHandle + 1;
                soMeCanTronTest = (int)this.slMeDaCanNoiTron.SoLuongMeCanTron;

            }
            //this.SendData_NewTread();
            this._presenter.ListTimerPara();

            this._so.SendingCommand.F1_Run = true;
            this.SendData_DB2_NewTread();
            Thread.Sleep(100);
            this._so.SendingCommand.F1_Run = false;
            this.SendData_DB2_NewTread();

            Send_Data_DB_3_To_PLC();
            Send_Data_DB_4_To_PLC();
            Send_Data_DB_5_To_PLC();
            // Send_Data_DB_2_To_PLC();
            if (checkAutoPrint.Checked)
            {
                AutoPrint_NewTread();
            }

        }

        private void AutoPrint_NewTread() //PRINTER
        {
            Thread thread = new Thread(new ThreadStart(this.LoadParam));
            thread.Start();
        }
        // Get NiemChi

        private void UpdateRankingDLT(ObjDuLieuTron dulieutron)
        {
            int j = 1;
            this._blstDuLieuTron = new BindingList<ObjDuLieuTron>(this._blstDuLieuTron.OrderBy(d => d.LnNo).ToList());
            
            for (int i = 0; i < this._blstDuLieuTron.Count; i++)
            {
                if (this._blstDuLieuTron[i].DuLieuTronID != dulieutron.DuLieuTronID)
                {
                    j++;
                    this._blstDuLieuTron[i].DLT_KLDuTinhCuaTungMe_NoiB = j;
                }
                else
                {
                    j = i + 1;
                    this._blstDuLieuTron[i].DLT_KLDuTinhCuaTungMe_NoiB = 1;
                }
            }
            this._presenter.UpdateDuLieuTron(dulieutron);
            RefreshRankingDLT();
        }
        private void RefreshRankingDLT()
        {
            this._blstDuLieuTron = new BindingList<ObjDuLieuTron>(this._blstDuLieuTron.OrderBy(d => d.DLT_KLDuTinhCuaTungMe_NoiB).ToList());
            
            for (int i = 0; i < this._blstDuLieuTron.Count; i++)
            {
                this._blstDuLieuTron[i].LnNo = i + 1;
                
            }
            this._presenter.SaveDuLieuTron(this._blstDuLieuTron);
            this._presenter.ListDuLieuTron(); // Xây dựng 1 luồng xử lý riêng để tránh việc
            this.grvHopDong.FocusedRowHandle = 0;

        }
        private void UpdateKLDaGiaoDLT()
        {
            /*if (this.grvHopDong.FocusedRowHandle < 0)
            {
                return;
            }*/

            ObjDuLieuTron objDuLieuTron = this.grvHopDong.GetRow(0) as ObjDuLieuTron;
            
            if (objDuLieuTron.KLDaGiao != null)
            {
                objDuLieuTron.KLDaGiao = objDuLieuTron.KLDaGiao + this._selectedPT_Run.KLDuTinh;
            }
            objDuLieuTron = this._presenter.UpdateDuLieuTron(objDuLieuTron);
            UpdateKLDaGiaoHD(objDuLieuTron);
            ChangeStatusSelectedDuLieuTron(4, 4);
            this.grvHopDong.RefreshRow(this.grvHopDong.FocusedRowHandle);

        }
        private void UpdateKLDaGiaoDLT_FocusMeTron()
        {
            ObjDuLieuTron objDuLieuTron = this.grvHopDong.GetRow(0) as ObjDuLieuTron;

            if (objDuLieuTron.KLDaGiao != null)
            {
                objDuLieuTron.KLDaGiao = objDuLieuTron.KLDaGiao + this._selectedPT_Run.KLDuTinhCuaTungMe;
                this.lblLuyKe.Text = objDuLieuTron.KLDaGiao.ToString();
                UpdateInfoDataPhieuTron(this._selectedPT_Run, (decimal)objDuLieuTron.KLDaGiao);
            }
            objDuLieuTron = this._presenter.UpdateDuLieuTron(objDuLieuTron);
            UpdateKLDaGiaoHD_FocusMeTron(objDuLieuTron);
            this.grvHopDong.RefreshRow(this.grvHopDong.FocusedRowHandle);
            
        }
        private void UpdateKLDaGiaoHD(ObjDuLieuTron objDuLieuTron)
        {
           /* if (this.grvHopDong.FocusedRowHandle < 0)
            {
                return;
            }*/
            //ObjDuLieuTron objDuLieuTron = this.grvHopDong.GetRow(0) as ObjDuLieuTron;

           /* if (objDuLieuTron.KLDaGiao != null)
            {
                objDuLieuTron.KLDaGiao = objDuLieuTron.KLDaGiao + this._selectedPT_Run.KLDuTinh;
            }*/
            if (this._selectedHD_Run != null && this._selectedHD_Run.KLDaGiao != null)
            {
                this._selectedHD_Run.KLDaGiao = this._selectedHD_Run.KLDaGiao + this._selectedPT_Run.KLDuTinh;
            }
            this._selectedHD_Run = this._presenter.SaveHopDong(this._selectedHD_Run, objDuLieuTron);
        }
        private void UpdateKLDaGiaoHD_FocusMeTron(ObjDuLieuTron objDuLieuTron)
        {
            if (this._selectedHD_Run != null && this._selectedHD_Run.KLDaGiao != null)
            {
                this._selectedHD_Run.KLDaGiao = this._selectedHD_Run.KLDaGiao + this._selectedPT_Run.KLDuTinhCuaTungMe;
                this._selectedHD_Run.KLConLai = this._selectedHD_Run.KLDatHang - this._selectedHD_Run.KLDaGiao;

            }
            this._selectedHD_Run = this._presenter.SaveHopDong(this._selectedHD_Run, objDuLieuTron);
            this.grvHopDong.RefreshRow(this.grvHopDong.FocusedRowHandle);
        }
        private void UpdateDLT_KLDuTinh_TangMe() // Cap nhat khoi luong can tron, chú ý không thể vượt qua thể tích chứa củ xe trộn
        {
            ObjDuLieuTron objDuLieuTron = this.grvHopDong.GetRow(0) as ObjDuLieuTron;
            objDuLieuTron.DLT_KLDuTinh = this._selectedHD_Run.DLT_KLDuTinh + this._selectedHD_Run.DLT_KLDuTinhCuaTungMe;
            objDuLieuTron.DLT_SLMeDuTinh = this._selectedHD_Run.DLT_SLMeDuTinh + 1;

            objDuLieuTron = this._presenter.UpdateDuLieuTron(objDuLieuTron);

            if (this._selectedHD_Run != null)
            {
                this._selectedHD_Run.DLT_KLDuTinh = this._selectedHD_Run.DLT_KLDuTinh + this._selectedPT_Run.KLDuTinhCuaTungMe;
                this._selectedHD_Run.DLT_SLMeDuTinh = this._selectedHD_Run.DLT_SLMeDuTinh + 1;
            }
            this._selectedHD_Run = this._presenter.SaveHopDong(this._selectedHD_Run, objDuLieuTron);

            this.grvHopDong.RefreshRow(0);
            this.lblKhoiLuong.Text = this._selectedHD_Run.DLT_KLDuTinh.ToString();

        }
        private void UpdateDLT_KLDuTinh_GiamMe() // Cap nhat khoi luong can tron, chú ý không thể vượt qua thể tích chứa củ xe trộn
        {
            ObjDuLieuTron objDuLieuTron = this.grvHopDong.GetRow(0) as ObjDuLieuTron;
            objDuLieuTron.DLT_KLDuTinh = this._selectedHD_Run.DLT_KLDuTinh - this._selectedHD_Run.DLT_KLDuTinhCuaTungMe;
            objDuLieuTron.DLT_SLMeDuTinh = this._selectedHD_Run.DLT_SLMeDuTinh - 1;

            objDuLieuTron = this._presenter.UpdateDuLieuTron(objDuLieuTron);

            if (this._selectedHD_Run != null)
            {
                this._selectedHD_Run.DLT_KLDuTinh = this._selectedHD_Run.DLT_KLDuTinh - this._selectedPT_Run.KLDuTinhCuaTungMe;
                this._selectedHD_Run.DLT_SLMeDuTinh = this._selectedHD_Run.DLT_SLMeDuTinh - 1;
            }
            this._selectedHD_Run = this._presenter.SaveHopDong(this._selectedHD_Run, objDuLieuTron);

            this.grvHopDong.RefreshRow(0);
            this.lblKhoiLuong.Text = this._selectedHD_Run.DLT_KLDuTinh.ToString();

        }
        private bool CheckSLMeDaTron_GreaterZero()
        {
            return this.slMeDaCanAdd1.SoLuongMeDaTron > 0m ||
                this.slMeDaCanAdd2.SoLuongMeDaTron > 0m ||
                this.slMeDaCanWa1.SoLuongMeDaTron > 0m ||
                this.slMeDaCanWa2.SoLuongMeDaTron > 0m || 
                this.slMeDaCanCe1.SoLuongMeDaTron > 0m || 
                this.slMeDaCanCe2.SoLuongMeDaTron > 0m ||
                this.slMeDaCanAgg1.SoLuongMeDaTron > 0m ||
                this.slMeDaCanAgg2.SoLuongMeDaTron > 0m ||
                this.slMeDaCanAgg3.SoLuongMeDaTron > 0m ||
                this.slMeDaCanAgg4.SoLuongMeDaTron > 0m ||
                this.slMeDaCanAgg5.SoLuongMeDaTron > 0m ||
                this.slMeDaCanAgg6.SoLuongMeDaTron > 0m;
        }
        private void ChangeStatusSelectedDuLieuTron(int status, int? lastStatus = null)
        {
            /*if (this.grvHopDong.FocusedRowHandle < 0)
            {
                return;
            }*/
            //ObjDuLieuTron objDuLieuTron = this.grvHopDong.GetRow(this.grvHopDong.FocusedRowHandle) as ObjDuLieuTron;
            ObjDuLieuTron objDuLieuTron = this.grvHopDong.GetRow(0) as ObjDuLieuTron;
            objDuLieuTron.Status = new int?(status);
            if (lastStatus != null)
            {
                objDuLieuTron.LastStatus = lastStatus;
            }
            objDuLieuTron = this._presenter.UpdateDuLieuTron(objDuLieuTron);
            this.grvHopDong.RefreshRow(0);
        }

        private void simpleButton1_Click(object sender, EventArgs e)//test
        {
            this.SaveMTCT("WeiAgg1", 0, this.ucHeThongAuto1.IsAuto, 0, 0);
            this.SaveMTCT("WeiAgg2", 0, this.ucHeThongAuto1.IsAuto, 0, 0);
            this.SaveMTCT("WeiAgg3", 0, this.ucHeThongAuto1.IsAuto, 0, 0);
            this.SaveMTCT("WeiAgg4", 0, this.ucHeThongAuto1.IsAuto, 0, 0);
            this.SaveMTCT("WeiAgg5", 0, this.ucHeThongAuto1.IsAuto, 0, 0);
            this.SaveMTCT("WeiCe1", 0, this.ucHeThongAuto1.IsAuto, 0, 0);
            this.SaveMTCT("WeiCe2", 0, this.ucHeThongAuto1.IsAuto, 0, 0);
            this.SaveMTCT("WeiCe3", 0, this.ucHeThongAuto1.IsAuto, 0, 0);
            this.SaveMTCT("WeiCe4", 0, this.ucHeThongAuto1.IsAuto, 0, 0);
            this.SaveMTCT("WeiCe5", 0, this.ucHeThongAuto1.IsAuto, 0, 0);
            this.SaveMTCT("WeiWa1", 0, this.ucHeThongAuto1.IsAuto, 0, 0);
            this.SaveMTCT("WeiWa2", 0, this.ucHeThongAuto1.IsAuto, 0, 0);
            this.SaveMTCT("WeiWa2", 0, this.ucHeThongAuto1.IsAuto, 0, 0);
            this.SaveMTCT("WeiAdd1", 0, this.ucHeThongAuto1.IsAuto, 0, 0);
            this.SaveMTCT("WeiAdd2", 0, this.ucHeThongAuto1.IsAuto, 0, 0);
        }

        private void simpleButton2_Click(object sender, EventArgs e)//test
        {
            this.SaveMTCT("WeiAgg1", 1, this.ucHeThongAuto1.IsAuto, 0, 0);
            this.SaveMTCT("WeiAgg2", 1, this.ucHeThongAuto1.IsAuto, 0, 0);
            this.SaveMTCT("WeiAgg3", 1, this.ucHeThongAuto1.IsAuto, 0, 0);
            this.SaveMTCT("WeiAgg4", 1, this.ucHeThongAuto1.IsAuto, 0, 0);
            this.SaveMTCT("WeiAgg5", 1, this.ucHeThongAuto1.IsAuto, 0, 0);
            this.SaveMTCT("WeiCe1", 1, this.ucHeThongAuto1.IsAuto, 0, 0);
            this.SaveMTCT("WeiCe2", 1, this.ucHeThongAuto1.IsAuto, 0, 0);
            this.SaveMTCT("WeiCe3", 1, this.ucHeThongAuto1.IsAuto, 0, 0);
            this.SaveMTCT("WeiCe4", 1, this.ucHeThongAuto1.IsAuto, 0, 0);
            this.SaveMTCT("WeiCe5", 1, this.ucHeThongAuto1.IsAuto, 0, 0);
            this.SaveMTCT("WeiWa1", 1, this.ucHeThongAuto1.IsAuto, 0, 0);
            this.SaveMTCT("WeiWa2", 1, this.ucHeThongAuto1.IsAuto, 0, 0);
            this.SaveMTCT("WeiWa2", 1, this.ucHeThongAuto1.IsAuto, 0, 0);
            this.SaveMTCT("WeiAdd1", 1, this.ucHeThongAuto1.IsAuto, 0, 0);
            this.SaveMTCT("WeiAdd2", 1, this.ucHeThongAuto1.IsAuto, 0, 0);
        }

        

        private void ucBTXien1_ButtonClick_MouseDown(object sender, EventArgs e)//event
        {
            if (!ucBTXien1.IsOn)
            {
                DialogResult result = TramTromMessageBox.ShowYesNoDialog("Xác nhận 'BẬT' băng tải xiên?");
                switch (result)
                {
                    case DialogResult.Yes:
                        this._so.SendingCommand.NN_BAT_TAT_BTX = true;
                        this.SendData_DB2_NewTread();
                        Thread.Sleep(100);
                        this._so.SendingCommand.NN_BAT_TAT_BTX = false;
                        this.SendData_DB2_NewTread();
                        //ucBTXien1.IsOn = true;
                        //ucBTXien1.CheDo = UcBTXien.Action.Pause;

                        break;
                    case DialogResult.No:
                        break;
                }
                /*if (ucHeThongAuto1.CheDoChay == UcHeThongAuto.CheDo.Auto)
                {
                    return;
                }
                else
                {
                   
                }*/
                
            }
            else
            {
                this._so.SendingCommand.F1_Run = false;
                this.SendData_DB2_NewTread();
            }
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void ucBTXien1_ButtonClick_MouseUp(object sender, EventArgs e)//event
        {
            this._so.SendingCommand.NN_BAT_TAT_BTX = false;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }
        private void ucBTXien1_ButtonClick(object sender, EventArgs e)//event
        {
            this._so.SendingCommand.NN_BAT_TAT_BTX = true;
            this.SendData_DB2_NewTread();
            //StatusConnected.CheckOpenSof(true, true);
            Thread.Sleep(100);
            this._so.SendingCommand.NN_BAT_TAT_BTX = false;
            this.SendData_DB2_NewTread();
            //ucBTXien1.IsOn = false;
            TramTronLogger.WriteInfo(sender.ToString());
        }
       

        private void ShowMessage(string message, Enums.MsgType msgType)
        {
            switch (msgType)
            {
                case Enums.MsgType.Error:
                    this.mmoThongBao.ForeColor = Color.Red;
                    break;
                case Enums.MsgType.Info:
                    this.mmoThongBao.ForeColor = Color.Green;
                    break;
                case Enums.MsgType.Warning:
                    this.mmoThongBao.ForeColor = Color.Orange;
                    break;
            }
            this.mmoThongBao.Text = message;
        }

        private void lueDriver_ButtonPressed(object sender, ButtonPressedEventArgs e)//event
        {
            if (e.Button.Kind == ButtonPredefines.Plus)
            {
                NewTaiXeView newTaiXeView = new NewTaiXeView(null, Enums.FormAction.New);
                ViewManager.ShowViewDialog(newTaiXeView);
                if (newTaiXeView.GetDialogResult() == DialogResult.OK)
                {
                    this._presenter.ListTaiXe();
                    this.lueDriver.EditValue = null;
                }
            }
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void lueXe_ButtonPressed(object sender, ButtonPressedEventArgs e)//event
        {
            if (e.Button.Kind == ButtonPredefines.Plus)
            {
                NewXeView newXeView = new NewXeView(null, Enums.FormAction.New);
                ViewManager.ShowViewDialog(newXeView);
                if (newXeView.GetDialogResult() == DialogResult.OK)
                {
                    this._presenter.ListXe();
                    this.lueXe.EditValue = null;
                }
            }
        }

        private void ucPrpel1_Button_NoiTronClick(object sender, EventArgs e)//event
        {
            ButtonClickNoiTron();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void ucPrpelSe1_Button_NoiTronClick(object sender, EventArgs e)//event
        {
            ButtonClickNoiTron();
            TramTronLogger.WriteInfo(sender.ToString());
        }
        private void ButtonClickNoiTron()//event
        {
            this._so.SendingCommand.NN_BAT_TAT_NOI_TRON = true;
            this.SendData_DB2_NewTread();
            Thread.Sleep(100);
            this._so.SendingCommand.NN_BAT_TAT_NOI_TRON = false;
            this.SendData_DB2_NewTread();
        }
        private void lblSim_Click(object sender, EventArgs e)//event
        {
            SimParaMngView ctrView = new SimParaMngView();
            ViewManager.ShowViewDialog(ctrView);
            if (ctrView.GetDialogResult() != DialogResult.OK)
                return;
            this._presenter.ListTimerPara();
            SendData_DB5_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void ucPrpel1_Button_NoiTronClick_MouseDown(object sender, EventArgs e)//event
        {
            ButtonMouseDownNoiTron();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void ucPrpel1_Button_NoiTronClick_MouseUp(object sender, EventArgs e)//event
        {
            this._so.SendingCommand.NN_BAT_TAT_NOI_TRON = false;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void ucPrpelSe1_Button_NoiTronClick_MouseDown(object sender, EventArgs e)//event
        {
            ButtonMouseDownNoiTron();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void ucPrpelSe1_Button_NoiTronClick_MouseUp(object sender, EventArgs e)//event
        {
            this._so.SendingCommand.NN_BAT_TAT_NOI_TRON = false;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }
        private void ButtonMouseDownNoiTron() //event
        {
            DialogResult result = TramTromMessageBox.ShowYesNoDialog("Xác nhận 'BẬT' nồi trộn?");
            switch (result)
            {
                case DialogResult.Yes:
                    this._so.SendingCommand.NN_BAT_TAT_NOI_TRON = true;
                    this.SendData_DB2_NewTread();
                    Thread.Sleep(100);
                    this._so.SendingCommand.NN_BAT_TAT_NOI_TRON = false;
                    this.SendData_DB2_NewTread();
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void ucBTCan1_Button_MouseDown(object sender, EventArgs e)
        {
            if (IsRunBTX || ucTinHieu_GT_Duoi.IsOn)
            {
                if (ucHeThongAuto1.CheDoChay == UcHeThongAuto.CheDo.Auto)
                {
                    return;
                }
                else
                {
                    DialogResult result = TramTromMessageBox.ShowYesNoDialog("Xác nhận 'BẬT' băng tải cân?");
                    switch (result)
                    {
                        case DialogResult.Yes:
                            this._so.SendingCommand.NN_BAT_TAT_BTC = true;
                            this.SendData_DB2_NewTread();
                            Thread.Sleep(100);
                            this._so.SendingCommand.NN_BAT_TAT_BTC = false;
                            this.SendData_DB2_NewTread();
                            break;
                        case DialogResult.No:
                            break;
                    }
                }
            }
            else
            {
                if(ConfigManager.TramTronConfig.CapPhoiRes == 0)
                {
                    TramTromMessageBox.ShowWarningDialog("Vui lòng bật băng tải xiên chạy trước.");
                }
                else if (ConfigManager.TramTronConfig.CapPhoiRes == 1)
                {
                    TramTromMessageBox.ShowWarningDialog("Vui lòng đưa gàu tải xuống vị trí dưới trước.");
                }
                
            }
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void ucBTCan1_Button_MouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_BAT_TAT_BTC = false;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void ucBTCan1_Button_Click(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_BAT_TAT_BTC = true;
            this.SendData_DB2_NewTread();
            Thread.Sleep(100);
            this._so.SendingCommand.NN_BAT_TAT_BTC = false;
            this.SendData_DB2_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void UpdateDoAmOnline(object sender, EventArgs e)
        {
            ObjHopDong selectedHD = this.lblMAC.Tag as ObjHopDong;

            foreach (ObjSilo silo in this._blstSilo_DoAmHutAgg)
            {
                SiloOnline siloOnline = this.GetSiloOnline(silo.MaSilo);
                decimal num1 = siloOnline.DoAm;
                UpdateDoAm(silo.SiloID, num1);
            }
            this.BuildSetPoint(selectedHD, true);
        }

        private void ChangeCursor_ButtonMouseHover(object sender, EventArgs e)
        {
            //Cursor = customCursor;
            //Cursor = Cursors.Hand;
        }

        private void ChangeCursor_ButtonMouseLeave(object sender, EventArgs e)
        {
            //Cursor = Cursors.Default;
        }

        private void ucGauTai1_ButtonClick(object sender, EventArgs e)
        {
            TimeGTParaMngView ctrView = new TimeGTParaMngView();
            ViewManager.ShowViewDialog(ctrView);
            if (ctrView.GetDialogResult() != DialogResult.OK)
                return;
            this._presenter.ListTimerPara();
            SendData_DB5_NewTread();
            TramTronLogger.WriteInfo(sender.ToString());

        }

        
        private void spnThemBotNc_EditValueChanged(object sender, EventArgs e)
        {
            ObjHopDong selectedHD = this.lblMAC.Tag as ObjHopDong;
            if(this.spnThemBotNc.Value > 100)
            {
                this.spnThemBotNc.Value = 100;
            }
            else if(this.spnThemBotNc.Value < -100)
            {
                this.spnThemBotNc.Value = -100;
            }
            this._themBotNuoc = this.spnThemBotNc.Value;
            this.SaveThemBotNuoc1((int)this.spnThemBotNc.Tag, this._themBotNuoc);

            this.BuildSetPoint(selectedHD, true);
            this.SendData_DB4_NewTread();


        }
        
        private void SaveThemBotNuoc1(int macID, decimal themBotNuoc1)
        {
            this._presenter.SaveThemBotNuoc1(macID, themBotNuoc1);
        }
        private void ResetThemBotNuoc()
        {
            foreach(ObjMAC mac in this._blstMAC)
            {
                this.SaveThemBotNuoc1(mac.MACID, 0M);
            }
            
        }
        private void ucButtonRungCanAgg1_ButtonMouseDown(object sender, EventArgs e)
        {
            this.labelControl6.Text = "Đang rung Agg1";
            this._so.SendingCommand.NN_RUNG_AGG1 = true;
            SendData_DB2_NewTread();
        }

        private void ucButtonRungCanAgg1_ButtonMouseUp(object sender, EventArgs e)
        {
            this.labelControl6.Text = "";
            this._so.SendingCommand.NN_RUNG_AGG1 = false;
            SendData_DB2_NewTread();
        }

        private void ucButtonRungCanAgg2_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_RUNG_AGG2 = true;
            SendData_DB2_NewTread();
        }

        private void ucButtonRungCanAgg2_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_RUNG_AGG2 = false;
            SendData_DB2_NewTread();
        }

        private void ucButtonRungCanAgg3_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_RUNG_AGG3 = true;
            SendData_DB2_NewTread();
        }

        private void ucButtonRungCanAgg3_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_RUNG_AGG3 = false;
            SendData_DB2_NewTread();
        }

        private void ucButtonRungCanAgg4_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_RUNG_AGG4 = true;
            SendData_DB2_NewTread();
        }

        private void ucButtonRungCanAgg4_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_RUNG_AGG4 = false;
            SendData_DB2_NewTread();
        }

        private void ucButtonRungCanAgg5_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_RUNG_AGG5 = true;
            SendData_DB2_NewTread();
        }

        private void ucButtonRungCanAgg5_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_RUNG_AGG5 = false;
            SendData_DB2_NewTread();
        }

        private void ucButtonRungCanAgg6_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_RUNG_AGG6 = true;
            SendData_DB2_NewTread();
        }

        private void ucButtonRungCanAgg6_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_RUNG_AGG6 = true;
            SendData_DB2_NewTread();
        }

        private void ucButtonRungCanCe1_ButtonMouseDown(object sender, EventArgs e)
        {
            labelControl6.Text = "RUNG CE1...";
            this._so.SendingCommand.NN_RUNG_CE1 = true;
            SendData_DB2_NewTread();
        }

        private void ucButtonRungCanCe1_ButtonMouseUp(object sender, EventArgs e)
        {
            labelControl6.Text = "DỪNG RUNG CE1...";
            this._so.SendingCommand.NN_RUNG_CE1 = false;
            SendData_DB2_NewTread();
        }

        private void ucButtonRungCanCe2_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_RUNG_CE2 = true;
            SendData_DB2_NewTread();
        }

        private void ucButtonRungCanCe2_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_RUNG_CE2 = false;
            SendData_DB2_NewTread();
        }

        private void ucButtonRungCanPC_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_RUNG_PC = true;
            SendData_DB2_NewTread();
        }

        private void ucButtonRungCanPC_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_RUNG_PC = false;
            SendData_DB2_NewTread();
        }

        

        
        private void simpleButton9_Click(object sender, EventArgs e)
        {
            txtNiemChi.Text = Support.GetNextNiemChi(ConfigManager.TramTronConfig.SecuritySealNum);
            ConfigManager.TramTronConfig.SecuritySealNum = txtNiemChi.Text;
        }
        private void GetNiemChi()
        {
            txtNiemChi.Text = ConfigManager.TramTronConfig.SecuritySealNum;
        }
        private void DoNextNiemChi()
        {
            txtNiemChi.Text = Support.GetNextNiemChi(ConfigManager.TramTronConfig.SecuritySealNum);
            ConfigManager.TramTronConfig.SecuritySealNum = txtNiemChi.Text;
        }

        private void txtNiemChi_EditValueChanged(object sender, EventArgs e)
        {
            ConfigManager.TramTronConfig.SecuritySealNum = txtNiemChi.Text;
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            ResetThemBotNuoc();
        }
        private void ucButtonGauStop2_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_DUNG_GAU = true;
            SendData_DB2_NewTread();
        }

        private void ucButtonGauStop2_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_DUNG_GAU = false;
            SendData_DB2_NewTread();
        }
        private void SetLogic(UcLogicBase ucLogic)
        {
            ucLogic.GetValueLogic();
            //TramTromMessageBox.ShowMessageDialog(ucLogic.ValueLogic.ToString());
        }
        
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            string pathXML = EncryptionHelper.Encrypt(textEdit1.Text);

            this.textEdit2.Text = EncryptionHelper.Encrypt(textEdit1.Text);
            TramTromMessageBox.ShowMessageDialog(pathXML);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            string pathXML = EncryptionHelper.Decrypt(textEdit2.Text);

            TramTromMessageBox.ShowMessageDialog(pathXML);
            /* string pathXML = this.bteLogoPath.Text;
             EncryptionHelper.DecryptedXml(pathXML);*/
            /* string folderPath = AppDomain.CurrentDomain.BaseDirectory;

             try
             {
                 // Lấy danh sách các tệp tin có phần mở rộng là .dll
                 string[] dllFiles = Directory.GetFiles(folderPath, "*.dll");

                 // Xóa từng tệp tin .dll
                 foreach (string dllFile in dllFiles)
                 {
                     File.Delete(dllFile);
                     TramTronLogger.WriteInfo("Đã xóa tệp tin: " + dllFile);
                 }

                 TramTronLogger.WriteInfo("Đã xóa thành công các tệp tin .dll.");
             }
             catch (Exception ex)
             {
                 TramTronLogger.WriteInfo("Don't Delete:" + ex);
             }*/

        }

        private void bteLogoPath_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "XML Files|*.xml"; 
            openFileDialog1.Title = "Chọn File";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Lấy đường dẫn đến tệp hình ảnh được chọn
                    string imagePath = openFileDialog1.FileName;
                    bteLogoPath.Text = imagePath;
                    // Hiển thị hình ảnh trong PictureBox
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
        //=========================================================================================LOGIC CAN
        private BindingList<ObjSilo> _blstLogicAG_01 = new BindingList<ObjSilo>();
        private BindingList<ObjSilo> _blstLogicAG_01_Co = new BindingList<ObjSilo>();
        private BindingList<ObjSilo> _blstLogicAG_02 = new BindingList<ObjSilo>();
        private BindingList<ObjSilo> _blstLogicAG_02_Co = new BindingList<ObjSilo>();
        private BindingList<ObjSilo> _blstLogicAG_03 = new BindingList<ObjSilo>();
        private BindingList<ObjSilo> _blstLogicAG_03_Co = new BindingList<ObjSilo>();

        private BindingList<ObjSilo> _blstLogicCE_01 = new BindingList<ObjSilo>();
        private BindingList<ObjSilo> _blstLogicCE_01_Co = new BindingList<ObjSilo>();
        private BindingList<ObjSilo> _blstLogicCE_02 = new BindingList<ObjSilo>();
        private BindingList<ObjSilo> _blstLogicCE_02_Co = new BindingList<ObjSilo>();

        private BindingList<ObjSilo> _blstLogicAD_01 = new BindingList<ObjSilo>();
        private BindingList<ObjSilo> _blstLogicAD_01_Co = new BindingList<ObjSilo>();
        private BindingList<ObjSilo> _blstLogicAD_02 = new BindingList<ObjSilo>();
        private BindingList<ObjSilo> _blstLogicAD_02_Co = new BindingList<ObjSilo>();

        private BindingList<ObjSilo> _blstLogicAG_SV = new BindingList<ObjSilo>();
        private BindingList<ObjSilo> _blstLogicAG_NoSV = new BindingList<ObjSilo>();
        private BindingList<ObjSilo> _blstLogicCE_SV = new BindingList<ObjSilo>();
        private BindingList<ObjSilo> _blstLogicCE_NoSV = new BindingList<ObjSilo>();
        private BindingList<ObjSilo> _blstLogicAD_SV = new BindingList<ObjSilo>();
        private BindingList<ObjSilo> _blstLogicAD_NoSV = new BindingList<ObjSilo>();

        private void LoadLogicAG(int numSilo)
        {
            ResetLogicAG();
            if (numSilo == 1 || numSilo == 0)
            {
                pnlLogicAG_01.Visible = true;

            }
            else if (numSilo == 2)
            {
                pnlLogicAG_01.Visible
                = pnlLogicAG_02.Visible = true;
            }
            else
            {
                pnlLogicAG_01.Visible
                = pnlLogicAG_02.Visible
                = pnlLogicAG_03.Visible = true;
            }
        }
        private void LoadLogicCE(int numSilo)
        {
            ResetLogicCE();
            if (numSilo == 1 || numSilo == 0)
            {
                pnlLogicCE_01.Visible = true;

            }
            else
            {
                pnlLogicCE_01.Visible
                = pnlLogicCE_02.Visible = true;
            }

        }
        private void LoadLogicAD(int numSilo)
        {
            ResetLogicAD();
            if (numSilo == 1 || numSilo == 0)
            {
                pnlLogicADD_01.Visible = true;

            }
            else
            {
                pnlLogicADD_01.Visible
                = pnlLogicADD_02.Visible = true;
            }
            
        }
        private void ResetLogicAG()
        {
            pnlLogicAG_01.Visible
            = pnlLogicAG_02.Visible
            = pnlLogicAG_03.Visible = false;
        }
        private void ResetLogicCE()
        {
            pnlLogicCE_01.Visible
            = pnlLogicCE_02.Visible = false;
        }
        private void ResetLogicAD()
        {
            pnlLogicADD_01.Visible
            = pnlLogicADD_02.Visible = false;
        }

        private void GetSiloLogicAGHaveSV()
        {
            this._blstLogicAG_SV.Clear();
            foreach (ObjSilo silo in this._blstSiloLogicAG)
            {
                SiloOnline siloOnline = this.GetSiloOnline(silo.MaSilo);
                if (siloOnline.KLCanCan != 0)
                {
                    this._blstLogicAG_SV.Add(silo);
                }
            }
            _blstLogicAG_01 = this._blstLogicAG_SV;
            _blstLogicAG_02 = this._blstLogicAG_SV;
            _blstLogicAG_03 = this._blstLogicAG_SV;

            this.lueBlstAG_01.Properties.DataSource = _blstLogicAG_01;
            this.lueBlstAG_02.Properties.DataSource = _blstLogicAG_02;
            this.lueBlstAG_03.Properties.DataSource = _blstLogicAG_03;
        }
        private void GetSiloLogicAGNotHaveSV()
        {
            this._blstLogicAG_NoSV.Clear();
            foreach (ObjSilo silo in this._blstSiloLogicAG)
            {
                SiloOnline siloOnline = this.GetSiloOnline(silo.MaSilo);
                if (siloOnline.KLCanCan == 0)
                {
                    this._blstLogicAG_NoSV.Add(silo);
                }

                _blstLogicAG_01_Co = this._blstLogicAG_NoSV;
                _blstLogicAG_02_Co = this._blstLogicAG_NoSV;
                _blstLogicAG_03_Co = this._blstLogicAG_NoSV;

                this.lueBlstAG_01_Co.Properties.DataSource = _blstLogicAG_01_Co;
                this.lueBlstAG_02_Co.Properties.DataSource = _blstLogicAG_02_Co;
                this.lueBlstAG_03_Co.Properties.DataSource = _blstLogicAG_03_Co;
            }
        }
        private void GetSiloLogicCEHaveSV()
        {
            this._blstLogicCE_SV.Clear();
            foreach (ObjSilo silo in this._blstSiloLogicCE)
            {
                SiloOnline siloOnline = this.GetSiloOnline(silo.MaSilo);
                if (siloOnline.KLCanCan != 0)
                {
                    this._blstLogicCE_SV.Add(silo);
                }
            }
            _blstLogicCE_01 = this._blstLogicCE_SV;
            _blstLogicCE_02 = this._blstLogicCE_SV;

            this.lueBlstCE_01.Properties.DataSource = _blstLogicCE_01;
            this.lueBlstCE_02.Properties.DataSource = _blstLogicCE_02;
        }
        private void GetSiloLogicCENotHaveSV()
        {
            this._blstLogicCE_NoSV.Clear();
            foreach (ObjSilo silo in this._blstSiloLogicCE)
            {
                SiloOnline siloOnline = this.GetSiloOnline(silo.MaSilo);
                if (siloOnline.KLCanCan == 0)
                {
                    this._blstLogicCE_NoSV.Add(silo);
                }

                _blstLogicCE_01_Co = this._blstLogicCE_NoSV;
                _blstLogicCE_02_Co = this._blstLogicCE_NoSV;

                this.lueBlstCE_01_Co.Properties.DataSource = _blstLogicCE_01_Co;
                this.lueBlstCE_02_Co.Properties.DataSource = _blstLogicCE_02_Co;
            }
        }
        private void GetSiloLogicADHaveSV()
        {
            this._blstLogicAD_SV.Clear();
            foreach (ObjSilo silo in this._blstSiloLogicAD)
            {
                SiloOnline siloOnline = this.GetSiloOnline(silo.MaSilo);
                if (siloOnline.KLCanCan != 0)
                {
                    this._blstLogicAD_SV.Add(silo);
                }
            }
            _blstLogicAD_01 = this._blstLogicAD_SV;
            _blstLogicAD_02 = this._blstLogicAD_SV;

            this.lueBlstADD_01.Properties.DataSource = _blstLogicAD_01;
            this.lueBlstADD_02.Properties.DataSource = _blstLogicAD_02;
        }
        private void GetSiloLogicADNotHaveSV()
        {
            this._blstLogicAD_NoSV.Clear();
            foreach (ObjSilo silo in this._blstSiloLogicAD)
            {
                SiloOnline siloOnline = this.GetSiloOnline(silo.MaSilo);
                if (siloOnline.KLCanCan == 0)
                {
                    this._blstLogicAD_NoSV.Add(silo);
                }

                _blstLogicAD_01_Co = this._blstLogicAD_NoSV;
                _blstLogicAD_02_Co = this._blstLogicAD_NoSV;

                this.lueBlstADD_01_Co.Properties.DataSource = _blstLogicAD_01_Co;
                this.lueBlstADD_02_Co.Properties.DataSource = _blstLogicAD_02_Co;
            }
        }
        private BindingList<ObjSilo> UpdateList(BindingList<ObjSilo> blstSilo, LookUpEdit lue1,LookUpEdit lue2)
        {
            BindingList<ObjSilo> blstNew = new BindingList<ObjSilo>();
            foreach (ObjSilo silo in blstSilo)
            {
                if(lue1 != null)
                {
                    if (silo.MaSilo != (string)lue1.EditValue)
                    {
                        blstNew.Add(silo);
                    }
                }
                if(lue2 != null)
                {
                    if (silo.MaSilo == (string)lue2.EditValue)
                    {
                        blstNew.Remove(silo);
                    }
                }
            }
            return blstNew;
        }

        private void GenericBlstLogicAG()
        {   
            this.lueBlstAG_01.Properties.DataSource =this._blstLogicAG_01;
            this.lueBlstAG_01_Co.Properties.DataSource =this._blstLogicAG_01_Co;
            this.lueBlstAG_02.Properties.DataSource = this._blstLogicAG_02;
            this.lueBlstAG_02_Co.Properties.DataSource = this._blstLogicAG_02_Co;
            this.lueBlstAG_03.Properties.DataSource = this._blstLogicAG_03;
            this.lueBlstAG_03_Co.Properties.DataSource = this._blstLogicAG_03_Co;
        }
        private void GenericBlstLogicCE()
        {
            this.lueBlstCE_01.Properties.DataSource = this._blstLogicCE_01;
            this.lueBlstCE_01_Co.Properties.DataSource = this._blstLogicCE_01_Co;
            this.lueBlstCE_02.Properties.DataSource = this._blstLogicCE_02;
            this.lueBlstCE_02_Co.Properties.DataSource = this._blstLogicCE_02_Co;
            
        }
        private void GenericBlstLogicAD()
        {
            this.lueBlstADD_01.Properties.DataSource = this._blstLogicAD_01;
            this.lueBlstADD_01_Co.Properties.DataSource = this._blstLogicAD_01_Co;
            this.lueBlstADD_02.Properties.DataSource = this._blstLogicAD_02;
            this.lueBlstADD_02_Co.Properties.DataSource = this._blstLogicAD_02_Co;

        }

        private void xtraTabPage1_VisibleChanged(object sender, EventArgs e)
        {
            GetSiloLogicAGHaveSV();
            GetSiloLogicAGNotHaveSV();

            GetSiloLogicCEHaveSV();
            GetSiloLogicCENotHaveSV();

            GetSiloLogicADHaveSV();
            GetSiloLogicADNotHaveSV();

            LoadLogicAG(this._blstLogicAG_NoSV.Count);
            LoadLogicCE(this._blstLogicCE_NoSV.Count);
            LoadLogicAD(this._blstLogicAD_NoSV.Count);

            /*Support.CheckSiloLogic(this._blstLogicAG_SV, lueBlstAG_01.EditValue.ToString());
            Support.CheckSiloLogic(this._blstLogicAG_SV, lueBlstAG_02.EditValue.ToString());
            Support.CheckSiloLogic(this._blstLogicAG_SV, lueBlstAG_03.EditValue.ToString());
            Support.CheckSiloLogic(this._blstLogicAG_NoSV, lueBlstAG_01_Co.EditValue.ToString());
            Support.CheckSiloLogic(this._blstLogicAG_NoSV, lueBlstAG_02_Co.EditValue.ToString());
            Support.CheckSiloLogic(this._blstLogicAG_NoSV, lueBlstAG_03_Co.EditValue.ToString());*/

        }
        private void lueBlst_01_EditValueChanged(object sender, EventArgs e)
        {
            _blstLogicAG_02 = UpdateList(this._blstLogicAG_SV, lueBlstAG_01, lueBlstAG_03);
            _blstLogicAG_03 = UpdateList(this._blstLogicAG_SV, lueBlstAG_01, lueBlstAG_02);
            GenericBlstLogicAG();
        }
        private void lueBlst_02_EditValueChanged(object sender, EventArgs e)
        {
            _blstLogicAG_01 = UpdateList(this._blstLogicAG_SV, lueBlstAG_02, lueBlstAG_03);
            _blstLogicAG_03 = UpdateList(this._blstLogicAG_SV, lueBlstAG_02, lueBlstAG_01);
            GenericBlstLogicAG();
        }

        private void lueBlst_03_EditValueChanged(object sender, EventArgs e)
        {
            _blstLogicAG_02 = UpdateList(this._blstLogicAG_SV, lueBlstAG_03, lueBlstAG_01);
            _blstLogicAG_01 = UpdateList(this._blstLogicAG_SV, lueBlstAG_03, lueBlstAG_02);
            GenericBlstLogicAG();
        }

        private void lueBlstAG_01_Co_EditValueChanged(object sender, EventArgs e)
        {
            _blstLogicAG_02_Co = UpdateList(this._blstLogicAG_NoSV, lueBlstAG_01_Co, lueBlstAG_03_Co);
            _blstLogicAG_03_Co = UpdateList(this._blstLogicAG_NoSV, lueBlstAG_01_Co, lueBlstAG_02_Co);
            GenericBlstLogicAG();
        }

        private void lueBlstAG_02_Co_EditValueChanged(object sender, EventArgs e)
        {
            _blstLogicAG_01_Co = UpdateList(this._blstLogicAG_NoSV, lueBlstAG_02_Co, lueBlstAG_03_Co);
            _blstLogicAG_03_Co = UpdateList(this._blstLogicAG_NoSV, lueBlstAG_02_Co, lueBlstAG_01_Co);
            GenericBlstLogicAG();
        }

        private void lueBlstAG_03_Co_EditValueChanged(object sender, EventArgs e)
        {
            _blstLogicAG_02_Co = UpdateList(this._blstLogicAG_NoSV, lueBlstAG_03_Co, lueBlstAG_01_Co);
            _blstLogicAG_01_Co = UpdateList(this._blstLogicAG_NoSV, lueBlstAG_03_Co, lueBlstAG_02_Co);
            GenericBlstLogicAG();
        }

        private void btnLamMoiAG_01_Click(object sender, EventArgs e)
        {
            Support.ResetValueLueLogic(this.lueBlstAG_01, this.lueBlstAG_01_Co);
            this._sp.LG1_AGG = Support.SetUpLogic(this.lueBlstAG_01, this.lueBlstAG_01_Co, "AG");
            SendData_DB6_NewTread();
        }

        private void btnThietLapAG_01_Click(object sender, EventArgs e)
        {
            this._sp.LG1_AGG = Support.SetUpLogic(this.lueBlstAG_01, this.lueBlstAG_01_Co, "AG");
            SendData_DB6_NewTread();
        }

        private void btnLamMoiAG_02_Click(object sender, EventArgs e)
        {
            Support.ResetValueLueLogic(this.lueBlstAG_02, this.lueBlstAG_02_Co);
            this._sp.LG1_AGG = Support.SetUpLogic(this.lueBlstAG_01, this.lueBlstAG_01_Co, "AG");
            SendData_DB6_NewTread();
        }

        private void btnThietLapAG_02_Click(object sender, EventArgs e)
        {
            Support.SetUpLogic(this.lueBlstAG_02, this.lueBlstAG_02_Co, "AG");
            this._sp.LG1_AGG = Support.SetUpLogic(this.lueBlstAG_01, this.lueBlstAG_01_Co, "AG");
            SendData_DB6_NewTread();
        }

        private void btnLamMoiAG_03_Click(object sender, EventArgs e)
        {
            Support.ResetValueLueLogic(this.lueBlstAG_03, this.lueBlstAG_03_Co);
            this._sp.LG1_AGG = Support.SetUpLogic(this.lueBlstAG_01, this.lueBlstAG_01_Co, "AG");
            SendData_DB6_NewTread();
        }

        private void btnThietLapAG_03_Click(object sender, EventArgs e)
        {
            Support.SetUpLogic(this.lueBlstAG_03, this.lueBlstAG_03_Co, "AG");
            this._sp.LG1_AGG = Support.SetUpLogic(this.lueBlstAG_01, this.lueBlstAG_01_Co, "AG");
            SendData_DB6_NewTread();
        }

        
        private void lueBlstCE_01_EditValueChanged(object sender, EventArgs e)
        {
            _blstLogicCE_02 = UpdateList(this._blstLogicCE_SV, lueBlstCE_01, null);
            GenericBlstLogicCE();
        }

        private void lueBlstCE_02_EditValueChanged(object sender, EventArgs e)
        {
            _blstLogicCE_01 = UpdateList(this._blstLogicCE_SV, lueBlstCE_02, null);
            GenericBlstLogicCE();
        }

        private void lueBlstCE_01_Co_EditValueChanged(object sender, EventArgs e)
        {
            _blstLogicCE_02_Co = UpdateList(this._blstLogicCE_NoSV, lueBlstCE_01_Co, null);
            GenericBlstLogicCE();
        }

        private void lueBlstCE_02_Co_EditValueChanged(object sender, EventArgs e)
        {
            _blstLogicCE_01_Co = UpdateList(this._blstLogicCE_NoSV, lueBlstCE_02_Co, null);
            GenericBlstLogicCE();
        }

        private void btnThietLapCE_01_Click(object sender, EventArgs e)
        {
            //Support.SetUpLogic(this.lueBlstCE_01, this.lueBlstCE_01_Co, "CE");
            this._sp.LG4_CE = Support.SetUpLogic(this.lueBlstCE_01, this.lueBlstCE_01_Co, "CE");
            SendData_DB6_NewTread();
        }

        private void btnLamMoiCE_01_Click(object sender, EventArgs e)
        {
            Support.ResetValueLueLogic(this.lueBlstCE_01, this.lueBlstCE_01_Co);
            this._sp.LG4_CE = Support.SetUpLogic(this.lueBlstCE_01, this.lueBlstCE_01_Co, "CE");
            SendData_DB6_NewTread();
        }

        private void btnThietLapCE_02_Click(object sender, EventArgs e)
        {
           // Support.SetUpLogic(this.lueBlstCE_02, this.lueBlstCE_02_Co, "CE");
            this._sp.LG5_CE = Support.SetUpLogic(this.lueBlstCE_02, this.lueBlstCE_02_Co, "CE");
            SendData_DB6_NewTread();
        }

        private void btnLamMoiCE_02_Click(object sender, EventArgs e)
        {
            Support.ResetValueLueLogic(this.lueBlstCE_02, this.lueBlstCE_02_Co);
            this._sp.LG5_CE = Support.SetUpLogic(this.lueBlstCE_02, this.lueBlstCE_02_Co, "CE");
            SendData_DB6_NewTread();
        }

        private void lueBlstADD_01_EditValueChanged(object sender, EventArgs e)
        {
            _blstLogicAD_02 = UpdateList(this._blstLogicAD_SV, lueBlstADD_01, null);
            GenericBlstLogicAD();
        }

        private void lueBlstADD_02_EditValueChanged(object sender, EventArgs e)
        {
            _blstLogicAD_01 = UpdateList(this._blstLogicAD_SV, lueBlstADD_02, null);
            GenericBlstLogicAD();
        }

        private void lueBlstADD_01_Co_EditValueChanged(object sender, EventArgs e)
        {
            _blstLogicAD_02_Co = UpdateList(this._blstLogicAD_NoSV, lueBlstADD_01_Co, null);
            GenericBlstLogicAD();
        }

        private void lueBlstADD_02_Co_EditValueChanged(object sender, EventArgs e)
        {
            _blstLogicAD_01_Co = UpdateList(this._blstLogicAD_NoSV, lueBlstADD_02_Co, null);
            GenericBlstLogicAD();
        }

        private void btnThietLapADD_01_Click(object sender, EventArgs e)
        {
            this._sp.LG6_ADD = Support.SetUpLogic(this.lueBlstADD_01, this.lueBlstADD_01_Co, "AD");
            SendData_DB6_NewTread();
        }

        private void btnLamMoiADD_01_Click(object sender, EventArgs e)
        {
            Support.ResetValueLueLogic(this.lueBlstADD_01, this.lueBlstADD_01_Co);
            this._sp.LG6_ADD = Support.SetUpLogic(this.lueBlstADD_01, this.lueBlstADD_01_Co, "AD");
            SendData_DB6_NewTread();
        }

        private void btnThietLapADD_02_Click(object sender, EventArgs e)
        {
            this._sp.LG7_ADD = Support.SetUpLogic(this.lueBlstADD_02, this.lueBlstADD_02_Co, "AD");
            SendData_DB6_NewTread();
        }

        private void btnLamMoiADD_02_Click(object sender, EventArgs e)
        {
            Support.ResetValueLueLogic(this.lueBlstADD_02, this.lueBlstADD_02_Co);
            this._sp.LG7_ADD = Support.SetUpLogic(this.lueBlstADD_02, this.lueBlstADD_02_Co, "AD");
            SendData_DB6_NewTread();
        }
        //=====================================================================================================GAU TAI
        private void ucButtonDungGau_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_DUNG_GAU = true;
            SendData_DB2_NewTread();
        }

        private void ucButtonDungGau_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_DUNG_GAU = false;
            SendData_DB2_NewTread();
        }

        private void ucButtonLenGau_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_GAU_LEN = true;
            SendData_DB2_NewTread();
        }

        private void ucButtonLenGau_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_GAU_LEN = false;
            SendData_DB2_NewTread();
        }

        private void ucButtonXuongGau_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_GAU_XUONG = true;
            SendData_DB2_NewTread();
        }

        private void ucButtonXuongGau_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_GAU_XUONG = false;
            SendData_DB2_NewTread();
        }

        private void ucButtonGauUp1_ButtonMouseDown_1(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_GAU_LEN = true;
            SendData_DB2_NewTread();
        }

        private void ucButtonGauUp1_ButtonMouseUp_1(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_GAU_LEN = false;
            SendData_DB2_NewTread();
        }

        private void ucButtonGauDown1_ButtonMouseDown_1(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_GAU_XUONG = true;
            SendData_DB2_NewTread();
        }

        private void ucButtonGauDown1_ButtonMouseUp_1(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_GAU_XUONG = false;
            SendData_DB2_NewTread();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            LoadParam();
        }
        private void LoadParam()
        {
            //FrmPrintGiaoHang frm = new FrmPrintGiaoHang();
            paras.Clear();
            paras.Add(ConfigManager.TramTronConfig.TenCty);
            paras.Add(this._selectedPT_Run.NgayPhieuTron.Value.ToString("dd/MM/yyyy"));
            paras.Add(lblTenCongTruong.Text);
            paras.Add(lblTenKhachHang.Text);
            paras.Add(lblMAC.Text);
            paras.Add(this._selectedPT_Run.NPMACCuongDo);
            paras.Add(this._selectedPT_Run.NPMACDoSut);
            paras.Add(lblSoPhieuTron.Text);
            paras.Add(this._selectedPT_Run.NPMACDoSut);
            paras.Add(lblDriver.Text);
            paras.Add(ConfigManager.TramTronConfig.KLChoLonNhat.ToString() + "m³");
            paras.Add(lblKhoiLuong.Text + "m³");
            paras.Add(_LuyKe_InNhanh.ToString() + "m³");
            paras.Add(lblXe.Text);
            paras.Add(this._selectedPT_Run.NgayPhieuTron.Value.ToString("HH: mm:ss"));
            paras.Add(this._selectedPT_Run.NPCongTruongDiaChi);
            paras.Add(this._selectedPT_Run.MaPhieuTron);
            paras.Add(lblKhoiLuong.Text);
            paras.Add(lblTenHangMuc.Text);
            paras.Add(lblNiemChi.Text);
            
            DateTime originalDateTime = this._selectedPT_Run.NgayPhieuTron.Value;
            DateTime modifiedDateTime = originalDateTime.AddMinutes(5);
            paras.Add(modifiedDateTime.ToString("HH: mm:ss"));

            if (ConfigManager.TramTronConfig.InPITuMau) // In Phiếu Trộn từ mẫu có sẳn được load từ file
            {
                WriteDetailInvoice(paras);
                PrintPTFromFile();
            }
            else
            {
               /* frm.FillDataPrinter(paras);
                frm.PrintPhieuTron();*/
            }
            

        }
        private void PrintPTFromFile()
        {
            try
            {
                string sourceFileName = ConfigManager.TramTronConfig.PIPath;

                string fileName = "";
                string filePathMau = ConfigManager.TramTronConfig.PIPath;
                if (filePathMau != string.Empty)
                {
                    fileName = Path.GetFileName(filePathMau);
                }
                string folderDesPhieuPath = ConfigManager.TramTronConfig.ReportPath;
                string wordFilePath = Path.Combine(folderDesPhieuPath, fileName);
                string pdfFilePath = Path.ChangeExtension(wordFilePath, ".pdf");

                Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();

                // Export Word document as PDF
                var wordDoc = wordApp.Documents.Add(wordFilePath);
                wordApp.ActiveDocument.ExportAsFixedFormat(pdfFilePath, WdExportFormat.wdExportFormatPDF);

                // Close and release Word document
                wordDoc.Close(false);
                Marshal.ReleaseComObject(wordDoc);

                // Delete the Word document
                if (File.Exists(wordFilePath))
                {
                    try
                    {
                        File.Delete(wordFilePath);
                        PrinterInvoke(pdfFilePath, 1);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Lỗi khi xóa tệp tin Word: {ex.Message}");
                        TramTronLogger.WriteError(ex);
                    }
                }

                /*if (File.Exists(pdfFilePath))
                {
                    // In file PDF vừa tạo
                   
                }
                else
                {
                    TramTromMessageBox.ShowMessageDialog("Không tìm thấy file PDF để in");
                }*/

                wordApp.Quit();
            }
            catch (Exception ex)
            {
                TramTromMessageBox.ShowErrorDialog(ex.ToString());
            }
        }
        public bool PrinterInvoke(string pdfFilePath, int numberOfCopies)
        {
            try
            {
                Task[] printTasks = new Task[numberOfCopies];

                for (int i = 0; i < numberOfCopies; i++)
                {
                    int copyIndex = i;
                    printTasks[i] = System.Threading.Tasks.Task.Run(() => Support.PrintReport(pdfFilePath));
                }

                Task.WaitAll(printTasks);

                return true;
            }
            catch (Exception ex)
            {
                TramTromMessageBox.ShowErrorDialog(ex.ToString());
            }
            return false;
        }
        private void PrintPDF(string pdfFilePath)
            {
                try
                {
                    // Hiển thị hộp thoại chọn máy in
                    string printerName = ConfigManager.TramTronConfig.MayInPI;

                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        Verb = "printto",
                        FileName = pdfFilePath,
                        UseShellExecute = true,
                        Arguments = $"\"{printerName}\""
                    };

                    using (Process process = new Process { StartInfo = startInfo }) // Kiem tra lai qua trinh in
                    {
                        process.Start();
                        process.WaitForExit(); // Chờ đến khi quá trình in kết thúc
                        //TramTromMessageBox.ShowMessageDialog("In file hoàn tất");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi in file PDF: {ex.Message}");
                    TramTronLogger.WriteError(ex);
                }
            }
        private void WriteDetailInvoice(List<string> param)
        {
            try
            {
                if (CopyTempFile() && !this._error)
                {
                    string sourceFileName = ConfigManager.TramTronConfig.PIPath;

                    string fileName = "";
                    string filePathMau = ConfigManager.TramTronConfig.PIPath;
                    if (filePathMau != string.Empty)
                    {
                        fileName = Path.GetFileName(filePathMau);
                    }
                    string folderDesPhieuPath = ConfigManager.TramTronConfig.ReportPath;

                    string filePath = Path.Combine(folderDesPhieuPath, fileName);

                    Microsoft.Office.Interop.Word.Application wordProcessor = new Microsoft.Office.Interop.Word.Application();

                    Microsoft.Office.Interop.Word.Document document = wordProcessor.Documents.Open(filePath);

                    for (int index = 0; index < param.Count; ++index)
                    {
                        string findText = "{" + index + "}";
                        ReplaceText(wordProcessor, findText, param[index]);
                    }

                    //managerLoadDataToTable(wordProcessor, dataTable);
                    wordProcessor.ActiveDocument.SaveAs(filePath, 12);
                    wordProcessor.Quit();

                }
            }
            catch (Exception ex)
            {
                TramTromMessageBox.ShowErrorDialog(ex.ToString());
            }
        }
        private bool CopyTempFile()
        {

            string sourceFileName = ConfigManager.TramTronConfig.PIPath;

            string fileName = "";
            string filePath = ConfigManager.TramTronConfig.PIPath;
            if (filePath != string.Empty)
            {
                fileName = Path.GetFileName(filePath);
            }

            string folderDesPhieuPath = ConfigManager.TramTronConfig.ReportPath;

            string str = Path.Combine(folderDesPhieuPath, fileName);

            try
            {
                if (!File.Exists(str))
                    File.Copy(sourceFileName, str, true);
                this._error = false;
            }
            catch (Exception ex)
            {
                this._error = true;
                TramTromMessageBox.ShowErrorDialog(ex.ToString());

            }
            return true;
        }
        private void ReplaceText(Microsoft.Office.Interop.Word.Application word, string searchText, string replacementText)
        {
            Microsoft.Office.Interop.Word.Selection selection = word.Selection;

            Microsoft.Office.Interop.Word.Find find = selection.Find;
            find.ClearFormatting();
            find.Text = searchText;

            Microsoft.Office.Interop.Word.Replacement replacement = find.Replacement;
            replacement.ClearFormatting();
            replacement.Text = replacementText;

            object missing = System.Reflection.Missing.Value;
            object replaceAll = Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll;

            find.Execute(ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref replaceAll, ref missing, ref missing, ref missing, ref missing);
        }
        private void ucButtonSKCe1_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.SW_SK_SILO1 = true;
            SendData_DB2_NewTread();

        }

        private void ucButtonSKCe1_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.SW_SK_SILO1 = false;
            SendData_DB2_NewTread();
        }

        private void ucButtonSKCe2_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_SKSL2 = true;
            SendData_DB2_NewTread();
        }

        private void ucButtonSKCe2_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_SKSL2 = false;
            SendData_DB2_NewTread();
        }

        private void ucButtonSKCe3_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_SKSL3 = true;
            SendData_DB2_NewTread();
        }

        private void ucButtonSKCe3_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_SKSL3 = false;
            SendData_DB2_NewTread();
        }

        private void ucButtonSKCe4_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_SKSL4 = true;
            SendData_DB2_NewTread();
        }

        private void ucButtonSKCe4_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_SKSL4 = false;
            SendData_DB2_NewTread();
        }

        private void ucButtonSKCe5_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_SKSL5 = true;
            SendData_DB2_NewTread();
        }

        private void ucButtonSKCe5_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_SKSL5 = false;
            SendData_DB2_NewTread();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            SimParaMngView ctrView = new SimParaMngView();
            ViewManager.ShowViewDialog(ctrView);
            if (ctrView.GetDialogResult() != DialogResult.OK)
                return;
            this._presenter.ListTimerPara();
        }

        private void checkAutoPrint_EditValueChanged(object sender, EventArgs e)
        {
            ConfigManager.TramTronConfig.AutoPrint = this.checkAutoPrint.Checked;
        }
    }
}
