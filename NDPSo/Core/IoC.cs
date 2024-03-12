using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NDPSo.Core
{
    public sealed class IoC
    {
        private static IUnityContainer _container = new UnityContainer();

        public static void Register<I, T>() where T : I
        {
            IoC.Current.Container.RegisterType<I, T>(new ContainerControlledLifetimeManager());
        }

        public static void InjectStub<I>(I instance)
        {
            IoC.Current.Container.RegisterInstance<I>(instance, new ContainerControlledLifetimeManager());
        }

        public static T Retrieve<T>()
        {
            return IoC.Current.Container.Resolve<T>();
        }
        public static IoC Current
        {
            get
            {
                return IoC.Nested.Instance;
            }
        }
        public IUnityContainer Container
        {
            get 
            {
                if (_container == null)
                {
                    _container = new UnityContainer();
                }
                return _container;
            }
        }
        private class Nested
        {
            internal static readonly IoC Instance = new IoC();
        }
    }
}
