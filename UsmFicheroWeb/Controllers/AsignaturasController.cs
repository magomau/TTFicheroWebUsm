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
    public class AsignaturasController : Controller
    {
        private FicheroBDEntities1 db = new FicheroBDEntities1();

        //
        // GET: /Asignaturas/

        public ActionResult Index()
        {
            string nombreUsuario = ModelosGlobales.GlobalValueNombre + " " + ModelosGlobales.GlobalValueApellidos;
            ViewData["UsuarioActualNombre"] = nombreUsuario;
            return View(db.Asignaturas.ToList());
        }

        //
        // GET: /Asignaturas/Details/5

        public ActionResult Details(byte id = 0)
        {
            Asignaturas asignaturas = db.Asignaturas.Find(id);
            if (asignaturas == null)
            {
                return HttpNotFound();
            }
            return View(asignaturas);
        }

        //
        // GET: /Asignaturas/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Asignaturas/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Asignaturas asignaturas)
        {
            if (ModelState.IsValid)
            {
                db.Asignaturas.Add(asignaturas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(asignaturas);
        }

        //
        // GET: /Asignaturas/Edit/5

        public ActionResult Edit(byte id = 0)
        {
            Asignaturas asignaturas = db.Asignaturas.Find(id);
            if (asignaturas == null)
            {
                return HttpNotFound();
            }
            return View(asignaturas);
        }

        //
        // POST: /Asignaturas/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Asignaturas asignaturas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asignaturas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(asignaturas);
        }

        //
        // GET: /Asignaturas/Delete/5

        public ActionResult Delete(byte id = 0)
        {
            Asignaturas asignaturas = db.Asignaturas.Find(id);
            if (asignaturas == null)
            {
                return HttpNotFound();
            }
            return View(asignaturas);
        }

        //
        // POST: /Asignaturas/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            Asignaturas asignaturas = db.Asignaturas.Find(id);
            db.Asignaturas.Remove(asignaturas);
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