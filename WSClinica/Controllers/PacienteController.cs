using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WSClinica.Data;
using WSClinica.Entidades;

namespace WSClinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {

        private readonly DBClinicaContext context;
        public PacienteController(DBClinicaContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Paciente>> Get()
        {
            return context.Pacientes.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Paciente> GetById(int id)
        {
            Paciente paciente = (from p in context.Pacientes
                                where p.Id == id
                               select p).SingleOrDefault();
            return paciente;

        }

        [HttpPost]
        public ActionResult Post(Paciente paciente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Pacientes.Add(paciente);
            context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Paciente paciente)
        {
            if (id != paciente.Id)
            {
                return BadRequest();
            }

            context.Entry(paciente).State = EntityState.Modified;
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Paciente> Delete(int id)
        {
            var paciente = (from a in context.Pacientes
                           where a.Id == id
                           select a).SingleOrDefault();

            if (paciente == null)
            {
                return NotFound();
            }

            context.Pacientes.Remove(paciente);
            context.SaveChanges();
            return paciente;
        }
    }
}
