using System.Data.SqlClient;
using WebApplicationSistemaDeReclamo.Models;
namespace WebApplicationSistemaDeReclamo.Services
{
    public class ReclamosService
    {
        public void AltaReclamos(Reclamo reclamo)
        {
            SqlConnection sqlConnection = DbUtils.RecuperarConnection();
            //TODO: FALTA EL ALTA EN LA BASE DE DATOS....
            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandText = "INSERT INTO reclamos (titulo, descripcion, estado, fechaAlta) VALUES" 
                + " (@titulo, @descripcion, @estado, @fechaAlta);";
            command.Parameters.AddWithValue("@titulo", reclamo.Titulo);
            command.Parameters.AddWithValue("@descripcion", reclamo.Descripcion);
            command.Parameters.AddWithValue("@estado", reclamo.Estado);
            command.Parameters.AddWithValue("@fechaAlta", reclamo.FechaAlta);
            command.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public List<Reclamo> RecuperarListadoDeReclamo()
        {
            //TODO: FALTA EL BUSCAR EN LA BASE DE DATOS....
            return new List<Reclamo>();
        }
    }
}
