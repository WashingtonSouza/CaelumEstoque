using CaelumEstoque.DAO;
using CaelumEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaelumEstoque.Controllers
{
    public class LoginController : Controller
    {
        public object UsuarioDao { get; private set; }

        // GET: Login
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Autentica(Usuario usuario)
        {
            UsuariosDAO dao = new UsuariosDAO();
            
            if (dao.Busca(usuario.Nome, usuario.Senha) != null)
            {
                Session["UsuarioLogado"] = usuario;
                return RedirectToAction("Index", "Produto");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}