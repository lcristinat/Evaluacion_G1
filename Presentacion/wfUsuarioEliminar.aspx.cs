using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class wfUsuarioEliminar : System.Web.UI.Page
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
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            int CodUsuario;
            Negocio.UsuarioNegocio dc = new Negocio.UsuarioNegocio();

            try
            {
                if (txtCodigo.Text.Trim() == "")
                {
                    CV_Datos.IsValid = false;
                    CV_Datos.ErrorMessage = "ERROR Dato no puede ser nulo";
                    btnGuardar.Enabled = false;
                }
                else
                {
                    CodUsuario = int.Parse(txtCodigo.Text.Trim());
                    Entidad.Usuarios c = dc.ObtenerUsuario(CodUsuario);
                    txtCodigo.Text = c.Usuarios1.ToString();
                    txtNombre.Text = c.Nombre;
                    txtCodigo.ReadOnly = true;
                    btnGuardar.Enabled = true;
                }
            }
            catch (Exception)
            {

                CV_Datos.IsValid = false;
                CV_Datos.ErrorMessage = "ERROR registro no Existe" ;
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Negocio.UsuarioNegocio dc = new Negocio.UsuarioNegocio();
            try
            {
                Entidad.Usuarios c = new Entidad.Usuarios();
                c.Usuarios1 = int.Parse(txtCodigo.Text);
                c.Nombre = txtNombre.Text.ToUpper().Trim();
                dc.EliminarUsuario(c);
                lblMensaje.Visible = true;
                lblMensaje.Text = "Registro Eliminado Correctamente";
                txtCodigo.ReadOnly = false;
                Limpiar_Controles(this.Controls);
                
            }
            catch (Exception err)
            {

                CV_Datos.IsValid = false;
                CV_Datos.ErrorMessage = "ERROR al Eliminar el registro" + err.Message;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
        
    }
}