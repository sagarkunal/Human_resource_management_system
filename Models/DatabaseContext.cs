using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace User_Registration_Form.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()  :base("abc")
        { 
        
        }

        public  DbSet<tblregistration> tblregistrations { get; set; }
        public  DbSet<tblcountry> tblcountries{ get; set; }
        public  DbSet<tblstate> tblstates { get; set; }
        public  DbSet<tblcity> tblcities { get; set; }
        public  DbSet<tblgender> tblgenders { get; set; }
        public  DbSet<tblhobby> tblhobbies { get; set; }
     
    }
}