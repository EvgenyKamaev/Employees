using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employes.Infrastructure.Domain
{
    public class ExperienceDomain : BaseDomain
    {
        /// <summary>
        /// Ид языка
        /// </summary>
        public int LanguageId { get; set; }

        public int EmployeId { get; set; }

        public virtual LanguagesDomain Languages { get; set; }
    }
}
