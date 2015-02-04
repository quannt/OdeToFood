using System.Data;
using System.Data.Entity;
using System.Linq;


namespace OdeToFood.Models
{


    public class OdeToFoodDb : DbContext, IOdeToFoodDb
    {


        public OdeToFoodDb() : base("name=DefaultConnection")
        {
            
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantReview> Reviews { get; set; }

        IQueryable<T> IOdeToFoodDb.Query<T>()
        {
            return Set<T>();
        }

        void IOdeToFoodDb.Add<T>(T entity)
        {
            Set<T>().Add(entity);
        }

        void IOdeToFoodDb.Update<T>(T entity)
        {
            Entry(entity).State = EntityState.Modified;
        }

        void IOdeToFoodDb.Remove<T>(T entity)
        {
            Set<T>().Remove(entity);
        }

        void IOdeToFoodDb.SaveChanges()
        {
            SaveChanges();
        }
    }
}