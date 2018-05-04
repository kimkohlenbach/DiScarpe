using DiScarpe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiScarpe.Controllers
{
    public class CategoriaController : Controller
    {
       public ActionResult Adicionar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Adicionar(Categoria C)
        {
            DiScarpeDBEntities db = new DiScarpeDBEntities();
            db.Categoria.Add(C);
            db.SaveChanges();
            return RedirectToAction("Adicionar", "Produto");
        }
    }
}