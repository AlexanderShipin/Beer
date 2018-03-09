using System;

using Newtonsoft.Json;

using Beer.Source.Repositories;

namespace Beer.Models
{
	public class BeerInGridModel
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public decimal? Abv { get; set; }
		public decimal? Ibu { get; set; }

		[JsonConverter(typeof(BeerModelJsonConverter))]
		public string Glass { get; set; }//glass.name
		[JsonConverter(typeof(BeerModelJsonConverter))]
		public string Available { get; set; }//available.name
		public string IsOrganic { get; set; }
		public string StatusDisplay { get; set; }
		public DateTime CreateDate { get; set; }
	}
}