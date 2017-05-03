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
        public void EliminarCliente(int id)
        {

            try
            {
                Entidad.BD_EvaluacionEntities dc = new Entidad.BD_EvaluacionEntities();

                Entidad.Clientes userbd = null;
                userbd = dc.Clientes.Where(u => u.Id == id).FirstOrDefault();
                if (userbd != null)
                {
                    dc.Clientes.Remove(userbd);
                    dc.SaveChanges();
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Metodo que actualiza un cliente en la Base de Datos
        /// </summary>
        /// <param name="c"></param>
        public void ModificarCliente(Entidad.Clientes c)
        {
            Entidad.BD_EvaluacionEntities dc = new Entidad.BD_EvaluacionEntities();
            try
            {
                Entidad.Clientes userBD = dc.Clientes.FirstOrDefault(aBD => aBD.Id == c.Id);
                userBD.Nombre = c.Nombre;
                userBD.Cedula = c.Cedula;
                userBD.Direccion = c.Direccion;
                userBD.FechaProceso = DateTime.Now;
                dc.SaveChanges();
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


    }
}
