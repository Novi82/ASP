using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using OnlineShop.Areas.admin.Code;
using OnlineShop.Areas.admin.Models;
using System.Web.Security;
namespace OnlineShop.Areas.admin.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /admin/Login/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            var bRs = Membership.ValidateUser(model.UserName,model.Password);
            if(bRs && ModelState.IsValid)
            {
                //SessionHelper.setSession(new UserSession() { UserName = model.UserName });
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(String.Empty,"Thông tin không đúng");
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");

        }

    }
}
