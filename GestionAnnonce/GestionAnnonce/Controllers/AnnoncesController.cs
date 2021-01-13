using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestionAnnonce.Data;
using GestionAnnonce.Models;

namespace GestionAnnonce.Controllers
{
    public class AnnoncesController : Controller
    {
        private GADbContext db = new GADbContext();

        // GET: Annonces
        public ActionResult Index(RechercheViewModel model)
        {
            
            IEnumerable<Annonce> annonces = db.Annonces.ToList();
            if (!string.IsNullOrWhiteSpace(model.Label))
            {
                 annonces = annonces.Where(a => a.Label.Contains(model.Label));
            }

            if(model.DateDebut != null)
            {
                annonces = annonces.Where(a => a.DateCreation > model.DateDebut);
            }

            if (model.DateFin != null)
            {
                annonces = annonces.Where(a => a.DateCreation < model.DateFin);
            }


            //var annonces = db.Annonces.Include(a => a.Categorie);
            ViewBag.Annonces = annonces.ToList();
            return View();
        }

        // GET: Annonces/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Annonce annonce = db.Annonces.Find(id);
            if (annonce == null)
            {
                return HttpNotFound();
            }
            return View(annonce);
        }

        // GET: Annonces/Create
        public ActionResult Create()
        {
            ViewBag.CategorieID = new SelectList(db.Categories, "ID", "Nom");
            return View();
        }

        // POST: Annonces/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Label,Description,DateCreation,Statut,CategorieID")] Annonce annonce)
        {
            if (ModelState.IsValid)
            {
                db.Annonces.Add(annonce);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategorieID = new SelectList(db.Categories, "ID", "Nom", annonce.CategorieID);
            return View(annonce);
        }

        // GET: Annonces/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Annonce annonce = db.Annonces.Find(id);
            if (annonce == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategorieID = new SelectList(db.Categories, "ID", "Nom", annonce.CategorieID);
            return View(annonce);
        }

        // POST: Annonces/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Label,Description,DateCreation,Statut,CategorieID")] Annonce annonce)
        {
            if (ModelState.IsValid)
            {
                db.Entry(annonce).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategorieID = new SelectList(db.Categories, "ID", "Nom", annonce.CategorieID);
            return View(annonce);
        }

        // GET: Annonces/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Annonce annonce = db.Annonces.Find(id);
            if (annonce == null)
            {
                return HttpNotFound();
            }
            return View(annonce);
        }

        // POST: Annonces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Annonce annonce = db.Annonces.Find(id);
            db.Annonces.Remove(annonce);
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
