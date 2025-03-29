using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace User_Registration_Form.Models
{
    public class CPModel
    {
        public string CurrentPassword {  get; set; }
        public string NewPassword {  get; set; }
        public string ConfirmNewPassword {  get; set; }
    }
}