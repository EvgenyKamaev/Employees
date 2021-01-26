using Employes.Infrastructure.Services.Interfaces;
using Employes.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Employes.Infrastructure.Enums;
using Employes.Web.Classes;

namespace Employes.Web.Controllers
{
    public class EditController : Controller
    {
        private readonly IEmployesService _employesService;
        private readonly IDepartmentsService _departmentsService;
        private readonly ILanguagesService _languagesService;
        private readonly IExperienceService _experienceService;

        public EditController(IEmployesService employesService, IDepartmentsService departmentsService, ILanguagesService languagesService, IExperienceService experienceService)
        {
            _employesService = employesService;
            _departmentsService = departmentsService;
            _languagesService = languagesService;
            _experienceService = experienceService;
        }

        public ActionResult Index()
        {
            TempData.Keep("employeInfo");
            var employeInfo = (HomeModel)TempData["employeInfo"];

            var info = _employesService.GetEmployeById(employeInfo.Id);

            var departments = _departmentsService.GetAll().Select(domain => domain.Name).ToList();

            var dataLang = _languagesService.GetAll();

            var languages = dataLang.Select(domain => domain.Name).ToList();

            var model = new EditModel()
            {
                Id = employeInfo.Id,
                LastName = info.LastName,
                FirstName = info.FirstName,
                Age = info.Age,
                Department = info.Department.Name,
                SelectedLanguage = dataLang.FirstOrDefault(lang => lang.LanguageId == info.Experience.LanguageId).Name,
                Departments = departments,
                Languages = languages
            };
            return View(model);
        }

        [HttpPost]
        public void UpdateInfo(EditModel model)
        {
            var department = _departmentsService.GetAll().FirstOrDefault(domain => domain.Name == model.Department);
            var language = _languagesService.GetAll().FirstOrDefault(domain => domain.Name == model.SelectedLanguage);
            var data = _employesService.GetEmployeById(model.Id);
            data.LastName = model.LastName;
            data.FirstName = model.FirstName;
            data.Age = model.Age;
            data.Department = department;

            if (data.Experience.Languages.Name != model.SelectedLanguage)
            {
                _experienceService.AddExperience(model.Id, language.LanguageId);
            }

            _employesService.UpdateEmployeInfo(data);
        }
    }
}