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
using serveurJDRMVC.Models.Objet;
using serveurJDRMVC.Models.Statistique;

namespace serveurJDRMVC.Controllers.RemplireBDD
{
    public class MaterielsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private Dal dal = new Dal();

        // GET: Materiels
        public ActionResult Index()
        {
            return View(db.Materiels.ToList());
        }

        // GET: Materiels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Materiel materiel = db.Materiels.Find(id);
            if (materiel == null)
            {
                return HttpNotFound();
            }
            return View(materiel);
        }

        // GET: Materiels/Create
        public ActionResult Create()
        {
            ViewBag.ListEffet = dal.GetAllEffets();
            List<Stat> stats = dal.GetAllStat();
            List<ValeurMaterielStat> valeurStat = new List<ValeurMaterielStat>();
            foreach (Stat s in stats)
            {
                valeurStat.Add(new ValeurMaterielStat { Stat = s, Valeur = 0 });
            }
            ViewBag.ListStat = valeurStat;
            return View();
        }

        // POST: Materiels/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TypeMat,Prix,Poid,Nom,Definition,Stats")] Materiel materiel, int? Effet1, int? Effet2, int? EffetCrit1, int? EffetCrit2)
        {
            if (ModelState.IsValid)
            {
                materiel.Effets = new List<EffetActivable>();
                if (Effet1 != null)
                {
                    materiel.Effets.Add(new EffetActivable { Effet = dal.GetEffetById((int)Effet1) , Activation = EffetActivable.TypeActivation.Toucher });
                }
                if (Effet2 != null)
                {
                    materiel.Effets.Add(new EffetActivable { Effet = dal.GetEffetById((int)Effet2), Activation = EffetActivable.TypeActivation.Toucher });
                }
                if (EffetCrit1 != null)
                {
                    materiel.Effets.Add(new EffetActivable { Effet = dal.GetEffetById((int)EffetCrit1), Activation = EffetActivable.TypeActivation.Critique });
                }
                if (EffetCrit2 != null)
                {
                    materiel.Effets.Add(new EffetActivable { Effet = dal.GetEffetById((int)EffetCrit2), Activation = EffetActivable.TypeActivation.Critique });
                }

                dal.AddMateriel(materiel);
                return RedirectToAction("Index");
            }

            return View(materiel);
        }

        // GET: Materiels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Materiel materiel = db.Materiels.Find(id);
            if (materiel == null)
            {
                return HttpNotFound();
            }
            //return View(materiel);
            return View("Index");
        }

        // POST: Materiels/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TypeMat,Prix,Poid,Nom,Definition")] Materiel materiel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(materiel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(materiel);
        }

        // GET: Materiels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Materiel materiel = db.Materiels.Find(id);
            if (materiel == null)
            {
                return HttpNotFound();
            }
            return View(materiel);
        }

        // POST: Materiels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Materiel materiel = db.Materiels.Find(id);
            db.Materiels.Remove(materiel);
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
