using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculoDeVacaciones2010;

namespace CalculoDeVacacionesTest
{
    /// <summary>
    /// Descripción resumida de TestFiltroPeriodosTrabajados
    /// </summary>
    [TestClass]
    public class TestFiltroPeriodosTrabajados
    {
        [TestMethod]
        public void deberia_filtrar_periodos_privados_a_quienes_entraron_despues_de_marzo_del_2006()
        {
            var periodos = new List<PeriodoTrabajado>();
            var periodo1 = new PeriodoTrabajado(new DateTime(2000, 01, 01), new DateTime(2005, 01, 01), 101202, new TipoDeTrabajoPrivado());
            var periodo2 = new PeriodoTrabajado(new DateTime(2005, 01, 01), new DateTime(2010, 01, 01), 101202, new TipoDeTrabajoPublico());

            periodos.Add(periodo1);
            periodos.Add(periodo2);

            var empleado = new Empleado(101202, 29753914);
            empleado.periodosTrabajadosAntesDelMinisterio = periodos;
            empleado.fechaIngresoMinisterio = new DateTime(2007, 01, 01);
            var filtro = new FiltroPeriodosTrabajados();
            var periodosConsiderados = filtro.filtrarPeriodosPara(empleado);

            Assert.IsFalse(periodosConsiderados.Contains(periodo1));
            Assert.IsTrue(periodosConsiderados.Contains(periodo2));
        }

        [TestMethod]
        public void no_deberia_filtrar_periodos_privados_a_quienes_entraron_antes_de_marzo_del_2006()
        {
            var periodos = new List<PeriodoTrabajado>();
            var periodo1 = new PeriodoTrabajado(new DateTime(2000, 01, 01), new DateTime(2005, 01, 01), 101202, new TipoDeTrabajoPrivado());
            var periodo2 = new PeriodoTrabajado(new DateTime(2005, 01, 01), new DateTime(2010, 01, 01), 101202, new TipoDeTrabajoPublico());

            periodos.Add(periodo1);
            periodos.Add(periodo2);

            var empleado = new Empleado(101202, 29753914);
            empleado.periodosTrabajadosAntesDelMinisterio = periodos;
            empleado.fechaIngresoMinisterio = new DateTime(2001, 01, 01);

            //, periodos, new DateTime(2001, 01, 01));
            var filtro = new FiltroPeriodosTrabajados();
            var periodosConsiderados = filtro.filtrarPeriodosPara(empleado);

            Assert.IsTrue(periodosConsiderados.Contains(periodo1));
            Assert.IsTrue(periodosConsiderados.Contains(periodo2));
        }

    }
}
