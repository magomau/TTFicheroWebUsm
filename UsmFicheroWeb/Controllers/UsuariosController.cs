using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UsmFicheroWeb.Models;

namespace UsmFicheroWeb.Controllers
{
    public class UsuariosController : Controller
    {
        private FicheroBDEntities1 db = new FicheroBDEntities1();

        //
        // GET: /Usuarios/

        public ActionResult Index()
        {
            string id = ModelosGlobales.GlobalValue.ToString();
            ViewData["rutUsuario"] = id;
            string nombreUsuario = ModelosGlobales.GlobalValueNombre + " " + ModelosGlobales.GlobalValueApellidos;
            ViewData["UsuarioActualNombre"] = nombreUsuario;
            return View(db.Usuarios.ToList());
        }

        //
        // GET: /Usuarios/Details/5

        public ActionResult Details(int id = 0)
        {
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        // GET: /Usuarios/ErrorPopUp
        public ActionResult ErrorPopUp()
        {
            return View();
        }

        //
        // GET: /Usuarios/Create

        public ActionResult Create()
        {
            //List<SelectListItem> carreras = new List<SelectListItem>();
            //carreras = ListaCarreras();
            //ViewBag.Carre = carreras;
            var getcarreras = db.Carreras.ToList();
            SelectList Carreras = new SelectList(getcarreras, "IdCarrera", "NombreCarrera");
            ViewBag.ListCarreras = Carreras;
            return View();
        }

        public List<SelectListItem> ListaCarreras()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            SelectListItem item1 = new SelectListItem() { Text = "Informatica", Value = "92", Selected = true };
            SelectListItem item2 = new SelectListItem() { Text = "Mecanica", Value = "63", Selected = true };
            items.Add(item1);
            items.Add(item2);

            return items;

        }

        //
        // POST: /Usuarios/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuarios usuarios, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                fileName = usuarios.Nombre + usuarios.Apellidos + ".jpg";
                var path = Path.Combine(Server.MapPath("~/Fotos"), fileName);
                file.SaveAs(path);
            }
            string unionRut = usuarios.Rut + "-" + usuarios.Dv;
            ValidarRutChileno vrc = new ValidarRutChileno();

            bool validacionRut = vrc.validarRut(unionRut);

            bool validacionDatos = false;

            int nombre = usuarios.Nombre.Length;
            int apellidos = usuarios.Apellidos.Length;
            int fono = usuarios.Fono.Length;
            int contraseña = usuarios.Contraseña.Length;

            if (nombre < 20 && apellidos < 20 && fono < 13 && contraseña < 20)
            {
                validacionDatos = true;
            }

            var User = (from u in db.Usuarios where (u.Rut == usuarios.Rut) select u.Rut).FirstOrDefault();

            if ((User == null && validacionDatos && validacionRut) || (User == 0 && validacionDatos && validacionRut))
            {
                if (ModelState.IsValid)
                {
                    db.Usuarios.Add(usuarios);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else {
                return RedirectToAction("Index");
            }

            return View(usuarios);
        }

        //
        // GET: /Usuarios/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            var getcarreras = db.Carreras.ToList();
            SelectList Carreras = new SelectList(getcarreras, "IdCarrera", "NombreCarrera");
            ViewBag.ListCarreras = Carreras;
            return View(usuarios);
        }

        //
        // POST: /Usuarios/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuarios usuarios, HttpPostedFileBase file, int Restable)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                fileName = usuarios.Nombre + usuarios.Apellidos + ".jpg";
                var path = Path.Combine(Server.MapPath("~/Fotos"), fileName);
                file.SaveAs(path);
            }
            if (Restable == 2)
            {
                usuarios.Contraseña = usuarios.Rut.ToString();
            }

            
            bool validacionDatos = false;

            int nombre = usuarios.Nombre.Length;
            int apellidos = usuarios.Apellidos.Length;
            int fono = usuarios.Fono.Length;
            int contraseña = usuarios.Contraseña.Length;

            if (nombre < 20 && apellidos < 20 && fono < 13 && contraseña < 20)
            {
                validacionDatos = true;
            }

            if (validacionDatos)
            {

                if (ModelState.IsValid)
                {
                    db.Entry(usuarios).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(usuarios);
        }

        //
        // GET: /Usuarios/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Usuarios usuarios = db.Usuarios.Find(id);
            string UsuarioActual = ModelosGlobales.GlobalValue.ToString();
            ViewData["rutUsuario"] = UsuarioActual;
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        //
        // POST: /Usuarios/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            string UsuarioActual = ModelosGlobales.GlobalValue.ToString();
            Usuarios usuarios = db.Usuarios.Find(id);
            if (id.ToString() != UsuarioActual)
            {
                db.Usuarios.Remove(usuarios);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}