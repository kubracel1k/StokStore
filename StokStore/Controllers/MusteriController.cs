using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StokStore.Models.Entity;
using StokStore.Controllers;

namespace StokStore.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        StokMvcDbEntities db = new StokMvcDbEntities();
        public ActionResult Index(string p)
        {
            //var degerler = db.tbl_musteriler.ToList();
            // return View(degerler);
            var degerler = from d in db.tbl_musteriler select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.MUSTERIAD.Contains(p));
            }
            return View(degerler.ToList());
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(tbl_musteriler p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.tbl_musteriler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var musteri = db.tbl_musteriler.Find(id);
            db.tbl_musteriler.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index"); 

        }
        public ActionResult MusteriGetir(int id)
        {
            var mus = db.tbl_musteriler.Find(id);
            return View("MusteriGetir",mus);
        }
        public ActionResult Güncelle(tbl_musteriler p1)
        {
            var mus = db.tbl_musteriler.Find(p1.MUSTERIID);
            mus.MUSTERIAD = p1.MUSTERIAD;
            mus.MUSTERISOYAD = p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}