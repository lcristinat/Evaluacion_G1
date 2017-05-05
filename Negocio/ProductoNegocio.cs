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
    }
}
