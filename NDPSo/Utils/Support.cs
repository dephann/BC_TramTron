using DevExpress.XtraEditors;
using NDPSo.Data;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace NDPSo.Utils
{
    public class Support
    {
        public static string GetNextNiemChi(string inputString)
        {
            string resultString = "";
            string numericPart = new string(inputString.SkipWhile(c => c == '0').ToArray());

            if (int.TryParse(numericPart, out int intValue))
            {
                intValue++;

                resultString = new string('0', inputString.Length - numericPart.Length) + intValue.ToString();

                return resultString;

            }
            else
            {
                return resultString;
            }
        }

        public static void GetListSiloLogic(BindingList<ObjSilo> _blstSiloLogic, BindingList<ObjSilo> _blstSiloLogic1, LookUpEdit lue1, LookUpEdit lue2)
        {
            _blstSiloLogic1.Clear();
            foreach (ObjSilo siloLogic in _blstSiloLogic)
            {
                if (siloLogic.SiloID != (int)lue1.EditValue)
                {
                    _blstSiloLogic1.Add(siloLogic);
                }
            }
            lue2.Properties.DataSource = _blstSiloLogic1;
        }
        public static void GetListSiloLogic(BindingList<ObjSilo> _blstSiloLogic, LookUpEdit lue1)
        {
            BindingList<ObjSilo> _list = new BindingList<ObjSilo>();
            foreach (ObjSilo siloLogic in _blstSiloLogic)
            {
                if (siloLogic.SiloID != (int)lue1.EditValue)
                {
                    _list.Add(siloLogic);
                }
            }
            _blstSiloLogic.Clear();
            _blstSiloLogic = _list;
        }

        public static void UpdateListSiloLogic(BindingList<ObjSilo> _blstSiloLogic, string maSilo)
        {
            BindingList<ObjSilo> _list = new BindingList<ObjSilo>();
            foreach (ObjSilo siloLogic in _blstSiloLogic)
            {
                if (siloLogic.MaSilo == maSilo)
                {
                    //return;
                    //continue;
                }
                else
                 _list.Add(siloLogic);
            } 
            _blstSiloLogic.Clear();
            foreach(ObjSilo silo in _list)
            {
                _blstSiloLogic.Add(silo);
            }
        }

        public static void SetValueSpinZero(SpinEdit spinEdit)
        {
            if (spinEdit != null && spinEdit.Value < 0)
            {
                spinEdit.Value = 0;
            }
        }
        public static void ResetValueLueLogic(LookUpEdit lue1, LookUpEdit lue2)
        {
            lue1.EditValue = (object)null;
            lue2.EditValue = (object)null;
        }

        public static double GetValueLogic(LookUpEdit lue1, LookUpEdit lue2, string nhomSilo)
        {
            double numlogic = 0;
            string _numberSiloLogic = "";

            if (!ValidateData(lue1, lue2))
            {
                return numlogic;
            }
            else
            {
                switch (nhomSilo)
                {
                    case "AG":
                        _numberSiloLogic = GetNumLogicSiloAG(lue1).ToString() + GetNumLogicSiloAG(lue2).ToString();
                        break;
                    case "CE":
                        _numberSiloLogic = GetNumLogicSiloCE(lue1).ToString() + GetNumLogicSiloCE(lue2).ToString();
                        break;
                    case "AD":
                        _numberSiloLogic = GetNumLogicSiloAD(lue1).ToString() + GetNumLogicSiloAD(lue2).ToString();
                        break;
                }
                string a = _numberSiloLogic;
                numlogic = double.Parse(a);
                return  numlogic;
            }
        }
        private static bool ValidateData(LookUpEdit lue1, LookUpEdit lue2)
        {
            bool flag = true;
            if (lue1.EditValue == null)
            {
                lue1.ErrorText = "Silo is requied";
                flag = false;
            }
            if (lue2.EditValue == null)
            {
                lue2.ErrorText = "Silo is requied";
                flag = false;
            }
            return flag;
        }
        private static int GetNumLogicSiloAG(LookUpEdit lueSiloLogic)
        {
            int a = 0;
            string maSilo = lueSiloLogic.GetColumnValue("MaSilo").ToString();
            switch (maSilo)
            {
                case "Agg1":
                    a = 1;
                    break;
                case "Agg2":
                    a = 2;
                    break;
                case "Agg3":
                    a = 3;
                    break;
                case "Agg4":
                    a = 4;
                    break;
                case "Agg5":
                    a = 5;
                    break;
                case "Agg6":
                    a = 6;
                    break;
                default:
                    break;
            }
            return a;
        }
        private static int GetNumLogicSiloCE(LookUpEdit lueSiloLogic)
        {
            int a = 0;
            string maSilo = lueSiloLogic.GetColumnValue("MaSilo").ToString();
            switch (maSilo)
            {
                case "Ce1":
                    a = 1;
                    break;
                case "Ce2":
                    a = 2;
                    break;
                case "Ce3":
                    a = 3;
                    break;
                case "Ce4":
                    a = 4;
                    break;
                case "Ce5":
                    a = 5;
                    break;
                default:
                    break;
            }
            return a;
        }
        private static int GetNumLogicSiloAD(LookUpEdit lueSiloLogic)
        {
            int a = 0;
            string maSilo = lueSiloLogic.GetColumnValue("MaSilo").ToString();
            switch (maSilo)
            {
                case "Add1":
                    a = 1;
                    break;
                case "Add2":
                    a = 2;
                    break;
                case "Add3":
                    a = 3;
                    break;
                case "Add4":
                    a = 4;
                    break;
                case "Add5":
                    a = 5;
                    break;
                case "Add6":
                    a = 6;
                    break;
                default:
                    break;
            }
            return a;
        }

        public static double SetUpLogic(LookUpEdit lue1, LookUpEdit lue2, string nhomSilo)
        {
            if (lue1.Text == string.Empty || lue2.Text == string.Empty)
            {
                return GetValueLogic(lue1, lue2, nhomSilo);
                TramTromMessageBox.ShowMessageDialog("Đã đưa LOGIC về trạng thái ban đầu.");
            }
            else
            {
                string str1 = lue1.Text.ToString();
                string str2 = lue2.Text.ToString();
                string str = string.Format("Xác nhận thực hiện thiết lập {0} - LOGIC - {1} ?", str1, str2);

                if (TramTromMessageBox.ShowYesNoDialog(str) != DialogResult.Yes)
                    return 0;
                return GetValueLogic(lue1, lue2, nhomSilo);
            }
        }

        public static bool CheckSiloLogic(BindingList<ObjSilo> bllst, string maSilo)
        {
            bool flag = true;
            foreach (ObjSilo silo in bllst)
            {
                if (silo.MaSilo != maSilo)
                    flag = false;
            }
            return flag;
        }

        public static string SecondToHour(int sec)
        {
            int hours = sec / 3600; 
            int minutes = (sec % 3600) / 60;
            int seconds = sec % 60;
            string timer = "PHẦN MỀM SẼ TỰ ĐỘNG CẬP NHẬT SAU: " + $"{hours} Giờ, {minutes} Phút, {seconds} Giây";
            return timer;
        }

        public static void PrintReport(string path)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    Verb = "print",
                    FileName = path,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                });
            }
            catch (Exception ex)
            {
                TramTromMessageBox.ShowErrorDialog(ex.ToString());
            }
        }
    }
}
