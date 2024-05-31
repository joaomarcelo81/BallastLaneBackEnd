using AutoMapper;
using BallastLaneBackEnd.Domain.DTO.Student;
using BallastLaneBackEnd.Domain.DTO.Subject;
using BallastLaneBackEnd.Domain.Entities;
using BallastLaneBackEnd.Domain.Interfaces.Repositories;
using BallastLaneBackEnd.Domain.Interfaces.Services;
using BallastLaneBackEnd.Domain.Util;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLaneBackEnd.Application
{
    public class StudentService : IStudentService
    {

        private readonly IRepository<Student> _studentRepository;

        private readonly ILogger<StudentService> _logger;

        private readonly Settings _settings;

        private readonly IMapper _mapper;

        public StudentService(IMapper mapper, ILogger<StudentService> logger, Settings settings, IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
            _logger = logger;
            _settings = settings;
            _mapper = mapper;
        }



        public Task<int> Add(StudentRequest classesRequest)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<StudentResponse> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<StudentResponse>> List()
        {
          var list =  await _studentRepository.GetAll();
            
          //  return list.Select(x => _mapper.Map<StudentResponse>(x)).ToList();

            return list.ConvertAll(x => new StudentResponse()
            {
                Id = x.Id
                ,Name = x.Name
                ,BirthDate = x.BirthDate                
            });
        }

        public Task<int> Update(int id, StudentRequest classesRequest)
        {
            throw new NotImplementedException();
        }
    }
}
