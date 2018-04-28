namespace Hxf.Infrastructure.Specifications
{
	public interface ICompositeSpecification<T> {
		
		ISpecification<T> Left { get; }
		
		ISpecification<T> Right { get; }
	}
}