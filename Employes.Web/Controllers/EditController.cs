using Employes.Infrastructure.Services.Interfaces;
using Employes.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employes.Web.Controllers
{
    public class EditController : Controller
    {
        private readonly IEmployesService _employesService;

        public EditController(IEmployesService employesService)
        {
            _employesService = employesService;
        }

        public ActionResult Index()
        {
            TempData.Keep("employeId");
            var employeId = (int) TempData["employeId"];

            var info = _employesService.GetEmployeById(employeId);

            var model = new EditModel()
            {
                Id = employeId,
                LastName = info.LastName,
                FirstName = info.FirstName,
                Age = info.Age,
                Department = info.Department.Name,
                Language = info.Experiences.Select(lang => lang.LanguageId).ToList()
            };
            return View(model);
        }
    }
}