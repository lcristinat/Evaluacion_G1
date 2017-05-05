using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class wfProductoEliminar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnConfirmar.Visible = false;
        }

        /*protected void btnBuscar_Click(object sender, EventArgs e)
        {

           
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {

            
        }*/

        public void limpiarFormulario()
        {

            txtCodigoProducto.Text = string.Empty;
            lblDescripcion.Text = string.Empty;

        } // fin del método limpiarFormulario

        protected void txtCodigoProducto_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnConfirmar_Click1(object sender, EventArgs e)
        {

            Negocio.productoNegocio dc = null;

            try
            {

                dc = new Negocio.productoNegocio();

                dc.eliminarProductoNegocio(int.Parse(txtCodigoProducto.Text));
                                
                limpiarFormulario();

                lblResultado.InnerText = "Se eliminó correctamente el producto de la base de datos.";

            }
            catch (Exception)
            {

                cvErrores.IsValid = false;
                cvErrores.ErrorMessage = "Ocurrió un error al eliminar el producto.";

            } // fin del try


        } // fin del btnConfirmar

        protected void btnBuscar_Click1(object sender, EventArgs e)
        {
            Negocio.productoNegocio dc = null;
            Entidad.Productos producto = null;

            try
            {

                dc = new Negocio.productoNegocio();
                producto = dc.obtenerProductoNegocio(int.Parse(txtCodigoProducto.Text));

                lblDescripcion.Text = producto.Descripcion;

                btnConfirmar.Visible = true;

            }
            catch (Exception)
            {

                cvErrores.IsValid = false;
                cvErrores.ErrorMessage = "No se encontró el producto buscado. Por favor verifique la información.";

            }// fin del try

        } // fin del btnBuscar

        protected void btnCancelar_Click1(object sender, EventArgs e)
        {
            limpiarFormulario();

        }
    } // fin de la clase wfProductoEliminar

}