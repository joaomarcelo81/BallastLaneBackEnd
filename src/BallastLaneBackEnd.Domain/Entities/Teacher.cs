using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLaneBackEnd.Domain.Entities
{
    public class Teacher : BaseEntity
    {
        public string Name { get; set; }
        public string? SubjectSpecialty { get; set; }
        public virtual IList<Class>? Classes { get; set; }
    }
}
