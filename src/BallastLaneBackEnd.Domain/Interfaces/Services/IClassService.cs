using BallastLaneBackEnd.Domain.DTO.Class;

namespace BallastLaneBackEnd.Domain.Interfaces.Services
{
    public interface IClassService
    {
        Task<int> Add(ClassRequest classesRequest);
        Task<int> Update(int id, ClassRequest classesRequest);
        Task<IList<ClassResponse>> List();
        Task<ClassResponse> Get(int id);
        Task<int> Delete(int id);
    }
}