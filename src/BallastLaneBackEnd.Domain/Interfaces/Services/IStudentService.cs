using BallastLaneBackEnd.Domain.DTO.Student;
using BallastLaneBackEnd.Domain.DTO.Subject;
using BallastLaneBackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLaneBackEnd.Domain.Interfaces.Services
{
    public interface IStudentService
    {
        Task<int> Add(CreateStudentRequest subjectRequest);
        Task<int> Update(int id, UpdateStudentRequest subjectRequest);
        Task<IList<StudentResponse>> List();
        Task<StudentResponse> Get(int id);
        Task<int> Delete(int id);
    }
}
