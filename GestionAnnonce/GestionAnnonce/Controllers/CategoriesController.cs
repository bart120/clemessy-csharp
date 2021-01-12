using GestionAnnonce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionAnnonce.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult Index()
        {
            return View();
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
                return RedirectToAction("index");
            }
            else
            {
                return View();
            }
        }
    }
}