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
    public class ValeurSousRaceStatsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ValeurSousRaceStats
        public ActionResult Index()
        {
            return View(new List<ValeurSousRaceStat>());
        }

        // GET: ValeurSousRaceStats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValeurSousRaceStat valeurSousRaceStat = new ValeurSousRaceStat();
            if (valeurSousRaceStat == null)
            {
                return HttpNotFound();
            }
            return View(valeurSousRaceStat);
        }

        // GET: ValeurSousRaceStats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ValeurSousRaceStats/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Valeur")] ValeurSousRaceStat valeurSousRaceStat)
        {
            if (ModelState.IsValid)
            {
                //db.ValeurSousRaceStats.Add(valeurSousRaceStat);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(valeurSousRaceStat);
        }

        // GET: ValeurSousRaceStats/Edit/5
        public ActionResult Edit(int? id)
        {
            /*if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValeurSousRaceStat valeurSousRaceStat = db.ValeurSousRaceStats.Find(id);
            if (valeurSousRaceStat == null)
            {
                return HttpNotFound();
            }*/
            return View();
        }

        // POST: ValeurSousRaceStats/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Valeur")] ValeurSousRaceStat valeurSousRaceStat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(valeurSousRaceStat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(valeurSousRaceStat);
        }

        // GET: ValeurSousRaceStats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           /* ValeurSousRaceStat valeurSousRaceStat = db.ValeurSousRaceStats.Find(id);
            if (valeurSousRaceStat == null)
            {
                return HttpNotFound();
            }*/
            return View();
        }

        // POST: ValeurSousRaceStats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           /* ValeurSousRaceStat valeurSousRaceStat = db.ValeurSousRaceStats.Find(id);
            db.ValeurSousRaceStats.Remove(valeurSousRaceStat);
            db.SaveChanges();*/
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
