using Employes.Infrastructure.Domain;
using System.Data.Entity.ModelConfiguration;

namespace Employes.Infrastructure.Mapping
{
    public class DepartmentMap : EntityTypeConfiguration<DepartmentDomain>
    {
        public DepartmentMap()
        {
            ToTable("Departments");
            HasKey(domain => domain.DepartmentId);
        }
    }
}
