using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationSistemaDeReclamo.Models.ViewModels
{
    public class ReclamoViewModel
    {
        private long id;
        private string titulo;
        private string descripcion;
        private string estado;
        private DateTime fechaAlta;

        [DisplayName("Id auto generado")]
        public long Id { get => id; set => id = value; }

        [DisplayName("Titulo del producto")]
        [Required(ErrorMessage = "El campo Titulo es obligatorio.")]
        public string Titulo { get => titulo; set => titulo = value; }

        [DisplayName("Descripción")]
        [Required(ErrorMessage = "El campo Descripcion es obligatorio.")]
        [StringLength(100)]
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string? Estado { get => estado; set => estado = value; }

        public DateTime FechaAlta { get => fechaAlta; set => fechaAlta = value; }
    }
}
