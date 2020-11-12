using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_Web_Application___Assignment.Model;

namespace MVC_Web_Application___Assignment.Controllers
{
    public class TempController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Temp()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Temp(Temp temp)
        {
            return View("Index", temp);
        }
    }
}
