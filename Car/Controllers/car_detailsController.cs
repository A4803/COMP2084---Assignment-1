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
    public class car_detailsController : Controller
    {
        private CarModels db = new CarModels();

        // GET: car_details
        public ActionResult Index()
        {
            var car_details = db.car_details.Include(c => c.car);
            return View(car_details.ToList());
        }

        // GET: car_details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            car_details car_details = db.car_details.Find(id);
            if (car_details == null)
            {
                return HttpNotFound();
            }
            return View(car_details);
        }

        // GET: car_details/Create
        public ActionResult Create()
        {
            ViewBag.id = new SelectList(db.cars, "id", "Type");
            return View();
        }

        // POST: car_details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "car_id,id,name,color,seats")] car_details car_details)
        {
            if (ModelState.IsValid)
            {
                db.car_details.Add(car_details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id = new SelectList(db.cars, "id", "Type", car_details.id);
            return View(car_details);
        }

        // GET: car_details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            car_details car_details = db.car_details.Find(id);
            if (car_details == null)
            {
                return HttpNotFound();
            }
            ViewBag.id = new SelectList(db.cars, "id", "Type", car_details.id);
            return View(car_details);
        }

        // POST: car_details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "car_id,id,name,color,seats")] car_details car_details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car_details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id = new SelectList(db.cars, "id", "Type", car_details.id);
            return View(car_details);
        }

        // GET: car_details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            car_details car_details = db.car_details.Find(id);
            if (car_details == null)
            {
                return HttpNotFound();
            }
            return View(car_details);
        }

        // POST: car_details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            car_details car_details = db.car_details.Find(id);
            db.car_details.Remove(car_details);
            db.SaveChanges();
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
