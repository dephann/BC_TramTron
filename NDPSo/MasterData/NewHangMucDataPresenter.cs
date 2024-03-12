using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    class NewHangMucDataPresenter : MasterDataPresenter<INewHangMucView>
    {
        public NewHangMucDataPresenter(INewHangMucView view)
          : base(view)
        {
        }

        public void BuildNewHangMuc() => this._iView.HangMuc = new ObjHangMuc()
        {
            MaHangMuc = MasterDataPresenter<INewHangMucView>._iMasterDataModel.GetNextCode("HangMuc"),
            Activated = true
        };

        public void GetHangMucByKey(int soID) => this._iView.HangMuc = MasterDataPresenter<INewHangMucView>._iMasterDataModel.GetHangMucByKey(soID);

        public void SaveHangMuc(BindingList<ObjHangMuc> blstCT) => this._iView.IsSuccessfulSaved = MasterDataPresenter<INewHangMucView>._iMasterDataModel.SaveHangMuc(blstCT);
    }
}