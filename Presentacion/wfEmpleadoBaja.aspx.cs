using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class wfEmpleadoBaja : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Entidad.Empleados upbajaemp = new Entidad.Empleados();
                upbajaemp.Id = int.Parse(txtCodigoEmpleado.Text);
                upbajaemp.Nombre = txtNombre.Text.ToUpper().Trim();
                upbajaemp.Estado = 2;
                Negocio.EmpleadoNegocio dc = new Negocio.EmpleadoNegocio();
                if (upbajaemp!= null)
                  {
                    dc.ActualizarBajaemp(upbajaemp);
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "Registro actualizado";
                     }
             }
           
 
            catch (Exception)
            {

                cvDatos.IsValid = false;
                cvDatos.ErrorMessage = "El registro no pudo ser actualizado en la BD";
            }
        }

        protected void txtCodigoEmpleado_TextChanged(object sender, EventArgs e)
        {
            
                int codempleado;
                try
                {
                    //if (txtCodigoEmpleado.Text.Trim() != "")
                    //{
                    //    if (char.IsNumber(char.Parse(txtCodigoEmpleado.Text.Trim())))
                    //    {
                            codempleado = int.Parse(txtCodigoEmpleado.Text);
                            ObtenerEmpleado(codempleado);
                            // txtCodigoEmpleado.Text = string.Empty;
                //        }
                //        else
                //        {
                //            cvDatos.IsValid = false;
                //            cvDatos.ErrorMessage = "Solo se permiten numeros";
                //            txtCodigoEmpleado.Text = string.Empty;
                //            txtNombre.Text = string.Empty;
                           
                //        }
                //    }

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
                //    txtCodigoEmpleado.Text = e.Id.ToString();
                txtNombre.Text = e.Nombre;
                txtCodigoEmpleado.ReadOnly = true;

            }
            catch (Exception err)
            {

                cvDatos.IsValid = false;
                cvDatos.ErrorMessage = "Empleado no existe en la Base de Datos"+err;
            }
        }

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
                txtCodigoEmpleado.ReadOnly = false;
                lblMensaje.Visible = false;
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario(this.Controls);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario(this.Controls);
        }
    }
}