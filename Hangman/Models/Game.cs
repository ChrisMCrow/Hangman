using System;
using System.Collections.Generic;

namespace Hangman.Models
{
    public class Guess
    {
        private static string _guessword { get; set;}
        private List<Guess> _guesses = new List<Guess> {};
        private static string[] _images = { "one", "two", "three", "four", "five", "six"};
        private static int missCount = 0;
        public string guessLetter;
        public bool match;

        public Guess(string guess)
        {
            guessLetter = guess;
            _guesses.Add(this);
        }

        public bool IsMatch()
        {
          match = true;
        }



    }
}
