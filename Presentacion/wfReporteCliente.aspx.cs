using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class wfReporteCliente : System.Web.UI.Page
    {

        #region Metodos Privados
        protected void CargarReporte()
        {
            try
            {
                rvCliente.Reset();
                Negocio.ClienteNegocio dc = new Negocio.ClienteNegocio();
                rvCliente.LocalReport.ReportEmbeddedResource = "Presentacion.Report1.rdlc";
                rvCliente.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("dsClientes", dc.ListaClientes()));
                rvCliente.LocalReport.Refresh();
               
                //rvCliente.LocalReport.ReportEmbeddedResource = "EntiyFramework.rptEstudiante.rdlc";
                //rvCliente.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", dc.AsignaturasEstudiante(asignaturasEst)));
                //rvCliente.LocalReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter("carnet", a.carne));
                //rvCliente.LocalReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter("direccion", a.direccion));
                //rvCliente.LocalReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter("nombre", a.nombre));
                //rvCliente.LocalReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter("telefono", a.telefono));
                //rvCliente.LocalReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter("correo", a.correo_electronico));
                //rvCliente.LocalReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter("fecha_nacimiento", a.fecha_nacimiento.ToShortDateString()));
                //rvCliente.LocalReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter("carrera", dc_Carrera.ListaCarreras().FirstOrDefault(c => c.Id == a.id_carrera).descripcion));
                //rvCliente.Visible = true;
                //rvCliente.LocalReport.Refresh();

            }
            catch (Exception err)
            {

                cvDatos.IsValid = false;
                cvDatos.ErrorMessage = err.Message;
            }
        }
        #endregion

        #region Eventos de los objetos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarReporte();
            }
        }
        #endregion



    }
}