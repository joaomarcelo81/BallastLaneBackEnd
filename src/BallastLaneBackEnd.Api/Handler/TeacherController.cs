using BallastLaneBackEnd.Domain.DTO.Teacher;
using BallastLaneBackEnd.Domain.Entities;
using BallastLaneBackEnd.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BallastLaneBackEnd.Api.Handler
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        public async Task<ActionResult> GetTeachers()
        {
            try
            {
                return Ok(await _service.List());
            }
            catch
            {

                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetTeacher(int id)
        {


            try
            {
                var subject = await _service.Get(id);

                if (subject == null)
                {
                    return NotFound();
                }

                return Ok(subject);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostTeacher(CreateTeacherRequest subject)
        {


            try
            {
                await _service.Add(subject);

                if (subject == null)
                {
                    return NotFound();
                }

                return StatusCode(201);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutTeacher(int id, UpdateTeacherRequest subject)
        {



            try
            {
                if (id != subject.Id)
                {
                    return BadRequest();
                }

                await _service.Update(id, subject);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {



            try
            {
                await _service.Delete(id);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
