using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculoDeVacaciones2010
{
    public class PeriodoDeTiempo
    {
        public DateTime desde { get; set; }
        public DateTime hasta { get; set; }

        public PeriodoDeTiempo(DateTime desde, DateTime hasta)
        {
            if (desde > hasta) throw new Exception("En un periodo, desde debe ser menor que hasta");
            this.desde = desde;
            this.hasta = hasta;
        }

        public Boolean sePisaCon(PeriodoDeTiempo otroPeriodo)
        {
            if (this.desde >= otroPeriodo.desde && this.desde <= otroPeriodo.hasta) return true;
            if (this.hasta >= otroPeriodo.desde && this.desde <= otroPeriodo.hasta) return true;
            return false;
        }

        public int CompareTo(object obj)
        {
            return desde.CompareTo(((PeriodoTrabajado)obj).desde);
        }

        public void unirCon(PeriodoDeTiempo periodo2)
        {
            if (!this.sePisaCon(periodo2)) throw new Exception("No se pueden unir dos periodos disjuntos");
            if (this.desde > periodo2.desde) this.desde = periodo2.desde;
            if (this.hasta < periodo2.hasta) this.hasta = periodo2.hasta;
        }


        #region identidad

        public override bool Equals(object obj)
        {
            var otroPeriodo = obj as PeriodoDeTiempo;
            return this.desde == otroPeriodo.desde && this.hasta == otroPeriodo.hasta;
        }

        public override int GetHashCode()
        {
            return this.desde.GetHashCode() * 13 + this.hasta.GetHashCode();
        }

        #endregion
    }
}
