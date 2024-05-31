using BallastLaneBackEnd.Domain.DTO.Teacher;
using BallastLaneBackEnd.Domain.Entities;
using BallastLaneBackEnd.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BallastLaneBackEnd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _service;

        public TeacherController(ITeacherService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<TeacherResponse>> GetTeachers()
        {
            return await _service.List();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetTeacher(int id)
        {
            var subject = await _service.Get(id);

            if (subject == null)
            {
                return NotFound();
            }

            return Ok(subject);
        }

        [HttpPost]
        public async Task<ActionResult> PostTeacher(TeacherRequest subject)
        {
            await _service.Add(subject);

            if (subject == null)
            {
                return NotFound();
            }

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutTeacher(int id, TeacherRequest subject)
        {
            if (id != subject.Id)
            {
                return BadRequest();
            }

            await _service.Update(id, subject);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            await _service.Delete(id);

            return Ok();
        }
    }
}
