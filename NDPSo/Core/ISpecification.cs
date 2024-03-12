using System;
using System.Linq.Expressions;

namespace NDPSo.Core
{
	public interface ISpecification<T>
	{
		Expression<Func<T, bool>> EvalPredicate { get; }

		Func<T, bool> EvalFunc { get; }
	}
}
