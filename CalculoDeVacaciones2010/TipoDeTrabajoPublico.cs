using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculoDeVacaciones2010
{
    public class TipoDeTrabajoPublico: ITipoDeTrabajo
    {
        public bool esPublico()
        {
            return true;
        }

        public bool esPrivado()
        {
            return false;
        }
    }
}
