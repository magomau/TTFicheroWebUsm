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
    public class CarrerasController : Controller
    {
        private FicheroBDEntities1 db = new FicheroBDEntities1();

        //
        // GET: /Carreras/

        public ActionResult Index()
        {
            string nombreUsuario = ModelosGlobales.GlobalValueNombre + " " + ModelosGlobales.GlobalValueApellidos;
            ViewData["UsuarioActualNombre"] = nombreUsuario;
            var carreras = db.Carreras.Include(c => c.Departamentos);
            return View(carreras.ToList());
        }

        //
        // GET: /Carreras/Details/5

        public ActionResult Details(byte id = 0)
        {
            Carreras carreras = db.Carreras.Find(id);
            if (carreras == null)
            {
                return HttpNotFound();
            }
            return View(carreras);
        }

        //
        // GET: /Carreras/Create

        public ActionResult Create()
        {
            var getDepartamentos = db.Departamentos.ToList();
            SelectList Departamentos = new SelectList(getDepartamentos, "IdDepartamento", "NombreDepartamento");
            ViewBag.ListDepartamentos = Departamentos;
            //ViewBag.IdDepartamento = new SelectList(db.Departamentos, "IdDepartamento", "NombreCarrera");
            return View();
        }

        //
        // POST: /Carreras/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Carreras carreras)
        {
            var Carr = (from u in db.Carreras where (u.IdCarrera == carreras.IdCarrera) select u.IdCarrera).FirstOrDefault();
            if (Carr == null)
            {
                if (ModelState.IsValid)
                {
                    db.Carreras.Add(carreras);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else { return RedirectToAction("Index"); }

            ViewBag.IdDepartamento = new SelectList(db.Departamentos, "IdDepartamento", "IdDepartamento", carreras.IdDepartamento);
            return View(carreras);
        }

        //
        // GET: /Carreras/Edit/5

        public ActionResult Edit(byte id = 0)
        {
            Carreras carreras = db.Carreras.Find(id);
            if (carreras == null)
            {
                return HttpNotFound();
            }
            //ViewBag.IdDepartamento = new SelectList(db.Departamentos, "IdDepartamento", "IdDepartamento", carreras.IdDepartamento);
            var getDepartamentos = db.Departamentos.ToList();
            SelectList Departamentos = new SelectList(getDepartamentos, "IdDepartamento", "NombreDepartamento");
            ViewBag.ListDepartamentos = Departamentos;
            return View(carreras);
        }

        //
        // POST: /Carreras/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Carreras carreras)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carreras).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdDepartamento = new SelectList(db.Departamentos, "IdDepartamento", "IdDepartamento", carreras.IdDepartamento);
            return View(carreras);
        }

        //
        // GET: /Carreras/Delete/5

        public ActionResult Delete(byte id = 0)
        {
            Carreras carreras = db.Carreras.Find(id);
            if (carreras == null)
            {
                return HttpNotFound();
            }
            return View(carreras);
        }

        //
        // POST: /Carreras/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            Carreras carreras = db.Carreras.Find(id);
            db.Carreras.Remove(carreras);
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