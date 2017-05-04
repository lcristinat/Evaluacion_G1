using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class wfProductoReporte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Negocio.productoNegocio dc = new Negocio.productoNegocio();

                try
                {

                    // Construimos el reporte para que lea toda la información que
                    // arroja el método "obtenerProductoNegocio"

                    rptvwReporte.LocalReport.ReportEmbeddedResource = "Presentacion.rptProducto.rdlc";
                    rptvwReporte.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", dc.obtenerProductoNegocio()));

                    rptvwReporte.LocalReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter("Descripcion", "Descripcion"));
                    rptvwReporte.LocalReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter("Existencia", "Existencia"));
                    rptvwReporte.LocalReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter("PrecioUnitario", "PrecioUnitario"));
                    rptvwReporte.LocalReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter("FechaProceso", "FechaProceso"));
                    rptvwReporte.LocalReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter("UsuarioProceso", "UsuarioProceso"));
                    rptvwReporte.LocalReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter("Estado", "Estado"));

                    rptvwReporte.LocalReport.Refresh();

                }
                catch (Exception err)
                {

                    throw err;
                }


            } // fin del if

        } // fin del Page_Load

        protected void btnConfirmar_Click1(object sender, EventArgs e)
        {

        }
    }
}