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
using Sitio.Comun.Clases;

namespace Sitio.Controllers
{
    public class ProductosController : ApiController
    {
        private db_conexion db = new db_conexion();



        // GET:   http://localhost:55377/api/Productos?id=1&se=otra&et=fga
        public IQueryable<Producto> GetEntidadPorArgumentos([FromUri] string id, [FromUri] string se, [FromUri] string et)
        {
            return db.Producto.Where(s => s.estatus == 1);
        }


        // GET: api/Productos
        public IQueryable<Producto> GetEntidad()
        {
            return db.Producto;
        }

        // GET: api/Productos/prueba
        [ResponseType(typeof(IQueryable<Producto>))]
        public IHttpActionResult GetEntidadPorLlave(String llave)
        {
            IQueryable<Producto> resultado = null;
            AutenticacionLlave autentificacion = new AutenticacionLlave();
            if (autentificacion.verificacion(llave))
                resultado = db.Producto.Where(s => s.estatus == 1);
            if (resultado == null)
            {
                return NotFound();
            }
            return Ok(resultado);
        }

        // GET: api/Productos/1/prueba
        [ResponseType(typeof(Producto))]
        public IHttpActionResult GetEntidadIdLlave(int id, String llave)
        {
            Producto resultado = null;
            AutenticacionLlave autentificacion = new AutenticacionLlave();
            if (autentificacion.verificacion(llave))
                resultado = db.Producto.Find(id);
            if (resultado == null)
               return NotFound();
            return Ok(resultado);
        }
        // GET: api/Productos/1/10/prueba
        [ResponseType(typeof(Paginador<Producto>))]
        public IHttpActionResult GetEntidadPorPagina(int pagina, int registrosPorPagina, String llave)
        {
            var _Paginador = new Paginador<Producto>();
            var _lista = db.Producto.Where(s => s.estatus == 1);
            AutenticacionLlave autentificacion = new AutenticacionLlave();
            if (autentificacion.verificacion(llave))
            {
                int _TotalRegistros = db.Producto.Count();
                pagina = pagina == 0 ? 1 : pagina;
                registrosPorPagina = registrosPorPagina == 0 ? _TotalRegistros : registrosPorPagina;
                var _TotalPaginas = (int)Math.Ceiling((double)_TotalRegistros / registrosPorPagina);
                // int final = pagina * registrosPorPagina;
                // int inicial = final - registrosPorPagina;
                // _lista = db.PreRegistro.Where(s => s.id > inicial && s.estatus == 1).Take(registrosPorPagina);
                _lista = _lista.OrderBy(s => s.id).Skip((pagina - 1) * registrosPorPagina)
                                                .Take(registrosPorPagina);
                _Paginador = new Paginador<Producto>()
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
        // GET: api/Productos/1/10/genero=M,clase=negro/amb
        [ResponseType(typeof(Paginador<Producto>))]
        public IHttpActionResult GetEntidadPorPaginaFiltro(int pagina, int registrosPorPagina, String filtro, String llave)
        {
            var _Paginador = new Paginador<Producto>();
            var _lista = db.Producto.Where(s => s.estatus == 1);
            AutenticacionLlave autentificacion = new AutenticacionLlave();
            if (autentificacion.verificacion(llave))
            {
                int _TotalRegistros = db.Producto.Count();
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
                            _lista = _lista.Where(s => s.clase.ToLower() == valor.ToLower());
                        if (campo.ToLower() == "clase")
                            _lista = _lista.Where(s => s.clase.ToLower() == valor.ToLower());
                        if (campo.ToLower() == "subclase")
                            _lista = _lista.Where(s => s.subclase.ToLower() == valor.ToLower());
                    }

                }
                // int final = pagina * registrosPorPagina;
                // int inicial = final - registrosPorPagina;
                //_lista = _lista.Where(s => s.id > inicial && s.estatus == 1).Take(registrosPorPagina);
                _lista = _lista.OrderBy(s => s.id).Skip((pagina - 1) * registrosPorPagina)
                                                .Take(registrosPorPagina);
                _Paginador = new Paginador<Producto>()
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


        // PUT: api/Productos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEntidad(int id, String llave, Producto producto)
        {
            AutenticacionLlave autentificacion = new AutenticacionLlave();
            if (autentificacion.verificacion(llave))
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != producto.id)
                {
                    return BadRequest();
                }

                db.Entry(producto).State = EntityState.Modified;

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

        // POST: api/Productos
        [ResponseType(typeof(Producto))]
        public IHttpActionResult PostEntidad(String llave, Producto entidad)
        {
            AutenticacionLlave autentificacion = new AutenticacionLlave();
            if (autentificacion.verificacion(llave))
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                db.Producto.Add(entidad);
                db.SaveChanges();
                return CreatedAtRoute("DefaultApi", new { id = entidad.id }, entidad);
            }
            else
                return NotFound();
        }

        // DELETE: api/Productos/5
        [ResponseType(typeof(Producto))]
        public IHttpActionResult DeleteEntidad(int id)
        {
            Producto entidad = db.Producto.Find(id);
            if (entidad == null)
            {
                return NotFound();
            }
            db.Producto.Remove(entidad);
            db.SaveChanges();
            return Ok(entidad);
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
            return db.Producto.Count(e => e.id == id) > 0;
        }
    }
}