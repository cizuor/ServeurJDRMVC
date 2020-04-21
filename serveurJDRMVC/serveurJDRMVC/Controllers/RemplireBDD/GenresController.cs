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
    public class GenresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private Dal dal = new Dal();

        // GET: Genres
        public ActionResult Index()
        {
            return View(db.Genres.ToList());
        }

        // GET: Genres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre genre = db.Genres.Find(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        // GET: Genres/Create
        public ActionResult Create()
        {
            ViewBag.ListEffet = dal.GetAllEffets();
            List<Stat> stats = dal.GetAllStat();
            List<ValeurGenreStat> valeurStat = new List<ValeurGenreStat>();
            foreach (Stat s in stats)
            {
                valeurStat.Add(new ValeurGenreStat { Stat = s, Valeur = 0 });
            }
            ViewBag.ListStat = valeurStat;
            return View();
        }

        // POST: Genres/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TypeMat,Prix,Poid,Nom,Definition,Stats")] Genre genre,int? Effet1 , int? Effet2 , int? EffetCrit1, int? EffetCrit2)
        {
            if (ModelState.IsValid)
            {
                genre.Effets = new List<EffetActivable>();

                if (Effet1 != null)
                {
                    genre.Effets.Add(new EffetActivable { Effet = dal.GetEffetById((int)Effet1), Activation = EffetActivable.TypeActivation.Toucher });
                }
                if (Effet2 != null)
                {
                    genre.Effets.Add(new EffetActivable { Effet = dal.GetEffetById((int)Effet2), Activation = EffetActivable.TypeActivation.Toucher });
                }
                if (EffetCrit1 != null)
                {
                    genre.Effets.Add(new EffetActivable { Effet = dal.GetEffetById((int)EffetCrit1), Activation = EffetActivable.TypeActivation.Critique });
                }
                if (EffetCrit2 != null)
                {
                    genre.Effets.Add(new EffetActivable { Effet = dal.GetEffetById((int)EffetCrit2), Activation = EffetActivable.TypeActivation.Critique });
                }

                dal.AddGenre(genre);
                return RedirectToAction("Index");
            }

            return View(genre);
        }

        // GET: Genres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre genre = db.Genres.Find(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            //return View(genre);
            return View("Index");
        }

        // POST: Genres/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TypeMat,Prix,Poid,Nom,Definition")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(genre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(genre);
        }

        // GET: Genres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre genre = db.Genres.Find(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        // POST: Genres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Genre genre = db.Genres.Find(id);
            db.Genres.Remove(genre);
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
