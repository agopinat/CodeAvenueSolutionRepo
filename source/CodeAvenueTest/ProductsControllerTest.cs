using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeAvenueSolution.Controllers;
using CodeAvenueSolution.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodeAvenueSolution;

namespace CodeAvenueTest
{
    [TestClass]
    public class ProductsControllerTest
    {
        private localEntities db = new localEntities();

        [TestMethod]
        public void TestIndexView()
        {
            var controller = new ProductsController();
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull("Index", "Fine");
            
        }

        [TestMethod]
        public void TestCreateView()
        {
            var controller = new ProductsController();
            var result = controller.Create() as ViewResult;
            Assert.IsNotNull("Create", "Fine");
        }

        [TestMethod]
        public void TestEditView()
        {
            var controller = new ProductsController();
            var result = controller.Edit(3) as ViewResult;
            Assert.IsNotNull("Edit", "Fine");
        }

        [TestMethod]
        public void TestDeleteView()
        {
            var controller = new ProductsController();
            var result = controller.Delete(3) as ViewResult;
            Assert.IsNotNull("Delete", "Fine");
        }

        [TestMethod]
        public void TestDetailsViewData()
        {
            var controller = new ProductsController();
            var result = controller.Details(2) as ViewResult;
            var product = (Product)result.ViewData.Model;
            Assert.AreEqual("Rear Bumper", product.Name);
        }
    }
}
