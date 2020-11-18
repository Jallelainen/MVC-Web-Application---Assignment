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
        

        [HttpGet]
        public IActionResult Index()
        {
            //Set random number
            HttpContext.Session.SetInt32("SecretNum", gameService.NewGame());
            
            //Load highscores
            ViewBag.High1 = HttpContext.Session.GetInt32("High1");
            ViewBag.High2 = HttpContext.Session.GetInt32("High2");
            ViewBag.High3 = HttpContext.Session.GetInt32("High3");

            //Sets counter at zero and stores it in session
            guessGame.Counter = 0;
            HttpContext.Session.SetInt32("count", guessGame.Counter);

            //Sets all scores to zero if it is first time visiting page
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
            //Gets high scores
            ViewBag.High1 = HttpContext.Session.GetInt32("High1");
            ViewBag.High2 = HttpContext.Session.GetInt32("High2");
            ViewBag.High3 = HttpContext.Session.GetInt32("High3");

            //Gets secret number
            ViewBag.secretNum = HttpContext.Session.GetInt32("SecretNum");
            guessGame = gameService.Check(guessGame.Guess, ViewBag.secretNum);

            //Gets counter, converts it to int
            var count = HttpContext.Session.GetInt32("count");
            if (count != null)
            {
                guessGame.Counter = (int)count;
            }

            //Increases counter by 1 of guess is valid.
            if (guessGame.Error == false && guessGame.Win == false)
            {
                guessGame.Counter = gameService.Count(guessGame.Counter);
                HttpContext.Session.SetInt32("count", guessGame.Counter);
                ViewBag.counter = guessGame.Counter;
            }
            else
            {
                ViewBag.counter = guessGame.Counter;
            }

            //Compares and saves Highscore if correct guess.
            if (guessGame.Win == true)
            {
                highscore = gameService.CheckHigh(guessGame.Counter, ViewBag.High1, ViewBag.High2, ViewBag.High3);
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
