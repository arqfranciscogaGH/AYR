//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Producto
    {
        public int id { get; set; }
        public string clave { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string clase { get; set; }
        public string subclase { get; set; }
        public Nullable<double> precio { get; set; }
        public Nullable<int> existencia { get; set; }
        public Nullable<System.DateTime> fechaEstatus { get; set; }
        public Nullable<short> estatus { get; set; }
    }
}
