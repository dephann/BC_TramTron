using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    class HangMucMngDataPresenter : MasterDataPresenter<IHangMucMngView>
    {
        public HangMucMngDataPresenter(IHangMucMngView view)
          : base(view)
        {
        }

        public void ListHangMuc() => this._iView.BLstHangMuc = MasterDataPresenter<IHangMucMngView>._iMasterDataModel.ListHangMuc();

        public void ListHangMuc_ByCondition(
          DateTime? fromDate,
          DateTime? toDate,
          string maKH,
          string tenKH,
          bool? active)
        {
            this._iView.BLstHangMuc = MasterDataPresenter<IHangMucMngView>._iMasterDataModel.ListHangMuc_ByCondition(fromDate, toDate, maKH, tenKH, active);
        }

        public void SaveHangMuc(BindingList<ObjHangMuc> blstCT) => this._iView.IsSuccessfulSaved = MasterDataPresenter<IHangMucMngView>._iMasterDataModel.SaveHangMuc(blstCT);
    }
}
