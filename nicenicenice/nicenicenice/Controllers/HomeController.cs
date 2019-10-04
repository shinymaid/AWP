using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using nicenicenice;
using PagedList;
using PagedList.Mvc;

namespace nicenicenice.Controllers
{
    public class HomeController : Controller
    {
        private CollectiblesEntities db = new CollectiblesEntities();
        public ActionResult Index(string sname, int? page)
        {
            if (sname != null)
            {
                return View(db.Products.Where(p => p.Product_Name.Contains(sname)).ToList().ToPagedList(page ?? 1, 5));
                
            }
            
            return View(db.Products.ToList());

        }
        public ActionResult Detail(int? id)
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
        public ActionResult Category(string id)
        {
            if (id != null)
            {
                return View(db.Products.Where(p => p.Product_Category.Contains(id)).ToList());

            }

            return View(db.Products.ToList());
        }
        [HttpGet]
        public ActionResult Randompost()
        {
            return View(db.Products.OrderBy(x => Guid.NewGuid()).Take(1).ToList());
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}