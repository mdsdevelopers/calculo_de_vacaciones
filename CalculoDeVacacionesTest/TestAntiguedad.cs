using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculoDeVacaciones2010;

namespace CalculoDeVacacionesTest
{
    [TestClass]
    public class TestAntiguedad
    {
        [TestMethod]
        public void deberia_comparar_dos_antiguedades_iguales()
        {
            var a1 = new Antiguedad(3, 3, 3);
            var a2 = new Antiguedad(3, 3, 3);

            Assert.IsTrue(a1 == a2);
            Assert.IsFalse(a1 != a2);
            Assert.IsFalse(a1 < a2);
            Assert.IsTrue(a1 <= a2);
            Assert.IsFalse(a1 > a2);
            Assert.IsTrue(a1 >= a2);
        }

        [TestMethod]
        public void deberia_comparar_cuando_una_antiguedad_tiene_mas_dias()
        {
            var a1 = new Antiguedad(3, 3, 3);
            var a2 = new Antiguedad(3, 3, 4);

            Assert.IsFalse(a1 == a2);
            Assert.IsTrue(a1 != a2);
            Assert.IsTrue(a1 < a2);
            Assert.IsTrue(a1 <= a2);
            Assert.IsFalse(a1 > a2);
            Assert.IsFalse(a1 >= a2);
        }

        [TestMethod]
        public void deberia_comparar_cuando_una_antiguedad_tiene_mas_meses()
        {
            var a1 = new Antiguedad(3, 3, 3);
            var a2 = new Antiguedad(3, 4, 1);

            Assert.IsFalse(a1 == a2);
            Assert.IsTrue(a1 != a2);
            Assert.IsTrue(a1 < a2);
            Assert.IsTrue(a1 <= a2);
            Assert.IsFalse(a1 > a2);
            Assert.IsFalse(a1 >= a2);
        }

        [TestMethod]
        public void deberia_comparar_cuando_una_antiguedad_tiene_mas_años()
        {
            var a1 = new Antiguedad(3, 3, 3);
            var a2 = new Antiguedad(4, 0, 0);

            Assert.IsFalse(a1 == a2);
            Assert.IsTrue(a1 != a2);
            Assert.IsTrue(a1 < a2);
            Assert.IsTrue(a1 <= a2);
            Assert.IsFalse(a1 > a2);
            Assert.IsFalse(a1 >= a2);
        }
    }
}
