using DiScarpe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiScarpe.Controllers
{
    public class FemininoController : Controller
    {
        private DiScarpeDBEntities db = new DiScarpeDBEntities();

        public ActionResult Calcados()
        {
            var model = from c in db.Produto
                        orderby c.IdCategoria
                        where c.IdCategoria == 1
                        select c;

            return View(model);
        }

        public ActionResult Botas()
        {
            var model = from c in db.Produto
                        orderby c.IdEstilo
                        where c.IdCategoria == 1
                        where c.IdEstilo == 2
                        select c;

            return View(model);
        }

        public ActionResult Sandálias()
        {
            var model = from c in db.Produto
                        orderby c.IdEstilo
                        where c.IdCategoria == 1
                        where c.IdEstilo == 3
                        select c;

            return View(model);
        }

        public ActionResult Sapatilhas()
        {
            var model = from c in db.Produto
                        orderby c.IdEstilo
                        where c.IdCategoria == 1
                        where c.IdEstilo == 4
                        select c;

            return View(model);
        }

        public ActionResult Tênis()
        {
            var model = from c in db.Produto
                        orderby c.IdEstilo
                        where c.IdCategoria == 1
                        where c.IdEstilo == 1
                        select c;

            return View(model);
        }
    }
}