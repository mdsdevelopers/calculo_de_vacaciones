using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculoDeVacaciones2010
{
    public class RepositorioEmpleadosMock:IRepositorioEmpleados
    {

        private static IRepositorioEmpleados _instance = new RepositorioEmpleadosMock();

        private RepositorioEmpleadosMock() {  }

        public List<Empleado> getEmpleados()
        {

            IRepositorioPeriodosTrabajados repoPeriodos = new ColeccionDeRepositorios().repositorioPeriodosTrabajados;

            var legajo = 202101;
            var periodosDelEmpleado = repoPeriodos.getPeriodosPorLegajo(legajo);

            var empleado = new Empleado(legajo, 29753914);
            empleado.periodosTrabajadosAntesDelMinisterio = periodosDelEmpleado;
            empleado.fechaIngresoMinisterio = new DateTime(2000, 10, 01);

            var empleados = new List<Empleado>();
            empleados.Add(empleado);
            return empleados;
        }

        public static IRepositorioEmpleados instance()
        {
            return _instance;
        }
    }
}
