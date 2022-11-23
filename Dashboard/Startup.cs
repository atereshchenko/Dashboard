using Dashboard.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Dashboard
{
	public class Startup
	{
		public static string Connecton = "Host=localhost;Port=5432;Database=dashboard;Username=postgres;Password=A1aaaaaa";

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllersWithViews();

			var dbContext = new ApplicationContext();
			services.AddTransient<ITileService, TileService>(provider => new TileService(dbContext));
			services.AddTransient<IUserService, UserService>(provider => new UserService(dbContext));
			services.AddTransient<IBorderColorService, BorderColorService>(provider => new BorderColorService(dbContext));
			services.AddTransient<ITextColorService, TextColorService>(provider => new TextColorService(dbContext));
			services.AddTransient<IRoleService, RoleService>(provider => new RoleService(dbContext));			

			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(options =>
				{
					options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/account/login");
					options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/account/login");
				});

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Dashboard", Version = "v1" });
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
			app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dashboard v1"));

			//app.UseForwardedHeaders(new ForwardedHeadersOptions
			//{
			//	ForwardedHeaders = ForwardedHeaders.XForwardedFor |	ForwardedHeaders.XForwardedProto
			//});			

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
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
