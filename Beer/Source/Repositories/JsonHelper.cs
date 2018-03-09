using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Beer.Models;

namespace Beer.Source.Repositories
{
	public class JsonHelper
	{
		public static BeerGridModel JsonToBeerGridModel(string json)
		{
			return JsonConvert.DeserializeObject<BeerGridModel>(json);
		}

		public static BeerDetailsModel JsonToBeerDetailsModel(string json)
		{
			var response = JObject.Parse(json);
			var beer = response["data"];
			var beerDetailsModel = beer.ToObject<BeerDetailsModel>();
			return beerDetailsModel;
		}
	}
}