using System.Web.Mvc;

namespace Beer.Controllers
{
	public class ErrorController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}
	}
}