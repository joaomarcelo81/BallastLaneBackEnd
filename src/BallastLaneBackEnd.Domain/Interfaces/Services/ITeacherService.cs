using BallastLaneBackEnd.Domain.DTO.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLaneBackEnd.Domain.Interfaces.Services
{
    public interface ITeacherService
    {
        Task<int> Add(TeacherRequest classesRequest);
        Task<int> Update(int id, TeacherRequest classesRequest);
        Task<IList<TeacherResponse>> List();
        Task<TeacherResponse> Get(int id);
        Task<int> Delete(int id);
    }
}
