using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculoDeVacaciones2010;

namespace CalculoDeVacacionesTest
{
    [TestClass]
    public class TestContrato
    {
        [TestMethod]
        public void deberia_saber_si_esta_vencido_a_una_fecha()
        {
            var contrato = new Contrato();
            contrato.desde = new DateTime(2001, 01, 01);
            contrato.hasta = new DateTime(2001, 12, 31);

            Assert.IsTrue(contrato.estaVencidoAl(new DateTime(2002, 01, 01)));
            Assert.IsFalse(contrato.estaVencidoAl(new DateTime(2001, 01, 01)));
        }

        [TestMethod]
        public void deberia_saber_si_esta_de_baja()
        {
            var contrato = new Contrato();
            contrato.estaDeBaja = true;

            Assert.IsTrue(contrato.estaDeBaja);
        }

        [TestMethod]
        public void deberia_saber_si_esta_aprobado()
        {
            var contrato = new Contrato();
            contrato.estaAprobado = true;

            Assert.IsTrue(contrato.estaAprobado);
        }

        [TestMethod]
        public void deberia_saber_si_es_el_primero_de_una_persona()
        {
            var contrato = new Contrato();
            contrato.numero = "01-4284003";

            Assert.IsTrue(contrato.esElPrimeroDeLaPersona());
        }

        [TestMethod]
        public void deberia_saber_si_no_es_el_primero_de_una_persona()
        {
            var contrato = new Contrato();
            contrato.numero = "02-4284003";

            Assert.IsFalse(contrato.esElPrimeroDeLaPersona());
        }
    }
}
