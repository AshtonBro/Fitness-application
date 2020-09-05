﻿using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Fitness.BL.Controller
{
    public class DataBaseDataSaver<T> : IDataSaver<T> where T: class
    {
        public List<T> Load()
        {
            using (var db = new FitnessContext())
            {
                var result = db.Set<T>().Where(f => true).ToList();
                return result;
            }
        }

        public void Save(T item)
        {
            using (var db = new FitnessContext())
            {
                db.Set<T>().Add(item);
                db.SaveChanges();
            }
        }
    }
}
