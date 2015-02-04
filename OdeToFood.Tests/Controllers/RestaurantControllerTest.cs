using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdeToFood.Controllers;
using OdeToFood.Models;
using OdeToFood.Tests.Fakes;

namespace OdeToFood.Tests.Controllers
{
    [TestClass]
    public class RestaurantControllerTest
    {
        [TestMethod]
        public void CreateSavesRestaurantWhenValid()
        {
            var db = new FakeOdeToFoodDb();
            var controller = new RestaurantController(db);

            controller.Create(new Restaurant());

            Assert.AreEqual(1,db.Added.Count);
            Assert.AreEqual(true, db.Saved);
        }

        public void CreateDoesNotSaveRestaurantWhenInvalid()
        {
            var db = new FakeOdeToFoodDb();
            var controller = new RestaurantController(db);

            controller.ModelState.AddModelError("", "Invalid");

            controller.Create(new Restaurant());
            Assert.AreEqual(0,db.Added.Count);
        }


    }
}
