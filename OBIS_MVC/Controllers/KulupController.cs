using OBIS_MVC.Models.Entity_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OBIS_MVC.Controllers
{
    public class KulupController : Controller
    {
        // GET: Kulup
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var kulupler = db.TBL_KULUP.Where(x=>x.KLPDURUM==true).ToList();
            return View(kulupler);
        }

        [HttpGet]
        public ActionResult KulupEkle()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult KulupEkle(TBL_KULUP p)
        {
            db.TBL_KULUP.Add(p);
            p.KLPDURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KulupSil(int id)
        {
            var deger = db.TBL_KULUP.Find(id);
            deger.KLPDURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult KulupGuncelle(int id)
        {
            var deger = db.TBL_KULUP.Find(id);

            return View("KulupGuncelle",deger);
        }

        [HttpPost]
        public ActionResult KulupGuncelle(TBL_KULUP p)
        {
            var deger = db.TBL_KULUP.Find(p.KULUPID);
            deger.KLPAD = p.KLPAD;
            db.SaveChanges();
            return RedirectToAction("Index","KULUP");
        }
    }
}