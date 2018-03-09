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
			return View("Index");
		}

		public JsonResult Beers(string name, bool? isOrganic, int? page, string order, string sort)
		{
			var model = _repository.Get(name, isOrganic, page, order, sort);

			return Json(model, JsonRequestBehavior.AllowGet);
		}

		protected override void OnException(ExceptionContext filterContext)
		{
			filterContext.ExceptionHandled = true;

			//_Logger.Error(filterContext.Exception);

			filterContext.Result = RedirectToAction("Index", "Error");
		}
	}
}