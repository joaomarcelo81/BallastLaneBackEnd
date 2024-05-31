using BallastLaneBackEnd.Domain.DTO.Class;

namespace BallastLaneBackEnd.Domain.Interfaces.Repositories
{
    public interface IClassService
    {
        Task<int> Adicionar(ClassRequest classesRequest);
        Task<int> Atualizar(int id, ClassRequest classesRequest);
        Task<IList<ClassResponse>> listaClasss();
        Task<ClassResponse> ObterClass(int id);
        Task<int> RemoverClass(int id);
    }
}