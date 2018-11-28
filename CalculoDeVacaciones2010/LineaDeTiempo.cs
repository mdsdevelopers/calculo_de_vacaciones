using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculoDeVacaciones2010
{
    public class LineaDeTiempo
    {

        List<PeriodoDeTiempo> _periodos = new List<PeriodoDeTiempo>();

        public void agregarPeriodo(PeriodoDeTiempo unPeriodo)
        {
            var superpuestos =_periodos.FindAll(periodo => periodo.sePisaCon(unPeriodo));
            superpuestos.ForEach(periodo => unPeriodo.unirCon(periodo));

            _periodos.RemoveAll(periodo => superpuestos.Contains(periodo));
            _periodos.Add(unPeriodo);
            _periodos.Sort();

        }

        public List<PeriodoDeTiempo> getPeriodos()
        {
            return _periodos;
        }

        public void agregarPeriodos(List<PeriodoTrabajado> periodos)
        {
            periodos.ForEach(periodo => this.agregarPeriodo(periodo));
        }
    }
}
