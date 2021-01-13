using GestionAnnonce.Data;
using GestionAnnonce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace GestionAnnonce.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly GADbContext _db = new GADbContext();
        // GET: Categories
        public ActionResult Index()
        {
            var categories = _db.Categories.ToList();
            return View(categories);

            //XDocument doc = XDocument.Load("...");
            /*var noms = from el in doc.Root.Elements("Name")
                       where (string)el.Attribute("Type") == "M"
                       select el;*/

            //var nom = doc.Root.Elements("Name").Where(el => (string)el.Attribute("Type") == "M");

        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            var categorie = _db.Categories.Single(x => x.ID == id);
            return View(categorie);
        }

        [HttpGet]
        public ActionResult Ajouter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ajouter(Categorie model)
        {
            if (ModelState.IsValid)
            {
                //enregistrement en base
                _db.Categories.Add(model);
                _db.SaveChanges();
                
                return RedirectToAction("index");
            }
            else
            {
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}