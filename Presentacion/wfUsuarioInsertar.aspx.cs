using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class wfUsuarioInsertar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnValida_Cedula_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    Negocio.Web_Services_Negocio dc = new Negocio.Web_Services_Negocio();
            //    lbl_Mensaje.Text = dc.ValidaCedula(txtNumeroCedula.Text.Trim()) == "1" ? "Válida" : "Inválida";
            //}
            //catch (Exception err)
            //{

            //    //throw;
            //    CV_Datos.IsValid = true;
            //    CV_Datos.ErrorMessage = "Error al conectarse al servicio WEB" + err;

            //}
        }
    }
}