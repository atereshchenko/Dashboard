using Dashboard.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Dashboard
{
	public class ApplicationContext : DbContext
    {
        /// <summary>
        /// Плитки
        /// </summary>
        public DbSet<Tile> Tiles { get; set; }
        /// <summary>
        /// Полльзователи
        /// </summary>
        public DbSet<User> Users { get; set; }
        /// <summary>
        /// Роли
        /// </summary>
        public DbSet<Role> Roles { get; set; }  
        
        public DbSet<CssColor> CssColors { get; set; }
        
        public ApplicationContext()
        {            
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Startup.Connecton);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            string adminEmail = "admin@dashboard.com";
            string adminPassword = "92AB2C1C8F150F5EDFBA5DB5F640FB47";           

            List<Role> roles = new List<Role>
            {
                new Role{ Id = 1, Name = "admin" },
                new Role{ Id = 2, Name = "user" },
            };
            modelBuilder.Entity<Role>().HasData(roles);


            User adminUser = new User { Id = 1, Name = "Администратор", Email = adminEmail, Password = adminPassword, RoleId = roles[0].Id, IsActive = true };            
            modelBuilder.Entity<User>().HasData(new User[] { adminUser });            

            List<CssColor> colors = new List<CssColor>
            {
                new CssColor { Id = 1, Value = "primary"},
                new CssColor { Id = 2, Value = "secondary"},
                new CssColor { Id = 3, Value = "success"},
                new CssColor { Id = 4, Value = "danger"},
                new CssColor { Id = 5, Value = "warning"},
                new CssColor { Id = 6, Value = "light"},
                new CssColor { Id = 7, Value = "dark"},
            };
            modelBuilder.Entity<CssColor>().HasData(colors);

            List<Tile> tiles = new List<Tile>
            {
                new Tile { Id = 1, Number = 1, Name = "Swagger documentation", Description = "Swagger documentation", Link = "http://localhost/swagger/index.html", LinkName = "Перейти", TurnOn = true, TextColorId = 1, BorderColorId = 2, Favorite = true },
                new Tile { Id = 2, Number = 2, Name = "Bootstrap Examples", Description = "Bootstrap Examples", Link = "http://localhost/examples", LinkName = "Перейти", TurnOn = false, TextColorId = 1, BorderColorId = 2, Favorite = true},
                new Tile { Id = 3, Number = 3, Name = "Chart.js", Description = "JavaScript charting", Link = "https://www.chartjs.org/", LinkName = "Перейти", TurnOn = true, TextColorId = 1, BorderColorId = 2, Favorite = true},
                new Tile { Id = 4, Number = 4, Name = "Bootstrap icons docs", Description = "Bootstrap icons docs", Link = "https://getbootstrap.com/docs/5.1/extend/icons/", LinkName = "Перейти", TurnOn = true, TextColorId = 1, BorderColorId = 2, Favorite = false},
                new Tile { Id = 5, Number = 5, Name = "Bootstrap Icons", Description = "Bootstrap Icons", Link = "https://icons.getbootstrap.com/", LinkName = "Перейти", TurnOn = true, TextColorId = 1, BorderColorId = 2, Favorite = false},
                new Tile { Id = 6, Number = 6, Name = "Feather icons", Description = "Feather icons", Link = "https://feathericons.com/", LinkName = "Перейти", TurnOn = true, TextColorId = 1, BorderColorId = 2, Favorite = false},
            };
            modelBuilder.Entity<Tile>().HasData(tiles);            

            base.OnModelCreating(modelBuilder);
        }
    }
}
