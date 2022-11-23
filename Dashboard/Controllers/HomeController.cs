using Dashboard.Models;
using Dashboard.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System.Diagnostics;

namespace Dashboard.Controllers
{
	[Authorize(Roles = "admin, user")]
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> logger;		
		private readonly ITileService tileService;

		public HomeController(ILogger<HomeController> logger, ITileService tileService)
		{
			this.logger = logger;
			this.tileService = tileService;			
		}

		[AllowAnonymous]
		public IActionResult Index()
		{
			var tiles = tileService.GetList(true);
			return View(tiles);			
		}
		
		
		[Authorize(Roles = "admin")]
		public IActionResult Privacy()
		{			
			return View();			
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
		
		//[AllowAnonymous]
		//[HttpPost]
		//public object Link(int id = 0)
		//{
		//	try
		//	{
		//		if (id > 0)
		//		{
		//			TilesNavigationHistory tileNavHistory = new TilesNavigationHistory();
		//			tileNavHistory.TileId = id;
		//			tileNavHistory.CreatedOn = DateTime.Now;

		//			var tmp = db.TilesNavigationHistory.Add(tileNavHistory);
		//			var tmp2 = db.SaveChanges();

		//			var response = new
		//			{
		//				message = "Successfully",
		//			};
		//			return Ok(response);
		//		}
		//		else
		//		{
		//			var response = new
		//			{
		//				message = "Query parameter not defined",
		//			};
		//			return BadRequest(response);
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		var response = new
		//		{
		//			message = ex.Message,
		//		};
		//		return BadRequest(response);
		//	}
		//}
	}
}
