using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PackPickup1.Models
{
    public class Vehicle
    {
        public int VehicleId { get; set; }

        public string Type { get; set; }

        public string Capacity { get; set; }

        public string Size { get; set; }

        public string Weight { get; set; }

        public Photo Photo { get; set; }

        public int PhotoId { get; set; }

        public Driver Driver { get; set; }

        public int DriverId { get; set; }
    }
}