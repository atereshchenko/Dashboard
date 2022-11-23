using Dashboard.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Dashboard.Services
{
	/// <summary>
	/// Интерфейс для работы с ролями пользователей
	/// </summary>
	public interface IRoleService
	{
		/// <summary>
		/// Получить список ролей
		/// </summary>
		/// <returns></returns>
		public List<Role> GetList();
	}
	public class RoleService : IRoleService
	{
		private readonly ApplicationContext context;

		public RoleService(ApplicationContext context)
		{
			this.context = context;
		}

		public List<Role> GetList()
		{
			return context.Roles.OrderBy(o => o.Name).ToList();
		}
	}
}
