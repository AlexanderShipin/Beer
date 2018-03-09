namespace Beer.Source.Repositories
{
	public interface IRepository<T> where T : class
	{
		T Get(string name, bool? isOrganic, int? page, string order, string sort);
	}
}
