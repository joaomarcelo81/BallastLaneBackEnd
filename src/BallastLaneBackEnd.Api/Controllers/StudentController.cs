
using BallastLaneBackEnd.Domain.DTO.Student;
using BallastLaneBackEnd.Domain.Entities;
using BallastLaneBackEnd.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BallastLaneBackEnd.Api.Controllers
{
   // [Authorize(Policy = "ApiKeyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetStudents()
        {
            return Ok( await _service.List());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetStudent(int id)
        {
            var subject = await _service.Get(id);

            if (subject == null)
            {
                return NotFound();
            }

            return Ok(subject);
        }

        [HttpPost]
        public async Task<ActionResult> PostStudent(CreateStudentRequest subject)
        {
            await _service.Add(subject);

            if (subject == null)
            {
                return NotFound();
            }

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutStudent(int id, UpdateStudentRequest subject)
        {
            if (id != subject.Id)
            {
                return BadRequest();
            }

            await _service.Update(id, subject);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await _service.Delete(id);

            return Ok();
        }
    }
}
