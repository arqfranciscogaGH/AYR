using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Sitio;
using System.Data.Entity.Core.Objects;
using Sitio.Comun.Clases;

namespace Sitio.Controllers
{
    public class CuentaUsuariosController : ApiController
    {
        private db_conexion db = new db_conexion();
        // GET:   http://localhost:55377/api/CuentaUsuarios?cuenta=giorgio&clave=123
        [ResponseType(typeof(IQueryable<CuentaUsuario>))]
        public IHttpActionResult GetEntidadPorArgumentos([FromUri] string cuenta, [FromUri] string clave)
        { 
            CuentaUsuario resultado = null;
            resultado = db.CuentaUsuario.Where(s => s.Cuenta.ToString() == cuenta && s.Activo == true).FirstOrDefault();
            if (resultado != null)
            {
                if (resultado.Contrasena != clave)
                    resultado = null;
            }
            if (resultado == null)
            {
                return NotFound();
            }
            return Ok(resultado);
        }

        // GET: api/CuentaUsuarios
        public IQueryable<CuentaUsuario> GetEntidad()
        {
            return db.CuentaUsuario;
        }
        // GET: api/CuentaUsuarios/prueba
        [ResponseType(typeof(IQueryable<CuentaUsuario>))]
        public IHttpActionResult GetEntidadPorLlave(String llave)
        {
            IQueryable<CuentaUsuario> resultado = null;
            AutenticacionLlave autentificacion = new AutenticacionLlave();
            if (autentificacion.verificacion(llave))
                resultado = db.CuentaUsuario.Where(s => s.Activo ==true);
            if (resultado == null)
            {
                return NotFound();
            }
            return Ok(resultado);
         }

        // GET: api/CuentaUsuarios/1/prueba
        [ResponseType(typeof(CuentaUsuario))]
        public IHttpActionResult GetEntidadIdLlave(int id,String llave)
        {
            CuentaUsuario resultado = null;
            AutenticacionLlave autentificacion = new AutenticacionLlave();
            if (autentificacion.verificacion(llave))
                resultado = db.CuentaUsuario.Find(id);

            if (resultado == null)

                return NotFound();
            return Ok(resultado);
        }
        // GET: api/CuentaUsuarios/1/10/prueba
        [ResponseType(typeof(Paginador<CuentaUsuario>))]
        public IHttpActionResult GetEntidadPorPagina(int pagina, int registrosPorPagina, String llave)
        {
            var _Paginador = new Paginador<CuentaUsuario>();
            var _lista = db.CuentaUsuario.Where(s => s.Activo == true);
            AutenticacionLlave autentificacion = new AutenticacionLlave();
            if (autentificacion.verificacion(llave))
            {
                int _TotalRegistros = db.CuentaUsuario.Count();
                pagina = pagina == 0 ? 1 : pagina;
                registrosPorPagina = registrosPorPagina == 0 ? _TotalRegistros : registrosPorPagina;
                var _TotalPaginas = (int)Math.Ceiling((double)_TotalRegistros / registrosPorPagina);
                // int final = pagina * registrosPorPagina;
                // int inicial = final - registrosPorPagina;
                // _lista = db.PreRegistro.Where(s => s.id > inicial && s.estatus == 1).Take(registrosPorPagina);
                _lista = _lista.OrderBy(s => s.IdUsuario).Skip((pagina - 1) * registrosPorPagina)
                                                .Take(registrosPorPagina);
                _Paginador = new Paginador<CuentaUsuario>()
                {
                    registrosPorPagina = registrosPorPagina,
                    totalRegistros = _TotalRegistros,
                    totalPaginas = _TotalPaginas,
                    paginaActual = pagina,
                    resultado = _lista
                };
            }
            if (_lista == null)
            {
                return NotFound();
            }

            return Ok(_Paginador);
        }

        // GET: api/CuentaUsuarios/1/10/genero=M,clase=negro/amb
        [ResponseType(typeof(Paginador<CuentaUsuario>))]
        public IHttpActionResult GetEntidadPorPaginaFiltro(int pagina, int registrosPorPagina, String filtro, String llave)
        {
            var _Paginador = new Paginador<CuentaUsuario>();
            var _lista = db.CuentaUsuario.Where(s => s.Activo == true);
            AutenticacionLlave autentificacion = new AutenticacionLlave();
            if (autentificacion.verificacion(llave))
            {
                int _TotalRegistros = db.CuentaUsuario.Count();
                pagina = pagina == 0 ? 1 : pagina;
                registrosPorPagina = registrosPorPagina == 0 ? _TotalRegistros : registrosPorPagina;
                var _TotalPaginas = (int)Math.Ceiling((double)_TotalRegistros / registrosPorPagina);

                if (filtro != "")
                {
                    string[] filtros = filtro.Split(',');
                    foreach (string elementoFiltro in filtros)
                    {
                        string[] camposFiltro = elementoFiltro.Split('=');
                        String campo = camposFiltro[0];
                        String valor = camposFiltro[1];
                        if (campo.ToLower() == "idsuscriptor")
                            _lista = _lista.Where(s => s.IdSuscriptor.ToString() == valor.ToLower());
             
                    }

                }
                // int final = pagina * registrosPorPagina;
                // int inicial = final - registrosPorPagina;
                //_lista = _lista.Where(s => s.id > inicial && s.estatus == 1).Take(registrosPorPagina);
                _lista = _lista.OrderBy(s => s.IdUsuario).Skip((pagina - 1) * registrosPorPagina)
                                                .Take(registrosPorPagina);
                _Paginador = new Paginador<CuentaUsuario>()
                {
                    registrosPorPagina = registrosPorPagina,
                    totalRegistros = _TotalRegistros,
                    totalPaginas = _TotalPaginas,
                    paginaActual = pagina,
                    resultado = _lista
                };
            }
            if (_lista == null)
            {
                return NotFound();
            }

            return Ok(_Paginador);
        }


        // PUT: api/CuentaUsuarios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCuentaUsuario(int id, String llave, CuentaUsuario cuentaUsuario)
        {
            AutenticacionLlave autentificacion = new AutenticacionLlave();
            if (autentificacion.verificacion(llave))
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (id != cuentaUsuario.IdUsuario)
                {
                    return BadRequest();
                }
                db.Entry(cuentaUsuario).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntidadExiste(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
                return NotFound();
        }

        // POST: api/CuentaUsuarios
        [ResponseType(typeof(CuentaUsuario))]
        public IHttpActionResult PostCuentaUsuario(String llave, CuentaUsuario cuentaUsuario)
        {
            AutenticacionLlave autentificacion = new AutenticacionLlave();
            if (autentificacion.verificacion(llave))
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                db.CuentaUsuario.Add(cuentaUsuario);
                db.SaveChanges();

                return CreatedAtRoute("DefaultApi", new { id = cuentaUsuario.IdUsuario }, cuentaUsuario);
            }
            else
                return NotFound();
        }

        // DELETE: api/CuentaUsuarios/5
        [ResponseType(typeof(CuentaUsuario))]
        public IHttpActionResult DeleteCuentaUsuario( int id, String llave)
        {
            AutenticacionLlave autentificacion = new AutenticacionLlave();
            if (autentificacion.verificacion(llave))
            {
                CuentaUsuario cuentaUsuario = db.CuentaUsuario.Find(id);
                if (cuentaUsuario == null)
                {
                    return NotFound();
                }

                db.CuentaUsuario.Remove(cuentaUsuario);
                db.SaveChanges();

                return Ok(cuentaUsuario);
            }
            else
                return NotFound();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EntidadExiste(int id)
        {
            return db.CuentaUsuario.Count(e => e.IdUsuario == id) > 0;
        }
    }
}