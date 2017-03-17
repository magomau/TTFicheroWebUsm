using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using UsmFicheroWeb.Models;

namespace UsmFicheroWeb.Controllers
{
    public class ProfesorController : Controller
    {
        private FicheroBDEntities1 db = new FicheroBDEntities1();
        public ActionResult HorarioAtencion()
        {
            string nombreUsuario = ModelosGlobales.GlobalValueNombre + " " + ModelosGlobales.GlobalValueApellidos;
            ViewData["UsuarioActualNombre"] = nombreUsuario;
            string HoraAten = null;
            HoraAten = ModelosGlobales.GlobalHorarioAtencion;
            if (HoraAten == null)
                { HoraAten = "No tiene Horario de Atención Asignado"; }
            ViewData["atenHora"] = HoraAten;

            return View();
        }


        // get CambioHoraAten
        public ActionResult CambioHoraAten()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CambioHoraAten(string horaAte, int rut)
        {

            return RedirectToAction("HorarioAtencion");

        }



        public ActionResult CambiosHorario()
        {
            string nombreUsuario = ModelosGlobales.GlobalValueNombre + " " + ModelosGlobales.GlobalValueApellidos;
            ViewData["UsuarioActualNombre"] = nombreUsuario;

            CrearCalendario c = new CrearCalendario();
            List<List<string>> Calendario = new List<List<string>>();
            Calendario = c.CrearProfesor();
            ViewBag.ListCalendario = Calendario;

            var horarios = db.Horarios.Include(h => h.Asignaturas).Include(h => h.Hora).Include(h => h.Salas).Include(h => h.Usuarios).Where(h => h.RutProfesor == (ModelosGlobales.GlobalValue));
            return View(horarios.ToList());
        }

        //
        // GET: /Horarios/Delete/5

        public ActionResult DeleteProfe(byte ida = 0, byte idm = 0, string idp = "A", byte idd = 0, byte idh = 0)
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

        [HttpPost, ActionName("DeleteProfe")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProfeConfirmed(byte ida = 0, byte idm = 0, string idp = "A", byte idd = 0, byte idh = 0)
        {
            Horarios horarios = db.Horarios.Find(ida, idm, idp, idd, idh);
            db.Horarios.Remove(horarios);
            db.SaveChanges();
            return RedirectToAction("CambiosHorario");
        }
        //
        // GET: /Horarios/Edit/5

        public ActionResult EditProfe(byte ida = 0, byte idm = 0, string idp = "A", byte idd = 0, byte idh = 0)
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
            var stands = db.Salas
                            .Where(s => s.CodSala != null).AsEnumerable()
                            .Select(s => new
                            {
                                CodSala = s.CodSala,
                                CodEdificio = string.Format("{0} - {1}", s.CodEdificio, s.NumeroSala)
                            })
                            .ToList();

            ViewBag.CodSala = new SelectList(stands, "CodSala", "CodEdificio",horarios.CodSala );

            var RutNombre = db.Usuarios
                .Where(s => s.Rut != 0).AsEnumerable()
                .Select(s => new
                {
                    Rut = s.Rut,
                    Nombre = string.Format("{0} {1}", s.Nombre, s.Apellidos)
                })
                .ToList();
            ViewBag.RutProfesor = new SelectList(RutNombre, "Rut", "Nombre", horarios.RutProfesor);
            return View(horarios);
        }

        //
        // POST: /Horarios/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfe(Horarios horarios, byte? _codAsig, byte? _dia, byte? _codHora, byte? _modificado, string _paralelo)
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
                return RedirectToAction("CambiosHorario");
            }
            ViewBag.CodAsignatura = new SelectList(db.Asignaturas, "CodAsig", "CodAsig", horarios.CodAsignatura);
            ViewBag.CodHora = new SelectList(db.Hora, "CodHora", "CodHora", horarios.CodHora);
            ViewBag.CodSala = new SelectList(db.Salas, "CodSala", "CodSala", horarios.CodSala);
            ViewBag.RutProfesor = new SelectList(db.Usuarios, "Rut", "Rut", horarios.RutProfesor);
            return View(horarios);
        }


        //
        // GET: /Horarios/Create

        public ActionResult CreateProfe()
        {
            CrearCalendario c = new CrearCalendario();
            List<List<string>> Calendario = new List<List<string>>();
            Calendario = c.CrearMuestra();
            ViewBag.ListCalendario = Calendario;
            ViewBag.CodAsignatura = new SelectList(db.Asignaturas, "CodAsig", "Nombre");
            ViewBag.CodHora = new SelectList(db.Hora, "CodHora", "CodHora");

            var stands =db.Salas
                            .Where(s => s.CodSala != null).AsEnumerable()
                            .Select(s => new
                            {
                                CodSala = s.CodSala,
                                CodEdificio = string.Format("{0} - {1}", s.CodEdificio, s.NumeroSala)
                            })
                            .ToList();

            ViewBag.CodSala = new SelectList(stands, "CodSala", "CodEdificio");

            var RutNombre = db.Usuarios
                .Where(s => s.Rut != 0).AsEnumerable()
                .Select(s => new
                {
                    Rut = s.Rut,
                    Nombre = string.Format("{0} {1}", s.Nombre, s.Apellidos)
                })
                .ToList();
            ViewBag.RutProfesor = new SelectList(RutNombre, "Rut", "Nombre");
            return View();
        }

        //
        // POST: /Horarios/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProfe(Horarios horarios)
        {
            if (ModelState.IsValid)
            {
                db.Horarios.Add(horarios);
                db.SaveChanges();
                return RedirectToAction("CambiosHorario");
            }

            ViewBag.CodAsignatura = new SelectList(db.Asignaturas, "CodAsig", "CodAsig", horarios.CodAsignatura);
            ViewBag.CodHora = new SelectList(db.Hora, "CodHora", "CodHora", horarios.CodHora);
            ViewBag.CodSala = new SelectList(db.Salas, "CodSala", "CodSala", horarios.CodSala);
            ViewBag.RutProfesor = new SelectList(db.Usuarios, "Rut", "Rut", horarios.RutProfesor);
            return View(horarios);
        }


        public ActionResult EspecificacionAsig()
        {
            AsignaturasProfesor Ap = new AsignaturasProfesor();
            List<List<string>> Asignaturas = new List<List<string>>();
            Asignaturas = Ap.BuscarAsignaturas();
            ViewBag.ListaAsignaturasProfe = Asignaturas;
            string nombreUsuario = ModelosGlobales.GlobalValueNombre + " " + ModelosGlobales.GlobalValueApellidos;
            ViewData["UsuarioActualNombre"] = nombreUsuario;
            return View();
        }

        public ActionResult AdministracionWeb()
        {
            string nombreUsuario = ModelosGlobales.GlobalValueNombre + " " + ModelosGlobales.GlobalValueApellidos;
            ViewData["UsuarioActualNombre"] = nombreUsuario;
            return View();
        }

        public ActionResult EvalucionesNotas()
        {
            string nombreUsuario = ModelosGlobales.GlobalValueNombre + " " + ModelosGlobales.GlobalValueApellidos;
            ViewData["UsuarioActualNombre"] = nombreUsuario;
            int rut = ModelosGlobales.GlobalValue;

            var usuarioasignatura = db.UsuarioAsignatura.Include(u => u.Asignaturas).Include(u => u.Usuarios).Where(u => u.RutProfesor == ModelosGlobales.GlobalValue);
            
            //var uaprueba = (from ua in db.UsuarioAsignatura
            //                join a in db.Asignaturas on ua.CodAsignatura equals a.CodAsig
            //                join h in db.Horarios on a.CodAsig equals h.CodAsignatura
            //                where (h.RutProfesor == rut)
            //                select new { UsuarioAsignatura = ua, Asignaturas = a, Horarios = h }).Distinct();
            ////select new { ua.RutUsuario, ua.Paralelo, ua.Nota1, ua.Nota2, ua.Nota3, ua.Nota4, ua.Nota5 }).ToList();

            //var verUA2 = uaprueba.ToList();
            var verUA = usuarioasignatura.ToList();
            //return View(usuarioasignatura.ToList());
            return View(verUA);
            //return View(uaprueba);
        }


        //
        // GET: /UsuarioAsignatura/Edit/5

        public ActionResult EditNotaProfe(int id = 0, int id2 = 0)
        {
            UsuarioAsignatura usuarioasignatura = db.UsuarioAsignatura.Find(id, id2);
            if (usuarioasignatura == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodAsignatura = new SelectList(db.Asignaturas, "CodAsig", "Nombre", usuarioasignatura.CodAsignatura);
            var RutNombre = db.Usuarios
                .Where(s => s.Rut != 0).AsEnumerable()
                .Select(s => new
                {
                    Rut = s.Rut,
                    Nombre = string.Format("{0} {1}", s.Nombre, s.Apellidos)
                })
                .ToList();
            ViewBag.RutUsuario = new SelectList(RutNombre, "Rut", "Nombre", usuarioasignatura.RutUsuario);

            var RutNombre2 = db.Usuarios
                .Where(s => s.TipoUser == 2).AsEnumerable()
                .Select(s => new
                {
                    Rut = s.Rut,
                    Nombre = string.Format("{0} {1}", s.Nombre, s.Apellidos)
                })
                .ToList();
            ViewBag.RutProfesor = new SelectList(RutNombre2, "Rut", "Nombre");
            return View(usuarioasignatura);
        }

        //
        // POST: /UsuarioAsignatura/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditNotaProfe(UsuarioAsignatura usuarioasignatura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarioasignatura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("EvalucionesNotas");
            }
            ViewBag.CodAsignatura = new SelectList(db.Asignaturas, "CodAsig", "Nombre", usuarioasignatura.CodAsignatura);
            ViewBag.RutUsuario = new SelectList(db.Usuarios, "Rut", "Rut", usuarioasignatura.RutUsuario);
            return View(usuarioasignatura);
        }

        //
        // GET: /Porfesor/DeleteNotaProfe/5

        public ActionResult DeleteNotaProfe(int id = 0, int id2 = 0)
        {
            UsuarioAsignatura usuarioasignatura = db.UsuarioAsignatura.Find(id, id2);
            if (usuarioasignatura == null)
            {
                return HttpNotFound();
            }
            return View(usuarioasignatura);
        }

        //
        // POST: /Porfesor/Delete/5

        [HttpPost, ActionName("DeleteNotaProfe")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteNotaProfeConfirmed(int id, int id2)
        {
            UsuarioAsignatura usuarioasignatura = db.UsuarioAsignatura.Find(id, id2);
            db.UsuarioAsignatura.Remove(usuarioasignatura);
            db.SaveChanges();
            return RedirectToAction("EvalucionesNotas");
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}