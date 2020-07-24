using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PackPickup1.Models;

namespace PackPickup1.ViewModels
{
    public class CustomerViewModel
    {
        public Customer Customer { get; set; }

        public IEnumerable<Country> Countries { get; set; }

        public IEnumerable<State> States { get; set; }

        public IEnumerable<City> Cities { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}