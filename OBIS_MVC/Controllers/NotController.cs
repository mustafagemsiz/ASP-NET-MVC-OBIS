using OBIS_MVC.Models.Entity_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OBIS_MVC.Models;
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


        [HttpGet]
        public ActionResult NotGuncelle(int id)
        {
            var deger = db.TBL_NOT.Find(id);
            return View("NotGuncelle", deger);
        }

        [HttpPost]
        public ActionResult NotEkle(TBL_NOT p ,int SINAV1 = 0, int SINAV2 = 0, int SINAV3 = 0, int PROJE = 0)
        {
            decimal ortalama = (SINAV1 + SINAV2 + SINAV3 + PROJE) / 4;
            ViewBag.ort = ortalama;
            var drs = db.TBL_DERS.Where(m => m.DERSID == p.TBL_DERS.DERSID).FirstOrDefault();
            var drs2 = db.TBL_OGRENCI.Where(m => m.OGRENCIID == p.TBL_OGRENCI.OGRENCIID).FirstOrDefault();
            p.TBL_DERS = drs;
            p.TBL_OGRENCI = drs2;
            db.TBL_NOT.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult NotGuncelle(TBL_NOT p, int SINAV1, int SINAV2, int SINAV3, int PROJE, Islem model)
        {
            if (model.islem == "Hesapla")
            {
                double ortalama = (SINAV1 + SINAV2 + SINAV3 + PROJE) / 4;
                ViewBag.ort = ortalama;
            }
            if (model.islem == "NotGuncelle")
            {
                var deger = db.TBL_NOT.Find(p.NOTID);
                deger.SINAV1 = p.SINAV1;
                deger.SINAV2 = p.SINAV2;
                deger.SINAV3 = p.SINAV3;
                deger.PROJE = p.PROJE;
                deger.ORTALAMA = p.ORTALAMA;
                if (deger.ORTALAMA>49)
                {
                    deger.DURUM = true;
                }
                else
                {
                    deger.DURUM = false;
                }
                db.SaveChanges();
                return RedirectToAction("Index", "Not");
            }
            return View();
        }



    }
}