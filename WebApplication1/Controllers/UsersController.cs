using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Net;

namespace WebApplication1.Controllers
{
    public class UsersController : Controller
    {
        Db_WebApp1Entities2 db = new Db_WebApp1Entities2();
        // GET: Users
        public ActionResult Index()
        {
            var usersList = db.Tbl_Users.ToList();
            return View(usersList);
        }

        #region Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind(Include = "Name,Family,Phone,password,Email")] Tbl_Users user)
        {
            if (ModelState.IsValid)
            {
                user.Register_date = DateTime.Now;
                user.IsActive = true;
                user.UserRole_Id = 3;
                db.Tbl_Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }


        #endregion

        #region Details

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = db.Tbl_Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        #endregion

        #region Edit

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = db.Tbl_Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Name,Family,Phone,password,Email,Register_date,gender,IsActive,UserRole_Id")] Tbl_Users user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
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
            var user = db.Tbl_Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteUser(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = db.Tbl_Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            db.Tbl_Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion
    }
}