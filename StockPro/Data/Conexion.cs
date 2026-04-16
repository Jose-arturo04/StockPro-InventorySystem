using System;
using System.Data;
using Microsoft.Data.SqlClient; // Asegúrate de instalar este paquete vía NuGet si da error

namespace StockPro.Data
{
    public class Conexion
    {
        // El '.' significa "Mi PC local"
        private string cadena = @"Server=(localdb)\MSSQLLocalDB; Database=StockProDB; Integrated Security=True; TrustServerCertificate=True;"; public SqlConnection cn = new SqlConnection();

        public Conexion()
        {
            cn.ConnectionString = cadena;
        }

        public void Abrir()
        {
            try
            {
                if (cn.State == ConnectionState.Closed) cn.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al conectar a la base de datos: " + ex.Message);
            }
        }

        public void Cerrar()
        {
            if (cn.State == ConnectionState.Open) cn.Close();
        }
    }
}