using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculoDeVacaciones2010
{
    public class CalculadoraAntiguedad
    {
        public Antiguedad getAntiguedadGeneradaPor(PeriodoDeTiempo periodo)
        {

            var años = periodo.hasta.Year - periodo.desde.Year;
            var meses = periodo.hasta.Month - periodo.desde.Month;
            var dias = periodo.hasta.Day - periodo.desde.Day;

            if (periodo.desde.Month > periodo.hasta.Month) años--;
            if (periodo.desde.Day > periodo.hasta.Day) meses--;

            if (meses < 0 && periodo.hasta.Year - periodo.desde.Year <= 1) meses += 13;
            if (meses < 0 && periodo.hasta.Year - periodo.desde.Year > 1) meses += 12;

            if (dias < 0) dias +=  diasHastaFinDeMes(periodo.desde) + 1;
            if (dias >= 30)
            {
                dias = 0;
                meses++;
            }

            if (meses >= 12)
            {
                meses = 0;
                años++;
            }

            return new Antiguedad(años, meses, dias);
        }

        private int diasHastaFinDeMes(DateTime fecha)
        {
            var primerDia = new DateTime(fecha.Year, fecha.Month, 01);
            var ultimoDia = agregarUnMes(primerDia);
            return (ultimoDia - primerDia).Days;
        }

        private DateTime agregarUnMes(DateTime fecha)
        {
            if (fecha.Month == 12)
            {
                return new DateTime(fecha.Year + 1, 01, 01);
            }
            return new DateTime(fecha.Year, fecha.Month + 1, 01);
        }

        public Antiguedad sumarAntiguedades(List<Antiguedad> antiguedades)
        {
            var antiguedadTotal = new Antiguedad(0, 0, 0);
            antiguedades.ForEach(antiguedad => antiguedadTotal = this.sumarAntiguedades(antiguedadTotal, antiguedad));
            return antiguedadTotal;
        }

        public Antiguedad sumarAntiguedades(Antiguedad antiguedad1, Antiguedad antiguedad2) 
        {
            var años = antiguedad1.años + antiguedad2.años;
            var meses = antiguedad1.meses + antiguedad2.meses;
            var dias = antiguedad1.dias + antiguedad2.dias;

            if (dias >= 30)
            {
                meses++;
                dias -= 30;
            }

            if (meses >= 12)
            {
                años++;
                meses -= 12;
            }

            return new Antiguedad(años, meses, dias);
        }


        public Antiguedad calcularAntiguedadPara(List<PeriodoTrabajado> periodosTrabajados)
        {
            var linea = new LineaDeTiempo();
            var antiguedades = new List<Antiguedad>();
            
            linea.agregarPeriodos(periodosTrabajados);
            var periodosUnidos = linea.getPeriodos();

            periodosUnidos.ForEach(periodo => antiguedades.Add(this.getAntiguedadGeneradaPor(periodo)));
            
            return this.sumarAntiguedades(antiguedades);
        }
    }
}
