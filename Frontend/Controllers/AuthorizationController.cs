using System;
using System.Net.Mail;
using System.Web.Http;
using Common;
using Frontend.Models;
using Journalist;
using UserManagement.Application;
using UserManagement.Domain;

namespace Frontend.Controllers
{
    public class AuthorizationController : ApiController
    {
        private readonly IAuthorizer _authorizer;

        public AuthorizationController(IAuthorizer authorizer)
        {
            Require.NotNull(authorizer, nameof(authorizer));
            _authorizer = authorizer;
        }

        [HttpPost]
        [Route("auth")]
        public AuthorizationTokenInfo Authorize([FromBody] LoginInformation loginInformation)
        {
            try
            {
                var token = _authorizer.Authorize(loginInformation.Email,
                    new Password(loginInformation.Password));
                return token;
            }
            finally 
            {
                throw new Exception("Error");
            }
        }
    }
}
