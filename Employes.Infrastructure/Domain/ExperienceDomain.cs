using System.Collections.Generic;

namespace Employes.Infrastructure.Domain
{
    public class ExperienceDomain : BaseDomain
    {
        /// <summary>
        /// Ид
        /// </summary>
        public int ExperienceId { get; set; }

        /// <summary>
        /// Сотрудник
        /// </summary>
        public virtual EmployesDomain Employe { get; set; }

        /// <summary>
        /// Языки
        /// </summary>
        public virtual List<LanguagesDomain> Languages { get; set; } = new List<LanguagesDomain>();
    }
}
