using System.Linq;
using System.Web.Mvc;
using HelpDesk.Models;

namespace HelpDesk.Controllers
{
    public class DashboardController : Controller
    {
        private static Context db = new Context();
        public ActionResult Index()
        {
            string Cod_usuario =(string)@Session["Login"];
            ViewBag.Cod_usuario = Cod_usuario;
            if (Cod_usuario == null)
            {
                
                return View();
            }
            else
            {
                Usuario usuario;
                
                Cliente cliente = null;

                cliente = db.Cliente.ToList().Where(c => c.ID_usuario == Cod_usuario).FirstOrDefault();

                if (cliente != null)
                {
                    usuario = db.Usuario.ToList().Where(u => u.ID_usuario == cliente.ID_usuario).FirstOrDefault();
                    ViewBag.Chamados = new Chamados().GetListByUsuer(Cod_usuario.ToString());
                    ViewBag.IsCliente = true;
                }
                else
                {
                  
                    Funcionario funcionario = null;
                    funcionario = db.Funcionario.ToList().Where(f => f.ID_usuario == Cod_usuario).FirstOrDefault();
                    if (funcionario != null)
                    {
                        usuario = db.Usuario.ToList().Where(u => u.ID_usuario == funcionario.ID_usuario).First();
                        ViewBag.Chamados = new Chamados().GetList();
                        ViewBag.IsCliente = false;
                    }
                }

                ViewBag.Title = "Dashboard";
                ViewBag.Produtos = new Produto().GetProdutos(Cod_usuario.ToString());
                
            }
            return View();
        }
    }
}
