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
       
    }
}
