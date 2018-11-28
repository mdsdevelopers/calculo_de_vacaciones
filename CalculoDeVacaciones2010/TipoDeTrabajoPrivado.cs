using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculoDeVacaciones2010
{
    public class TipoDeTrabajoPrivado:ITipoDeTrabajo
    {
        public bool esPublico()
        {
            return false; ;
        }

        public bool esPrivado()
        {
            return true;
        }
    }
}
