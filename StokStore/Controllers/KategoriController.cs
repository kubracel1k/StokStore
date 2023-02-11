using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StokStore.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace StokStore.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        StokMvcDbEntities db = new StokMvcDbEntities();
        public ActionResult Index(int sayfa=1)
        {
            //  var degerler = db.tbl_kategori.ToList();
            var degerler = db.tbl_kategori.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategori(tbl_kategori p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.tbl_kategori.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var kategori = db.tbl_kategori.Find(id);
            db.tbl_kategori.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.tbl_kategori.Find(id);
            return View("KategoriGetir",ktgr);
        }
        public ActionResult Güncelle(tbl_kategori p1)
        {
            var ktgr = db.tbl_kategori.Find(p1.KATEGORİID);
            ktgr.KATEGORİAD = p1.KATEGORİAD;
            db.SaveChanges();
            return RedirectToAction("Index");
                 
        }
    }
}