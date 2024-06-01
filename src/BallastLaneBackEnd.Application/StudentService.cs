using AutoMapper;
using BallastLaneBackEnd.Domain.DTO.Student;
using BallastLaneBackEnd.Domain.Entities;
using BallastLaneBackEnd.Domain.Interfaces.Repositories;
using BallastLaneBackEnd.Domain.Interfaces.Services;
using BallastLaneBackEnd.Domain.Util;
using Microsoft.Extensions.Logging;

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

        public async Task<int> Add(CreateStudentRequest studentRequest)
        {
            var student = await _studentRepository.Add(new Student()
            {
                Name = studentRequest.Name
                ,BirthDate = studentRequest.BirthDate
            });

            return student.Id;
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<StudentResponse> Get(int id)
        {
            var student = await _studentRepository.Get(id);

            //  return list.Select(x => _mapper.Map<StudentResponse>(x)).ToList();

            return new StudentResponse()
            {
                Id = student.Id
                ,
                Name = student.Name
                ,
                BirthDate = student.BirthDate
            };
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

        public async Task<int> Update(int id, UpdateStudentRequest studentRequest)
        {

            _logger.LogInformation($"atualizando um student", studentRequest);
            try
            {
                var studentNovo = _mapper.Map<Student>(studentRequest);
                studentNovo.Id = id;
                var student = await _studentRepository.Update(studentNovo);
                return id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao atualizar um student", studentRequest);
                throw;
            }
        }
    }
}
