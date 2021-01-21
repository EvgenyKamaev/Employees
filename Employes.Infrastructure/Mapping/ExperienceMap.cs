using Employes.Infrastructure.Domain;
using System.Data.Entity.ModelConfiguration;

namespace Employes.Infrastructure.Mapping
{
    public class ExperienceMap : EntityTypeConfiguration<ExperienceDomain>
    {
        public ExperienceMap()
        {
            ToTable("Experiences");
            HasKey(domain => domain.ExperienceId);
            HasRequired(domain => domain.Languages).WithMany().HasForeignKey(exp => exp.LanguageId);
        }
    }
}
