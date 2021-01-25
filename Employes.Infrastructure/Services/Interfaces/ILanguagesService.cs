using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employes.Infrastructure.Domain;

namespace Employes.Infrastructure.Services.Interfaces
{
    public interface ILanguagesService
    {
        LanguagesDomain[] GetAll();

        LanguagesDomain GetById(int languageId);
    }
}
