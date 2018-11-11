using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HelpDesk.Models;

namespace HelpDesk.Controllers
{
    public class ProdutoController : ApiController
    {
        public static Context db = new Context();
        // GET api/values
        public IEnumerable<Produto> Get()
        {
            return db.Produto.ToList();
        }
        // GET api/values/5
        public Produto Get(string id)
        {

            return db.Produto.ToList().Where(produto => produto.Cod_Produto == id).First();
        }
        // POST api/values
        public HttpResponseMessage Post([FromBody]Produto value)
        {
            if (value == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            db.Produto.Add(value);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }
        // PUT api/values/5
        public HttpResponseMessage Put(int id, [FromBody]Produto value)
        {
            if (value == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            db.Produto.Add(value);
            db.Entry(value).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }
        // DELETE api/values/5
        public HttpResponseMessage Delete(string id)
        {
            var chamado = db.Produto.ToList().Where(c => c.Cod_Produto == id).First();
            db.Produto.Remove(chamado);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);

        }
    }
}
