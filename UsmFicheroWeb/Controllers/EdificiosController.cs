using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UsmFicheroWeb.Models;

namespace UsmFicheroWeb.Controllers
{
    public class EdificiosController : Controller
    {
        private FicheroBDEntities1 db = new FicheroBDEntities1();

        //
        // GET: /Edificios/

        public ActionResult Index()
        {
            string nombreUsuario = ModelosGlobales.GlobalValueNombre + " " + ModelosGlobales.GlobalValueApellidos;
            ViewData["UsuarioActualNombre"] = nombreUsuario;
            return View(db.Edificios.ToList());
        }

        //
        // GET: /Edificios/Details/5

        public ActionResult Details(string id = "Z")
        {
            Edificios edificios = db.Edificios.Find(id);
            if (edificios == null)
            {
                return HttpNotFound();
            }
            return View(edificios);
        }

        //
        // GET: /Edificios/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Edificios/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Edificios edificios)
        {
            var Edi = (from u in db.Edificios where (u.CodEdificios == edificios.CodEdificios) select u.CodEdificios).FirstOrDefault();
            if (Edi == null)
            {
                if (ModelState.IsValid)
                {
                    db.Edificios.Add(edificios);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else { return RedirectToAction("Index"); }

            return View(edificios);
        }

        //
        // GET: /Edificios/Edit/5

        public ActionResult Edit(string id = "A")
        {
            Edificios edificios = db.Edificios.Find(id);
            if (edificios == null)
            {
                return HttpNotFound();
            }
            return View(edificios);
        }

        //
        // POST: /Edificios/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Edificios edificios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(edificios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(edificios);
        }

        //
        // GET: /Edificios/Delete/5

        public ActionResult Delete(string id = "Z")
        {
            Edificios edificios = db.Edificios.Find(id);
            if (edificios == null)
            {
                return HttpNotFound();
            }
            return View(edificios);
        }

        //
        // POST: /Edificios/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Edificios edificios = db.Edificios.Find(id);
            db.Edificios.Remove(edificios);
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