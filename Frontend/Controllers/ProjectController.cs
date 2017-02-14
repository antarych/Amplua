//using System.Web.Http;
//using Frontend.Models;
//using ProjectManagement.Domain;

//namespace Frontend.Controllers
//{
//    public class ProjectController : ApiController
//    {
//        private readonly ProjectManager _projectManager;

//        public ProjectController(ProjectManager projectManager)
//        {
//            _projectManager = projectManager;
//        }

//        [HttpPost]
//        [Route("project_creation")]
//        public IHttpActionResult CreateNewProject([FromBody]ProjectCreationModel prjCreationModel)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var prjRequest = new Project(prjCreationModel.LeadersId, prjCreationModel.ProjectName, prjCreationModel.ProjectDescription,
//                prjCreationModel.Members, prjCreationModel.Vacancies, prjCreationModel.UserId, prjCreationModel.IsFromOrganization,
//                prjCreationModel.OrganizationId);
//            _projectManager.CreateProject(prjRequest);

//            return Ok();
//        }
//    }
//}
