using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class wfUsuarioActualizar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ObtenerUsuario(int Id_Usua)
        {
            Negocio.UsuarioNegocio dc = new Negocio.UsuarioNegocio();

            try
            {
                Entidad.Usuarios c = dc.ObtenerUsuario(Id_Usua);
                txtCodigo.Text = c.Usuarios1.ToString();
                txtNombre.Text = c.Nombre;
                txtNumeroCedula.Text = c.Cedula;
                txtLogin.Text = c.Login;
                txtClave.Text = c.Clave;
                txtCodigo.ReadOnly = true;
            }
            catch (Exception err)
            {

                CV_Datos.IsValid = false;
                CV_Datos.ErrorMessage = "Error Registro no se encuentra" + err.Message;
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Negocio.UsuarioNegocio dc = new Negocio.UsuarioNegocio();
            string validaCedula;
            try
            {

                validaCedula = dc.ValidarCedula(txtNumeroCedula.Text.Trim());
                if (validaCedula == "1")
                {

                    Entidad.Usuarios c = new Entidad.Usuarios();
                    c.Usuarios1= int.Parse(txtCodigo.Text);
                    c.Nombre = txtNombre.Text.ToUpper().Trim();
                    c.Cedula = txtNumeroCedula.Text.ToUpper().Trim();
                    c.Login = txtLogin.Text.ToUpper().Trim();
                    c.Clave = txtClave.Text.ToUpper().Trim();
                    dc.ActualizarUsuario(c);
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "Registro Actualizado Correctamente";

                }
                else
                {
                    CV_Datos.IsValid = false;
                    CV_Datos.ErrorMessage = "Cèdula no es vàlida";
                }

            }
            catch (Exception err)
            {

                CV_Datos.IsValid = false;
                CV_Datos.ErrorMessage = "Error al Actualizar el registro" + err.Message;
            }

        }
        
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            int CodUsuario;
            try
            {
                if (txtCodigo.Text.Trim() != "")
                {
                    if (char.IsNumber(char.Parse(txtCodigo.Text.Trim())))
                    {
                        CodUsuario = int.Parse(txtCodigo.Text);
                        ObtenerUsuario(CodUsuario);
                    }
                    else
                    {
                        CV_Datos.IsValid = false;
                        CV_Datos.ErrorMessage = "Valor no permitido, Digite nùmeros enteros";
                        txtCodigo.Text = string.Empty;
                        txtNombre.Text = string.Empty;
                        txtNumeroCedula.Text = string.Empty;
                        txtLogin.Text = string.Empty;
                        txtClave.Text = string.Empty;

                    }
                }

            }
            catch (Exception err)
            {

                CV_Datos.IsValid = false;
                CV_Datos.ErrorMessage = "ERROR al Consultar el registro" + err.Message;
            }

        }
    }
 }