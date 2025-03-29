using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace User_Registration_Form.Models
{
    public class tblregistration
    {
        [Key]
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
    }
}