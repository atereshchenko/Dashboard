using Dashboard.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Controllers.API
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly ILogger<UserController> logger;
		private readonly IUserService userService ;

		public UserController(ILogger<UserController> logger, IUserService userService)
		{
			this.logger = logger;
			this.userService = userService;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var users = userService.GetList();

			var result = users.Select(user => new
			{
				user.Id,
				user.Name,
				user.Email,
				user.IsActive,
				role = (user.Role != null) ? new { user.Role.Id, user.Role.Name } : null
			});

			return Ok(result);
		}
	}
}
