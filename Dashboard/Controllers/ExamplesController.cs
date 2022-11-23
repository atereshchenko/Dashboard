using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dashboard.Controllers
{
	[Authorize(Roles = "admin")]
	public class ExamplesController : Controller
	{
		private readonly ILogger<ExamplesController> logger;
		public ActionResult Index()
		{
			ViewBag.Breadcrumb = "Bootstrap examples";

			return View();
		}		
	}
}
