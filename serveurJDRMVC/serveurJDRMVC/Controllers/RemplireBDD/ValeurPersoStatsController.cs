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
    public class ValeurPersoStatsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ValeurPersoStats
        public ActionResult Index()
        {
            return View(db.ValeurPersoStats.ToList());
        }

        // GET: ValeurPersoStats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValeurPersoStat valeurPersoStat = db.ValeurPersoStats.Find(id);
            if (valeurPersoStat == null)
            {
                return HttpNotFound();
            }
            return View(valeurPersoStat);
        }

        // GET: ValeurPersoStats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ValeurPersoStats/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Valeur")] ValeurPersoStat valeurPersoStat)
        {
            if (ModelState.IsValid)
            {
                db.ValeurPersoStats.Add(valeurPersoStat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(valeurPersoStat);
        }

        // GET: ValeurPersoStats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValeurPersoStat valeurPersoStat = db.ValeurPersoStats.Find(id);
            if (valeurPersoStat == null)
            {
                return HttpNotFound();
            }
            return View(valeurPersoStat);
        }

        // POST: ValeurPersoStats/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Valeur")] ValeurPersoStat valeurPersoStat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(valeurPersoStat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(valeurPersoStat);
        }

        // GET: ValeurPersoStats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValeurPersoStat valeurPersoStat = db.ValeurPersoStats.Find(id);
            if (valeurPersoStat == null)
            {
                return HttpNotFound();
            }
            return View(valeurPersoStat);
        }

        // POST: ValeurPersoStats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ValeurPersoStat valeurPersoStat = db.ValeurPersoStats.Find(id);
            db.ValeurPersoStats.Remove(valeurPersoStat);
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
