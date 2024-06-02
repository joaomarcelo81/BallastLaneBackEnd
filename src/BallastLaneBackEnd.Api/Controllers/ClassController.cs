using BallastLaneBackEnd.Domain.DTO.Class;
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
    public class ClassController : ControllerBase
    {
        private readonly IClassService _service;

        public ClassController(IClassService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetClasss()
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
        public async Task<ActionResult> GetClass(int id)
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
