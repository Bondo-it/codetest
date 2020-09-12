namespace Frontend.Services
{
	public interface IViewRender
	{
		string Render<TModel>(string name, TModel model);
	}
}