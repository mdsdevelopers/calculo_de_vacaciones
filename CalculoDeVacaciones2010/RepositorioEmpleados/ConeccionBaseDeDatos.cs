using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace CalculoDeVacaciones2010
{
    public class ConeccionBaseDeDatos
    {
        private string _connectionString = "Data Source=DIOGENES\\DOSK;Connection Timeout=5000;Initial Catalog=DB_RRHH;Integrated Security=True";
        //private string _connectionString = "Data Source=SQLTRETA;Initial Catalog=DB_RRHH;Integrated Security=True";
        private SqlConnection _coneccion = new SqlConnection();

        public IDataReader getDataReader(string storedProcedure)
        {
            _coneccion.ConnectionString = _connectionString;
            _coneccion.Open();
            var to = _coneccion.ConnectionTimeout;

            var command = new SqlCommand();
            command.Connection = _coneccion;
            command.CommandText = storedProcedure;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 5000;

            return command.ExecuteReader();
        }

        public void cerrar()
        {
            _coneccion.Close();
        }

        public void Abrir()
        {
            _coneccion.ConnectionString = _connectionString;
            _coneccion.Open();
        }

        public void Ejecutar(SqlCommand comando)
        {

            comando.Connection = _coneccion;
            comando.CommandType = CommandType.StoredProcedure;

            comando.ExecuteNonQuery();

        }
    }
}
