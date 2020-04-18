using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using serveurJDRMVC.Models;
using serveurJDRMVC.Models.Personnage;
using serveurJDRMVC.Models.Statistique;

namespace serveurJDRMVC.Controllers.RemplireBDD
{
    public class SousRacesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private Dal dal = new Dal();


        // GET: SousRaces
        public ActionResult Index()
        {
            dal.SaveJson();
            return View(db.SousRaces.ToList());
        }

        // GET: SousRaces/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SousRace sousRace = db.SousRaces.Find(id);
            if (sousRace == null)
            {
                return HttpNotFound();
            }
            return View(sousRace);
        }

        // GET: SousRaces/Create
        public ActionResult Create()
        {
            ViewBag.ListRace = dal.GetAllRace();

            List < Stat > stats = dal.GetAllStat();
            List<ValeurSousRaceStat> valeurStat = new List<ValeurSousRaceStat>();
            foreach (Stat s in stats)
            {
                valeurStat.Add(new ValeurSousRaceStat { Stat = s , Valeur = 0});
            }
            ViewBag.ListStat = valeurStat;
            return View();
        }

        // POST: SousRaces/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom,Definition,Stat")] SousRace sousRace , int RaceCible)
        {
            Race cible = dal.GetAllRace().FirstOrDefault(r => r.Id == RaceCible);
            if (ModelState.IsValid && cible != null)
            {
                sousRace.listRace = new List<Race>();
                sousRace.listRace.Add(cible);
                dal.AddSousRace(sousRace);
                return RedirectToAction("Index");
            }

            return View(sousRace);
        }

        // GET: SousRaces/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.ListRace = dal.GetAllRace();
            SousRace sousRace = db.SousRaces.Find(id);
            if (sousRace == null)
            {
                return HttpNotFound();
            }
            else
            {
                //dal.GetSousRaceStats(sousRace);
            }
            return View(sousRace);
        }

        // POST: SousRaces/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Exclude = "listRace")] SousRace sousRace, int RaceCible)
        {
            
            if (ModelState.IsValid)
            {
                dal.MajSousRace(sousRace);
                //dal.UpdateSousRace(sousRace, cible);
                /*db.Entry(sousRace).State = EntityState.Modified;
                db.SaveChanges();*/
                return RedirectToAction("Index");
            }
            return View(sousRace);
        }

        // GET: SousRaces/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SousRace sousRace = db.SousRaces.Find(id);
            if (sousRace == null)
            {
                return HttpNotFound();
            }
            return View(sousRace);
        }

        // POST: SousRaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SousRace sousRace = db.SousRaces.Find(id);
            dal.DeleteSousRace(sousRace);
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
