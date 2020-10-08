using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PackPickup1.Models;

namespace PackPickup1.ViewModels
{
    public class VehicleViewModel
    {
        public Driver Driver { get; set; }
        public IEnumerable<Vehicle> vehicles { get; set; }
       
    }
}