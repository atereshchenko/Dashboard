using System.Collections.Generic;

namespace Dashboard.Models
{
	public class User
	{
		/// <summary>
		/// Идентификатор
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// Имя
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// Емейл
		/// </summary>
		public string Email { get; set; }
		/// <summary>
		/// Пароль
		/// </summary>
		public string Password { get; set; }
		/// <summary>
		/// Идентфикатор роли
		/// </summary>
		public int? RoleId { get; set; }
		/// <summary>
		/// Роль пользователя
		/// </summary>
		public Role Role { get; set; }
		/// <summary>
		/// Действуюющая уч. запись?
		/// </summary>
		public bool IsActive { get; set; }		

	}
}
