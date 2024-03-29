﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sitio
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class db_conexion : DbContext
    {
        public db_conexion()
            : base("name=db_conexion")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<PreRegistro> PreRegistro { get; set; }
        public virtual DbSet<CuentaUsuario> CuentaUsuario { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Suscripcion> Suscripcion { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
    
        public virtual ObjectResult<PaginarPreRegistro_Result> PaginarPreRegistro(Nullable<int> pagenum, Nullable<int> pagesize)
        {
            var pagenumParameter = pagenum.HasValue ?
                new ObjectParameter("pagenum", pagenum) :
                new ObjectParameter("pagenum", typeof(int));
    
            var pagesizeParameter = pagesize.HasValue ?
                new ObjectParameter("pagesize", pagesize) :
                new ObjectParameter("pagesize", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PaginarPreRegistro_Result>("PaginarPreRegistro", pagenumParameter, pagesizeParameter);
        }
    
        public virtual ObjectResult<RegistrarSuscripcionLLave_Result> RegistrarSuscripcionLLave(Nullable<int> idSuscriptor, string cuenta, string servicio, string estacionTrabajo)
        {
            var idSuscriptorParameter = idSuscriptor.HasValue ?
                new ObjectParameter("idSuscriptor", idSuscriptor) :
                new ObjectParameter("idSuscriptor", typeof(int));
    
            var cuentaParameter = cuenta != null ?
                new ObjectParameter("cuenta", cuenta) :
                new ObjectParameter("cuenta", typeof(string));
    
            var servicioParameter = servicio != null ?
                new ObjectParameter("servicio", servicio) :
                new ObjectParameter("servicio", typeof(string));
    
            var estacionTrabajoParameter = estacionTrabajo != null ?
                new ObjectParameter("estacionTrabajo", estacionTrabajo) :
                new ObjectParameter("estacionTrabajo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RegistrarSuscripcionLLave_Result>("RegistrarSuscripcionLLave", idSuscriptorParameter, cuentaParameter, servicioParameter, estacionTrabajoParameter);
        }
    
        public virtual ObjectResult<VerificarSuscripcionLLave_Result> VerificarSuscripcionLLave(Nullable<int> idSuscriptor, string llave, byte[] llaveE)
        {
            var idSuscriptorParameter = idSuscriptor.HasValue ?
                new ObjectParameter("idSuscriptor", idSuscriptor) :
                new ObjectParameter("idSuscriptor", typeof(int));
    
            var llaveParameter = llave != null ?
                new ObjectParameter("llave", llave) :
                new ObjectParameter("llave", typeof(string));
    
            var llaveEParameter = llaveE != null ?
                new ObjectParameter("llaveE", llaveE) :
                new ObjectParameter("llaveE", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<VerificarSuscripcionLLave_Result>("VerificarSuscripcionLLave", idSuscriptorParameter, llaveParameter, llaveEParameter);
        }
    }
}
