using OBIS_MVC.Models.Entity_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OBIS_MVC.Controllers
{
    public class NotController : Controller
    {
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        // GET: Not
        public ActionResult Index()
        {
            var notlar = db.TBL_NOT.ToList();
            return View(notlar);
        }

        [HttpGet]
        public ActionResult NotEkle()
        {
            List<SelectListItem> degerler = (from x in db.TBL_DERS.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.DERSAD,
                                                   Value = x.DERSID.ToString()
                                               }).ToList();
            ViewBag.dgr = degerler;
            List<SelectListItem> degerler2 = (from x in db.TBL_OGRENCI.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.OGRAD+" "+x.OGRSOYAD,
                                                 Value = x.OGRENCIID.ToString()
                                             }).ToList();
            ViewBag.dgr2 = degerler2;
            return View();
        }

        [HttpPost]
        public ActionResult NotEkle(TBL_NOT p)
        {

            var drs = db.TBL_DERS.Where(m => m.DERSID == p.TBL_DERS.DERSID).FirstOrDefault();
            var drs2 = db.TBL_OGRENCI.Where(m => m.OGRENCIID == p.TBL_OGRENCI.OGRENCIID).FirstOrDefault();
            p.TBL_DERS = drs;
            p.TBL_OGRENCI = drs2;
            db.TBL_NOT.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult NotHesapla(int SINAV1 = 0, int SINAV2 = 0, int SINAV3 = 0, int PROJE = 0)
        {
            decimal ortalama = (SINAV1 + SINAV2 + SINAV3 + PROJE) / 4;
            ViewBag.ort = ortalama;
            return View();
        }
    }
}