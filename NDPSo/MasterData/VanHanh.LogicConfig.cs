using DevExpress.XtraEditors;
using NDPSo.Data;
using NDPSo.PLCModule;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using NDPSo.Utils;

namespace NDPSo.MasterData
{
    public partial class VanHanh
    {
        #region Logic Configuration (Logic Can AGG / CE / ADD)

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

        #endregion
    }
}