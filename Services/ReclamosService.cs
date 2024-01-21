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
            command.CommandText = "INSERT INTO RECLAMOS (TITULO, DESCRIPCION, ESTADO, FECHA_ALTA) VALUES"
                + " (@TITULO, @DESCRIPCION, @ESTADO, @FECHA_ALTA);";
            command.Parameters.AddWithValue("@TITULO", reclamo.Titulo);
            command.Parameters.AddWithValue("@DESCRIPCION", reclamo.Descripcion);
            command.Parameters.AddWithValue("@ESTADO", reclamo.Estado);
            command.Parameters.AddWithValue("@FECHA_ALTA", reclamo.FechaAlta);
            command.ExecuteNonQuery();

            connection.Close();
        }

        public void EditDeReclamo(long id, Reclamo reclamo)
        {
            SqlConnection connection = DbUtils.RecuperarConnection();
            //TODO: FALTA EL ALTA EN LA BASE DE DATOS....
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE RECLAMOS SET TITULO = @TITULO, DESCRIPCION = @DESCRIPCION, ESTADO = @ESTADO"
                + " WHERE ID = @ID;";
            command.Parameters.AddWithValue("@TITULO", reclamo.Titulo);
            command.Parameters.AddWithValue("@DESCRIPCION", reclamo.Descripcion);
            command.Parameters.AddWithValue("@ESTADO", reclamo.Estado);
            command.Parameters.AddWithValue("@ID", id);
            command.ExecuteNonQuery();

            connection.Close();
        }

        public void BorrarReclamo(long id)
        {
            SqlConnection connection = DbUtils.RecuperarConnection();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM RECLAMOS WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", id);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public List<Reclamo> RecuperarListadoDeReclamo()
        {
            List<Reclamo> reclamos = new List<Reclamo>();
            SqlConnection connection = DbUtils.RecuperarConnection();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT ID, TITULO, DESCRIPCION, ESTADO, FECHA_ALTA FROM reclamos";
            SqlDataReader dr = command.ExecuteReader();
            Reclamo reclamo = null;

            while (dr.Read()) 
            {
                reclamo = new Reclamo();
                reclamo.Id = dr.GetInt32("ID");
                reclamo.Titulo = dr.GetString("TITULO");
                reclamo.Descripcion = dr.GetString("DESCRIPCION");
                reclamo.Estado = dr.GetBoolean("ESTADO");
                reclamo.FechaAlta = dr.GetDateTime("FECHA_ALTA");
                reclamos.Add(reclamo);
            }

            connection.Close();

            return reclamos;
        }

        public List<Reclamo> RecuperarListadoDeReclamosBusc(string textoBuscar)
        {
            List<Reclamo> reclamos = new List<Reclamo>();
            SqlConnection connection = DbUtils.RecuperarConnection();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT ID, TITULO, DESCRIPCION, ESTADO, FECHA_ALTA FROM RECLAMOS WHERE TITULO LIKE @textoBuscar OR DESCRIPCION LIKE @textoBuscar";
            string parametroTextoBuscar = "%" + textoBuscar + "%";
            command.Parameters.AddWithValue("@textoBuscar", parametroTextoBuscar);
            SqlDataReader dr = command.ExecuteReader();
            Reclamo reclamo = null;

            while (dr.Read())
            {
                reclamo = new Reclamo();
                reclamo.Id = dr.GetInt32("ID");
                reclamo.Titulo = dr.GetString("TITULO");
                reclamo.Descripcion = dr.GetString("DESCRIPCION");
                reclamo.Estado = dr.GetBoolean("ESTADO");
                reclamo.FechaAlta = dr.GetDateTime("FECHA_ALTA");
                reclamos.Add(reclamo);
            }

            connection.Close();

            return reclamos;
        }

        public Reclamo RecuperarReclamoId(long id)
        {
            SqlConnection connection = DbUtils.RecuperarConnection();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT ID, TITULO, DESCRIPCION, ESTADO, FECHA_ALTA FROM RECLAMOS WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", id);
            SqlDataReader dr = command.ExecuteReader();
            Reclamo reclamo = null;
            while(dr.Read())
            {
                reclamo = new Reclamo();
                reclamo.Id = dr.GetInt32("ID");
                reclamo.Titulo = dr.GetString("TITULO");
                reclamo.Descripcion = dr.GetString("DESCRIPCION");
                reclamo.Estado = dr.GetBoolean("ESTADO");
                reclamo.FechaAlta = dr.GetDateTime("FECHA_ALTA");
            }
            

            connection.Close();

            return reclamo;

        }
    }
}
