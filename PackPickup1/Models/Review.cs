using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PackPickup1.Models
{
    public class Review
    {
        public int ReviewId { get; set; }

        public string Comment { get; set; }

        public int RateIt { get; set; }

        public string CommentType { get; set; }

        public DateTime CreateAt { get; set; }

        public Customer Customer { get; set; }

        public int CustomerId { get; set; }

        public Driver Driver { get; set; }

        public int DriverId { get; set; }
    }
}