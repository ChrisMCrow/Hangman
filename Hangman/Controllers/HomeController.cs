using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Hangman.Models;

namespace Hangman.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            Guess.Reset();
            return View();
        }

        [HttpPost("/game")]
        public ActionResult Create()
        {
            Guess._guessword = Request.Form["new-word"];
            Guess._guessword = Guess._guessword.ToUpper();
            return View("Start");
        }

        [HttpGet("/game/new")]
        public ActionResult Start()
        {
            Guess newGuess = new Guess();
            return View("game", newGuess);
        }

        [HttpPost("/game/new")]
        public ActionResult Next()
        {
            Guess newGuess = new Guess(Request.Form["new-letter"]);
            newGuess.IsMatch();
            Guess.CheckGameOver();
            if (Guess.CheckGameOver())
            {
                return View("GameOver", newGuess);
            }
            else
            {
                return View("game", newGuess);
            }
        }
    }
}
