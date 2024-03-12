using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Core
{
    public interface IEFRepository<T> where T : class
    {
        void Add(T entity);

        void Attach(T entity);

        void Delete(T entity);

        void Delete(Expression<Func<T, bool>> where);

        IEnumerable<T> GetAll();

        IEnumerable<T> Get(Expression<Func<T, bool>> where);
        IQueryable<T> DoQuery();
        IQueryable<T> DoQuery(ISpecification<T> where);

        IList<T> SelectAll();
        IList<T> SelectAll(ISpecification<T> where);
        IList<T> SelectAll(Expression<Func<T, bool>> where);

        T GetById(int id);

        void Update(T entity);

        void Save();
    }
}
