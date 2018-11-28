using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculoDeVacaciones2010;

namespace CalculoDeVacacionesTest
{
    [TestClass]
    public class TestCalculadoraAntiguedad
    {

        [TestMethod]
        public void deberia_decirme_antiguedad_de_un_dia_de_trabajo()
        {

            var periodo = new PeriodoDeTiempo(new DateTime(2009, 01, 01), new DateTime(2009, 01, 02));
            var calculadora = new CalculadoraAntiguedad();
            var antiguedad = calculadora.getAntiguedadGeneradaPor(periodo);

            Assert.AreEqual(new Antiguedad(0, 0, 1), antiguedad);

        }

        [TestMethod]
        public void deberia_decirme_antiguedad_de_un_mes_de_trabajo()
        {

            var periodo = new PeriodoDeTiempo(new DateTime(2009, 01, 01), new DateTime(2009, 02, 01));
            var calculadora = new CalculadoraAntiguedad();
            var antiguedad = calculadora.getAntiguedadGeneradaPor(periodo);

            Assert.AreEqual(new Antiguedad(0, 1, 0), antiguedad);
        }

        [TestMethod]
        public void deberia_decirme_antiguedad_de_un_año_de_trabajo()
        {

            var periodo = new PeriodoDeTiempo(new DateTime(2009, 01, 01), new DateTime(2010, 01, 01));
            var calculadora = new CalculadoraAntiguedad();
            var antiguedad = calculadora.getAntiguedadGeneradaPor(periodo);

            Assert.AreEqual(new Antiguedad(1, 0, 0), antiguedad);
        }


        [TestMethod]
        public void deberia_decirme_antiguedad_de_un_mes_aunque_cambie_de_año()
        {

            var periodo = new PeriodoDeTiempo(new DateTime(2009, 12, 01), new DateTime(2010, 01, 01));
            var calculadora = new CalculadoraAntiguedad();
            var antiguedad = calculadora.getAntiguedadGeneradaPor(periodo);

            Assert.AreEqual(new Antiguedad(0, 2, 0), antiguedad);
        }

        [TestMethod]
        public void deberia_decirme_antiguedad_de_quince_dias_aunque_cambie_de_mes()
        {

            var periodo = new PeriodoDeTiempo(new DateTime(2010, 04, 20), new DateTime(2010, 05, 4));
            var calculadora = new CalculadoraAntiguedad();
            var antiguedad = calculadora.getAntiguedadGeneradaPor(periodo);

            Assert.AreEqual(new Antiguedad(0, 0, 15), antiguedad);
        }

        [TestMethod]
        public void deberia_decirme_antiguedad_de_quince_dias_aunque_cambie_de_mes_de_31_dias()
        {

            var periodo = new PeriodoDeTiempo(new DateTime(2010, 05, 20), new DateTime(2010, 06, 4));
            var calculadora = new CalculadoraAntiguedad();
            var antiguedad = calculadora.getAntiguedadGeneradaPor(periodo);

            Assert.AreEqual(new Antiguedad(0, 0, 16), antiguedad);
        }

        [TestMethod]
        public void deberia_decirme_antiguedad_en_periodos_de_varios_años()
        {

            var periodo = new PeriodoDeTiempo(new DateTime(1998, 08, 20), new DateTime(2010, 06, 4));
            var calculadora = new CalculadoraAntiguedad();
            var antiguedad = calculadora.getAntiguedadGeneradaPor(periodo);

            Assert.AreEqual(new Antiguedad(11, 9, 16), antiguedad);
        }

        [TestMethod]
        public void deberia_sumar_un_año_cuando_hay_mas_de_doce_meses()
        {
            var periodo = new PeriodoDeTiempo(new DateTime(1998, 05, 20), new DateTime(2010, 09, 4));
            var calculadora = new CalculadoraAntiguedad();
            var antiguedad = calculadora.getAntiguedadGeneradaPor(periodo);

            Assert.AreEqual(new Antiguedad(12, 3, 16), antiguedad);
        }

        [TestMethod]
        public void deberia_sumar_dias_de_antiguedad()
        {
            var antiguedad1 = new Antiguedad(0, 0, 4);
            var antiguedad2 = new Antiguedad(0, 0, 8);

            var calculadora = new CalculadoraAntiguedad();

            var antiguedadTotal = calculadora.sumarAntiguedades(antiguedad1, antiguedad2);

            Assert.AreEqual(new Antiguedad(0, 0, 12), antiguedadTotal);
        }

        [TestMethod]
        public void deberia_sumar_meses_de_antiguedad()
        {
            var antiguedad1 = new Antiguedad(0, 8, 0);
            var antiguedad2 = new Antiguedad(0, 2, 0);

            var calculadora = new CalculadoraAntiguedad();

            var antiguedadTotal = calculadora.sumarAntiguedades(antiguedad1, antiguedad2);

            Assert.AreEqual(new Antiguedad(0, 10, 0), antiguedadTotal);
        }

        [TestMethod]
        public void deberia_sumar_años_de_antiguedad()
        {
            var antiguedad1 = new Antiguedad(8, 0, 0);
            var antiguedad2 = new Antiguedad(11, 0, 0);

            var calculadora = new CalculadoraAntiguedad();

            var antiguedadTotal = calculadora.sumarAntiguedades(antiguedad1, antiguedad2);

            Assert.AreEqual(new Antiguedad(19, 0, 0), antiguedadTotal);
        }

        [TestMethod]
        public void deberia_sumar_un_año_si_sobrepasa_doce_meses()
        {
            var antiguedad1 = new Antiguedad(8, 9, 0);
            var antiguedad2 = new Antiguedad(11, 9, 0);

            var calculadora = new CalculadoraAntiguedad();

            var antiguedadTotal = calculadora.sumarAntiguedades(antiguedad1, antiguedad2);

            Assert.AreEqual(new Antiguedad(20, 6, 0), antiguedadTotal);
        }

        [TestMethod]
        public void deberia_sumar_un_año_si_iguala_doce_meses()
        {
            var antiguedad1 = new Antiguedad(8, 6, 0);
            var antiguedad2 = new Antiguedad(11, 6, 0);

            var calculadora = new CalculadoraAntiguedad();

            var antiguedadTotal = calculadora.sumarAntiguedades(antiguedad1, antiguedad2);

            Assert.AreEqual(new Antiguedad(20, 0, 0), antiguedadTotal);
        }

        [TestMethod]
        public void deberia_sumar_un_mes_si_sobrepasa_treinta_dias()
        {
            var antiguedad1 = new Antiguedad(0, 2, 15);
            var antiguedad2 = new Antiguedad(0, 2, 18);

            var calculadora = new CalculadoraAntiguedad();

            var antiguedadTotal = calculadora.sumarAntiguedades(antiguedad1, antiguedad2);

            Assert.AreEqual(new Antiguedad(0, 5, 3), antiguedadTotal);
        }

        [TestMethod]
        public void deberia_sumar_un_mes_si_iguala_treinta_dias()
        {
            var antiguedad1 = new Antiguedad(0, 2, 15);
            var antiguedad2 = new Antiguedad(0, 2, 15);

            var calculadora = new CalculadoraAntiguedad();

            var antiguedadTotal = calculadora.sumarAntiguedades(antiguedad1, antiguedad2);

            Assert.AreEqual(new Antiguedad(0, 5, 0), antiguedadTotal);
        }
    }
}