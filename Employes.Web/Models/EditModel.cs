using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Employes.Web.Classes;

namespace Employes.Web.Models
{
    public class EditModel
    {
        public int Id { get; set; }
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public int Age { get; set; }

        public string Department { get; set; }

        public string SelectedLanguage { get; set; }

        public List<string> Departments { get; set; }

        public List<string> Languages { get; set; }
    }
}