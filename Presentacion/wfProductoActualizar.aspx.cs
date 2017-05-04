using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class wfProductoActualizar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            btnConfirmar.Visible = false;

        }

        /*protected void btnConfirmar_Click(object sender, EventArgs e)
        {

          

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

           

        }*/

        public void limpiarFormulario()
        {

            txtCodigoProducto.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtExistencia.Text = string.Empty;
            txtPrecioUnitario.Text = string.Empty;
            btnConfirmar.Visible = false;
            lblResultado.InnerText = string.Empty;


        } // fin del método limpiarFormulario

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

            

        }

        protected void btnConfirmar_Click1(object sender, EventArgs e)
        {

            Negocio.productoNegocio dc = null;
            Entidad.Productos producto = null;

            try
            {

                // Actualizamos la información del producto

                dc = new Negocio.productoNegocio();
                producto = new Entidad.Productos();

                producto.Descripcion = txtDescripcion.Text.Trim().ToUpper();
                producto.Existencia = int.Parse(txtExistencia.Text);
                producto.PrecioUnitario = decimal.Parse(txtPrecioUnitario.Text);
                producto.Id = int.Parse(txtCodigoProducto.Text);
                producto.FechaProceso = DateTime.Now;

                dc.modificarProductoNegocio(producto);

                // Limpiamos el formulario

                limpiarFormulario();

                lblResultado.InnerText = "La información se actualizó exitosamente.";

            }
            catch (Exception)
            {

                cvErrores.IsValid = false;
                cvErrores.ErrorMessage = "Ocurrió un error al intentar actualizar la información. Por favor verifique.";

            } // fin del try

        } // fin del btnConfirmar

        protected void btnBuscar_Click1(object sender, EventArgs e)
        {

            Negocio.productoNegocio dc = null;
            Entidad.Productos producto = null;

            try
            {

                // Se recupera la información del producto con base en
                // el id del mismo

                dc = new Negocio.productoNegocio();
                producto = dc.obtenerProductoNegocio(int.Parse(txtCodigoProducto.Text));

                txtDescripcion.Text = producto.Descripcion.Trim().ToUpper();
                txtExistencia.Text = producto.Existencia.ToString();
                txtPrecioUnitario.Text = producto.PrecioUnitario.ToString();

                btnConfirmar.Visible = true;

            }
            catch (Exception)
            {

                cvErrores.IsValid = false;
                cvErrores.ErrorMessage = "Ocurrió un error al recuperar los datos. Por favor verifique.";

            } // fin del try

        } // fin del btnBuscar

        protected void btnCancelar_Click1(object sender, EventArgs e)
        {

            limpiarFormulario();

        }
    } // fin de la clase wfProductoActualizar

}