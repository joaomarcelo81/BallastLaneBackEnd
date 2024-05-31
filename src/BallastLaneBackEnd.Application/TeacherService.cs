using BallastLaneBackEnd.Domain.DTO.Teacher;
using BallastLaneBackEnd.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLaneBackEnd.Application
{
    public class TeacherService : ITeacherService
    {
        public Task<int> Add(TeacherRequest classesRequest)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TeacherResponse> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<TeacherResponse>> List()
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(int id, TeacherRequest classesRequest)
        {
            throw new NotImplementedException();
        }
    }
}
