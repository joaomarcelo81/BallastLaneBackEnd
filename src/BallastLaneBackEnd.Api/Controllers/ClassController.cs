using BallastLaneBackEnd.Domain.DTO.Class;
using BallastLaneBackEnd.Domain.Entities;
using BallastLaneBackEnd.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BallastLaneBackEnd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _service;

        public ClassController(IClassService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<ClassResponse>> GetClasss()
        {
            return await _service.List();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetClass(int id)
        {
            var subject = await _service.Get(id);

            if (subject == null)
            {
                return NotFound();
            }

            return Ok(subject);
        }

        [HttpPost]
        public async Task<ActionResult> PostClass(CreateClassRequest @class)
        {
            try
            {
                if (@class == null)
                {
                    return NotFound();
                }
                await _service.Add(@class);
                return StatusCode(201);
            }
            catch
            {
                return BadRequest();
            }

        
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutClass(int id, UpdateClassRequest subject)
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
        public async Task<IActionResult> DeleteClass(int id)
        {
            await _service.Delete(id);

            return Ok();
        }
    }
}
