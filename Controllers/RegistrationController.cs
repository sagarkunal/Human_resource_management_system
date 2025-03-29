using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using User_Registration_Form.Models;
using System.IO;


namespace User_Registration_Form.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly DatabaseContext _db = new DatabaseContext();
        public ActionResult AddUser(int id =0)
        {
            tblregistration1 _reg1 = new tblregistration1();
            _reg1.lstcountry = _db.tblcountries.ToList();
            _reg1.lstgender = _db.tblgenders.ToList();
            var Hdata = _db.tblhobbies.ToList();
            _reg1.lsthobby1 = Hdata.Select(x => new tblhobby1
            {
                hobbyid = x.hobbyid,
                hobbyname =  x.hobbyname,
                ischecked = false
            }).ToList();


            if(id> 0)
            {
                var data = (from R in _db.tblregistrations where R.rid == id select R).ToList();
                _reg1.rid = data[0].rid;
                _reg1.rname = data[0].rname;
                _reg1.remail = data[0].remail;
                _reg1.rpassword = data[0].rpassword;
                _reg1.rcountry = data[0].rcountry;
                _reg1.rstate = data[0].rstate;
                _reg1.rcity = data[0].rcity;
                _reg1.rgender = data[0].rgender;
                _reg1.rimage = data[0].rimage;
                string[] arr = data[0].rhobbies.Split(',');
                foreach(var a in _reg1.lsthobby1)
                {
                    foreach(var b in arr)
                    {
                        if(a.hobbyname == b)
                        {
                            a.ischecked = true;
                        }
                    }
                }
            }
            _reg1.lststate = (from S in _db.tblstates where S.countryid == _reg1.rcountry select S).ToList();
            _reg1.lstcity = (from T in _db.tblcities where T.stateid == _reg1.rstate select T).ToList();

            return View(_reg1);
        }

        [HttpPost]
        public ActionResult AddUser(tblregistration1 _reg1, HttpPostedFileBase file)
        {

            string pp = "";
            foreach (var a in _reg1.lsthobby1)
            {
                if (a.ischecked == true)
                {
                    pp += a.hobbyname + ",";

                }
            }

            pp = pp.TrimEnd(',');

           

            tblregistration _reg = new tblregistration();
            _reg.rname = _reg1.rname;
            _reg.remail = _reg1.remail;
            _reg.rpassword = _reg1.rpassword;
            _reg.rstate = _reg1.rstate;
            _reg.rcountry = _reg1.rcountry;
            _reg.rcity = _reg1.rcity;
            _reg.rgender = _reg1.rgender;
            _reg.rhobbies = pp;
           

            if (_reg1.rid > 0)
            {
                _reg.rid = _reg1.rid;
                string FN = Path.GetFileName(file.FileName);
                file.SaveAs(Path.Combine(Server.MapPath("~/UserPics/"), FN));
                System.IO.File.Delete(Path.Combine(Server.MapPath(_reg1.rimage)));
                _reg.rimage = "~/UserPics/" + FN;
                _db.Entry(_reg).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }
            else
            {
                string FN = Path.GetFileName(file.FileName);
                file.SaveAs(Path.Combine(Server.MapPath("~/UserPics/"), FN));
                _reg.rimage = "~/UserPics/" + FN;
                _db.tblregistrations.Add(_reg);
                _db.SaveChanges();
            }
              
            return RedirectToAction("ShowUser");
        }


        public ActionResult ShowUser()
        {

            var data = (from R in _db.tblregistrations
                        join C in _db.tblcountries on R.rcountry equals C.countryid
                        join S in _db.tblstates on R.rstate equals S.stateid
                        join T in _db.tblcities on R.rcity equals T.cityid 
                        join G in _db.tblgenders on R.rcountry equals G.genderid
                        select new RegistrationJoin { 
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

        public ActionResult DeleteUser(int id = 0)
        {

            var data = _db.tblregistrations.Find(id);
            System.IO.File.Delete(Path.Combine(Server.MapPath(data.rimage)));
            _db.tblregistrations.Remove(data);
            _db.SaveChanges();
            return RedirectToAction("ShowUser");
        }

        public JsonResult GetState(int A = 0)
        {
            var data = (from S in _db.tblstates where S.countryid==A select S).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);  
        }

        public JsonResult GetCity(int A = 0)
        {
            var data = (from C in _db.tblcities where C.stateid  == A select C).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }

}