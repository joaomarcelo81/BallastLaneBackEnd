using BallastLaneBackEnd.Domain.Entities;
using BallastLaneBackEnd.Infra.Repository.Base;

namespace BallastLaneBackEnd.Infra.Repositories
{
    public class TeacherRepository : BaseRepository<Teacher, SchoolContext>
    {
        public TeacherRepository(SchoolContext context) : base(context)
        {

        }
    }
}
