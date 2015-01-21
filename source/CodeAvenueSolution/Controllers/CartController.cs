using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodeAvenueSolution;

namespace CodeAvenueSolution.Controllers
{
    public class CartController : Controller
    {
        private localEntities db = new localEntities();
        public static int? inProductID;
        public static string inProductName;
        public static string inProductCar;
        public static bool isEdit = false;

        // GET: Cart
        public ActionResult Index()
        {
            var products = db.Products.Where(p => p.CartID != null);
            return View(products);
        }

        // GET: Cart/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Cart/Create
        public ActionResult Create(int? id)
        {
            inProductID = id;
            ViewBag.CartID = new SelectList(db.Carts, "CartID", "CartName");
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Cart/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,CartID,Name,Price,Car,Description,QuantityInHand,Image")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                updateProductList(product.QuantityInHand,false,false);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CartID = new SelectList(db.Carts, "CartID", "CartName", product.CartID);
            return View(product);
        }

        // GET: Cart/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            inProductName = product.Name;
            inProductCar = product.Car;

            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CartID = new SelectList(db.Carts, "CartID", "CartName", product.CartID);
            return View(product);
        }

        // POST: Cart/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,CartID,Name,Price,Car,Description,QuantityInHand,Image")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                updateProductList(product.QuantityInHand,true,false);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CartID = new SelectList(db.Carts, "CartID", "CartName", product.CartID);
            return View(product);
        }

        // GET: Cart/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            inProductName = product.Name;
            inProductCar = product.Car;

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Cart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            updateProductList(product.QuantityInHand, false, true);
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

        public void updateProductList(decimal? postBackProductQIH, bool isEdit, bool isDelete)
        {

            if (isEdit) //update quantity in Hand in Product List when Product Ordered is Changed in Cart
            {
                var qry1 = from product in db.Products where product.Name == inProductName 
                           && product.Car == inProductCar 
                           && product.CartID == null
                           select product;
                var item = qry1.Single();
                item.QuantityInHand = item.QuantityInHand - postBackProductQIH;
                isEdit = false;
                isDelete = false;
            }
            else if (isDelete) //update quantity in Hand in Product List when Product Ordered is Deleted from Cart
            {
                var qry2 = from product in db.Products
                           where product.Name == inProductName
                               && product.Car == inProductCar
                               && product.CartID == null
                           select product;
                var item = qry2.Single();
                item.QuantityInHand = item.QuantityInHand + postBackProductQIH;
                isEdit = false;
                isDelete = false;
            }
            else //update quantity in Hand in Product List when Product Ordered is Added to Cart
            {
                var qry3 = from product in db.Products where product.ProductID == inProductID select product;
                var item = qry3.Single();
                item.QuantityInHand = item.QuantityInHand - postBackProductQIH;
            }
        }
    }
}
