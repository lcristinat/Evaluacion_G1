using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class wfUsuarioInsertar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Limpiar()
        {
            txtNombre.Text = "";
            txtNumeroCedula.Text = "";
            txtLogin.Text = "";
            txtClave.Text = "";
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                String cadena_cedula = txtNumeroCedula.Text.Trim().ToUpper();
                cadena_cedula = cadena_cedula.Replace("-", "");
                string NCedula;
                
                Negocio.web_Services_Negocio dc_s = new Negocio.web_Services_Negocio();
                NCedula = dc_s.ValidaCedula(cadena_cedula);
                if (NCedula == "1")
                {
                    Negocio.UsuarioNegocio dc = new Negocio.UsuarioNegocio();
                    Entidad.Usuarios u = new Entidad.Usuarios();
                    u.Nombre = txtNombre.Text.Trim().ToUpper();
                    u.Login = txtLogin.Text.Trim().ToUpper();
                    u.Clave = txtClave.Text.Trim();
                    u.Cedula = cadena_cedula.ToUpper();
                    u.FechaProceso = DateTime.Now;
                    u.Estado = 1;
                    dc.Agregar(u);
                    lblMensaje.Text = "Usuario Creado con Éxito";
                    Limpiar();
                }
                else
                {
                    lblMensaje.Text = "Usuario no puede Crearse porque cèdula no es correcta";
                }
                
            }
            catch (Exception err)
            {
                CV_Datos.IsValid = false;
                CV_Datos.ErrorMessage = "Error al registrar los datos" + err;
            }
        }

      
    }
}