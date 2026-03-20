using System;

namespace NDPSo.Utils
{
    public class TramTronConfig : ConfigBase
    {
        private const string FILENAME = "TramTronConfig.xml";
        private const string CONFIG_PATH = "/configuration/TramTron";
        private const string SERVICE_URI = "ServiceURI";
        private const string COMMON_SERVICE = "CommonService";
        private const string RECEIVING_SERVICE = "ReceivingService";
        private const string RUNNING_MOTE = "RunningMode";
        private const string SERVER_IP = "ServerIP";
        private const string SERIALPORT = "SerialPort";
        private const string LAN_IP = "LANIP";
        private const string LAN_PORT = "LANPort";
        private const string REPORT_PATH = "ReportPath";
        private const string LANGUAGE_RES = "LanguageRes";
        private const string SHOW_DASHBOARD = "ShowDashboard";
        private const string NONE_PLC_VERSION = "NonePLCVersion";
        private const string DODOAM1_PLC = "DoDoAm1PLC";
        private const string DODOAM2_PLC = "DoDoAm2PLC";
        private const string DODOAM1_AGG_MAPPING = "DoDoAm1AGG_Mapping";
        private const string DODOAM2_AGG_MAPPING = "DoDoAm2AGG_Mapping";
        private const string SHOW_TRON_ONLINE = "ShowTronOnline";
        private const string ALLOW_SAVEDATA = "AllowSaveData";
        private const string SHOW_CHANGE_MAC = "ShowChangeMAC";
        private const string DATA_DOCK_AUTO_HIDE = "DataDockAutoHide";
        private const string DATA_DOCK_HEIGHT = "DataDockHeight";
        private const string SEND_APP_RUNNING = "SendAppRunning";
        private const string OPEN_AS_NEW_WINDOW = "OpenAsNewWindow";
        private const string SHOW_FINISHED_DLT = "ShowFinishedDLT";
        private const string SHOW_PLANT_B = "ShowPlantB";
        private const string SET_0 = "Set0";
        private const string TEN_CTY = "TenCty";
        private const string DIACHI_CTY = "DiaChiCty";
        private const string DIENTHOAI_CTY = "DienThoaiCty";
        private const string LOGO_CTY = "LogoCty";
        private const string KL_CHO_LONNHAT = "KLChoLonNhat";
        private const string KL_TRON_NHONHAT = "KLTronNhoNhat";
        private const string KL_TRON_LONNHAT = "KLTronLonNhat";
        private const string TINH_BUTRU = "TinhBuTru";
        private const string RANGE_BT_AGG = "RangeBuTruAgg";
        private const string RANGE_BT_CE = "RangeBuTruCe";
        private const string RANGE_BT_WA = "RangeBuTruWa";
        private const string RANGE_BT_ADD = "RangeBuTruAdd";
        private const string LATEST_HOPDONG_DAYS = "LatestHopDongDays";
        private const string LATEST_PHIEUTRON_DAYS = "LatestPhieuTronDays";
        private const string DEFAULT_DULIEUTRON_ROWCOUNT = "DefaultDuLieuTronRowCount";
        private const string CE_X = "CE_X";
        private const string WA_X = "WA_X";
        private const string ADD_X = "ADD_X";
        private const string AGG_X = "AGG_X";
        private const string CE_Y = "CE_Y";
        private const string WA_Y = "WA_Y";
        private const string ADD_Y = "ADD_Y";
        private const string AGG_Y = "AGG_Y";
        private const string CE_GROUP_WIDTH = "CE_Group_Width";
        private const string WA_GROUP_WIDTH = "WA_Group_Width";
        private const string ADD_GROUP_WIDTH = "ADD_Group_Width";
        private const string AGG_GROUP_WIDTH = "AGG_Group_Width";
        private const string SKIN_STYLE = "SkinStyle";
        private const string NUMERIC_FORMAT_STRING = "NumericFormatString";
        private const string SIM_ISMOPHONG = "SIM_IsMoPhong";
        private const string SIM_CAN_AGG_VALUE = "SIM_CanAggValue";
        private const string SIM_CAN_CE_VALUE = "SIM_CanCeValue";
        private const string SIM_CAN_WA_VALUE = "SIM_CanWaValue";
        private const string SIM_CAN_ADD_VALUE = "SIM_CanAddValue";
        private const string SIM_CAN_AGG_NAP = "SIM_CanAggNap";
        private const string SIM_CAN_CE_NAP = "SIM_CanCeNap";
        private const string SIM_CAN_WA_NAP = "SIM_CanWaNap";
        private const string SIM_CAN_ADD_NAP = "SIM_CanAddNap";
        private const string SIM_CAN_AGG_XA = "SIM_CanAggXa";
        private const string SIM_CAN_CE_XA = "SIM_CanCeXa";
        private const string SIM_CAN_WA_XA = "SIM_CanWaXa";
        private const string SIM_CAN_ADD_XA = "SIM_CanAddXa";
        private const string PARA01 = "Para01";
        private const string PARA02 = "Para02";
        private const string PARA03 = "Para03";
        private const string PARA04 = "Para04";
        private const string PARA05 = "Para05";
        private const string PARA06 = "Para06";
        private const string PARA07 = "Para07";
        private const string PARA08 = "Para08";
        private const string PARA09 = "Para09";
        private const string PARA10 = "Para10";
        private const string PARA11 = "Para11";
        private const string PARA12 = "Para12";
        private const string PARA13 = "Para13";
        private const string PARA14 = "Para14";
        private const string PARA15 = "Para15";
        private const string COMMAND_SECTION_NAME = "Command";
        private const string COMMAND_KEY_NAME = "Code";
        private const string COMMAND_ENABLE = "Enable";
        private const string ID_SAVE_SECTION_NAME = "IdSaveCan";
        private const string ID_SAVE_KEY_NAME = "Can";
        private const string ID_SAVE_VALUE = "IdSave";
        private const string HCC_SECTION_NAME = "HieuChuanCan";
        private const string HCC_KEY_NAME = "SiloType";
        private const string HCC_LO_AI = "Lo_AI";
        private const string HCC_HI_AI = "Hi_AI";
        private const string HCC_LO_WEIGH = "Lo_Weigh";
        private const string HCC_HI_WEIGH = "Hi_Weigh";
        private const string ACTION_SECTION_NAME = "Action";
        private const string ACTION_KEY_NAME = "ActionType";
        private const string ACTION_DISPLAY = "Display";
        private const string ACTION_MANDATORY = "Mandatory";
        private const string ACTION_ENABLE = "Enable";
        private const string ACTION_VISIBLE = "Visible";
        private const string ACTION_INDEX = "Index";
        private const string YES = "yes";
        private const string SECURITY_SEAL_NUM = "SecuritySealNum";
        public bool DevEnv
        {
            get => Convert.ToBoolean(this[nameof(DevEnv)]);
            set => this["DevEnv"] = value ? "true" : "false";
        }

        public string ServiceURI
        {
            get => this[nameof(ServiceURI)];
            set => this[nameof(ServiceURI)] = value;
        }

        public string CommonService
        {
            get => this[nameof(CommonService)];
            set => this[nameof(CommonService)] = value;
        }
        public string SecuritySealNum
        {
            get => this[nameof(SecuritySealNum)];
            set => this[nameof(SecuritySealNum)] = value;
        }
        public int DriverNum
        {
            get => Convert.ToInt32(this[nameof(DriverNum)]);
            set => this[nameof(DriverNum)] = value.ToString();
        }
        public int XeNum
        {
            get => Convert.ToInt32(this[nameof(XeNum)]);
            set => this[nameof(XeNum)] = value.ToString();
        }
        public int HangMucNumNA
        {
            get => Convert.ToInt32(this[nameof(HangMucNumNA)]);
            set => this[nameof(HangMucNumNA)] = value.ToString();
        }
        public int AddMinuteGioKT
        {
            get => Convert.ToInt32(this[nameof(AddMinuteGioKT)]);
            set => this[nameof(AddMinuteGioKT)] = value.ToString();
        }
        public string ReceivingService
        {
            get => this[nameof(ReceivingService)];
            set => this[nameof(ReceivingService)] = value;
        }

        public int RunningMode
        {
            get => Convert.ToInt32(this[nameof(RunningMode)]);
            set => this[nameof(RunningMode)] = value.ToString();
        }

        public string ServerIP
        {
            get => this[nameof(ServerIP)];
            set => this[nameof(ServerIP)] = value;
        }

        public string SerialPort
        {
            get => this[nameof(SerialPort)];
            set => this[nameof(SerialPort)] = value;
        }

        public string LANIP
        {
            get => this[nameof(LANIP)];
            set => this[nameof(LANIP)] = value;
        }

        public int LANPort
        {
            get => Convert.ToInt32(this[nameof(LANPort)]);
            set => this[nameof(LANPort)] = value.ToString();
        }

        public string ReportPath
        {
            get => this[nameof(ReportPath)];
            set => this[nameof(ReportPath)] = value;
        }
        public string ImportPath
        {
            get => this[nameof(ImportPath)];
            set => this[nameof(ImportPath)] = value;
        }

        public int LanguageRes
        {
            get => Convert.ToInt32(this[nameof(LanguageRes)]);
            set => this[nameof(LanguageRes)] = value.ToString();
        }

        public bool ShowDashBoard
        {
            get => Convert.ToBoolean(this["ShowDashboard"]);
            set => this["ShowDashboard"] = value ? "true" : "false";
        }
        public bool AutoPrint
        {
            get => Convert.ToBoolean(this[nameof(AutoPrint)]);
            set => this[nameof(AutoPrint)] = value ? "true" : "false";
        }
        public bool NonePLCVersion
        {
            get => Convert.ToBoolean(this[nameof(NonePLCVersion)]);
            set => this[nameof(NonePLCVersion)] = value ? "true" : "false";
        }

        public bool DoDoAm1PLC
        {
            get => Convert.ToBoolean(this[nameof(DoDoAm1PLC)]);
            set => this[nameof(DoDoAm1PLC)] = value ? "true" : "false";
        }

        public bool DoDoAm2PLC
        {
            get => Convert.ToBoolean(this[nameof(DoDoAm2PLC)]);
            set => this[nameof(DoDoAm2PLC)] = value ? "true" : "false";
        }

        public string DoDoAm1AGG_Mapping
        {
            get => this[nameof(DoDoAm1AGG_Mapping)];
            set => this[nameof(DoDoAm1AGG_Mapping)] = value;
        }

        public string DoDoAm2AGG_Mapping
        {
            get => this[nameof(DoDoAm2AGG_Mapping)];
            set => this[nameof(DoDoAm2AGG_Mapping)] = value;
        }

        public bool ShowTronOnline
        {
            get => Convert.ToBoolean(this[nameof(ShowTronOnline)]);
            set => this[nameof(ShowTronOnline)] = value ? "true" : "false";
        }

        public bool ShowKLCanMinMax
        {
            get => Convert.ToBoolean(this[nameof(ShowKLCanMinMax)]);
            set => this[nameof(ShowKLCanMinMax)] = value ? "true" : "false";
        }

        public bool AllowSaveData
        {
            get => Convert.ToBoolean(this[nameof(AllowSaveData)]);
            set => this[nameof(AllowSaveData)] = value ? "true" : "false";
        }

        public bool ShowChangeMAC
        {
            get => Convert.ToBoolean(this[nameof(ShowChangeMAC)]);
            set => this[nameof(ShowChangeMAC)] = value ? "true" : "false";
        }

        public bool DataDockAutoHide
        {
            get => Convert.ToBoolean(this[nameof(DataDockAutoHide)]);
            set => this[nameof(DataDockAutoHide)] = value ? "true" : "false";
        }

        public int DataDockHeight
        {
            get => int.Parse(this[nameof(DataDockHeight)]);
            set => this[nameof(DataDockHeight)] = value.ToString();
        }

        public bool SendAppRunning
        {
            get => Convert.ToBoolean(this[nameof(SendAppRunning)]);
            set => this[nameof(SendAppRunning)] = value ? "true" : "false";
        }

        public bool OpenAsNewWindow
        {
            get => Convert.ToBoolean(this[nameof(OpenAsNewWindow)]);
            set => this[nameof(OpenAsNewWindow)] = value ? "true" : "false";
        }

        public bool ShowFinishedDLT
        {
            get => Convert.ToBoolean(this[nameof(ShowFinishedDLT)]);
            set => this[nameof(ShowFinishedDLT)] = value ? "true" : "false";
        }

        public bool ShowPlantB
        {
            get => Convert.ToBoolean(this[nameof(ShowPlantB)]);
            set => this[nameof(ShowPlantB)] = value ? "true" : "false";
        }

        public bool Set0
        {
            get => Convert.ToBoolean(this[nameof(Set0)]);
            set => this[nameof(Set0)] = value ? "true" : "false";
        }

        public string TenCty
        {
            get => this[nameof(TenCty)];
            set => this[nameof(TenCty)] = value;
        }

        public string DiaChiCty
        {
            get => this[nameof(DiaChiCty)];
            set => this[nameof(DiaChiCty)] = value;
        }

        public string DienThoaiCty
        {
            get => this[nameof(DienThoaiCty)];
            set => this[nameof(DienThoaiCty)] = value;
        }

        public string LogoCty
        {
            get => this[nameof(LogoCty)];
            set => this[nameof(LogoCty)] = value;
        }

        public Decimal KLChoLonNhat
        {
            get => Decimal.Parse(this[nameof(KLChoLonNhat)]);
            set => this[nameof(KLChoLonNhat)] = value.ToString();
        }

        public Decimal KLTronNhoNhat
        {
            get => Decimal.Parse(this[nameof(KLTronNhoNhat)]);
            set => this[nameof(KLTronNhoNhat)] = value.ToString();
        }

        public Decimal KLTronLonNhat
        {
            get => Decimal.Parse(this[nameof(KLTronLonNhat)]);
            set => this[nameof(KLTronLonNhat)] = value.ToString();
        }

        public bool TinhBuTru
        {
            get => Convert.ToBoolean(this[nameof(TinhBuTru)]);
            set => this[nameof(TinhBuTru)] = value ? "true" : "false";
        }

        public Decimal RangeBuTruAgg
        {
            get => Decimal.Parse(this[nameof(RangeBuTruAgg)]);
            set => this[nameof(RangeBuTruAgg)] = value.ToString();
        }

        public Decimal RangeBuTruCe
        {
            get => Decimal.Parse(this[nameof(RangeBuTruCe)]);
            set => this[nameof(RangeBuTruCe)] = value.ToString();
        }

        public Decimal RangeBuTruWa
        {
            get => Decimal.Parse(this[nameof(RangeBuTruWa)]);
            set => this[nameof(RangeBuTruWa)] = value.ToString();
        }

        public Decimal RangeBuTruAdd
        {
            get => Decimal.Parse(this[nameof(RangeBuTruAdd)]);
            set => this[nameof(RangeBuTruAdd)] = value.ToString();
        }

        public int LatestHopDongDays
        {
            get => Convert.ToInt32(this[nameof(LatestHopDongDays)]);
            set => this[nameof(LatestHopDongDays)] = value.ToString();
        }

        public int LatestPhieuTronDays
        {
            get => Convert.ToInt32(this[nameof(LatestPhieuTronDays)]);
            set => this[nameof(LatestPhieuTronDays)] = value.ToString();
        }
        public int LatestBaoCaoDays
        {
            get => Convert.ToInt32(this[nameof(LatestBaoCaoDays)]);
            set => this[nameof(LatestBaoCaoDays)] = value.ToString();
        }

        public int DefaultDuLieuTronRowCount
        {
            get => Convert.ToInt32(this[nameof(DefaultDuLieuTronRowCount)]);
            set => this[nameof(DefaultDuLieuTronRowCount)] = value.ToString();
        }
        public bool Show_BTC
        {
            get => Convert.ToBoolean(this[nameof(Show_BTC)]);
            set => this[nameof(Show_BTC)] = value ? "true" : "false";
        }
        public bool PGN
        {
            get => Convert.ToBoolean(this[nameof(PGN)]);
            set => this[nameof(PGN)] = value ? "true" : "false";
        }
        public int Width_BTC
        {
            get => Convert.ToInt32(this["Width_BTC"]);
            set => this["Width_BTC"] = value.ToString();
        }
        public int BTC_X
        {
            get => Convert.ToInt32(this["BTC_X"]);
            set => this["BTC_X"] = value.ToString();
        }
        public int CheDoCapPhoi
        {
            get => Convert.ToInt32(this[nameof(CheDoCapPhoi)]);
            set => this[nameof(CheDoCapPhoi)] = value.ToString();
        }
        public bool Show_BTX
        {
            get => Convert.ToBoolean(this[nameof(Show_BTX)]);
            set => this[nameof(Show_BTX)] = value ? "true" : "false";
        }
        public int CapPhoiRes
        {
            get => Convert.ToInt32(this[nameof(CapPhoiRes)]);
            set => this[nameof(CapPhoiRes)] = value.ToString();
        }
        public bool Show_Funnel
        {
            get => Convert.ToBoolean(this[nameof(Show_Funnel)]);
            set => this[nameof(Show_Funnel)] = value ? "true" : "false";
        }
        public int SL_Silo_AGG
        {
            get => Convert.ToInt32(this["SL_Silo_AGG"]);
            set => this["SL_Silo_AGG"] = value.ToString();
        }
        public int SL_Silo_CE
        {
            get => Convert.ToInt32(this["SL_Silo_CE"]);
            set => this["SL_Silo_CE"] = value.ToString();
        }
        public int SL_Silo_WA
        {
            get => Convert.ToInt32(this["SL_Silo_WA"]);
            set => this["SL_Silo_WA"] = value.ToString();
        }
        public int SL_Silo_ADD
        {
            get => Convert.ToInt32(this["SL_Silo_ADD"]);
            set => this["SL_Silo_ADD"] = value.ToString();
        }
        public int SL_Wei_AGG
        {
            get => Convert.ToInt32(this["SL_Wei_AGG"]);
            set => this["SL_Wei_AGG"] = value.ToString();
        }
        public int SL_Wei_CE
        {
            get => Convert.ToInt32(this["SL_Wei_CE"]);
            set => this["SL_Wei_CE"] = value.ToString();
        }
        public int SL_Wei_WA
        {
            get => Convert.ToInt32(this["SL_Wei_WA"]);
            set => this["SL_Wei_WA"] = value.ToString();
        }
        public int SL_Wei_ADD
        {
            get => Convert.ToInt32(this["SL_Wei_ADD"]);
            set => this["SL_Wei_ADD"] = value.ToString();
        }
        public int Silo_CE_1_X
        {
            get => Convert.ToInt32(this["Silo_CE_1_X"]);
            set => this["Silo_CE_1_X"] = value.ToString();
        }
        public int Silo_CE_2_X
        {
            get => Convert.ToInt32(this["Silo_CE_2_X"]);
            set => this["Silo_CE_2_X"] = value.ToString();
        }
        public int Silo_CE_3_X
        {
            get => Convert.ToInt32(this["Silo_CE_3_X"]);
            set => this["Silo_CE_3_X"] = value.ToString();
        }
        public int Silo_CE_4_X
        {
            get => Convert.ToInt32(this["Silo_CE_4_X"]);
            set => this["Silo_CE_4_X"] = value.ToString();
        }
        public int Silo_CE_5_X
        {
            get => Convert.ToInt32(this["Silo_CE_5_X"]);
            set => this["Silo_CE_5_X"] = value.ToString();
        }
        public int Silo_WA_1_X
        {
            get => Convert.ToInt32(this["Silo_WA_1_X"]);
            set => this["Silo_WA_1_X"] = value.ToString();
        }
        public int Silo_WA_2_X
        {
            get => Convert.ToInt32(this["Silo_WA_2_X"]);
            set => this["Silo_WA_2_X"] = value.ToString();
        }
        public int Silo_ADD_1_X
        {
            get => Convert.ToInt32(this["Silo_ADD_1_X"]);
            set => this["Silo_ADD_1_X"] = value.ToString();
        }
        public int Silo_ADD_2_X
        {
            get => Convert.ToInt32(this["Silo_ADD_2_X"]);
            set => this["Silo_ADD_2_X"] = value.ToString();
        }
        public int Silo_ADD_3_X
        {
            get => Convert.ToInt32(this["Silo_ADD_3_X"]);
            set => this["Silo_ADD_3_X"] = value.ToString();
        }
        public int Silo_ADD_4_X
        {
            get => Convert.ToInt32(this["Silo_ADD_4_X"]);
            set => this["Silo_ADD_4_X"] = value.ToString();
        }
        public int Silo_ADD_5_X
        {
            get => Convert.ToInt32(this["Silo_ADD_5_X"]);
            set => this["Silo_ADD_5_X"] = value.ToString();
        }
        public int Silo_ADD_6_X
        {
            get => Convert.ToInt32(this["Silo_ADD_6_X"]);
            set => this["Silo_ADD_6_X"] = value.ToString();
        }
        public int Silo_AGG_1_X
        {
            get => Convert.ToInt32(this["Silo_AGG_1_X"]);
            set => this["Silo_AGG_1_X"] = value.ToString();
        }
        public int Silo_AGG_2_X
        {
            get => Convert.ToInt32(this["Silo_AGG_2_X"]);
            set => this["Silo_AGG_2_X"] = value.ToString();
        }
        public int Silo_AGG_3_X
        {
            get => Convert.ToInt32(this["Silo_AGG_3_X"]);
            set => this["Silo_AGG_3_X"] = value.ToString();
        }
        public int Silo_AGG_4_X
        {
            get => Convert.ToInt32(this["Silo_AGG_4_X"]);
            set => this["Silo_AGG_4_X"] = value.ToString();
        }
        public int Silo_AGG_5_X
        {
            get => Convert.ToInt32(this["Silo_AGG_5_X"]);
            set => this["Silo_AGG_5_X"] = value.ToString();
        }
        public int Silo_AGG_6_X
        {
            get => Convert.ToInt32(this["Silo_AGG_6_X"]);
            set => this["Silo_AGG_6_X"] = value.ToString();
        }
        public int Wei_CE_1_X
        {
            get => Convert.ToInt32(this["Wei_CE_1_X"]);
            set => this["Wei_CE_1_X"] = value.ToString();
        }
        public int Wei_CE_2_X
        {
            get => Convert.ToInt32(this["Wei_CE_2_X"]);
            set => this["Wei_CE_2_X"] = value.ToString();
        }
        public int Wei_WA_1_X
        {
            get => Convert.ToInt32(this["Wei_WA_1_X"]);
            set => this["Wei_WA_1_X"] = value.ToString();
        }
        public int Wei_WA_2_X
        {
            get => Convert.ToInt32(this["Wei_WA_2_X"]);
            set => this["Wei_WA_2_X"] = value.ToString();
        }
        public int Wei_ADD_1_X
        {
            get => Convert.ToInt32(this["Wei_ADD_1_X"]);
            set => this["Wei_ADD_1_X"] = value.ToString();
        }
        public int Wei_ADD_2_X
        {
            get => Convert.ToInt32(this["Wei_ADD_2_X"]);
            set => this["Wei_ADD_2_X"] = value.ToString();
        }
        public int Wei_AGG_1_X
        {
            get => Convert.ToInt32(this["Wei_AGG_1_X"]);
            set => this["Wei_AGG_1_X"] = value.ToString();
        }
        public int Wei_AGG_2_X
        {
            get => Convert.ToInt32(this["Wei_AGG_2_X"]);
            set => this["Wei_AGG_2_X"] = value.ToString();
        }
        public int Wei_AGG_3_X
        {
            get => Convert.ToInt32(this["Wei_AGG_3_X"]);
            set => this["Wei_AGG_3_X"] = value.ToString();
        }
        public int Wei_AGG_4_X
        {
            get => Convert.ToInt32(this["Wei_AGG_4_X"]);
            set => this["Wei_AGG_4_X"] = value.ToString();
        }
        public int Wei_AGG_5_X
        {
            get => Convert.ToInt32(this["Wei_AGG_5_X"]);
            set => this["Wei_AGG_5_X"] = value.ToString();
        }
        public int Wei_AGG_6_X
        {
            get => Convert.ToInt32(this["Wei_AGG_6_X"]);
            set => this["Wei_AGG_6_X"] = value.ToString();
        }


        public int Ce_X
        {
            get => Convert.ToInt32(this["CE_X"]);
            set => this["CE_X"] = value.ToString();
        }

        public int Wa_X
        {
            get => Convert.ToInt32(this["WA_X"]);
            set => this["WA_X"] = value.ToString();
        }

        public int Add_X
        {
            get => Convert.ToInt32(this["ADD_X"]);
            set => this["ADD_X"] = value.ToString();
        }

        public int Agg_X
        {
            get => Convert.ToInt32(this["AGG_X"]);
            set => this["AGG_X"] = value.ToString();
        }

        public int Ce_Y
        {
            get => Convert.ToInt32(this["CE_Y"]);
            set => this["CE_Y"] = value.ToString();
        }

        public int Wa_Y
        {
            get => Convert.ToInt32(this["WA_Y"]);
            set => this["WA_Y"] = value.ToString();
        }

        public int Add_Y
        {
            get => Convert.ToInt32(this["ADD_Y"]);
            set => this["ADD_Y"] = value.ToString();
        }

        public int Agg_Y
        {
            get => Convert.ToInt32(this["AGG_Y"]);
            set => this["AGG_Y"] = value.ToString();
        }

        public int Ce_Group_Width
        {
            get => Convert.ToInt32(this["CE_Group_Width"]);
            set => this["CE_Group_Width"] = value.ToString();
        }

        public int Wa_Group_Width
        {
            get => Convert.ToInt32(this["WA_Group_Width"]);
            set => this["WA_Group_Width"] = value.ToString();
        }

        public int Add_Group_Width
        {
            get => Convert.ToInt32(this["ADD_Group_Width"]);
            set => this["ADD_Group_Width"] = value.ToString();
        }

        public int Agg_Group_Width
        {
            get => Convert.ToInt32(this["AGG_Group_Width"]);
            set => this["AGG_Group_Width"] = value.ToString();
        }

        public string SkinStyle
        {
            get => this[nameof(SkinStyle)];
            set => this[nameof(SkinStyle)] = value;
        }

        public string NumericFormatString
        {
            get => this[nameof(NumericFormatString)];
            set => this[nameof(NumericFormatString)] = value;
        }

        public bool SimIsMoPhong
        {
            get => Convert.ToBoolean(this["SIM_IsMoPhong"]);
            set => this["SIM_IsMoPhong"] = value ? "true" : "false";
        }

        public Decimal SimCanAggValue
        {
            get => Decimal.Parse(this["SIM_CanAggValue"]);
            set => this["SIM_CanAggValue"] = value.ToString();
        }

        public Decimal SimCanCeValue
        {
            get => Decimal.Parse(this["SIM_CanCeValue"]);
            set => this["SIM_CanCeValue"] = value.ToString();
        }

        public Decimal SimCanWaValue
        {
            get => Decimal.Parse(this["SIM_CanWaValue"]);
            set => this["SIM_CanWaValue"] = value.ToString();
        }

        public Decimal SimCanAddValue
        {
            get => Decimal.Parse(this["SIM_CanAddValue"]);
            set => this["SIM_CanAddValue"] = value.ToString();
        }

        public Decimal SimCanAggNap
        {
            get => Decimal.Parse(this["SIM_CanAggNap"]);
            set => this["SIM_CanAggNap"] = value.ToString();
        }

        public Decimal SimCanCeNap
        {
            get => Decimal.Parse(this["SIM_CanCeNap"]);
            set => this["SIM_CanCeNap"] = value.ToString();
        }

        public Decimal SimCanWaNap
        {
            get => Decimal.Parse(this["SIM_CanWaNap"]);
            set => this["SIM_CanWaNap"] = value.ToString();
        }

        public Decimal SimCanAddNap
        {
            get => Decimal.Parse(this["SIM_CanAddNap"]);
            set => this["SIM_CanAddNap"] = value.ToString();
        }

        public Decimal SimCanAggXa
        {
            get => Decimal.Parse(this["SIM_CanAggXa"]);
            set => this["SIM_CanAggXa"] = value.ToString();
        }

        public Decimal SimCanCeXa
        {
            get => Decimal.Parse(this["SIM_CanCeXa"]);
            set => this["SIM_CanCeXa"] = value.ToString();
        }

        public Decimal SimCanWaXa
        {
            get => Decimal.Parse(this["SIM_CanWaXa"]);
            set => this["SIM_CanWaXa"] = value.ToString();
        }

        public Decimal SimCanAddXa
        {
            get => Decimal.Parse(this["SIM_CanAddXa"]);
            set => this["SIM_CanAddXa"] = value.ToString();
        }
        public bool InPITuMau
        {
            get => Convert.ToBoolean(this[nameof(InPITuMau)]);
            set => this[nameof(InPITuMau)] = value ? "true" : "false";
        }
        public string PIPath
        {
            get => this[nameof(PIPath)];
            set => this[nameof(PIPath)] = value;
        }
        public string PICTPath
        {
            get => this[nameof(PICTPath)];
            set => this[nameof(PICTPath)] = value;
        }
        public string PdfReaderPath
        {
            get => this[nameof(PdfReaderPath)];
            set => this[nameof(PdfReaderPath)] = value;
        }
        public string MayInPI
        {
            get => this[nameof(MayInPI)];
            set => this[nameof(MayInPI)] = value;
        }
        public string MayInPICT
        {
            get => this[nameof(MayInPICT)];
            set => this[nameof(MayInPICT)] = value;
        }
        public bool IsCanFixPGH
        {
            get => Convert.ToBoolean(this[nameof(IsCanFixPGH)]);
            set => this[nameof(IsCanFixPGH)] = value ? "true" : "false";
        }
        public bool IsCanFixPCT
        {
            get => Convert.ToBoolean(this[nameof(IsCanFixPCT)]);
            set => this[nameof(IsCanFixPCT)] = value ? "true" : "false";
        }
        /// <summary>
        /// //////////////////////
        /// </summary>
        public string Para01
        {
            get => this[nameof(Para01)];
            set => this[nameof(Para01)] = value;
        }

        public string Para02
        {
            get => this[nameof(Para02)];
            set => this[nameof(Para02)] = value;
        }

        public string Para03
        {
            get => this[nameof(Para03)];
            set => this[nameof(Para03)] = value;
        }

        public string Para04
        {
            get => this[nameof(Para04)];
            set => this[nameof(Para04)] = value;
        }

        public string Para05
        {
            get => this[nameof(Para05)];
            set => this[nameof(Para05)] = value;
        }

        public string Para06
        {
            get => this[nameof(Para06)];
            set => this[nameof(Para06)] = value;
        }

        public string Para07
        {
            get => this[nameof(Para07)];
            set => this[nameof(Para07)] = value;
        }

        public string Para08
        {
            get => this[nameof(Para08)];
            set => this[nameof(Para08)] = value;
        }

        public string Para09
        {
            get => this[nameof(Para09)];
            set => this[nameof(Para09)] = value;
        }

        public string Para10
        {
            get => this[nameof(Para10)];
            set => this[nameof(Para10)] = value;
        }

        public string Para11
        {
            get => this[nameof(Para11)];
            set => this[nameof(Para11)] = value;
        }

        public string Para12
        {
            get => this[nameof(Para12)];
            set => this[nameof(Para12)] = value;
        }

        public string Para13
        {
            get => this[nameof(Para13)];
            set => this[nameof(Para13)] = value;
        }

        public string Para14
        {
            get => this[nameof(Para14)];
            set => this[nameof(Para14)] = value;
        }

        public string Para15
        {
            get => this[nameof(Para15)];
            set => this[nameof(Para15)] = value;
        }
        //============
        // DataPrinter
        public bool TenChuTram_Stus
        {
            get => Convert.ToBoolean(this[nameof(TenChuTram_Stus)]);
            set => this[nameof(TenChuTram_Stus)] = value ? "true" : "false";
        }
        public int TenChuTram_X
        {
            get => Convert.ToInt32(this["TenChuTram_X"]);
            set => this["TenChuTram_X"] = value.ToString();
        }
        public int TenChuTram_Y
        {
            get => Convert.ToInt32(this["TenChuTram_Y"]);
            set => this["TenChuTram_Y"] = value.ToString();
        }
        public bool NgayTron_Stus
        {
            get => Convert.ToBoolean(this[nameof(NgayTron_Stus)]);
            set => this[nameof(NgayTron_Stus)] = value ? "true" : "false";
        }
        public int NgayTron_X
        {
            get => Convert.ToInt32(this["NgayTron_X"]);
            set => this["NgayTron_X"] = value.ToString();
        }
        public int NgayTron_Y
        {
            get => Convert.ToInt32(this["NgayTron_Y"]);
            set => this["NgayTron_Y"] = value.ToString();
        }
        public bool TenDuAn_Stus
        {
            get => Convert.ToBoolean(this[nameof(TenDuAn_Stus)]);
            set => this[nameof(TenDuAn_Stus)] = value ? "true" : "false";
        }
        public int TenDuAn_X
        {
            get => Convert.ToInt32(this["TenDuAn_X"]);
            set => this["TenDuAn_X"] = value.ToString();
        }
        public int TenDuAn_Y
        {
            get => Convert.ToInt32(this["TenDuAn_Y"]);
            set => this["TenDuAn_Y"] = value.ToString();
        }
        public bool TenKhachHang_Stus
        {
            get => Convert.ToBoolean(this[nameof(TenKhachHang_Stus)]);
            set => this[nameof(TenKhachHang_Stus)] = value ? "true" : "false";
        }
        public int TenKhachHang_X
        {
            get => Convert.ToInt32(this["TenKhachHang_X"]);
            set => this["TenKhachHang_X"] = value.ToString();
        }
        public int TenKhachHang_Y
        {
            get => Convert.ToInt32(this["TenKhachHang_Y"]);
            set => this["TenKhachHang_Y"] = value.ToString();
        }
        public bool TenMAC_Stus
        {
            get => Convert.ToBoolean(this[nameof(TenMAC_Stus)]);
            set => this[nameof(TenMAC_Stus)] = value ? "true" : "false";
        }
        public int TenMAC_X
        {
            get => Convert.ToInt32(this["TenMAC_X"]);
            set => this["TenMAC_X"] = value.ToString();
        }
        public int TenMAC_Y
        {
            get => Convert.ToInt32(this["TenMAC_Y"]);
            set => this["TenMAC_Y"] = value.ToString();
        }
        public bool CuongDo_Stus
        {
            get => Convert.ToBoolean(this[nameof(CuongDo_Stus)]);
            set => this[nameof(CuongDo_Stus)] = value ? "true" : "false";
        }
        public int CuongDo_X
        {
            get => Convert.ToInt32(this["CuongDo_X"]);
            set => this["CuongDo_X"] = value.ToString();
        }
        public int CuongDo_Y
        {
            get => Convert.ToInt32(this["CuongDo_Y"]);
            set => this["CuongDo_Y"] = value.ToString();
        }
        public bool SoPhieu_Stus
        {
            get => Convert.ToBoolean(this[nameof(SoPhieu_Stus)]);
            set => this[nameof(SoPhieu_Stus)] = value ? "true" : "false";
        }
        public int SoPhieu_X
        {
            get => Convert.ToInt32(this["SoPhieu_X"]);
            set => this["SoPhieu_X"] = value.ToString();
        }
        public int SoPhieu_Y
        {
            get => Convert.ToInt32(this["SoPhieu_Y"]);
            set => this["SoPhieu_Y"] = value.ToString();
        }
        public bool CotLieuMax_Stus
        {
            get => Convert.ToBoolean(this[nameof(CotLieuMax_Stus)]);
            set => this[nameof(CotLieuMax_Stus)] = value ? "true" : "false";
        }
        public int CotLieuMax_X
        {
            get => Convert.ToInt32(this["CotLieuMax_X"]);
            set => this["CotLieuMax_X"] = value.ToString();
        }
        public int CotLieuMax_Y
        {
            get => Convert.ToInt32(this["CotLieuMax_Y"]);
            set => this["CotLieuMax_Y"] = value.ToString();
        }
        public bool DoSut_Stus
        {
            get => Convert.ToBoolean(this[nameof(DoSut_Stus)]);
            set => this[nameof(DoSut_Stus)] = value ? "true" : "false";
        }
        public int DoSut_X
        {
            get => Convert.ToInt32(this["DoSut_X"]);
            set => this["DoSut_X"] = value.ToString();
        }
        public int DoSut_Y
        {
            get => Convert.ToInt32(this["DoSut_Y"]);
            set => this["DoSut_Y"] = value.ToString();
        }
        public bool LaiXe_Stus
        {
            get => Convert.ToBoolean(this[nameof(LaiXe_Stus)]);
            set => this[nameof(LaiXe_Stus)] = value ? "true" : "false";
        }
        public int LaiXe_X
        {
            get => Convert.ToInt32(this["LaiXe_X"]);
            set => this["LaiXe_X"] = value.ToString();
        }
        public int LaiXe_Y
        {
            get => Convert.ToInt32(this["LaiXe_Y"]);
            set => this["LaiXe_Y"] = value.ToString();
        }
        public bool TheTichXeTron_Stus
        {
            get => Convert.ToBoolean(this[nameof(TheTichXeTron_Stus)]);
            set => this[nameof(TheTichXeTron_Stus)] = value ? "true" : "false";
        }
        public int TheTichXeTron_X
        {
            get => Convert.ToInt32(this["TheTichXeTron_X"]);
            set => this["TheTichXeTron_X"] = value.ToString();
        }
        public int TheTichXeTron_Y
        {
            get => Convert.ToInt32(this["TheTichXeTron_Y"]);
            set => this["TheTichXeTron_Y"] = value.ToString();
        }
        public bool TheTichDatHang_Stus
        {
            get => Convert.ToBoolean(this[nameof(TheTichDatHang_Stus)]);
            set => this[nameof(TheTichDatHang_Stus)] = value ? "true" : "false";
        }
        public int TheTichDatHang_X
        {
            get => Convert.ToInt32(this["TheTichDatHang_X"]);
            set => this["TheTichDatHang_X"] = value.ToString();
        }
        public int TheTichDatHang_Y
        {
            get => Convert.ToInt32(this["TheTichDatHang_Y"]);
            set => this["TheTichDatHang_Y"] = value.ToString();
        }
        public bool LuyKe_Stus
        {
            get => Convert.ToBoolean(this[nameof(LuyKe_Stus)]);
            set => this[nameof(LuyKe_Stus)] = value ? "true" : "false";
        }
        public int LuyKe_X
        {
            get => Convert.ToInt32(this["LuyKe_X"]);
            set => this["LuyKe_X"] = value.ToString();
        }
        public int LuyKe_Y
        {
            get => Convert.ToInt32(this["LuyKe_Y"]);
            set => this["LuyKe_Y"] = value.ToString();
        }
        public bool BienSo_Stus
        {
            get => Convert.ToBoolean(this[nameof(BienSo_Stus)]);
            set => this[nameof(BienSo_Stus)] = value ? "true" : "false";
        }
        public int BienSo_X
        {
            get => Convert.ToInt32(this["BienSo_X"]);
            set => this["BienSo_X"] = value.ToString();
        }
        public int BienSo_Y
        {
            get => Convert.ToInt32(this["BienSo_Y"]);
            set => this["BienSo_Y"] = value.ToString();
        }
        public bool TGBatDau_Stus
        {
            get => Convert.ToBoolean(this[nameof(TGBatDau_Stus)]);
            set => this[nameof(TGBatDau_Stus)] = value ? "true" : "false";
        }
        public int TGBatDau_X
        {
            get => Convert.ToInt32(this["TGBatDau_X"]);
            set => this["TGBatDau_X"] = value.ToString();
        }
        public int TGBatDau_Y
        {
            get => Convert.ToInt32(this["TGBatDau_Y"]);
            set => this["TGBatDau_Y"] = value.ToString();
        }
        public bool TGKetThuc_Stus
        {
            get => Convert.ToBoolean(this[nameof(TGKetThuc_Stus)]);
            set => this[nameof(TGKetThuc_Stus)] = value ? "true" : "false";
        }
        public int TGKetThuc_X
        {
            get => Convert.ToInt32(this["TGKetThuc_X"]);
            set => this["TGKetThuc_X"] = value.ToString();
        }
        public int TGKetThuc_Y
        {
            get => Convert.ToInt32(this["TGKetThuc_Y"]);
            set => this["TGKetThuc_Y"] = value.ToString();
        }
        public bool DiaDiemDuAn_Stus
        {
            get => Convert.ToBoolean(this[nameof(DiaDiemDuAn_Stus)]);
            set => this[nameof(DiaDiemDuAn_Stus)] = value ? "true" : "false";
        }
        public int DiaDiemDuAn_X
        {
            get => Convert.ToInt32(this["DiaDiemDuAn_X"]);
            set => this["DiaDiemDuAn_X"] = value.ToString();
        }
        public int DiaDiemDuAn_Y
        {
            get => Convert.ToInt32(this["DiaDiemDuAn_Y"]);
            set => this["DiaDiemDuAn_Y"] = value.ToString();
        }
        public bool MaPhieu_Stus
        {
            get => Convert.ToBoolean(this[nameof(MaPhieu_Stus)]);
            set => this[nameof(MaPhieu_Stus)] = value ? "true" : "false";
        }
        public int MaPhieu_X
        {
            get => Convert.ToInt32(this["MaPhieu_X"]);
            set => this["MaPhieu_X"] = value.ToString();
        }
        public int MaPhieu_Y
        {
            get => Convert.ToInt32(this["MaPhieu_Y"]);
            set => this["MaPhieu_Y"] = value.ToString();
        }
        public bool TheTich1MeTron_Stus
        {
            get => Convert.ToBoolean(this[nameof(TheTich1MeTron_Stus)]);
            set => this[nameof(TheTich1MeTron_Stus)] = value ? "true" : "false";
        }
        public int TheTich1MeTron_X
        {
            get => Convert.ToInt32(this["TheTich1MeTron_X"]);
            set => this["TheTich1MeTron_X"] = value.ToString();
        }
        public int TheTich1MeTron_Y
        {
            get => Convert.ToInt32(this["TheTich1MeTron_Y"]);
            set => this["TheTich1MeTron_Y"] = value.ToString();
        }
        public bool TenHangMuc_Stus
        {
            get => Convert.ToBoolean(this[nameof(TenHangMuc_Stus)]);
            set => this[nameof(TenHangMuc_Stus)] = value ? "true" : "false";
        }
        public int TenHangMuc_X
        {
            get => Convert.ToInt32(this["TenHangMuc_X"]);
            set => this["TenHangMuc_X"] = value.ToString();
        }
        public int TenHangMuc_Y
        {
            get => Convert.ToInt32(this["TenHangMuc_Y"]);
            set => this["TenHangMuc_Y"] = value.ToString();
        }
        public bool SoNiemChi_Stus
        {
            get => Convert.ToBoolean(this[nameof(SoNiemChi_Stus)]);
            set => this[nameof(SoNiemChi_Stus)] = value ? "true" : "false";
        }
        public int SoNiemChi_X
        {
            get => Convert.ToInt32(this["SoNiemChi_X"]);
            set => this["SoNiemChi_X"] = value.ToString();
        }
        public int SoNiemChi_Y
        {
            get => Convert.ToInt32(this["SoNiemChi_Y"]);
            set => this["SoNiemChi_Y"] = value.ToString();
        }
        public bool NhanVien_Stus
        {
            get => Convert.ToBoolean(this[nameof(NhanVien_Stus)]);
            set => this[nameof(NhanVien_Stus)] = value ? "true" : "false";
        }
        public int NhanVien_X
        {
            get => Convert.ToInt32(this["NhanVien_X"]);
            set => this["NhanVien_X"] = value.ToString();
        }
        public int NhanVien_Y
        {
            get => Convert.ToInt32(this["NhanVien_Y"]);
            set => this["NhanVien_Y"] = value.ToString();
        }
        public DateTime TimeLife
        {
            get => DateTime.Parse(this[nameof(TimeLife)]);
            set => this[nameof(TimeLife)] = value.ToString();
        }
        public Decimal Trial 
        {
            get => Decimal.Parse(this[nameof(Trial)]);
            set => this[nameof(Trial)] = value.ToString();
        }
        public string BcMix
        {
            get => this[nameof(BcMix)];
            set => this[nameof(BcMix)] = value;
        }
        public string TrcMix
        {
            get => this[nameof(TrcMix)];
            set => this[nameof(TrcMix)] = value;
        }
        public TramTronConfig()
          : base("TramTronConfig.xml", "/configuration/TramTron")
        {
        }
        // ChinhCan
        public string KL_ZERO_AGG1
        {
            get => this[nameof(KL_ZERO_AGG1)];
            set => this[nameof(KL_ZERO_AGG1)] = value;
        }
        public string KL_SPAN_AGG1
        {
            get => this[nameof(KL_SPAN_AGG1)];
            set => this[nameof(KL_SPAN_AGG1)] = value;
        }
        public string KL_ZERO_AGG2
        {
            get => this[nameof(KL_ZERO_AGG2)];
            set => this[nameof(KL_ZERO_AGG2)] = value;
        }
        public string KL_SPAN_AGG2
        {
            get => this[nameof(KL_SPAN_AGG2)];
            set => this[nameof(KL_SPAN_AGG2)] = value;
        }
        public string KL_ZERO_AGG3
        {
            get => this[nameof(KL_ZERO_AGG3)];
            set => this[nameof(KL_ZERO_AGG3)] = value;
        }
        public string KL_SPAN_AGG3
        {
            get => this[nameof(KL_SPAN_AGG3)];
            set => this[nameof(KL_SPAN_AGG3)] = value;
        }
        public string KL_ZERO_AGG4
        {
            get => this[nameof(KL_ZERO_AGG4)];
            set => this[nameof(KL_ZERO_AGG4)] = value;
        }
        public string KL_SPAN_AGG4
        {
            get => this[nameof(KL_SPAN_AGG4)];
            set => this[nameof(KL_SPAN_AGG4)] = value;
        }
        public string KL_ZERO_AGG5
        {
            get => this[nameof(KL_ZERO_AGG5)];
            set => this[nameof(KL_ZERO_AGG5)] = value;
        }
        public string KL_SPAN_AGG5
        {
            get => this[nameof(KL_SPAN_AGG5)];
            set => this[nameof(KL_SPAN_AGG5)] = value;
        }
        public string KL_ZERO_AGG6
        {
            get => this[nameof(KL_ZERO_AGG6)];
            set => this[nameof(KL_ZERO_AGG6)] = value;
        }
        public string KL_SPAN_AGG6
        {
            get => this[nameof(KL_SPAN_AGG6)];
            set => this[nameof(KL_SPAN_AGG6)] = value;
        }
        public string KL_ZERO_CEM1
        {
            get => this[nameof(KL_ZERO_CEM1)];
            set => this[nameof(KL_ZERO_CEM1)] = value;
        }
        public string KL_SPAN_CEM1
        {
            get => this[nameof(KL_SPAN_CEM1)];
            set => this[nameof(KL_SPAN_CEM1)] = value;
        }
        public string KL_ZERO_CEM2
        {
            get => this[nameof(KL_ZERO_CEM2)];
            set => this[nameof(KL_ZERO_CEM2)] = value;
        }
        public string KL_SPAN_CEM2
        {
            get => this[nameof(KL_SPAN_CEM2)];
            set => this[nameof(KL_SPAN_CEM2)] = value;
        }
        public string KL_ZERO_WA1
        {
            get => this[nameof(KL_ZERO_WA1)];
            set => this[nameof(KL_ZERO_WA1)] = value;
        }
        public string KL_SPAN_WA1
        {
            get => this[nameof(KL_SPAN_WA1)];
            set => this[nameof(KL_SPAN_WA1)] = value;
        }
        public string KL_ZERO_WA2
        {
            get => this[nameof(KL_ZERO_WA2)];
            set => this[nameof(KL_ZERO_WA2)] = value;
        }
        public string KL_SPAN_WA2
        {
            get => this[nameof(KL_SPAN_WA2)];
            set => this[nameof(KL_SPAN_WA2)] = value;
        }
        public string KL_ZERO_ADD1
        {
            get => this[nameof(KL_ZERO_ADD1)];
            set => this[nameof(KL_ZERO_ADD1)] = value;
        }
        public string KL_SPAN_ADD1
        {
            get => this[nameof(KL_SPAN_ADD1)];
            set => this[nameof(KL_SPAN_ADD1)] = value;
        }
        public string KL_ZERO_ADD2
        {
            get => this[nameof(KL_ZERO_ADD2)];
            set => this[nameof(KL_ZERO_ADD2)] = value;
        }
        public string KL_SPAN_ADD2
        {
            get => this[nameof(KL_SPAN_ADD2)];
            set => this[nameof(KL_SPAN_ADD2)] = value;
        }
        // Change PRODUCT
        public string NameProduct
        {
            get => this[nameof(NameProduct)];
            set => this[nameof(NameProduct)] = value;
        }

        public string LocalProduct
        {
            get => this[nameof(LocalProduct)];
            set => this[nameof(LocalProduct)] = value;
        }

        public string PhoneProduct
        {
            get => this[nameof(PhoneProduct)];
            set => this[nameof(PhoneProduct)] = value;
        }

        public string LogoProduct
        {
            get => this[nameof(LogoProduct)];
            set => this[nameof(LogoProduct)] = value;
        }


        public bool GetCommandEnable(string strEntryKey) => this.Attributes["Command", "Code", strEntryKey, "Enable"] == "1";

        public void SetCommandEnable(string strEntryKey, bool value)
        {
            string str = value ? "1" : "0";
            this.Attributes["IdSaveCan", "Can", strEntryKey, "IdSave"] = str;
        }

        public int GetIdSaveCan(string strEntryKey) => Convert.ToInt32(this.Attributes["IdSaveCan", "Can", strEntryKey, "IdSave"]);

        public void SetIdSaveCan(string strEntryKey, int value) => this.Attributes["IdSaveCan", "Can", strEntryKey, "IdSave"] = value.ToString();

        public Decimal GetHCC_LO_AI(string strEntryKey) => Convert.ToDecimal(this.Attributes["HieuChuanCan", "SiloType", strEntryKey, "Lo_AI"]);

        public void SetHCC_LO_AI(string strEntryKey, Decimal value) => this.Attributes["HieuChuanCan", "SiloType", strEntryKey, "Lo_AI"] = value.ToString();

        public Decimal GetHCC_HI_AI(string strEntryKey) => Convert.ToDecimal(this.Attributes["HieuChuanCan", "SiloType", strEntryKey, "Hi_AI"]);

        public void SetHCC_HI_AI(string strEntryKey, Decimal value) => this.Attributes["HieuChuanCan", "SiloType", strEntryKey, "Hi_AI"] = value.ToString();

        public Decimal GetHCC_LO_WEIGH(string strEntryKey) => Convert.ToDecimal(this.Attributes["HieuChuanCan", "SiloType", strEntryKey, "Lo_Weigh"]);

        public void SetHCC_LO_WEIGH(string strEntryKey, Decimal value) => this.Attributes["HieuChuanCan", "SiloType", strEntryKey, "Lo_Weigh"] = value.ToString();

        public Decimal GetHCC_HI_WEIGH(string strEntryKey) => Convert.ToDecimal(this.Attributes["HieuChuanCan", "SiloType", strEntryKey, "Hi_Weigh"]);

        public void SetHCC_HI_WEIGH(string strEntryKey, Decimal value) => this.Attributes["HieuChuanCan", "SiloType", strEntryKey, "Hi_Weigh"] = value.ToString();

        public bool GetActMandatory(string strEntryKey) => this.Attributes["Action", "ActionType", strEntryKey, "Mandatory"] == "yes";

        public void SetActMandatory(string strEntryKey, bool blnValue)
        {
            string str = blnValue ? "yes" : string.Empty;
            this.Attributes["Action", "ActionType", strEntryKey, "Mandatory"] = str;
        }

        public bool GetActVisible(string strEntryKey) => this.Attributes["Action", "ActionType", strEntryKey, "Visible"] == "yes";

        public void SetActVisible(string strEntryKey, bool blnValue)
        {
            string str = blnValue ? "yes" : string.Empty;
            this.Attributes["Action", "ActionType", strEntryKey, "Visible"] = str;
        }

        public bool GetActEnable(string strEntryKey) => this.Attributes["Action", "ActionType", strEntryKey, "Enable"] == "yes";

        public void SetActEnable(string strEntryKey, bool blnValue)
        {
            string str = blnValue ? "yes" : string.Empty;
            this.Attributes["Action", "ActionType", strEntryKey, "Enable"] = str;
        }

        public string GetActDisplay(string strEntryKey) => this.Attributes["Action", "ActionType", strEntryKey, "Display"];

        public void SetActDisplay(string strEntryKey, string strValue) => this.Attributes["Action", "ActionType", strEntryKey, "Display"] = strValue;

        public int GetActIndex(string strEntryKey) => Convert.ToInt32(this.Attributes["Action", "ActionType", strEntryKey, "Index"]);

        public void SetActIndex(string strEntryKey, int intValue) => this.Attributes["Action", "ActionType", strEntryKey, "Index"] = intValue.ToString();
    }
}
