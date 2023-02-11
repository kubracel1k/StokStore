using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StokStore.Models.Entity;
using StokStore.Controllers;
using System.Web.Mvc;

namespace StokStore.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        StokMvcDbEntities db = new StokMvcDbEntities();
        public ActionResult Index()
        {
            return View();

        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(tbl_satıs p3)
        {
            db.tbl_satıs.Add(p3);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Satilan()
        {
            var degerler = db.tbl_satıs.ToList();
            return View(degerler);
        }
        public ActionResult Sil(int id)
        {
            var satis = db.tbl_satıs.Find(id);
            db.tbl_satıs.Remove(satis);
            db.SaveChanges();
            return RedirectToAction("Satilan");
        }
      
    }
}