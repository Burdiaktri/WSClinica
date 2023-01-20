using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;

namespace WSClinica.Entidades
{
    public class Clinica
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Nombre { get; set; }
        public DateTime FechaInicioActividades { get; set; }
        [Required]
        [Column(TypeName = "varchar(60)")]
        public string Email { get; set; }
        public List<Habitacion> Habitaciones { get; set; }

    }
}
