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
    public class PhieuTronMngDataPresenter : MasterDataPresenter<IPhieuTronMngView>
    {
        public PhieuTronMngDataPresenter(IPhieuTronMngView view)
          : base(view)
        {
        }

        public void ListPhieuTron() => this._iView.BLstPhieuTron = MasterDataPresenter<IPhieuTronMngView>._iMasterDataModel.ListPhieuTron();

        public void ListPhieuTron(
          string maPhieuTron,
          DateTime fromDate,
          DateTime toDate,
          int? status,
          bool? isQueued)
        {
            this._iView.BLstPhieuTron = MasterDataPresenter<IPhieuTronMngView>._iMasterDataModel.ListPhieuTron_ByCondition(maPhieuTron, fromDate, toDate, status, isQueued);
        }

        public void SavePhieuTron(BindingList<ObjPhieuTron> blstCT) => this._iView.IsSuccessfulSaved = MasterDataPresenter<IPhieuTronMngView>._iMasterDataModel.SavePhieuTron(blstCT);

        public void ListPhieuTronStatus() => this._iView.LstPhieuTronStatus = Converter.EnumToListFieldCode<Enums.PhieuTronStatus>(true);
        public void ListHopDong() => this._iView.BLstHopDong = MasterDataPresenter<IPhieuTronMngView>._iMasterDataModel.ListHopDong();

        public ObjPhieuTron GetPhieuTronByKey(int ptID) => MasterDataPresenter<ITronOnlineView>._iMasterDataModel.GetPhieuTronByKey(ptID);

        public ObjKhachHang GetKhachHangByKey(int khID) => MasterDataPresenter<ITronOnlineView>._iMasterDataModel.GetKhachHangByKey(khID);
        public ObjCongTruong GetCongTruongByKey(int ctID) => MasterDataPresenter<ITronOnlineView>._iMasterDataModel.GetCongTruongByKey(ctID);
        public ObjMAC GetMACByKey(int macID) => MasterDataPresenter<ITronOnlineView>._iMasterDataModel.GetMACByKey(macID);
        public ObjTaiXe GetTaiXeByKey(int txID) => MasterDataPresenter<ITronOnlineView>._iMasterDataModel.GetTaiXeByKey(txID);
        public ObjXe GetXeByKey(int xeID) => MasterDataPresenter<ITronOnlineView>._iMasterDataModel.GetXeByKey(xeID);
        public void ListMeTron(int ptID) => this._iView.BLstMeTron = MasterDataPresenter<INewPhieuTronView>._iMasterDataModel.ListMeTronByPhieuTronID(ptID);
        public void ListMeTronChiTiet(int ptID) => this._iView.BLstMeTronChiTiet = MasterDataPresenter<INewPhieuTronView>._iMasterDataModel.ListMeTronChiTietByPhieuTronID(ptID);
        public ObjHopDong GetHopDongByKey(int hdID) => MasterDataPresenter<ITronOnlineView>._iMasterDataModel.GetHopDongByKey(hdID);
        
    }
}

