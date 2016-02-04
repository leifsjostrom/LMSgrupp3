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
    public class FileModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private StudentRepository repo = new StudentRepository();

        // GET: FileModels
        public ActionResult Index()
        {
            return View(repo.ShowAllFiles());
        }

        // GET: FileModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileModel fileModel = db.FileModels.Find(id);
            if (fileModel == null)
            {
                return HttpNotFound();
            }
            return View(fileModel);
        }

        // GET: FileModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FileModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Subject,Shared, CourceId")] FileModel fileModel)
        {
            fileModel.Id = 1;
            fileModel.StudentNumber = "1001";
            //fileModel.Students = new List<StudentModel>();
            //fileModel.Cources = new List<CourceModel>();
            fileModel.Date = DateTime.Now;

            repo.Create(fileModel);

            //if (ModelState.IsValid)
            //{
                
            //    db.FileModels.Add(fileModel);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            return View(fileModel);
        }

        // GET: FileModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileModel fileModel = db.FileModels.Find(id);
            if (fileModel == null)
            {
                return HttpNotFound();
            }
            return View(fileModel);
        }

        // POST: FileModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Subject,Shared,Date")] FileModel fileModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fileModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fileModel);
        }

        // GET: FileModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileModel fileModel = db.FileModels.Find(id);
            if (fileModel == null)
            {
                return HttpNotFound();
            }
            return View(fileModel);
        }

        // POST: FileModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FileModel fileModel = db.FileModels.Find(id);
            db.FileModels.Remove(fileModel);
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
