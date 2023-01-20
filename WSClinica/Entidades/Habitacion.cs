using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSClinica.Entidades
{
    public class Habitacion
    {
        public int Id { get; set; }
        [Range(1, 100, ErrorMessage = "Solo se aceptan edades entre 18 y 110")]
        public int Numero { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Estado { get; set; }
        public int ClinicaId { get; set; }
        [ForeignKey("ClinicaId")]
        public Clinica clinica { get; set; }

    }
}
