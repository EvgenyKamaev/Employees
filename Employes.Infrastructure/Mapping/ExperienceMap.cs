using Employes.Infrastructure.Domain;
using System.Data.Entity.ModelConfiguration;

namespace Employes.Infrastructure.Mapping
{
    public class ExperienceMap : EntityTypeConfiguration<ExperienceDomain>
    {
        public ExperienceMap()
        {
            ToTable("Experiences");
            //HasKey(domain => domain.EmployeId);
        }
    }
}
