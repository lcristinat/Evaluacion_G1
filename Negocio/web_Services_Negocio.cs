﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
   public class web_Services_Negocio
    {
        public string ValidaCedula(string numCedula)
        {
            try
            {
                ServiciosUCA.ServiciosUcaClient ws = new ServiciosUCA.ServiciosUcaClient();
                string resp = ws.ValidarCedula(numCedula);
                return resp;
            }
            catch (Exception err)
            {

                throw (err);
            }
        }

    }
}
