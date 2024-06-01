using BallastLaneBackEnd.Domain.Util;
using Microsoft.VisualBasic;

namespace BallastLaneBackEnd.Api.Validation
{
    public class ApiKeyValidation : IApiKeyValidation
    {
        private readonly IConfiguration _configuration;

        private Settings _settings;

        public ApiKeyValidation(IConfiguration configuration, Settings settings)
        {
            _configuration = configuration;
            _settings = settings;
        }

        public bool IsValidApiKey(string userApiKey)
        {
            if (string.IsNullOrWhiteSpace(userApiKey))
                return false;

            string? apiKey = _settings.ApiKey;

            if (apiKey == null || apiKey != userApiKey)
                return false;

            return true;
        }
    }

    public interface IApiKeyValidation
    {
        bool IsValidApiKey(string userApiKey);
    }
}
