using BallastLaneBackEnd.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using BallastLaneBackEnd.Domain.Util;
using BallastLaneBackEnd.Domain.Entities;
using AutoMapper;
using BallastLaneBackEnd.Domain.DTO.Class;
using BallastLaneBackEnd.Domain.Interfaces.Services;

namespace BallastLaneBackEnd.Application
{
    public class ClassService : IClassService
    {
        private readonly IRepository<Class> _classesRepository;

        private readonly IRepository<Student> _studentRepository;

        private readonly ILogger<ClassService> _logger;

        private readonly Settings _settings;

        private readonly IMapper _mapper;

        public ClassService(IMapper mapper, ILogger<ClassService> logger, Settings settings
            , IRepository<Class> classesRepository, IRepository<Student> studentRepository)
        {
            _classesRepository = classesRepository;
            _logger = logger;
            _settings = settings;
            _mapper = mapper;
            _studentRepository = studentRepository;
        }
        public async Task<int> Add(CreateClassRequest createClassesRequest)
        {
            _logger.LogInformation($"Add classes", createClassesRequest);
            try
            {
                var classes = _mapper.Map<Class>(createClassesRequest);
                classes = await _classesRepository.Add(classes);
                return classes.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error add classes", createClassesRequest);
                throw;
            }
        }

        public async Task<int> Update(int id, UpdateClassRequest classesRequest)
        {

            _logger.LogInformation($"Update classes", classesRequest);
            try
            {
                var classToBeUpdate = await _classesRepository.Get(id);
                var classRequestUpdated = _mapper.Map<Class>(classesRequest);
                classRequestUpdated.Id = id;
                if (!string.IsNullOrWhiteSpace(classRequestUpdated.Number))
                {
                    classToBeUpdate.Number = classRequestUpdated.Number;
                }
                if (classRequestUpdated.TeacherId.HasValue)
                {
                    classToBeUpdate.TeacherId = classRequestUpdated.TeacherId.Value;
                }
                if (classRequestUpdated.SubjectId.HasValue)
                {
                    classToBeUpdate.SubjectId = classRequestUpdated.SubjectId.Value;
                }
                if (classRequestUpdated.Students.Any())
                {
                    if (classToBeUpdate.Students != null)
                    {
                        classToBeUpdate.Students.Clear();
                        await _classesRepository.Update(classToBeUpdate);
                    }

                    else { classToBeUpdate.Students = new List<Student>(); }
                    foreach (var student in classRequestUpdated.Students)
                    {
                        classToBeUpdate.Students.Add(await _studentRepository.Get(student.Id));
                    }
                }

                classToBeUpdate.UpdateDate = DateTime.Now;  

                var classes = await _classesRepository.Update(classToBeUpdate);
                return id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error update classes", classesRequest);
                throw;
            }
        }
        public async Task<ClassResponse> Get(int id)
        {
            _logger.LogInformation($"Search for a classes pelo id");
            try
            {
                var classes = await _classesRepository.Get(id);
                var classesResponse = _mapper.Map<ClassResponse>(classes);
                return classesResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error List the classes");
                throw;
            }
        }
        public async Task<int> Delete(int id)
        {
            _logger.LogInformation($"delete a class");
            try
            {
                var classes = await _classesRepository.Delete(id);
                var classesResponse = _mapper.Map<ClassResponse>(classes);
                return (classesResponse != null) ? classesResponse.Id : 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error delete a class");
                throw;
            }
        }
        public async Task<IList<ClassResponse>> List()
        {
            _logger.LogInformation($"List all  classess");
            try
            {
                var lista = await _classesRepository.GetAll();
                return lista.ConvertAll(c => _mapper.Map<ClassResponse>(c));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error List all classess");
                throw;
            }
        }
    }
}
