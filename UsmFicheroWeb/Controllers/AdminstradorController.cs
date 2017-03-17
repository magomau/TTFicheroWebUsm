using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UsmFicheroWeb.Models;

namespace UsmFicheroWeb.Controllers
{
    public class AdminstradorController : Controller
    {
        //
        // GET: /Adminstrador/

        public ActionResult Index()
        {
            string nombreUsuario = ModelosGlobales.GlobalValueNombre + " " + ModelosGlobales.GlobalValueApellidos;
            ViewData["UsuarioActualNombre"] = nombreUsuario;
            LoginController LC = new LoginController();
            ViewData["DirFoto"] = LC.RetornarFoto();
            return View();
        }

    }
}
