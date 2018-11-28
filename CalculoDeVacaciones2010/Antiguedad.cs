using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculoDeVacaciones2010
{
    public class Antiguedad
    {

        public int años { get; set; }
        public int meses { get; set; }
        public int dias { get; set; }

        public Antiguedad(int años, int meses, int dias)
        {
            //if (dias >= 30) throw new Exception("No pueden existir mas de 29 dias de antiguedad");
            if (meses >= 12) throw new Exception("No pueden existir mas de 11 meses de antiguedad");

            this.años = años;
            this.meses = meses;
            this.dias = dias;
        }

        #region identidad

        public override bool Equals(object obj)
        {
            var otraAntiguedad = (Antiguedad)obj;
            return this == otraAntiguedad; // se sobreescribe == mas abajo
        }

        public override int GetHashCode()
        {
            return this.años.GetHashCode() + this.meses.GetHashCode() * 13 + this.dias.GetHashCode() * 19;
        }

        #endregion

        #region comparaciones

        public static bool operator <(Antiguedad a1, Antiguedad a2)
        {
            if (a1.años < a2.años) return true;
            if (a1.años > a2.años) return false;
            if (a1.meses < a2.meses) return true;
            if (a1.meses > a2.meses) return false;
            return a1.dias < a2.dias;
        }

        public static bool operator >(Antiguedad a1, Antiguedad a2)
        {
            return !(a1 < a2) && !(a1 == a2);
        }

        public static bool operator <=(Antiguedad a1, Antiguedad a2)
        {
            return a1 < a2 || a1 == a2;
        }

        public static bool operator >=(Antiguedad a1, Antiguedad a2)
        {
            return !(a1 < a2);
        }

        public static bool operator ==(Antiguedad a1, Antiguedad a2)
        {
            return a1.años == a2.años && a1.meses == a2.meses && a1.dias == a2.dias;
        }

        public static bool operator !=(Antiguedad a1, Antiguedad a2)
        {
            return !(a1 == a2);
        }

        #endregion
    }
}
