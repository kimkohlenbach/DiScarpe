using DiScarpe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiScarpe.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: Home
        public ActionResult ListaDesejos()
        {
            return View();
        }

        // GET: Home
        public ActionResult Carrinho()
        {
            return View();
        }


        // REGISTRAR ----------------------------------------------------------------
        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(Usuario obj)

        {
            if (ModelState.IsValid)
            {
                DiScarpeDBEntities db = new DiScarpeDBEntities();
                db.Usuario.Add(obj);
                db.SaveChanges();
            }
            return View(obj);
        }

        // LOGIN ----------------------------------------------------------------
        public ActionResult Login()
        {

            return View();
        }


        [HttpPost]
        public ActionResult Acesso(DiScarpe.Models.Usuario userModel)
        {
            using (DiScarpeDBEntities db = new DiScarpeDBEntities())
            {
                var infoUsuario = db.Usuario.Where(x => x.Email == userModel.Email && x.Senha == userModel.Senha).FirstOrDefault();
                if (infoUsuario == null)
                {
                    userModel.LoginErrorMessage = "Nome ou senha incorretos.";
                    return View("Login", userModel);
                }
                else
                {
                    Session["IdUsuario"] = infoUsuario.IdUsuario;
                    Session["Email"] = infoUsuario.Email;
                    Session["Nome"] = infoUsuario.Nome;
                    return RedirectToAction("ListaDesejos", "Home");
                }
            }
        }

        public ActionResult LogOut()
        {
            int IdUsuario = (int)Session["IdUsuario"];
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult LoginAdministrador()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AcessoAdmin(DiScarpe.Models.Usuario u)
        {
            DiScarpeDBEntities db =new DiScarpeDBEntities();
            
            return View();
        }
        
    }
}