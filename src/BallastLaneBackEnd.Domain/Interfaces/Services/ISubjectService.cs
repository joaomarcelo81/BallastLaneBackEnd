using BallastLaneBackEnd.Domain.DTO.Class;
using BallastLaneBackEnd.Domain.DTO.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLaneBackEnd.Domain.Interfaces.Services
{
    public interface ISubjectService
    {
        Task<int> Add(CreateSubjectRequest subjectRequest);
        Task<int> Update(int id, UpdateSubjectRequest subjectRequest);
        Task<IList<SubjectResponse>> List();
        Task<SubjectResponse> Get(int id);
        Task<int> Delete(int id);
    }
}
