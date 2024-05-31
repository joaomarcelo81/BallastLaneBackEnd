using BallastLaneBackEnd.Domain.Dto.Reponse;
using BallastLaneBackEnd.Domain.Dto.Request;
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
        Task<StudentResponse> ObterStudent(int Id);
        Task<int> Atualizar(int Id, StudentRequest Student);
        Task<int> Adicionar(StudentRequest Student);
        Task<IList<StudentResponse>> listaStudents();
        Task<int> RemoverStudent(int Id);
        Task<int> BuscarDadosAlura(string nomeStudent);
    }
}
