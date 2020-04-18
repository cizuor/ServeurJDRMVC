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
    public class StatUtilsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private Dal dal = new Dal();


        // GET: StatUtils
        public ActionResult Index()
        {
            return View(dal.GetAllStatUtil());
        }

        // GET: StatUtils/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatUtil statUtil = dal.GetAllStatUtil().FirstOrDefault(s => s.Id == id);
            if (statUtil == null)
            {
                return HttpNotFound();
            }
            return View(statUtil);
        }

        // GET: StatUtils/Create
        public ActionResult Create()
        {
            ViewBag.ListStat = dal.GetAllStat();
            return View();
        }

        // POST: StatUtils/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Valeur")] StatUtil statUtil , int StatUtile , int StatCible)
        {
            Stat util = dal.GetAllStat().FirstOrDefault(u => u.Id == StatUtile);
            Stat cible = dal.GetAllStat().FirstOrDefault(u => u.Id == StatCible);
           
            //statUtil.StatUtile = util;
            //cible.ListStatUtils.Add(statUtil);

            if (ModelState.IsValid && util != null && cible != null)
            {
                dal.AddStatUtil(statUtil, util, cible);
               /* db.Entry(cible).State = EntityState.Modified;
                if (cible.StatCalculer == null)
                {
                    cible.StatCalculer = new StatCalculer { ListStatUtils = new List<StatUtil>() };
                    db.SaveChanges();
                }

                cible.StatCalculer.ListStatUtils.Add(statUtil);

                db.SaveChanges();*/
                return RedirectToAction("Index");
            }

            return View(statUtil);
        }

        // GET: StatUtils/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatUtil statUtil = dal.GetAllStatUtil().FirstOrDefault(s => s.Id == id);
            if (statUtil == null)
            {
                return HttpNotFound();
            }
            return View(statUtil);
        }

        // POST: StatUtils/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Valeur")] StatUtil statUtil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statUtil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(statUtil);
        }

        // GET: StatUtils/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatUtil statUtil = dal.GetAllStatUtil().FirstOrDefault(s => s.Id == id); 
            if (statUtil == null)
            {
                return HttpNotFound();
            }
            return View(statUtil);
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
