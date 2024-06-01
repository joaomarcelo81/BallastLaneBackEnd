using BallastLaneBackEnd.Api.Validation;
using BallastLaneBackEnd.Domain.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.VisualBasic;

namespace BallastLaneBackEnd.Api.Handler
{

    public class ApiKeyRequirement : IAuthorizationRequirement
    {
    }
    public class ApiKeyHandler : AuthorizationHandler<ApiKeyRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IApiKeyValidation _apiKeyValidation;

        public ApiKeyHandler(IHttpContextAccessor httpContextAccessor, IApiKeyValidation apiKeyValidation)
        {
            _httpContextAccessor = httpContextAccessor;
            _apiKeyValidation = apiKeyValidation;
        }

        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, ApiKeyRequirement requirement)
        {

            string apiKey = _httpContextAccessor?.HttpContext?.Request.Headers[Settings.ApiKeyHeaderName].ToString();

            if (string.IsNullOrWhiteSpace(apiKey))
            {
                context.Fail();
                return Task.CompletedTask;
            }


            if (!_apiKeyValidation.IsValidApiKey(apiKey))
            {
                context.Fail();
                return Task.CompletedTask;
            }

            context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
