using Dashboard.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> logger;
        private ApplicationContext db;

        public UserController(ILogger<UserController> logger, ApplicationContext context)
        {
            this.logger = logger;
            db = context;
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Index()
        {
            ViewBag.Breadcrumb = "Users";
            var users = await db.Users.Include(u => u.Role).OrderBy(t => t.Id).ToListAsync();
            ViewModel viewModel = new ViewModel
            {
                Users = users
            };
            return View(viewModel);
        }
        
        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Create()
        {
            ViewBag.Roles = db.Roles.ToList().Select(x => new DropDownList { Value = x.Id, Text = x.Name });
            User user = new User();
            user.RoleId = 2;
            user.IsActive = true;

            ViewModel viewModel = new ViewModel
            {
                User = user
            };
            return View(viewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ViewModel model)
        {
            try
            {                
                if (ModelState.IsValid)
                {
                    string md5password = CalculateMD5Hash(model.User.Password);
                    model.User.Password = md5password;

                    await db.Users.AddAsync(model.User);
                    await db.SaveChangesAsync();
                    return RedirectToAction("index");
                }
                ModelState.AddModelError("", "Некорректные данные");
                return View(model);
            }
            catch (Exception ex)
            {
                return View(ex.ToString());
            }
        }
        
        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Edit(int? id)
        {
            ViewBag.Breadcrumb = "User";
            var user = await db.Users.Include(u => u.Role).FirstOrDefaultAsync(p => p.Id == id);
            ViewBag.Roles = db.Roles.ToList().Select(x => new DropDownList { Value = x.Id, Text = x.Name });            

            ViewModel viewModel = new ViewModel
            {
                User = user
            };
            return View(viewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Users.Update(model.User);
                    await db.SaveChangesAsync();
                    return RedirectToAction("index");
                }
                ModelState.AddModelError("", "Некорректные данные");
                return View(model);
            }
            catch
            {
                return View();
            }
        }
                
        public ActionResult Delete(int id)
        {
            return View();
        }
                
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public string CalculateMD5Hash(string password)
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
