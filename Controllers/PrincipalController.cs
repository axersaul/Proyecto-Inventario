using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proyecto.Models;

namespace proyecto.Controllers
{

    public class PrincipalController : Controller
    {
        private storemyinventoryEntities db = new storemyinventoryEntities();
        // GET: Principal
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Models.ViewModels.Usuario datos)
        {
            string siguienteVista="Index";
            var busqueda = from p in db.usuario
                           where p.nombre == datos.Nombre
                           select p.contrasena;

            try
            {
                if (busqueda.First().ToString() == datos.Contrasena)
                {
                    siguienteVista = "MainMenu";
                }

            }
            catch (Exception e)
            {
            
            }

            
            return View("Menu/Index");
        }
        [HttpGet]
        public ActionResult MainMenu()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Inventory()
        {
            return View();
        }
          
    }
}