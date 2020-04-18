using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using serveurJDRMVC.Models;
using serveurJDRMVC.Models.Statistique;

namespace serveurJDRMVC.Controllers.RemplireBDD
{
    public class ValeurRaceStatsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ValeurRaceStats
        public ActionResult Index()
        {
            return View(db.ValeurRaceStats.ToList());
        }

        // GET: ValeurRaceStats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValeurRaceStat valeurRaceStat = db.ValeurRaceStats.Find(id);
            if (valeurRaceStat == null)
            {
                return HttpNotFound();
            }
            return View(valeurRaceStat);
        }

        // GET: ValeurRaceStats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ValeurRaceStats/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Valeur")] ValeurRaceStat valeurRaceStat)
        {
            if (ModelState.IsValid)
            {
                db.ValeurRaceStats.Add(valeurRaceStat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(valeurRaceStat);
        }

        // GET: ValeurRaceStats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValeurRaceStat valeurRaceStat = db.ValeurRaceStats.Find(id);
            if (valeurRaceStat == null)
            {
                return HttpNotFound();
            }
            return View(valeurRaceStat);
        }

        // POST: ValeurRaceStats/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Valeur")] ValeurRaceStat valeurRaceStat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(valeurRaceStat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(valeurRaceStat);
        }

        // GET: ValeurRaceStats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValeurRaceStat valeurRaceStat = db.ValeurRaceStats.Find(id);
            if (valeurRaceStat == null)
            {
                return HttpNotFound();
            }
            return View(valeurRaceStat);
        }

        // POST: ValeurRaceStats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ValeurRaceStat valeurRaceStat = db.ValeurRaceStats.Find(id);
            db.ValeurRaceStats.Remove(valeurRaceStat);
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
