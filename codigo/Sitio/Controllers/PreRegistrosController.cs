using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Sitio;
using Sitio.Comun.Clases;


namespace Sitio.Controllers
{
    public class PreRegistrosController : ApiController
    {
        private db_conexion db = new db_conexion();


        // GET:   http://localhost:55377/api/PreRegistros?id=1&se=otra&et=fga
        public IQueryable<PreRegistro> GetEntidadPorArgumentos([FromUri] string id, [FromUri] string se, [FromUri] string et)
        {
            return db.PreRegistro.Where(s => s.estatus == 1);
        }

        // GET: api/PreRegistro
        public IQueryable<PreRegistro> GetEntidad()
        {

            return db.PreRegistro.Where(s => s.estatus == 1);
        }

        // GET: api/PreRegistros/prueba
        [ResponseType(typeof(IQueryable<PreRegistro>))]
        public  IHttpActionResult GetEntidadPorLlave(String llave)
        {;
            IQueryable<PreRegistro> resultado=null;
            AutenticacionLlave autentificacion = new AutenticacionLlave();
            if  (autentificacion.verificacion(llave) )
               resultado = db.PreRegistro.Where(s => s.estatus == 1);
            if (resultado == null)
            {
                return NotFound();
            }
            return Ok(resultado);
        }

        // GET: api/PreRegistros/1/prueba
        [ResponseType(typeof(PreRegistro))]
        public IHttpActionResult GetEntidadIdLlave(int id, String llave)
        {
            PreRegistro preRegistro=null;
            AutenticacionLlave autentificacion = new AutenticacionLlave();
            if (autentificacion.verificacion(llave))
                preRegistro = db.PreRegistro.Find(id);
     
            if (preRegistro == null)
            {
                return NotFound();
            }

            return Ok(preRegistro);
        }
        // GET: api/PreRegistros/1/10/prueba
        [ResponseType(typeof(Paginador<PreRegistro>))]
        public IHttpActionResult GetEntidadPorPagina( int pagina, int registrosPorPagina, String llave)
        {
            var _Paginador = new Paginador<PreRegistro>();
            var _lista = db.PreRegistro.Where(s => s.estatus == 1);
            AutenticacionLlave autentificacion = new AutenticacionLlave();
            if (autentificacion.verificacion(llave))
            {
                int _TotalRegistros = db.PreRegistro.Count();
                pagina = pagina == 0 ? 1 : pagina;
                registrosPorPagina = registrosPorPagina == 0 ? _TotalRegistros : registrosPorPagina;
                var _TotalPaginas = (int)Math.Ceiling((double)_TotalRegistros / registrosPorPagina);
                // int final = pagina * registrosPorPagina;
                // int inicial = final - registrosPorPagina;
                // _lista = db.PreRegistro.Where(s => s.id > inicial && s.estatus == 1).Take(registrosPorPagina);
                _lista = _lista.OrderBy(s => s.id).Skip((pagina - 1) * registrosPorPagina)
                                                .Take(registrosPorPagina);
                _Paginador = new Paginador<PreRegistro>()
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
        // GET: api/PreRegistros/1/10/genero=M,clase=negro/prueba
        [ResponseType(typeof(Paginador<PreRegistro>))]
        public IHttpActionResult GetEntidadPorPaginaFiltro(int pagina, int registrosPorPagina, String filtro, String llave)
        {
            var _Paginador = new Paginador<PreRegistro>();
            var _lista = db.PreRegistro.Where(s => s.estatus == 1);
            AutenticacionLlave autentificacion = new AutenticacionLlave();
            if (autentificacion.verificacion(llave))
            {
                int _TotalRegistros = db.PreRegistro.Count();
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
                        if (campo.ToLower() == "genero")
                            _lista = _lista.Where(s => s.genero.ToLower() == valor.ToLower());
                        if (campo.ToLower() == "clase")
                            _lista = _lista.Where(s => s.clase.ToLower() == valor.ToLower());
                    }

                }
                // int final = pagina * registrosPorPagina;
                // int inicial = final - registrosPorPagina;
                //_lista = _lista.Where(s => s.id > inicial && s.estatus == 1).Take(registrosPorPagina);
                _lista = _lista.OrderBy(s => s.id).Skip((pagina - 1) * registrosPorPagina)
                                                .Take(registrosPorPagina);
                _Paginador = new Paginador<PreRegistro>()
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



        // PUT: api/PreRegistros/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEntidad(int id, String llave, PreRegistro preRegistro)
        {
            AutenticacionLlave autentificacion = new AutenticacionLlave();
            if (autentificacion.verificacion(llave))
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (id != preRegistro.id)
                {
                    return BadRequest();
                }
                db.Entry(preRegistro).State = EntityState.Modified;
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

        // POST: api/PreRegistros
        [ResponseType(typeof(PreRegistro))]
        public IHttpActionResult PostEntidad(String llave, PreRegistro preRegistro)
        {
            AutenticacionLlave autentificacion = new AutenticacionLlave();
            if (autentificacion.verificacion(llave))
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                db.PreRegistro.Add(preRegistro);
                db.SaveChanges();

                return CreatedAtRoute("DefaultApi", new { id = preRegistro.id }, preRegistro);
            }
            else
                return NotFound();
        }

        // DELETE: api/PreRegistros/5
        [ResponseType(typeof(PreRegistro))]
        public IHttpActionResult DeleteEntidad(int id,String llave)
        {
            AutenticacionLlave autentificacion = new AutenticacionLlave();
            if (autentificacion.verificacion(llave))
            {

                PreRegistro preRegistro = db.PreRegistro.Find(id);
                if (preRegistro == null)
                {
                    return NotFound();
                }

                db.PreRegistro.Remove(preRegistro);
                db.SaveChanges();

                return Ok(preRegistro);
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
            return db.PreRegistro.Count(e => e.id == id) > 0;
        }
    }
}