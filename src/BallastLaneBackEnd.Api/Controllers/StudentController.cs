﻿
using BallastLaneBackEnd.Domain.DTO.Student;
using BallastLaneBackEnd.Domain.Entities;
using BallastLaneBackEnd.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BallastLaneBackEnd.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        public async Task<ActionResult> GetStudent(int id)
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
        public async Task<ActionResult> PostStudent(CreateStudentRequest subject)
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
            catch (Exception)
            {

                return BadRequest();
            }
     

           
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutStudent(int id, UpdateStudentRequest subject)
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
        public async Task<IActionResult> DeleteStudent(int id)
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
