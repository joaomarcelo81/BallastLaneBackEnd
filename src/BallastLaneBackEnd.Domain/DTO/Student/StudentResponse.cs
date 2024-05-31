using BallastLaneBackEnd.Domain.DTO.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLaneBackEnd.Domain.DTO.Student
{
    public class StudentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public List<ClassResponse> Classes { get; set; }
    }
}
