using BallastLaneBackEnd.Domain.Entities;
using BallastLaneBackEnd.Domain.Interfaces;
using BallastLaneBackEnd.Infra.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace BallastLaneBackEnd.Infra.Repositories
{
    public class ClassRepository : BaseRepository<Class, SchoolContext>
    {
        private readonly SchoolContext _context;
        public ClassRepository(SchoolContext context) : base(context)
        {
            _context= context;
        

        }
        public override async Task<Class> Get(int id)
        {
            return await _context.Classes
                .Include(x => x.Teacher)
                .Include(x => x.Subject)
                .Include(x => x.Students).FirstAsync(x => x.Id == id);
           
        }

        public override async Task<List<Class>> GetAll()
        {
           return await _context.Classes.Include(x => x.Teacher)
                .Include(x => x.Subject).Include(x => x.Students).ToListAsync();
            
        }
    }
}
