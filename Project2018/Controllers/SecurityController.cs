using Project2018.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Project2018.Controllers
{    
    public class SecurityController : Controller
    {
        PersonelDbEntities3 db = new PersonelDbEntities3();
        // GET: Security
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }        
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(User1 user)
        {
            var userInDb = db.User1.FirstOrDefault(x => x.Name == user.Name && x.Password == user.Password);
            if (userInDb != null)
            {
                FormsAuthentication.SetAuthCookie(userInDb.Name, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Invalid User Name or Password";
                return View();
            }                                         
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}