using Dashboard.Entities;
using Dashboard.Models;
using Dashboard.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Dashboard.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ILogger<CategoryController> logger;
		private readonly ICategoryService categoryService;
		private readonly IUserService userService;

		public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService, IUserService userService)
		{
			this.logger = logger;
			this.categoryService = categoryService;
			this.userService = userService;
		}

		[HttpGet]
		[Authorize(Roles = "admin")]
		public ActionResult Index()
		{
			string email = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
			User user = userService.GetByEmail(email);

			ViewBag.UserId = user.Id;
			ViewBag.Title = "Список категорий";
			ViewBag.Breadcrumb = "Сategories";

			var categories = categoryService.GetList();

			ViewModel viewModel = new ViewModel
			{
				User = user,
				Categories = categories
			};
			return View(viewModel);
		}

		// GET: CategoryController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}
		
		public ActionResult Create()
		{
			string email = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
			User user = userService.GetByEmail(email);
			ViewBag.UserId = user.Id;
			ViewBag.Title = "Create tile category";
			ViewBag.Breadcrumb = "Create Tile category";

			//ViewBag.Categories = categoryService.GetList().Select(x => new DropDownList { Value = x.Id, Text = x.Name });	

			ViewModel viewModel = new ViewModel
			{
				User = user,				
			};
			return View(viewModel);
		}

		// POST: CategoryController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection, Category category)
		{
			categoryService.Create(category);
			return RedirectToAction("index", "category");
			//try
			//{				
			//	return RedirectToAction(nameof(Index));
			//}
			//catch
			//{
			//	return View();
			//}
		}
				
		public ActionResult Edit(int id)
		{
			string email = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
			User user = userService.GetByEmail(email);
			ViewBag.UserId = user.Id;
			ViewBag.Title = "Редактирование Категории";
			ViewBag.Breadcrumb = "Category";

			var category = categoryService.GetById(id);

			ViewModel viewModel = new ViewModel
			{
				User = user,
				Category = category
			};
			return View(viewModel);
		}
		
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(ViewModel model)
		{
			ViewBag.Breadcrumb = "Breadcrumb";
			categoryService.Update(model.Category);

			return RedirectToAction("index", "category");			
		}

		// GET: CategoryController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: CategoryController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
