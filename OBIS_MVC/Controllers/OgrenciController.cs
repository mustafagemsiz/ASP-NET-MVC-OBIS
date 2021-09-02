using OBIS_MVC.Models.Entity_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OBIS_MVC.Controllers
{
    public class OgrenciController : Controller
    {
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        // GET: Ogrenci
        public ActionResult Index()
        {
            var ogrenciler = db.TBL_OGRENCI.Where(x=>x.OGRDURUM==true).ToList();
            return View(ogrenciler);
        }

        [HttpGet]
        public ActionResult OgrenciEkle()
        {
            List<SelectListItem> degerler = (from x in db.TBL_KULUP.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.KLPAD,
                                                 Value = x.KULUPID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult OgrenciEkle(TBL_OGRENCI p)
        {
            var klp = db.TBL_KULUP.Where(m => m.KULUPID == p.TBL_KULUP.KULUPID).FirstOrDefault();
            p.TBL_KULUP = klp;
            p.OGRDURUM = true;
            db.TBL_OGRENCI.Add(p);           
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult OgrenciSil(int id)
        {
            var deger = db.TBL_OGRENCI.Find(id);
            deger.OGRDURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult OgrenciGuncelle(int id)
        {
            var deger = db.TBL_OGRENCI.Find(id);
            return View("OgrenciGuncelle",deger);
        }

        [HttpPost]
        public ActionResult OgrenciGuncelle(TBL_OGRENCI p)
        {
            var deger = db.TBL_OGRENCI.Find(p.OGRENCIID);
            deger.OGRAD = p.OGRAD;
            deger.OGRSOYAD = p.OGRSOYAD;
            deger.OGRFOTOGRAF = p.OGRFOTOGRAF;
            deger.OGRCINSIYET = p.OGRCINSIYET;
            deger.OGRKULUP = p.OGRKULUP;
            db.SaveChanges();
            return RedirectToAction("Index", "Ogrenci");
        }
    }
}