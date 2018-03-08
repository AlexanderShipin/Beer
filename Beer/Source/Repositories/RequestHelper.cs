using System;
using System.IO;
using System.Net;
using System.Web.Configuration;

namespace Brewery.Source.DataProviders
{
	public class RequestHelper
	{
		public string Request()
		{
			var beerApi = WebConfigurationManager.AppSettings["BeerApi"];
			var key = WebConfigurationManager.AppSettings["ApiKey"];

			//var request = (HttpWebRequest)WebRequest.Create($"{beerApi}");//?key={key}");
			//request.Method = "GET";

			//Stream respStream;
			//using (var response = request.GetResponse())
			//{
			//	respStream = response.GetResponseStream();
			//}

			//if (respStream == null)
			//	throw new Exception("Request to beer api failed");

			var json = "{\"currentPage\":1,\"numberOfPages\":1444,\"totalResults\":72181,\"data\":[{\"id\":\"cBLTUw\",\"glasswareId\":5,\"glass\":{\"id\":5,\"name\":\"Pint\",\"createDate\":\"2012-01-03 02:41:33\"},\"available\":{\"name\":\"Year Round\"},\"name\":\"\\\"18\\\" Imperial IPA 2\"}],\"status\":\"success\"}";//mock json for test

			//using (var StreamReader = new StreamReader(respStream))
			//{
			//	json = StreamReader.ReadToEnd();
			//}

			return json;
		}
	}
}