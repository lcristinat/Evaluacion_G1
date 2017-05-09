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
        public int ConsultarFactura(int idfactura)
        {
            int respuesta = 0;
            Datos.FacturaDatos dc = new Datos.FacturaDatos();
            Entidad.Facturas fact = dc.GetFactura(idfactura);
            if (fact != null)
            {

                if (fact.Id!= idfactura)
                {
                    respuesta = 1;
                } //cierra if verificacion clave...
                else
                {
                    respuesta = 2;
                }
            } //cierra if verificacion usuario NULL
            if (fact == null)
            {
                respuesta = 1;
            }
            return respuesta;
            //cierra if verificacion factura NULL

        }
        public bool NuevaFactura(Entidad.Facturas nuevafactura, List<Entidad.Factura_Detalle> productos)
        {
            bool resp = true;
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    this.Agregar(nuevafactura);
                    int codFactura = nuevafactura.Id;
                    Negocio.FacturaDetalleNegocio dc = new FacturaDetalleNegocio();
                    foreach (var item in productos)
                    {
                        int codProducto = item.IdProducto;
                        Entidad.Factura_Detalle aa = new Entidad.Factura_Detalle();
                        aa.IdFactura = codFactura;
                        aa.IdProducto = codProducto;
                        aa.Cantidad = item.Cantidad;
                        aa.Valor = item.Valor;
                        aa.FechaProceso = DateTime.Now;
                                               
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
