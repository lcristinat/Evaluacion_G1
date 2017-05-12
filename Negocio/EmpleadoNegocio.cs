using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class EmpleadoNegocio
    {
        public void Agregar(Entidad.Empleados empleados)
        {
            try
            {
                Datos.EmpleadoDatos dc = new Datos.EmpleadoDatos();
                empleados.estado = 1;
                dc.Insert(empleados);
            }
            catch (Exception err)
            {

                throw err;
            }
        }
        public string CrearCedulaEmp(Entidad.Empleados cedemp)
        {
            string resp = "0";
            try
            {
                Datos.EmpleadoDatos dc = new Datos.EmpleadoDatos();
                List<Entidad.Empleados> Empleados = dc.ListaEmpleados();
                bool existe = Empleados.Exists(e => e.Cedula == cedemp.Cedula);
                if (!existe) 
                    this.Agregar(cedemp);
                else
                {
                    resp = "1";
                }
                return resp;
               }
            catch (Exception err)
            {

                throw err;
            }
        }

        public Entidad.Empleados ConsultarEmpleado(int Idemp)
        {

            Datos.EmpleadoDatos dc = new Datos.EmpleadoDatos();

            try
            {
                return dc.ListaEmpleados().Where(a => a.Id == Idemp).FirstOrDefault();
            }
            catch (Exception err)
            {

                throw err;

            }
        }

        public int ActualizarEmpleado(Entidad.Empleados datoEmpleado)
        {
            int resp = 0;
            Datos.EmpleadoDatos dc = null;
            try
            {
                dc = new Datos.EmpleadoDatos();
                dc.update(datoEmpleado);
                resp = 1;
            }
            catch (Exception err)
            {

                throw (err);
            }
            return resp;
        }

        public void ActualizarBajaemp(Entidad.Empleados bajaempleado)
        {
            //int baja = 0;
            Datos.EmpleadoDatos dc = null;
            try
            {
                dc = new Datos.EmpleadoDatos();
            //    bajaempleado.estado = 2;
                dc.updatebaja(bajaempleado);
             //   baja = 1;
            }
            catch (Exception err)
            {

                throw (err);
            }
           // return baja;
        }

        public List<Entidad.Empleados> ListaEmpleados()
        {
            Datos.EmpleadoDatos dc = new Datos.EmpleadoDatos();
            return dc.ListaEmpleados();
        }

    }
}