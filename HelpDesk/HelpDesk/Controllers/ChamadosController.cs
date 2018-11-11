using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HelpDesk.Models;

namespace HelpDesk.Controllers
{
    public class ChamadosController : ApiController
    {
        public static Context db = new Context();
        // GET api/Chamados
        public IEnumerable<Chamados> Get()

        {
             return  db.Chamados.ToList();

        }
        // GET api/Chamados/5
        public Chamados Get(string id)
        {
            return db.Chamados.ToList().Where(chamado => chamado.Cod_Chamado == id).First();
        }
        // POST api/Chamados
        public HttpResponseMessage Post([FromBody]Chamados value)
        {
            if (value == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var chamados = db.Chamados.ToList();
            value.Cod_Chamado = (chamados.Count() + 1).ToString();
            value.Data = DateTime.Now;
            db.Chamados.Add(value);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }
        // PUT api/Chamados/5
        public HttpResponseMessage Put(int id, [FromBody]Chamados value)
        {
            if (value == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            db.Chamados.Add(value);
            db.Entry(value).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }
        // DELETE api/Chamados/5
        public HttpResponseMessage Delete(string id)
        {
            var chamado = db.Chamados.ToList().Where(c => c.Cod_Chamado == id).First();
            db.Chamados.Remove(chamado);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);

        }


    }
}
