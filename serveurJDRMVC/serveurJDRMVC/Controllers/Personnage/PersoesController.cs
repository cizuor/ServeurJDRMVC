using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using serveurJDRMVC.Models;
using serveurJDRMVC.Models.Personnage;
using serveurJDRMVC.ViewModel;

namespace serveurJDRMVC.Controllers.Personnage
{
    [Authorize]
    public class PersoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private Dal dal = new Dal();

        // GET: Persoes
        public ActionResult Index()
        {
            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            ApplicationUser appUser = um.FindByName(HttpContext.User.Identity.Name);
            User user = dal.GetUserById(appUser.Id);
            return View(dal.GetPersoFromUser(user.Id));
        }

        // GET: Persoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perso perso = db.Persoes.Find(id);
            if (perso == null)
            {
                return HttpNotFound();
            }
            return View(perso);
        }

        // GET: Persoes/Create
        public ActionResult Create()
        {
            List<Race> races = dal.GetAllRace();
            List<Classe> classes = dal.GetAllClasse();
            ViewBag.races = races;
            ViewBag.classes = classes;
            return View();
        }

        // POST: Persoes/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nom,Prenom,Definition")] PersoViewModel perso,int Race , int Classe)
        {
            if (ModelState.IsValid)
            {
                /*db.Persoes.Add(perso);
                db.SaveChanges();*/
                perso.Race = dal.GetRaceById(Race);
                perso.Classe = dal.GetClasseById(Classe);
                var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                ApplicationUser appUser = um.FindByName(HttpContext.User.Identity.Name);
                User user = dal.GetUserById(appUser.Id);
                dal.AddPersoCreatToUser(user.Id, perso);
                return RedirectToAction("CreateSousRace");
            }

            return View(perso);
        }


        public ActionResult CreateSousRace()
        {

            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            ApplicationUser appUser = um.FindByName(HttpContext.User.Identity.Name);
            User user = dal.GetUserById(appUser.Id);
            ViewBag.sousRaces = user.PersoEnCreation.Race.ListSousRace ;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSousRace( int sousRace)
        {
            if (ModelState.IsValid)
            {
                var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                ApplicationUser appUser = um.FindByName(HttpContext.User.Identity.Name);
                User user = dal.GetUserById(appUser.Id);
                user.PersoEnCreation.SousRace = dal.GetSousRaceById(sousRace);
                Perso perso = Perso.CreationPerso(user.PersoEnCreation);
                dal.AddPersoToUser(user.Id, perso);
                return RedirectToAction("Index");
            }

            return View(CreateSousRace());
        }

        // GET: Persoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perso perso = db.Persoes.Find(id);
            if (perso == null)
            {
                return HttpNotFound();
            }
            return View(perso);
        }

        // POST: Persoes/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom,Prenom,Definition,Vivant,Lvl,posX,posY")] Perso perso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(perso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(perso);
        }

        // GET: Persoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perso perso = db.Persoes.Find(id);
            if (perso == null)
            {
                return HttpNotFound();
            }
            return View(perso);
        }

        // POST: Persoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Perso perso = db.Persoes.Find(id);
            db.Persoes.Remove(perso);
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
