using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculoDeVacaciones2010
{
    public interface ITipoDeTrabajo
    {
        bool esPublico();
        bool esPrivado();
    }
}
