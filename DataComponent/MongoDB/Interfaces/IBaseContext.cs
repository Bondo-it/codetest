using DomainModels.Models.Interfaces;

namespace DataComponent.MongoDB.Interfaces
{
	public interface IBaseContext
	{
		IRepository<T> ResolveRepository<T>() where T : IEntity;
	}
}