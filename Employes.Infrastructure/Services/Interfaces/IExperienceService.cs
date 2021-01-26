using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employes.Infrastructure.Services.Interfaces
{
    public interface IExperienceService
    {
        void AddExperience(int employeId, int languageId);
    }
}
