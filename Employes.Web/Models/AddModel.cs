using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Employes.Web.Classes;

namespace Employes.Web.Models
{
    public class AddModel
    {
        public List<DepartmentModel> Departments { get; set; }

        public List<LanguagesModel> Languages { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Age { get; set; }

        public int Gender { get; set; }

        public int Department { get; set; }

        public int Language { get; set; }

        public List<string> Names { get; set; }
    }
}