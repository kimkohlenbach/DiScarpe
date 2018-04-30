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


        public ActionResult Index()
        {
            var Produto = db.Produto;
            return View(Produto);
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



    }
}