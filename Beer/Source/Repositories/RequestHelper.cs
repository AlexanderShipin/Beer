using System;
using System.IO;
using System.Net;
using System.Web.Configuration;

namespace Beer.Source.Repositories
{
	public class RequestHelper
	{
		static string beerApi = WebConfigurationManager.AppSettings["BeerApi"];
		static string key = WebConfigurationManager.AppSettings["ApiKey"];

		public static string BeersRequest(string requestParams)
		{
			var request = (HttpWebRequest)WebRequest.Create($"{beerApi}/beers?key={key}{requestParams}");
			request.Method = "GET";

			string json;
			using (var response = request.GetResponse())
			{
				var respStream = response.GetResponseStream();

				if (respStream == null)
					throw new Exception("Request to beer api failed");

				using (var streamReader = new StreamReader(respStream))
				{
					json = streamReader.ReadToEnd();
				}
			}

			return json;
		}

		public static string BeerRequest(string id)
		{

			var request = (HttpWebRequest)WebRequest.Create($"{beerApi}/beer/{id}?key={key}");
			request.Method = "GET";

			string json;
			using (var response = request.GetResponse())
			{
				var respStream = response.GetResponseStream();

				if (respStream == null)
					throw new Exception("Request to beer api failed");

				using (var streamReader = new StreamReader(respStream))
				{
					json = streamReader.ReadToEnd();
				}
			}

			return json;
		}
	}
}