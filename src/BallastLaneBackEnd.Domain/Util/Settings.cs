using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLaneBackEnd.Domain.Util
{
    public class Settings
    {
        public const string ApiKeyHeaderName = "X-API-Key";
        public const string ApiKeyName = "ApiKey";

        public string ApiKey { get; set; }
    }
}
