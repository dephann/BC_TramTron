using System;
using System.Linq.Expressions;

namespace NDPSo.Core
{
	public class Specification<T> : ISpecification<T>
	{
		public Specification(Expression<Func<T, bool>> predicate)
		{
			this._evalPredicate = predicate;
		}

		private Specification()
		{
		}

		public virtual Expression<Func<T, bool>> EvalPredicate
		{
			get
			{
				return this._evalPredicate;
			}
		}

		public virtual Func<T, bool> EvalFunc
		{
			get
			{
				return this._evalFunc;
			}
		}

		private  Func<T, bool> _evalFunc;

		private  Expression<Func<T, bool>> _evalPredicate;
	}
}
