﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLaneBackEnd.Domain.Entities
{
    public class Subject : BaseEntity
    {
        public string Name { get; set; }
        public virtual IList<Class>? Classes { get; set; }
    }
}
