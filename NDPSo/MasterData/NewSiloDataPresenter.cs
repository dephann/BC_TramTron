using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    public class NewSiloDataPresenter : MasterDataPresenter<INewSiloView>
    {
        public NewSiloDataPresenter(INewSiloView view)
          : base(view)
        {
        }

        public void BuildNewSilo() => this._iView.Silo = new ObjSilo()
        {
            MaSilo = string.Empty,
            TenSilo = string.Empty,
            NhomSiloID = 0,
            MaterialID = new int?(),
            SaiSoDuoi = new Decimal?(0M),
            SaiSoTren = new Decimal?(0M),
            KLCanNhoNhat = new Decimal?(0M),
            KLCanLonNhat = new Decimal?(0M),
            TGNhapNhaOn = new Decimal?(0M),
            TGNhapNhaOff = new Decimal?(0M),
            TGKiemTraVatLieuRoi = new Decimal?(0M),
            KLRoi = new Decimal?(0M),
            KLDT_Tu1 = new Decimal?(0M),
            KLDT_Tu2 = new Decimal?(0M),
            KLDT_Tu3 = new Decimal?(0M),
            KLDT_Den1 = new Decimal?(0M),
            KLDT_Den2 = new Decimal?(0M),
            KLDT_Den3 = new Decimal?(0M),
            KLDT_DungTruoc1 = new Decimal?(0M),
            KLDT_DungTruoc2 = new Decimal?(0M),
            KLDT_DungTruoc3 = new Decimal?(0M),
            Activated = new bool?(true)
        };

        public void GetSiloByKey(int soID) => this._iView.Silo = MasterDataPresenter<INewSiloView>._iMasterDataModel.GetSiloByKey(soID);

        public void ListNhomSilo() => this._iView.BLstNhomSilo = MasterDataPresenter<INewSiloView>._iMasterDataModel.ListNhomSilo();

        public void ListMaterial() => this._iView.BLstMaterial = MasterDataPresenter<INewSiloView>._iMasterDataModel.ListMaterial();

        public void ListSiloNhomAgg() => this._iView.BLstSiloNhomAgg = MasterDataPresenter<INewSiloView>._iMasterDataModel.ListSilo_ByActivated_ByMaNhomSilo(true, "Agg");

        public void SaveSilo(BindingList<ObjSilo> blstCT) => this._iView.IsSuccessfulSaved = MasterDataPresenter<INewSiloView>._iMasterDataModel.SaveSilo(blstCT);
    }
}
