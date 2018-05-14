using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult AdicionarCarrinho()
        {
            return Content("Produto adicionado");
        }
    }
}