using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculoDeVacaciones2010;

namespace CalculoDeVacacionesTest
{
    [TestClass]
    public class TestLineaDeTiempo
    {
        private ITipoDeTrabajo publico = new TipoDeTrabajoPublico();

        [TestMethod]
        public void dos_periodos_iguales_se_transforman_en_uno()
        {
            LineaDeTiempo linea = new LineaDeTiempo();
            List<PeriodoDeTiempo> periodos = new List<PeriodoDeTiempo>();

            var desde = new DateTime(2010, 01, 01);
            var hasta = new DateTime(2010, 05, 01);

            var periodo1 = new PeriodoTrabajado(desde, hasta, 29753914, publico);
            var periodo2 = new PeriodoTrabajado(desde, hasta, 29753914, publico);

            linea.agregarPeriodo(periodo1);
            linea.agregarPeriodo(periodo2);

            periodos = linea.getPeriodos();

            Assert.AreEqual(1, periodos.Count);

            var periodo = periodos[0];
            Assert.AreEqual(desde, periodo.desde);
            Assert.AreEqual(hasta, periodo.hasta);
        }

        [TestMethod]
        public void dos_periodos_que_se_pisan_se_transforman_en_uno()
        {
            LineaDeTiempo linea = new LineaDeTiempo();
            List<PeriodoDeTiempo> periodos = new List<PeriodoDeTiempo>();

            var desde = new DateTime(2000, 01, 01);
            var hasta = new DateTime(2010, 05, 01);

            var periodo1 = new PeriodoTrabajado(desde, new DateTime(2005, 01, 01), 29753914, publico);
            var periodo2 = new PeriodoTrabajado(new DateTime(2004, 01, 01), hasta, 29753914, publico);

            linea.agregarPeriodo(periodo1);
            linea.agregarPeriodo(periodo2);

            periodos = linea.getPeriodos();

            Assert.AreEqual(1, periodos.Count);

            var periodo = periodos[0];
            Assert.AreEqual(desde, periodo.desde);
            Assert.AreEqual(hasta, periodo.hasta);
        }

        [TestMethod]
        public void dos_periodos_que_se_no_pisan_quedan_igual()
        {
            LineaDeTiempo linea = new LineaDeTiempo();
            List<PeriodoDeTiempo> periodos = new List<PeriodoDeTiempo>();

            var desde = new DateTime(2000, 01, 01);
            var hasta = new DateTime(2010, 05, 01);

            var periodo1 = new PeriodoTrabajado(desde, new DateTime(2005, 01, 01), 29753914, publico);
            var periodo2 = new PeriodoTrabajado(new DateTime(2006, 01, 01), hasta, 29753914, publico);

            linea.agregarPeriodo(periodo1);
            linea.agregarPeriodo(periodo2);

            periodos = linea.getPeriodos();

            Assert.AreEqual(2, periodos.Count);

            var periodo = periodos[0];
            Assert.AreEqual(periodo1, periodos[0]);
            Assert.AreEqual(periodo2, periodos[1]);
        }


        [TestMethod]
        public void agregar_un_metodo_que_une_otros_dos_deberia_devolver_uno()
        {
            LineaDeTiempo linea = new LineaDeTiempo();
            List<PeriodoDeTiempo> periodos = new List<PeriodoDeTiempo>();

            var desde = new DateTime(2000, 01, 01);
            var hasta = new DateTime(2010, 05, 01);

            var periodo1 = new PeriodoTrabajado(desde, new DateTime(2005, 01, 01), 29753914, publico);
            var periodo2 = new PeriodoTrabajado(new DateTime(2006, 01, 01), hasta, 29753914, publico);
            var periodo3 = new PeriodoTrabajado(new DateTime(2004, 01, 01), new DateTime(2007, 01, 01), 29753914, publico);

            linea.agregarPeriodo(periodo1);
            linea.agregarPeriodo(periodo2);
            linea.agregarPeriodo(periodo3);

            periodos = linea.getPeriodos();

            Assert.AreEqual(1, periodos.Count);

            var periodo = periodos[0];
            Assert.AreEqual(periodo.desde, desde);
            Assert.AreEqual(periodo.hasta, hasta);
        }

        [TestMethod]
        public void deberian_ordenarse_los_periodos_segun_fecha_desde()
        {
            List<PeriodoTrabajado> periodos = new List<PeriodoTrabajado>();

            var periodo1 = new PeriodoTrabajado(new DateTime(2000, 01, 01), new DateTime(2000, 01, 01), 29753914, publico);
            var periodo2 = new PeriodoTrabajado(new DateTime(1998, 01, 01), new DateTime(2020, 03, 01), 29753914, publico);
            var periodo3 = new PeriodoTrabajado(new DateTime(1998, 01, 05), new DateTime(2000, 01, 01), 29753914, publico);

            periodos.Add(periodo1);
            periodos.Add(periodo2);
            periodos.Add(periodo3);

            periodos.Sort();

            Assert.AreEqual(periodo2, periodos[0]);
            Assert.AreEqual(periodo3, periodos[1]);
            Assert.AreEqual(periodo1, periodos[2]);

        }
    }
}
