using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BallastLaneBackEnd.Domain.Entities
{
    public class Class
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }
    }
}
