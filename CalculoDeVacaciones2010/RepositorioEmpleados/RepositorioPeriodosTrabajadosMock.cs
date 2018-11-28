using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculoDeVacaciones2010
{
    public class RepositorioPeriodosTrabajadosMock:IRepositorioPeriodosTrabajados
    {
        private static IRepositorioPeriodosTrabajados _instance = new RepositorioPeriodosTrabajadosMock();

        public DateTime fechaLimite { get; set; }
        List<PeriodoTrabajado> _periodos = new List<PeriodoTrabajado>();

        private RepositorioPeriodosTrabajadosMock() { }

        public static IRepositorioPeriodosTrabajados instance()
        {
            return _instance;
        }

        public List<PeriodoTrabajado> getPeriodos()
        {
            if (_periodos.Count != 0) return _periodos;

            var desde = new DateTime(2000, 01, 01);
            var hasta = new DateTime(2010, 12, 31);
            var legajo = 202101;


            ITipoDeTrabajo publico = new TipoDeTrabajoPublico();
            ITipoDeTrabajo privado = new TipoDeTrabajoPublico();

            _periodos.Add(new PeriodoTrabajado(desde, hasta, legajo, publico));
            _periodos.Add(new PeriodoTrabajado(desde, hasta, legajo, publico));
            _periodos.Add(new PeriodoTrabajado(desde, hasta, legajo, publico));
            _periodos.Add(new PeriodoTrabajado(desde, hasta, legajo, publico));
            _periodos.Add(new PeriodoTrabajado(desde, hasta, legajo, publico));

            return _periodos;
        }

        public List<PeriodoTrabajado> getPeriodosPorLegajo(int legajo)
        {
            return getPeriodos().FindAll(periodo => periodo.legajo == legajo);
        }
    }
}
