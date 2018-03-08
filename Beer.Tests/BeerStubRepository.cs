﻿using System;
using System.Collections.Generic;

using Beer.Models;
using Beer.Source.Repositories;

namespace Beer.Tests
{
	class BeerStubRepository : IRepository<BeerGridModel>
	{
		public BeerGridModel Filter(string exression)
		{
			throw new NotImplementedException();
		}

		public BeerGridModel Get()
		{
			var beerGridModel = new BeerGridModel() {
				CurrentPage = 1,
				NumberOfPages = 2,
				Status = "Success",
				TotalResults = 2
			};

			var beerModel = new BeerModel {
				Id = "id",
				Name = "Beer1",
				Abv = 2.1m,
				Ibu = 2.2m,
				Glass = "Pint",
				Available = "Year Round",
				IsOrganic = "Y",
				StatusDisplay = "Verified",
				CreateDate = new DateTime(2018, 1, 1)
			};

			beerGridModel.Data = new List<BeerModel> { beerModel };

			return beerGridModel;
		}

		public BeerGridModel Sort(string field, string order)
		{
			throw new NotImplementedException();
		}
	}
}
