using Dashboard.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Dashboard.Services
{
	/// <summary>
	/// Интерфейс для работы с пользователями
	/// </summary>
	public interface IUserService
	{
        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="email"><see cref="string"/> email</param>
        /// <param name="password"><see cref="string"/> password</param>
        /// <returns><see cref="User"/> Пользователь</returns>
		public User Login(string email, string password);
        /// <summary>
        /// Получить пользователя по идентификатору
        /// </summary>
        /// <param name="id"><see cref="int"/> идентификатор пользователя</param>
        /// <returns>пользователь <see cref="User"/></returns>
        public User GetById(int id);
        /// <summary>
        /// Получить пользователя по e-mail
        /// </summary>
        /// <param name="email"><see cref="string"/> e-mail пользователя</param>
        /// <returns> пользователь <see cref="User"/></returns>
        public User GetByEmail(string email);
        /// <summary>
        /// Получить список всех пользователей
        /// </summary>
        /// <returns>список всех пользователей</returns>
        public List<User> GetList();
        /// <summary>
        /// Создание пользователя
        /// </summary>
        /// <param name="user">экземпляр класса <see cref="User"/></param>
        /// <returns>идентификатор созданного пользователя</returns>
        int Create(User user);
        /// <summary>
        /// Обновить данные пользователя
        /// </summary>
        /// <param name="user">экземпляр класса <see cref="User"/></param>
        /// <returns>Пользователь с обновленными данными</returns>
        User Update(User user);        
    }
    public class UserService : IUserService
    {
        private readonly ApplicationContext context;

        public UserService(ApplicationContext context)
        {
            this.context = context;
        }

        public User Login(string email, string password)
        {
            string MD5Hash = CalculateMD5Hash(password);
            return context.Users.Include(u => u.Role).FirstOrDefault(u => u.Email == email && u.Password == MD5Hash);
        }

        public User GetByEmail(string email)
        {
            return context.Users.Include(u => u.Role).FirstOrDefault(u => u.Email == email);
        }

        public User GetById(int id)
        {
            return context.Users.Include(u => u.Role).FirstOrDefault(u => u.Id == id);
        }

        public List<User>GetList()
        {
            return context.Users.Include(u => u.Role).OrderBy(t => t.Id).ToList();
        }

        public int Create(User user)
        {
            context.Users.Add(user);
            var result = context.SaveChanges();
            return result;
        }

        public User Update(User user)
        {
            var result = context.Users.FirstOrDefault(u => u.Id == user.Id);

            if (result != null)
            {
                if (result.Name != user.Name)
                {
                    result.Name = user.Name;
                    // Указать, что запись изменилась
                    context.Entry(result).State = EntityState.Modified;
                }

                if (result.IsActive != user.IsActive)
                {
                    result.IsActive = user.IsActive;
                    // Указать, что запись изменилась
                    context.Entry(result).State = EntityState.Modified;
                }

                if (result.RoleId != user.RoleId)
                {
                    result.RoleId = user.RoleId;
                    // Указать, что запись изменилась
                    context.Entry(result).State = EntityState.Modified;
                }

                if (result.Email != user.Email)
                {
                    result.Email = user.Email;
                    // Указать, что запись изменилась
                    context.Entry(result).State = EntityState.Modified;
                }

                // Сохранить изменения
                context.SaveChanges();
            }

            return result;
        }

        private string CalculateMD5Hash(string password)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password);
            byte[] hash = md5.ComputeHash(inputBytes);
            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
