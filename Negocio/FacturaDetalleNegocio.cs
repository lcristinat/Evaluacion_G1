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
        public bool NuevaFacturaDetalle(Entidad.Facturas nuevafactura, List<Entidad.Productos> producto)
        {
            bool resp = true;
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    this.Agregar(nuevafactura);
                    int codFactura = nuevafactura.Id;
                    Negocio.FacturaDetalleNegocio dc = new FacturaDetalleNegocio();
                    foreach (var item in producto)
                    {
                        int codProducto = item.Id;
                        Entidad.Factura_Detalle aa = new Entidad.Factura_Detalle();
                        aa.IdFactura = codFactura;
                        aa.IdProducto = codProducto;
                        dc.Agregar(aa);
                    }
                    ts.Complete();
                }
            }
            catch (Exception)
            {
                resp = false;
                //throw;
            }
            return resp;

        }
    }
}
