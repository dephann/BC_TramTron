using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using NDPSo.Data;
using NDPSo.MasterData.Config;
using NDPSo.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDPSo.MasterData
{
    public partial class ConfigUIMngView : ControlViewBase, IConfigUIMngView, IBase, IPermission
    {
        private ConfigUIMngDataPresenter _presenter;
        private bool isDragging;
        private Point offset;

        private BindingList<ObjSilo> _blstSiloConfig_Agg= new BindingList<ObjSilo>();
        private BindingList<ObjSilo> _blstSiloConfig_Ce= new BindingList<ObjSilo>();
        private BindingList<ObjSilo> _blstSiloConfig_Wa= new BindingList<ObjSilo>();
        private BindingList<ObjSilo> _blstSiloConfig_Add= new BindingList<ObjSilo>();
        public BindingList<ObjNhomSilo> BLstNhomSilo { set => throw new NotImplementedException(); }
        public bool IsSuccessfulSave { set => this.SuccessfullySave(value); }
        
        private void SuccessfullySave(bool isSuccess)
        {
            if (isSuccess)
            {
                this.IsSuccess = true;
                //this._dlgRes = DialogResult.OK;
                this.Close();
            }
            else
            {
                TramTromMessageBox.ShowErrorDialog(GlobalValues.Messages.UnsuccessProceed);
            }
        }
        private void SuccessfullySaved(bool isSuccess)
        {
            if (isSuccess)
            {
                //this._dlgRes = DialogResult.OK;
            }
            else
            {
                TramTromMessageBox.ShowErrorDialog(GlobalValues.Messages.UnsuccessProceed);
            }
        }
        public BindingList<ObjSilo> BLstSilo_Agg 
        {
            set
            {
                this._blstSiloConfig_Agg = value;
            } 
        }
        public BindingList<ObjSilo> BLstSilo_Ce 
        {
            set
            {
                this._blstSiloConfig_Ce = value;
            }
        }
        public BindingList<ObjSilo> BLstSilo_Wa 
        {
            set
            {
                this._blstSiloConfig_Wa = value;
            }
        }
        public BindingList<ObjSilo> BLstSilo_Add 
        {
            set
            {
                this._blstSiloConfig_Add = value;
            }
        }

        public bool IsSuccessfulSaved 
        { 
            set
            {
                SuccessfullySaved(value);
            }
        }

        public ConfigUIMngView()
        {
            InitializeComponent();
            this._presenter = new ConfigUIMngDataPresenter((IConfigUIMngView)this);
            LoadData();
            this.Caption = "Cấu hình giao diện";

        }

        protected override void PopulateData()
        {
            try
            {
                CreateSilo_AGG(ConfigManager.TramTronConfig.SL_Silo_AGG);
                CreateSilo_CE(ConfigManager.TramTronConfig.SL_Silo_CE);
                CreateSilo_WA(ConfigManager.TramTronConfig.SL_Silo_WA);
                CreateSilo_ADD(ConfigManager.TramTronConfig.SL_Silo_ADD);

                CreateWei_AGG(ConfigManager.TramTronConfig.SL_Wei_AGG);
                CreateWei_CE(ConfigManager.TramTronConfig.SL_Wei_CE);
                CreateWei_WA(ConfigManager.TramTronConfig.SL_Wei_WA);
                CreateWei_ADD(ConfigManager.TramTronConfig.SL_Wei_ADD);

                silo_Agg1.ToaDoX = ConfigManager.TramTronConfig.Silo_AGG_1_X.ToString();
                silo_Agg2.ToaDoX = ConfigManager.TramTronConfig.Silo_AGG_2_X.ToString();
                silo_Agg3.ToaDoX = ConfigManager.TramTronConfig.Silo_AGG_3_X.ToString();
                silo_Agg4.ToaDoX = ConfigManager.TramTronConfig.Silo_AGG_4_X.ToString();
                silo_Agg5.ToaDoX = ConfigManager.TramTronConfig.Silo_AGG_5_X.ToString();
                silo_Agg6.ToaDoX = ConfigManager.TramTronConfig.Silo_AGG_6_X.ToString();

                silo_Ce1.ToaDoX = ConfigManager.TramTronConfig.Silo_CE_1_X.ToString();
                silo_Ce2.ToaDoX = ConfigManager.TramTronConfig.Silo_CE_2_X.ToString();
                silo_Ce3.ToaDoX = ConfigManager.TramTronConfig.Silo_CE_3_X.ToString();
                silo_Ce4.ToaDoX = ConfigManager.TramTronConfig.Silo_CE_4_X.ToString();
                silo_Ce5.ToaDoX = ConfigManager.TramTronConfig.Silo_CE_5_X.ToString();

                silo_Wa1.ToaDoX = ConfigManager.TramTronConfig.Silo_WA_1_X.ToString();
                silo_Wa2.ToaDoX = ConfigManager.TramTronConfig.Silo_WA_2_X.ToString();

                silo_Add1.ToaDoX = ConfigManager.TramTronConfig.Silo_ADD_1_X.ToString();
                silo_Add2.ToaDoX = ConfigManager.TramTronConfig.Silo_ADD_2_X.ToString();
                silo_Add3.ToaDoX = ConfigManager.TramTronConfig.Silo_ADD_3_X.ToString();
                silo_Add4.ToaDoX = ConfigManager.TramTronConfig.Silo_ADD_4_X.ToString();
                silo_Add5.ToaDoX = ConfigManager.TramTronConfig.Silo_ADD_5_X.ToString();
                silo_Add6.ToaDoX = ConfigManager.TramTronConfig.Silo_ADD_6_X.ToString();

                wei_Agg1.ToaDoX = ConfigManager.TramTronConfig.Wei_AGG_1_X;
                wei_Agg2.ToaDoX = ConfigManager.TramTronConfig.Wei_AGG_2_X;
                wei_Agg3.ToaDoX = ConfigManager.TramTronConfig.Wei_AGG_3_X;
                wei_Agg4.ToaDoX = ConfigManager.TramTronConfig.Wei_AGG_4_X;
                wei_Agg5.ToaDoX = ConfigManager.TramTronConfig.Wei_AGG_5_X;
                wei_Agg6.ToaDoX = ConfigManager.TramTronConfig.Wei_AGG_6_X;

                wei_Ce1.ToaDoX = ConfigManager.TramTronConfig.Wei_CE_1_X;
                wei_Ce2.ToaDoX = ConfigManager.TramTronConfig.Wei_CE_2_X;

                wei_Wa1.ToaDoX = ConfigManager.TramTronConfig.Wei_WA_1_X;
                wei_Wa2.ToaDoX = ConfigManager.TramTronConfig.Wei_WA_2_X;

                wei_Add1.ToaDoX = ConfigManager.TramTronConfig.Wei_ADD_1_X;
                wei_Add2.ToaDoX = ConfigManager.TramTronConfig.Wei_ADD_2_X;

                this.lue_Silo_Agg.EditValue = (object)ConfigManager.TramTronConfig.SL_Silo_AGG;
                this.lue_Silo_Ce.EditValue = (object)ConfigManager.TramTronConfig.SL_Silo_CE;
                this.lue_Silo_Wa.EditValue = (object)ConfigManager.TramTronConfig.SL_Silo_WA;
                this.lue_Silo_Add.EditValue = (object)ConfigManager.TramTronConfig.SL_Silo_ADD;
                this.lue_Wei_Agg.EditValue = (object)ConfigManager.TramTronConfig.SL_Wei_AGG;
                this.lue_Wei_Ce.EditValue = (object)ConfigManager.TramTronConfig.SL_Wei_CE;
                this.lue_Wei_Wa.EditValue = (object)ConfigManager.TramTronConfig.SL_Wei_WA;
                this.lue_Wei_Add.EditValue = (object)ConfigManager.TramTronConfig.SL_Wei_ADD;
                this.rdgCapPhoiRes.SelectedIndex = ConfigManager.TramTronConfig.CapPhoiRes;

                this.silo_Agg1.Location = new  Point(ConfigManager.TramTronConfig.Silo_AGG_1_X, this.silo_Agg1.Location.Y);
                this.silo_Agg2.Location = new  Point(ConfigManager.TramTronConfig.Silo_AGG_2_X, this.silo_Agg2.Location.Y);
                this.silo_Agg3.Location = new  Point(ConfigManager.TramTronConfig.Silo_AGG_3_X, this.silo_Agg3.Location.Y);
                this.silo_Agg4.Location = new  Point(ConfigManager.TramTronConfig.Silo_AGG_4_X, this.silo_Agg4.Location.Y);
                this.silo_Agg5.Location = new  Point(ConfigManager.TramTronConfig.Silo_AGG_5_X, this.silo_Agg5.Location.Y);
                this.silo_Agg6.Location = new  Point(ConfigManager.TramTronConfig.Silo_AGG_6_X, this.silo_Agg6.Location.Y);
                this.silo_Ce1.Location = new  Point(ConfigManager.TramTronConfig.Silo_CE_1_X, this.silo_Ce1.Location.Y);
                this.silo_Ce2.Location = new  Point(ConfigManager.TramTronConfig.Silo_CE_2_X, this.silo_Ce2.Location.Y);
                this.silo_Ce3.Location = new  Point(ConfigManager.TramTronConfig.Silo_CE_3_X, this.silo_Ce3.Location.Y);
                this.silo_Ce4.Location = new  Point(ConfigManager.TramTronConfig.Silo_CE_4_X, this.silo_Ce4.Location.Y);
                this.silo_Ce5.Location = new  Point(ConfigManager.TramTronConfig.Silo_CE_5_X, this.silo_Ce5.Location.Y);
                this.silo_Wa1.Location = new  Point(ConfigManager.TramTronConfig.Silo_WA_1_X, this.silo_Wa1.Location.Y);
                this.silo_Wa2.Location = new  Point(ConfigManager.TramTronConfig.Silo_WA_2_X, this.silo_Wa2.Location.Y);
                this.silo_Add1.Location = new  Point(ConfigManager.TramTronConfig.Silo_ADD_1_X, this.silo_Add1.Location.Y);
                this.silo_Add2.Location = new  Point(ConfigManager.TramTronConfig.Silo_ADD_2_X, this.silo_Add2.Location.Y);
                this.silo_Add3.Location = new  Point(ConfigManager.TramTronConfig.Silo_ADD_3_X, this.silo_Add3.Location.Y);
                this.silo_Add4.Location = new  Point(ConfigManager.TramTronConfig.Silo_ADD_4_X, this.silo_Add4.Location.Y);
                this.silo_Add5.Location = new  Point(ConfigManager.TramTronConfig.Silo_ADD_5_X, this.silo_Add5.Location.Y);
                this.silo_Add6.Location = new  Point(ConfigManager.TramTronConfig.Silo_ADD_6_X, this.silo_Add6.Location.Y);

                this.wei_Agg1.Location = new  Point(ConfigManager.TramTronConfig.Wei_AGG_1_X, this.wei_Agg1.Location.Y);
                this.wei_Agg2.Location = new  Point(ConfigManager.TramTronConfig.Wei_AGG_2_X, this.wei_Agg2.Location.Y);
                this.wei_Agg3.Location = new  Point(ConfigManager.TramTronConfig.Wei_AGG_3_X, this.wei_Agg3.Location.Y);
                this.wei_Agg4.Location = new  Point(ConfigManager.TramTronConfig.Wei_AGG_4_X, this.wei_Agg4.Location.Y);
                this.wei_Agg5.Location = new  Point(ConfigManager.TramTronConfig.Wei_AGG_5_X, this.wei_Agg5.Location.Y);
                this.wei_Agg6.Location = new  Point(ConfigManager.TramTronConfig.Wei_AGG_6_X, this.wei_Agg6.Location.Y);
                this.wei_Ce1.Location = new  Point(ConfigManager.TramTronConfig.Wei_CE_1_X, this.wei_Ce1.Location.Y);
                this.wei_Ce2.Location = new  Point(ConfigManager.TramTronConfig.Wei_CE_2_X, this.wei_Ce2.Location.Y);
                this.wei_Wa1.Location = new  Point(ConfigManager.TramTronConfig.Wei_WA_1_X, this.wei_Wa1.Location.Y);
                this.wei_Wa2.Location = new  Point(ConfigManager.TramTronConfig.Wei_WA_2_X, this.wei_Wa2.Location.Y);
                this.wei_Add1.Location = new  Point(ConfigManager.TramTronConfig.Wei_ADD_1_X, this.wei_Add1.Location.Y);
                this.wei_Add2.Location = new  Point(ConfigManager.TramTronConfig.Wei_ADD_2_X, this.wei_Add2.Location.Y);

                this.ucBTC1.Visible = ConfigManager.TramTronConfig.Show_BTC;
                this.ucBTC1.Location = new Point(ConfigManager.TramTronConfig.BTC_X, this.ucBTC1.Location.Y);
                this.ucBTC1.ToaDoX = ConfigManager.TramTronConfig.BTC_X.ToString();
                this.spnWidthBTC.EditValue = ConfigManager.TramTronConfig.Width_BTC;
                this.funnel.Visible = ConfigManager.TramTronConfig.Show_Funnel;
                this.chk_BTC.Checked = ConfigManager.TramTronConfig.Show_BTC;
                this.chk_PGN.Checked = ConfigManager.TramTronConfig.PGN;
                this.chk_Funnel.Checked = ConfigManager.TramTronConfig.Show_Funnel;
                if (rdgCapPhoiRes.SelectedIndex == 0)
                {
                    this.ucBTXien1.Visible = true;
                    this.ucGauTai1.Visible = false;
                }
                else if (rdgCapPhoiRes.SelectedIndex == 1)
                {
                    this.ucBTXien1.Visible = false;
                    this.ucGauTai1.Visible = true;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
                TramTronLogger.WriteError(ex);
                TramTromMessageBox.ShowDEPErrorDialog(ex);
            }
        }

        protected override void PopulateStaticData()
        {
            lue_Silo_Agg.Properties.DataSource = (object)Converter.EnumToListFieldCode<silo_AGG>(false);
            lue_Silo_Ce.Properties.DataSource = (object)Converter.EnumToListFieldCode<silo_CE>(false);
            lue_Silo_Wa.Properties.DataSource = (object)Converter.EnumToListFieldCode<silo_WA>(false);
            lue_Silo_Add.Properties.DataSource = (object)Converter.EnumToListFieldCode<silo_ADD>(false);

            lue_Wei_Agg.Properties.DataSource = (object)Converter.EnumToListFieldCode<wei_AGG>(false);
            lue_Wei_Ce.Properties.DataSource = (object)Converter.EnumToListFieldCode<wei_CE>(false);
            lue_Wei_Wa.Properties.DataSource = (object)Converter.EnumToListFieldCode<wei_WA>(false);
            lue_Wei_Add.Properties.DataSource = (object)Converter.EnumToListFieldCode<wei_ADD>(false);
        }

        private void LoadData()
        {

        }
        private void lue_Silo_Agg_EditValueChanged(object sender, EventArgs e)
        {
            string selectedOption = lue_Silo_Agg.EditValue.ToString();
        }

        
        public enum silo_AGG
        {
            [Display(Name = "1 Silo")]
            Silo1 = 1,
            [Display(Name = "2 Silo")]
            Silo2 = 2,
            [Display(Name = "3 Silo")]
            Silo3 = 3,
            [Display(Name = "4 Silo")]
            Silo4 = 4,
            [Display(Name = "5 Silo")]
            Silo5 = 5,
            [Display(Name = "6 Silo")]
            Silo6 = 6
        }
        public enum silo_CE
        {
            [Display(Name = "1 Silo")]
            Silo1 = 1,
            [Display(Name = "2 Silo")]
            Silo2 = 2,
            [Display(Name = "3 Silo")]
            Silo3 = 3,
            [Display(Name = "4 Silo")]
            Silo4 = 4,
            [Display(Name = "5 Silo")]
            Silo5 = 5
        }
        public enum silo_WA
        {
            [Display(Name = "1 Silo")]
            Silo1 = 1,
            [Display(Name = "2 Silo")]
            Silo2 = 2
            
        }
        public enum silo_ADD
        {
            [Display(Name = "1 Silo")]
            Silo1 = 1,
            [Display(Name = "2 Silo")]
            Silo2 = 2,
            [Display(Name = "3 Silo")]
            Silo3 = 3,
            [Display(Name = "4 Silo")]
            Silo4 = 4,
            [Display(Name = "5 Silo")]
            Silo5 = 5,
            [Display(Name = "6 Silo")]
            Silo6 = 6
        }
        public enum wei_AGG
        {
            [Display(Name = "1 Weight")]
            Weight1 = 1,
            [Display(Name = "2 Weight")]
            Weight2 = 2,
            [Display(Name = "3 Weight")]
            Weight3 = 3,
            [Display(Name = "4 Weight")]
            Weight4 = 4,
            [Display(Name = "5 Weight")]
            Weight5 = 5,
            [Display(Name = "6 Weight")]
            Weight6 = 6
        }
        public enum wei_CE
        {
            [Display(Name = "1 Weight")]
            Weight1 = 1,
            [Display(Name = "2 Weight")]
            Weight2 = 2
        }
        public enum wei_WA
        {
            [Display(Name = "1 Weight")]
            Weight1 = 1,
            [Display(Name = "2 Weight")]
            Weight2 = 2
        }
        public enum wei_ADD
        {
            [Display(Name = "1 Weight")]
            Weight1 = 1,
            [Display(Name = "2 Weight")]
            Weight2 = 2
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int sl_silo_AGG = Convert.ToInt32(this.lue_Silo_Agg.EditValue);
            CreateSilo_AGG(sl_silo_AGG);

            int sl_silo_CE = Convert.ToInt32(this.lue_Silo_Ce.EditValue);
            CreateSilo_CE(sl_silo_CE);

            int sl_silo_WA = Convert.ToInt32(this.lue_Silo_Wa.EditValue);
            CreateSilo_WA(sl_silo_WA);

            int sl_silo_ADD = Convert.ToInt32(this.lue_Silo_Add.EditValue);
            CreateSilo_ADD(sl_silo_ADD);

            int sl_wei_AGG = Convert.ToInt32(this.lue_Wei_Agg.EditValue);
            CreateWei_AGG(sl_wei_AGG);

            int sl_wei_CE = Convert.ToInt32(this.lue_Wei_Ce.EditValue);
            CreateWei_CE(sl_wei_CE);

            int sl_wei_WA = Convert.ToInt32(this.lue_Wei_Wa.EditValue);
            CreateWei_WA(sl_wei_WA);

            int sl_wei_ADD = Convert.ToInt32(this.lue_Wei_Add.EditValue);
            CreateWei_ADD(sl_wei_ADD);

            this.ucBTC1.Visible = this.chk_BTC.Checked;
            this.ucBTC1.Size = new Size((int)this.spnWidthBTC.Value, ucBTC1.Size.Height);

            this.funnel.Visible = this.chk_Funnel.Checked;

            if(rdgCapPhoiRes.SelectedIndex == 0)
            {
                this.ucBTXien1.Visible = true;
                this.ucGauTai1.Visible = false;
            }
            else if(rdgCapPhoiRes.SelectedIndex == 1)
            {
                this.ucBTXien1.Visible = false;
                this.ucGauTai1.Visible = true;
            }
            

        }
        private void ActiveSilo(List<ucSilo> lst_Silo, int sl)
        {
            LimitedList<ucSilo> limitedList = new LimitedList<ucSilo>(sl);
            for (int i = 0; i < sl; i++)
            {
                limitedList.Add(lst_Silo[i]);
            }
            foreach (ucSilo sl_Silo in limitedList)
            {
                sl_Silo.Visible = true;
            }
        }
        private void ActiveWeight(List<ucWeight> lst_Wei, int sl)
        {
            LimitedList<ucWeight> limitedList = new LimitedList<ucWeight>(sl);
            for (int i = 0; i < sl; i++)
            {
                limitedList.Add(lst_Wei[i]);
            }
            foreach (ucWeight sl_Wei in limitedList)
            {
                sl_Wei.Visible = true;
            }
        }
        private void CreateSilo_AGG(int sl)
        {
            List<ucSilo> lst_Agg = new List<ucSilo>();
            lst_Agg.Add(silo_Agg1);
            lst_Agg.Add(silo_Agg2);
            lst_Agg.Add(silo_Agg3);
            lst_Agg.Add(silo_Agg4);
            lst_Agg.Add(silo_Agg5);
            lst_Agg.Add(silo_Agg6);
            foreach(ucSilo silo_Agg in lst_Agg)
            {
                silo_Agg.Visible = false;
            }
            ActiveSilo(lst_Agg, sl);
        }
        private void CreateSilo_CE(int sl)
        {
            List<ucSilo> lst_Ce = new List<ucSilo>();
            lst_Ce.Add(silo_Ce1);
            lst_Ce.Add(silo_Ce2);
            lst_Ce.Add(silo_Ce3);
            lst_Ce.Add(silo_Ce4);
            lst_Ce.Add(silo_Ce5);
            foreach (ucSilo silo_Ce in lst_Ce)
            {
                silo_Ce.Visible = false;
            }
            ActiveSilo(lst_Ce, sl);
        }
        private void CreateSilo_WA(int sl)
        {
            List<ucSilo> lst_Wa = new List<ucSilo>();
            lst_Wa.Add(silo_Wa1);
            lst_Wa.Add(silo_Wa2);
            foreach (ucSilo silo_Wa in lst_Wa)
            {
                silo_Wa.Visible = false;
            }
            ActiveSilo(lst_Wa, sl);
        }
        private void CreateSilo_ADD(int sl)
        {
            List<ucSilo> lst_Add = new List<ucSilo>();
            lst_Add.Add(silo_Add1);
            lst_Add.Add(silo_Add2);
            lst_Add.Add(silo_Add3);
            lst_Add.Add(silo_Add4);
            lst_Add.Add(silo_Add5);
            lst_Add.Add(silo_Add6);
            foreach (ucSilo silo_Add in lst_Add)
            {
                silo_Add.Visible = false;
            }
            ActiveSilo(lst_Add, sl);
        }
        private void CreateWei_AGG(int sl)
        {
            List<ucWeight> lst_Agg = new List<ucWeight>();
            lst_Agg.Add(wei_Agg1);
            lst_Agg.Add(wei_Agg2);
            lst_Agg.Add(wei_Agg3);
            lst_Agg.Add(wei_Agg4);
            lst_Agg.Add(wei_Agg5);
            lst_Agg.Add(wei_Agg6);
            foreach (ucWeight wei_Agg in lst_Agg)
            {
                wei_Agg.Visible = false;
            }
            ActiveWeight(lst_Agg, sl);
        }
        private void CreateWei_CE(int sl)
        {
            List<ucWeight> lst_Ce = new List<ucWeight>();
            lst_Ce.Add(wei_Ce1);
            lst_Ce.Add(wei_Ce2);
            foreach (ucWeight wei_Ce in lst_Ce)
            {
                wei_Ce.Visible = false;
            }
            ActiveWeight(lst_Ce, sl);
        }
        private void CreateWei_WA(int sl)
        {
            List<ucWeight> lst_Wa = new List<ucWeight>();
            lst_Wa.Add(wei_Wa1);
            lst_Wa.Add(wei_Wa2);
            foreach (ucWeight wei_Wa in lst_Wa)
            {
                wei_Wa.Visible = false;
            }
            ActiveWeight(lst_Wa, sl);
        }
        private void CreateWei_ADD(int sl)
        {
            List<ucWeight> lst_Add = new List<ucWeight>();
            lst_Add.Add(wei_Add1);
            lst_Add.Add(wei_Add2);
            foreach (ucWeight wei_Add in lst_Add)
            {
                wei_Add.Visible = false;
            }
            ActiveWeight(lst_Add, sl);
        }

        private void Silo_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("fff");
            switch (e.KeyCode)
            {

                case Keys.Left:
                    this.Left -= 5; // Di chuyển sang trái
                    
                    break;
                case Keys.Right:
                    this.Left += 5; // Di chuyển sang phải
                    break;
            }
        }
        private void silo_ButtonMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ucSilo control = sender as ucSilo;
                offset = e.Location;
                isDragging = true;
                control.BringToFront();
            }
        }

        private void silo_ButtonMouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                ucSilo control = sender as ucSilo;

                control.Left = e.X + control.Left - offset.X;
                control.ToaDoX = control.Left.ToString();
            }
        }

        
        private void silo_ButtonMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }
        private void wei_ButtonMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ucWeight control = sender as ucWeight;
                offset = e.Location;
                isDragging = true;
                control.BringToFront();
            }
        }

        private void wei_ButtonMouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                ucWeight control = sender as ucWeight;

                control.Left = e.X + control.Left - offset.X;
                control.ToaDoX = control.Left;
            }
        }
        private void wei_ButtonMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }
        private void btc_ButtonMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ucBTC control = sender as ucBTC;
                offset = e.Location;
                isDragging = true;
                control.BringToFront();
            }
        }
        private void btc_ButtonMouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                ucBTC control = sender as ucBTC;

                control.Left = e.X + control.Left - offset.X;
                control.ToaDoX = control.Left.ToString();
            }
        }
        private void btc_ButtonMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            this.lue_Silo_Agg.EditValue = 0;
            this.lue_Silo_Ce.EditValue = 0;
            this.lue_Silo_Wa.EditValue = 0;
            this.lue_Silo_Add.EditValue = 0;

            this.lue_Wei_Agg.EditValue = 0;
            this.lue_Wei_Ce.EditValue = 0;
            this.lue_Wei_Wa.EditValue = 0;
            this.lue_Wei_Add.EditValue = 0;

            this.spnWidthBTC.EditValue = 100;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                ConfigManager.TramTronConfig.SL_Silo_AGG = this.lue_Silo_Agg.EditValue.GetHashCode();
                ConfigManager.TramTronConfig.SL_Silo_CE = this.lue_Silo_Ce.EditValue.GetHashCode();
                ConfigManager.TramTronConfig.SL_Silo_WA = this.lue_Silo_Wa.EditValue.GetHashCode();
                ConfigManager.TramTronConfig.SL_Silo_ADD = this.lue_Silo_Add.EditValue.GetHashCode();

                ConfigManager.TramTronConfig.SL_Wei_AGG = this.lue_Wei_Agg.EditValue.GetHashCode();
                ConfigManager.TramTronConfig.SL_Wei_CE = this.lue_Wei_Ce.EditValue.GetHashCode();
                ConfigManager.TramTronConfig.SL_Wei_WA = this.lue_Wei_Wa.EditValue.GetHashCode();
                ConfigManager.TramTronConfig.SL_Wei_ADD = this.lue_Wei_Add.EditValue.GetHashCode();

                ConfigManager.TramTronConfig.Silo_AGG_1_X = this.silo_Agg1.Location.X;
                ConfigManager.TramTronConfig.Silo_AGG_2_X = this.silo_Agg2.Location.X;
                ConfigManager.TramTronConfig.Silo_AGG_3_X = this.silo_Agg3.Location.X;
                ConfigManager.TramTronConfig.Silo_AGG_4_X = this.silo_Agg4.Location.X;
                ConfigManager.TramTronConfig.Silo_AGG_5_X = this.silo_Agg5.Location.X;
                ConfigManager.TramTronConfig.Silo_AGG_6_X = this.silo_Agg6.Location.X;
                ConfigManager.TramTronConfig.Silo_CE_1_X = this.silo_Ce1.Location.X;
                ConfigManager.TramTronConfig.Silo_CE_2_X = this.silo_Ce2.Location.X;
                ConfigManager.TramTronConfig.Silo_CE_3_X = this.silo_Ce3.Location.X;
                ConfigManager.TramTronConfig.Silo_CE_4_X = this.silo_Ce4.Location.X;
                ConfigManager.TramTronConfig.Silo_CE_5_X = this.silo_Ce5.Location.X;
                ConfigManager.TramTronConfig.Silo_WA_1_X = this.silo_Wa1.Location.X;
                ConfigManager.TramTronConfig.Silo_WA_2_X = this.silo_Wa2.Location.X;
                ConfigManager.TramTronConfig.Silo_ADD_1_X = this.silo_Add1.Location.X;
                ConfigManager.TramTronConfig.Silo_ADD_2_X = this.silo_Add2.Location.X;
                ConfigManager.TramTronConfig.Silo_ADD_3_X = this.silo_Add3.Location.X;
                ConfigManager.TramTronConfig.Silo_ADD_4_X = this.silo_Add4.Location.X;
                ConfigManager.TramTronConfig.Silo_ADD_5_X = this.silo_Add5.Location.X;
                ConfigManager.TramTronConfig.Silo_ADD_6_X = this.silo_Add6.Location.X;
                ConfigManager.TramTronConfig.Wei_AGG_1_X = this.wei_Agg1.Location.X;
                ConfigManager.TramTronConfig.Wei_AGG_2_X = this.wei_Agg2.Location.X;
                ConfigManager.TramTronConfig.Wei_AGG_3_X = this.wei_Agg3.Location.X;
                ConfigManager.TramTronConfig.Wei_AGG_4_X = this.wei_Agg4.Location.X;
                ConfigManager.TramTronConfig.Wei_AGG_5_X = this.wei_Agg5.Location.X;
                ConfigManager.TramTronConfig.Wei_AGG_6_X = this.wei_Agg6.Location.X;
                ConfigManager.TramTronConfig.Wei_CE_1_X = this.wei_Ce1.Location.X;
                ConfigManager.TramTronConfig.Wei_CE_2_X = this.wei_Ce2.Location.X;
                ConfigManager.TramTronConfig.Wei_WA_1_X = this.wei_Wa1.Location.X;
                ConfigManager.TramTronConfig.Wei_WA_2_X = this.wei_Wa2.Location.X;
                ConfigManager.TramTronConfig.Wei_ADD_1_X = this.wei_Add1.Location.X;
                ConfigManager.TramTronConfig.Wei_ADD_2_X = this.wei_Add2.Location.X;

                ConfigManager.TramTronConfig.Show_BTC = this.chk_BTC.Checked;
                ConfigManager.TramTronConfig.PGN = this.chk_PGN.Checked;
                ConfigManager.TramTronConfig.Width_BTC = (int)this.spnWidthBTC.Value;
                ConfigManager.TramTronConfig.BTC_X = this.ucBTC1.Location.X;

                ConfigManager.TramTronConfig.Show_Funnel = this.chk_Funnel.Checked;

                if (rdgCapPhoiRes.SelectedIndex == 0)
                {
                    ConfigManager.TramTronConfig.CapPhoiRes = 0;
                }
                else
                {
                    ConfigManager.TramTronConfig.CapPhoiRes = 1;
                }

                CreateListAgg();
                IsSuccessfulSave = true;
                
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //TramTronLogger.WriteError(ex);
                //TramTromMessageBox.ShowDNErrorDialog(ex);
            }
        }

        private void CloseFormVHTabs()
        {
           
        }

        private void ConfigUIMngView_Load(object sender, EventArgs e)
        {

        }

        private void CreateListAgg()
        {
            BindingList<ObjSilo> blstSilo = new BindingList<ObjSilo>();
            this._presenter.ListSilo_ByActivated_Agg(null);
            for (int i = 0; i < this.lue_Silo_Agg.EditValue.GetHashCode(); i++)
            {
                this._blstSiloConfig_Agg[i].Activated = true;
                blstSilo.Add(this._blstSiloConfig_Agg[i]);
            }
            for (int j = this.lue_Silo_Agg.EditValue.GetHashCode(); j < this._blstSiloConfig_Agg.Count; j++)
            {
                this._blstSiloConfig_Agg[j].Activated = false;
                blstSilo.Add(this._blstSiloConfig_Agg[j]);
            }

            //this._presenter.SaveSilo(blstSilo);

            this._presenter.ListSilo_ByActivated_Ce(null);
            for (int i = 0; i < this.lue_Silo_Ce.EditValue.GetHashCode(); i++)
            {
                this._blstSiloConfig_Ce[i].Activated = true;
                blstSilo.Add(this._blstSiloConfig_Ce[i]);
            }
            for (int j = this.lue_Silo_Ce.EditValue.GetHashCode(); j < this._blstSiloConfig_Ce.Count; j++)
            {
                this._blstSiloConfig_Ce[j].Activated = false;
                blstSilo.Add(this._blstSiloConfig_Ce[j]);
            }

            this._presenter.ListSilo_ByActivated_Wa(null);
            for (int i = 0; i < this.lue_Silo_Wa.EditValue.GetHashCode(); i++)
            {
                this._blstSiloConfig_Wa[i].Activated = true;
                blstSilo.Add(this._blstSiloConfig_Wa[i]);
            }
            for (int j = this.lue_Silo_Wa.EditValue.GetHashCode(); j < this._blstSiloConfig_Wa.Count; j++)
            {
                this._blstSiloConfig_Wa[j].Activated = false;
                blstSilo.Add(this._blstSiloConfig_Wa[j]);
            }

            this._presenter.ListSilo_ByActivated_Add(null);
            for (int i = 0; i < this.lue_Silo_Add.EditValue.GetHashCode(); i++)
            {
                this._blstSiloConfig_Add[i].Activated = true;
                blstSilo.Add(this._blstSiloConfig_Add[i]);
            }
            for (int j = this.lue_Silo_Add.EditValue.GetHashCode(); j < this._blstSiloConfig_Add.Count; j++)
            {
                this._blstSiloConfig_Add[j].Activated = false;
                blstSilo.Add(this._blstSiloConfig_Add[j]);
            }
            this._presenter.SaveSilo(blstSilo);
        }
        private void CreateListCe()
        {
            BindingList<ObjSilo> blstSilo = new BindingList<ObjSilo>();
            

            //this._presenter.SaveSilo(blstSilo);
        }

        private void spnWidthBTC_EditValueChanged(object sender, EventArgs e)
        {
            if(this.spnWidthBTC.Value < 100)
            {
                this.spnWidthBTC.Value = 100;
            }
            else if(this.spnWidthBTC.Value > 550)
            {
                this.spnWidthBTC.Value = 550;
            }
            this.ucBTC1.Size = new Size((int)this.spnWidthBTC.Value, this.ucBTC1.Size.Height);
        }
    }


    public class LimitedList<T> : List<T>
    {
        private int maxSize;

        public LimitedList(int maxSize)
        {
            this.maxSize = maxSize;
        }

        public new void Add(T item)
        {
            if (Count >= maxSize)
            {
                throw new InvalidOperationException("List is full.");
            }
            base.Add(item);
        }
    }
}
