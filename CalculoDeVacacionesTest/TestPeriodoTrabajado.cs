using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculoDeVacaciones2010;

namespace CalculoDeVacacionesTest
{
    /// <summary>
    /// Descripción resumida de TestPeriodoTrabajado
    /// </summary>
    [TestClass]
    public class TestPeriodoTrabajado
    {

        IRepositorioPeriodosTrabajados _repositorio;

        [TestInitialize]
        public void MyTestInitialize()
        {
            _repositorio = RepositorioPeriodosTrabajadosMock.instance();
            _repositorio.fechaLimite = new DateTime(2010, 12, 31);
        }

        [TestMethod]
        public void un_periodo_deberia_conocer_cuando_empieza_y_termina()
        {
            var periodos = _repositorio.getPeriodos();
            var periodo = periodos[0];

            var desde = new DateTime(2000, 01, 01);
            var hasta = new DateTime(2010, 12, 31);

            Assert.AreEqual(desde, periodo.desde);
            Assert.AreEqual(hasta, periodo.hasta);
        }
    }
}
