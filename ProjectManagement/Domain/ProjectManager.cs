using System;
using System.Collections.Generic;
using Journalist;
using ProjectManagement.Application;
using ProjectManagement.Infrastructure;

namespace ProjectManagement.Domain
{
    public class ProjectManager : IProjectManager
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectManager(IProjectRepository projectRepository)
        {
            Require.NotNull(projectRepository, nameof(projectRepository));
            _projectRepository = projectRepository;
        }

        public void CreateProject(Project request)
        {
            Require.NotNull(request, nameof(request));

            var newProject = new Project(
                request.LeadersId,
                request.ProjectName,
                request.ProjectDescription,
                request.Members,
                request.Vacancies,
                request.UserId,
                request.FromOrganization,
                request.OrganizationId);
            var projectId = _projectRepository.CreateProject(newProject);
        }

        public Project GetProject(int projectId)
        {
            Require.Positive(projectId, nameof(projectId));

            var account = _projectRepository.GetProject(projectId);

            return account;
        }

        public IEnumerable<Project> GetAccounts(Func<Project, bool> predicate = null)
        {
            return _projectRepository.GetAllProjects(predicate);
        }

        public void RemoveProject(int projectId)
        {
            _projectRepository.RemoveProject(projectId);
        }
    }
}
