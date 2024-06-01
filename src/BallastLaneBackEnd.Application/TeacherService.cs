using AutoMapper;
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

        public async Task<int> Add(CreateTeacherRequest teacherRequest)
        {
            var teacher = await _teacherRepository.Add(new Teacher()
            {
                Name = teacherRequest.Name,
                SubjectSpecialty = teacherRequest.SubjectSpecialty
            });

            return teacher.Id;
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
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

            _logger.LogInformation($"atualizando um teacher", teacherRequest);
            try
            {
                var teacherNovo = _mapper.Map<Teacher>(teacherRequest);
                teacherNovo.Id = id;
                var teacher = await _teacherRepository.Update(teacherNovo);
                return id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao atualizar um teacher", teacherRequest);
                throw;
            }
        }
    }
}
