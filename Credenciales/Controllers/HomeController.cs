using Credenciales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Credenciales.Controllers
{
    public class HomeController : Controller
    {
        ConsultaUsuarios ob = new ConsultaUsuarios();
        public ActionResult Index(loginViewModel model)
       {
           
            return View("Index");
        }

       
        [HttpPost]
        public ActionResult regLogin(loginViewModel model)
        {
            if (model.Usuario != null || model.Contra != null)
            {
                var usuario = ob.ConsultaUser(model.Usuario, model.Contra);
                if (usuario.Item1 == HttpStatusCode.OK)
                {
                    Session["Usuario"] = usuario.Item2.usuario;
                    Session["Contra"] = usuario.Item2.usuario;

                    return RedirectToAction("Index", "Principal");

                }
                else if (usuario.Item1 == HttpStatusCode.InternalServerError)
                {
                    @TempData["validation"] = "Por favor intenta mas tarde";
                    return RedirectToAction("Index");
                }
                else if (usuario.Item1 == HttpStatusCode.NotFound)
                {
                    @TempData["validation"] = "Lo sentimos el usuario no existe";
                    return RedirectToAction("Index");
                }
            }
            return View("Index");
        }
        public bool parametros(string Usuario, string Contra, string Nombre, string Mail, string Telefono, string Tipo_Usuario)
        {
            if (Usuario == null || Contra == null || Nombre == null || Mail == null || Telefono == null || Tipo_Usuario == null)
                return false;
            else
                return true;
        }
    }
}