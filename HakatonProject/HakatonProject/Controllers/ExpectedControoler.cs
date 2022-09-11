using HackatonProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HackatonProject.Controllers
{
    public class ExpectedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}