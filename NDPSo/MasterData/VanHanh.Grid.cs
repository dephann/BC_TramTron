using DevExpress.Data;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using NDPSo.Data;
using NDPSo.MasterData.Config;
using NDPSo.MasterData.TronOnlineView.UserControls;
using NDPSo.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace NDPSo.MasterData
{
    public partial class VanHanh
    {

        #region Grid & DuLieuTron CRUD

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

        private void DoSetThoiGianGiaoHang(object sender, EventArgs e)
        {
            int rowHandle = ((sender as DXMenuItem).Tag as VanHanh.RowInfo).RowHandle;
            ObjDuLieuTron dlt = this.grvHopDong.GetRow(rowHandle) as ObjDuLieuTron;
            if (dlt == null) return;

            using (XtraForm dlg = new XtraForm())
            {
                dlg.Text = "Đặt giờ giao hàng";
                dlg.Size = new System.Drawing.Size(340, 150);
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
                dlg.MaximizeBox = false;
                dlg.MinimizeBox = false;

                DateEdit datePicker = new DateEdit();
                datePicker.Properties.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
                datePicker.Properties.EditFormat.FormatString = "dd/MM/yyyy HH:mm";
                datePicker.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
                datePicker.Properties.Mask.EditMask = "dd/MM/yyyy HH:mm";
                datePicker.EditValue = dlt.ThoiGianGiaoHang.HasValue
                    ? (object)dlt.ThoiGianGiaoHang.Value
                    : (object)DateTime.Now.Date.AddHours(8);
                datePicker.Bounds = new System.Drawing.Rectangle(12, 16, 220, 24);
                dlg.Controls.Add(datePicker);

                SimpleButton btnOk = new SimpleButton { Text = "Lưu", DialogResult = DialogResult.OK };
                btnOk.Bounds = new System.Drawing.Rectangle(242, 16, 70, 24);
                dlg.Controls.Add(btnOk);
                dlg.AcceptButton = btnOk;

                SimpleButton btnClear = new SimpleButton { Text = "Xóa giờ" };
                btnClear.Bounds = new System.Drawing.Rectangle(12, 52, 90, 24);
                btnClear.Click += (s2, e2) => { dlt.ThoiGianGiaoHang = null; dlg.DialogResult = DialogResult.OK; dlg.Close(); };
                dlg.Controls.Add(btnClear);

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (datePicker.EditValue is DateTime dt)
                        dlt.ThoiGianGiaoHang = dt;
                    this._presenter.UpdateDuLieuTron(dlt);
                    this.grvHopDong.RefreshData();
                }
            }
        }

        private void DoTogglePrioritySort(object sender, EventArgs e)
        {
            _isPrioritySort = !_isPrioritySort;
            if (_isPrioritySort)
            {
                // Sắp xếp theo CR tăng dần (CR thấp nhất = gấp nhất → lên đầu)
                // Các đơn không có ThoiGianGiaoHang đặt xuống cuối
                var sorted = this._blstDuLieuTron
                    .OrderBy(d => d.Status == 4 ? 3 : d.Status == 3 ? 2 : d.Status == 1 ? 0 : 1)  // Done cuối, Cancelled kế cuối, Running đầu
                    .ThenBy(d => d.ThoiGianGiaoHang.HasValue ? 0 : 1)             // có deadline trước
                    .ThenBy(d => d.CriticalRatio ?? double.MaxValue)               // CR thấp nhất = ưu tiên
                    .ToList();
                this._blstDuLieuTron = new BindingList<ObjDuLieuTron>(sorted);
                this.grcHopDong.DataSource = this._blstDuLieuTron;
                this.grvHopDong.RefreshData();
                MessageBox.Show("Đã sắp xếp theo ưu tiên CR.\nĐỏ = Trễ  |  Vàng = Gấp  |  Xanh = An toàn", "Sắp xếp ưu tiên", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Về sắp xếp mặc định theo LnNo
                var sorted = this._blstDuLieuTron
                    .OrderBy(d => d.Status == 4 ? 2 : d.Status == 3 ? 1 : 0)  // Done cuối, Cancelled kế cuối
                    .ThenBy(d => d.LnNo)
                    .ToList();
                this._blstDuLieuTron = new BindingList<ObjDuLieuTron>(sorted);
                this.grcHopDong.DataSource = this._blstDuLieuTron;
                this.grvHopDong.RefreshData();
            }
        }

        private void grvHopDong_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView gridView = sender as GridView;
            if (e.RowHandle < 0 || e.RowHandle >= this._blstDuLieuTron.Count) return;

            ObjDuLieuTron dlt = gridView.GetRow(e.RowHandle) as ObjDuLieuTron;
            if (dlt == null) return;

            // Đã hủy (Status=3) → hồng nhạt
            if (dlt.Status == 3)
            {
                e.Appearance.BackColor = ScheduleColorHelper.ColorCancelled;
                e.Appearance.ForeColor = ScheduleColorHelper.ForeCancelled;
                e.Appearance.Options.UseForeColor = true;
                return;
            }

            // Hoàn tất (Status=4) → xám, đẩy xuống cuối về mặt hiển thị
            if (dlt.Status == 4)
            {
                e.Appearance.BackColor = ScheduleColorHelper.ColorDone;
                e.Appearance.ForeColor = Color.DimGray;
                e.Appearance.Options.UseForeColor = true;
                return;
            }

            // Đang chạy (Status=1) → xanh lá đậm (ưu tiên cao nhất)
            if (dlt.Status == 1)
            {
                e.Appearance.BackColor  = ScheduleColorHelper.ColorRunning;
                e.Appearance.ForeColor  = ScheduleColorHelper.ForeRunning;
                e.Appearance.Options.UseForeColor = true;
                return;
            }

            // Luôn tô màu theo CR khi có deadline (không cần bật _isPrioritySort)
            if (dlt.ThoiGianGiaoHang.HasValue)
            {
                double? cr = dlt.CriticalRatio;
                Color back = ScheduleColorHelper.BackColorByCR(cr);
                Color fore = ScheduleColorHelper.ForeColorByCR(cr);
                if (back != System.Drawing.Color.Empty)
                {
                    e.Appearance.BackColor = back;
                    e.Appearance.ForeColor = fore;
                    e.Appearance.Options.UseForeColor = true;
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

                // Đặt giờ giao hàng cho dòng được chọn
                DXMenuItem dXMenuItemSetTime = new DXMenuItem("⏰ Đặt giờ giao hàng", new EventHandler(this.DoSetThoiGianGiaoHang));
                dXMenuItemSetTime.Tag = new VanHanh.RowInfo(view, rowHandle);
                dXMenuItemSetTime.Enabled = rowHandle >= 0;
                e.Menu.Items.Add(dXMenuItemSetTime);

                // Toggle chế độ sắp xếp ưu tiên CR
                string sortLabel = _isPrioritySort
                    ? "↩ Về sắp xếp mặc định"
                    : "⚡ Sắp xếp theo ưu tiên (CR)";
                DXMenuItem dXMenuItemSort = new DXMenuItem(sortLabel, new EventHandler(this.DoTogglePrioritySort));
                dXMenuItemSort.Tag = new VanHanh.RowInfo(view, rowHandle);
                dXMenuItemSort.Enabled = true;
                e.Menu.Items.Add(dXMenuItemSort);
            }
        }
        private void ResetValueInfoTable()
        {
            this.lblMaPhieuTron.Text
            = this.lblTenKhachHang.Text
            = this.lblTenCongTruong.Text
            = this.lblDiaDiem.Text
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
                        this.lblDiaDiem.Text = this._presenter.GetCongTruongByKey(_idCongTruong).DiaChi;
                        this.lblMAC.Text = hopDongByKey.NPMACTenMAC;
                        this.lblMAC.Tag = hopDongByKey;
                        this.lblKhoiLuong.Text = hopDongByKey.DLT_KLDuTinh.ToString();
                        this.lblLuyKe.Text = hopDongByKey.KLDaGiao.ToString();
                        this.spnThemBotNc.Tag = hopDongByKey.MACID;
                        this.spnThemBotNc.EditValue = hopDongByKey.NPMACThemBotNuoc1;
                        this.ucSoKhoiTrenMe.GiaTri = (decimal)hopDongByKey.DLT_KLDuTinhCuaTungMe;
                        this.lblNguoiTron.Text = GlobalValues.DisplayUser;
                       // this.slMeCanTron = (int)hopDongByKey.DLT_SLMeDuTinh;
                        this.BuildSetPoint(hopDongByKey, false);

                    }
                    return;
                }
            }
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
                    //this.slMeCanTron = (int)objHopDong.DLT_SLMeDuTinh;
                    this.BuildSetPoint(objHopDong, false);
                    UpdateRankingDLT(objDuLieuTron);
                }
                //Update Thong tin PT
                //UpdateRankingDLT(objDuLieuTron);
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
                        this.lblDiaDiem.Text = this._presenter.GetCongTruongByKey(_idCongTruong).DiaChi;
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
                //TramTromMessageBox.ShowWarningDialog(GlobalValues.Messages.DataEditedPleaseRefresh);
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
            ObjDuLieuTron dlt = this.grvHopDong.GetRow(e.FocusedRowHandle) as ObjDuLieuTron;
            btnRun.Enabled = dlt?.Status != 4 && dlt?.Status != 3;
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
        private void SetSLMe(int slMeTron)
        {
            TramTronLogger.WriteInfo("CHECKING ME TRON: " + slMeTron);
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
                            = (this.slMeDaCanNoiTron.SoLuongMeCanTron = slMeTron)))))))))))));
        }
        #endregion

        #endregion

    }
}