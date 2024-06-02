﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLaneBackEnd.Domain.Authentication
{
    public interface ITokenGenerator
    {
        dynamic Generator(string login);
    }
}
