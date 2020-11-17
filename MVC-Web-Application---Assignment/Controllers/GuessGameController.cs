using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_Web_Application___Assignment.Model;

namespace MVC_Web_Application___Assignment.Controllers
{
    public class GuessGameController : Controller
    {
        GuessGame guessGame = new GuessGame();
        GameService gameService = new GameService();
        static int Counter;

        [HttpGet]
        public IActionResult Index()
        {
            HttpContext.Session.SetInt32("SecretNum", gameService.NewGame());

            Counter = 0;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(GuessGame guessGame)
        {


            ViewBag.secretNum = HttpContext.Session.GetInt32("SecretNum");
            guessGame = gameService.Check(guessGame.Guess, ViewBag.secretNum);

            if (guessGame.Error == false)
            {
                Counter = gameService.Count(Counter);
                ViewBag.counter = Counter;
            }
            else
            {
                ViewBag.counter = Counter;
            }

            return View("Index", guessGame);
        }
    }
}
