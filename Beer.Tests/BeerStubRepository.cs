using System;
using System.Collections.Generic;

using Beer.Models;
using Beer.Source.Repositories;

namespace Beer.Tests
{
	class BeerStubRepository : IBeerRepository
	{
		public BeerGridModel Get(string name, bool? isOrganic, int? page, string order, string sort)
		{
			var beerGridModel = new BeerGridModel() {
				CurrentPage = 1,
				NumberOfPages = 2,
				Status = "Success",
				TotalResults = 2
			};

			var beerModel = new BeerInGridModel {
				Id = "id",
				Name = name,
				Abv = 2.1m,
				Ibu = 2.2m,
				Glass = "Pint",
				Available = "Year Round",
				IsOrganic = "Y",
				StatusDisplay = "Verified",
				CreateDate = new DateTime(2018, 1, 1)
			};

			beerGridModel.Data = new List<BeerInGridModel> { beerModel };

			return beerGridModel;
		}

		public BeerDetailsModel Get(string id)
		{
			var beerDetailsModel = new BeerDetailsModel
				{
					Id = id,
					Name = "Beer1",
					Abv = 2.1m,
					Ibu = 2.2m,
					Description = "Description1"
				};
			return beerDetailsModel;
		}
	}
}
