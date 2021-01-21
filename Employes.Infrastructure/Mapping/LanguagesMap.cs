using Employes.Infrastructure.Domain;
using System.Data.Entity.ModelConfiguration;

namespace Employes.Infrastructure.Mapping
{
    public class LanguagesMap : EntityTypeConfiguration<LanguagesDomain>
    {
        public LanguagesMap()
        {
            ToTable("Languages");
            HasKey(domain => domain.LanguageId);
        }
    }
}
