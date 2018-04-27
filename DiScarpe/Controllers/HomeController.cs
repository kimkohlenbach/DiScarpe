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
    }
}