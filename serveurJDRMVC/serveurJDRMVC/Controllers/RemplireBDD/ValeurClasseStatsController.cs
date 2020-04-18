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
    public class ValeurClasseStatsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ValeurClasseStats
        public ActionResult Index()
        {
            return View(db.ValeurClasseStats.ToList());
        }

        // GET: ValeurClasseStats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValeurClasseStat valeurClasseStat = db.ValeurClasseStats.Find(id);
            if (valeurClasseStat == null)
            {
                return HttpNotFound();
            }
            return View(valeurClasseStat);
        }

        // GET: ValeurClasseStats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ValeurClasseStats/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Valeur")] ValeurClasseStat valeurClasseStat)
        {
            if (ModelState.IsValid)
            {
                db.ValeurClasseStats.Add(valeurClasseStat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(valeurClasseStat);
        }

        // GET: ValeurClasseStats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValeurClasseStat valeurClasseStat = db.ValeurClasseStats.Find(id);
            if (valeurClasseStat == null)
            {
                return HttpNotFound();
            }
            return View(valeurClasseStat);
        }

        // POST: ValeurClasseStats/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Valeur")] ValeurClasseStat valeurClasseStat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(valeurClasseStat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(valeurClasseStat);
        }

        // GET: ValeurClasseStats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValeurClasseStat valeurClasseStat = db.ValeurClasseStats.Find(id);
            if (valeurClasseStat == null)
            {
                return HttpNotFound();
            }
            return View(valeurClasseStat);
        }

        // POST: ValeurClasseStats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ValeurClasseStat valeurClasseStat = db.ValeurClasseStats.Find(id);
            db.ValeurClasseStats.Remove(valeurClasseStat);
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
