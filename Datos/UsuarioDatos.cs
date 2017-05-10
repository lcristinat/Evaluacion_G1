using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
   public class UsuarioDatos
    {
        public Entidad.Usuarios GetUsuario(string userLogin)
        {
            // Este método Obtiene de la base de datos un usuario meidante un pàrametro desde la capa de Negocio
           
            Entidad.BD_EvaluacionEntities dc = null;
            Entidad.Usuarios user = null;
            try
            {

                dc = new Entidad.BD_EvaluacionEntities();
                user =dc.Usuarios.Where(u => u.Login == userLogin).FirstOrDefault();
                return user;

            }
            catch (Exception err)
            {

                throw (err);
            }
        }

        public Entidad.Usuarios GetUsuarios(int Cod_Usua)
        {
            // Este método Obtiene de la base de datos un usuario meidante un pàrametro desde la capa de Negocio

            Entidad.BD_EvaluacionEntities dc = null;
            Entidad.Usuarios user = null;
            try
            {

                dc = new Entidad.BD_EvaluacionEntities();
                user = dc.Usuarios.Where(u => u.Usuarios1 == Cod_Usua).FirstOrDefault();
                return user;

            }
            catch (Exception err)
            {

                throw (err);
            }
        }


        public List<Entidad.Usuarios> GetList()
        {
            Entidad.BD_EvaluacionEntities dc = null;
            try
            {
                dc = new Entidad.BD_EvaluacionEntities();
                return dc.Usuarios.ToList();
            }
            catch (Exception err)
            {
                throw (err);
            }

        }

        public void Delete_Usuarios(int codUsuario)
        {
            Entidad.BD_EvaluacionEntities dc = null;
            try
            {
                dc = new Entidad.BD_EvaluacionEntities();
                Entidad.Usuarios usuarioBD = (from x in dc.Usuarios where x.Usuarios1 == codUsuario select x).FirstOrDefault();

                if (usuarioBD != null)
                {
                    dc.Usuarios.Remove(usuarioBD);
                    dc.SaveChanges();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        public void Insert(Entidad.Usuarios u)
        {
            Entidad.BD_EvaluacionEntities dc = null;
            try
            {
                dc = new Entidad.BD_EvaluacionEntities();
                dc.Usuarios.Add(u);//Consultar porque no se encuentra el AddObject
                dc.SaveChanges();
            }
            catch (Exception err)
            {
                throw (err);
            }
       }

        public void update(Entidad.Usuarios a)
        {
            Entidad.Usuarios usr = null;
            Entidad.BD_EvaluacionEntities dc = null;
            try
            {
                dc = new Entidad.BD_EvaluacionEntities();
                dc = new Entidad.BD_EvaluacionEntities();
                usr = dc.Usuarios.Where(c => c.Usuarios1 == a.Usuarios1).FirstOrDefault();
                usr.Nombre = a.Nombre;
               // usr.Login = a.Login;
               // usr.Clave = a.Clave;
                usr.Cedula = a.Cedula;
                dc.SaveChanges();
            }
            catch (Exception err)
            {

                throw new Exception("Error al ejecutar update en Usuarios////Detalle: " + err.Message);
            }
            finally
            {
                if (dc != null)
                    dc.Dispose();
            }


        }
    }
}
