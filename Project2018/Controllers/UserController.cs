using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project2018.Models.EntityFramework;

namespace Project2018.Controllers
{
    [Authorize(Roles ="A")]
    public class UserController : Controller
    {
        private PersonelDbEntities3 db = new PersonelDbEntities3();

        // GET: User
        public ActionResult Index()
        {
            return View(db.User1.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User1 user1 = db.User1.Find(id);
            if (user1 == null)
            {
                return HttpNotFound();
            }
            return View(user1);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Password,Role")] User1 user1)
        {
            if (ModelState.IsValid)
            {
                db.User1.Add(user1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user1);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User1 user1 = db.User1.Find(id);
            if (user1 == null)
            {
                return HttpNotFound();
            }
            return View(user1);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Password,Role")] User1 user1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user1);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User1 user1 = db.User1.Find(id);
            if (user1 == null)
            {
                return HttpNotFound();
            }
            return View(user1);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User1 user1 = db.User1.Find(id);
            db.User1.Remove(user1);
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
