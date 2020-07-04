using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PackPickup1.Models;

namespace PackPickup1.ViewModels
{
    public class DriverViewModel
    {

        public Driver Driver { get; set; }

        public IEnumerable<Photo> Photos { get; set; }   

    }
}