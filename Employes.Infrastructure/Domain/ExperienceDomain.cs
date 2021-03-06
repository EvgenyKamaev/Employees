﻿using System.Collections.Generic;
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

        /// <summary>
        /// Ид
        /// </summary>
        public int EmployeId { get; set; }

        /// <summary>
        /// Языки
        /// </summary>
        public virtual LanguagesDomain Languages { get; set; }
    }
}
