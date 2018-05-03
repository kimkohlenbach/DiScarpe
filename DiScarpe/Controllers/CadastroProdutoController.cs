using DiScarpe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiScarpe.Controllers
{
    public class CadastroProdutoController : Controller
    {
        public ActionResult loginInterno()
        {
            return View();
        }
        // GET: CadastroProduto
        public ActionResult AddMercadoria()
        {
            {
                DiScarpeDBEntities db = new DiScarpeDBEntities();
                var Categoria = db.Categoria;
                List<SelectListItem> cat = new List<SelectListItem>();
                foreach (var i in Categoria)
                {
                    cat.Add(new SelectListItem
                    {
                        Text = i.Descricao,
                        Value = i.IdCategoria.ToString()
                    });
                }
                ViewBag.cat = cat;

                var Color = db.Cor;
                List<SelectListItem> color = new List<SelectListItem>();
                foreach (var i in Color)
                {
                    color.Add(new SelectListItem
                    {
                        Text = i.Descricao,
                        Value = i.IdCor.ToString()
                    });
                }
                ViewBag.color = color;

                var marca = db.Marca;
                List<SelectListItem> listaMarca = new List<SelectListItem>();
                foreach (var i in marca)
                {
                    listaMarca.Add(new SelectListItem
                    {
                        Text = i.Descricao,
                        Value = i.IdMarca + ""
                    });
                }
                ViewBag.marca = listaMarca;

                var tamanho = db.Tamanho;
                List<SelectListItem> listaTamanhos = new List<SelectListItem>();
                foreach (var i in tamanho)
                {
                    listaTamanhos.Add(new SelectListItem
                    {
                        Text = i.Descricao + "",
                        Value = i.IdTamanho + ""
                    });
                }
                ViewBag.tamanho = listaTamanhos;

                var estilo = db.Estilo;
                List<SelectListItem> listaEstilos = new List<SelectListItem>();
                foreach (var i in estilo)
                {
                    listaEstilos.Add(new SelectListItem
                    {
                        Text = i.Descricao,
                        Value = i.IdEstilo + ""
                    });
                }
                ViewBag.estilo = listaEstilos;
                return View();
            }

        }
        [HttpPost]
        public ActionResult AddMercadoria(Produto P)
        {
            DiScarpeDBEntities db = new DiScarpeDBEntities();
            db.Produto.Add(P);
            db.SaveChanges();
            return Content("alert('Inserido com  sucesso')");
        }
    }
}
