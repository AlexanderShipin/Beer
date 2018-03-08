namespace Beer.Source.Repositories
{
	public interface IRepository<T> where T : class
	{
		T Get();
		T Sort(string field, string order);
		T Filter(string exression);
	}
}
