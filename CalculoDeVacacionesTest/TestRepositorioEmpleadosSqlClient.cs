using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculoDeVacaciones2010;

namespace CalculoDeVacacionesTest
{
    [TestClass]
    public class TestRepositorioEmpleadosSqlClient
    {

        IRepositorioPeriodosTrabajados _repoPeriodos;

        [TestInitialize]
        public void setup()
        {
            _repoPeriodos = RepositorioPeriodosTrabajadosSqlClient.instance();
            _repoPeriodos.fechaLimite = new DateTime(2010, 12, 31);
        }

        [TestMethod]
        public void RepositorioEmpleados()
        {
            IRepositorioEmpleados repo = RepositorioEmpleadosSqlClient.instance();
            var empleados = repo.getEmpleados();
            Assert.AreNotEqual(0, empleados.Count);
        }
    }
}
