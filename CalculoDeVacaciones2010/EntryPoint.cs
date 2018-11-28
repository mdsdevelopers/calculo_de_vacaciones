using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace CalculoDeVacaciones2010
{
    public class EntryPoint
    {
        public List<AutorizacionLicencia> calcularVacaciones() {
            var añoDeCalculo = 2010;
            var calculadora = new CalculadoraVacaciones();
            var repoEmpleados = RepositorioEmpleadosSqlClient.instance();
            var repoPeriodos = RepositorioPeriodosTrabajadosSqlClient.instance();
            repoPeriodos.fechaLimite = new DateTime(2010, 12, 31);
            var empleados = repoEmpleados.getEmpleados();
            
            var autorizaciones = new List<AutorizacionLicencia>();

            empleados.ForEach(empleado => empleado.periodosTrabajadosAntesDelMinisterio = repoPeriodos.getPeriodosPorLegajo(empleado.legajo));
            empleados.ForEach(empleado => autorizaciones.Add(new AutorizacionLicencia(empleado.legajo, calculadora.calcularDiasPara(empleado, añoDeCalculo))));

            insertarAutorizaciones(autorizaciones);
            
            return autorizaciones;
        }

        private void insertarAutorizaciones(List<AutorizacionLicencia> autorizaciones)
        {
            var coneccion = new ConeccionBaseDeDatos();
            coneccion.Abrir();
            autorizaciones.ForEach(auth => insertarAutorizacion(coneccion, auth));
        }


        public void insertarAutorizacion(ConeccionBaseDeDatos coneccion, AutorizacionLicencia autorizacion) {
            
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "dbo.InsertarAutorizacion";
            var legajo = new SqlParameter("@Legajo", autorizacion.Legajo);
            var dias = new SqlParameter("@Dias", autorizacion.Dias);
            comando.Parameters.Add(legajo);
            comando.Parameters.Add(dias);
            coneccion.Ejecutar(comando);
        }
    }
}
