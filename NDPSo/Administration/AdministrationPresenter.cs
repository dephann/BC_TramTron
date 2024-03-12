using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Administration
{
    public class AdministrationPresenter<T> where T : IBase
    {
        protected static IAdministrationModel _iAdministrationModel { get; private set; }

        protected T _iView { get; private set; }

        static AdministrationPresenter() => AdministrationPresenter<T>._iAdministrationModel = (IAdministrationModel)new AdministrationModel();

        public AdministrationPresenter(T view) => this._iView = view;
    }
}
