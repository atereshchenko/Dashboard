using Dashboard.Entities;
using Dashboard.Models;
using Dashboard.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Security.Claims;

namespace Dashboard.Controllers
{
	public class AccountController : Controller
	{
        private readonly ILogger<AccountController> logger;
        private readonly IUserService userService;
        public AccountController(ILogger<AccountController> logger, IUserService userService)
		{
            this.logger = logger;
            this.userService = userService;
		}

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = userService.Login(model.Email, model.Password);

                if (user == null)
                {
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
                }
                else
                {
                    if (user.IsActive)
                    {
                        GetIdentity(user);
                        if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                        {
                            return Redirect(model.ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("index", "admin");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Доступ к сайту ограничен");
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
		public IActionResult Register()
		{
			return View();
		}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterModel model)
        {
            //if (ModelState.IsValid)
            //{
            //    User user = await context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
            //    if (user == null)
            //    {
            //        // добавляем пользователя в бд
            //        user = new User { Email = model.Email, Password = model.Password };
            //        Role userRole = await context.Roles.FirstOrDefaultAsync(r => r.Name == "user");
            //        if (userRole != null)
            //            user.Role = userRole;
            //        context.Users.Add(user);

            //        await context.SaveChangesAsync();
            //        await Authenticate(user); // аутентификация
            //        return RedirectToAction("index", "home");
            //    }
            //    else
            //        ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            //}

            //return View(model);
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("index", "home");
        }        

        /// <summary>
        /// Получить удостоверение личности
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns>Идентификатор</returns>
        private ClaimsIdentity GetIdentity(User user)
        {            
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name)                    
                };

                // создаем объект ClaimsIdentity
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Dashboard", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }
    }
}
