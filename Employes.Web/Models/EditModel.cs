using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employes.Web.Models
{
    public class EditModel
    {
        public int Id { get; set; }
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public int Age { get; set; }

        public string Department { get; set; }

        public List<int> Language { get; set; }
    }
}