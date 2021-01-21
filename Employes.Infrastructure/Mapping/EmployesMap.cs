using Employes.Infrastructure.Domain;
using System.Data.Entity.ModelConfiguration;

namespace Employes.Infrastructure.Mapping
{
    public class EmployesMap : EntityTypeConfiguration<EmployesDomain>
    {
        public EmployesMap()
        {
            ToTable("Employes");
            HasKey(domain => domain.EmployeId);
        }
    }
}
