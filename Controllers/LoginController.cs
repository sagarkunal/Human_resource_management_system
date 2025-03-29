using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using User_Registration_Form.Models;

namespace User_Registration_Form.Controllers
{
    public class LoginController : Controller
    {
        DatabaseContext _db = new DatabaseContext();
        public ActionResult AddLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddLogin(tblregistration _reg)
        {
            var data = (from R in _db.tblregistrations where R.remail == _reg.remail && R.rpassword == _reg.rpassword select R).ToList();
            if (data.Count > 0)
            {
                Session["ID"] = data[0].rid;
                return RedirectToAction("AddHome", "Home1");

            }
            else
            {
                ViewBag.msg = "Login Failed .. Try Again !!";
                return View();
            }
        }
    }
}