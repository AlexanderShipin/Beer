using Beer.Models;

namespace Beer.Source.Repositories
{
	public class BeerRepository : IBeerRepository
	{
		public BeerGridModel Get(string name, bool? isOrganic, int? page, string order, string sort)
		{
			var requestParams = getParameterString(name, isOrganic, page, order, sort);
			var json = RequestHelper.BeersRequest(requestParams);

			if (string.IsNullOrEmpty(json))
				return null;

			var beerGridModel = JsonHelper.JsonToBeerGridModel(json);

			return beerGridModel;
		}

		public BeerDetailsModel Get(string id)
		{
			var json = RequestHelper.BeerRequest(id);

			if (string.IsNullOrEmpty(json))
				return null;

			var beerDetailsModel = JsonHelper.JsonToBeerDetailsModel(json);

			return beerDetailsModel;
		}

		private string getParameterString(string name, bool? isOrganic, int? page, string order, string sort)
		{
			string result = string.Empty;
			if (name != null)
				result += $"&name={name}";
			if (isOrganic != null && isOrganic.HasValue)
			{
				var isOrganicString = ((bool)isOrganic) ? "Y" : "N";
				result += $"&isOrganic={isOrganicString}";
			}
			if (page != null && page.HasValue)
				result += $"&p={page.Value}";
			if (order != null)
				result += $"&order={order}";
			if (sort != null)
				result += $"&sort={sort}";

			return result;
		}
	}
}