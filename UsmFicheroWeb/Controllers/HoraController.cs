using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UsmFicheroWeb.Controllers
{
    public class HoraController : Controller
    {
        private FicheroBDEntities1 db = new FicheroBDEntities1();

        //
        // GET: /Hora/

        public ActionResult Index()
        {
            return View(db.Hora.ToList());
        }

        //
        // GET: /Hora/Details/5

        public ActionResult Details(byte id = 0)
        {
            Hora hora = db.Hora.Find(id);
            if (hora == null)
            {
                return HttpNotFound();
            }
            return View(hora);
        }

        //
        // GET: /Hora/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Hora/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Hora hora)
        {
            if (ModelState.IsValid)
            {
                db.Hora.Add(hora);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hora);
        }

        //
        // GET: /Hora/Edit/5

        public ActionResult Edit(byte id = 0)
        {
            Hora hora = db.Hora.Find(id);
            if (hora == null)
            {
                return HttpNotFound();
            }
            return View(hora);
        }

        //
        // POST: /Hora/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Hora hora)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hora).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hora);
        }

        //
        // GET: /Hora/Delete/5

        public ActionResult Delete(byte id = 0)
        {
            Hora hora = db.Hora.Find(id);
            if (hora == null)
            {
                return HttpNotFound();
            }
            return View(hora);
        }

        //
        // POST: /Hora/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            Hora hora = db.Hora.Find(id);
            db.Hora.Remove(hora);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}