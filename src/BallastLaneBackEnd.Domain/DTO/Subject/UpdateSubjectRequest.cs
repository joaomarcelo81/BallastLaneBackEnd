using BallastLaneBackEnd.Domain.DTO.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLaneBackEnd.Domain.DTO.Subject
{
    public class UpdateSubjectRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UpdateClassRequest>? Classes { get; set; }
    }

}
