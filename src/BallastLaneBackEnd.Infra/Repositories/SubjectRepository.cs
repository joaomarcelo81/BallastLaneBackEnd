using BallastLaneBackEnd.Domain.Entities;
using BallastLaneBackEnd.Infra.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLaneBackEnd.Infra.Repositories
{
    public class SubjectRepository : BaseRepository<Subject, SchoolContext>
    {
        public SubjectRepository(SchoolContext context) : base(context)
        {

        }
    }
}
