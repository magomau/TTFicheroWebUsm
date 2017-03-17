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
    public class NoticiasController : Controller
    {
        private FicheroBDEntities1 db = new FicheroBDEntities1();

        //
        // GET: /Noticias/

        public ActionResult Index()
        {
            string nombreUsuario = ModelosGlobales.GlobalValueNombre + " " + ModelosGlobales.GlobalValueApellidos;
            ViewData["UsuarioActualNombre"] = nombreUsuario;
            var noticias = db.Noticias.Include(n => n.Usuarios);
            return View(noticias.ToList());
        }

        //
        // GET: /Noticias/Details/5

        public ActionResult Details(byte id = 0)
        {
            Noticias noticias = db.Noticias.Find(id);
            if (noticias == null)
            {
                return HttpNotFound();
            }
            return View(noticias);
        }

        //
        // GET: /Noticias/Create

        public ActionResult Create()
        {
            ViewBag.RutAutor = new SelectList(db.Usuarios, "Rut", "rut");
            ViewBag.CodAsignatura = new SelectList(db.Asignaturas, "CodAsig", "Nombre");
            ViewBag.IdCarrera = new SelectList(db.Carreras, "IdCarrera", "NombreCarrera");
            return View();
        }

        public ActionResult CreateProfe()
        {
            var getAsignatura = db.Asignaturas.ToList();
            SelectList Asignatura = new SelectList(getAsignatura, "CodAsig", "Nombre");
            ViewBag.ListAsignatura = Asignatura;
            var getcarreras = db.Carreras.ToList();
            SelectList Carreras = new SelectList(getcarreras, "IdCarrera", "NombreCarrera");
            ViewBag.ListCarreras = Carreras;
            ViewBag.RutAutor = new SelectList(db.Usuarios.Where(m => m.Rut == (ModelosGlobales.GlobalValue)), "Rut", "rut");
            return View();
        }

        //
        // POST: /Noticias/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Noticias noticias)
        {
            if (ModelState.IsValid)
            {
                db.Noticias.Add(noticias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RutAutor = new SelectList(db.Usuarios, "Rut", "rut", noticias.RutAutor);
            return View(noticias);
        }

        // POST: /Noticias/CreateProfe
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProfe(Noticias noticias)
        {
            if (ModelState.IsValid)
            {
                db.Noticias.Add(noticias);
                db.SaveChanges();
                return RedirectToAction("GeneralProfe", "Login");
            }

            ViewBag.RutAutor = new SelectList(db.Usuarios, "Rut", "rut", noticias.RutAutor);
            return View(noticias);
        }

        //
        // GET: /Noticias/Edit/5

        public ActionResult Edit(byte id = 0)
        {
            Noticias noticias = db.Noticias.Find(id);
            if (noticias == null)
            {
                return HttpNotFound();
            }
            ViewBag.RutAutor = new SelectList(db.Usuarios, "Rut", "rut", noticias.RutAutor);
            ViewBag.CodAsignatura = new SelectList(db.Asignaturas, "CodAsig", "Nombre");
            ViewBag.IdCarrera = new SelectList(db.Carreras, "IdCarrera", "NombreCarrera");
            return View(noticias);
        }

        //
        // POST: /Noticias/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Noticias noticias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(noticias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RutAutor = new SelectList(db.Usuarios, "Rut", "rut", noticias.RutAutor);
            return View(noticias);
        }

        //
        // GET: /Noticias/Delete/5

        public ActionResult Delete(byte id = 0)
        {
            Noticias noticias = db.Noticias.Find(id);
            if (noticias == null)
            {
                return HttpNotFound();
            }
            return View(noticias);
        }

        //
        // POST: /Noticias/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            Noticias noticias = db.Noticias.Find(id);
            db.Noticias.Remove(noticias);
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