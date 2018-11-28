using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculoDeVacaciones2010
{
    public class Contrato
    {
        public DateTime desde { get; set; }
        public DateTime hasta { get; set; }
        public bool estaDeBaja { get; set; }
        public bool estaAprobado { get; set; }
        public string numero { get; set; }

        public bool estaVencidoAl(DateTime fecha)
        {
            return fecha > hasta;
        }

        public bool esElPrimeroDeLaPersona()
        {
            return numero.Substring(0, 2) == "01";
        }
    }
}
