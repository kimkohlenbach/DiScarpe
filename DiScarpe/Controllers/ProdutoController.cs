using DiScarpe.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiScarpe.Controllers
{
    public class ProdutoController : Controller
    {
        private DiScarpeDBEntities db = new DiScarpeDBEntities();

        public ActionResult Detalhes(int produtoId)
        {
            return View(db.Produto.FirstOrDefault(x => x.IdProduto == produtoId));
        }

        public ActionResult Painel()
        {
            int IdUsuario = (int)Session["IdUsuario"];
            var model = from c in db.Produto
                        orderby c.IdUsuario
                        where c.IdUsuario == IdUsuario
                        select c;

            return View(model);
        }


        // GET: CadastroProduto
        public ActionResult Adicionar()
        {
            {
                DiScarpeDBEntities db = new DiScarpeDBEntities();
                var Categoria = db.Categoria;
                List<SelectListItem> cat = new List<SelectListItem>();
                cat.Add(new SelectListItem
                {

                });
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
                color.Add(new SelectListItem
                {

                });
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
                listaMarca.Add(new SelectListItem
                {

                });
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
                listaTamanhos.Add(new SelectListItem
                {

                });
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
                listaEstilos.Add(new SelectListItem
                {

                });
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
        public ActionResult Adicionar(Produto P)
        {
            DiScarpeDBEntities db = new DiScarpeDBEntities();
            int IdUsuario = (int)Session["IdUsuario"];
            P.IdUsuario = IdUsuario;
            db.Produto.Add(P);
            db.SaveChanges();
            ViewBag.Status = "ok";
            return RedirectToAction("Administracao","Home");
        }

        public ActionResult AdicionarMarca()
        {
           
           return View();
        }

        [HttpPost]
        public ActionResult AdicionarMarca(Marca marca)
        {

            DiScarpeDBEntities db = new DiScarpeDBEntities();
            db.Marca.Add(marca);
            db.SaveChanges();
            ViewBag.mensagem = "Acesso Negado";
            return RedirectToAction("Adicionar", "Produto");
        }

        public ActionResult AdicionarCor()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AdicionarCor(Cor cor)
        {

            DiScarpeDBEntities db = new DiScarpeDBEntities();
            db.Cor.Add(cor);
            db.SaveChanges();
            ViewBag.mensagem = "Acesso Negado";
            return RedirectToAction("Adicionar", "Produto");
        }

        public ActionResult AdicionarEstilo()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AdicionarEstilo(Estilo estilo)
        {

            DiScarpeDBEntities db = new DiScarpeDBEntities();
            db.Estilo.Add(estilo);
            db.SaveChanges();
            ViewBag.mensagem = "Acesso Negado";
            return RedirectToAction("Adicionar", "Produto");
        }

        public ActionResult AdicionarTamanho()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AdicionarTamanho(Tamanho tamanho)
        {

            DiScarpeDBEntities db = new DiScarpeDBEntities();
            db.Tamanho.Add(tamanho);
            db.SaveChanges();
            ViewBag.mensagem = "Acesso Negado";
            return RedirectToAction("Adicionar", "Produto");
        }
        
        public ActionResult Categoria()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Categoria(Categoria C)
        {

            DiScarpeDBEntities db = new DiScarpeDBEntities();
            db.Categoria.Add(C);
            db.SaveChanges();
            ViewBag.mensagem = "Acesso Negado";
            return RedirectToAction("Adicionar", "Produto");
        }


        public ActionResult Editar(long id)
        {
            Produto produto = db.Produto.Find(id);
            ViewBag.IdCategoria = new SelectList(db.Categoria, "IdCategoria", "Descricao", produto.IdCategoria);
            ViewBag.IdMarca = new SelectList(db.Marca, "IdMarca", "Descricao", produto.IdMarca);
            ViewBag.IdCor = new SelectList(db.Cor, "IdCor", "Descricao", produto.IdCor);
            ViewBag.IdEstilo = new SelectList(db.Estilo, "IdEstilo", "Descricao", produto.IdEstilo);
            ViewBag.IdTamanho = new SelectList(db.Tamanho, "IdTamanho", "Descricao", produto.IdTamanho);
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "IdUsuario", produto.IdUsuario);
            return View(produto);
        }

        [HttpPost]
        public ActionResult Editar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified; db.SaveChanges();
                return RedirectToAction("Painel", "Produto");
            }
            ViewBag.IdCategoria = new SelectList(db.Categoria, "IdCategoria", "Categoria", produto.IdCategoria);
            ViewBag.IdMarca = new SelectList(db.Marca, "IdMarca", "Descricao", produto.IdMarca);
            ViewBag.IdCor = new SelectList(db.Cor, "IdCor", "Cor", produto.IdCor);
            ViewBag.IdEstilo = new SelectList(db.Estilo, "IdEstilo", "Estilo", produto.IdEstilo);
            ViewBag.IdTamanho = new SelectList(db.Tamanho, "IdTamanho", "Tamanho", produto.IdTamanho);
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "IdUsuario", produto.IdUsuario);
            return View(produto);
        }


        public ActionResult AdicionarCarrinho(Produto p)
        {
            if (Session["IdUsuario"]!=null)
            {
                if (Session["compras"] != null)
                {

                }
                else
                {

                }
            }
            return Content("Produto adicionado" + Session["carrinhoUsuario"]);
        }



    }
}