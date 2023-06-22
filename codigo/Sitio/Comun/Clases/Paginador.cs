using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitio.Comun.Clases
{

    public class Paginador<T> where T : class
    {
        public int paginaActual { get; set; }
        public int registrosPorPagina { get; set; }
        public int totalRegistros { get; set; }
        public int totalPaginas { get; set; }
        public IEnumerable<T> resultado { get; set; }
    }
}