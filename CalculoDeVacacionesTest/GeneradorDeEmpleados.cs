using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CalculoDeVacaciones2010;

namespace CalculoDeVacacionesTest
{
    public class GeneradorDeEmpleados
    {
        public Empleado getEmpleadoConAntiguedad(Antiguedad antiguedad)
        {
            var legajo = 202111;
            var desde = new DateTime(1990, 1, 01);
            var hasta = desde.AddYears(antiguedad.años).AddMonths(antiguedad.meses).AddDays(antiguedad.dias);
            var periodo = new PeriodoTrabajado(desde, hasta, legajo, new TipoDeTrabajoPublico());
            var periodosTrabajados = new List<PeriodoTrabajado>();
            periodosTrabajados.Add(periodo);
            var empleado = new Empleado(legajo, 29753915);
            empleado.periodosTrabajadosAntesDelMinisterio = periodosTrabajados;
            empleado.fechaIngresoMinisterio = new DateTime(2000, 01, 01);
            return empleado;
        }
    }
}
