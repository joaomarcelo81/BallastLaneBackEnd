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
    public class ClassResponse
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public SubjectResponse Subject { get; set; }
        public int TeacherId { get; set; }
        public TeacherResponse Teacher { get; set; }
        public List<StudentResponse> Students { get; set; }



    }
}
