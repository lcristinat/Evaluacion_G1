using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class wfEmpleadoEdit : System.Web.UI.Page
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
                    Entidad.Empleados upemp = new Entidad.Empleados();
                    upemp.Id = int.Parse(txtCodigoEmpleado.Text);
                    upemp.Nombre = txtNombre.Text.ToUpper().Trim();
                    upemp.Cedula = txtNumeroCedula.Text.ToUpper().Trim();
                    upemp.Direccion = txtDireccion.Text.ToUpper().Trim();
                    upemp.Estado = 1;
                    Negocio.EmpleadoNegocio dcemp = new Negocio.EmpleadoNegocio();
                    if (dcemp.ActualizarEmpleado(upemp) > 0)
                    {
                        lblMensaje.Visible = true;
                        lblMensaje.Text = "Registro actualizado";
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
                cvDatos.ErrorMessage = "El registro no pudo ser actualizado en la BD";
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarControlesEmp(this.Controls);
          //  txtCodigoEmpleado.Enabled = true;

        }

        protected void txtCodigoEmpleado_TextChanged(object sender, EventArgs e)
        {
            
               int codempleado;
               try
               {
            //        if (txtCodigoEmpleado.Text.Trim()!="")
            //        {
            //            if (char.IsNumber(char.Parse(txtCodigoEmpleado.Text.Trim())))
            //            {
                          codempleado = int.Parse(txtCodigoEmpleado.Text);
                            ObtenerEmpleado(codempleado);
                           // txtCodigoEmpleado.Text = string.Empty;
                    //    }
                    //    else
                    //    {
                    //        cvDatos.IsValid = false;
                    //        cvDatos.ErrorMessage = "Solo se permiten numeros";
                    //        txtCodigoEmpleado.Text = string.Empty;
                    //        txtNombre.Text = string.Empty;
                    //        txtNumeroCedula.Text = string.Empty;
                    //        txtDireccion.Text = string.Empty;
                          
                    //    }
                    //}

                }
                catch (Exception err)
                {

                    cvDatos.IsValid = false;
                cvDatos.ErrorMessage = "Error al cargar los Datos Empleados"+err;
                }
            }
        

        protected void ObtenerEmpleado(int codEmp)
        {
            Negocio.EmpleadoNegocio dc = new Negocio.EmpleadoNegocio();

            try
            {
                Entidad.Empleados e = dc.ConsultarEmpleado(codEmp);
                txtCodigoEmpleado.Text = e.Id.ToString();
                txtNombre.Text = e.Nombre;
                txtNumeroCedula.Text = e.Cedula;
                txtDireccion.Text = e.Direccion;
                txtCodigoEmpleado.ReadOnly = true;
               
              }
            catch (Exception err)
            {

                cvDatos.IsValid = false;
                cvDatos.ErrorMessage = "Empleado no existe en la Base de Datos"+err;
            }
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
                       txtCodigoEmpleado.ReadOnly = false;
                    lblMensaje.Visible = false;
                }

            }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControlesEmp(this.Controls);
        }
    }
}
   
