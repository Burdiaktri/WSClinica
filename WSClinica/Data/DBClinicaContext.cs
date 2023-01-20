using Microsoft.EntityFrameworkCore;
using WSClinica.Entidades;

namespace WSClinica.Data
{
    public class DBClinicaContext : DbContext
    {
        public DBClinicaContext(DbContextOptions<DBClinicaContext> options) : base(options) { }

        public DbSet<Clinica> Clinicas { get; set; }
        public DbSet<Habitacion> Habitaciones { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }

    }
}
