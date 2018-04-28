using System.Collections.Generic;
using System.Linq.Expressions;

namespace Hxf.Infrastructure.Specifications
{
	internal class ParameterRebinder : ExpressionVisitor {
		
		#region Private Fields

		private readonly Dictionary<ParameterExpression, ParameterExpression> _map;
		
		#endregion

		#region Ctor
		
		internal ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map) {
			_map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
		}
		
		#endregion

		#region Internal Static Methods
		
		internal static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp) {
			return new ParameterRebinder(map).Visit(exp);
		}
		
		#endregion

		#region Protected Methods
		
		protected override Expression VisitParameter(ParameterExpression p) {
			ParameterExpression replacement;
			if (_map.TryGetValue(p, out replacement)) {
				p = replacement;
			}
			return base.VisitParameter(p);
		}
		
		#endregion
	}
}