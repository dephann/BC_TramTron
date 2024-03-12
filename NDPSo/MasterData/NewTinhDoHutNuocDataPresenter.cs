using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    public class NewTinhDoHutNuocDataPresenter : MasterDataPresenter<INewTinhDoHutNuocView>
    {
        public NewTinhDoHutNuocDataPresenter(INewTinhDoHutNuocView view)
          : base(view)
        {
        }

        public void BuildNewTinhDoHutNuoc() => this._iView.TinhDoHutNuoc = new ObjTinhDoHutNuoc()
        {
            NgayTinhDoHut = DateTime.Now,
            MaTinhDoHutNuoc = MasterDataPresenter<INewTinhDoHutNuocView>._iMasterDataModel.GetNextCode("TinhDoHutNuoc"),
            BLstTinhDoHutNuocChiTiet = new BindingList<ObjTinhDoHutNuocChiTiet>()
        };

        public void GetTinhDoHutNuocByKey(int soID) => this._iView.TinhDoHutNuoc = MasterDataPresenter<INewTinhDoHutNuocView>._iMasterDataModel.GetTinhDoHutNuocByKey(soID);

        public void SaveTinhDoHutNuoc(BindingList<ObjTinhDoHutNuoc> blstCT) => this._iView.IsSuccessfulSaved = MasterDataPresenter<INewTinhDoHutNuocView>._iMasterDataModel.SaveTinhDoHutNuoc(blstCT);

        public void ListNhomSilo() => this._iView.BLstNhomSilo = MasterDataPresenter<INewTinhDoHutNuocView>._iMasterDataModel.ListNhomSilo();
    }
}
