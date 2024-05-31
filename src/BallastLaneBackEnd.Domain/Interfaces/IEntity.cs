using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLaneBackEnd.Domain.Interfaces
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTime CreateDate { get; set; }
    }
}
