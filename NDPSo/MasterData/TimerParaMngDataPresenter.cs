using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    public class TimerParaMngDataPresenter : MasterDataPresenter<ITimerParaMngView>
    {
        public TimerParaMngDataPresenter(ITimerParaMngView view)
          : base(view)
        {
        }

        public void ListTimerPara() => this._iView.BLstTimerPara = MasterDataPresenter<ITimerParaMngView>._iMasterDataModel.ListTimerPara();

        public void SaveTimerPara(BindingList<ObjTimerPara> blstTimerPara) => this._iView.IsSuccessfulSaved = MasterDataPresenter<ITimerParaMngView>._iMasterDataModel.SaveTimerPara(blstTimerPara);
    }
}
