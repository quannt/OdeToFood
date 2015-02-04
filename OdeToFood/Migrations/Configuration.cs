using System.Collections.Generic;
using System.Globalization;
using System.Web.Security;
using OdeToFood.Models;
using WebMatrix.WebData;

namespace OdeToFood.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OdeToFood.Models.OdeToFoodDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OdeToFood.Models.OdeToFoodDb context)
        {
           

            context.Restaurants.AddOrUpdate(r => r.Name,
                new Restaurant { Name = "Little Vietnam", City = "Singapore", Country = "Singapire"},
                new Restaurant { Name = "Long Phung", City = "Singapore", Country = "Singapire"},
                new Restaurant
                {
                    Name = "Don's", City = "Hanoi", Country = "Vietnam",
                    Reviews = new List<RestaurantReview>
                    {
                        new RestaurantReview{Rating = 9, Body = "Great food and ambience!", ReviewerName = "Leo"}
                    }
                }
                );



            SeedMembership();
        }

        private void SeedMembership()
        {
            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
            }
         
            var roles = (SimpleRoleProvider) Roles.Provider;
            var membership = (SimpleMembershipProvider) Membership.Provider;

            if (!roles.RoleExists("Admin"))
            {
                roles.CreateRole("Admin");
            }
            if (membership.GetUser("quannt", false) == null)
            {
                membership.CreateUserAndAccount("quannt", "Test1234");
            }
            if (!roles.GetRolesForUser("quannt").Contains("Admin"))
            {
                roles.AddUsersToRoles(new []{"quannt"}, new []{"admin"});
            }
        }

  

  
    }
}
