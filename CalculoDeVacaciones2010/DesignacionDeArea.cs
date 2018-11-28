using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculoDeVacaciones2010
{
    public class DesignacionDeArea:Designacion
    {
        public Area area { get; set; }

        public DesignacionDeArea(Area area, DateTime fecha)
        {
            this.area = area;
            base.fecha = fecha;
        }

        public object nombreArea()
        {
            return this.area.nombre;
        }
    }
}
