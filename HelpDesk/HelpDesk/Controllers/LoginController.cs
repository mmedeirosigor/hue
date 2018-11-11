using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;
using HelpDesk.Models;

namespace HelpDesk.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index([FromBody]string email, string senha)
        {
            ViewBag.Title = "Home Page";


            if(email != null && senha != null) {
                var result = Usuario.Login(email, senha);

                if (result != null)
                {
                    Session["Login"] = result;

                    Response.Redirect("~/Dashboard/Index");

                    return null;
                }
            }

            return View();
        }
     }
}
