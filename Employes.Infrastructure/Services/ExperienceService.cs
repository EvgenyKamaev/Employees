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
    public class ExperienceService : IExperienceService
    {
        private readonly IRepository<ExperienceDomain> _experienceRepository;

        public ExperienceService(IRepository<ExperienceDomain> experienceRepository)
        {
            _experienceRepository = experienceRepository;
        }

        public void AddExperience(int employeId, int languageId)
        {
            var domain = new ExperienceDomain()
            {
                EmployeId = employeId,
                LanguageId = languageId
            };
            _experienceRepository.Insert(domain);
        }
    }
}
