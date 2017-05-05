using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class wfProductoInsertar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /*protected void btnConfirmar_Click(object sender, EventArgs e)
        {

           
        }*/

        public void limpiarFormulario()
        {

            txtDescripcion.Text = string.Empty;
            txtExistencia.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            
        } // fin del método limpiarFormulario

        /*protected void btnCancelar_Click(object sender, EventArgs e)
        {

            

        }*/

        protected void btnConfirmar_Click1(object sender, EventArgs e)
        {

            Negocio.productoNegocio dc = null;
            Entidad.Productos producto = null;

            try
            {

                dc = new Negocio.productoNegocio();
                producto = new Entidad.Productos();

                producto.Descripcion = txtDescripcion.Text.ToUpper().Trim();
                producto.Existencia = int.Parse(txtExistencia.Text);
                producto.PrecioUnitario = decimal.Parse(txtPrecio.Text);
                producto.FechaProceso = DateTime.Now;
                producto.Estado = 1;
                producto.UsuarioProceso = 1;

                dc.insertarProductoNegocio(producto);

                lblResultado.InnerText = "La información se guardó correctamente.";
                
                limpiarFormulario();

            }
            catch (Exception)
            {

                cvErrores.IsValid = false;
                cvErrores.ErrorMessage = "Ocurrió un error al guardar. Por favor revise la información.";

            } // fin del try

        } // fin del btnBuscar

        protected void btnCancelar_Click1(object sender, EventArgs e)
        {

            lblResultado.InnerText = string.Empty;
            limpiarFormulario();
            
        } // fin del btnCancelar

    } // clase wfProductoInsertar

}