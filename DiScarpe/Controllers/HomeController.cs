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
        private DiScarpeDBEntities db = new DiScarpeDBEntities();

        public ActionResult Index(string pesquisar)
        {
            return View(db.Produto.Where(x => x.Nome.Contains(pesquisar) || pesquisar == null).ToList());
        }

        [HttpPost]
        public ActionResult Index(DiScarpe.Models.Produto produtos)
        {
            if (ModelState.IsValid)
            {
                db.Produto.Add(produtos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produtos);
        }

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

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Acesso(DiScarpe.Models.Usuario Usuario)
        {
            using (DiScarpeDBEntities db = new DiScarpeDBEntities())
            {

                var info = db.Usuario.Where(x => x.Email == Usuario.Email && x.Senha == Usuario.Senha).FirstOrDefault();
                if (info == null)
                {
                    Usuario.LoginErrorMessage = "Nome ou senha incorretos.";
                    return View("Login", Usuario);
                }
                else
                {
                    if (info.Administrador)
                    {
                        Session["IdUsuario"] = info.IdUsuario;
                        Session["Email"] = info.Email;
                        Session["Nome"] = info.Nome;
                        Session["Administrador"] = info.Administrador;
                        return RedirectToAction("Painel", "Produto");
                      
                    }
                    else
                    {
                        Session["IdUsuario"] = info.IdUsuario;
                        Session["Email"] = info.Email;
                        Session["Nome"] = info.Nome;
                        Session["Administrador"] = info.Administrador;
                        return RedirectToAction("ListaDesejos", "Cliente");
                    }
                }
            }
        }

        public ActionResult LogOut()
        {
            int IdUsuario = (int)Session["IdUsuario"];
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

    }
}