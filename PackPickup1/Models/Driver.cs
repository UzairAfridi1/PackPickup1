using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PackPickup1.Models
{
    public class Driver
    {
        public int DriverId { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Area { get; set; }

        public string Nationality { get; set; }

        public string Language { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }

        public int? PhotoId { get; set; }


    }
}