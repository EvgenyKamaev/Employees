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

        [HttpGet]
        public ActionResult ShowInfo(int employeId)
        {
            TempData["employeId"] = employeId;
            // return RedirectToAction("Index", "Edit");
            var t  = Url.Action("Index", "Edit");
            return Json(new { redirectUrl = Url.Action("Index", "Edit") });
        }

        public ActionResult Info()
        {
            TempData.Keep("infoModel");
            var info = TempData["infoModel"];
            return View(info);
        }
    }
}