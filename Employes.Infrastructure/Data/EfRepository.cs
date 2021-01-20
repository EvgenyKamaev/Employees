using Employes.Infrastructure.Data.Interfaces;
using Employes.Infrastructure.Domain;
using System;
using System.Data.Entity;
using System.Linq;

namespace Employes.Infrastructure.Data
{
    public class EfRepository<T> : IRepository<T> where T : BaseDomain
    {
        private readonly IDbContext _context;
        private DbSet<T> _entities;

        public EfRepository(IDbContext context)
        {
            _context = context;
        }

        protected virtual DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();
                return _entities;
            }
        }

        public virtual IQueryable<T> Table
        {
            get { return Entities; }
        }

        public virtual void Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                Entities.Add(entity);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual void Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                Entities.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
