﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Convert the byte array to hexadecimal string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("x2"));
            }
            return sb.ToString();
        }

        /// <summary>
        /// Método para validar si existe el usuario 
        /// </summary>
        /// <param name="Login">Usuario</param>
        /// <returns>0- Usuario no existe / 1- Usuario existe / 3- Usuario existe pero está inactivo</returns>
        public int existeUsuario(string Login)
        {
            Datos.UsuarioDatos dc = new Datos.UsuarioDatos();
            try
            {
                int resp = 0;
                Entidad.Usuarios usuario = dc.GetUsuario(Login);

                //si usuario es distinto de null, existe y se procede a validar que este activo
                if (usuario != null)
                {
                    //si usuario esta activo se devuelve 1
                    if (usuario.Estado == 1)
                    {
                        resp = 1;
                    }
                    //de lo contrario se devuelve 3 que significa que es un usuario inactivo
                    else
                    {
                        resp = 3;
                    }
                }
                return resp;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        /// <summary>
        /// Método que se utiliza para validar si el password y el usuario son correctos
        /// </summary>
        /// <param name="login">Usuario</param>
        /// <param name="password">Contraseña</param>
        /// <returns>1- datos correctos / 0- Datos incorrectos</returns>
        public int validaDatos(string login, string password)
        {
            Datos.UsuarioDatos dc = new Datos.UsuarioDatos();
            try
            {
                int resp = 0;
                List<Entidad.Usuarios> listaUsuario = dc.GetList();
                //si login y password coinciden se retorna 1
                if (listaUsuario.Exists(u => u.Login == login && u.Clave == password))
                {
                    resp = 1;
                }
                return resp;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        /// <summary>
        /// Metodo que retorna el id del registro según login y password
        /// </summary>
        /// <param name="login">Login</param>
        /// <returns>Retorna el identificador del registro</returns>
        public int devolverID(string login)
        {
            Datos.UsuarioDatos dc = new Datos.UsuarioDatos();
            try
            {
                return dc.GetList().Where(u => u.Login == login).FirstOrDefault().Usuarios1;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        /// <summary>
        /// Método que devuelve la entidad mediante el identificador del registro
        /// </summary>
        /// <param name="idUsuario">Identificador del registro</param>
        /// <returns>Entidad del tipo usuario</returns>
        public Entidad.Usuarios devolverUsuario(int idUsuario)
        {
            Datos.UsuarioDatos dc = new Datos.UsuarioDatos();
            try
            {
                return dc.GetList().Where(u => u.Usuarios1 == idUsuario).FirstOrDefault();
            }
            catch (Exception err)
            {

                throw err;
            }
        }

        /// <summary>
        /// Llamado al metodo actualizar usuario de la capa de datos
        /// </summary>
        /// <param name="usuario">Entidad de tipo usuario</param>
        public void actualizarUsuario(Entidad.Usuarios usuario)
        {
            Datos.UsuarioDatos dc = new Datos.UsuarioDatos();
            try
            {
                dc.Update(usuario);
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        /// <summary>
        /// LLamado al método listUsuario de la capa de datos
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        public List<Entidad.Usuarios> listaUsuario()
        {
            Datos.UsuarioDatos dc = new Datos.UsuarioDatos();
            try
            {
                return dc.GetList();
            }
            catch (Exception err)
            {
                throw err;
            }
        }
    }
}
