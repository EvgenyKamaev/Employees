using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Employes.Infrastructure.Domain;
using Employes.Infrastructure.Enums;
using Employes.Infrastructure.Services.Interfaces;
using Employes.Web.Classes;
using Employes.Web.Models;

namespace Employes.Web.Controllers
{
    public class AddController : Controller
    {
        private readonly IDepartmentsService _departmentsService;
        private readonly ILanguagesService _languagesService;
        private readonly IEmployesService _employesService;

        public AddController(IDepartmentsService departmentsService, ILanguagesService languagesService, IEmployesService employesService)
        {
            _departmentsService = departmentsService;
            _languagesService = languagesService;
            _employesService = employesService;
        }

        public ActionResult Index()
        {
            var names = _employesService.GetAllEmployes().Select(domain => domain.FirstName).ToList();

            var departments = _departmentsService.GetAll().Select(domain => new DepartmentModel()
            {
                DepartmentId = domain.DepartmentId,
                DepartmentName = domain.Name
            }).ToList();

            var languages = _languagesService.GetAll().Select(domain => new LanguagesModel()
            {
                LanguageId = domain.LanguageId,
                Name = domain.Name
            }).ToList();

            var model = new AddModel()
            {
                Departments = departments,
                Languages = languages,
                Names = names
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult AddEmploye(AddModel model)
        {
            try
            {
                var department = _departmentsService.GetById(model.Department);
                var language = _languagesService.GetById(model.Language);
                var data = new EmployesDomain()
                {
                    LastName = model.LastName,
                    FirstName = model.FirstName,
                    Age = Int32.Parse(model.Age),
                    IsDeleted = false,
                    Department = department,
                    Gender = (EGender)model.Gender
                };
                data.Experiences.Add(new ExperienceDomain()
                {
                    LanguageId = language.LanguageId,
                    
                });
                _employesService.AddEmploye(data);
                return Json(new { redirectUrl = Url.Action("Index", "Home") });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}