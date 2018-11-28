using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculoDeVacaciones2010
{
    public class AutorizacionLicencia
    {
        public int Legajo { get; set; }
        public int Dias { get; set; }

        public AutorizacionLicencia(int legajo, int dias)
        {
            this.Legajo = legajo;
            this.Dias = dias;
        }
    }
}
