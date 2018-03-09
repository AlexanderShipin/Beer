namespace Beer.Models
{
	public class BeerDetailsModel
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public decimal? Abv { get; set; }
		public decimal? Ibu { get; set; }
		public string Description { get; set; }
	}
}