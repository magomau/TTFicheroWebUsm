using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using UsmFicheroWeb.Models;
using System.IO;
using System.Reflection;

namespace UsmFicheroWeb.Controllers
{
    public class LoginController : Controller
    {
        private FicheroBDEntities1 db = new FicheroBDEntities1();
        private FicheroBDEntities1 dba = new FicheroBDEntities1();
        public string userIDCarrera2 = null;
        //
        // GET: /Login/

        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult Contrasena(int id = 0)
        {
            id = ModelosGlobales.GlobalValue;
            ViewData["XXX"] = ModelosGlobales.GlobalValuePass ;
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }
        public ActionResult contrasenaprof(int id = 0)
        {
            id = ModelosGlobales.GlobalValue;
            ViewData["XXX"] = ModelosGlobales.GlobalValuePass;
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contrasena(Usuarios usuarios , string Password)
        {
            if (Password == ModelosGlobales.GlobalValuePass)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult contrasenaprof(Usuarios usuarios, string Password)
        {
            if (Password == ModelosGlobales.GlobalValuePass)
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
        public ActionResult Horarios()
        {
            //var query = db.Horarios.Include
            var horario = db.Horarios.Include(n => n.Asignaturas)
                                        .Where(n => n.Dia.Equals(1))
                                        .Where(n => n.CodAsignatura.Equals(db.UsuarioAsignatura.Include(m => m.Usuarios).Where(m => m.RutUsuario == (ModelosGlobales.GlobalValue))));
                                         //& n.CodAsignatura.Equals(db.UsuarioAsignatura.Include(m => m.CodAsignatura).Where(m => m.RutUsuario ==(ModelosGlobales.GlobalValue))));
                                      //.Where(n => n.IdCarrera == (ModelosGlobales.GlobalValue2) || n.IdCarrera == null);
             //var horario1 = db.Horarios.Include(n => n.CodAsignatura)
             //                           .Where(n => n.Dia.Equals(1) && n.CodHora.Equals(1) );

           return View(horario.OrderBy(c => c.CodHora).ToList());
        }

        public ActionResult GeneralProfe()
        {
            string nombreUsuario = ModelosGlobales.GlobalValueNombre + " " + ModelosGlobales.GlobalValueApellidos;
            ViewData["DirFoto"] = RetornarFoto();
            ViewData["UsuarioActualNombre"] = nombreUsuario;
            var noticias = db.Noticias.Include(n => n.Usuarios)
                                        .Where(n => n.IdCarrera == (ModelosGlobales.GlobalValue2) || n.IdCarrera == null);
            // Se mostraran solo noticias Donde Asignatura corresponda al Usuario en sesion.
            //.Where(x => x.CodAsignatura.Equals  (db.UsuarioAsignatura.Where(y => y.RutUsuario  == (ModelosGlobales.GlobalValue )).Select(n => n.CodAsignatura)));
            return View(noticias.OrderByDescending(c => c.IdNoticias).ToList());

        }
        public ActionResult notaedit(int id = 0, int id2 = 0)
        {
            UsuarioAsignatura usuarioasignatura = db.UsuarioAsignatura.Find(id, id2);
            if (usuarioasignatura == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodAsignatura = new SelectList(db.Asignaturas, "CodAsig", "Nombre", usuarioasignatura.CodAsignatura);
            ViewBag.RutUsuario = new SelectList(db.Usuarios, "Rut", "Nombre", usuarioasignatura.RutUsuario);
            return View(usuarioasignatura);
        }

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult notaedit(UsuarioAsignatura usuarioasignatura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarioasignatura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PrivadoProfe");
            }
            ViewBag.CodAsignatura = new SelectList(db.Asignaturas, "CodAsig", "Nombre", usuarioasignatura.CodAsignatura);
            ViewBag.RutUsuario = new SelectList(db.Usuarios, "Rut", "Dv", usuarioasignatura.RutUsuario);
            return View(usuarioasignatura);
        }

        public ActionResult PrivadoProfe()
        {
            string nombreUsuario = ModelosGlobales.GlobalValueNombre + " " + ModelosGlobales.GlobalValueApellidos;
            ViewData["UsuarioActualNombre"] = nombreUsuario;
            ViewData["DirFoto"] = RetornarFoto();
            var usuarioasignatura = db.UsuarioAsignatura.Include(u => u.Asignaturas).Include(u => u.Usuarios);
            return View(usuarioasignatura.ToList());
        }
        public ActionResult Privado()
        {
            string nombreUsuario = ModelosGlobales.GlobalValueNombre + " " + ModelosGlobales.GlobalValueApellidos;
            ViewData["UsuarioActualNombre"] = nombreUsuario;

            string nombreCarrera = ModelosGlobales.GlobalValueNomCarrera;
            ViewData["CarreraDelUsuario"] = nombreCarrera;

            CrearCalendario c = new CrearCalendario();
            List<List<string>> Calendario = new List<List<string>>();
            Calendario = c.Crear();
           ViewBag.ListCalendario = Calendario;

            var usuarioasignatura = db.UsuarioAsignatura.Include(u => u.Asignaturas).Include(u => u.Usuarios)
                                     .Where(u => u.RutUsuario == (ModelosGlobales.GlobalValue));
            return View(usuarioasignatura.ToList());
        }

        public ActionResult General()
        {
            string nombreUsuario = ModelosGlobales.GlobalValueNombre + " " + ModelosGlobales.GlobalValueApellidos;
            ViewData["DirFoto"] = RetornarFoto();
            ViewData["UsuarioActualNombre"] = nombreUsuario; // ModelosGlobales.GlobalValueNombre;

            string nombreCarrera = ModelosGlobales.GlobalValueNomCarrera;
            ViewData["CarreraDelUsuario"] = nombreCarrera;

            var getcarreras = db.Carreras.ToList();
            SelectList Carreras = new SelectList(getcarreras, "IdCarrera", "NombreCarrera");
            ViewBag.ListCarreras = Carreras;

            var noticias = db.Noticias.Include(n => n.Usuarios)
                                      .Where(n => n.IdCarrera == (ModelosGlobales.GlobalValue2) || n.IdCarrera == null);
            var asdasd = noticias.OrderByDescending(c => c.IdNoticias).ToList();

            

            var hola = (from u in db.Noticias.Include(n => n.Usuarios)
                       //join c in db.Carreras on u.IdCarrera equals c.IdCarrera
                       where ((u.IdCarrera == ModelosGlobales.GlobalValue2) || (u.IdCarrera == null))
                       select new { Noticias = u/*, Carreras = c*/ });
            var hola1 = hola.OrderByDescending(c => c.Noticias.IdNoticias).ToList();

           
            // Se mostraran solo noticias Donde Asignatura corresponda al Usuario en sesion.
            //.Where(x => x.CodAsignatura.Equals  (db.UsuarioAsignatura.Where(y => y.RutUsuario  == (ModelosGlobales.GlobalValue )).Select(n => n.CodAsignatura)));
            return View(asdasd);

        }

        public string RetornarFoto()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().EscapedCodeBase);// raiz adentro del bin !!
            string link = null;
            link =  ModelosGlobales.GlobalValueNombre + ModelosGlobales.GlobalValueApellidos;
            string DirectorioRoot = AppDomain.CurrentDomain.BaseDirectory;
            string asd = @"Fotos\" + link + ".jpg";
            string dir = Path.Combine(DirectorioRoot, asd); /*"\\Fotos\\" +  link + ".jpg";*/
            if (!System.IO.File.Exists(dir))
            {
                link = "SinFoto";
            }
            return link;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuarios u, int TipoUsuario)
        {
            // this action is for handle post (login)

            if (ModelState.IsValid) // this is check validity
            {
                using (FicheroBDEntities1 db = new FicheroBDEntities1())
                {
                    var v = db.Usuarios.Where(a => a.Rut.Equals(u.Rut) && a.Contraseña.Equals(u.Contraseña) && a.Dv.Equals(u.Dv)).FirstOrDefault();
                    if (v != null)
                    {
                        Usuarios algo = new Usuarios();
                        ModelosGlobales.GlobalValue = v.Rut;
                        ModelosGlobales.GlobalValue4 = v.TipoUser;
                        ModelosGlobales.GlobalValueNombre = v.Nombre;
                        ModelosGlobales.GlobalValueApellidos = v.Apellidos;
                        ModelosGlobales.GlobalValuePass = v.Contraseña;
                        ModelosGlobales.GlobalHorarioAtencion = v.HorarioAtencion;

                        Session["userIDCarrera"] = v.IdCarrera.ToString();
                        ModelosGlobales.GlobalValue2 = v.IdCarrera;
                        var carreraVar = (from c in db.Carreras where (c.IdCarrera == v.IdCarrera) select c.NombreCarrera).FirstOrDefault();
                        if (carreraVar != null)
                        {
                            ModelosGlobales.GlobalValueNomCarrera = carreraVar.ToString();
                        }
                        else { ModelosGlobales.GlobalValueNomCarrera = "Sin Carrera"; }
                        userIDCarrera2 = Session["userIDCarrera"] as string;
                        if (TipoUsuario == 0)
                        {

                            if (ModelosGlobales.GlobalValue4 == 1)
                            {
                                return RedirectToAction("General", "Login");
                            }
                            else if (ModelosGlobales.GlobalValue4 == 2)
                            {
                                return RedirectToAction("GeneralProfe", "Login");
                            }
                            else
                            {
                                return RedirectToAction("Index", "Adminstrador");
                            }
                        }
                        else if ((TipoUsuario == 1 && ModelosGlobales.GlobalValue4 == 1) || (TipoUsuario == 1 && ModelosGlobales.GlobalValue4 == 2) || (TipoUsuario == 1 && ModelosGlobales.GlobalValue4 == 3))
                        {

                            return RedirectToAction("General", "Login");
                        }
                        else if ((TipoUsuario == 2 && ModelosGlobales.GlobalValue4 == 2) || (TipoUsuario == 2 && ModelosGlobales.GlobalValue4 == 3))
                        {
                            return RedirectToAction("GeneralProfe", "Login");
                        }
                        else if (TipoUsuario == 3 && ModelosGlobales.GlobalValue4 == 3)
                        {
                            return RedirectToAction("Index", "Adminstrador");
                        }
                    }
                }
            }
            return View(u);
        }
    }
}
