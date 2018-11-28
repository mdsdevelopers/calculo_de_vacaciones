using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculoDeVacaciones2010
{
    public class PeriodoTrabajado:PeriodoDeTiempo, IComparable
    {
        public int legajo { get; set; }
        private ITipoDeTrabajo _tipoDeTrabajo { get; set; }
        public PeriodoTrabajado(DateTime desde, DateTime hasta, int legajo, ITipoDeTrabajo tipoDeTrabajo):base (desde, hasta)
        {
            this.legajo = legajo;
            _tipoDeTrabajo = tipoDeTrabajo;
        }

        #region identidad

        public override bool Equals(object obj)
        {
            return base.Equals(obj) && this.legajo == ((PeriodoTrabajado)obj).legajo;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() + legajo * 19;
        }

        #endregion

        public bool esPublico()
        {
            return _tipoDeTrabajo.esPublico();
        }

        public bool esPrivado()
        {
            return _tipoDeTrabajo.esPrivado();
        }
    }
}
