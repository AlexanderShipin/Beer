using System.Collections.Generic;

namespace Beer.Models
{
	public class BeerGridModel
	{
		public int CurrentPage { get; set; }
		public int NumberOfPages { get; set; }
		public int TotalResults { get; set; }
		public List<BeerModel> Data { get; set; }
		public string Status { get; set; }
	}
}