using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class wfAgregarCliente : System.Web.UI.Page
    {

        #region Metdos Privados del Formulario
        /// <summary>
        /// Metodo para limpiar las cajas de texto del aspx
        /// </summary>
        protected void LimpiarFormulario(ControlCollection controles)
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
                    LimpiarFormulario(control.Controls);
            }
        }

        /// <summary>
        /// Metodo para insertar un cliente
        /// </summary>
        protected void InsertarCliente()
        {
            Negocio.ClienteNegocio dc = new Negocio.ClienteNegocio();
      
            string validaCedula;
            try
            {
                validaCedula = dc.ValidarCedula(txtNumeroCedula.Text.Trim());
                if (validaCedula == "1")
                {
                    if (!ValidarExisteCedula(txtNumeroCedula.Text.ToUpper().Trim()))
                    {
                        Entidad.Clientes c = new Entidad.Clientes();
                        c.Nombre = txtNombre.Text.ToUpper().Trim();
                        c.Direccion = txtDireccion.Text.ToUpper().Trim();
                        c.Cedula = txtNumeroCedula.Text.ToUpper().Trim();

                        dc.InsertarCliente(c);
                        lblMensaje.Visible = true;
                        lblMensaje.Text = "EL REGISTRO HA SIDO GUARDADO";
                    }
                    else
                    {
                        cvDatos.IsValid = false;
                        cvDatos.ErrorMessage = "EL NUMERO DE CEDULA YA EXISTE";
                    }

                }
                else
                {
                    cvDatos.IsValid = false;
                    cvDatos.ErrorMessage = "WEB SERVICE: EL NUMERO DE CEDULA ES INVALIDO " ;
                }

            }
            catch (Exception err)
            {

                cvDatos.IsValid = false;
                cvDatos.ErrorMessage = "ERROR A GUARDAR LOS DATOS" + lblMensaje.Text+err;
            }
        }

        protected bool ValidarExisteCedula(string cedulaCliente) //List<Entidad.Clientes> detalleClientes
        {

            Negocio.ClienteNegocio dc = new Negocio.ClienteNegocio();
            List<Entidad.Clientes> detalleClientes = dc.ListaClientes();
            return detalleClientes.Any(det => det.Cedula == cedulaCliente);
        }

        #endregion

        #region Eventos de Objetos
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario(this.Controls);
            lblMensaje.Visible = false;
            
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            
            InsertarCliente();
        }
        #endregion

    }
}