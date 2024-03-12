using System;
using System.Data.Entity;
using System.Data.Objects;
using Microsoft.Practices.Unity;

namespace NDPSo.Core
{
	public class RepositoryService<TContext> : IDbContextManager where TContext : DbContext, IDBContext, new()
	{
        private TContext _dbContext;

        public void Initialize(TContext context)
        {
            this._dbContext = context;
            IoC.Current.Container.RegisterInstance(this);
            IoC.Current.Container.RegisterType(typeof(IEFRepository<>), typeof(EFRepository<>), new InjectionMember[0]);
        }

        public IDBContext GetDBContext()
        {
            return this._dbContext;
        }

        public IUnityContainer Container { get; set; }
    }
}
