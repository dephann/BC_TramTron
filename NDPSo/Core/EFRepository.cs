using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace NDPSo.Core
{
    public class EFRepository<T> : IEFRepository<T>, IDisposable  where T : class
    {
        private IDBContext _dbContext;
        private string _keyProperty = "ID";
        private DbSet<T> _dbSet { get; set; }
        

        public EFRepository(IDbContextManager dbCtxMng)
        {
            this.SetContext(dbCtxMng.GetDBContext());
        }
        private void SetContext(IDBContext ctx)
        {
            _dbContext = ctx;
            _dbSet = ctx.Set<T>() as DbSet<T>;

        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }
        public void Attach(T entity)
        {
            _dbSet.Attach(entity);
        }

        public void Delete(T entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }

            _dbSet.Remove(entity);
        }

        public void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = _dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                _dbSet.Remove(obj);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> where)
        {
            if (_dbSet == null)
            {
                throw new Exception("_dbSet is null");
            }
            return _dbSet.Where(where).ToList();
        }
        /*public IQueryable<T> DoQuery(ISpecification<T> where)
        {
            return this._dbContext.Set<T>().Where(where.EvalPredicate);
        }*/
        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        protected string GetKeyColumnName(T entity, DbContext context)
        {
            var objectContext = ((IObjectContextAdapter)context).ObjectContext;
            var entityType = objectContext.CreateObjectSet<T>().EntitySet;
            var pk = entityType.ElementType.KeyMembers.First();
            var pkName = pk.Name;
            return pkName;
        }
        public IQueryable<T> DoQuery()
        {
            return this._dbContext.Set<T>().AsQueryable();
        }
        public IQueryable<T> DoQuery(ISpecification<T> where)
        {
            return this._dbContext.Set<T>().AsQueryable().Where(where.EvalPredicate);
        }
        public IList<T> SelectAll()
        {
            IList<T> result;
            try
            {
                result = _dbSet.ToList<T>();
                result = _dbContext.Set<T>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
        public IList<T> SelectAll(Expression<Func<T, bool>> where)
        {
            /*Expression<Func<T, bool>> predicate = where.EvalPredicate;
            IQueryable<T> query = _dbContext.Set<T>().Where(predicate);
            return query.ToList();*/
            //return this.DoQuery(where).ToList<T>();
            return Get(where).ToList<T>();
            //return FindByCondition(where).ToList<T>();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _dbContext.Set<T>().Where(expression);
        }

        public void Dispose()
        {
            if ((object)this._dbContext == null)
                return;
            this._dbContext.Dispose();
        }

        public IList<T> SelectAll(ISpecification<T> where)
        {
            return this.DoQuery(where).ToList<T>();
        }

        public string KeyProperty
        {
            get
            {
                return this._keyProperty;
            }
            set
            {
                this._keyProperty = value;
            }
        }
    }
}
