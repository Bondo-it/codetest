namespace DataComponent.MongoDB.Interfaces
{
	public interface IDbBuilder
	{
		string GetDatabaseName();

		string GetConnectionString();
	}
}