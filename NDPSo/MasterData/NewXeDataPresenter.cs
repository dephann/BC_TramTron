using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    public class NewXeDataPresenter : MasterDataPresenter<INewXeView>
    {
        public NewXeDataPresenter(INewXeView view)
          : base(view)
        {
        }

        public void BuildNewXe() => this._iView.Xe = new ObjXe()
        {
            BienSo = string.Empty,
            KhoiLuong = new Decimal?(0M),
            GhiChu = string.Empty,
            Activated = true
        };

        public void GetXeByKey(int soID) => this._iView.Xe = MasterDataPresenter<INewXeView>._iMasterDataModel.GetXeByKey(soID);

        public void SaveXe(BindingList<ObjXe> blstCT) => this._iView.IsSuccessfulSaved = MasterDataPresenter<INewXeView>._iMasterDataModel.SaveXe(blstCT);
    }
}
