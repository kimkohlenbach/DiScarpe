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

        public ActionResult Feminino()
        {
            var model = from c in db.Produto
                        orderby c.IdCategoria
                        where c.IdCategoria == 1
                        select c;

            return View(model);
        }

        public ActionResult Masculino()
        {
            var model = from c in db.Produto
                        orderby c.IdCategoria
                        where c.IdCategoria == 2
                        select c;
            return View(model);
        }

        // GET: Home
        public ActionResult ListaDesejos()
        {
            return View();
        }

        // CARRINHO DE COMPRAS
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
                    if (info.Adminisrador)
                    {
                        return RedirectToAction("Adicionar", "Produto");
                    }
                    else
                    {
                        Session["IdUsuario"] = Usuario.IdUsuario;
                        Session["Email"] = Usuario.Email;
                        Session["Nome"] = Usuario.Nome;
                        return RedirectToAction("ListaDesejos", "Home");
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