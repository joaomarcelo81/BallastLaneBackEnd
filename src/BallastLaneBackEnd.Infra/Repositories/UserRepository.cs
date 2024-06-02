using BallastLaneBackEnd.Domain.Entities;
using BallastLaneBackEnd.Domain.Interfaces.Repositories;
using BallastLaneBackEnd.Infra.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLaneBackEnd.Infra.Repositories
{
    public class UserRepository : BaseRepository<User, SchoolContext>, IUserRepository
    {
        private readonly SchoolContext _context;
        public UserRepository(SchoolContext context) : base(context)
        {
            _context = context;
        }
        public async Task<User> UserLogin(string login)
        {
            return await _context.Users
               .FirstAsync(x => x.Login == login);

        }
    }
}
