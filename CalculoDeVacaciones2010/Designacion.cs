using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculoDeVacaciones2010
{
    public abstract class Designacion:IComparable
    {
        public DateTime fecha { get; set; }

        public int CompareTo(object otraDesignacion)
        {
            return this.fecha.CompareTo(((Designacion)otraDesignacion).fecha);
        }
    }
}
