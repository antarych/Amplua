using System.Collections.Generic;
using Journalist.Options;
using UserManagement.Domain;

namespace ProjectManagement.Domain
{
    public class Project
    {
        public Project(
            int leadersId,
            string projectName,
            string projectDescription,
            Option<ISet<int>> members,
            ISet<Vacancy> vacancies,
            int userId,           
            bool fromOrganization,
            int organizationId = 0)
        {
            LeadersId = leadersId;
            ProjectName = projectName;
            ProjectDescription = projectDescription;
            Members = members;
            Vacancies = vacancies;
            UserId = userId;
            FromOrganization = fromOrganization;
            OrganizationId = organizationId;            
        }

        public virtual int ProjectId { get; protected set; }
        public virtual int LeadersId { get; protected set; }
        public virtual string ProjectName { get; protected set; }
        public virtual string ProjectDescription { get; protected set; }
        public virtual Option<ISet<int>> Members { get; protected set; }
        public virtual ISet<Vacancy> Vacancies { get; protected set; }
        public virtual int UserId { get; protected set; }
        public virtual bool FromOrganization { get; protected set; }
        public virtual int OrganizationId { get; protected set; }
    }
}
