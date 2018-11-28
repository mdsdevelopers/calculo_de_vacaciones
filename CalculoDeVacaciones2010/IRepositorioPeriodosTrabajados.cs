using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculoDeVacaciones2010
{
    public interface IRepositorioPeriodosTrabajados
    {
        List<PeriodoTrabajado> getPeriodos();
        List<PeriodoTrabajado> getPeriodosPorLegajo(int legajo);
        DateTime fechaLimite { get; set; }
    }
}
