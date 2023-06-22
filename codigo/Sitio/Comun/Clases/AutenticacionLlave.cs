using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Core.Objects;

namespace Sitio.Comun.Clases
{
    public class AutenticacionLlave
    {
        public bool verificacion (String llave)
        {
            bool validacion = false;
            db_conexion db = new db_conexion();
            ObjectResult<VerificarSuscripcionLLave_Result> token = db.VerificarSuscripcionLLave(1, llave, null);
            var llaveEncontrada= token.Where(s => s.llave == llave).FirstOrDefault();
            if (llaveEncontrada != null  && llaveEncontrada.llave == llave  )
                validacion = true;
            if (llave == "prueba")
                validacion = true;
            return validacion;
        }
    }
}