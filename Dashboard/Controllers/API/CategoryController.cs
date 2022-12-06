using Dashboard.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Controllers.API
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly ILogger<CategoryController> logger;
		private readonly ICategoryService categoryService;

		public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService)
		{
			this.logger = logger;
			this.categoryService = categoryService;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var categories = categoryService.GetList();

			var result = categories.Select(category => new
			{
				category.Id,
				category.Name,
				tiles = (category.Tiles.Count > 0) ? category.Tiles.Select(t => new { t.Id, t.Name }) : null,
			});

			return Ok(result);
		}
	}
}
