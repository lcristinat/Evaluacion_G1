using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ClienteDatos
    {
        
        /// <summary>
        /// Metodo que inserta un cliente en la Base de Datos
        /// </summary>
        /// <param name="c"></param>
        public void InsertarCliente(Entidad.Clientes c)
        {
            Entidad.BD_EvaluacionEntities dc = new Entidad.BD_EvaluacionEntities();
            dc.Clientes.Add(c);
            dc.SaveChanges();

        }

        /// <summary>
        /// Metodo que elimina un cliente de la Base de Datos
        /// </summary>
        /// <param name="id"></param>
        public void ActualizarCliente(Entidad.Clientes c)
        {
            Entidad.BD_EvaluacionEntities dc = new Entidad.BD_EvaluacionEntities();
            try
            {
                Entidad.Clientes userBD = dc.Clientes.FirstOrDefault(aBD => aBD.Id == c.Id);
                if (userBD != null)
                {
                    userBD.Nombre = c.Nombre;
                    userBD.Cedula = c.Cedula;
                    userBD.Direccion = c.Direccion;
                    userBD.FechaProceso = c.FechaProceso;
                    userBD.UsuarioProceso = c.UsuarioProceso;
                    userBD.Estado = c.Estado;
                    dc.SaveChanges();
                }


            }
            catch (Exception err)
            {

                throw (err);
            }
        }

       
        /// <summary>
        /// Metodo que busca un ciente en la base de datos por el codigo del cliente
        /// </summary>
        /// <param name="clienteId"></param>
        /// <returns></returns>
        public Entidad.Clientes ObtenerCliente(int  clienteId)
        {
            Entidad.BD_EvaluacionEntities dc = new Entidad.BD_EvaluacionEntities();
            try
            {
                return dc.Clientes.FirstOrDefault(a => a.Id == clienteId); 

            }
            catch (Exception err)
            {

                throw (err);
            }
        }


        /// <summary>
        /// Metodo que Carga la lista de Clientes
        /// </summary>
        /// <returns></returns>
        public List<Entidad.Clientes> ListaClientes()
        {
            Entidad.BD_EvaluacionEntities dc = new Entidad.BD_EvaluacionEntities();
            try
            {
                return dc.Clientes.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
