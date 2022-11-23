using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dashboard.Controllers
{
	[Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> logger;       

        public AdminController(ILogger<AdminController> logger)
        {
            this.logger = logger;            
        }

        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {            
            return View();
        }

        [Authorize(Roles = "admin")]
        public ActionResult Details(int id)
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]        
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]        
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]       
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
    }
}
