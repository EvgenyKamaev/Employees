using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employes.Infrastructure.Data.Interfaces;
using Employes.Infrastructure.Domain;
using Employes.Infrastructure.Services.Interfaces;

namespace Employes.Infrastructure.Services
{
    public class DepartmentsService : IDepartmentsService
    {
        private readonly IRepository<DepartmentDomain> _departmentsRepository;

        public DepartmentsService(IRepository<DepartmentDomain> departmentsRepository)
        {
            _departmentsRepository = departmentsRepository;
        }

        public DepartmentDomain[] GetAll()
        {
            return _departmentsRepository.Table.ToArray();
        }

        public DepartmentDomain GetById(int departmentId)
        {
            return _departmentsRepository.Table.FirstOrDefault(domain => domain.DepartmentId == departmentId);
        }
    }
}
