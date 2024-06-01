using AutoMapper;
using BallastLaneBackEnd.Domain.DTO.Class;
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

        public async Task<int> Add(CreateStudentRequest createStudentRequest)
        {
            _logger.LogInformation($"Add classes", createStudentRequest);
            try
            {
                var student = await _studentRepository.Add(new Student()
                {
                    Name = createStudentRequest.Name,
                    BirthDate = createStudentRequest.BirthDate
                });

                return student.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error add classes", createStudentRequest);
                throw;
            }
        }

        public async Task<int> Delete(int id)
        {
            _logger.LogInformation($"Remover um classes pelo id");
            try
            {
                var student = await _studentRepository.Delete(id);
                var studentResponse = _mapper.Map<StudentResponse>(student);
                return (studentResponse != null) ? studentResponse.Id : 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error removing classes");
                throw;
            }
        }

        public async Task<StudentResponse> Get(int id)
        {
            _logger.LogInformation($"Search for a classes pelo id");
            try
            {
                var student = await _studentRepository.Get(id);
                var studentResponse = _mapper.Map<StudentResponse>(student);
                return studentResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error List the classes");
                throw;
            }
        }

        public async Task<IList<StudentResponse>> List()
        {      

            _logger.LogInformation($"List all  classess");
            try
            {
                var list = await _studentRepository.GetAll();

                return list.Select(x => _mapper.Map<StudentResponse>(x)).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error List all classess");
                throw;
            }
        }

        public async Task<int> Update(int id, UpdateStudentRequest studentRequest)
        {

            _logger.LogInformation($"Update student", studentRequest);
            try
            {
                var studentNovo = _mapper.Map<Student>(studentRequest);
                studentNovo.Id = id;
                var student = await _studentRepository.Update(studentNovo);
                return id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error update student", studentRequest);
                throw;
            }
        }
    }
}
