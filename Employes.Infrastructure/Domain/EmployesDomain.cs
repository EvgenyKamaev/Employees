using System.Collections.Generic;
using Employes.Infrastructure.Enums;

namespace Employes.Infrastructure.Domain
{
    /// <summary>
    /// Сотрудники
    /// </summary>
    public class EmployesDomain : BaseDomain
    {
        /// <summary>
        /// Id записи
        /// </summary>
        public int EmployeId { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Возраст
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        public EGender Gender { get; set; }

        /// <summary>
        /// Удален?
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Отдел
        /// </summary>
        public virtual DepartmentDomain Department { get; set; }

        /// <summary>
        /// Опыт
        /// </summary>
        public virtual List<ExperienceDomain> Experiences { get; set; } = new List<ExperienceDomain>();
    }
}
