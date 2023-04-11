using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class Empleado
    {
        public static ML.Result Add(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AacostaEmpleadoContext context = new DL.AacostaEmpleadoContext())
                {
                    int query = context.Database.ExecuteSqlRaw($"EmpleadoAdd '{empleado.Nombre}','{empleado.ApellidoPaterno}','{empleado.ApellidoMaterno}', '{empleado.Estado.IdEstado}'");

                    if (query >= 1)
                    {
                        result.Correct = true;
                        result.Message = "Se Inserto el Empleado";
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se Inserto el Empleado";
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }
        public static ML.Result Update(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AacostaEmpleadoContext context = new DL.AacostaEmpleadoContext())
                {

                    int query = context.Database.ExecuteSqlRaw($"EmpleadoUpdate '{empleado.IdEmpleado}','{empleado.Nombre}','{empleado.ApellidoPaterno}','{empleado.ApellidoMaterno}', '{empleado.Estado.IdEstado}'");

                    if (query >= 0)
                    {
                        result.Correct = true;
                        result.Message = "Se Modifico el Empleado";
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se Modifico el Empleado";
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;

        }
        public static ML.Result Delete(int idEmpleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AacostaEmpleadoContext context = new DL.AacostaEmpleadoContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"EmpleadoDelete {idEmpleado}");
                    if (query >= 1)
                    {
                        result.Correct = true;
                        result.Message = "Se Elimino el Empleado";
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se Elimino el Empleado";
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AacostaEmpleadoContext context = new DL.AacostaEmpleadoContext())
                {
                    var query = context.Empleados.FromSqlRaw("EmpleadoGetAll").ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            ML.Empleado empleado = new ML.Empleado();

                            empleado.IdEmpleado = obj.IdEmpleado;
                            empleado.NumeroNomina = obj.NumeroNomina;
                            empleado.Nombre = obj.Nombre;
                            empleado.ApellidoPaterno = obj.ApellidoPaterno;
                            empleado.ApellidoMaterno = obj.ApellidoMaterno;


                            empleado.Estado = new ML.Estado();
                            empleado.Estado.IdEstado = obj.IdEstado.Value;
                            empleado.Estado.Nombre = obj.NombreEstado;

                            result.Objects.Add(empleado);
                        }
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Ex = ex;

            }
            return result;
        }
        public static ML.Result GetById(int idEmpleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AacostaEmpleadoContext context = new DL.AacostaEmpleadoContext())
                {
                    var query = context.Empleados.FromSqlRaw($"EmpleadoGetById {idEmpleado}").AsEnumerable().FirstOrDefault();


                    if (query != null)
                    {
                        ML.Empleado empleado = new ML.Empleado();

                        empleado.IdEmpleado = query.IdEmpleado;
                        empleado.NumeroNomina = query.NumeroNomina;
                        empleado.Nombre = query.Nombre;
                        empleado.ApellidoPaterno = query.ApellidoPaterno;
                        empleado.ApellidoMaterno = query.ApellidoMaterno;


                        empleado.Estado = new ML.Estado();
                        empleado.Estado.IdEstado = query.IdEstado.Value;
                        empleado.Estado.Nombre = query.NombreEstado;

                        result.Object = empleado;
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}