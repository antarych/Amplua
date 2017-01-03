using System.Web.Http;
using UserManagement.Application;
using Frontend.Models;

namespace Frontend.Controllers
{
    public class UsersController : ApiController
    {
        protected UsersController() { }

        public UsersController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        private readonly IUserManager _userManager;

        [HttpPost]
        [Route("registration")]
        public IHttpActionResult RegisterNewUser([FromBody] UserRegistrationModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var accountRequest = new CreateAccountRequest(
                user.FirstName,
                user.LastName,
                user.Password,
                user.Email);

            _userManager.CreateUser(accountRequest);

            return Ok();
        }
    }
}