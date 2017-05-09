using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Negocio
{
   public class FacturaDetalleNegocio
    {
        public void Agregar(Entidad.Factura_Detalle facturaDetalle)
        {
            try
            {
                Datos.FacturaDetalleDatos dc = new Datos.FacturaDetalleDatos();
                dc.Insert(facturaDetalle);
            }
            catch (Exception err)
            {

                throw (err);
            }
        }
       
    }
}
