using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace User_Registration_Form.Models
{
    public class tblregistration1
    {
        
        public int rid { get; set; }
        public string rname { get; set; }
        public string remail { get; set; }
        public string rpassword { get; set; }
        public int rcountry { get; set; }
        public int rstate { get; set; }
        public int rcity { get; set; }
        public string rgender { get; set; }
        public string rhobbies { get; set; }
        public string rimage { get; set; }

        public List <tblcountry> lstcountry { get; set; }    
        public List <tblstate> lststate { get; set; }    
        public List <tblcity> lstcity { get; set; }    
        public List <tblgender> lstgender { get; set; }    
        public List <tblhobby> lsthobby { get; set; }    
        public List <tblhobby1> lsthobby1 { get; set; }
    }
}