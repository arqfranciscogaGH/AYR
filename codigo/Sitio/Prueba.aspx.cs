using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using  Sitio;
namespace Sitio
{
    public partial class Prueba : System.Web.UI.Page
    {
        private db_conexion db = new db_conexion();
        static int id = 0;
        static PreRegistro registro;
        static bool agregar = false;
        protected void Page_Load(object sender, EventArgs e)
        {

            String argumento = Request.QueryString["id"];
            db = new db_conexion();
            lblOperacion.Text = "";
            if (!IsPostBack)
            {
                if (argumento != null && argumento != String.Empty)
                {
                    agregar = false;
                    id = int.Parse(argumento);
                    registro = db.PreRegistro.Find(id);
                    limpiar();
                    asignar(id);
                }
                else
                {
                    agregar = true;
                    registro = new PreRegistro();
                    limpiar();
                }
            }
            if (agregar)
            {
                btnRegresar.Visible = false;
                btnLimpiar.Visible = true;
            }
            else
            {
                btnRegresar.Visible = true;
                btnLimpiar.Visible = false;
            }

        }


        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PreRegistros", false);
        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            btnRegistrar.Enabled = false;
            lblOperacion.Text = "";
            db = new db_conexion();

            registro.nombre = txtNombre.Text;
            if (txtEdad.Text != "")
            {
                registro.edad = int.Parse(txtEdad.Text);
                int anios = (registro.edad.Value * -1);
                registro.fechaNacimiento = DateTime.Now.AddYears(anios);
            }
            registro.genero = rblGenero.SelectedValue;

            if (!agregar)
            {
                registro.clase = txtGrupo.Text;
                registro.correo = txtCorreo.Text;
                registro.telefono = txtTelefono.Text;
                registro.estadoCivil = rblEstadoCivil.SelectedValue;
                registro.religion = txtReligion.Text;
                registro.tieneReligion = registro.religion.Length == 0 ? false : true;
                registro.congregacion = txtCongregacion.Text;
                registro.tieneCongregacion = registro.congregacion.Length == 0 ? false : true;
                registro.enfermedad = txtEnfermedad.Text;
                registro.tieneEnfermedad = registro.enfermedad.Length == 0 ? false : true;
                registro.tieneRetiroT = cvRetiro.Checked;

                if (cvEstatus.Checked == true)
                    registro.estatus = 1;
                else
                    registro.estatus = 0;

            }

            registro.invitador = txtInvitador.Text;

            string mensaje = String.Empty;
            if (agregar)
            {
                registro.estatus = 1;
                registro = db.PreRegistro.Add(registro);
                int r = db.SaveChanges();
                String folio = registro.id.ToString();
                mensaje = "Se agregó exitosamente el folio: " + folio;
            }
            else
            {
                db.Entry(registro).State = EntityState.Modified;
                int r = db.SaveChanges();
                String folio = registro.id.ToString();
                mensaje = "Se actualizó  exitosamenteel folio: " + folio;

            }
            if (agregar)
                limpiar();
            lblOperacion.Text = mensaje;
            string script = "alert('" + mensaje + " ');";

            //ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);

        }
        void limpiar()
        {
            btnRegistrar.Enabled = true;
            if (agregar)
            {
                txtGrupo.Visible = false;
                lblGrupo.Visible = false;
                txtTelefono.Visible = false;
                txtCorreo.Visible = false;
                txtEnfermedad.Visible = false;
                cvRetiro.Visible = false;
                rblEstadoCivil.Visible = false;
                txtReligion.Visible = false;
                txtCongregacion.Visible = false;
                cvEstatus.Visible = false;


                lblTelefono.Visible = false;
                lblCorreo.Visible = false;
                lblEnfermedad.Visible = false;
                lblRetiro.Visible = false;
                lblEstadoCivil.Visible = false;
                lblReligion.Visible = false;
                lblCongregacion.Visible = false;
                lblEstatus.Visible = false;

                // Inicializar  entidad
                registro = new PreRegistro();
                registro.estatus = 1;
                registro.estadoCivil = "";
                registro.edad = 0;
                registro.telefono = "";
                registro.correo = "";
                registro.enfermedad = "";
                registro.religion = "";
                registro.congregacion = "";
                registro.clase = "";

            }
            else
            {
                txtGrupo.Visible = true;
                lblGrupo.Visible = true;
                txtTelefono.Visible = true;
                lblCorreo.Visible = true;
                txtEnfermedad.Visible = true;
                cvRetiro.Visible = true;
                rblEstadoCivil.Visible = true;
                txtReligion.Visible = true;
                txtCongregacion.Visible = true;
                cvEstatus.Visible = true;

                lblTelefono.Visible = true;
                txtCorreo.Visible = true;
                lblEnfermedad.Visible = true;
                lblRetiro.Visible = true;
                lblEstadoCivil.Visible = true;
                lblReligion.Visible = true;
                lblCongregacion.Visible = true;
                lblEstatus.Visible = true;

            }

            txtGrupo.Text = "";
            txtNombre.Text = "";
            txtEdad.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            txtReligion.Text = "";
            txtCongregacion.Text = "";
            txtEnfermedad.Text = "";
            txtInvitador.Text = "";
            cvRetiro.Checked = false;
            cvEstatus.Checked = false;

        }
        void asignar(int id)
        {
            txtGrupo.Text = registro.clase;
            txtNombre.Text = registro.nombre;
            txtEdad.Text = registro.edad.ToString();
            rblGenero.SelectedValue = registro.genero;
            txtCorreo.Text = registro.correo;
            txtTelefono.Text = registro.telefono;

            rblEstadoCivil.SelectedValue = registro.estadoCivil;
            txtReligion.Text = registro.religion;
            txtCongregacion.Text = registro.congregacion;
            txtEnfermedad.Text = registro.enfermedad;
            cvRetiro.Checked = (bool)(registro.tieneRetiroT == null ? false : registro.tieneRetiroT);
            txtInvitador.Text = registro.invitador;
            cvEstatus.Checked = (bool)(registro.estatus == null || registro.estatus == 0 ? false : true);

        }
        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
    }
}