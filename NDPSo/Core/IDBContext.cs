using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Core
{
	public interface IDBContext : IDisposable
	{
		IDbSet<TEntity> Set<TEntity>() where TEntity : class;
		DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
		void SaveChanges();
	}
}
