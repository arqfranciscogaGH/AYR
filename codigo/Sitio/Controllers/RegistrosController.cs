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

namespace Sitio.Controllers
{
    public class RegistrosController : ApiController
    {
        private db_conexion db = new db_conexion();

        // GET: api/Registros
        public IQueryable<PreRegistro> GetPreRegistro()
        {

            return db.PreRegistro.Where(s => s.estatus == 1);
        }
        public IQueryable<PreRegistro> GetPreRegistroPorpagina(int pagina, int registros)
        {
            int final = pagina * registros;
            int inicial = final - registros;
            //return db.PreRegistro.Where(s => s.estatus == 1).Skip((pagina - 1) * registros).Take(registros); 
            return db.PreRegistro.Where(s => s.id> inicial  && s.estatus == 1).Take(registros);
        }
        public IQueryable<PreRegistro> GetPreRegistroPorpaginaFiltro(int pagina, int registros, String filtro)
        {
            int final = pagina * registros;
            int inicial = final - registros;
            //return db.PreRegistro.Where(s => s.estatus == 1).Skip((pagina - 1) * registros).Take(registros); 
            return db.PreRegistro.Where(s => s.id > inicial && s.estatus == 1).Take(registros);
        }

        // GET: api/Registros/5
        [ResponseType(typeof(PreRegistro))]
        public IHttpActionResult GetPreRegistro(int id)
        {
            PreRegistro preRegistro = db.PreRegistro.Find(id);
            if (preRegistro == null)
            {
                return NotFound();
            }

            return Ok(preRegistro);
        }

        // PUT: api/Registros/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPreRegistro(int id, PreRegistro preRegistro)
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
                if (!PreRegistroExists(id))
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

        // POST: api/Registros
        [ResponseType(typeof(PreRegistro))]
        public IHttpActionResult PostPreRegistro(PreRegistro preRegistro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PreRegistro.Add(preRegistro);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = preRegistro.id }, preRegistro);
        }

        // DELETE: api/Registros/5
        [ResponseType(typeof(PreRegistro))]
        public IHttpActionResult DeletePreRegistro(int id)
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PreRegistroExists(int id)
        {
            return db.PreRegistro.Count(e => e.id == id) > 0;
        }
    }
}