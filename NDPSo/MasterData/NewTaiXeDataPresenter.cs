using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    public class NewTaiXeDataPresenter : MasterDataPresenter<INewTaiXeView>
    {
        public NewTaiXeDataPresenter(INewTaiXeView view)
          : base(view)
        {
        }

        public void BuildNewTaiXe() => this._iView.TaiXe = new ObjTaiXe()
        {
            MaTaiXe = MasterDataPresenter<INewTaiXeView>._iMasterDataModel.GetNextCode("TaiXe"),
            GioiTinh = "M",
            Activated = true
        };

        public void GetTaiXeByKey(int soID) => this._iView.TaiXe = MasterDataPresenter<INewTaiXeView>._iMasterDataModel.GetTaiXeByKey(soID);

        public void SaveTaiXe(BindingList<ObjTaiXe> blstCT) => this._iView.IsSuccessfulSaved = MasterDataPresenter<INewTaiXeView>._iMasterDataModel.SaveTaiXe(blstCT);
    }
}
