using System.ComponentModel.DataAnnotations;

namespace Dashboard.Models
{
	/// <summary>
	/// Авторизационная модель
	/// </summary>
	public class LoginModel
	{
		/// <summary>
		/// Email пользователя
		/// </summary>
		[Required(ErrorMessage = "Не указан Email")]
		public string Email { get; set; }
		/// <summary>
		/// Пароль пользователя
		/// </summary>
		[Required(ErrorMessage = "Не указан пароль")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		/// <summary>
		/// URL переадресации
		/// </summary>
		public string ReturnUrl { get; set; }
	}
}
