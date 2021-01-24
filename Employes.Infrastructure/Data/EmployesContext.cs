using Employes.Infrastructure.Data.Interfaces;
using System;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using Employes.Infrastructure.Domain;

namespace Employes.Infrastructure.Data
{
    public class EmployesContext : DbContext, IDbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => !string.IsNullOrEmpty(type.Namespace) &&
                                type.BaseType != null &&
                                type.BaseType.IsGenericType &&
                                type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            foreach (dynamic configurationInstance in typesToRegister.Select(Activator.CreateInstance))
                modelBuilder.Configurations.Add(configurationInstance);

            base.OnModelCreating(modelBuilder);
        }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : BaseDomain
            => base.Set<TEntity>();

        public DbSet<DepartmentDomain> Departments { get; set; }
        public DbSet<LanguagesDomain> Languages { get; set; }

        static EmployesContext()
        {
            Database.SetInitializer<EmployesContext>(new DataInitializer());
        }
    }
}
