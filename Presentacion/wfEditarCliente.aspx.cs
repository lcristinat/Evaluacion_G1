using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class wfEditarCliente : System.Web.UI.Page
    {

        #region METODOS PRIVADOS 
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
                    txtIdCliente.ReadOnly = false;
                    lblMensaje.Visible = false;
            }
        }

        /// <summary>
        /// Metodo para obtener el Id de un cliente
        /// </summary>
        /// <param name="pIdCliente"></param>
        protected void ObtenerCliente(int pIdCliente)
        {
            Negocio.ClienteNegocio dc = new Negocio.ClienteNegocio();

            try
            {
                Entidad.Clientes c = dc.ObtenerCliente(pIdCliente);
                txtIdCliente.Text = c.Id.ToString();
                txtNombre.Text = c.Nombre;
                txtNumeroCedula.Text = c.Cedula;
                txtDireccion.Text = c.Direccion;
                txtIdCliente.ReadOnly = true;

            }
            catch (Exception err)
            {

                cvDatos.IsValid = false;
                cvDatos.ErrorMessage = "ERROR AL CARGAR EL REGISTRO" + err.Message;
            }
        }



        #endregion
        #region EVENTOS DE LOS OBJETOS
       

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            Negocio.ClienteNegocio dc = new Negocio.ClienteNegocio();
           
            string validaCedula;
            try
            {
                
                validaCedula = dc.ValidarCedula(txtNumeroCedula.Text.Trim());
                if (validaCedula == "1")
                {

                    Entidad.Clientes c = new Entidad.Clientes();
                    c.Id = int.Parse(txtIdCliente.Text);
                    c.Nombre = txtNombre.Text.ToUpper().Trim();
                    c.Direccion = txtDireccion.Text.ToUpper().Trim();
                    c.Cedula = txtNumeroCedula.Text.ToUpper().Trim();
                    dc.ModificarCliente(c);
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "EL REGISTRO HA SIDO ACTUALIZADO";
                    
                }
                else
                {
                    cvDatos.IsValid = false;
                    cvDatos.ErrorMessage = "EL NUMERO DE CEDULA ES INVALIDO";
                }

            }
            catch (Exception err)
            {

                cvDatos.IsValid = false;
                cvDatos.ErrorMessage = "ERROR AL ACTUALIZAR EL REGISTRO" + err.Message;
            }
        }

        protected void txtIdCliente_TextChanged(object sender, EventArgs e)
        {
            int idCliente;
            try
            {
                if (txtIdCliente.Text.Trim() != "")
                {
                    if (char.IsNumber(char.Parse(txtIdCliente.Text.Trim())))
                    {
                        idCliente = int.Parse(txtIdCliente.Text);
                        ObtenerCliente(idCliente);
                    }
                    else
                    {
                        cvDatos.IsValid = false;
                        cvDatos.ErrorMessage = "SOLO SE PERMITEN NUMEROS";
                        txtIdCliente.Text = string.Empty;
                        txtNombre.Text = string.Empty;
                        txtDireccion.Text = string.Empty;
                        txtNumeroCedula.Text = string.Empty;
                    }
                }


                else
                {

                }
            }
            catch (Exception err)
            {

                cvDatos.IsValid = false;
                cvDatos.ErrorMessage = "ERROR AL CARGAR DATOS" + err.Message;
            }

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario(this.Controls);
   
        }

        #endregion

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}