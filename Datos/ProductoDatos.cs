using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ProductoDatos
    {
        public List<Entidad.Productos> GetList()
        {
            Entidad.BD_EvaluacionEntities dc = null;
            try
            {
                dc = new Entidad.BD_EvaluacionEntities();
                return dc.Productos.ToList();
            }
            catch (Exception err)
            {

                throw (err);
            }
        }
    }
}
