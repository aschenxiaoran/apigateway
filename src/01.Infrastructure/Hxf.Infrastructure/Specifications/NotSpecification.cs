using System;
using System.Linq.Expressions;

namespace Hxf.Infrastructure.Specifications
{
	public class NotSpecification<T> : Specification<T> {

		private readonly ISpecification<T> _spec;

		public NotSpecification(Specification<T> specification) {
			this._spec = specification;
		}

		public override Expression<Func<T, bool>> GetExpression() {
			var body = Expression.Not(this._spec.GetExpression().Body);
			return Expression.Lambda<Func<T, bool>>(body, this._spec.GetExpression().Parameters);
		}
	}
}