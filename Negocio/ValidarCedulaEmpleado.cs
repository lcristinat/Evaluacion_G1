using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ValidarCedulaEmpleado
    {
        public string ValidaCedulaEmp(string numeroCedula)
        {
            ServicioUCA.ServiciosUcaClient ws = new ServicioUCA.ServiciosUcaClient();
            try
            {
                string resp = (ws.ValidarCedula(numeroCedula) == "1" ? "CEDULA VALIDA" : "CEDULA INVALIDA");
                return resp;
            }
            catch (Exception err)
            {

                throw err;
            }
        }
    }
}
