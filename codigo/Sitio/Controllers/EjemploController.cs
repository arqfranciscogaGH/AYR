using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Sitio.Comun.Clases;


namespace Sitio.Controllers
{
    public class EjemploController : ApiController
    {
        //[Authorize]
        [ResponseType(typeof(Cuenta))]
        public async Task<IHttpActionResult> Get()

        // public JsonResult ver()
        {
            Cuenta resultado = new Cuenta();
            resultado.Usuario = "fgarcia";
            // Json(new { success = "OK", error = "" });
            return Ok(resultado);
        }
    }
}
