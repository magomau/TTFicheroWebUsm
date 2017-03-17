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
    public class HorariosController : Controller
    {
        private FicheroBDEntities1 db = new FicheroBDEntities1();

        //
        // GET: /Horarios/

        public ActionResult Index()
        {
            string nombreUsuario = ModelosGlobales.GlobalValueNombre + " " + ModelosGlobales.GlobalValueApellidos;
            ViewData["UsuarioActualNombre"] = nombreUsuario;
            var horarios = db.Horarios.Include(h => h.Asignaturas).Include(h => h.Hora).Include(h => h.Salas).Include(h => h.Usuarios);
            return View(horarios.ToList());
        }

        //
        // GET: /Horarios/Details/5

        public ActionResult Details(int idd = 0, int idh = 0, int ida = 0, int idm = 0 )
        {
            Horarios horarios = db.Horarios.Find(ida, idm, idh, idd);
            if (horarios == null)
            {
                return HttpNotFound();
            }
            return View(horarios);
        }

        //
        // GET: /Horarios/Create

        public ActionResult Create()
        {
            CrearCalendario c = new CrearCalendario();
            List<List<string>> Calendario = new List<List<string>>();
            Calendario = c.CrearMuestra();
            ViewBag.ListCalendario = Calendario;
            ViewBag.CodAsignatura = new SelectList(db.Asignaturas, "CodAsig", "Nombre");
            ViewBag.CodHora = new SelectList(db.Hora, "CodHora", "CodHora");
            ViewBag.CodSala = new SelectList(db.Salas, "CodSala", "CodSala");
            ViewBag.RutProfesor = new SelectList(db.Usuarios, "Rut", "Rut");
            return View();
        }

        //
        // POST: /Horarios/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Horarios horarios)
        {
            if (ModelState.IsValid)
            {
                db.Horarios.Add(horarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodAsignatura = new SelectList(db.Asignaturas, "CodAsig", "CodAsig", horarios.CodAsignatura);
            ViewBag.CodHora = new SelectList(db.Hora, "CodHora", "CodHora", horarios.CodHora);
            ViewBag.CodSala = new SelectList(db.Salas, "CodSala", "CodSala", horarios.CodSala);
            ViewBag.RutProfesor = new SelectList(db.Usuarios, "Rut", "Rut", horarios.RutProfesor);
            return View(horarios);
        }

        //
        // GET: /Horarios/Edit/5

        public ActionResult Edit(byte ida = 0, byte idm = 0, string idp = "A", byte idd = 0, byte idh = 0)
        {
            Horarios horarios = db.Horarios.Find(ida, idm, idp, idd, idh);
            
            if (horarios == null)
            {
                return HttpNotFound();
            }
            CrearCalendario c = new CrearCalendario();
            List<List<string>> Calendario = new List<List<string>>();
            Calendario = c.CrearMuestra();
            ViewBag.ListCalendario = Calendario;
            ViewBag.CodAsignatura = new SelectList(db.Asignaturas, "CodAsig", "Nombre", horarios.CodAsignatura);
            ViewBag.CodHora = new SelectList(db.Hora, "CodHora", "CodHora", horarios.CodHora);
            ViewBag.CodSala = new SelectList(db.Salas, "CodSala", "CodSala", horarios.CodSala);
            ViewBag.RutProfesor = new SelectList(db.Usuarios, "Rut", "Rut", horarios.RutProfesor);
            return View(horarios);
        }

        //
        // POST: /Horarios/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Horarios horarios, byte? _codAsig, byte? _dia, byte? _codHora, byte? _modificado, string _paralelo)
        {
            if (_codAsig != null && _dia != null && _codHora != null && _modificado != null && _paralelo != null)
            {
                Horarios hrs = db.Horarios.Find(_codAsig, _modificado, _paralelo, _dia, _codHora);
                db.Horarios.Remove(hrs);
                db.SaveChanges();
            }

            if (ModelState.IsValid)
            {
                //db.Entry(horarios).State = EntityState.Modified;
                db.Horarios.Add(horarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodAsignatura = new SelectList(db.Asignaturas, "CodAsig", "CodAsig", horarios.CodAsignatura);
            ViewBag.CodHora = new SelectList(db.Hora, "CodHora", "CodHora", horarios.CodHora);
            ViewBag.CodSala = new SelectList(db.Salas, "CodSala", "CodSala", horarios.CodSala);
            ViewBag.RutProfesor = new SelectList(db.Usuarios, "Rut", "Rut", horarios.RutProfesor);
            return View(horarios);
        }

        //
        // GET: /Horarios/Delete/5

        public ActionResult Delete(byte ida = 0, byte idm = 0, string idp = "A", byte idd = 0, byte idh = 0)
        {
            Horarios horarios = db.Horarios.Find(ida, idm, idp, idd, idh);
            if (horarios == null)
            {
                return HttpNotFound();
            }
            return View(horarios);
        }

        //
        // POST: /Horarios/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte ida = 0, byte idm = 0, string idp = "A", byte idd = 0, byte idh = 0)
        {
            Horarios horarios = db.Horarios.Find(ida, idm, idp, idd, idh);
            db.Horarios.Remove(horarios);
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