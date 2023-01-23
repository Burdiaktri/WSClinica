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
    public class EspecialidadController : ControllerBase
    {

        private readonly DBClinicaContext context;
        public EspecialidadController(DBClinicaContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Especialidad>> Get()
        {
            return context.Especialidades.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Especialidad> GetById(int id)
        {
            Especialidad especialidad = (from e in context.Especialidades
                             where e.Id == id
                             select e).SingleOrDefault();
            return especialidad;

        }

        [HttpPost]
        public ActionResult Post(Especialidad especialidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Especialidades.Add(especialidad);
            context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Especialidad especialidad)
        {
            if (id != especialidad.Id)
            {
                return BadRequest();
            }

            context.Entry(especialidad).State = EntityState.Modified;
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Especialidad> Delete(int id)
        {
            var especialidad = (from e in context.Especialidades
                          where e.Id == id
                          select e).SingleOrDefault();

            if (especialidad == null)
            {
                return NotFound();
            }

            context.Especialidades.Remove(especialidad);
            context.SaveChanges();
            return especialidad;
        }
    }
}
