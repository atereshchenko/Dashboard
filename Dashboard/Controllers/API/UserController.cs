using Dashboard.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Controllers.API
{
	/// <summary>
	/// Контроллер для работы с пользователями
	/// </summary>
	[Route("api/[controller]")]
	[Produces("application/json")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly ILogger<UserController> logger;
		private readonly IUserService userService ;

		/// <summary>
		/// Конструктор класса
		/// </summary>
		/// <param name="logger">Oбъект интерфейса логирования</param>
		/// <param name="userService">Oбъект интерфейса для работы с Пользователями</param>
		public UserController(ILogger<UserController> logger, IUserService userService)
		{
			this.logger = logger;
			this.userService = userService;
		}

		/// <summary>
		/// Cписок пользователей
		/// </summary>
		/// <returns>Получение списка пользователей</returns>
		/// <remarks>Какое-либо описание</remarks>
		/// <response code="200">список пользователей в формате Json-строки</response>
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
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
