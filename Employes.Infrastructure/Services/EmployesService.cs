using Employes.Infrastructure.Data.Interfaces;
using Employes.Infrastructure.Domain;
using Employes.Infrastructure.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Employes.Infrastructure.Services
{
    public class EmployesService : IEmployesService
    {
        private readonly IRepository<EmployesDomain> _employesRepository;

        public EmployesService(IRepository<EmployesDomain> employesRepository)
        {
            _employesRepository = employesRepository;
        }

        public EmployesDomain GetEmployeById(int employeId)
        {
            return _employesRepository.Table.FirstOrDefault(employe => employe.EmployeId == employeId);
        }

        public void AddEmploye(EmployesDomain employe)
        {
            _employesRepository.Insert(employe);
        }

        public EmployesDomain[] GetAllEmployes()
        {
            return _employesRepository.Table.ToArray();
        }

        public List<EmployesDomain> GetAllNotDeletedEmployes()
        {
            return _employesRepository.Table.Where(employe => !employe.IsDeleted).ToList();
        }

        public void UpdateEmployeInfo(EmployesDomain employeInfo)
        {
            _employesRepository.Update(employeInfo);
        }

        public void DeleteEmploye(int employeId)
        {
            var employeDomain = GetEmployeById(employeId);
            employeDomain.IsDeleted = true;
            UpdateEmployeInfo(employeDomain);
        }
    }
}
