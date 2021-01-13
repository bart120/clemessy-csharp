using GestionAnnonce.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionAnnonce.Controllers
{
    public class SharedController : Controller
    {
        private readonly GADbContext _db = new GADbContext();

        // GET: Shared
        [ChildActionOnly]
        public ActionResult Menu()
        {
            return View("_MenuPartial", _db.Categories.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}