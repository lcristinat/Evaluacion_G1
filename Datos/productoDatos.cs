using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class productoDatos
    {

        public void insertarProductoDatos(Entidad.Productos producto)
        {

            // Este método registra en la base de datos un producto pasado como parámetro
            // desde la capa de negocio

            Entidad.BD_EvaluacionEntities dc = null;

            try
            {

                dc = new Entidad.BD_EvaluacionEntities();
                dc.Productos.Add(producto);

                dc.SaveChanges();

            }
            catch (Exception err)
            {

                throw err;
            }

        } // fin del método insertarProductoDatos

        public void modificarProductoDatos(Entidad.Productos producto)
        {

            // Este método modifica la información de un producto de la 
            // base de datos. El producto se busca con base en el ID

            Entidad.BD_EvaluacionEntities dc = null;
            Entidad.Productos prod = null;

            try
            {

                dc = new Entidad.BD_EvaluacionEntities();
                prod = dc.Productos.Where(u => u.Id == producto.Id).FirstOrDefault();

                // Se actualiza cada dato del producto en la base de datos con la información
                // recibida de la capa de negocio

                prod.Id = producto.Id;
                prod.Descripcion = producto.Descripcion;
                prod.Existencia = producto.Existencia;
                prod.PrecioUnitario = producto.PrecioUnitario;
                prod.FechaProceso = producto.FechaProceso;
                prod.UsuarioProceso = producto.UsuarioProceso;

                dc.SaveChanges();

            }
            catch (Exception err)
            {

                throw err;
            }



        } // fin del método modificarProductoDatos

        public Entidad.Productos obtenerProductoDatos(int id)
        {

            // Este método recupera la información de un producto con base
            // en el id del mismo, recibido como parámetro desde la capa de negocio

            Entidad.BD_EvaluacionEntities dc = null;
            Entidad.Productos producto = null;

            try
            {

                dc = new Entidad.BD_EvaluacionEntities();
                producto = dc.Productos.Where(u => u.Id == id).FirstOrDefault();

                return producto;

            }
            catch (Exception err)
            {

                throw err;
            }

        } // fin del método obtenerProductoDatos

        public List<Entidad.Productos> obtenerProductoDatos()
        {

            // Este método recupera la información de un producto con base
            // en el id del mismo, recibido como parámetro desde la capa de negocio

            Entidad.BD_EvaluacionEntities dc = null;
            List<Entidad.Productos> producto = null;

            try
            {

                dc = new Entidad.BD_EvaluacionEntities();
                producto = dc.Productos.ToList();

                return producto;

            }
            catch (Exception err)
            {

                throw err;
            }

        } // fin del método obtenerProductoDatos


        public void eliminarProductoDatos(int id)
        {

            // Este método busca un producto en la base de datos con base en su
            // id y luego lo elimina

            Entidad.BD_EvaluacionEntities dc = null;
            Entidad.Productos producto = null;

            try
            {

                dc = new Entidad.BD_EvaluacionEntities();
                producto = dc.Productos.Where(u => u.Id == id).FirstOrDefault();

                dc.Productos.Remove(producto);
                dc.SaveChanges();

            }
            catch (Exception err)
            {

                throw err;
            }

        } // fin del método eliminarProductoDatos

    } // fin de la clase productoDatos
}
