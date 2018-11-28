using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculoDeVacaciones2010
{
    public class Empleado
    {
        public int legajo { get; set; }
        public int nroDocumento { get; set; }
        public List<PeriodoTrabajado> periodosTrabajadosAntesDelMinisterio { get; set; }
        public DateTime fechaIngresoMinisterio { get; set; }
        public List<DesignacionDeArea> historialDesignacionesDeAreas { get; set; }
        public List<DesignacionDePlanta> historialDesignacionesDePlantas { get; set; }
        public List<DesignacionDeNivelYGrado> historialDesignacionesDeNivelYGrado { get; set; }
        public List<Contrato> historialDeContratos { get; set; }

        public Empleado(int legajo, int nroDocumento)
        {
            this.legajo = legajo;
            this.nroDocumento = nroDocumento;
            this.periodosTrabajadosAntesDelMinisterio = new List<PeriodoTrabajado>();
        }

        public Antiguedad getAntiguedadPublica()
        {
            return this.getAntiguedadAPartirDe(this.periodosTrabajadosAntesDelMinisterio.FindAll(periodo => periodo.esPublico()));
        }

        public Antiguedad getAntiguedadPrivada()
        {
            return this.getAntiguedadAPartirDe(this.periodosTrabajadosAntesDelMinisterio.FindAll(periodo => periodo.esPrivado()));
        }

        private Antiguedad getAntiguedadAPartirDe(List<PeriodoTrabajado> periodos)
        {
            var calculadora = new CalculadoraAntiguedad();
            return calculadora.calcularAntiguedadPara(periodos);
        }

        public Antiguedad getAntiguedadEnElMinisterioAl(DateTime fechaDeCalculo)
        {
            var calculadora = new CalculadoraAntiguedad();
            var periodoActual = new PeriodoTrabajado(this.fechaIngresoMinisterio, fechaDeCalculo, this.legajo, new TipoDeTrabajoPublico());
            return calculadora.getAntiguedadGeneradaPor(periodoActual);
        }

        public Area areaAl(DateTime fechaActual)
        {
            this.historialDesignacionesDeAreas.Sort();
            return historialDesignacionesDeAreas.Last(des => des.fecha < fechaActual).area;
        }

        public object getNivelYGradoAl(DateTime fechaActual)
        {
            this.historialDesignacionesDeNivelYGrado.Sort();
            return historialDesignacionesDeNivelYGrado.Last(des => des.fecha < fechaActual).nivelYGrado;
        }

        public object getPlantaAl(DateTime fechaActual)
        {
            this.historialDesignacionesDePlantas.Sort();
            return historialDesignacionesDePlantas.Last(des => des.fecha < fechaActual).tipoDePlanta;
        }
    }
}