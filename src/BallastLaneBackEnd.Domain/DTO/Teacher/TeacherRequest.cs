using BallastLaneBackEnd.Domain.DTO.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLaneBackEnd.Domain.DTO.Teacher
{
    public class TeacherRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SubjectSpecialty { get; set; }
        public List<ClassRequest> Classes { get; set; }


    }
}
