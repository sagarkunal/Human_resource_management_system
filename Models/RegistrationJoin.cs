using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace User_Registration_Form.Models
{
    public class RegistrationJoin
    {
        public int rid { get; set; }
        public string rname { get; set; }
        public string remail { get  ; set; }
        public string rpassword { get; set; }
        public string rcountry { get; set; }
        public string rstate { get; set; }
        public string rcity { get; set; }
        public string rgender { get; set; }
        public string rhobbies { get; set; }
        public string rimage { get; set; }
    }
}