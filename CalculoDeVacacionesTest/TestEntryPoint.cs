using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculoDeVacaciones2010;

namespace CalculoDeVacacionesTest
{
    [TestClass]
    public class TestEntryPoint
    {
        [TestMethod]
        public void test()
        {
            var entry = new EntryPoint();
            var vacaciones = entry.calcularVacaciones();
            Assert.AreNotEqual(0, vacaciones.Count);
        }
    }
}