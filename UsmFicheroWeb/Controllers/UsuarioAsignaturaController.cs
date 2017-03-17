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
    public class UsuarioAsignaturaController : Controller
    {
        private FicheroBDEntities1 db = new FicheroBDEntities1();

        //
        // GET: /UsuarioAsignatura/

        public ActionResult Index()
        {
            string nombreUsuario = ModelosGlobales.GlobalValueNombre + " " + ModelosGlobales.GlobalValueApellidos;
            ViewData["UsuarioActualNombre"] = nombreUsuario;
            var usuarioasignatura = db.UsuarioAsignatura.Include(u => u.Asignaturas).Include(u => u.Usuarios);
            return View(usuarioasignatura.ToList());
        }

        //
        // GET: /UsuarioAsignatura/Details/5

        public ActionResult Details(int id = 0)
        {
            UsuarioAsignatura usuarioasignatura = db.UsuarioAsignatura.Find(id);
            if (usuarioasignatura == null)
            {
                return HttpNotFound();
            }
            return View(usuarioasignatura);
        }

        //
        // GET: /UsuarioAsignatura/Create

        public ActionResult Create()
        {
            ViewBag.CodAsignatura = new SelectList(db.Asignaturas, "CodAsig", "Nombre");
            ViewBag.RutUsuario = new SelectList(db.Usuarios, "Rut", "Rut");
            ViewBag.RutProfesor = new SelectList(db.Usuarios, "Rut", "Rut");
            return View();
        }

        //
        // POST: /UsuarioAsignatura/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioAsignatura usuarioasignatura)
        {
            if (ModelState.IsValid)
            {
                db.UsuarioAsignatura.Add(usuarioasignatura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodAsignatura = new SelectList(db.Asignaturas, "CodAsig", "Nombre", usuarioasignatura.CodAsignatura);
            ViewBag.RutUsuario = new SelectList(db.Usuarios, "Rut", "Rut", usuarioasignatura.RutUsuario);
            return View(usuarioasignatura);
        }

        //
        // GET: /UsuarioAsignatura/Edit/5

        public ActionResult Edit(int id = 0, int id2 = 0)
        {
            UsuarioAsignatura usuarioasignatura = db.UsuarioAsignatura.Find(id, id2);
            if (usuarioasignatura == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodAsignatura = new SelectList(db.Asignaturas, "CodAsig", "Nombre", usuarioasignatura.CodAsignatura);
            ViewBag.RutUsuario = new SelectList(db.Usuarios, "Rut", "Nombre", usuarioasignatura.RutUsuario);
            ViewBag.RutProfesor = new SelectList(db.Usuarios, "Rut", "Rut");
            return View(usuarioasignatura);
        }

        //
        // POST: /UsuarioAsignatura/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioAsignatura usuarioasignatura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarioasignatura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodAsignatura = new SelectList(db.Asignaturas, "CodAsig", "Nombre", usuarioasignatura.CodAsignatura);
            ViewBag.RutUsuario = new SelectList(db.Usuarios, "Rut", "Rut", usuarioasignatura.RutUsuario);
            return View(usuarioasignatura);
        }

        //
        // GET: /UsuarioAsignatura/Delete/5

        public ActionResult Delete(int id = 0, int id2 = 0)
        {
            UsuarioAsignatura usuarioasignatura = db.UsuarioAsignatura.Find(id, id2);
            if (usuarioasignatura == null)
            {
                return HttpNotFound();
            }
            return View(usuarioasignatura);
        }

        //
        // POST: /UsuarioAsignatura/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int id2)
        {
            UsuarioAsignatura usuarioasignatura = db.UsuarioAsignatura.Find(id, id2);
            db.UsuarioAsignatura.Remove(usuarioasignatura);
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