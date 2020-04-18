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
    public class DeeStatsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DeeStats
        public ActionResult Index()
        {
            return View(db.DeeStats.ToList());
        }

        // GET: DeeStats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeeStat deeStat = db.DeeStats.Find(id);
            if (deeStat == null)
            {
                return HttpNotFound();
            }
            return View(deeStat);
        }

        // GET: DeeStats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeeStats/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NbDee,TailleDee")] DeeStat deeStat)
        {
            if (ModelState.IsValid)
            {
                db.DeeStats.Add(deeStat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deeStat);
        }

        // GET: DeeStats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeeStat deeStat = db.DeeStats.Find(id);
            if (deeStat == null)
            {
                return HttpNotFound();
            }
            return View(deeStat);
        }

        // POST: DeeStats/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NbDee,TailleDee")] DeeStat deeStat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deeStat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deeStat);
        }

        // GET: DeeStats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeeStat deeStat = db.DeeStats.Find(id);
            if (deeStat == null)
            {
                return HttpNotFound();
            }
            return View(deeStat);
        }

        // POST: DeeStats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeeStat deeStat = db.DeeStats.Find(id);
            db.DeeStats.Remove(deeStat);
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
