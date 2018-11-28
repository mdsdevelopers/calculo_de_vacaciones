using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace CalculoDeVacaciones2010
{
    public class RepositorioEmpleadosSqlClient:IRepositorioEmpleados
    {

        private static IRepositorioEmpleados _instance = new RepositorioEmpleadosSqlClient();

        private List<Empleado> _empleados = new List<Empleado>();

        private RepositorioEmpleadosSqlClient() { }

        public static IRepositorioEmpleados instance()
        {
            return _instance;
        }

        public List<Empleado> getEmpleados()
        {
            if (_empleados.Count > 0) return _empleados;
            var coneccion = new ConeccionBaseDeDatos();
            
            //var reader = coneccion.getDataReader("dbo.ASIS_getEmpleados");
            var reader = coneccion.getDataReader("dbo.RH_Get_Dotacion_Completa_Calculo_Vacaciones");

            while (reader.Read())
            {
                var empleado = new Empleado(getInt("legajo", reader), getInt("documento", reader));
                empleado.fechaIngresoMinisterio = getDate("ingreso_ministerio", reader);
                _empleados.Add(empleado);
            };

            coneccion.cerrar();
            return _empleados;
        }

        private DateTime getDate(string nombreCampo, IDataReader reader)
        {
            var ordinal = reader.GetOrdinal(nombreCampo);
            return reader.GetDateTime(ordinal);
        }

        private int getInt(string nombreCampo, IDataReader reader)
        {
            var ordinal = reader.GetOrdinal(nombreCampo);
            var value = reader.GetDecimal(ordinal);
            return Int32.Parse(value.ToString());
        }
    }
}
