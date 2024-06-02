using AutoMapper;
using BallastLaneBackEnd.Api.Authentication;
using BallastLaneBackEnd.Domain.Authentication;
using BallastLaneBackEnd.Domain.Common;
using BallastLaneBackEnd.Domain.DTO.Login;
using BallastLaneBackEnd.Domain.Entities;
using BallastLaneBackEnd.Domain.Interfaces.Repositories;
using BallastLaneBackEnd.Domain.Interfaces.Services;
using BallastLaneBackEnd.Domain.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLaneBackEnd.Application
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;

        private readonly ILogger<UserService> _logger;

        private readonly Settings _settings;

        private readonly IMapper _mapper;

        private readonly ITokenGenerator _tokenGenerator;

        public UserService(IMapper mapper, ILogger<UserService> logger, Settings settings
            , IUserRepository userRepository
            , ITokenGenerator tokenGenerator)
        {
            _userRepository = userRepository;
            _logger = logger;
            _settings = settings;
            _mapper = mapper;
            _tokenGenerator = tokenGenerator;
        }
        public async Task<dynamic> GenerateTokenAsync(UserRequest loginRequest)
        {
            dynamic retorno = string.Empty;
            try
            {

                if (loginRequest == null)
                    return null;
        
                loginRequest.Password = Functions.GenerateSHA256Hash(loginRequest.Password, _settings);

                var user = await _userRepository.UserLogin(loginRequest.Login);
                user.Password = Functions.GenerateSHA256Hash(user.Password, _settings);
                if (user.Password == loginRequest.Password)
                {
                    _logger.LogInformation($"Login user ");

                    retorno = _tokenGenerator.Generator(user.Login);
                }else
                {
                    _logger.LogInformation($"Login user error");
                    return null;
                }

                
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro Generate Token {ex.Message}");

                return null;
            }

            return retorno;
        }
    }
}
