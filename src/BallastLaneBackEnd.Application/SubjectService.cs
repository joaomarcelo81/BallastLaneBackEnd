using AutoMapper;
using BallastLaneBackEnd.Domain.DTO.Class;
using BallastLaneBackEnd.Domain.DTO.Subject;
using BallastLaneBackEnd.Domain.Entities;
using BallastLaneBackEnd.Domain.Interfaces.Repositories;
using BallastLaneBackEnd.Domain.Interfaces.Services;
using BallastLaneBackEnd.Domain.Util;
using Microsoft.Extensions.Logging;

namespace BallastLaneBackEnd.Application
{
    public class SubjectService : ISubjectService
    {

        private readonly IRepository<Subject> _subjectRepository;

        private readonly ILogger<SubjectService> _logger;

        private readonly Settings _settings;

        private readonly IMapper _mapper;

        public SubjectService(IMapper mapper, ILogger<SubjectService> logger, Settings settings, IRepository<Subject> subjectRepository)
        {
            _subjectRepository = subjectRepository;
            _logger = logger;
            _settings = settings;
            _mapper = mapper;
        }

        public async Task<int> Add(CreateSubjectRequest classesRequest)
        {
            var subject = await _subjectRepository.Add(new Subject()
            {
                Name = classesRequest.Name
            });

            return subject.Id;
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<SubjectResponse> Get(int id)
        {
            var subject = await _subjectRepository.Get(id);

            //  return list.Select(x => _mapper.Map<SubjectResponse>(x)).ToList();

            return new SubjectResponse()
            {
                Id = subject.Id,
                Name = subject.Name
            };
        }

        public async Task<IList<SubjectResponse>> List()
        {
            var list = await _subjectRepository.GetAll();

            //  return list.Select(x => _mapper.Map<SubjectResponse>(x)).ToList();

            return list.ConvertAll(x => new SubjectResponse()
            {
                Id = x.Id,
                Name = x.Name
            });
        }

        public async Task<int> Update(int id, UpdateSubjectRequest classesRequest)
        {

            _logger.LogInformation($"atualizando um classes", classesRequest);
            try
            {
                var classesNovo = _mapper.Map<Subject>(classesRequest);
                classesNovo.Id = id;
                var classes = await _subjectRepository.Update(classesNovo);
                return id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao atualizar um classes", classesRequest);
                throw;
            }
        }
    }
}
