﻿using Dashboard.Entities;
using Dashboard.Models;
using Dashboard.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Dashboard.Controllers
{
	public class TileController : Controller
	{
		private readonly ILogger<TileController> logger;
		private readonly ITileService tileService;
		private readonly IUserService userService;
		private readonly IBorderColorService borderColorService;
		private readonly ITextColorService textColorService;

		public TileController(ILogger<TileController> logger, ITileService tileService, IUserService userService, IBorderColorService borderColorService, ITextColorService textColorService)
		{
			this.logger = logger;
			this.tileService = tileService;
			this.userService = userService;
			this.borderColorService = borderColorService;
			this.textColorService = textColorService;
		}

		[HttpGet]
		[Authorize(Roles = "admin")]
		public async Task<ActionResult> Index()
		{
			string email = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;			
			User user = userService.GetByEmail(email);

			ViewBag.UserId = user.Id;
			ViewBag.Title = "Список плиток";
			ViewBag.Breadcrumb = "Tiles";			

			var tiles = tileService.GetList();

			ViewModel viewModel = new ViewModel
			{
				User = user,
				Tiles = tiles
			};
			return View(viewModel);			
		}

		[HttpGet]
		[Authorize(Roles = "admin")]
		public ActionResult Edit(int? id)
		{
			string email = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
			User user = userService.GetByEmail(email);
			ViewBag.UserId = user.Id;
			ViewBag.Title = "Редактирование плитки";
			ViewBag.Breadcrumb = "Tile";

			var tile = tileService.GetById(id);

			ViewBag.BorderColors = borderColorService.GetList().Select(x => new DropDownList { Value = x.Id, Text = x.Value });
			ViewBag.TextColor = textColorService.GetList().Select(x => new DropDownList { Value = x.Id, Text = x.Value });

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
			tileService.Update(model.Tile);

			return RedirectToAction("index", "tile");			
		}

		[HttpGet]
		[Authorize(Roles = "admin")]
		public async Task<ActionResult> Create()
		{
			string email = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
			User user = userService.GetByEmail(email);
			ViewBag.UserId = user.Id;
			ViewBag.Title = "Создание плитки";
			ViewBag.Breadcrumb = "Tile";

			var lastTile = tileService.GetList().LastOrDefault().Number;
			Tile newTile = new Tile
			{
				Number = lastTile + 1
			};

			ViewBag.BorderColors = borderColorService.GetList().Select(x => new DropDownList { Value = x.Id, Text = x.Value });
			ViewBag.TextColor = textColorService.GetList().Select(x => new DropDownList { Value = x.Id, Text = x.Value });

			ViewModel viewModel = new ViewModel
			{
				User = user,
				Tile = newTile
			};
			return View(viewModel);			
		}

		[HttpPost]
		[Authorize(Roles = "admin")]
		public async Task<ActionResult> Create(Entities.Tile tile)
		{			
			tileService.Create(tile);			
			return RedirectToAction("index", "tile");
		}
	}
}
