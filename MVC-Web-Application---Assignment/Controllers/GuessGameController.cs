using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_Web_Application___Assignment.Models;

namespace MVC_Web_Application___Assignment.Controllers
{
    public class GuessGameController : Controller
    {
        Highscore highscore = new Highscore();
        GuessGame guessGame = new GuessGame();
        GameService gameService = new GameService();
        static int Counter;

        [HttpGet]
        public IActionResult Index()
        {
            HttpContext.Session.SetInt32("SecretNum", gameService.NewGame());
            ViewBag.High1 = HttpContext.Session.GetInt32("High1");
            ViewBag.High2 = HttpContext.Session.GetInt32("High2");
            ViewBag.High3 = HttpContext.Session.GetInt32("High3");
            Counter = 0;

            // sets all scores to zero
            if (ViewBag.High1 == null && ViewBag.High1 == null && ViewBag.High1 == null)
            {
                HttpContext.Session.SetInt32("High1", 0);
                HttpContext.Session.SetInt32("High2", 0);
                HttpContext.Session.SetInt32("High3", 0);

                ViewBag.High1 = HttpContext.Session.GetInt32("High1");
                ViewBag.High2 = HttpContext.Session.GetInt32("High2");
                ViewBag.High3 = HttpContext.Session.GetInt32("High3");
            }


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(GuessGame guessGame)
        {

            ViewBag.High1 = HttpContext.Session.GetInt32("High1");
            ViewBag.High2 = HttpContext.Session.GetInt32("High2");
            ViewBag.High3 = HttpContext.Session.GetInt32("High3");

            ViewBag.secretNum = HttpContext.Session.GetInt32("SecretNum");
            guessGame = gameService.Check(guessGame.Guess, ViewBag.secretNum);

            if (guessGame.Error == false || guessGame.Win == false)
            {
                Counter = gameService.Count(Counter);
                ViewBag.counter = Counter;
            }
            else
            {
                ViewBag.counter = Counter;
            }

            if (guessGame.Win == true)
            {
                highscore = gameService.CheckHigh(Counter, ViewBag.High1, ViewBag.High2, ViewBag.High3);
                ViewBag.High1 = highscore.High1;
                ViewBag.High2 = highscore.High2;
                ViewBag.High3 = highscore.High3;

                HttpContext.Session.SetInt32("High1", highscore.High1);
                HttpContext.Session.SetInt32("High2", highscore.High2);
                HttpContext.Session.SetInt32("High3", highscore.High3);
            }

            return View("Index", guessGame);
        }
    }
}
