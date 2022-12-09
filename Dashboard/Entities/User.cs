using System.ComponentModel.DataAnnotations.Schema;

namespace Dashboard.Entities
{
	/// <summary>
	/// Пользователи
	/// Отношение (классы vs объекты) - "Ассоциация"
	/// </summary>
	[Table("users")]
	public class User
	{
		/// <summary>
		/// Идентификатор
		/// </summary>
		[Column("id")]
		public int Id { get; set; }
		/// <summary>
		/// Имя
		/// </summary>
		[Column("name")]
		public string Name { get; set; }
		/// <summary>
		/// Емейл
		/// </summary>
		[Column("email")]
		public string Email { get; set; }
		/// <summary>
		/// Пароль
		/// </summary>
		[Column("password")]
		public string Password { get; set; }
		/// <summary>
		/// Идентфикатор роли
		/// </summary>
		[Column("role_id")]
		public int? RoleId { get; set; }
		/// <summary>
		/// Роль пользователя
		/// </summary>
		public Role Role { get; set; }
		/// <summary>
		/// Действуюющая уч. запись?
		/// </summary>
		[Column("is_active")]
		public bool IsActive { get; set; }		

	}
}
