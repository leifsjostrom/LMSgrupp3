using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LMSgrupp3.Models;
using LMSgrupp3.Repository;

namespace LMSgrupp3.Controllers
{
    public class SchemaModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private StudentRepository repo = new StudentRepository();

        // GET: SchemaModels
        public ActionResult Index()
        {
            return View(db.CourceModels.ToList());
        }

        // GET: SchemaModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchemaModel schemaModel = db.SchemaModels.Find(id);
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
        public ActionResult Create([Bind(Include = "Id,Location,StartDate,EndDate,TeacherId,CourceId")] SchemaModel schemaModel)
        {
            repo.Create(schemaModel);

            //if (ModelState.IsValid)
            //{
            //    db.SchemaModels.Add(schemaModel);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            return View(schemaModel);
        }

        // GET: SchemaModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchemaModel schemaModel = db.SchemaModels.Find(id);
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
        public ActionResult Edit([Bind(Include = "Id,Location,StartDate,EndDate,TeacherId,CourceId")] SchemaModel schemaModel)
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
            SchemaModel schemaModel = db.SchemaModels.Find(id);
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
            SchemaModel schemaModel = db.SchemaModels.Find(id);
            db.SchemaModels.Remove(schemaModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            // Todo  implementering
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            //base.Dispose(disposing);
        }
    }
}
