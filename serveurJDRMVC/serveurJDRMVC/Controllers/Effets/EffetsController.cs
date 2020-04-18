using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using serveurJDRMVC.Models;
using serveurJDRMVC.Models.Effets;

namespace serveurJDRMVC.Controllers.Effets
{
    public class EffetsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private Dal dal = new Dal();

        // GET: Effets
        public ActionResult Index()
        {
            return View(db.Effets.ToList());
        }

        // GET: Effets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Effet effet = db.Effets.Find(id);
            if (effet == null)
            {
                return HttpNotFound();
            }
            return View(effet);
        }

        // GET: Effets/Create
        public ActionResult Create()
        {
            ViewBag.ListStat = dal.GetAllStat();
            return View();
        }

        // POST: Effets/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom,ChanceEffetBonus,TempsAvantEffetBonus,Penetration,MinHit,MaxHit,DureMin,DureMax,CoefStatUtil,CoefStatReduc,Cible,CumulMax,ChanceResist,ValeurBase,Drain,TailleDee,NbDee")] Effet effet,int StatUtil, int StatReduc , int StatResist , int StatAffecter)
        {
            if (ModelState.IsValid)
            {
                effet.StatAffecter = dal.GetAllStat().FirstOrDefault(s => s.Id == StatAffecter);
                effet.StatUtil = dal.GetAllStat().FirstOrDefault(s => s.Id == StatUtil);
                effet.StatReduc = dal.GetAllStat().FirstOrDefault(s => s.Id == StatReduc);
                effet.StatResist = dal.GetAllStat().FirstOrDefault(s => s.Id == StatResist);

                dal.AddEffet(effet);
                return RedirectToAction("Index");
            }

            return View(effet);
        }

        // GET: Effets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Effet effet = db.Effets.Find(id);
            if (effet == null)
            {
                return HttpNotFound();
            }

            ViewBag.ListStat = dal.GetAllStat();
            return View(effet);
        }

        // POST: Effets/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom,ChanceEffetBonus,TempsAvantEffetBonus,Penetration,MinHit,MaxHit,DureMin,DureMax,CoefStatUtil,CoefStatReduc,Cible,CumulMax,ChanceResist,ValeurBase,Drain,TailleDee,NbDee")] Effet effet,int StatUtil, int StatReduc, int StatResist, int StatAffecter)
        {
            if (ModelState.IsValid)
            {
                effet.StatAffecter = dal.GetAllStat().FirstOrDefault(s => s.Id == StatAffecter);
                effet.StatUtil = dal.GetAllStat().FirstOrDefault(s => s.Id == StatUtil);
                effet.StatReduc = dal.GetAllStat().FirstOrDefault(s => s.Id == StatReduc);
                effet.StatResist = dal.GetAllStat().FirstOrDefault(s => s.Id == StatResist);
                dal.MajEffet(effet);
                return RedirectToAction("Index");
            }
            return View(effet);
        }

        // GET: Effets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Effet effet = db.Effets.Find(id);
            if (effet == null)
            {
                return HttpNotFound();
            }
            return View(effet);
        }

        // POST: Effets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Effet effet = db.Effets.Find(id);
            db.Effets.Remove(effet);
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
