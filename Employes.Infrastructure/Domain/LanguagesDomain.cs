using System.Collections.Generic;

namespace Employes.Infrastructure.Domain
{
    public class LanguagesDomain : BaseDomain
    {
        /// <summary>
        /// Ид
        /// </summary>
        public int LanguageId { get; set; }

        /// <summary>
        /// Название 
        /// </summary>
        public string Name { get; set; }
    }
}
