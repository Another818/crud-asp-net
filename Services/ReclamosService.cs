using System.Data;
using System.Data.SqlClient;
using WebApplicationSistemaDeReclamo.Models;
namespace WebApplicationSistemaDeReclamo.Services
{
    public class ReclamosService
    {
        public void AltaDeReclamo(Reclamo reclamo)
        {
            SqlConnection connection = DbUtils.RecuperarConnection();
            //TODO: FALTA EL ALTA EN LA BASE DE DATOS....
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO reclamos (titulo, descripcion, estado, fechaAlta) VALUES" 
                + " (@titulo, @descripcion, @estado, @fechaAlta);";
            command.Parameters.AddWithValue("@titulo", reclamo.Titulo);
            command.Parameters.AddWithValue("@descripcion", reclamo.Descripcion);
            command.Parameters.AddWithValue("@estado", reclamo.Estado);
            command.Parameters.AddWithValue("@fechaAlta", reclamo.FechaAlta);
            command.ExecuteNonQuery();

            connection.Close();
        }

        public void BorrarReclamo(long id)
        {
            SqlConnection connection = DbUtils.RecuperarConnection();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM reclamos WHERE id = @id";
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public List<Reclamo> RecuperarListadoDeReclamo()
        {
            List<Reclamo> reclamos = new List<Reclamo>();
            SqlConnection connection = DbUtils.RecuperarConnection();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT id, titulo, descripcion, estado, fechaAlta FROM reclamos";
            SqlDataReader dr = command.ExecuteReader();
            Reclamo reclamo = null;

            while (dr.Read()) 
            {
                reclamo = new Reclamo();
                reclamo.Id = dr.GetInt32("id");
                reclamo.Titulo = dr.GetString("titulo");
                reclamo.Descripcion = dr.GetString("descripcion");
                reclamo.Estado = dr.GetString("estado");
                reclamo.FechaAlta = dr.GetDateTime("fechaAlta");
                reclamos.Add(reclamo);
            }

            connection.Close();

            return reclamos;
        }
    }
}
