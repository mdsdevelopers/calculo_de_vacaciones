using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculoDeVacaciones2010
{
    public class NivelYGrado
    {
        public string nivel { get; set; }
        public string grado { get; set; }

        public NivelYGrado(string nivel, string grado)
        {
            this.nivel = nivel;
            this.grado = grado;
        }
    }
}
