using BallastLaneBackEnd.Domain.DTO.Subject;
using BallastLaneBackEnd.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLaneBackEnd.Application
{
    public class SubjectService : ISubjectService
    {
        public Task<int> Add(SubjectRequest classesRequest)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SubjectResponse> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<SubjectResponse>> List()
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(int id, SubjectRequest classesRequest)
        {
            throw new NotImplementedException();
        }
    }
}
