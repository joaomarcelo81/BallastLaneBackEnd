using BallastLaneBackEnd.Domain.Entities;
using BallastLaneBackEnd.Infra.Repository.Base;

namespace BallastLaneBackEnd.Infra.Repositories
{
    public class ClassRepository : BaseRepository<Class, SchoolContext>
    {
        public ClassRepository(SchoolContext context) : base(context)
        {

        }
    }
}
