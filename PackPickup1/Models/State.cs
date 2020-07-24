using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PackPickup1.Models
{
    public class State
    {
        [Key]
        public int StateId { get; set; }

        public string Name { get; set; }

        public Country Country { get; set; }

        public int Id { get; set; }

    }
}