using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Car.Models;

namespace Car.Controllers
{
    public class carsController : Controller
    {
        //private CarModels db = new CarModels();

        IMockCars db;
        public carsController()
        {
            this.db = new IDataCars();
        }

        public carsController(IMockCars mockdb)
        {
            this.db = mockdb;
        }

        // GET: cars
        public ActionResult Index()
        {
            return View("Index",db.cars.ToList());
        }

        // GET: cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //car car = db.cars.Find(id);
            car car = db.cars.SingleOrDefault(c => c.id == id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View("Details",car);
        }

        // GET: cars/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Type,Make,Model")] car car)
        {
            if (ModelState.IsValid)
            {
                //db.cars.Add(car);
                //db.SaveChanges();
                db.Save(car);
                return RedirectToAction("Index");
            }

            return View(car);
        }

        // GET: cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //car car = db.cars.Find(id);
            car car = db.cars.SingleOrDefault(c => c.id == id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View("Edit",car);
        }

        // POST: cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Type,Make,Model")] car car)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(car).State = EntityState.Modified;
                //db.SaveChanges();
                db.Save(car);
                return RedirectToAction("Index");
            }
            return View("Edit",car);
        }

        // GET: cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //car car = db.cars.Find(id);
            car car = db.cars.SingleOrDefault(c => c.id == id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View("Delete",car);
        }       

        // POST: cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //car car = db.cars.Find(id);
            car car = db.cars.SingleOrDefault(c => c.id == id);
            //db.cars.Remove(car);
            //db.SaveChanges();
            db.Delete(car);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
