using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OdeToFood.Models
{
    public class Restaurant
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string City { get; set; }  
        public virtual string Country { get; set; }
        public virtual ICollection<RestaurantReview> Reviews { get; set; } 

    }
}