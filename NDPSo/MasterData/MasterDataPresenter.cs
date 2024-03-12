using System;

namespace NDPSo.MasterData
{
	public class MasterDataPresenter<T> where T : IBase
	{
		public MasterDataPresenter(T view)
		{
			this._iView = view;
		}

		private protected static IMasterDataModel _iMasterDataModel { get; private set; } = new MasterDataModel();

		private protected T _iView { get; private set; }
	}
}
