using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace WebApplicationSistemaDeReclamo.Services
{
    public class DbUtils
    {
        public static SqlConnection RecuperarConnection()
        {
            //Leer el archivo appsettings.json
            var builder = new ConfigurationBuilder()
                   .AddJsonFile($"appsettings.json", true, true);

            var config = builder.Build();

            //Conexión SQL Server
            string connectionString = config.GetConnectionString("DefaultConnection");
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            return con;
        }
    }
}
