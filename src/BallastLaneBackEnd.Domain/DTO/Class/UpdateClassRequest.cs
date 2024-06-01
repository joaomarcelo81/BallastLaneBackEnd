using BallastLaneBackEnd.Domain.DTO.Student;
using BallastLaneBackEnd.Domain.DTO.Subject;
using BallastLaneBackEnd.Domain.DTO.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLaneBackEnd.Domain.DTO.Class
{
    public class UpdateClassRequest
    {
        public int Id { get; set; }
        public string? Number { get; set; }
        public int? SubjectId { get; set; }      
        public int? TeacherId { get; set; } 
        public IList<StudentRequest> Students { get; set; } = new List<StudentRequest>();
    }
}
