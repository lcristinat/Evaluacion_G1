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
        protected void Limpiar_Controles(ControlCollection controles)
        {
            foreach (Control control in controles)
            {
                if (control is TextBox)
                    ((TextBox)control).Text = string.Empty;
                else if (control is DropDownList)
                    ((DropDownList)control).ClearSelection();
                else if (control is RadioButtonList)
                    ((RadioButtonList)control).ClearSelection();
                else if (control is CheckBoxList)
                    ((CheckBoxList)control).ClearSelection();
                else if (control is RadioButton)
                    ((RadioButton)control).Checked = false;
                else if (control is CheckBox)
                    ((CheckBox)control).Checked = false;
                else if (control.HasControls())
                    //Esta linea detécta un Control que contenga otros Controles
                    //Así ningún control se quedará sin ser limpiado.
                    Limpiar_Controles(control.Controls);
             }
        }
        protected bool  ValidarCedula(string CodCedula)
        {
            Negocio.UsuarioNegocio dc = new Negocio.UsuarioNegocio();
            List<Entidad.Usuarios> ced = dc.ListaUsuario();
            return ced.Any(a => a.Cedula == CodCedula);
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
                    Entidad.Usuarios c = dc.ObtenerCedula(cadena_cedula);
                    if (!ValidarCedula(cadena_cedula))
                    {
                      
                        Entidad.Usuarios u = new Entidad.Usuarios();
                        u.Nombre = txtNombre.Text.Trim().ToUpper();
                        u.Login = txtLogin.Text.Trim().ToUpper();
                        u.Clave = txtClave.Text.Trim();
                        u.Cedula = cadena_cedula.ToUpper();
                        u.FechaProceso = DateTime.Now;
                        u.Estado = 1;
                        dc.Agregar(u);
                        lblMensaje.Text = "Usuario Creado con Éxito";
                        Limpiar_Controles(this.Controls);
                        
                    }
                    else
                    {
                        lblMensaje.Text = "Usuarios no pueden crearse con un mismo nùmero de cèdula, operaciòn cancelada";
                        Limpiar_Controles(this.Controls);
                        btnGuardar.Enabled = false;
                    }
                   
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

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}