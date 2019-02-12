using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SusiSu.Models;

namespace SusiSu.Controllers
{
    public class SiparisController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Siparis
        public ActionResult Index()
        {
            return View(db.Sipariss.ToList());
        }

        // GET: Siparis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Siparis siparis = db.Sipariss.Find(id);
            if (siparis == null)
            {
                return HttpNotFound();
            }
            return View(siparis);
        }
        // GET: Siparis/Create
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult SiparisOlustur(SiparisViewModel svm)
        {   
            
            int id = 11;
            var result = (from a in db.Sus
                          where a.Id == id
                          select new
                          {
                              a.StokMiktarı
                          }.StokMiktarı).FirstOrDefault();
            var sures = (from b in db.Sus
                         where b.Id == id
                         select b).FirstOrDefault();
            if (result == 0 && result < svm.Adet)
            {
                return View();
            }
            else
            {
                Siparis s = new Siparis();
                var Uid = User.Identity.GetUserId();
                s.SiparisTarihi = DateTime.Now;            
                var us = (from u in db.User where u.Id == Uid select u).FirstOrDefault();
                s.Users = us;
                db.Sipariss.Add(s);                
                SiparisDetay sd = new SiparisDetay();
                sd.Adet = svm.Adet;
                sd.Fiyat = sures.Fiyat;
                sd.Su = sures;
                var sid = db.Sipariss.OrderByDescending(x => x.SiparisId).FirstOrDefault().SiparisId;
                var sipa = (from c in db.Sipariss where c.SiparisId == sid select c).FirstOrDefault();
                sd.Siparis = sipa;
                db.SiparisDetays.Add(sd);
                db.SaveChanges();
            }          
            return RedirectToAction("Index");
        }


 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SiparisId,SiparisTarihi")] Siparis siparis)
        {
            if (ModelState.IsValid)
            {
                db.Sipariss.Add(siparis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(siparis);
        }

        // GET: Siparis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Siparis siparis = db.Sipariss.Find(id);
            if (siparis == null)
            {
                return HttpNotFound();
            }
            return View(siparis);
        }

        // POST: Siparis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SiparisId,SiparisTarihi")] Siparis siparis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(siparis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(siparis);
        }

        // GET: Siparis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Siparis siparis = db.Sipariss.Find(id);
            if (siparis == null)
            {
                return HttpNotFound();
            }
            return View(siparis);
        }

        // POST: Siparis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Siparis siparis = db.Sipariss.Find(id);
            db.Sipariss.Remove(siparis);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
