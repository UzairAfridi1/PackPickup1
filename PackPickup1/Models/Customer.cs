using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PackPickup1.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Area { get; set; }

        public string Nationality { get; set; }

        public bool IsDeleted { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }

    }
}