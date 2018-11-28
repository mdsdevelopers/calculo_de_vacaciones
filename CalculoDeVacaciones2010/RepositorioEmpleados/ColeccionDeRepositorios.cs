using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculoDeVacaciones2010
{
    public class ColeccionDeRepositorios
    {
        public IRepositorioEmpleados repositorioEmpleados { get; set; }
        public IRepositorioPeriodosTrabajados repositorioPeriodosTrabajados { get; set; }

        public ColeccionDeRepositorios()
        {
            this.repositorioEmpleados = RepositorioEmpleadosSqlClient.instance();
            this.repositorioPeriodosTrabajados = RepositorioPeriodosTrabajadosSqlClient.instance();
        }
    }
}