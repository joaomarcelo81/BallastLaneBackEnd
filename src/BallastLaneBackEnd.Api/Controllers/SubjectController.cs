using BallastLaneBackEnd.Domain.DTO.Subject;
using BallastLaneBackEnd.Domain.Entities;
using BallastLaneBackEnd.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BallastLaneBackEnd.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        public async Task<ActionResult> GetSubjects()
        {
  
            try
            {
                return  Ok(await _service.List());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetSubject(int id)
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
        public async Task<ActionResult> PostSubject(CreateSubjectRequest subject)
        {
           await _service.Add(subject);

            if (subject == null)
            {
                return NotFound();
            }

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutSubject(int id, UpdateSubjectRequest subject)
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
        public async Task<IActionResult> DeleteSubject(int id)
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
