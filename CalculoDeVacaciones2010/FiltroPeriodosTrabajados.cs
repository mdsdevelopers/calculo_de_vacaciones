using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculoDeVacaciones2010
{
    public class FiltroPeriodosTrabajados
    {
        public List<PeriodoTrabajado> filtrarPeriodosPara(Empleado empleado)
        {
            var fechaLimite = new DateTime(2006, 03, 01);
            if (empleado.fechaIngresoMinisterio < fechaLimite) {
                return empleado.periodosTrabajadosAntesDelMinisterio;
            }
            return empleado.periodosTrabajadosAntesDelMinisterio.FindAll(periodo => periodo.esPublico());
        }
    }
}
