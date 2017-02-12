using System;
using System.Collections.Generic;
using ProjectManagement.Domain;

namespace ProjectManagement.Application
{
    public interface IProjectManager
    {
        Project GetProject(int projectId);

        void CreateProject(Project request);

        IEnumerable<Project> GetAccounts(Func<Project, bool> predicate = null);

        void RemoveProject(int projectId);
    }
}
