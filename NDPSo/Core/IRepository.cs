using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Data.Objects;
using System.Linq.Expressions;

namespace NDPSo.Core
{
	public interface IRepository<E, C>
	{
		DbTransaction BeginTransaction();

		void Add(E entity);

		void AddOrAttach(E entity);

		void DeleteRelatedEntries(E entity);

		void DeleteRelatedEntries(E entity, ObservableCollection<string> keyListOfIgnoreEntites);

		void Delete(E entity);

		int Save();

		ObjectQuery<E> DoQuery(string entitySetName);

		ObjectQuery<E> DoQuery();

		ObjectQuery<E> DoQuery(string entitySetName, ISpecification<E> where);

		ObjectQuery<E> DoQuery(ISpecification<E> where);

		ObjectQuery<E> DoQuery(int maximumRows, int startRowIndex);

		ObjectQuery<E> DoQuery<T>(Expression<Func<E, T>> sortExpression);

		ObjectQuery<E> DoQuery<T>(Expression<Func<E, T>> sortExpression, int maximumRows, int startRowIndex);

		IList<E> SelectAll(string entitySetName);

		IList<E> SelectAll();

		IList<E> SelectAll(string entitySetName, ISpecification<E> where);

		IList<E> SelectAll(ISpecification<E> where);

		IList<E> SelectAll(int maximumRows, int startRowIndex);

		IList<E> SelectAll<T>(Expression<Func<E, T>> sortExpression);

		IList<E> SelectAll<T>(Expression<Func<E, T>> sortExpression, int maximumRows, int startRowIndex);

		E SelectByKey(int Key);

		bool TrySameValueExist(string fieldName, object fieldValue, int key);

		bool TryEntity(ISpecification<E> selectSpec);

		int GetCount();

		int GetCount(ISpecification<E> selectSpec);

		bool LazyLoadingEnabled { set; }
	}
}
