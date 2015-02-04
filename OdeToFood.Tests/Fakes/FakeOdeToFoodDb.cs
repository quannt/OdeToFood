﻿using System;
using System.Collections.Generic;
using System.Linq;
using OdeToFood.Models;

namespace OdeToFood.Tests.Fakes
{
    class FakeOdeToFoodDb : IOdeToFoodDb
    {

        public IQueryable<T> Query<T>() where T : class
        {
            return Sets[typeof(T)] as IQueryable<T>;
        }

        public void Add<T>(T entity) where T : class
        {
            Added.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            Updated.Add(entity);
        }

        public void Remove<T>(T entity) where T : class
        {
            Removed.Add(entity);
        }

        public void SaveChanges()
        {
            Saved = true;
        }

        public void AddSet<T>(IQueryable<T> objects)
        {
            Sets.Add(typeof(T), objects);
        }

        public Dictionary<Type,object> Sets = new Dictionary<Type, object>(); 
        public List<object> Added = new List<object>();
        public List<object> Updated = new List<object>();
        public List<object> Removed = new List<object>();
        public bool Saved = false;


        public void Dispose()
        {
            
        }
    }
}
