﻿using Dashboard.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Controllers.API
{	
	/// <summary>
	/// Контроллер для работы с Плитками
	/// </summary>
	[Route("api/[controller]")]
	[Produces("application/json")]
	[ApiController]
	public class TileController : ControllerBase
	{
		private readonly ILogger<TileController> logger;
		private readonly ITileService tileService;

		/// <summary>
		/// Конструктор класса 
		/// </summary>
		/// <param name="logger">Oбъект интерфейса для работы логированием</param>
		/// <param name="tileService">Oбъект интерфейса для работы с Плитками</param>
		public TileController(ILogger<TileController> logger, ITileService tileService)
		{
			this.logger = logger;
			this.tileService = tileService;
		}

		/// <summary>
		/// Список плиток
		/// </summary>
		/// <returns>Получить список плиток</returns>
		/// <remarks>Какое-либо описание </remarks>
		/// <response code="200">список плиток в формате Json-строки</response>
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public IActionResult Get()
		{
			var tiles = tileService.GetList();

			var result = tiles.Select(tile => new
			{
				tile.Id,
				tile.Name,
				tile.Description,
				tile.Link,
				tile.LinkName,
				tile.TurnOn,				
				textColor = (tile.TextColor != null) ? new { tile.TextColor.Id, tile.TextColor.Value } : null,
				borderColor = (tile.BorderColor != null) ? new { tile.BorderColor.Id, tile.BorderColor.Value } : null,				
			});

			return Ok(result);
		}
	}
}
