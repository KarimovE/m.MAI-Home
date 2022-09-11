using HackatonProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HackatonProject.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

      
    }
}