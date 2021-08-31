using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OBIS_MVC.Controllers
{
    public class HesaplaController : Controller
    {
        // GET: Hesapla
        public ActionResult Index(int sinav1=0, int sinav2 = 0, int sinav3 = 0, int proje = 0)
        {
            decimal ortalama = (sinav1 + sinav2 + sinav3 + proje) / 4;
            ViewBag.ort = ortalama;
            return View();
        }
    }
}