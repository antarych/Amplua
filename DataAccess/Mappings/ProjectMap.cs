using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using ProjectManagement.Domain;

namespace DataAccess.Mappings
{
    class ProjectMap : ClassMapping<Project>
    {
        public ProjectMap()
        {
            Table("Project");
            Id(project => project.ProjectId, mapper => mapper.Generator(Generators.Identity));
            Property(project => project.LeadersId, mapper => mapper.Column("Leader"));
            Property(project => project.ProjectName, mapper => mapper.Column("Name"));
            Property(project => project.ProjectDescription, mapper => mapper.Column("Description"));
            
            //Set(member => member.Members, mapper =>
            //{
            //    mapper.Cascade(Cascade.All);
            //    mapper.Key(m => m.Column("ProjectId"));
            //},
            //action => action.OneToMany());

            Set(vacancies => vacancies.Vacancies, mapper =>
            {
                mapper.Cascade(Cascade.All);
                mapper.Key(m => m.Column("ProjectId"));
                mapper.Table("Vacancies");
            },
            action => action.OneToMany());

            Property(project => project.UserId, mapper => mapper.Column("Creator"));
            Property(project => project.FromOrganization, mapper => mapper.Column("From Organization"));
            Property(project => project.OrganizationId, mapper => mapper.Column("Organization"));
        }
    }
}
