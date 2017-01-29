using System.Web.Http;
using UserManagement.Application;
using Frontend.Models;
using UserManagement.Domain;

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
        public IHttpActionResult RegisterNewUser([FromBody] UserRegistrationModel userRegistrationModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var accountRequest = new CreateAccountRequest(
                userRegistrationModel.FirstName,
                userRegistrationModel.LastName,
                userRegistrationModel.Password,
                userRegistrationModel.Email);

            _userManager.CreateUser(accountRequest);

            return Ok();
        }

        [HttpGet]
        [Route("user/{id}")]
        public UserPresentationModel GetUser(int id)
        {
            var account = _userManager.GetUser(id);
            return new UserPresentationModel(account.Firstname, account.Lastname, account.Email, account.Profile);
        }
    }
}