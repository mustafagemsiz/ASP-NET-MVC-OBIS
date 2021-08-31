using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OBIS_MVC.Models.Entity_Framework;

namespace OBIS_MVC.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index            
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var dersler = db.TBL_DERS.ToList();
            return View(dersler);
        }

        [HttpGet]
        public ActionResult DersEkle()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DersEkle(TBL_DERS p)
        {
            db.TBL_DERS.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}