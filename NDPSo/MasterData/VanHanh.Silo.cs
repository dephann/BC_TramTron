using System;
using System.Linq;
using System.Windows.Forms;
using NDPSo.Data;
using NDPSo.MasterData.Config;
using NDPSo.MasterData.TronOnlineView.UserControls;
using NDPSo.Utils;

namespace NDPSo.MasterData
{
    public partial class VanHanh
    {
        #region Silo & Weight Operations

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
                BuildSetPoint(_selectedHD_Run, true);
                //this.SendData_DB2_NewTread();
                this.SendData_DB3_NewTread();
                //Add 2906
                this._presenter.ListSilo();
                this._presenter.ListSilo_DoAmHutAgg();
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
            BuildSetPoint(_selectedHD_Run, true);
            this.SendData_DB4_NewTread();
            //this.SendData_DB2_NewTread();
            this._presenter.ListWei();
        }

        #endregion
    }
}