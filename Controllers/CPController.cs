using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using User_Registration_Form.Models;

namespace User_Registration_Form.Controllers
{
    public class CPController : Controller
    {
        DatabaseContext _db = new DatabaseContext();
        public ActionResult AddCP()
        {
            return View();
        }
        [HttpPost]

        public ActionResult AddCP(CPModel _cpm)
        {
            if (_cpm.NewPassword == _cpm.ConfirmNewPassword )
            {
                int IDD = Convert.ToInt32(Session["ID"]);
                var data = _db.tblregistrations.Find(IDD);
                if (data.rpassword == _cpm.CurrentPassword)
                {
                    data.rpassword = _cpm.NewPassword;
                    _db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                    ViewBag.msg = "Password changed successfylly !!";
                }
                else
                {
                    ViewBag.msg = "Current Password do not match !!";
                }
               

            }
            else
            {
                ViewBag.msg = "Password not match";
            }

                return View();
        }
    }
}