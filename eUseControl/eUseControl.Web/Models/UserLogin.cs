﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eUseControl.Web.Models
{
    public class UserLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
    }
}