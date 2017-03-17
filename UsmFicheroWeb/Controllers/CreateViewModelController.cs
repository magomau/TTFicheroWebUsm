using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UsmFicheroWeb.Controllers
{
    public class CreateViewModelController : Controller
    {
        private FicheroBDEntities1 db = new FicheroBDEntities1();

        //
        // GET: /Usuarios/

        public ActionResult Index()
        {   
            return View();
        }
    }
}