using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WSClinica.Entidades
{
    public class Medico
    {
        [Key]
        public int IdMedico { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Nombre { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Apellido { get; set; }
        public int EspecialidadId { get; set; }
        [ForeignKey("EspecialidadId")]
        public Especialidad Especialidad { get; set; }
        public int Matricula { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public List<Paciente> Pacientes { get; set; }

    }
}
