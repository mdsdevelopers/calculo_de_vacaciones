using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculoDeVacaciones2010;

namespace CalculoDeVacacionesTest
{
    [TestClass]
    public class TestPeriodoDeTiempo
    {
        [TestMethod]
        public void dos_periodos_deberian_saber_que_no_se_pisan()
        {
            var periodo1 = new PeriodoDeTiempo(new DateTime(2008, 01, 01), new DateTime(2010, 10, 05));
            var periodo2 = new PeriodoDeTiempo(new DateTime(2000, 07, 01), new DateTime(2001, 02, 05));
            Assert.IsFalse(periodo1.sePisaCon(periodo2));
            Assert.IsFalse(periodo2.sePisaCon(periodo1));
        }


        [TestMethod]
        public void dos_periodos_deberian_saber_que_se_pisan_si_son_iguales()
        {
            var desde = new DateTime(2010, 01, 01);
            var hasta = new DateTime(2010, 05, 01);

            var periodo1 = new PeriodoDeTiempo(desde, hasta);
            var periodo2 = new PeriodoDeTiempo(desde, hasta);

            Assert.IsTrue(periodo1.sePisaCon(periodo2));
            Assert.IsTrue(periodo2.sePisaCon(periodo1));
        }

        [TestMethod]
        public void dos_periodos_deberian_saber_que_se_pisan_si_se_superponen_en_parte()
        {
            var periodo1 = new PeriodoDeTiempo(new DateTime(2008, 01, 01), new DateTime(2010, 10, 05));
            var periodo2 = new PeriodoDeTiempo(new DateTime(2009, 07, 01), new DateTime(2011, 02, 05));
            Assert.IsTrue(periodo1.sePisaCon(periodo2));
            Assert.IsTrue(periodo2.sePisaCon(periodo1));
        }

        [TestMethod]
        public void dos_periodos_deberian_saber_que_se_pisan_si_uno_incluye_al_otro()
        {
            var periodo1 = new PeriodoDeTiempo(new DateTime(2008, 01, 01), new DateTime(2010, 10, 05));
            var periodo2 = new PeriodoDeTiempo(new DateTime(2009, 02, 01), new DateTime(2009, 02, 05));
            Assert.IsTrue(periodo1.sePisaCon(periodo2));
            Assert.IsTrue(periodo2.sePisaCon(periodo1));
        }

        [TestMethod]
        public void un_periodo_deberia_poder_unirse_a_otro_que_pisa_al_principio()
        {
            var inicio = new DateTime(2008, 01, 01);
            var fin = new DateTime(2011, 02, 05);

            var periodo1 = new PeriodoDeTiempo(inicio, new DateTime(2010, 10, 05));
            var periodo2 = new PeriodoDeTiempo(new DateTime(2009, 07, 01), fin);

            periodo1.unirCon(periodo2);

            Assert.AreEqual(periodo1.desde, inicio);
            Assert.AreEqual(periodo1.hasta, fin);
        }

        [TestMethod]
        public void un_periodo_deberia_poder_unirse_a_otro_que_pisa_al_final()
        {
            var inicio = new DateTime(2008, 01, 01);
            var fin = new DateTime(2011, 02, 05);

            var periodo1 = new PeriodoDeTiempo(inicio, new DateTime(2010, 10, 05));
            var periodo2 = new PeriodoDeTiempo(new DateTime(2009, 07, 01), fin);

            periodo2.unirCon(periodo1);

            Assert.AreEqual(periodo2.desde, inicio);
            Assert.AreEqual(periodo2.hasta, fin);
        }

        [TestMethod]
        public void un_periodo_deberia_poder_unirse_a_otro_que_lo_contiene()
        {
            var inicio = new DateTime(2008, 01, 01);
            var fin = new DateTime(2011, 02, 05);

            var periodo1 = new PeriodoDeTiempo(inicio, fin);
            var periodo2 = new PeriodoDeTiempo(new DateTime(2009, 07, 01), new DateTime(2010, 07, 01));

            periodo2.unirCon(periodo1);

            Assert.AreEqual(periodo2.desde, inicio);
            Assert.AreEqual(periodo2.hasta, fin);
        }

        [TestMethod]
        public void un_periodo_deberia_poder_unirse_a_otro_al_que_contiene()
        {
            var inicio = new DateTime(2008, 01, 01);
            var fin = new DateTime(2011, 02, 05);

            var periodo1 = new PeriodoDeTiempo(inicio, fin);
            var periodo2 = new PeriodoDeTiempo(new DateTime(2009, 07, 01), new DateTime(2010, 07, 01));

            periodo1.unirCon(periodo2);

            Assert.AreEqual(periodo1.desde, inicio);
            Assert.AreEqual(periodo1.hasta, fin);
        }

        [TestMethod]
        public void un_periodo_deberia_poder_unirse_a_otro_que_pisa()
        {
            var inicio = new DateTime(2008, 01, 01);
            var fin = new DateTime(2011, 02, 05);

            var periodo1 = new PeriodoDeTiempo(inicio, new DateTime(2010, 10, 05));
            var periodo2 = new PeriodoDeTiempo(new DateTime(2009, 07, 01), fin);

            periodo1.unirCon(periodo2);

            Assert.AreEqual(periodo1.desde, inicio);
            Assert.AreEqual(periodo1.hasta, fin);
        }

        

    }
}
