using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PackPickup1.Models;

namespace PackPickup1.ViewModels
{
    public class ResetPasswordViewModel
    {
        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }

        public string ConfirmPassword { get; set; }

    }
}