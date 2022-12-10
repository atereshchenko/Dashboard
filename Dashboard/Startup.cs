using Dashboard.Models;
using Dashboard.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

using System;
using System.IO;
using System.Reflection;

namespace Dashboard
{
	public class Startup
	{
		/// <summary>
		/// ������ ����������� � ��
		/// </summary>
		public static string Connecton = "Host=localhost;Port=5432;Database=dashboard;Username=postgres;Password=A1aaaaaa";
		/// <summary>
		/// O����� ���������� IConfiguration
		/// </summary>
		public IConfiguration Configuration { get; }
		/// <summary>
		/// ����������� ������
		/// </summary>
		/// <param name="configuration">O����� ���������� IConfiguration</param>
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}		

		/// <summary>
		/// ������������ �����, ������� ������������ ��� ��������� �������� ��� ����������
		/// </summary>
		/// <param name="services"></param>
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllersWithViews();

			var dbContext = new ApplicationContext();
			
			// �������� ���� �����������
			services.AddTransient<ITileService, TileService>(provider => new TileService(dbContext));
			services.AddTransient<IUserService, UserService>(provider => new UserService(dbContext));
			services.AddTransient<IBorderColorService, BorderColorService>(provider => new BorderColorService(dbContext));
			services.AddTransient<ITextColorService, TextColorService>(provider => new TextColorService(dbContext));
			services.AddTransient<IRoleService, RoleService>(provider => new RoleService(dbContext));
			services.AddTransient<ICategoryService, CategoryService>(provider => new CategoryService(dbContext));

			// ����������� �� ������ Cookie
			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(options =>
				{
					options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/account/login");
					options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/account/login");
				});

			services.AddSwaggerGen(options => 
			{
				options.SwaggerDoc("v1", new OpenApiInfo
				{
					Version = "v1",
					Title = "Dashboard API",
					Description = "WEB-API ASP.NET Core ���������� ��� ���������� ���������� ������",
					//TermsOfService = new Uri("https://example.com/terms"),
					Contact = new OpenApiContact
					{
						Name = "Tereshchenko Alexey",						
						Email = "atereshhenko@gmail.com",
						Url = new Uri("https://github.com/atereshchenko?tab=repositories")
					},
					License = new OpenApiLicense
					{
						Name = "License",
						Url = new Uri("https://example.com/license")
					}
				});

				//using System.Reflection;
				var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
			});

		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/home/error");
				app.UseHsts();
			}

			app.UseSwagger();
			app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dashboard API"));		

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			// �������������� - �������������� ������������, ������, ��� ��
			app.UseAuthentication();

			// ����������� - ����� ����� � ������� ����� ������������, ��������� ������������ ������ � �������� ����������.
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=home}/{action=index}/{id?}");
			});
		}
	}
}
