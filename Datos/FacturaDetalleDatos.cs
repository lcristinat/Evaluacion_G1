using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class FacturaDetalleDatos
    {
        public void Insert(Entidad.Factura_Detalle aa)
        {
            Entidad.BD_EvaluacionEntities dc = null;
            try
            {
                dc = new Entidad.BD_EvaluacionEntities();
                dc.Factura_Detalle.Add(aa);
                dc.SaveChanges();
            }
            catch (Exception err)
            {

                throw (err);
            }
        }
    }
}
