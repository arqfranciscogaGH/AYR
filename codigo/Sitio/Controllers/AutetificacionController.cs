using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Sitio.Comun.Clases;

namespace Sitio.Controllers
{
    public class AutenticacionController : ApiController
    {
        private db_conexion db = new db_conexion();
        //  api/Autenticacion/?id=1&cuenta=giorgio&clave=123&operacion=reg&estacionTrabajo=fga
        [ResponseType(typeof(RegistrarSuscripcionLLave_Result))]
        public IHttpActionResult GetRegistrar([FromUri] int id,[FromUri] string cuenta, [FromUri] string clave,  [FromUri] string operacion, [FromUri] string estacionTrabajo)
        {
            ObjectResult<RegistrarSuscripcionLLave_Result> resultado=null;
            CuentaUsuario cuentaUsuario = null;
            //String llave = "{llave:";
            cuentaUsuario = db.CuentaUsuario.Where(s=>s.Cuenta.ToString()== cuenta && s.Activo==true).FirstOrDefault();
            if (cuentaUsuario != null)
            {
                if (cuentaUsuario.Contrasena == clave)
                {
                    resultado = db.RegistrarSuscripcionLLave(id, cuenta, operacion, estacionTrabajo);
                    //llave += resultado.FirstOrDefault().llave + "}";
                }
                //else
                //    llave = null;
            }
            if (resultado == null )
            {
                return NotFound();
            }
            return Ok(resultado);
        }

        //  api/ServicioAplicacion/?id=1&llave=EC91EEAB-2D42-4E59-A26C-840A2672BC24 &llaveE=null
        [ResponseType(typeof(VerificarSuscripcionLLave_Result))]
        public IHttpActionResult GetVerificar([FromUri] int id, [FromUri] string llave, [FromUri] byte[] llaveE)
        {
            VerificarSuscripcionLLave_Result resultado = db.VerificarSuscripcionLLave(id, llave, llaveE).FirstOrDefault();
            return Ok(resultado);
        }

        // POST: api/ServicioAplicacion/cuerpo
        [ResponseType(typeof(RegistrarSuscripcionLLave_Result))]
        public IHttpActionResult PostCuentaUsuario(AutenticacionServicio autentificacion)
        {
            RegistrarSuscripcionLLave_Result resultado = null;
            CuentaUsuario cuentaUsuario = null;
            //String llave = "{llave:";
            cuentaUsuario = db.CuentaUsuario.Where(s => s.Cuenta.ToString() == autentificacion.cuenta && s.Activo == true).FirstOrDefault();
            if (cuentaUsuario != null)
            {
                if (cuentaUsuario.Contrasena == autentificacion.clave)
                {
                    resultado = db.RegistrarSuscripcionLLave(autentificacion.id, autentificacion.cuenta, autentificacion.operacion, autentificacion.estacionTrabajo).FirstOrDefault();
                }
                //else
                //    llave = null;
            }
            if (resultado == null)
            {
                return NotFound();
            }
            return Ok(resultado);
        }
    }
}