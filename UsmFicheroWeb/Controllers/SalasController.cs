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
    public class SalasController : Controller
    {
        private FicheroBDEntities1 db = new FicheroBDEntities1();

        //
        // GET: /Salas/

        public ActionResult Index()
        {
            string nombreUsuario = ModelosGlobales.GlobalValueNombre + " " + ModelosGlobales.GlobalValueApellidos;
            ViewData["UsuarioActualNombre"] = nombreUsuario;
            var salas = db.Salas.Include(s => s.Edificios);
            return View(salas.ToList());
        }

        //
        // GET: /Salas/Details/5

        public ActionResult Details(byte id = 0)
        {
            Salas salas = db.Salas.Find(id);
            if (salas == null)
            {
                return HttpNotFound();
            }
            return View(salas);
        }

        //
        // GET: /Salas/Create

        public ActionResult Create()
        {
            ViewBag.CodEdificio = new SelectList(db.Edificios, "CodEdificios", "CodEdificios");
            return View();
        }

        //
        // POST: /Salas/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Salas salas)
        {
            if (ModelState.IsValid)
            {
                db.Salas.Add(salas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodEdificio = new SelectList(db.Edificios, "CodEdificios", "CodEdificios", salas.CodEdificio);
            return View(salas);
        }

        //
        // GET: /Salas/Edit/5

        public ActionResult Edit(byte id = 0)
        {
            Salas salas = db.Salas.Find(id);
            if (salas == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodEdificio = new SelectList(db.Edificios, "CodEdificios", "CodEdificios", salas.CodEdificio);
            return View(salas);
        }

        //
        // POST: /Salas/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Salas salas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodEdificio = new SelectList(db.Edificios, "CodEdificios", "CodEdificios", salas.CodEdificio);
            return View(salas);
        }

        //
        // GET: /Salas/Delete/5

        public ActionResult Delete(byte id = 0)
        {
            Salas salas = db.Salas.Find(id);
            if (salas == null)
            {
                return HttpNotFound();
            }
            return View(salas);
        }

        //
        // POST: /Salas/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            Salas salas = db.Salas.Find(id);
            db.Salas.Remove(salas);
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