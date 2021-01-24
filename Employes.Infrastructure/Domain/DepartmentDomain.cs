using System.Collections.Generic;

namespace Employes.Infrastructure.Domain
{
    /// <summary>
    /// Отдел
    /// </summary>
    public class DepartmentDomain : BaseDomain
    {
        /// <summary>
        /// Ид
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Этаж
        /// </summary>
        public int Floor { get; set; }
    }
}
