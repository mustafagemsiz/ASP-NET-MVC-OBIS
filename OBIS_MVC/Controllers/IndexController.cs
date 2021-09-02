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
            var dersler = db.TBL_DERS.Where(x=>x.DERSDURUM==true).ToList();
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
            p.DERSDURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DersSil(int id)
        {
            var deger = db.TBL_DERS.Find(id);
            deger.DERSDURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DersGuncelle(int id)
        {
            var deger = db.TBL_DERS.Find(id);
            return View("DersGuncelle",deger);
        }

        [HttpPost]
        public ActionResult DersGuncelle(TBL_DERS p)
        {
            var deger = db.TBL_DERS.Find(p.DERSID);
            deger.DERSAD = p.DERSAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}