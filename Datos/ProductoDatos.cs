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
        public int ObtenerProducto(int codproducto)
        {
            Entidad.BD_EvaluacionEntities dc = null;
            try
            {
                int cantidad = 0;
                dc = new Entidad.BD_EvaluacionEntities();
                Entidad.Productos myExistencia = null;
                myExistencia = dc.Productos.Where(a => a.Id == codproducto).FirstOrDefault();
                cantidad = myExistencia.Existencia;
                return cantidad;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
