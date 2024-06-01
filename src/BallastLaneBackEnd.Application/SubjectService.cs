using AutoMapper;
using BallastLaneBackEnd.Domain.DTO.Class;
using BallastLaneBackEnd.Domain.DTO.Student;
using BallastLaneBackEnd.Domain.DTO.Subject;
using BallastLaneBackEnd.Domain.Entities;
using BallastLaneBackEnd.Domain.Interfaces.Repositories;
using BallastLaneBackEnd.Domain.Interfaces.Services;
using BallastLaneBackEnd.Domain.Util;
using BallastLaneBackEnd.Infra.Repositories;
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

        public async Task<int> Add(CreateSubjectRequest createSubjectRequest)
        {
            _logger.LogInformation($"Add subject", createSubjectRequest);
            try
            {
                var subject = _mapper.Map<Subject>(createSubjectRequest);
                subject = await _subjectRepository.Add(subject);
                return subject.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error add subject", createSubjectRequest);
                throw;
            }
        }

        public async Task<int> Delete(int id)
        {
            _logger.LogInformation($"Remover um subject pelo id");
            try
            {
                var subject = await _subjectRepository.Delete(id);
                var subjectResponse = _mapper.Map<SubjectResponse>(subject);
                return (subjectResponse != null) ? subjectResponse.Id : 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error removing subject");
                throw;
            }
        }

        public async Task<SubjectResponse> Get(int id)
        {
            _logger.LogInformation($"Search for a subject by id");
            try
            {
                var subject = await _subjectRepository.Get(id);
                var subjectResponse = _mapper.Map<SubjectResponse>(subject);
                return subjectResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error List the subject");
                throw;
            }
        }

        public async Task<IList<SubjectResponse>> List()
        {
            _logger.LogInformation($"List all Subject");
            try
            {
                var list = await _subjectRepository.GetAll();

                return list.Select(x => _mapper.Map<SubjectResponse>(x)).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error List all Subject");
                throw;
            }
        }

        public async Task<int> Update(int id, UpdateSubjectRequest subjectRequest)
        {

            _logger.LogInformation($"Update subject", subjectRequest);
            try
            {
                var subjectToBeUpdate = _mapper.Map<Subject>(subjectRequest);
                subjectToBeUpdate.Id = id;
                var subject = await _subjectRepository.Update(subjectToBeUpdate);
                return id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error update subject", subjectRequest);
                throw;
            }
        }
    }
}
