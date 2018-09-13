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
            return View();
        }

        [HttpPost("/game")]
        public ActionResult Create()
        {
            Guess newGuess = new Guess();
            Guess._guessword = Request.Form["new-word"];
            return View("game", newGuess);
        }

        [HttpPost("/game/new")]
        public ActionResult Guess()
        {
            Guess newGuess = new Guess(Request.Form["new-letter"]);
            newGuess.IsMatch();
            return View("game", newGuess);
        }
    }
}
