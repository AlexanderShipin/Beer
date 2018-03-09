using System;
using System.IO;
using System.Net;
using System.Web.Configuration;

namespace Beer.Source.Repositories
{
	public class RequestHelper
	{
		public string Request(string requestParams)
		{
			var beerApi = WebConfigurationManager.AppSettings["BeerApi"];
			var key = WebConfigurationManager.AppSettings["ApiKey"];

			var request = (HttpWebRequest)WebRequest.Create($"{beerApi}?key={key}{requestParams}");
			request.Method = "GET";

			//var json = "{\"currentPage\":1,\"numberOfPages\":1444,\"totalResults\":72181,\"status\":\"success\",\"data\":[{\"id\":\"cBLTUw\",\"glasswareId\":5,\"glass\":{\"id\":5,\"name\":\"Pint\",\"createDate\":\"2012-01-03 02:41:33\"},\"available\":{\"name\":\"Year Round\"},\"name\":\"\\\"18\\\" Imperial IPA 2\",\"nameDisplay\":\"\\\"18\\\" Imperial IPA 2\",\"ibu\" : \"2\",\"abv\" : \"2.1\",\"isOrganic\" : \"Y\",\"createDate\":\"2012-01-03 02:41:33\",\"statusDisplay\":\"Verified\",\"extraFieldToTest\":\"Verified\"},{\"id\":\"cBLTUw111\",\"glasswareId\":5,\"glass\":{\"id\":5,\"name\":\"Pint\",\"createDate\":\"2012-01-03 02:41:33\"},\"available\":{\"name\":\"Year Round\"},\"name\":\"\\\"18\\\" Imperial IPA 2\",\"nameDisplay\":\"\\\"18\\\" Imperial IPA 2\",\"ibu\" : \"2\",\"abv\" : \"2.1\",\"isOrganic\" : \"Y\",\"createDate\":\"2012-01-03 02:41:33\",\"statusDisplay\":\"Verified\",\"extraFieldToTest\":\"Verified\"}]}";//mock json for test
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