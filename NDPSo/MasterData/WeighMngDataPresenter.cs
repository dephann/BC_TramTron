using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    public class WeighMngDataPresenter : MasterDataPresenter<IWeighMngView>
    {
        public WeighMngDataPresenter(IWeighMngView view)
          : base(view)
        {
        }

        public void ListWeigh() => this._iView.BLstWeigh = MasterDataPresenter<IWeighMngView>._iMasterDataModel.ListWeigh();

        public void SaveWeigh(BindingList<ObjWeigh> blstWeigh) => this._iView.IsSuccessfulSaved = MasterDataPresenter<IWeighMngView>._iMasterDataModel.SaveWeigh(blstWeigh);
    }
}

