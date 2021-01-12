using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionAnnonce.Controllers
{
    public class AnnoncesController : Controller
    {
        // GET: Annonces
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ajouter()
        {
            return View();
        }
    }
}