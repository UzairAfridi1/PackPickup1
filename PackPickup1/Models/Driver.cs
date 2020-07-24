using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PackPickup1.Models
{
    public class Driver
    {
        [Key]
        public int DriverId { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Area { get; set; }

        public string Nationality { get; set; }

        public string Language { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }

        public int? PhotoId { get; set; }

        public Country Country { get; set; }

        public int Id { get; set; }

        public State State { get; set; }

        public int StateId { get; set; }

        public City City { get; set; }

        public int CityId { get; set; }



    }
}