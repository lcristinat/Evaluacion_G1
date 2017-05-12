using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class wfEmpleadosAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    
        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                //validar Cedula
                Negocio.ValidarCedulaEmpleado dc = new Negocio.ValidarCedulaEmpleado();
                string cedula = dc.ValidaCedulaEmp(txtNumeroCedula.Text.Trim());

                if (cedula == "CEDULA VALIDA")
                {
                    Entidad.Empleados em = new Entidad.Empleados();
                    em.Nombre = txtNombre.Text.ToUpper().Trim();
                    em.Cedula = txtNumeroCedula.Text.ToUpper().Trim();
                    em.Direccion = txtDireccion.Text.ToUpper().Trim();
                    em.FechaProceso = DateTime.Now;
                    em.UsuarioProceso = int.Parse("1");
                    em.estado = int.Parse("1");

                    Negocio.EmpleadoNegocio emadd = new Negocio.EmpleadoNegocio();
                    if (emadd.CrearCedulaEmp(em) == "1")
                    {
                        lblMensaje.Visible = true;
                        lblMensaje.Text = "La cedula del empleado ya existe";
                    }
                    else
                    {
                        lblMensaje.Visible = true;
                        lblMensaje.Text = "Registro Guardado";
                      //  LimpiarControlesEmp(this.Controls);
                    }
                }
                else
                {
                    cvDatos.IsValid = false;
                    cvDatos.ErrorMessage = "Cédula invalida, por favor verificar";
                }

            }

            catch (Exception)
            {

                cvDatos.IsValid = false;
                cvDatos.ErrorMessage = "Ocurrio un error en la BD al guardar";
            }

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarControlesEmp(this.Controls);
        }

        protected void LimpiarControlesEmp(ControlCollection controles)
        {
            foreach (Control control in controles)
            {
                if (control is TextBox)
                    ((TextBox)control).Text = string.Empty;

                else if (control.HasControls())
                    //Esta linea detécta un Control que contenga otros Controles
                    //Así ningún control se quedará sin ser limpiado.
                    LimpiarControlesEmp(control.Controls);
                           lblMensaje.Visible = false;
            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControlesEmp(this.Controls);
        }
    }
}