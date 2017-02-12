using System.Collections.Generic;
using UserManagement.Domain;

namespace ProjectManagement.Domain
{
    public class Project
    {
        public Project(
            int leadersId,
            string projectName,
            string projectDescription,
            List<int> members,
            List<Vacancy> vacancies,
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

        public int ProjectId { get; protected set; }
        public int LeadersId { get; protected set; }
        public string ProjectName { get; protected set; }
        public string ProjectDescription { get; protected set; }
        public List<int> Members { get; protected set; }
        public List<Vacancy> Vacancies { get; protected set; }
        public int UserId { get; protected set; }
        public bool FromOrganization { get; protected set; }
        public int OrganizationId { get; protected set; }
    }
}
