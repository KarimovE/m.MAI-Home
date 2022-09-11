using HackatonProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HackatonProject.Controllers
{
    public class ForecastController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}