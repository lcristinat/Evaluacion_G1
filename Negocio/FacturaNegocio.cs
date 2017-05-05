using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Negocio
{
    public  class FacturaNegocio
    {

        public List<Entidad.Facturas> ListaFacturas()
        {
            try
            {
                Datos.FacturaDatos   dc = new Datos.FacturaDatos();
                return dc.GetList();
            }
            catch (Exception err)
            {

                throw (err);
            }
        }
        public void Agregar(Entidad.Facturas factura)
        {
            try
            {
                Datos.FacturaDatos dc = new Datos.FacturaDatos();
                dc.Insert(factura);
            }
            catch (Exception err)
            {

                throw (err);
            }
        }
        public bool NuevaFactura(Entidad.Facturas nuevafactura  , List<Entidad.Productos> producto)
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
