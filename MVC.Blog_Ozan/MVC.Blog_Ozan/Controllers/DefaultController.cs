using MVC.Blog_Ozan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Blog_Ozan.Controllers
{
    public class DefaultController : Controller
    {
        BlogDBContext db = new BlogDBContext();
        
        public ActionResult Index(string category)
        {
            if (!string.IsNullOrEmpty(category))
            {
                return View(db.Categories.Where(x=> x.Name==category).FirstOrDefault().Posts.Take(2).ToList());
            }
            return View(db.Posts.Take(2).ToList());
        }

        public ActionResult About()
        {
            //ViewBag.Categories = db.Categories.ToList();
            return View();
        }

        public ActionResult Contact()
        {
            //ViewBag.Categories = db.Categories.ToList();
            return View();
        }

        public ActionResult Details(int id)
        {
            //ViewBag.Categories = db.Categories.ToList();
            return View(db.Posts.Find(id));
        }

        [ChildActionOnly]
        public ActionResult Navbar()
        {
            ViewBag.Categories = db.Categories.ToList();
            return PartialView();
        }

        public ActionResult GetMore(string category, int toSkip)
        {
            List<string> postList = new List<string>();
            if (string.IsNullOrEmpty(category))
            {
                postList = db.Posts.ToList().Skip(toSkip).Take(2).Select(x => x.Title).ToList();
            }
            else
            {
                postList = db.Posts.Where(x => x.Category.Name == category).ToList().Skip(toSkip).Take(2).Select(x => x.Title).ToList();
            }

            return Json(postList, JsonRequestBehavior.AllowGet);
        }
    }
}