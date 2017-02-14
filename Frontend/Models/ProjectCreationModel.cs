using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Journalist.Options;
using ProjectManagement.Domain;

namespace Frontend.Models
{
    public class ProjectCreationModel
    {
        public int LeadersId { get; set; }

        [MaxLength(60)]
        public string ProjectName { get; set; }

        public string ProjectDescription { get; set; }

        public Option<ISet<int>> Members { get; set; }

        public ISet<Vacancy> Vacancies { get; set; }

        public int UserId { get; set; }

        public bool IsFromOrganization { get; set; }

        public int OrganizationId { get; set; }
    }
}