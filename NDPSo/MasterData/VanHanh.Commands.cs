using System;
using System.Threading;
using System.Windows.Forms;
using NDPSo.MasterData.Config;
using NDPSo.MasterData.TronOnlineView.UserControls;
using NDPSo.Utils;

namespace NDPSo.MasterData
{
    public partial class VanHanh
    {
        #region Button Command Handlers (VanXa / Gau / SKCe / etc.)

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
                DialogResult result = MessageBox.Show("Xác nhận chạy tiến trình trộn?", "Thông báo", MessageBoxButtons.YesNo);
                switch (result)
                {
                    case DialogResult.Yes:
                        this.InitRunning(true);
                        this._so.SendingCommand.F1_Run = true;
                        this.SendData_DB2_NewTread();
                        //StatusConnected.CheckOpenSof(true, true);
                        Thread.Sleep(100);
                        this._so.SendingCommand.F1_Run = false;
                        this.SendData_DB2_NewTread();
                        

                        if (checkEdit3.Checked)
                        {
                            isTesst = true;
                            lblTest.Text = "Đang chạy Auto";
                        }

                        break;
                    case DialogResult.No:
                        break;
                }

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


        private void ucButtonSKCe1_ButtonMouseDown(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_SKSL1 = true;
            SendData_DB2_NewTread();

        }

        private void ucButtonSKCe1_ButtonMouseUp(object sender, EventArgs e)
        {
            this._so.SendingCommand.NN_SKSL1 = false;
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

        private void VanHanh_ControlClosing(object sender, FormClosingEventArgs e)
        {
            this._so.SendingCommand.SW_XA_COT_LIEU = false;
            this._so.SendingCommand.SW_NAP_NOI_TRON = false;
            this._so.SendingCommand.SW_XA_NOI_TRON = false;
            this._so.SendingCommand.SW_RUA_NOI_TRON = false;

            this.SendData_DB2_NewTread();

            _nvlMonitor?.Stop();
            _nvlMonitor?.Dispose();
        }

        private void ucXeBonTron1_Click(object sender, EventArgs e)
        {
            TramTromMessageBox.ShowMessageDialog(Support.GenerateFakeValueADD(1).ToString());
            
        }

        private void ucXeBonTron1_MouseDown(object sender, MouseEventArgs e)
        {
            TramTromMessageBox.ShowMessageDialog(Support.GenerateFakeValueADD(1).ToString());

        }
        #endregion
    }
}
