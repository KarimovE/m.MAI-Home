﻿using HackatonProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HackatonProject.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}