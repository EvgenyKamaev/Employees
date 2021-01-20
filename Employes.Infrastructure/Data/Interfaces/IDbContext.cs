using Employes.Infrastructure.Domain;
using System.Data.Entity;

namespace Employes.Infrastructure.Data.Interfaces
{
    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : BaseDomain;

        int SaveChanges();
    }
}
