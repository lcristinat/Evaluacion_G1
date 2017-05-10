using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Negocio
{
   public class UsuarioNegocio
    {
        public Entidad.Usuarios ObtenerUsuario(int codigo_usua)
        {
       
            Datos.UsuarioDatos dc = new Datos.UsuarioDatos();
            try
            {
              return dc.GetList().Where(a => a.Usuarios1 == codigo_usua).FirstOrDefault();
            }
            catch (Exception err)
            {

                throw err;
            }
        }
        public int ConsultaUsuario(string login, string clave)
        {
            int respuesta = 0;
            Datos.UsuarioDatos dc = new Datos.UsuarioDatos();
            Entidad.Usuarios usuario = dc.GetUsuario(login);
            if (usuario != null)
            {
                string Clave_Encrip = CreateMD5(clave);

                if (usuario.Clave != Clave_Encrip)
                {
                    respuesta = 1;
                }
                else
                    if (usuario.Clave == "EVALUACION")
                {
                    respuesta = 2;
                }
                else
                {
                    respuesta = 3;
                }
            }
            return respuesta;
        }
        public void EliminarUsuario(int idUsuario)
        {
            try
            {
                Datos.UsuarioDatos dc = new Datos.UsuarioDatos();
                dc.Delete_Usuarios(idUsuario);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ActualizarUsuario(Entidad.Usuarios idUsuario)
        {
            try
            {
                Datos.UsuarioDatos dc = new Datos.UsuarioDatos();
                dc.update(idUsuario);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Entidad.Usuarios> ListaUsuario()
        {
            try
            {
                Datos.UsuarioDatos dc = new Datos.UsuarioDatos();
                return dc.GetList();
            }
            catch (Exception err)
            {

                throw (err);
            }
        }

        public string Agregar(Entidad.Usuarios Usua)
        {
            try
            {
                string resp = "";
               
                    Datos.UsuarioDatos dc = new Datos.UsuarioDatos();
                    Entidad.Usuarios userBD = dc.GetUsuario(Usua.Login);
                    if (userBD == null)
                    {
                        Usua.Clave = CreateMD5(Usua.Clave);
                        dc.Insert(Usua);
                        resp = "1";
                    }
                
                return resp;

            }
            catch (Exception err)
            {
                throw (err);
            }

        }

        protected static string CreateMD5(string input)
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
        public string ValidarCedula(string numeroCedula)
        {
            string respuesta = "";
            ServiciosUCA.ServiciosUcaClient ws = new ServiciosUCA.ServiciosUcaClient();

            try
            {
                string resp = ws.ValidarCedula(numeroCedula);
                if (resp == "1")
                {
                    respuesta = "1";
                }
                else
                {
                    respuesta = "2";
                }
            }
            catch (Exception err)
            {
                throw (err);
            }

            return respuesta;
        }

    }
}
