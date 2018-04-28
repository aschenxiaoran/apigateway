namespace Hxf.Infrastructure.Specifications {
	public abstract class CompositeSpecification<T> : Specification<T>, ICompositeSpecification<T> {

		private readonly ISpecification<T> _left;
		private readonly ISpecification<T> _right;

		protected CompositeSpecification(ISpecification<T> left, ISpecification<T> right) {
			_left = left;
			_right = right;
		}

		public ISpecification<T> Left {
			get { return _left; }
		}
		public ISpecification<T> Right {
			get { return _right; }
		}
	}
}