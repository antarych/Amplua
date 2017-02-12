using System;
using System.Collections.Generic;
using ProjectManagement.Domain;

namespace ProjectManagement.Infrastructure
{
    public interface IProjectRepository
    {
        Project GetProject(int projectId);

        int CreateProject(Project request);

        List<Project> GetAllProjects(Func<Project, bool> predicate = null);

        void RemoveProject(int projectId);
    }
}
