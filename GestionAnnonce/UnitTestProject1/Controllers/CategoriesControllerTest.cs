using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using GestionAnnonce.Controllers;
using GestionAnnonce.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1.Controllers
{
    [TestClass]
    public class CategoriesControllerTest
    {
        [TestMethod]
        public void Index()
        {
            using (CategoriesController controller = new CategoriesController())
            {
                ViewResult result = controller.Index() as ViewResult;

                Assert.IsNotNull(result);
            }
        }

        [TestMethod]
        public void IndexData()
        {
            using (CategoriesController controller = new CategoriesController())
            {
                ViewResult result = controller.Index() as ViewResult;
                
                Assert.IsNotNull(result.Model);
                Assert.AreEqual(((List<Categorie>)result.Model).Count, 4);

            }
        }
    }
}
