using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class EmpleadoDatos
    {
        public void Insert(Entidad.Empleados e) // metodo para insertar nuevo registro
        {
            Entidad.BD_EvaluacionEntities dc = null;
            try
            {
                dc = new Entidad.BD_EvaluacionEntities();
                dc.Empleados.Add(e);
                dc.SaveChanges();
            }
            catch (Exception err)
            {

                throw err;
            }
        }
//Inicia Actualización de datos del Empleador
        public void update(Entidad.Empleados emp)// Guarda los cambios para la edición o modificación de los datos
        {
            Entidad.BD_EvaluacionEntities dc = null;
            try
            {
                dc = new Entidad.BD_EvaluacionEntities();
                Entidad.Empleados EmpleadoBD = dc.Empleados.Where(eBD => eBD.Id == emp.Id).FirstOrDefault();
                EmpleadoBD.Nombre = emp.Nombre;
                EmpleadoBD.Cedula = emp.Cedula;
                EmpleadoBD.Direccion = emp.Direccion;
                EmpleadoBD.Estado = emp.Estado;
                dc.SaveChanges();
            }
            catch (Exception err)
            {

                throw (err);
            }
        }

        public void updatebaja(Entidad.Empleados empbaja) //actualizar la baja de los empleados
        {
            Entidad.BD_EvaluacionEntities dc = null;
            try
            {
                dc = new Entidad.BD_EvaluacionEntities();
                Entidad.Empleados bajaBD = dc.Empleados.Where(ebaja => ebaja.Id == empbaja.Id).FirstOrDefault();
                bajaBD.Id = empbaja.Id;
                bajaBD.Nombre = empbaja.Nombre;
                bajaBD.Estado = empbaja.Estado;
                dc.SaveChanges();
            }
            catch (Exception err)
            {

                throw err;
            }
        }

        public List<Entidad.Empleados> ListaEmpleados()
        {
            Entidad.BD_EvaluacionEntities dc = new Entidad.BD_EvaluacionEntities();
            try
            {
                return dc.Empleados.ToList();
            }
            catch (Exception err)
            {

                throw err;
            }
        }


    }

}