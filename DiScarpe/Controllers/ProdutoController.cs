using DiScarpe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiScarpe.Controllers
{
    public class ProdutoController : Controller
    {
        private DiScarpeDBEntities db = new DiScarpeDBEntities();
        

        public ActionResult Index(string pesquisar)
        {
            //var Produto = db.Produto;
            return View(db.Produto.Where(x => x.Nome.Contains(pesquisar) || pesquisar == null).ToList());

            //return View(Produto);
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

       

    }
}