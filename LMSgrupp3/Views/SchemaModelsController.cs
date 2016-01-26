using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LMSgrupp3.DataConnection;
using LMSgrupp3.Models;

namespace LMSgrupp3.Views
{
    public class SchemaModelsController : Controller
    {
        private StudentContext db = new StudentContext();

        // GET: SchemaModels
        public ActionResult Index()
        {
            return View(db.Schemas.ToList());
        }

        // GET: SchemaModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchemaModel schemaModel = db.Schemas.Find(id);
            if (schemaModel == null)
            {
                return HttpNotFound();
            }
            return View(schemaModel);
        }

        // GET: SchemaModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SchemaModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Location,StartDate,EndDate")] SchemaModel schemaModel)
        {
            if (ModelState.IsValid)
            {
                db.Schemas.Add(schemaModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(schemaModel);
        }

        // GET: SchemaModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchemaModel schemaModel = db.Schemas.Find(id);
            if (schemaModel == null)
            {
                return HttpNotFound();
            }
            return View(schemaModel);
        }

        // POST: SchemaModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Location,StartDate,EndDate")] SchemaModel schemaModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schemaModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(schemaModel);
        }

        // GET: SchemaModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchemaModel schemaModel = db.Schemas.Find(id);
            if (schemaModel == null)
            {
                return HttpNotFound();
            }
            return View(schemaModel);
        }

        // POST: SchemaModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SchemaModel schemaModel = db.Schemas.Find(id);
            db.Schemas.Remove(schemaModel);
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
