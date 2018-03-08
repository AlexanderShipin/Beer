using System.Web.Mvc;

using Beer.Models;
using Beer.Source.Repositories;

namespace Beer.Controllers
{
	public class HomeController : Controller
	{
		IRepository<BeerGridModel> _repository;

		public HomeController()
		{
			_repository = new BeerRepository();
		}

		public HomeController(IRepository<BeerGridModel> repository)
		{
			_repository = repository;
		}

		public ViewResult Index()
		{
			var model = _repository.Get();

			return View(model);
		}
	}
}