using AutoMapper;
using BallastLaneBackEnd.Domain.DTO.Student;
using BallastLaneBackEnd.Domain.DTO.Subject;
using BallastLaneBackEnd.Domain.DTO.Teacher;
using BallastLaneBackEnd.Domain.Entities;
using BallastLaneBackEnd.Domain.Interfaces.Repositories;
using BallastLaneBackEnd.Domain.Interfaces.Services;
using BallastLaneBackEnd.Domain.Util;
using BallastLaneBackEnd.Infra.Repositories;
using Microsoft.Extensions.Logging;

namespace BallastLaneBackEnd.Application
{
    public class TeacherService : ITeacherService
    {

        private readonly IRepository<Teacher> _teacherRepository;

        private readonly ILogger<TeacherService> _logger;

        private readonly Settings _settings;

        private readonly IMapper _mapper;

        public TeacherService(IMapper mapper, ILogger<TeacherService> logger, Settings settings, IRepository<Teacher> teacherRepository)
        {
            _teacherRepository = teacherRepository;
            _logger = logger;
            _settings = settings;
            _mapper = mapper;
        }

        public async Task<int> Add(CreateTeacherRequest createTeacherRequest)
        {
            _logger.LogInformation($"Add a teacher", createTeacherRequest);
            try
            {
                var teacher = _mapper.Map<Teacher>(createTeacherRequest);
                teacher = await _teacherRepository.Add(teacher);
                return teacher.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error add teacher", createTeacherRequest);
                throw;
            }
        }

        public async Task<int> Delete(int id)
        {
            _logger.LogInformation($"Remover um classes pelo id");
            try
            {
                var teacher = await _teacherRepository.Delete(id);
                var teacherResponse = _mapper.Map<TeacherResponse>(teacher);
                return (teacherResponse != null) ? teacherResponse.Id : 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error removing classes");
                throw;
            }
        }

        public async Task<TeacherResponse> Get(int id)
        {
            var teacher = await _teacherRepository.Get(id);

            //  return list.Select(x => _mapper.Map<TeacherResponse>(x)).ToList();

            return new TeacherResponse()
            {
                Id = teacher.Id,
                Name = teacher.Name
            };
        }

        public async Task<IList<TeacherResponse>> List()
        {
            var list = await _teacherRepository.GetAll();

            //  return list.Select(x => _mapper.Map<TeacherResponse>(x)).ToList();

            return list.ConvertAll(x => new TeacherResponse()
            {
                Id = x.Id,
                Name = x.Name
            });
        }

        public async Task<int> Update(int id, UpdateTeacherRequest teacherRequest)
        {

            _logger.LogInformation($"Update teacher", teacherRequest);
            try
            {
                var teacherNovo = _mapper.Map<Teacher>(teacherRequest);
                teacherNovo.Id = id;
                var teacher = await _teacherRepository.Update(teacherNovo);
                return id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error update teacher", teacherRequest);
                throw;
            }
        }
    }
}
