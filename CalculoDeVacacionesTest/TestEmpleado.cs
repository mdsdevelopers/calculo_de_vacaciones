using CalculoDeVacaciones2010;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System;

namespace CalculoDeVacacionesTest
{
    [TestClass]
    public class TestEmpleado
    {
        ITipoDeTrabajo publico = new TipoDeTrabajoPublico();
        ITipoDeTrabajo privado = new TipoDeTrabajoPrivado();


        [TestMethod]
        public void deberia_saber_sus_periodos_trabajados()
        {
            var empleado = new Empleado(10, 10);
            empleado.periodosTrabajadosAntesDelMinisterio.Add( new PeriodoTrabajado(new DateTime(), new DateTime(), 10, new TipoDeTrabajoPublico()));
            List<PeriodoTrabajado> periodos = empleado.periodosTrabajadosAntesDelMinisterio;
            Assert.AreEqual(1, periodos.Count);
        }

        [TestMethod]
        public void deberia_conocer_su_antiguedad_publica_y_privada()
        {
            var legajoEmpleado = 202201;
            var periodosTrabajados = new List<PeriodoTrabajado>();

            periodosTrabajados.Add(new PeriodoTrabajado(new DateTime(2001, 01, 01), new DateTime(2004, 01, 01), legajoEmpleado, publico));
            periodosTrabajados.Add(new PeriodoTrabajado(new DateTime(2003, 01, 01), new DateTime(2006, 01, 01), legajoEmpleado, publico));
            periodosTrabajados.Add(new PeriodoTrabajado(new DateTime(2009, 01, 01), new DateTime(2010, 01, 01), legajoEmpleado, publico));

            periodosTrabajados.Add(new PeriodoTrabajado(new DateTime(2001, 01, 01), new DateTime(2010, 01, 01), legajoEmpleado, privado));
            periodosTrabajados.Add(new PeriodoTrabajado(new DateTime(2005, 01, 01), new DateTime(2008, 01, 01), legajoEmpleado, privado));

            var empleado = new Empleado(legajoEmpleado, 29753914);
            empleado.periodosTrabajadosAntesDelMinisterio = periodosTrabajados;
            empleado.fechaIngresoMinisterio = new DateTime(2000, 01, 01);
            
            var antiguedadPublica = empleado.getAntiguedadPublica();
            var antiguedadPrivada = empleado.getAntiguedadPrivada();

            Assert.AreEqual(new Antiguedad(6, 0, 0), antiguedadPublica);
            Assert.AreEqual(new Antiguedad(9, 0, 0), antiguedadPrivada);
        }

        [TestMethod]
        public void deberia_conocer_su_historial_de_areas()
        {
            var empleado = new Empleado(101202, 29753914);
            var historialDeAreas = new List<DesignacionDeArea>();

            var area1 = new Area("RRHH");
            var area2 = new Area("Capacitacion");

            historialDeAreas.Add(new DesignacionDeArea(area1, new DateTime(2000, 01, 01)));
            historialDeAreas.Add(new DesignacionDeArea(area2, new DateTime(2005, 01, 01)));

            empleado.historialDesignacionesDeAreas = historialDeAreas;

            Assert.AreEqual(2, empleado.historialDesignacionesDeAreas.Count);

            Assert.AreEqual("RRHH", empleado.historialDesignacionesDeAreas[0].nombreArea());
            Assert.AreEqual(new DateTime(2000, 01, 01), empleado.historialDesignacionesDeAreas[0].fecha);
            Assert.AreEqual("Capacitacion", empleado.historialDesignacionesDeAreas[1].nombreArea());
            Assert.AreEqual(new DateTime(2005, 01, 01), empleado.historialDesignacionesDeAreas[1].fecha);
        }

        [TestMethod]
        public void deberia_conocer_su_historial_de_plantas()
        {
            var empleado = new Empleado(101202, 29753914);
            var historialDePlantas = new List<DesignacionDePlanta>();

            var planta1 = new TipoDePlanta("Permanente");
            var planta2 = new TipoDePlanta("Gab Ases UR");

            historialDePlantas.Add(new DesignacionDePlanta(planta1, new DateTime(2000, 01, 01)));
            historialDePlantas.Add(new DesignacionDePlanta(planta2, new DateTime(2005, 01, 01)));

            empleado.historialDesignacionesDePlantas = historialDePlantas;

            Assert.AreEqual(2, empleado.historialDesignacionesDePlantas.Count);

            Assert.AreEqual("Permanente", empleado.historialDesignacionesDePlantas[0].nombrePlanta());
            Assert.AreEqual(new DateTime(2000, 01, 01), empleado.historialDesignacionesDePlantas[0].fecha);
            Assert.AreEqual("Gab Ases UR", empleado.historialDesignacionesDePlantas[1].nombrePlanta());
            Assert.AreEqual(new DateTime(2005, 01, 01), empleado.historialDesignacionesDePlantas[1].fecha);
        }

        [TestMethod]
        public void deberia_conocer_su_historial_de_nivel_y_grado()
        {
            var empleado = new Empleado(101202, 29753914);
            var historialDeNivelYGrado = new List<DesignacionDeNivelYGrado>();

            var nivelYGrado1 = new NivelYGrado("A", "1");
            var nivelYGrado2 = new NivelYGrado("B", "2");

            historialDeNivelYGrado.Add(new DesignacionDeNivelYGrado(nivelYGrado1, new DateTime(2000, 01, 01)));
            historialDeNivelYGrado.Add(new DesignacionDeNivelYGrado(nivelYGrado2, new DateTime(2005, 01, 01)));

            empleado.historialDesignacionesDeNivelYGrado = historialDeNivelYGrado;

            Assert.AreEqual(2, empleado.historialDesignacionesDeNivelYGrado.Count);

            Assert.AreEqual("A", empleado.historialDesignacionesDeNivelYGrado[0].nivel());
            Assert.AreEqual("1", empleado.historialDesignacionesDeNivelYGrado[0].grado());
            Assert.AreEqual(new DateTime(2000, 01, 01), empleado.historialDesignacionesDeNivelYGrado[0].fecha);
            Assert.AreEqual("B", empleado.historialDesignacionesDeNivelYGrado[1].nivel());
            Assert.AreEqual("2", empleado.historialDesignacionesDeNivelYGrado[1].grado());
            Assert.AreEqual(new DateTime(2005, 01, 01), empleado.historialDesignacionesDeNivelYGrado[1].fecha);
        }


        [TestMethod]
        public void deberia_conocer_sus_contratos()
        {
            var empleado = new Empleado(101202, 29753914);
            var historialDeContratos = new List<Contrato>();

            historialDeContratos.Add(new Contrato());

            empleado.historialDeContratos = historialDeContratos;

            Assert.AreEqual(1, empleado.historialDeContratos.Count);
        }


        [TestMethod]
        public void deberia_conocer_su_area_actual()
        {

            var fechaActual = new DateTime(2010, 10, 21);
            var empleado = new Empleado(101202, 29753914);
            var historialDeAreas = new List<DesignacionDeArea>();

            var area1 = new Area("RRHH");
            var area2 = new Area("Capacitacion");

            historialDeAreas.Add(new DesignacionDeArea(area2, new DateTime(2005, 01, 01)));
            historialDeAreas.Add(new DesignacionDeArea(area1, new DateTime(2000, 01, 01)));
            
            empleado.historialDesignacionesDeAreas = historialDeAreas;

            var areaActual = empleado.areaAl(fechaActual);

            Assert.AreEqual(area2, areaActual);
        }


        [TestMethod]
        public void deberia_conocer_su_nivel_y_grado_actuales()
        {

            var fechaActual = new DateTime(2010, 10, 21);

            var empleado = new Empleado(101202, 29753914);
            var historialDeNivelYGrado = new List<DesignacionDeNivelYGrado>();

            var nivelYGrado1 = new NivelYGrado("A", "1");
            var nivelYGrado2 = new NivelYGrado("B", "2");

            historialDeNivelYGrado.Add(new DesignacionDeNivelYGrado(nivelYGrado1, new DateTime(2000, 01, 01)));
            historialDeNivelYGrado.Add(new DesignacionDeNivelYGrado(nivelYGrado2, new DateTime(2005, 01, 01)));

            empleado.historialDesignacionesDeNivelYGrado = historialDeNivelYGrado;

            var nivelYGradoActual = empleado.getNivelYGradoAl(fechaActual);

            Assert.AreEqual(nivelYGrado2, nivelYGradoActual);

        }

        [TestMethod]
        public void deberia_conocer_su_planta_actual()
        {

            var fechaActual = new DateTime(2010, 10, 21);

            var empleado = new Empleado(101202, 29753914);
            var historialDePlantas = new List<DesignacionDePlanta>();

            var planta1 = new TipoDePlanta("Permanente");
            var planta2 = new TipoDePlanta("Gab Ases UR");

            historialDePlantas.Add(new DesignacionDePlanta(planta1, new DateTime(2005, 01, 01)));
            historialDePlantas.Add(new DesignacionDePlanta(planta2, new DateTime(2000, 01, 01)));

            empleado.historialDesignacionesDePlantas = historialDePlantas;

            var plantaActual = empleado.getPlantaAl(fechaActual);

            Assert.AreEqual(planta1, plantaActual);
        }
    }
}
