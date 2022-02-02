using Dashboard.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Dashboard
{
	public class ApplicationContext : DbContext
    {
        /// <summary>
        /// Полльзователи
        /// </summary>
        public DbSet<User> Users { get; set; }
        /// <summary>
        /// Роли
        /// </summary>
        public DbSet<Role> Roles { get; set; }
        /// <summary>
        /// Плитки
        /// </summary>
        public DbSet<Tile> Tiles { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string userRoleName = "user";
            string adminEmail = "admin@mail.ru";
            string adminPassword = "A1aaaaaa";

            // добавляем роли
            Role adminRole = new Role { Id = 1, Name = adminRoleName };
            Role userRole = new Role { Id = 2, Name = userRoleName };
            User adminUser = new User { Id = 1, Name = "Администратор", Email = adminEmail, Password = adminPassword, RoleId = adminRole.Id, IsActive = true };

            Tile tile1 = new Tile { Id = 1, Number = 1, Name = "Документация по C#", Description = "Программирования C# на платформе .NET", Link = "https://docs.microsoft.com/ru-ru/dotnet/csharp/", LinkName = "Перейти",SvgClass= "#chevron-right", TurnOn = true };
            Tile tile2 = new Tile { Id = 2, Number = 2, Name = "Шаблон AdminLTE 3", Description = "Bootstrap шаблон админ-панели", Link = "https://adminlte.io/themes/v3/", LinkName= "Перейти", SvgClass = "#chevron-right", TurnOn = true };
            Tile tile3 = new Tile { Id = 3, Number = 3, Name = "Help ASP.NET Core", Description = "Help-ер по разработке ASP.NET Core", Link = "https://metanit.com/sharp/aspnet5/", LinkName = "Перейти", SvgClass = "#chevron-right", TurnOn = true };
            Tile tile4 = new Tile { Id = 4, Number = 4, Name = "GitHub", Description = "Репозиторий с моими проектами", Link = "https://github.com/", LinkName = "Перейти", SvgClass = "#chevron-right", TurnOn = true };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser });
            modelBuilder.Entity<Tile>().HasData(new Tile[] { tile1, tile2, tile3, tile4 });

            base.OnModelCreating(modelBuilder);
        }
    }
}
