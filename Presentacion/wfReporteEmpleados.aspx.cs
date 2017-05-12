using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class wfReporteEmpleados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReporteEmpleado();
            }
        }
        
        protected void ReporteEmpleado()
        {
            try
            {
                ReportViewer1.Reset();
                Negocio.EmpleadoNegocio dc = new Negocio.EmpleadoNegocio();
                ReportViewer1.LocalReport.ReportEmbeddedResource = "Presentacion.rptListadoEmpleados.rdlc";
                ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", dc.ListaEmpleados()));
                ReportViewer1.Visible = true;
                ReportViewer1.LocalReport.Refresh();

            }
            catch (Exception err)
            {
                cvdatos.IsValid = false;
                cvdatos.ErrorMessage = err.Message;
            }
        }
    }
}