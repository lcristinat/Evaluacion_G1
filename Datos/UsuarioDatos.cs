﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class UsuarioDatos
    {
        public void Update(Entidad.Usuarios a)
        {
            Entidad.Usuarios usr = null;
            Entidad.BD_EvaluacionEntities dc = null;
            try
            {
                dc = new Entidad.BD_EvaluacionEntities();
                usr = dc.Usuarios.Where(c => c.Usuarios1 == a.Usuarios1).FirstOrDefault();
                if (usr != null)
                {
                    usr.Login = a.Login;
                    usr.Nombre = a.Nombre;
                    usr.Clave = a.Clave;
                    usr.FechaProceso = a.FechaProceso;
                    usr.Cedula = a.Cedula;
                    dc.SaveChanges();
                }
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

        public Entidad.Usuarios GetUsuario(string userLogin)
        {
            Entidad.BD_EvaluacionEntities dc = null;
            Entidad.Usuarios user = null;
            try
            {
                dc = new Entidad.BD_EvaluacionEntities();
                user = dc.Usuarios.Where(u => u.Login == userLogin).FirstOrDefault();
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

    }
}
