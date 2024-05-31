using BallastLaneBackEnd.Domain.DTO.Subject;
using BallastLaneBackEnd.Domain.Entities;
using BallastLaneBackEnd.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BallastLaneBackEnd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _service;

        public SubjectController(ISubjectService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<SubjectResponse>> GetSubjects()
        {
            return await _service.List();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetSubject(int id)
        {
            var subject = await _service.Get(id);

            if (subject == null)
            {
                return NotFound();
            }

            return Ok(subject);
        }

        [HttpPost]
        public async Task<ActionResult> PostSubject(SubjectRequest subject)
        {
           await _service.Add(subject);

            if (subject == null)
            {
                return NotFound();
            }

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutSubject(int id, SubjectRequest subject)
        {
            if (id != subject.Id)
            {
                return BadRequest();
            }

            await _service.Update(id, subject);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            await _service.Delete(id);

            return Ok();
        }     
    }
}
