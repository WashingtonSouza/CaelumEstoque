using CaelumEstoque.DAO;
using CaelumEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaelumEstoque.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            ProdutosDAO dao = new ProdutosDAO();
            IList<Produto> produtos = dao.Lista();
            ViewBag.produto = produtos;

            return View();
        }

        public ActionResult Form()
        {
            CategoriasDAO dao = new CategoriasDAO();
            IList<CategoriaDoProduto> categoria = dao.Lista();
            ViewBag.Categorias = categoria;
            ViewBag.Produto = new Produto();

            return View();
        }

        [HttpPost]
        public ActionResult Adiciona(Produto produto)
        {
            int idDaInformatica = 1;
            if (produto.CategoriaId.Equals(idDaInformatica) && produto.Preco >= 100)
            {
                ModelState.AddModelError("produto.Invalido", "Preço acima de 100 reais");
            }

            if (ModelState.IsValid)
            {                
                ProdutosDAO dao = new ProdutosDAO();
                dao.Adiciona(produto);

                return RedirectToAction("Index", "Produto");
            }
            else
            {
                ViewBag.Produto = produto;

                CategoriasDAO categoriasDAO = new CategoriasDAO();
                ViewBag.Categorias = categoriasDAO.Lista();

                return View("Form");
            }
            
        }
    }
}