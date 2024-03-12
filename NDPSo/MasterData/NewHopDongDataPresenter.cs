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
    public class NewHopDongDataPresenter : MasterDataPresenter<INewHopDongView>
    {
        public NewHopDongDataPresenter(INewHopDongView view)
          : base(view)
        {
        }

        public void BuildNewHopDong()
        {
            ObjHopDong objHopDong = new ObjHopDong()
            {
                MaHopDong = MasterDataPresenter<INewHopDongView>._iMasterDataModel.GetNextCode("HopDong"),
                TenHopDong = string.Empty,
                NgayHopDong = new DateTime?(DateTime.Now),
                MoTa = string.Empty,
                DoSut = string.Empty,
                KLDatHang = new Decimal?(0M),
                KLDaGiao = new Decimal?(0M),
                KLConLai = new Decimal?(0M),
                KLTaoPhieuTron = new Decimal?(0M),
                Status = new int?(0)
            };
            Decimal klTronNhoNhat = ConfigManager.TramTronConfig.KLTronNhoNhat;
            Decimal klTronLonNhat = ConfigManager.TramTronConfig.KLTronLonNhat;
            Decimal klChoLonNhat = ConfigManager.TramTronConfig.KLChoLonNhat;
            Decimal kldtPhieuTron = MasterDataPresenter<INewHopDongView>._iMasterDataModel.GetKLDTPhieuTron(objHopDong.KLLyThuyetCoTheTaoPT.Value, klChoLonNhat);
            int meTronQty = MasterDataPresenter<INewHopDongView>._iMasterDataModel.CalcMeTronQty(kldtPhieuTron, klTronLonNhat);
            Decimal d = MasterDataPresenter<INewHopDongView>._iMasterDataModel.CalcKLDTMeTron(kldtPhieuTron, meTronQty);
            objHopDong.DLT_KLDuTinh = new Decimal?(kldtPhieuTron);
            objHopDong.DLT_SLMeDuTinh = new Decimal?((Decimal)meTronQty);
            objHopDong.DLT_KLDuTinhCuaTungMe = new Decimal?(d);
            objHopDong.DLT_KLBuTruMeCuoi = new Decimal?(kldtPhieuTron - Math.Round(d, 2) * (Decimal)meTronQty);
            objHopDong.DLT_KLTronNhoNhat = new Decimal?(klTronNhoNhat);
            objHopDong.DLT_KLTronLonNhat = new Decimal?(klTronLonNhat);
            objHopDong.DLT_KLXeChoLonNhat = new Decimal?(klChoLonNhat);
            this._iView.HopDong = objHopDong;
        }

        public void GetHopDongByKey(int soID) => this._iView.HopDong = MasterDataPresenter<INewHopDongView>._iMasterDataModel.GetHopDongByKey(soID);

        public void ListKhachHang() => this._iView.BLstKhachHang = MasterDataPresenter<INewHopDongView>._iMasterDataModel.ListKhachHang_ByCondition(new DateTime?(DateTime.MinValue), new DateTime?(DateTime.MinValue), string.Empty, string.Empty, string.Empty, string.Empty, new bool?(true));

        public void ListCongTruong() => this._iView.BLstCongTruong = MasterDataPresenter<INewHopDongView>._iMasterDataModel.ListCongTruong_ByCondition(new DateTime?(DateTime.MinValue), new DateTime?(DateTime.Now), string.Empty, string.Empty,string.Empty, string.Empty, new bool?(true));

       // public void ListCongTruong() => this._iView.BLstCongTruong = MasterDataPresenter<INewHopDongView>._iMasterDataModel.ListCongTruong();

        public void ListMAC() => this._iView.BLstMAC = MasterDataPresenter<INewHopDongView>._iMasterDataModel.ListMAC_ByCondition(new DateTime?(DateTime.MinValue), new DateTime?(DateTime.MinValue), string.Empty, string.Empty, new bool?(true));
        
        public void ListHangMuc() => this._iView.BLstHangMuc = MasterDataPresenter<INewHopDongView>._iMasterDataModel.ListHangMuc_ByCondition(new DateTime?(DateTime.MinValue), new DateTime?(DateTime.MinValue), string.Empty, string.Empty, new bool?(true));

        public void SaveHopDong(BindingList<ObjHopDong> blstCT) => this._iView.IsSuccessfulSaved = MasterDataPresenter<INewHopDongView>._iMasterDataModel.SaveHopDong(blstCT);

        public void SaveHopDong(ObjHopDong objHD)
        {
            ObjHopDong objHopDong = MasterDataPresenter<INewHopDongView>._iMasterDataModel.SaveHopDong(objHD);
            this._iView.HopDong = objHopDong;
            this._iView.IsSuccessfulSaved = objHopDong != null && objHopDong.HopDongID > 0;
        }

        public void SaveHopDong(ObjHopDong objHD, ObjDuLieuTron objDLT)
        {
            ObjHopDong objHopDong = MasterDataPresenter<INewHopDongView>._iMasterDataModel.SaveHopDong(objHD, objDLT);
            this._iView.HopDong = objHopDong;
            this._iView.IsSuccessfulSaved = objHopDong != null && objHopDong.HopDongID > 0;
        }

        public void GetSLMeDuTinh(Decimal klDuTinh, Decimal maxKLTron) => this._iView.SLMeDuTinh = MasterDataPresenter<INewHopDongView>._iMasterDataModel.CalcMeTronQty(klDuTinh, maxKLTron);

        public void GetKLDuTinhMeTron(Decimal klDuTinh, int slMeDuTinh) => this._iView.KLDuTinhMeTron = MasterDataPresenter<INewHopDongView>._iMasterDataModel.CalcKLDTMeTron(klDuTinh, slMeDuTinh);

        public ObjKhachHang GetKhachHangByKey(int khID) => MasterDataPresenter<ITronOnlineView>._iMasterDataModel.GetKhachHangByKey(khID);
        public ObjCongTruong GetCongTruongByKey(int ctID) => MasterDataPresenter<ITronOnlineView>._iMasterDataModel.GetCongTruongByKey(ctID);
        public ObjMAC GetMACByKey(int macID) => MasterDataPresenter<ITronOnlineView>._iMasterDataModel.GetMACByKey(macID);
        public ObjHangMuc GetHangMucByKey(int hangmucID) => MasterDataPresenter<ITronOnlineView>._iMasterDataModel.GetHangMucByKey(hangmucID);

    }
}
