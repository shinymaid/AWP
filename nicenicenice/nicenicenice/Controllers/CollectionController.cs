using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using nicenicenice;
using Microsoft.AspNet.Identity;

namespace nicenicenice.Controllers
{
    public class CollectionController : Controller
    {
        private CollectiblesEntities db = new CollectiblesEntities();

        // GET: Collection
        public ActionResult Index()
        {
            var Userid = User.Identity.Name;
            var comp = db.Collected_DB.Where(i => i.UserId == Userid);
           // var collected_DB = db.Collected_DB.Include(c => c.Product);
            return View(comp);
        }

        // GET: Collection/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collected_DB collected_DB = db.Collected_DB.Find(id);
            if (collected_DB == null)
            {
                return HttpNotFound();
            }
            return View(collected_DB);
        }

        // GET: Collection/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "Product_ID", "Product_Name");
            return View();
        }

        public ActionResult Collect(int id)
        {
            CollectiblesEntities db = new CollectiblesEntities();
            Collected_DB cd = new Collected_DB();
            cd.UserId = User.Identity.Name;
            cd.ProductId = id;

            db.Collected_DB.Add(cd);
            try
            {
                db.SaveChanges();
            }catch(Exception ex)
            {
                ViewBag.First = "Knock Knock!";
                ViewBag.Second = "This item is already in your collection!";
                return View("Error");
            }
            

            return RedirectToAction("Index");
        }

        // POST: Collection/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,ProductId")] Collected_DB collected_DB)
        {
            if (ModelState.IsValid)
            {
                db.Collected_DB.Add(collected_DB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "Product_ID", "Product_Name", collected_DB.ProductId);
            return View(collected_DB);
        }

        // GET: Collection/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collected_DB collected_DB = db.Collected_DB.Find(id);
            if (collected_DB == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "Product_ID", "Product_Name", collected_DB.ProductId);
            return View(collected_DB);
        }

        // POST: Collection/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,ProductId")] Collected_DB collected_DB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(collected_DB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Product_ID", "Product_Name", collected_DB.ProductId);
            return View(collected_DB);
        }

        // GET: Collection/Delete/5
        public ActionResult Delete(int? id, string uid)
        {
            if (id == null || uid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collected_DB collected_DB = db.Collected_DB.Find(uid,id);
            if (collected_DB == null)
            {
                return HttpNotFound();
            }
            return View(collected_DB);
        }

        // POST: Collection/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, string uid)
        {
            Collected_DB collected_DB = db.Collected_DB.Find(uid,id);
            db.Collected_DB.Remove(collected_DB);
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
    }
}
