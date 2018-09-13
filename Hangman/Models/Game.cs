using System;
using System.Collections.Generic;
using System.Linq;

namespace Hangman.Models
{
    public class Guess
    {
        public static string _guessword { get; set;}
        public static int missCount = 0;
        public string guessLetter;
        public bool match;
        public static string blanks;
        public string gameOver = "";

        public Guess()
        {
            CreateBlanks();
        }

        public Guess(string guess)
        {
            guessLetter = guess.ToUpper();
            PopulateBlanks();
        }

        public void CreateBlanks()
        {
            for(int i = 0; i < _guessword.Length; i++)
            {
                blanks += "_ ";
            }
        }

        public void PopulateBlanks()
        {
            for(int i = 0; i < _guessword.Length; i++)
            {
                if(_guessword[i] == guessLetter[0])
                {
                    blanks = blanks.Remove(i * 2, 1).Insert(i * 2, guessLetter);
                }
            }

        }



        public bool IsMatch()
        {
            if (_guessword.Contains(guessLetter))
            {
                match = true;
                return true;
            }
            else
            {
                missCount++;
                match = false;
                return false;
            }
        }

        public static string GetImg()
        {
          return missCount + ".png";
        }

        public static bool CheckGameOver()
        {
            if (missCount >= 6)
            {
                return true;
            }
            else if (!blanks.Contains("_"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void Reset()
        {
            missCount = 0;
            blanks = "";
        }
    }
}
