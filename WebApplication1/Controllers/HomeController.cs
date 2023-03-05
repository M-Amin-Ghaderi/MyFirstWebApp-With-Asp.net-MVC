using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using System.Reflection;
using System.Web.Helpers;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cart()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult UserProfile(string firstName, string lastName, string nationalCode, string mobile, string email, HttpPostedFileBase profilePic)
        {
            if (profilePic.ContentLength > 10000000)
            {
                return RedirectToAction("SignUp");
            }
            if (profilePic.ContentType != "image/png" && profilePic.ContentType != "image/jpeg")
            {
                return RedirectToAction("SignUp");
            }

            string picture = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(profilePic.FileName);

            profilePic.SaveAs(Server.MapPath("/images/profile/") + picture);


            ViewBag.name = firstName;
            ViewBag.family = lastName;
            ViewBag.code = nationalCode;
            ViewBag.mobile = mobile;
            ViewBag.email = email;
            ViewBag.image = "/images/profile/" + picture;
            return View();

        }
    }
}