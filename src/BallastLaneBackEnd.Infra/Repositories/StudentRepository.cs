using BallastLaneBackEnd.Domain.Entities;
using BallastLaneBackEnd.Infra.Repository.Base;

namespace BallastLaneBackEnd.Infra.Repositories
{
    public class StudentRepository : BaseRepository<Student, SchoolContext>
    {
        public StudentRepository(SchoolContext context) : base(context)
        {

        }
    }
}
