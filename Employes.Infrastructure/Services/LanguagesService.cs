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
    public class LanguagesService : ILanguagesService
    {
        private readonly IRepository<LanguagesDomain> _languagesRepository;

        public LanguagesService(IRepository<LanguagesDomain> languagesRepository)
        {
            _languagesRepository = languagesRepository;
        }

        public LanguagesDomain[] GetAll()
        {
            return _languagesRepository.Table.ToArray();
        }

        public LanguagesDomain GetById(int languageId)
        {
            return _languagesRepository.Table.FirstOrDefault(domain => domain.LanguageId == languageId);
        }
    }
}
