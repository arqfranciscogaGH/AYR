using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sitio;
using Sitio.Comun.Clases;

namespace Sitio.Controllers
{
    public class PreRegistrosController : Controller
    {
        private db_conexion db = new db_conexion();
        static List<Columna> columnas = new  List<Columna>();
        static Columna columnaActual ;
        public JsonResult Buscar(string query)
        {
            IQueryable<PreRegistro> preRegistros = db.PreRegistro.Where(s => s.estatus == 1);
            List<string> nombres;
            nombres = preRegistros.Where(x => x.nombre.StartsWith(query.ToLower())).Select(x => x.nombre).ToList();
            return Json(nombres, JsonRequestBehavior.AllowGet);
        }

        // GET: PreRegistros
        //public ActionResult Index()
        //{
        //    return View(db.PreRegistro.Where(s=>s.estatus==1).ToList());
        //}
        //[HttpPost]
        public ActionResult Index(String invitador, String grupo,  String filtro, String columanOrden,  int pagina = 1)
        {
            // Número total de registros de la tabla Customers
            int _RegistrosPorPagina = 10;
            int _TotalRegistros = 0;
            //
            // seleccionar  ordernar por columna y se define  y guarda la  columna
            //
   
            if (!string.IsNullOrEmpty(columanOrden))
            {
                Columna columna;
                ViewBag.columanOrden = columanOrden;
                columna = columnas.Where(s => s.Nombre.Contains(columanOrden)).FirstOrDefault();
                if (columna == null)
                {
                    columna = new Columna { Nombre = columanOrden, Orden = "Asc" };
                    columnas.Add(columna);
                }
                else
                {
                    if (columna.Orden == "Asc")
                        columna.Orden = "Desc";
                    else
                        columna.Orden = "Asc";
                }
                columnaActual = columna;
            }
       

  
            //
            // obtene  info de  listas 
            //
            // obtener lista de  personal que invita
            var _listaInvitador = new List<string>();

            var consulta_Invitador = from d in db.PreRegistro
                           where  d.estatus==1
                           orderby d.invitador
                           select d.invitador;
            //var x = db.PreRegistro.Select(r => r.invitador).Distinct();

          
            _listaInvitador.AddRange(consulta_Invitador.Distinct());
            ViewBag.invitador = new SelectList(_listaInvitador);





            // obtener lista de  personal que invita
            var _listaGrupo = new List<string>();

            var consulta_Grupo = from d in db.PreRegistro
                                     where d.estatus == 1
                                     orderby d.clase
                                     select d.clase;
            //var x = db.PreRegistro.Select(r => r.invitador).Distinct();


            _listaGrupo.AddRange(consulta_Grupo.Distinct());
            ViewBag.grupo = new SelectList(_listaGrupo);






            //   filtrar  de registros
            //  obtener pregistros


            IQueryable<PreRegistro> preRegistros = db.PreRegistro.Where(s => s.estatus == 1);
            _TotalRegistros = preRegistros.Count();
            if (!String.IsNullOrEmpty(filtro))
            {
                preRegistros = preRegistros.Where(s => s.estatus == 1 && s.nombre.Contains(filtro));
            }
            if (!string.IsNullOrEmpty(invitador))
            {
                preRegistros = preRegistros.Where(s => s.invitador.Contains(invitador));
            }
            if (!string.IsNullOrEmpty(grupo))
            {
                preRegistros = preRegistros.Where(s => s.clase.Contains(grupo));
            }


  


            //  orden de  columnas 
            if (columnaActual != null)
            {
                if (columnaActual.Nombre == "id")
                {
                    if (columnaActual.Orden == "Asc")
                        preRegistros = preRegistros.OrderBy(s => s.id).Skip((pagina - 1) * _RegistrosPorPagina)
                                             .Take(_RegistrosPorPagina);
                    else
                        preRegistros = preRegistros.OrderByDescending(s => s.id).Skip((pagina - 1) * _RegistrosPorPagina)
                                             .Take(_RegistrosPorPagina);
                }
                if (columnaActual.Nombre == "nombre")
                {
                    if (columnaActual.Orden == "Asc")
                        preRegistros = preRegistros.OrderBy(s => s.nombre).Skip((pagina - 1) * _RegistrosPorPagina)
                                             .Take(_RegistrosPorPagina);
                    else
                        preRegistros = preRegistros.OrderByDescending(s => s.nombre).Skip((pagina - 1) * _RegistrosPorPagina)
                                             .Take(_RegistrosPorPagina);
                }
                if (columnaActual.Nombre == "genero")
                {
                    if (columnaActual.Orden == "Asc")
                        preRegistros = preRegistros.OrderBy(s => s.genero).Skip((pagina - 1) * _RegistrosPorPagina)
                                             .Take(_RegistrosPorPagina); 
                    else
                        preRegistros = preRegistros.OrderByDescending(s => s.genero).Skip((pagina - 1) * _RegistrosPorPagina)
                                             .Take(_RegistrosPorPagina);
                }
                if (columnaActual.Nombre == "edad")
                {
                    if (columnaActual.Orden == "Asc")
                        preRegistros = preRegistros.OrderBy(s => s.edad).Skip((pagina - 1) * _RegistrosPorPagina)
                                             .Take(_RegistrosPorPagina);
                    else
                        preRegistros = preRegistros.OrderByDescending(s => s.edad).Skip((pagina - 1) * _RegistrosPorPagina)
                                             .Take(_RegistrosPorPagina);
                }
                if (columnaActual.Nombre == "grupo")
                {
                    if (columnaActual.Orden == "Asc")
                        preRegistros = preRegistros.OrderBy(s => s.clase).Skip((pagina - 1) * _RegistrosPorPagina)
                                             .Take(_RegistrosPorPagina); 
                    else
                        preRegistros = preRegistros.OrderByDescending(s => s.clase).Skip((pagina - 1) * _RegistrosPorPagina)
                                             .Take(_RegistrosPorPagina); 
                }

            }
            else
            {
                //  paginación 

                // Obtenemos la 'página de registros' de la tabla Customers
                preRegistros = preRegistros.OrderBy(s => s.id).Skip((pagina - 1) * _RegistrosPorPagina)
                                                 .Take(_RegistrosPorPagina);
            }


            // Número total de páginas de la tabla Customers
            var _TotalPaginas = (int)Math.Ceiling((double)_TotalRegistros / _RegistrosPorPagina);
            // Instanciamos la 'Clase de paginación' y asignamos los nuevos valores
            var _Paginador = new Paginador<PreRegistro>()
            {
                RegistrosPorPagina = _RegistrosPorPagina,
                TotalRegistros = _TotalRegistros,
                TotalPaginas = _TotalPaginas,
                PaginaActual = pagina,
                Resultado = preRegistros
            };
            // Enviamos a la Vista la 'Clase de paginación'
            return View(_Paginador);
            //return View(db.PreRegistro.Where(s => s.estatus == 1).ToList());
            }
        // GET: PreRegistros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreRegistro preRegistro = db.PreRegistro.Find(id);
            if (preRegistro == null)
            {
                return HttpNotFound();
            }
            return View(preRegistro);
        }

        // GET: PreRegistros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PreRegistros/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,genero,edad,fechaNacimiento,estadoCivil,telefono,correo,tieneReligion,religion,tieneCongregacion,congregacion,tieneEnfermedad,enfermedad,tieneRetiroT,invitador,descripcion,info,notas,idSuscriptor,estatus")] PreRegistro preRegistro)
        {
            if (ModelState.IsValid)
            {
                db.PreRegistro.Add(preRegistro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(preRegistro);
        }

        // GET: PreRegistros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreRegistro preRegistro = db.PreRegistro.Find(id);
            if (preRegistro == null)
            {
                return HttpNotFound();
            }
            return View(preRegistro);
        }

        // POST: PreRegistros/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,genero,edad,fechaNacimiento,estadoCivil,telefono,correo,tieneReligion,religion,tieneCongregacion,congregacion,tieneEnfermedad,enfermedad,tieneRetiroT,invitador,descripcion,info,notas,idSuscriptor,estatus")] PreRegistro preRegistro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(preRegistro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(preRegistro);
        }

        // GET: PreRegistros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreRegistro preRegistro = db.PreRegistro.Find(id);
            if (preRegistro == null)
            {
                return HttpNotFound();
            }
            return View(preRegistro);
        }

        // POST: PreRegistros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PreRegistro preRegistro = db.PreRegistro.Find(id);
            db.PreRegistro.Remove(preRegistro);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
