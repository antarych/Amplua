using System.Collections.Generic;
using Journalist;


namespace ProjectManagement.Domain
{
    public class Vacancy
    {
        public Vacancy(string name, string description, Categories categoty, List<string> skills)
        {
            Require.NotNull(name, nameof(name));
            Require.NotNull(description, nameof(description));
            Require.NotNull(categoty, nameof(categoty));
            Require.NotNull(skills, nameof(skills));

            Name = name;
            Description = description;
            Category = categoty;
            Skills = skills;
        }

        public string Name { get; protected set; }

        public string Description { get; protected set; }

        public Categories Category { get; protected set; }

        public List<string> Skills { get; protected set; }
    }
}
