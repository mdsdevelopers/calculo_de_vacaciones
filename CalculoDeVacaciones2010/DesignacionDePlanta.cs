using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculoDeVacaciones2010
{
    public class DesignacionDePlanta:Designacion
    {
        public TipoDePlanta tipoDePlanta { get; set; }

        public DesignacionDePlanta(TipoDePlanta tipoDePlanta, DateTime fecha)
        {
            this.tipoDePlanta = tipoDePlanta;
            base.fecha = fecha;
        }

        public string nombrePlanta()
        {
            return this.tipoDePlanta.nombre;
        }
    }
}
