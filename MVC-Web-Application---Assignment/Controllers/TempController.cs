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
        TempCheck _tempCheck = new TempCheck();

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult TempCheck()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TempCheck(Temp temp)
        {
            _tempCheck.Check(temp.temperature);

            return RedirectToAction(nameof(Index));
        }
    }
}
