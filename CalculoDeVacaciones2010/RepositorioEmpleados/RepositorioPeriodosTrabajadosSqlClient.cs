using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CalculoDeVacaciones2010
{
    public class RepositorioPeriodosTrabajadosSqlClient : IRepositorioPeriodosTrabajados
    {

        private static IRepositorioPeriodosTrabajados _instance = new RepositorioPeriodosTrabajadosSqlClient();

        public DateTime fechaLimite { get; set; }
        List<PeriodoTrabajado> _periodos = new List<PeriodoTrabajado>();


        private RepositorioPeriodosTrabajadosSqlClient() { }

        public static IRepositorioPeriodosTrabajados instance()
        {
            return _instance;
        }

        public List<PeriodoTrabajado> getPeriodos()
        {
            if (_periodos.Count != 0) return _periodos;
            getPeriodosPublicos();
             getPeriodosPrivados();
            return _periodos;
        }

        private object getPeriodosPrivados()
        {
            var coneccion = new ConeccionBaseDeDatos();
            var reader = coneccion.getDataReader("dbo.getPeriodosTrabajadosPrivada");
            getPeriodosFromReader(reader, coneccion, new TipoDeTrabajoPrivado());
            return _periodos;
        }


        public List<PeriodoTrabajado> getPeriodosPublicos()
        {
            var coneccion = new ConeccionBaseDeDatos();
            var reader = coneccion.getDataReader("dbo.getPeriodosTrabajadosPublica");
            getPeriodosFromReader(reader, coneccion, new TipoDeTrabajoPublico());
            return _periodos;
        }

        public void getPeriodosFromReader (IDataReader reader, ConeccionBaseDeDatos coneccion, ITipoDeTrabajo tipo) {
            while (reader.Read())
            {
                _periodos.Add(
                    new PeriodoTrabajado(
                        getDate("desde", reader),
                        getHasta(getDate("hasta", reader)),
                        getInt("legajo", reader),
                        tipo
                        )
                    );
            };
            coneccion.cerrar();
        }

        private DateTime getHasta(DateTime fecha)
        {
            if (fecha.Equals(new DateTime(1900, 01, 01)))
            {
                return this.fechaLimite;
            }
            return fecha;
        }

        public List<PeriodoTrabajado> getPeriodosPorLegajo(int legajo)
        {
            return getPeriodos().FindAll(periodo => periodo.legajo == legajo);
        }

        private int getInt(string nombreCampo, IDataReader reader)
        {
            var ordinal = reader.GetOrdinal(nombreCampo);
            return reader.GetInt32(ordinal);
        }

        private DateTime getDate(string nombreCampo, IDataReader reader)
        {
            var ordinal = reader.GetOrdinal(nombreCampo);
            return reader.GetDateTime(ordinal);
        }
    }
}
