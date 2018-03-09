using Beer.Models;

namespace Beer.Source.Repositories
{
	public interface IBeerRepository
	{
		BeerGridModel Get(string name, bool? isOrganic, int? page, string order, string sort);
		BeerDetailsModel Get(string id);
	}
}
