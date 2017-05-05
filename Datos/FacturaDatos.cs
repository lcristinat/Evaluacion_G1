using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class FacturaDatos
    {
        public Entidad.Facturas GetFactura(int idcliente)
        {
            Entidad.BD_EvaluacionEntities dc = null;
            Entidad.Facturas Factura = null;
            try
            {
                dc = new Entidad.BD_EvaluacionEntities();
                Factura = dc.Facturas.Where(u => u.IdCliente== idcliente).FirstOrDefault();
                return Factura;
            }
            catch (Exception err)
            {

                throw (err);
            }
        }
        public void Insert(Entidad.Facturas a)
        {
            Entidad.BD_EvaluacionEntities dc = null;
            try
            {
                dc = new Entidad.BD_EvaluacionEntities();
                dc.Facturas.Add(a);
                dc.SaveChanges();
            }
            catch (Exception err)
            {

                throw (err);
            }
        }
        public List<Entidad.Facturas> GetList()
        {
            Entidad.BD_EvaluacionEntities dc = null;
            try
            {
                dc = new Entidad.BD_EvaluacionEntities();
                return dc.Facturas.ToList();
            }
            catch (Exception err)
            {

                throw (err);
            }
        }
    }
}
