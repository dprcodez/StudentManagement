using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace StudentManagement.Controllers
{
    
    public class LoginController : Controller
    {
        Stu_LindaDBEntities db = new Stu_LindaDBEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(user u)
        {
            if (ModelState.IsValid)
            {
                using (Stu_LindaDBEntities db = new Stu_LindaDBEntities())
                {
                    var data = db.users.Where(model => model.username == u.username && model.password == u.password).FirstOrDefault();
                    if (data != null)
                    {
                        Session["UserId"] = data.id.ToString();
                        Session["UserName"] = data.id.ToString();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "The UserName or Password Incurrect");
                    }
                }
            }
    
            
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}