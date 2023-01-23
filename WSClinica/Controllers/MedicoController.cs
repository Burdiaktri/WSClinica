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
    public class MedicoController : ControllerBase
    {

        private readonly DBClinicaContext context;
        public MedicoController(DBClinicaContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Medico>> Get()
        {
            return context.Medicos.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Medico> GetById(int id)
        {
            Medico medico = (from m in context.Medicos
                             where m.IdMedico == id
                             select m).SingleOrDefault();
            return medico;

        }

        [HttpPost]
        public ActionResult Post(Medico medico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Medicos.Add(medico);
            context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Medico medico)
        {
            if (id != medico.IdMedico)
            {
                return BadRequest();
            }

            context.Entry(medico).State = EntityState.Modified;
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Medico> Delete(int id)
        {
            var medico = (from m in context.Medicos
                           where m.IdMedico == id
                           select m).SingleOrDefault();

            if (medico == null)
            {
                return NotFound();
            }

            context.Medicos.Remove(medico);
            context.SaveChanges();
            return medico;
        }
    }
}
