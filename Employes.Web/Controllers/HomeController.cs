using Employes.Infrastructure.Services.Interfaces;
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
            _employesService.GetAllEmployes();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}