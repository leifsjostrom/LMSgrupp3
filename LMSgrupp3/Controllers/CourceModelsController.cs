using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LMSgrupp3.Models;

namespace LMSgrupp3.Controllers
{
    public class CourceModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CourceModels
        public ActionResult Index()
        {
            return View(db.CourceModels.ToList());
        }

        // GET: CourceModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourceModel courceModel = db.CourceModels.Find(id);
            if (courceModel == null)
            {
                return HttpNotFound();
            }
            return View(courceModel);
        }

        // GET: CourceModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourceModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] CourceModel courceModel)
        {
            if (ModelState.IsValid)
            {
                db.CourceModels.Add(courceModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courceModel);
        }

        // GET: CourceModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourceModel courceModel = db.CourceModels.Find(id);
            if (courceModel == null)
            {
                return HttpNotFound();
            }
            return View(courceModel);
        }

        // POST: CourceModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] CourceModel courceModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courceModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courceModel);
        }

        // GET: CourceModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourceModel courceModel = db.CourceModels.Find(id);
            if (courceModel == null)
            {
                return HttpNotFound();
            }
            return View(courceModel);
        }

        // POST: CourceModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourceModel courceModel = db.CourceModels.Find(id);
            db.CourceModels.Remove(courceModel);
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
