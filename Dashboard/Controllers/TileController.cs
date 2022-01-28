using Dashboard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Dashboard.Controllers
{
	public class TileController : Controller
	{
		private readonly ILogger<TileController> logger;
		private ApplicationContext db;

		public TileController(ILogger<TileController> logger, ApplicationContext context)
		{
			this.logger = logger;
			db = context;
		}

		[HttpGet]
		[Authorize(Roles = "admin")]
		public async Task<ActionResult> Index()
		{			
			string email = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
			User user = await db.Users.Include(u => u.Role).FirstOrDefaultAsync(p => p.Email == email);
			ViewBag.UserId = user.Id;
			ViewBag.Title = "Список плиток";
			ViewBag.Breadcrumb = "Tiles";
			var tiles = await db.Tiles.OrderBy(t => t.Number).ToListAsync();

			ViewModel viewModel = new ViewModel
			{				
				User = user,
				Tiles = tiles
			};
			return View(viewModel);
		}

		[HttpGet]
		[Authorize(Roles = "admin")]
		public async Task<ActionResult> Edit(int? id)
		{
			string email = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
			User user = await db.Users.Include(u => u.Role).FirstOrDefaultAsync(p => p.Email == email);
			ViewBag.UserId = user.Id;
			ViewBag.Title = "Редактирование";
			ViewBag.Breadcrumb = "Tile";
			var tile = await db.Tiles.FirstOrDefaultAsync(t => t.Id == id);

			ViewModel viewModel = new ViewModel
			{
				User = user,
				Tile = tile
			};
			return View(viewModel);
		}

		[HttpPost]
		[Authorize(Roles = "admin")]
		public async Task<ActionResult> Edit(ViewModel model)
		{
			ViewBag.Breadcrumb = "Breadcrumb";
			db.Tiles.Update(model.Tile);
			await db.SaveChangesAsync();
			return RedirectToAction("index");
		}

		[HttpGet]
		[Authorize(Roles = "admin")]
		public async Task<ActionResult> Create()
		{
			return View();
		}

		[HttpPost]
		[Authorize(Roles = "admin")]
		public async Task<ActionResult> Create(Tile tile)
		{
			db.Tiles.Add(tile);
			await db.SaveChangesAsync();
			return RedirectToAction("index");
		}
	}
}
