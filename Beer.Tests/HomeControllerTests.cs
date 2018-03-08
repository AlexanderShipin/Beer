using System;
using System.Web.Mvc;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Beer.Controllers;
using Beer.Tests;
using Beer.Models;

namespace Brewery.Tests
{
	[TestClass]
	public class HomeControllerTests
	{
		[TestMethod]
		public void Index_Get_AsksForIndexView()
		{
			var controller = new HomeController(new BeerStubRepository());

			ViewResult result = controller.Index();

			Assert.AreEqual("Index", result.ViewName);
		}

		[TestMethod]
		public void Index_Get_RetrievesAllContactsFromRepository()
		{
			var controller = new HomeController(new BeerStubRepository());

			var result = controller.Index();

			var model = (BeerGridModel)result.ViewData.Model;

			Assert.AreEqual(model.CurrentPage, 1);
			Assert.AreEqual(model.NumberOfPages, 2);
			Assert.AreEqual(model.TotalResults, 2);
			Assert.AreEqual(model.Status, "Success");
			Assert.AreEqual(model.Data[0].Id, "id");
			Assert.AreEqual(model.Data[0].Glass, "Pint");
			Assert.AreEqual(model.Data[0].CreateDate, new DateTime(2018, 1, 1));
			Assert.AreEqual(model.Data[0].Available, "Year Round");
			Assert.AreEqual(model.Data[0].Name, "Beer1");
			Assert.AreEqual(model.Data[0].Ibu, 2.2m);
			Assert.AreEqual(model.Data[0].Abv, 2.1m);
			Assert.AreEqual(model.Data[0].IsOrganic, "Y");
			Assert.AreEqual(model.Data[0].StatusDisplay, "Verified");
		}
	}
}
