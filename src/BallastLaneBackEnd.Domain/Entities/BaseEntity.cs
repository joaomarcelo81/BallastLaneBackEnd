using BallastLaneBackEnd.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLaneBackEnd.Domain.Entities
{
    public class BaseEntity : IEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
