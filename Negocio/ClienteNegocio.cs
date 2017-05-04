using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ClienteNegocio
    {

        /// <summary>
        /// Metodo que Inserta un Cliente
        /// </summary>
        /// <param name="nc"></param>
        public void InsertarCliente(Entidad.Clientes nc) //nc significa negociocliente
        {
            Datos.ClienteDatos dc = new Datos.ClienteDatos();

            try
            {
                nc.FechaProceso = DateTime.Now;
                nc.Estado = 1;
                dc.InsertarCliente(nc);  
            }
            catch (Exception err)
            {

                throw err;
            }
        }

        /// <summary>
        /// Metodo que Modifica un Cliente
        /// Manda al llamar al metodo ActualizarCliente de la capa de datos
        /// </summary>
        /// <param name="nc"></param>
        public void ModificarCliente(Entidad.Clientes nc) //nc significa negociocliente
        {
            Datos.ClienteDatos dc = new Datos.ClienteDatos();
            try
            {
                nc.FechaProceso = DateTime.Now;
                nc.UsuarioProceso = 1;
                dc.ActualizarCliente(nc);
            }
            catch (Exception)
            {

                throw;
            }
              
        }

        /// <summary>
        /// Metodo para Eliminar Cliente de la Capa de Negocio
        /// Manda a llamar al metodo ActualizarCliente de la capa de datos
        /// </summary>
        /// <param name="nc"></param>
        public void EliminarCliente(Entidad.Clientes nc) //nc significa negociocliente
        {
            Datos.ClienteDatos dc = new Datos.ClienteDatos();

            try
            {
                nc.FechaProceso = DateTime.Now;
                nc.Estado = 0;
                dc.ActualizarCliente(nc);
            }
            catch (Exception err)
            {

                throw err;
            }
        }

        /// <summary>
        /// Metodo para buscar un cliente por su Id
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public Entidad.Clientes ObtenerCliente(int idCliente)
        {
            Datos.ClienteDatos dc = new Datos.ClienteDatos();

            try
            {
                return dc.ListaClientes().Where(a => a.Id == idCliente).FirstOrDefault();
            }
            catch (Exception err)
            {

                throw err;
            }
        }
    }

}
