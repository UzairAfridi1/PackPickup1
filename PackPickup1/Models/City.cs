﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PackPickup1.Models
{
    public class City
    {
        public int CityId { get; set; }

        public string Name { get; set; }

        public State State { get; set; }

        public int StateId { get; set; }

    }
}