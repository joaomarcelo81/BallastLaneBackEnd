using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLaneBackEnd.Domain.Entities
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Class> Classes { get; set; }
    }
}
