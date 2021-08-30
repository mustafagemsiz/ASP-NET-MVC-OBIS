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
    }
}