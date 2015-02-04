using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OdeToFood.Models
{
    public class RestaurantListViewModel
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string City { get; set; }
        public virtual string Country { get; set; }
        public virtual int CountOfReviews { get; set; } 
    }
}