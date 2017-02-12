using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.NHibernate;
using Journalist;
using NHibernate.Linq;
using ProjectManagement.Domain;
using ProjectManagement.Infrastructure;

namespace DataAccess.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ISessionProvider _sessionProvider;

        public ProjectRepository(ISessionProvider sessionProvider)
        {
            Require.NotNull(sessionProvider, nameof(sessionProvider));
            _sessionProvider = sessionProvider;
        }

        public int CreateProject(Project project)
        {
            Require.NotNull(project, nameof(project));

            var session = _sessionProvider.GetCurrentSession();
            var savedProjectId = (int)session.Save(project);
            return savedProjectId;
        }

        public Project GetProject(int projectId)
        {
            Require.Positive(projectId, nameof(projectId));

            var session = _sessionProvider.GetCurrentSession();
            var project = session.Get<Project>(projectId);
            return project;
        }

        public List<Project> GetAllProjects(Func<Project, bool> predicate = null)
        {
            var session = _sessionProvider.GetCurrentSession();
            return predicate == null
                ? session.Query<Project>().ToList()
                : session.Query<Project>().Where(predicate).ToList();
        }

        public void RemoveProject(int projectId)
        {
            Require.Positive(projectId, nameof(projectId));

            var session = _sessionProvider.GetCurrentSession();
            var project = GetProject(projectId);
            session.Delete(project);
        }
    }
}
