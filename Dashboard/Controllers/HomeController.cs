using Dashboard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Dashboard.Controllers
{
	[Authorize(Roles = "admin, user")]
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> logger;
		private ApplicationContext db;

		public HomeController(ILogger<HomeController> logger, ApplicationContext context)
		{
			this.logger = logger;
			db = context;			
		}

		[AllowAnonymous]
		public IActionResult Index()
		{
			//var users = db.Users.ToList();
			//string role = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
			//return Content($"ваша роль: {role}");

			var tiles = db.Tiles.Where(x=>x.TurnOn == true).OrderBy(t => t.Number).ToList();			
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
	}
}
