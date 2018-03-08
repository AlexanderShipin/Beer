using Beer.Models;
using Brewery.Source.DataProviders;
using Newtonsoft.Json;
namespace Beer.Source.Repositories
{
	public class BeerRepository : IRepository<BeerGridModel>
	{
		private RequestHelper _requestHelper = new RequestHelper();

		public BeerGridModel Filter(string exression)
		{
			throw new System.NotImplementedException();
		}

		public BeerGridModel Get()
		{
			var json = _requestHelper.Request();

			if (string.IsNullOrEmpty(json))
				return null;

			var beerGridModel = JsonConvert.DeserializeObject<BeerGridModel>(json);

			return beerGridModel;
		}

		public BeerGridModel Sort(string field, string order)
		{
			throw new System.NotImplementedException();
		}
	}
}