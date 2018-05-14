using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiScarpe.Models;

namespace DiScarpe.Controllers
{
    public class ClienteController : Controller
    {
        public ActionResult ListaDesejos()
        {
            return View();
        }

        public ActionResult Carrinho()
        {
            return View();
        }

       
    }
}