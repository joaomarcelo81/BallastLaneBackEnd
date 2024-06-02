using BallastLaneBackEnd.Domain.DTO.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLaneBackEnd.Domain.Interfaces.Services
{

    public interface IUserService
    {
        Task<dynamic> GenerateTokenAsync(UserRequest login);
    }
}
