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

        [HttpGet]
        public IActionResult Index()
        {
            HttpContext.Session.SetInt32("SecretNum", gameService.NewGame());

            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(GuessGame guessGame)
        {
            ViewBag.secretNum = HttpContext.Session.GetInt32("SecretNum");
            guessGame = gameService.Check(guessGame.Guess, ViewBag.secretNum);

            return View("Index", guessGame);
        }
    }
}
