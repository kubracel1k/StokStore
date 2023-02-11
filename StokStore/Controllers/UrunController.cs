using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StokStore.Models.Entity;
using StokStore.Controllers;

namespace StokStore.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        StokMvcDbEntities db = new StokMvcDbEntities();
        public ActionResult Index()
        {
            var degerler = db.tbl_urunler.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> degerler = (from i in db.tbl_kategori.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORİAD,
                                                 Value = i.KATEGORİID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(tbl_urunler p1)
        {
            var ktg = db.tbl_kategori.Where(m => m.KATEGORİID == p1.tbl_kategori.KATEGORİID).FirstOrDefault();
            p1.tbl_kategori = ktg;
            db.tbl_urunler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var urun = db.tbl_urunler.Find(id);
            db.tbl_urunler.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var urun = db.tbl_urunler.Find(id);
            List<SelectListItem> degerler = (from i in db.tbl_kategori.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORİAD,
                                                 Value = i.KATEGORİID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("UrunGetir", urun);

        }
        public ActionResult Güncelle(tbl_urunler p)
        {
            var urun = db.tbl_urunler.Find(p.URUNID);
            urun.URUNAD = p.URUNAD;
            urun.MARKA = p.MARKA;
            urun.STOK = p.STOK;
            urun.FIYAT = p.FIYAT;
            //  urun.URUNKATEGERI=p.URUNKATEGERI;
            var ktg = db.tbl_kategori.Where(m => m.KATEGORİID == p.tbl_kategori.KATEGORİID).FirstOrDefault();
            urun.URUNKATEGERI = ktg.KATEGORİID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}