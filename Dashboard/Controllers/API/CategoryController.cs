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
	/// <summary>
	/// Контроллер для работы с Категориями плиток
	/// </summary>
	[Route("api/[controller]")]
	[Produces("application/json")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly ILogger<CategoryController> logger;
		private readonly ICategoryService categoryService;

		/// <summary>
		/// Конструктор класса
		/// </summary>
		/// <param name="logger">Oбъект интерфейса для работы с логированием</param>
		/// <param name="categoryService">Oбъект интерфейса для работы с категориями</param>
		public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService)
		{
			this.logger = logger;
			this.categoryService = categoryService;
		}

		/// <summary>
		/// Список плиток сгрупированных по категориям
		/// </summary>
		/// <returns>Список плиток сгрупированных по категориям</returns>
		/// <remarks>Какое-либо описание</remarks>
		/// <response code="200">список плиток сгрупированых по категориям в формате Json-строки</response>
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
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
