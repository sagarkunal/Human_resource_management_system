﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace User_Registration_Form.Models
{
    public class tblcity
    {
        [Key]
        public int cityid { get; set; }
        public int stateid { get; set; }
        public string cityname { get; set; }
    }
}