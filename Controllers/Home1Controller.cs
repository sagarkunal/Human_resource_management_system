using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using User_Registration_Form.Models;

namespace User_Registration_Form.Controllers
{
    public class Home1Controller : Controller
    {
        DatabaseContext _db = new DatabaseContext();
        public ActionResult AddHome()
        {
            int IDD = Convert.ToInt32(Session["ID"]);
            var data = (from R in _db.tblregistrations
                        join C in _db.tblcountries on R.rcountry equals C.countryid
                        join S in _db.tblstates on R.rstate equals S.stateid
                        join T in _db.tblcities on R.rcity equals T.cityid
                        join G in _db.tblgenders on R.rcountry equals G.genderid
                        where R.rid == IDD
                        select new RegistrationJoin
                        {
                            rid = R.rid,
                            rname = R.rname,
                            remail = R.remail,
                            rpassword = R.rpassword,
                            rcountry = C.countryname,
                            rstate = S.statename,
                            rcity = T.cityname,
                            rgender = G.gendername,
                            rhobbies = R.rhobbies,
                            rimage = R.rimage

                        }).ToList();
            return View(data);
        }
    }
}