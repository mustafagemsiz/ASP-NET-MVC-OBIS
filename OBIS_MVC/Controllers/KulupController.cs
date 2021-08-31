﻿using OBIS_MVC.Models.Entity_Framework;
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
            var kulupler = db.TBL_KULUP.ToList();
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
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}