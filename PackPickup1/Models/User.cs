﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PackPickup1.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string MobileNo { get; set; }

        public string PhoneCode { get; set; }

        public string Password { get; set; }

        public string RoleType { get; set; }


    }
}