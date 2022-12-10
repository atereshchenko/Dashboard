using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Dashboard.Models
{
	/// <summary>
	///  Класс, описывающий свойства, необходимые для генерации JWT-токена
	/// </summary>
	public class JwtAuthOptions
	{
        /// <summary>
        /// Издатель токена
        /// </summary>
        public const string ISSUER = "DashboardAuthServer";
        /// <summary>
        /// Потребитель токена
        /// </summary>
        public const string AUDIENCE = "DashboardAuthClient";
        /// <summary>
        /// Ключ для шифрации
        /// </summary>
        const string KEY = "dashboardauthserver_secretkey!123";
        /// <summary>
        /// Время жизни токена 
        /// </summary>
        public const int LIFETIME = 15;
        /// <summary>
        /// Представление симметричного ключа безопасности.
        /// </summary>
        /// <returns></returns>
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
