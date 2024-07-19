using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarInsurance.Models;

namespace CarInsurance.Controllers
{
    public class InsureeController : Controller
    {
        private InsuranceEntities db = new InsuranceEntities();

        // GET: Insuree
        public ActionResult Index()
        {
            return View(db.Tables.ToList());
        }

        // GET: Insuree/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table insuree = db.Tables.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // GET: Insuree/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Insuree/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] Table insuree)
        {
            if (ModelState.IsValid)
            {
                decimal quoteTotal = 50;
                var today = DateTime.Today;
                var age = today.Year - insuree.DateOfBirth.Year;
                if (age <= 18)
                {
                    quoteTotal += 100;
                }
                if (age >= 19 && age <= 25)
                {
                    quoteTotal += +50;
                }
                if (age > 25)
                {
                    quoteTotal += +25;
                }
                if (insuree.CarYear < 2000)
                {
                    quoteTotal += +25;
                }
                if (insuree.CarYear > 2015)
                {
                    quoteTotal += +25;
                }
                if (insuree.CarMake == "Porsche")
                {
                    quoteTotal += +25;
                }
                if (insuree.CarMake == "Porsche" && insuree.CarModel == "911 Carrera")
                {
                    quoteTotal += +25;
                }
                if (insuree.SpeedingTickets > 0)
                {
                    decimal h = insuree.SpeedingTickets * 10;
                    quoteTotal += h;
                }
                if (insuree.DUI == true)
                {
                    quoteTotal *= 1.25m;
                }
                if (insuree.CoverageType == true)
                {
                    quoteTotal *= 1.5m;
                }

                insuree.Quote = quoteTotal;

                db.Tables.Add(insuree);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(insuree);
        }

        // GET: Insuree/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table insuree = db.Tables.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // POST: Insuree/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] Table insuree)
        {
            if (ModelState.IsValid)
            {
                decimal quoteTotal = 50;
                var today = DateTime.Today;
                var age = today.Year - insuree.DateOfBirth.Year;
                if (age <= 18)
                {
                    quoteTotal += 100;
                }
                if (age >= 19 && age <= 25)
                {
                    quoteTotal += +50;
                }
                if (age > 25)
                {
                    quoteTotal += +25;
                }
                if (insuree.CarYear < 2000)
                {
                    quoteTotal += +25;
                }
                if (insuree.CarYear > 2015)
                {
                    quoteTotal += +25;
                }
                if (insuree.CarMake == "Porsche")
                {
                    quoteTotal += +25;
                }
                if (insuree.CarMake == "Porsche" && insuree.CarModel == "911 Carrera")
                {
                    quoteTotal += +25;
                }
                if (insuree.SpeedingTickets > 0)
                {
                    decimal h = insuree.SpeedingTickets * 10;
                    quoteTotal += h;
                }
                if (insuree.DUI == true)
                {
                    quoteTotal *= 1.25m;
                }
                if (insuree.CoverageType == true)
                {
                    quoteTotal *= 1.5m;
                }

                insuree.Quote = quoteTotal;

                db.Entry(insuree).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(insuree);
        }

        // GET: Insuree/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table insuree = db.Tables.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // POST: Insuree/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Table insuree = db.Tables.Find(id);
            db.Tables.Remove(insuree);
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
