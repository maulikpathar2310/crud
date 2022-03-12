using Crudinterface.Infrastructure.DataProvider;
using Crudinterface.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using IServiceProvider = Crudinterface.Infrastructure.DataProvider.IServiceProvider;

namespace Crudinterface.Controllers
{
    public class LoginController : Controller
    {
        private IServiceProvider _dataprovider;

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User_Login login)
        {
            _dataprovider = new ServiceProvider();
            bool flag = _dataprovider.ValidUser(login);
            if (flag)
            {
                return RedirectToAction("ProviderPanel", "Login");
            }
            else
            {
                ViewBag.message = "Invalid PassWord";
                return View();
            }
        }

        //Website
        public ActionResult ProviderPanel()
        {
            return View();
        }
    }
}