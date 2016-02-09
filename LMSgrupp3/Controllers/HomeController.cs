using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace LMSgrupp3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
               LMSgrupp3.Views.FileTransfer ft = new LMSgrupp3.Views.FileTransfer();
               ft.Upload(file);
            }
            
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult Download(HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                LMSgrupp3.Views.FileTransfer ft = new LMSgrupp3.Views.FileTransfer();
                ft.Download(file);
            }
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            /*
            LMSgrupp3.Views.FileTransfer ft = new LMSgrupp3.Views.FileTransfer();
            ft.Download("minfil.txt");
            */
            return View();
        }
    }
}