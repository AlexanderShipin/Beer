using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Beer.Source.Repositories;

namespace Beer.Tests
{
	[TestClass]
	public class JsonHelperTests
	{
		[TestMethod]
		public void JsonHelper_JsonToBeerGridModel()
		{
			var json = "{\"currentPage\":1,\"numberOfPages\":1444,\"totalResults\":72181,\"status\":\"success\",\"data\":[{\"id\":\"cBLTUw\",\"glasswareId\":5,\"glass\":{\"id\":5,\"name\":\"Pint\",\"createDate\":\"2012-01-03 02:41:33\"},\"available\":{\"name\":\"Year Round\"},\"name\":\"\\\"18\\\" Imperial IPA 2\",\"nameDisplay\":\"\\\"18\\\" Imperial IPA 2\",\"ibu\" : \"2\",\"abv\" : \"2.1\",\"isOrganic\" : \"Y\",\"createDate\":\"2012-01-03 02:41:33\",\"statusDisplay\":\"Verified\",\"extraFieldToTest\":\"Verified\"},{\"id\":\"cBLTUw\",\"glasswareId\":5,\"glass\":{\"id\":5,\"name\":\"Pint\",\"createDate\":\"2012-01-03 02:41:33\"},\"available\":{\"name\":\"Year Round\"},\"name\":\"\\\"18\\\" Imperial IPA 2\",\"nameDisplay\":\"\\\"18\\\" Imperial IPA 2\",\"ibu\" : \"2\",\"abv\" : \"2.1\",\"isOrganic\" : \"Y\",\"createDate\":\"2012-01-03 02:41:33\",\"statusDisplay\":\"Verified\",\"extraFieldToTest\":\"Verified\"}]}";

			var beerGridModel = JsonHelper.JsonToBeerGridModel(json);

			Assert.AreEqual(beerGridModel.CurrentPage, 1);
			Assert.AreEqual(beerGridModel.NumberOfPages, 1444);
			Assert.AreEqual(beerGridModel.TotalResults, 72181);
			Assert.AreEqual(beerGridModel.Status, "success");
			Assert.AreEqual(beerGridModel.Data[0].Id, "cBLTUw");
			Assert.AreEqual(beerGridModel.Data[0].Glass, "Pint");
			Assert.AreEqual(beerGridModel.Data[0].CreateDate, Convert.ToDateTime("2012-01-03 02:41:33"));
			Assert.AreEqual(beerGridModel.Data[0].Available, "Year Round");
			Assert.AreEqual(beerGridModel.Data[0].Name, "\"18\" Imperial IPA 2");
			Assert.AreEqual(beerGridModel.Data[0].Ibu, 2m);
			Assert.AreEqual(beerGridModel.Data[0].Abv, 2.1m);
			Assert.AreEqual(beerGridModel.Data[0].IsOrganic, "Y");
			Assert.AreEqual(beerGridModel.Data[0].StatusDisplay, "Verified");
			Assert.AreEqual(beerGridModel.Data.Count, 2);
		}

		[TestMethod]
		public void JsonHelper_JsonToBeerDetailsModel()
		{
			var json = "{\"message\":\"Request Successful\",\"data\":{\"id\":\"cBLTUw\",\"name\":\"\\\"18\\\" Imperial IPA 2\",\"ibu\" : \"2\",\"abv\" : \"2.1\", \"description\" : \"American - style India pale ales are perceived to have medium-high to intense hop bitterness\"}}";

			var beerGridModel = JsonHelper.JsonToBeerDetailsModel(json);

			Assert.AreEqual(beerGridModel.Id, "cBLTUw");
			Assert.AreEqual(beerGridModel.Name, "\"18\" Imperial IPA 2");
			Assert.AreEqual(beerGridModel.Ibu, 2m);
			Assert.AreEqual(beerGridModel.Abv, 2.1m);
			Assert.AreEqual(beerGridModel.Description, "American - style India pale ales are perceived to have medium-high to intense hop bitterness");
		}
	}
}
