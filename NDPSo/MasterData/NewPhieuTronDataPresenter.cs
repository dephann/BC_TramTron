using NDPSo.Data;
using NDPSo.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    public class NewPhieuTronDataPresenter : MasterDataPresenter<INewPhieuTronView>
    {
        public NewPhieuTronDataPresenter(INewPhieuTronView view)
          : base(view)
        {
        }

        public void BuildNewPhieuTron(ObjHopDong objHD)
        {
            Decimal klTronNhoNhat = ConfigManager.TramTronConfig.KLTronNhoNhat;
            Decimal klTronLonNhat = ConfigManager.TramTronConfig.KLTronLonNhat;
            Decimal klChoLonNhat = ConfigManager.TramTronConfig.KLChoLonNhat;
            Decimal kldtPhieuTron = MasterDataPresenter<INewPhieuTronView>._iMasterDataModel.GetKLDTPhieuTron(objHD.KLLyThuyetCoTheTaoPT.Value, klChoLonNhat);
            int meTronQty = MasterDataPresenter<INewPhieuTronView>._iMasterDataModel.CalcMeTronQty(kldtPhieuTron, klTronLonNhat);
            Decimal d = MasterDataPresenter<INewPhieuTronView>._iMasterDataModel.CalcKLDTMeTron(kldtPhieuTron, meTronQty);
            this._iView.PhieuTron = new ObjPhieuTron()
            {
                MaPhieuTron = MasterDataPresenter<INewPhieuTronView>._iMasterDataModel.GetNextCode("PhieuTron"),
                Status = new int?(0),
                HopDongID = new int?(objHD.HopDongID),
                NgayPhieuTron = new DateTime?(DateTime.Now),
                KLDuTinh = new Decimal?(kldtPhieuTron),
                KLThuc = new Decimal?(0M),
                SLMeDuTinh = new Decimal?((Decimal)meTronQty),
                KLDuTinhCuaTungMe = new Decimal?(d),
                KLBuTruMeCuoi = new Decimal?(kldtPhieuTron - Math.Round(d, 2) * (Decimal)meTronQty),
                MinKLTron = new Decimal?(klTronNhoNhat),
                MaxKLTron = new Decimal?(klTronLonNhat),
                MaxKLXeCho = new Decimal?(klChoLonNhat),
                IsQueued = new bool?(true),
                NPHopDongMaHopDong = objHD.MaHopDong,
                NPHopDongTenHopDong = objHD.TenHopDong
            };
        }

        public void GetPhieuTronByKey(int ptID) => this._iView.PhieuTron = MasterDataPresenter<INewPhieuTronView>._iMasterDataModel.GetPhieuTronByKey(ptID);

        public void GetPhieuTronByCode(string code) => this._iView.PhieuTron = MasterDataPresenter<INewPhieuTronView>._iMasterDataModel.GetPhieuTronByCode(code);

        public void GetHopDongByKey(int hdID) => this._iView.HopDong = MasterDataPresenter<INewPhieuTronView>._iMasterDataModel.GetHopDongByKey(hdID);

        public void ListMeTron(int ptID) => this._iView.BLstMeTron = MasterDataPresenter<INewPhieuTronView>._iMasterDataModel.ListMeTronByPhieuTronID(ptID);

        public void ListMeTronChiTiet(int ptID) => this._iView.BLstMeTronChiTiet = MasterDataPresenter<INewPhieuTronView>._iMasterDataModel.ListMeTronChiTietByPhieuTronID(ptID);

        public void ListTaiXe() => this._iView.BLstTaiXe = MasterDataPresenter<INewPhieuTronView>._iMasterDataModel.ListTaiXe();

        public void ListTaiXe_ByCondition(
          DateTime? fromDate,
          DateTime? toDate,
          string maKH,
          string tenKH,
          string phone,
          bool? active)
        {
            this._iView.BLstTaiXe = MasterDataPresenter<INewPhieuTronView>._iMasterDataModel.ListTaiXe_ByCondition(fromDate, toDate, maKH, tenKH, phone, active);
        }

        public void ListXe() => this._iView.BLstXe = MasterDataPresenter<INewPhieuTronView>._iMasterDataModel.ListXe();

        public void ListXe_ByCondition(
          DateTime? fromDate,
          DateTime? toDate,
          string bienSo,
          bool? active)
        {
            this._iView.BLstXe = MasterDataPresenter<INewPhieuTronView>._iMasterDataModel.ListXe_ByCondition(fromDate, toDate, bienSo, active);
        }

        public void SavePhieuTron(BindingList<ObjPhieuTron> blstCT) => this._iView.IsSuccessfulSaved = MasterDataPresenter<INewPhieuTronView>._iMasterDataModel.SavePhieuTron(blstCT);

        public void GetSLMeDuTinh(Decimal klDuTinhPhieuTron, Decimal maxKLTron) => this._iView.SLMeDuTinh = MasterDataPresenter<INewPhieuTronView>._iMasterDataModel.CalcMeTronQty(klDuTinhPhieuTron, maxKLTron);

        public void GetKLDuTinhMeTron(Decimal klDuTinhPhieuTron, int slMeDuTinh) => this._iView.KLDuTinhMeTron = MasterDataPresenter<INewPhieuTronView>._iMasterDataModel.CalcKLDTMeTron(klDuTinhPhieuTron, slMeDuTinh);
    }
}
