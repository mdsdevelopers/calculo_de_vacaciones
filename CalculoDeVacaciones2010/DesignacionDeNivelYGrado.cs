using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculoDeVacaciones2010
{
    public class DesignacionDeNivelYGrado:Designacion
    {
        public NivelYGrado nivelYGrado { get; set; }

        public DesignacionDeNivelYGrado(NivelYGrado nivelYGrado, DateTime fecha)
        {
            this.nivelYGrado = nivelYGrado;
            base.fecha = fecha;
        }

        public string nivel()
        {
            return this.nivelYGrado.nivel;
        }

        public string grado()
        {
            return this.nivelYGrado.grado;
        }
    }
}
