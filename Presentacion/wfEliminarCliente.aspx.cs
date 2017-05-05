using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class wfEliminarCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ObtenerCliente(int pIdCliente)
        {
            Negocio.ClienteNegocio dc = new Negocio.ClienteNegocio();

            try
            {
                Entidad.Clientes c = dc.ObtenerCliente(pIdCliente);
                txtIdCliente.Text = c.Id.ToString();
                txtNombre.Text = c.Nombre;
                //btnEliminar.Visible = true;

            }
            catch (Exception)
            {

                throw;
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
                    }
                }

                
                else
                {
                    //lblMensaje.Text = "Solo se permiten numeros";
                }
            }
            catch (Exception err)
            {

                cvDatos.IsValid = false;
                cvDatos.ErrorMessage = "ERROR AL CARGAR DATOS" + err.Message;
            }
           
            
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

            Negocio.ClienteNegocio dc = new Negocio.ClienteNegocio();

            try
            {
                Entidad.Clientes c = dc.ObtenerCliente(int.Parse(txtIdCliente.Text));
               
                if (txtIdCliente.Text != "")
                {
                    dc.EliminarCliente(c);
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "EL REGISTRO SE HA INACTIVADO";
                }
                
            }
            catch (Exception err)
            {

                cvDatos.IsValid = false;
                cvDatos.ErrorMessage = "ERROR AL ELIMINAR REGISTRO" + err.Message;
            }
        }
    }
}