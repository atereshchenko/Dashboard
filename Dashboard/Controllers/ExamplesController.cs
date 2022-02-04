using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Controllers
{
	public class ExamplesController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}		
	}
}
