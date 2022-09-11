using HackatonProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HackatonProject.Controllers
{
    public class SocketsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}