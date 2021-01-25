using Employes.Infrastructure.Domain;
using System.Collections.Generic;
using System.Data.Entity;

namespace Employes.Infrastructure.Data
{
    public class DataInitializer : CreateDatabaseIfNotExists<EmployesContext>
    {
        protected override void Seed(EmployesContext db)
        {
            var departmentList = new List<DepartmentDomain>() { new DepartmentDomain() { DepartmentId = 1, Floor = 1 , Name ="Первый отдел"},
            new DepartmentDomain() { DepartmentId = 2, Floor = 2 , Name ="Второй отдел"},
            new DepartmentDomain() { DepartmentId = 3, Floor = 3 , Name ="Третий отдел"},
            new DepartmentDomain() { DepartmentId = 4, Floor = 4 , Name ="Четвертый отдел"}};

            var languagesList = new List<LanguagesDomain>() { new LanguagesDomain() { LanguageId = 1, Name = "C#" },
            new LanguagesDomain() { LanguageId = 2, Name = "Java" },
            new LanguagesDomain() { LanguageId = 3, Name = "C++" },
            new LanguagesDomain() { LanguageId = 4, Name = "Python" }};

            foreach(var language in languagesList)
            {
                db.Languages.Add(language);
            }
            foreach (var department in departmentList)
            {
                db.Departments.Add(department);
            }
            db.SaveChanges();
        }
    }
}
