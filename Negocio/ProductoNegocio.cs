using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ProductoNegocio
    {
        public List<Entidad.Productos> ListaProducto()
        {
            try
            {
                Datos.ProductoDatos dc = new Datos.ProductoDatos();
                return dc.GetList();
            }
            catch (Exception err)
            {

                throw (err);
            }
        }
        public int ConsultarExistencia(int idproducto )
        {
            try
            {
                int existencia = 0;
                Datos.ProductoDatos dc = new Datos.ProductoDatos();
                existencia= dc.ObtenerProducto(idproducto);
                return existencia;
            }
            catch (Exception err)
            {

                throw (err);
            }
        }
        //protected int ExisteProucto(int NA)
        //{
        //    int respuesta = 0;
        //    Datos.ProductoDatos dc = new Datos.ProductoDatos();
        //    Entidad.Productos producto = dc.ObtenerProducto (NA);
        //    if (producto != null)
        //    {
        //        respuesta = 1;
        //    }

        //    return respuesta;
        //}
    }
}
