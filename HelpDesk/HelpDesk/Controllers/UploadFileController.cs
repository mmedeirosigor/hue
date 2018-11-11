using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using HelpDesk.Models;

namespace HelpDesk.Controllers
{
    public class UploadFileController : ApiController
    {

       
        public HttpResponseMessage Post()
        {
            var file = HttpContext.Current.Request.Files.Count > 0 ?
                HttpContext.Current.Request.Files[0] : null;

            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);

                var path = Path.Combine(
                    HttpContext.Current.Server.MapPath("~/UploadedFiles"),
                     DateTime.Now.ToString("dd-MM-yyyy") + fileName
                );

                file.SaveAs(path);

                return Request.CreateResponse(HttpStatusCode.OK);
            }

            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }


    }
}
