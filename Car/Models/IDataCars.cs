using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Car.Models
{
    public class IDataCars : IMockCars
    {
        private CarModels db = new CarModels();

        public IQueryable<car> cars { get { return db.cars; } }

        public void Delete(car car)
        {
            db.cars.Remove(car);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();            
        }

        public car Save(car car)
        {
          if (car.id == 0)
            {
                db.cars.Add(car);
            }
          else
            {
                db.Entry(car).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return car;
        }
    }
}