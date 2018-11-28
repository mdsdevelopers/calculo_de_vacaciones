using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculoDeVacaciones2010;

namespace CalculoDeVacacionesTest
{
    [TestClass]
    public class TestCalculadoraVacaciones
    {

        CalculadoraVacaciones calculadora = new CalculadoraVacaciones();
        int añoDeCalculo = 2010;

        [TestMethod]
        public void deberia_calcular_35_dias_con_mas_de_15_años_en_publica()
        {
            var empleado = new GeneradorDeEmpleados().getEmpleadoConAntiguedad(new Antiguedad(15, 0, 1));
            var dias = calculadora.calcularDiasPara(empleado, añoDeCalculo);

            Assert.AreEqual(35, dias);
        }

        [TestMethod]
        public void deberia_calcular_35_dias_con_15_años_en_publica()
        {
            var empleado = new GeneradorDeEmpleados().getEmpleadoConAntiguedad(new Antiguedad(15, 0, 0));
            var dias = calculadora.calcularDiasPara(empleado, añoDeCalculo);

            Assert.AreEqual(35, dias);
        }

        [TestMethod]
        public void deberia_calcular_30_dias_con_10_años_en_publica()
        {
            var empleado = new GeneradorDeEmpleados().getEmpleadoConAntiguedad(new Antiguedad(10, 0, 0));
            var dias = calculadora.calcularDiasPara(empleado, añoDeCalculo);

            Assert.AreEqual(30, dias);
        }

        [TestMethod]
        public void deberia_calcular_30_dias_con_mas_de_10_años_en_publica()
        {
            var empleado = new GeneradorDeEmpleados().getEmpleadoConAntiguedad(new Antiguedad(12, 0, 0));
            var dias = calculadora.calcularDiasPara(empleado, añoDeCalculo);

            Assert.AreEqual(30, dias);
        }

        [TestMethod]
        public void deberia_calcular_25_dias_con_mas_de_5_años_en_publica()
        {
            var empleado = new GeneradorDeEmpleados().getEmpleadoConAntiguedad(new Antiguedad(7, 0, 0));
            var dias = calculadora.calcularDiasPara(empleado, añoDeCalculo);

            Assert.AreEqual(25, dias);
        }

        [TestMethod]
        public void deberia_calcular_25_dias_con_5_años_en_publica()
        {
            var empleado = new GeneradorDeEmpleados().getEmpleadoConAntiguedad(new Antiguedad(5, 0, 0));
            var dias = calculadora.calcularDiasPara(empleado, añoDeCalculo);

            Assert.AreEqual(25, dias);
        }

        [TestMethod]
        public void deberia_calcular_20_dias_con_1_año_en_publica()
        {
            var empleado = new GeneradorDeEmpleados().getEmpleadoConAntiguedad(new Antiguedad(1, 0, 0));
            var dias = calculadora.calcularDiasPara(empleado, añoDeCalculo);

            Assert.AreEqual(20, dias);
        }


        [TestMethod]
        public void deberia_calcular_20_dias_con_mas_de_1_año_en_publica()
        {
            var empleado = new GeneradorDeEmpleados().getEmpleadoConAntiguedad(new Antiguedad(2, 0, 0));
            var dias = calculadora.calcularDiasPara(empleado, añoDeCalculo);

            Assert.AreEqual(20, dias);
        }

        [TestMethod]
        public void deberia_calcular_0_dias_para_empleados_con_menos_de_3_meses_en_mds()
        {
            var empleado = new GeneradorDeEmpleados().getEmpleadoConAntiguedad(new Antiguedad(25, 0, 0));
            empleado.fechaIngresoMinisterio = new DateTime(2010, 10, 02);
            var dias = calculadora.calcularDiasPara(empleado, añoDeCalculo);

            Assert.AreEqual(0, dias);
        }

        [TestMethod]
        public void deberia_devolver_el_proporcional_para_empleados_antiguos_con_3_meses()
        {
            var empleado = new GeneradorDeEmpleados().getEmpleadoConAntiguedad(new Antiguedad(25, 0, 0));
            empleado.fechaIngresoMinisterio = new DateTime(2010, 10, 01);
            var dias = calculadora.calcularDiasPara(empleado, añoDeCalculo);

            Assert.AreEqual(9, dias);
        }

        [TestMethod]
        public void deberia_devolver_el_proporcional_para_empleados_nuevos_con_3_meses()
        {
            var empleado = new GeneradorDeEmpleados().getEmpleadoConAntiguedad(new Antiguedad(0, 0, 0));
            empleado.fechaIngresoMinisterio = new DateTime(2010, 10, 01);
            var dias = calculadora.calcularDiasPara(empleado, añoDeCalculo);
            Assert.AreEqual(5, dias);
        }

        [TestMethod]
        public void deberia_descartar_periodos_privados_para_ingresados_posteriores_al_2006()
        {
            var empleado = new GeneradorDeEmpleados().getEmpleadoConAntiguedad(new Antiguedad(1, 0, 0));
            empleado.periodosTrabajadosAntesDelMinisterio.Add(
                new PeriodoTrabajado(new DateTime(1980, 01, 01), new DateTime(1990, 01, 01), empleado.legajo, new TipoDeTrabajoPrivado()));
            empleado.fechaIngresoMinisterio = new DateTime(2007, 01, 01); // posterior al 2006
            var dias = calculadora.calcularDiasPara(empleado, añoDeCalculo);
            Assert.AreEqual(20, dias);
        }

        [TestMethod]
        public void deberia_tener_en_cuenta_periodos_privados_para_ingresados_anteriores_al_2006()
        {
            var empleado = new GeneradorDeEmpleados().getEmpleadoConAntiguedad(new Antiguedad(1, 0, 0));
            empleado.periodosTrabajadosAntesDelMinisterio.Add(
                new PeriodoTrabajado(new DateTime(1980, 01, 01), new DateTime(1990, 01, 01), empleado.legajo, new TipoDeTrabajoPrivado()));
            empleado.fechaIngresoMinisterio = new DateTime(2005, 01, 01); // anterior al 2006
            var dias = calculadora.calcularDiasPara(empleado, añoDeCalculo);
            Assert.AreEqual(30, dias);
        }
    }
}
