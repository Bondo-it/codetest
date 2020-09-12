
namespace Specification.Specifications
{
	public interface ICompositeSpecification<T>
	{
		ISpecification<T> And(ISpecification<T> other);
		ISpecification<T> AndNot(ISpecification<T> other);
		global::System.Boolean IsSatisfiedBy(T candidate);
		ISpecification<T> Not();
		ISpecification<T> Or(ISpecification<T> other);
		ISpecification<T> OrNot(ISpecification<T> other);
	}
}