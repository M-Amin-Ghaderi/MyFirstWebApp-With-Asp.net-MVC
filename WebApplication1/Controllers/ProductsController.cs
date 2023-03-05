using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using WebApplication1.Models;
using System.Net;
using System.Data.Entity;

namespace WebApplication1.Controllers
{
    public class ProductsController : Controller
    {
        Db_WebApp1Entities2 db = new Db_WebApp1Entities2();
        public ActionResult Index()
        {
            var products = db.Tbl_Products.ToList();
            return View(products);
        }

        public ActionResult PV_Index()
        {
            var products = db.Tbl_Products.ToList();
            return PartialView(products);
        }


        #region Details

        public ActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = db.Tbl_Products.Find(Id);
            if (product == null)
            {
                return HttpNotFound();
            }
            var user = db.Tbl_Users.Find(product.Product_UserId);
            ViewBag.User = user.Tbl_Roles.Role_Title;
            return View(product);
        }


        #endregion


        #region Edit


        [HttpGet]
        public ActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = db.Tbl_Products.Find(Id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Product_Name, Product_Details, Product_Price,Product_UserId,Product_Image")] Tbl_Products product, HttpPostedFileBase Product_Image)
        {
            if (ModelState.IsValid)
            {
                if (Product_Image != null)
                {
                    if (Product_Image.ContentType != "image/jpeg" && Product_Image.ContentType != "image/png")
                    {
                        ModelState.AddModelError("Product_Image", "فرمت عکس باید jpeg jpg یا png باشد");
                        return View(product);
                    }
                    if (Product_Image.ContentLength > 300000)
                    {
                        ModelState.AddModelError("Product_Image", "عکس شما نباید بیش از 300 کیلوبایت باشد");
                        return View(product);
                    }
                    if (product.Product_Image != "default_Product")
                    {
                        if (System.IO.File.Exists(Server.MapPath("/images/Product/") + product.Product_Image))
                        {
                            System.IO.File.Delete(Server.MapPath("/images/Product/") + product.Product_Image);
                        }
                    }
                    string newImage = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(Product_Image.FileName);
                    Product_Image.SaveAs(Server.MapPath("~/images/Product/" + newImage));
                    product.Product_Image = newImage;
                }


                product.Product_UserId = 1;
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        #endregion

        #region Create



        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Product_Name, Product_Details, Product_Price")] Tbl_Products product, HttpPostedFileBase Product_Image)
        {
            if (ModelState.IsValid)
            {
                string newImage = "default_Product.jpg";

                if (Product_Image != null)
                {
                    if (Product_Image.ContentType != "image/jpeg" && Product_Image.ContentType != "image/png")
                    {
                        ModelState.AddModelError("Product_Image", "فرمت عکس باید jpeg jpg یا png باشد");
                        return View();
                    }
                    if (Product_Image.ContentLength > 300000)
                    {
                        ModelState.AddModelError("Product_Image", "عکس شما نباید بیش از 300 کیلوبایت باشد");
                        return View();
                    }

                    newImage = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(Product_Image.FileName);
                    Product_Image.SaveAs(Server.MapPath("~/images/Product/" + newImage));
                }
                product.Product_Image = newImage;
                product.Product_UserId = 1;
                db.Tbl_Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index", "Products");
            }
            return View();
        }

        #endregion


        #region Delete
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = db.Tbl_Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteStudent(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = db.Tbl_Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            if (product != null)
            {
                db.Tbl_Products.Remove(product);
                db.SaveChanges();
                if (product.Product_Image != "default_Product")
                {
                    if (System.IO.File.Exists(Server.MapPath("/images/Product/") + product.Product_Image))
                    {
                        System.IO.File.Delete(Server.MapPath("/images/Product/") + product.Product_Image);
                    }
                }
                return RedirectToAction("Index");
            }
            return View(product);
        }

        #endregion




        #region Dispose


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        #endregion
    }
}