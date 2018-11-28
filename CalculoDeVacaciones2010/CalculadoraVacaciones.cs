using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculoDeVacaciones2010
{
    public class CalculadoraVacaciones
    {
        SortedDictionary<int, int> diasSegunAños = new SortedDictionary<int, int>();

        public CalculadoraVacaciones()
        {
            this.diasSegunAños.Add(0, 20); //Diccionario<años de antiguedad minimos, dias de vacaciones>
            this.diasSegunAños.Add(5, 25);
            this.diasSegunAños.Add(10, 30);
            this.diasSegunAños.Add(15, 35);

        }

        public int calcularDiasPara(Empleado unEmpleado, int añoDeCalculo)
        {
            if (unEmpleado.legajo == 201241)
            {
                var a = unEmpleado.legajo;
            }
            if (unEmpleado.fechaIngresoMinisterio == DateTime.MinValue) throw new Exception("Debe especificar una fecha de ingreso al ministerio del empleado para calcular los dias de Licencia");
            var fechaDeCalculo = new DateTime(añoDeCalculo, 12, 31);
            var antiguedadEnMinisterio = unEmpleado.getAntiguedadEnElMinisterioAl(fechaDeCalculo);
            if (antiguedadEnMinisterio < new Antiguedad(0, 3, 0)) return 0;
            if (antiguedadEnMinisterio < new Antiguedad(1, 0, 0)) return getAntiguedadProporcional(unEmpleado, fechaDeCalculo);
            return getDiasPorAntiguedad(unEmpleado, fechaDeCalculo);
        }

        private int getDiasPorAntiguedad(Empleado unEmpleado, DateTime fechaDeCalculo)
        {
            var filtro = new FiltroPeriodosTrabajados();
            var periodos = filtro.filtrarPeriodosPara(unEmpleado);
            periodos.Add(new PeriodoTrabajado(unEmpleado.fechaIngresoMinisterio, fechaDeCalculo, unEmpleado.legajo, new TipoDeTrabajoPublico()));
            
            var antiguedadAnterior = new CalculadoraAntiguedad().calcularAntiguedadPara(periodos);

            return diasSegunAños.Last(tupla => tupla.Key <= antiguedadAnterior.años).Value;
        }


        private int getAntiguedadProporcional(Empleado unEmpleado, DateTime fechaDeCalculo)
        {
            var antiguedadMinisterio = unEmpleado.getAntiguedadEnElMinisterioAl(fechaDeCalculo);
            var diasCalculados = Math.Ceiling((double)getDiasPorAntiguedad(unEmpleado, fechaDeCalculo) / 12 * antiguedadMinisterio.meses);
            return (int)diasCalculados;
        }
    }
}
