using Crudinterface.Infrastructure.DataProvider;
using Crudinterface.Models.Entity;
using Crudinterface.Models.Viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using IServiceProvider = Crudinterface.Infrastructure.DataProvider.IServiceProvider;

namespace Crudinterface.Controllers
{   [Authorize]
    public class HomeController : Controller
    {
        private IServiceProvider _serviceProvider;
        // GET: ServiceProvider

        // User Register List
        public ActionResult providerslist() 
        {
            _serviceProvider = new ServiceProvider();
            User_Reg_Viewmodel Model = new User_Reg_Viewmodel();
            Model = _serviceProvider.GetServiceProvider();
            return View(Model);
        }

        // User Register 
        public ActionResult UserRegCreate()
        {
            return View();
        }
        [HttpPost]
      
        public ActionResult UserRegCreate(User_Reg_Viewmodel model) // User Register 
        {
            _serviceProvider = new ServiceProvider();
            string str = _serviceProvider.SaveServiceProvider(model);
            return RedirectToAction("Login","Login", model);
        }

        // User Register Edit
        public ActionResult UserRegEdit(int id)
        {
            
            _serviceProvider = new ServiceProvider();
            User_Reg Model = new User_Reg();
            Model = _serviceProvider.GetUpdateId(id);
            return View(Model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UserRegEdit(User_Reg model)
        {
            _serviceProvider = new ServiceProvider();
            string str = _serviceProvider.EditServiceProvider(model);
            return RedirectToAction("providerslist", model);
        }


        // User Register Delete        
        public ActionResult DeleteServiceProvider(int id)  // User Register Delete
        {
            _serviceProvider = new ServiceProvider();
            string str = _serviceProvider.DeletServiceProvider(id);
            return RedirectToAction("providerslist");
        }

        //Website Logout Page
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login", "Login");
        }


    }
}