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

namespace BallastLaneBackEnd.Application
{
    public class ClassService : IClassService
    {
        private readonly IRepository<Class> _classesRepository;

        private readonly ILogger<ClassService> _logger;

        private readonly Settings _settings;

        private readonly IMapper _mapper;

        public ClassService(IMapper mapper, ILogger<ClassService> logger, Settings settings, IRepository<Class> classesRepository)
        {
            _classesRepository = classesRepository;
            _logger = logger;
            _settings = settings;
            _mapper = mapper;
        }
        public async Task<int> Adicionar(ClassRequest classesRequest)
        {
            _logger.LogInformation($"Adiciondo um classes", classesRequest);
            try
            {
                var classes = _mapper.Map<Class>(classesRequest);
                classes = await _classesRepository.Add(classes);
                return classes.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"ao adicionar um classes", classesRequest);
                throw;
            }
        }

        public async Task<int> Atualizar(int id, ClassRequest classesRequest)
        {

            _logger.LogInformation($"atualizando um classes", classesRequest);
            try
            {
                var classesNovo = _mapper.Map<Class>(classesRequest);
                classesNovo.Id = id;
                var classes = await _classesRepository.Update(classesNovo);
                return id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao atualizar um classes", classesRequest);
                throw;
            }
        }
        public async Task<ClassResponse> ObterClass(int id)
        {
            _logger.LogInformation($"Buscar um classes pelo id");
            try
            {
                var classes = await _classesRepository.Get(id);
                var classesResponse = _mapper.Map<ClassResponse>(classes);
                return classesResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao buscar o classes");
                throw;
            }
        }
        public async Task<int> RemoverClass(int id)
        {
            _logger.LogInformation($"Remover um classes pelo id");
            try
            {
                var classes = await _classesRepository.Delete(id);
                var classesResponse = _mapper.Map<ClassResponse>(classes);
                return (classesResponse != null) ? classesResponse.Id : 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao remover o classes");
                throw;
            }
        }
        public async Task<IList<ClassResponse>> listaClasss()
        {
            _logger.LogInformation($"listando todos os classess");
            try
            {
                var lista = await _classesRepository.GetAll();
                return lista.ConvertAll(c => _mapper.Map<ClassResponse>(c));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao listar todos os classess");
                throw;
            }
        }
    }
}
