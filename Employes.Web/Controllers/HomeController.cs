using Employes.Infrastructure.Services.Interfaces;
using Employes.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employes.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployesService _employesService;

        public HomeController(IEmployesService employesService)
        {
            _employesService = employesService;
        }

        public ActionResult Index()
        {
            var data = _employesService.GetAllNotDeletedEmployes().Select(employe => new HomeModel()
            {
                Id = employe.EmployeId,
                LastName = employe.LastName,
                FirstName = employe.FirstName,
                Age = employe.Age,
                Department = employe.Department.Name
            }).ToList();

            return View(data);
        }

        [HttpGet]
        public void DeleteEmploye(int employeId)
        {
            try
            {
                _employesService.DeleteEmploye(employeId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}