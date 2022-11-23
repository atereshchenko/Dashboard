using Dashboard.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Controllers.API
{
	[Route("api/[controller]")]
	[ApiController]
	public class TileController : ControllerBase
	{
		private readonly ILogger<TileController> logger;
		private readonly ITileService tileService;

		public TileController(ILogger<TileController> logger, ITileService tileService)
		{
			this.logger = logger;
			this.tileService = tileService;			
		}

		[HttpGet]
		public async Task<IActionResult> Get()
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
