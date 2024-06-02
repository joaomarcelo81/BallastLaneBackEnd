using BallastLaneBackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLaneBackEnd.Domain.Interfaces.Repositories
{
    public interface IUserRepository: IRepository<User>
    {
        Task<User> UserLogin(string login);
    }
}
